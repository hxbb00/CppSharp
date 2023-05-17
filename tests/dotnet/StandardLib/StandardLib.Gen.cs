using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Utils;

namespace CppSharp.Tests
{
    public class StandardLibTestsGenerator : GeneratorTest
    {
        public StandardLibTestsGenerator(GeneratorKind kind)
            : base("StandardLib", kind)
        {
        }

        public override void Preprocess(Driver driver, ASTContext ctx)
        {
            ctx.SetClassAsValueType("IntWrapperValueType");
        }

        public static void Main(string[] args)
        {
            if(args.Length > 0){
                Console.WriteLine("DBG...");
                Console.ReadLine();
            }

            ConsoleDriver.Run(new StandardLibTestsGenerator(GeneratorKind.CLI));
        }
    }
}
