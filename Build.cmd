@echo off

echo Veronique - build task
echo.

echo Restoring nuget packages
nuget restore Veronique.sln
if errorlevel 1 goto error

echo Setting version number
.\Build\Packages\Veronique.1.2.0\tools\Veronique
if errorlevel 1 goto error

echo Building solution (release)
msbuild.exe /consoleloggerparameters:ErrorsOnly /maxcpucount /nologo ^
  /property:Configuration=Release /property:Platform="Any CPU" ^
  /verbosity:quiet ^
  Veronique.sln
if errorlevel 1 goto error

echo Builing package
nuget pack Veronique.nuspec
if errorlevel 1 goto error

echo Cleaning up
git checkout -- Veronique.nuspec
if errorlevel 1 goto error
git checkout -- Veronique/Veronique/Properties/AssemblyInfo.cs
if errorlevel 1 goto error
git checkout -- Veronique/Veronique.Test/Properties/AssemblyInfo.cs
if errorlevel 1 goto error

:success
echo.
echo Build successful
exit /b 0

:error
echo.
echo Build failed
exit /b 1