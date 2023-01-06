#!/bin/sh

DIR=$( cd "$( dirname "$0" )" && pwd )
UNA="$(uname -s)"

case "$UNA" in

   Darwin|Linux)
    if [[ $UNA =~ 'arm64' ]] | [[ $UNA =~ 'aarch64' ]]
    then
        echo "ARM platform"
        premake5 "$@"        
    else
        echo "X86 platform"
        "$DIR/premake/premake5" "$@"
    fi
    ;;

   CYGWIN*|MINGW32*|MSYS*|MINGW*)
     "$DIR/premake/premake5.exe" "$@"
     ;;

   *)
    echo "Unsupported platform"
    exit 1
     ;;
esac
