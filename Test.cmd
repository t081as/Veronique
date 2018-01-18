@echo off

echo Veronique - test task
echo.

echo Restoring nuget packages
nuget restore Veronique.sln
if errorlevel 1 goto error

echo Building solution (debug)
msbuild.exe /consoleloggerparameters:ErrorsOnly /maxcpucount /nologo ^
  /property:Configuration=Debug /property:Platform="Any CPU" ^
  /verbosity:quiet ^
  Veronique.sln
if errorlevel 1 goto error

echo Running unit tests
.\packages\NUnit.ConsoleRunner.3.7.0\tools\nunit3-console.exe .\Build\Debug\Veronique.Test.dll ^
--work=.\Build\Debug\ ^
--result=Veronique.TestReport.xml
if errorlevel 1 goto error

echo Running code coverage analysis
.\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe ^
  -register:user ^
  "-filter:+[*]* -[Veronique.Test]* -[*]*.Properties.*" ^
  -target:".\packages\NUnit.ConsoleRunner.3.7.0\tools\nunit3-console.exe" ^
  -targetargs:".\Build\Debug\Veronique.Test.dll --result=.\Build\Debug\Veronique.TestReport.xml" ^
  -output:.\Build\Debug\Veronique.Coverage.xml
if errorlevel 1 goto error

echo Generating coverage report
packages\ReportGenerator.3.1.1\tools\ReportGenerator.exe ^
  -reports:".\Build\Debug\Veronique.Coverage.xml" ^
  -targetdir:".\Build\Debug\Coverage"
if errorlevel 1 goto error

:success
echo.
echo Test successful
exit /b 0

:error
echo.
echo Test failed
exit /b 1