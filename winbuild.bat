@echo init first: "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\VC\Auxiliary\Build\vcvarsx86_amd64.bat"
"D:\Program Files\Git\bin\sh.exe" ./build/build.sh clean
"D:\Program Files\Git\bin\sh.exe" ./build/build.sh generate -platform x64
"D:\Program Files\Git\bin\sh.exe" ./build/build.sh restore -platform x64
"D:\Program Files\Git\bin\sh.exe" ./build/build.sh -build_only -platform x64