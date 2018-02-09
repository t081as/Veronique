![VERONIQUE](https://gitlab.com/tobiaskoch/Veronique/raw/master/Media/Veronique-256.png)

# VERONIQUE

[![pipeline status](https://gitlab.com/tobiaskoch/Veronique/badges/master/pipeline.svg)](https://gitlab.com/tobiaskoch/Veronique/commits/master)
[![maintained: yes](https://tobiaskoch.gitlab.io/badges/maintained-yes.svg)](https://gitlab.com/tobiaskoch/Veronique/commits/master)
[![donate: paypal](https://tobiaskoch.gitlab.io/badges/donate-paypal.svg)](https://www.tk-software.de/donate)

*Ver*-**Unique**-*onique*-**Version**

---
Veronique is a simple yet powerful command line tool helping versioning your software projects automatically during the build process.

## Features
- Written in plain C#, supports Microsoft Windows (.NET Framework) and Linux (Mono)
- Available as single application file or as nuget package
- Supports extracting version numbers from git tags
- Supports persistent build numbers (using the gitlab-ci cache feature)

## Installation

### Option 1: NuGet
NuGet packages are available [here](https://www.nuget.org/packages/Veronique/).

### Option 2: Binary
Stable versions can be downloaded [here](https://gitlab.com/tobiaskoch/Veronique/pipelines?scope=tags).

### Option 3: Source
#### Requirements
The following applications must be available and included in you *PATH* environment variable:

* [Git](https://git-scm.com/)
* [Nuget.exe](https://www.nuget.org/)
* MSBuild (.NET Framework / Mono; [Visual Studio](https://www.visualstudio.com) recommended for development)

#### Source code
Get the source code using the following command:

    > git clone https://gitlab.com/tobiaskoch/Veronique.git

#### Build
    > .\Build.cmd

The executable will be located in the directory *.\Build\Release* if the build succeeds.

#### Test
    > .\Test.cmd

The script will report if the unit tests succeeds, the coverage report will be placed in the directory *.\Build\Debug\Coverage*.

## Usage
see [USAGE.md](https://gitlab.com/tobiaskoch/Veronique/blob/master/USAGE.md)

## Contributing
see [CONTRIBUTING.md](https://gitlab.com/tobiaskoch/Veronique/blob/master/CONTRIBUTING.md)

## Contributors
see [AUTHORS.txt](https://gitlab.com/tobiaskoch/Veronique/blob/master/AUTHORS.txt)

## Donating
Thanks for your interest in this project. You can show your appreciation and support further development by [donating](https://www.tk-software.de/donate).

## License
**Veronique** © 2017-2018  Tobias Koch. Released under the [GPL](https://gitlab.com/tobiaskoch/Veronique/blob/master/LICENSE.md).