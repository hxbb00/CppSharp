
## Tips
1. not support Vs2022, run dotnet command on vs2019 command prompt, like:

> @echo init env

> call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsx86_amd64.bat"

> @echo start build

> dotnet "%~dp0ABC.dll"

2. build on windows

> "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\VC\Auxiliary\Build\vcvarsx86_amd64.bat"

> "D:\Program Files\Git\bin\sh.exe" ./build/build.sh clean

> "D:\Program Files\Git\bin\sh.exe" ./build/build.sh generate -platform x64

> "D:\Program Files\Git\bin\sh.exe" ./build/build.sh restore -platform x64

> "D:\Program Files\Git\bin\sh.exe" ./build/build.sh -build_only -platform x64

3. Debug on Windows  
Windows µ÷ÊÔ£ºĞŞ¸Ä.\build\config.props  
Configuration -> Debug  
CI-> true  