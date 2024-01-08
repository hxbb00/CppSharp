#!/bin/bash
set -e
builddir=$(cd "$(dirname "$0")"; pwd)
platform=x64
dotnet_platform=x64
vs=vs2019
configuration=Release
build_only=false
ci=false
target_framework=
verbosity=minimal
rootdir="$builddir/.."
bindir="$rootdir/bin"
objdir="$builddir/obj"
gendir="$builddir/gen"
slnpath="$rootdir/CppSharp.sln"
artifacts="$rootdir/artifacts"
oshost=""
os=""
test=

if [[ $(uname -m) != *"64"* ]]; then
  platform=x86
fi

build()
{
  if [ $ci = true ]; then
    clean
  fi

  if [ $ci = true ] || [ $build_only = false ]; then
    generate
    restore
  fi

  if [ $oshost = "linux" ] || [ $oshost = "macosx" ]; then
    config=$(tr '[:upper:]' '[:lower:]' <<< ${configuration}_$dotnet_platform) make -C "$builddir/gmake/"
  fi

  find_msbuild
  $msbuild "$slnpath" -p:Configuration=$configuration -p:Platform=$dotnet_platform -v:$verbosity -nologo

  if [ $ci = true ]; then
    test
  fi
}

generate_config()
{
  "$builddir/premake.sh" --file="$builddir/premake5.lua" $vs --os=$os --arch=$platform --configuration=$configuration --target-framework=$target_framework --config_only
}

generate()
{
  download_llvm

  if [ "$os" = "linux" ] || [ "$os" = "macosx" ]; then
    "$builddir/premake.sh" --file="$builddir/premake5.lua" gmake2 --os=$os --arch=$platform --configuration=$configuration --target-framework=$target_framework "$@"
  fi

  "$builddir/premake.sh" --file="$builddir/premake5.lua" $vs --os=$os --arch=$platform --configuration=$configuration --target-framework=$target_framework
}

restore()
{
  find_msbuild
  $msbuild "$slnpath" -p:Configuration=$configuration -p:Platform=$dotnet_platform -v:$verbosity -t:restore -nologo
}

prepack()
{
  find_msbuild
  $msbuild "$slnpath" -t:prepack -p:Configuration=$configuration -p:Platform=$dotnet_platform -v:$verbosity -nologo
}

pack()
{
  find_msbuild
  $msbuild -t:restore "$rootdir/src/Package/CppSharp.Package.csproj" -p:Configuration=$configuration -p:Platform=$dotnet_platform
  $msbuild -t:pack "$rootdir/src/Package/CppSharp.Package.csproj" -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg -p:Configuration=$configuration -p:Platform=$dotnet_platform -p:PackageOutputPath="$rootdir/artifacts"

  if [ $oshost = "windows" -a $platform = "x64" ]; then
    $msbuild -t:restore "$rootdir/src/Runtime/CppSharp.Runtime.csproj" -p:Configuration=$configuration -p:Platform=$dotnet_platform
    $msbuild -t:pack "$rootdir/src/Runtime/CppSharp.Runtime.csproj" -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg -p:Configuration=$configuration -p:Platform=$dotnet_platform -p:PackageOutputPath="$rootdir/artifacts"
  fi
}

test()
{
  dotnet test {"$bindir/${configuration}_$platform","$gendir"/*}/*.Tests*.dll --nologo --blame
}

clean()
{  
  rm -rf "$objdir"
  rm -rf "$gendir"
  rm -rf "$bindir"
  rm -rf "$builddir/gmake"
  rm -rf "$builddir/$vs"
  rm -rf "$slnpath"
}

download_premake()
{
  premake_dir="$builddir/premake"
  premake_filename=premake5
  premake_archive_ext=tar.gz
  if [ $oshost = "windows" ]; then
    premake_filename=$premake_filename.exe
    premake_archive_ext=zip
  fi
  premake_path=$premake_dir/$premake_filename
  echo "premake_local_path... $premake_path"
  if ! [ -f "$premake_path" ]; then
    premake_url=https://github.com/hxbb00/premake-core/releases/download/latest/premake-$oshost-$platform.zip  
    echo "Downloading and unpacking Premake... $premake_url"
    curl -L -O $premake_url
    unzip premake-$oshost-$platform.zip $premake_filename -d "$premake_dir"
    chmod +x "$premake_path"
    rm premake-$oshost-$platform.zip
    ls -al "$premake_dir"
  fi
}

download_llvm()
{
  "$builddir/premake.sh" --file="$builddir/llvm/LLVM.lua" download_llvm --os=$os --arch=$platform --configuration=$configuration
}

clone_llvm()
{
  "$builddir/premake.sh" --file="$builddir/llvm/LLVM.lua" clone_llvm --os=$os --arch=$platform --configuration=$configuration
}

build_llvm()
{
  "$builddir/premake.sh" --file="$builddir/llvm/LLVM.lua" build_llvm --os=$os --arch=$platform --configuration=$configuration
}

package_llvm()
{
  "$builddir/premake.sh" --file="$builddir/llvm/LLVM.lua" package_llvm --os=$os --arch=$platform --configuration=$configuration
}

detect_dotnet_arch(){
  if [ "$platform" = "aarch64" ]; then
    dotnet_platform=arm64
  else
    dotnet_platform=$platform
  fi

  echo "dotnet platform $dotnet_platform"
}

detect_os()
{
  case "$(uname -s)" in
    Darwin)
      oshost=macosx
      ;;
    Linux)
      oshost=linux
      ;;
    CYGWIN*|MINGW32*|MSYS*|MINGW*)
      oshost=windows
      ;;
    *)
      echo "Unsupported platform"
      exit 1
      ;;
  esac

  os=$oshost
}

find_msbuild()
{
  if [ -x "$(command -v MSBuild.exe)" ]; then
    msbuild="MSBuild.exe"
  else
    msbuild="dotnet msbuild"
  fi
}

cmd=$(tr '[:upper:]' '[:lower:]' <<< $1)
detect_os

while [[ $# > 0 ]]; do
  option=$(tr '[:upper:]' '[:lower:]' <<< "${1/#--/-}")
  case "$option" in
    -debug)
      configuration=Debug
      ;;
    -configuration)
      configuration=$2
      shift
      ;;      
    -platform)
      platform=$2
      shift
      ;;
    -vs)
      vs=vs$2
      shift
      ;;
    -os)
      os=$2
      shift
      ;;
    -target-framework)
      target_framework=$2
      echo $target_framework
      shift
      ;;
    -ci)
      ci=true
      export CI=true
      ;;
    -build_only)
      build_only=true
      ;;
  esac
  shift
done

detect_dotnet_arch

download_premake

case "$cmd" in
  clean)
    clean
    ;;
  generate)
    generate
    ;;
  generate_config)
    generate_config
    ;;    
  prepack)
    prepack
    ;;
  pack)
    pack
    ;;
  restore)
    restore
    ;;
  test)
    test
    ;;
  download_llvm)
    download_llvm
    ;;
  clone_llvm)
    clone_llvm
    ;;
  build_llvm)
    build_llvm
    ;;
  package_llvm)
    package_llvm
    ;;
  install_tools)
    download_premake
    ;;
   *)
    build
    ;;
esac
