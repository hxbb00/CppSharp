using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Parser;
using CppSharp.Passes;
using CppAbi = CppSharp.Parser.AST.CppAbi;

namespace CppSharp
{
    /// <summary>
    /// Generates C# and C++/CLI bindings for the CppSharp.CppParser project.
    /// </summary>
    class ParserGen : ILibrary
    {
        internal readonly GeneratorKind Kind;
        internal readonly string Triple;
        internal readonly bool IsGnuCpp11Abi;

        public ParserGen(GeneratorKind kind, string triple,
            bool isGnuCpp11Abi = false)
        {
            Kind = kind;
            Triple = triple;
            IsGnuCpp11Abi = isGnuCpp11Abi;
        }

        static string GetSourceDirectory(string dir)
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

            while (directory != null)
            {
                var path = Path.Combine(directory.FullName, dir);

                if (Directory.Exists(path))
                    return path;

                directory = directory.Parent;
            }

            throw new Exception("Could not find build directory: " + dir);
        }

        public void Setup(Driver driver)
        {
            var parserOptions = driver.ParserOptions;
            parserOptions.TargetTriple = Triple;

            var options = driver.Options;
            options.GeneratorKind = Kind;
            options.CommentKind = CommentKind.BCPLSlash;
            var parserModule = options.AddModule("CppSharp.CppParser");
            parserModule.Headers.AddRange(new[]
            {
                "AST.h",
                "Sources.h",
                "CppParser.h"
            });
            parserModule.OutputNamespace = string.Empty;

            if (parserOptions.IsMicrosoftAbi)
                parserOptions.MicrosoftMode = true;

            if (Triple.Contains("apple"))
                SetupMacOptions(parserOptions);

            if (Triple.Contains("linux"))
                SetupLinuxOptions(parserOptions);

            var basePath = Path.Combine(GetSourceDirectory("src"), "CppParser");
            parserModule.IncludeDirs.Add(basePath);
            parserModule.LibraryDirs.Add(".");

            options.OutputDir = Path.Combine(GetSourceDirectory("src"), "CppParser",
                "Bindings", Kind.ToString());

            var extraTriple = IsGnuCpp11Abi ? "-cxx11abi" : string.Empty;

            if (Kind == GeneratorKind.CSharp)
                options.OutputDir = Path.Combine(options.OutputDir, parserOptions.TargetTriple + extraTriple);

            options.CheckSymbols = false;
            //options.Verbose = true;
            parserOptions.UnityBuild = true;
        }

        private void SetupLinuxOptions(ParserOptions options)
        {
            options.MicrosoftMode = false;
            options.NoBuiltinIncludes = true;

            if(Platform.IsLinux)
            {
                options.SetupLinux(string.Empty);
            }
            else
            {
                var x64 = Path.Combine(GetSourceDirectory("build"), "headers", "x86_64-linux-gnu");
                if(Directory.Exists(x64))
                {
                    options.SetupLinux(x64);
                }
                else
                {
                    var arm64 = Path.Combine(GetSourceDirectory("build"), "headers", "aarch64-linux-gnu");
                    if(Directory.Exists(arm64))
                    {
                        options.SetupLinux(arm64);
                    }
                }
            }
            options.AddDefines("_GLIBCXX_USE_CXX11_ABI=" + (IsGnuCpp11Abi ? "1" : "0"));
        }

        private static void SetupMacOptions(ParserOptions options)
        {
            if (Platform.IsMacOS)
            {
                options.SetupXcode();
                return;
            }

            options.MicrosoftMode = false;
            options.NoBuiltinIncludes = true;

            var headersPath = Path.Combine(GetSourceDirectory("build"), "headers",
                "osx");

            options.AddSystemIncludeDirs(Path.Combine(headersPath, "include", "c++", "v1"));
            options.AddSystemIncludeDirs(options.BuiltinsDir);
            options.AddSystemIncludeDirs(Path.Combine(headersPath, "include"));
            options.AddArguments("-stdlib=libc++");
        }

        public void SetupPasses(Driver driver)
        {
        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
            ctx.RenameNamespace("CppSharp::CppParser", "Parser");

            if (driver.Options.IsCSharpGenerator)
            {
                driver.Generator.OnUnitGenerated += o =>
                {
                    Block firstBlock = o.Outputs[0].RootBlock.Blocks[1];
                    if (o.TranslationUnit.Module == driver.Options.SystemModule)
                    {
                        firstBlock.NewLine();
                        firstBlock.WriteLine("[assembly:InternalsVisibleTo(\"CppSharp.Parser.CSharp\")]");
                    }
                    else
                    {
                        firstBlock.WriteLine("using System.Runtime.CompilerServices;");
                        firstBlock.NewLine();
                        firstBlock.WriteLine("[assembly:InternalsVisibleTo(\"CppSharp.Parser\")]");
                    }
                };
            }
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("DBG...");
            Console.ReadLine();
            if (Platform.IsWindows)
            {
                Console.WriteLine("Generating the C++/CLI parser bindings for Windows...");
                ConsoleDriver.Run(new ParserGen(GeneratorKind.CLI, "i686-pc-win32-msvc"));
                Console.WriteLine();

                Console.WriteLine("Generating the C# parser bindings for Windows...");
                ConsoleDriver.Run(new ParserGen(GeneratorKind.CSharp, "i686-pc-win32-msvc"));
                Console.WriteLine();

                Console.WriteLine("Generating the C# 64-bit parser bindings for Windows...");
                ConsoleDriver.Run(new ParserGen(GeneratorKind.CSharp, "x86_64-pc-win32-msvc"));
                Console.WriteLine();
            }

            var osxHeadersPath = Path.Combine(GetSourceDirectory("build"), @"headers/osx");
            if (Directory.Exists(osxHeadersPath) || Platform.IsMacOS)
            {
                Console.WriteLine("Generating the C# parser bindings for OSX...");
                ConsoleDriver.Run(new ParserGen(GeneratorKind.CSharp, "i686-apple-darwin12.4.0"));
                Console.WriteLine();

                Console.WriteLine("Generating the C# parser bindings for OSX...");
                ConsoleDriver.Run(new ParserGen(GeneratorKind.CSharp, "x86_64-apple-darwin12.4.0"));
                Console.WriteLine();
            }

            var linuxHeadersPath = Path.Combine(GetSourceDirectory("build"), @"headers/x86_64-linux-gnu");
            if (Directory.Exists(linuxHeadersPath))
            {
                GenLinux("x86_64-linux-gnu");
            }
            var linuxaarch64HeadersPath = Path.Combine(GetSourceDirectory("build"), @"headers/aarch64-linux-gnu");
            if (Directory.Exists(linuxaarch64HeadersPath))
            {
                GenLinux("aarch64-linux-gnu");
            }
            if (Platform.IsLinux)
            {
                if(System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture == System.Runtime.InteropServices.Architecture.Arm64)
                {
                    GenLinux("aarch64-linux-gnu");
                }
                else
                {
                    GenLinux("x86_64-linux-gnu");
                }
            }
        }

        static void GenLinux(string triple){
            Console.WriteLine("Generating the C# parser bindings for Linux...");
            ConsoleDriver.Run(new ParserGen(GeneratorKind.CSharp, triple));
            Console.WriteLine();

            Console.WriteLine("Generating the C# parser bindings for Linux (GCC C++11 ABI)...");
            ConsoleDriver.Run(new ParserGen(GeneratorKind.CSharp, triple,
                isGnuCpp11Abi: true));
            Console.WriteLine();
        }
    }
}
