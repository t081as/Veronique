![VERONIQUE](https://gitlab.com/tobiaskoch/Veronique/raw/master/Media/Veronique-256.png)

# VERONIQUE

[![pipeline status](https://gitlab.com/tobiaskoch/Veronique/badges/master/pipeline.svg)](https://gitlab.com/tobiaskoch/Veronique/commits/master)

*Ver*-**Unique**-*onique*-**Version**

---
Veronique is a simple yet powerful command line tool helping versioning your software projects automatically during the build process.

## Features

## Installation

### Option 1: Binary
Stable versions can be downloaded [here](https://gitlab.com/tobiaskoch/Veronique/pipelines?scope=tags).

### Option 2: Source
#### Requirements
The following applications must be available and included in you *PATH* environment variable:

* [Git](https://git-scm.com/)
* [Nuget.exe](https://www.nuget.org/)
* MSBuild / XBuild ([Visual Studio](https://www.visualstudio.com) recommended for development)

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

## License
**Veronique** © 2017  Tobias Koch. Released under the [GPL](https://gitlab.com/tobiaskoch/Veronique/blob/master/LICENSE.md).