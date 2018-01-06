@echo off

echo Veronique - build task
echo.

echo Preparing environment
call "%VS140COMNTOOLS%\vsvars32.bat"
if errorlevel 1 goto error

echo Restoring nuget packages
nuget restore Veronique.sln
if errorlevel 1 goto error

echo Setting version number
packages\Veronique.0.5.2\tools\Veronique
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