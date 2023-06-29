@echo off
dotnet publish -r win-x64 -c Release -o .\publish\ /p:PublishSingleFile=true
xcopy .\publish\TotallySaf*piz.exe .\publish\af1le\payload.bak /Y
xcopy .\publish\af1le\payload.bak .\TotallySafe.Web\af1le\payload.bak /Y