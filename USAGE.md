# VERONIQUE USAGE GUIDE

Veronique is a simple yet powerful tool to determine a version number from different sources and write it to different destinations during the build process.

## Command line arguments

    USAGE: Veronique [command] [params]

    COMMANDS:
      init         Creates a configuration file in the current directory
      execute      Executes the configuration file in the current directory
      help         Shows this usage guide or detailled topic based help

    HELP:
      help         Shows this usage guide
      help list    Lists all available help topics
      help [topic] Shows help for the given topic

## Setup

### Create configuration file

Each project is configured using a simple configuration file in [json format](https://en.wikipedia.org/wiki/JSON).
You can copy an existing file or use `veronique init` to create an empty configuration file.
The configuration file must be named `ohlala.json`.

### Example

The following example has been taken from the integration unit test:

    {
      "projectname":"IntegrationTest",
      "formatversion":"v1",
  
      "definitions":
      [
        {
          "name": "MyVar",
          "command": 
          {
            "name": "const",
            "parameters": [ "0.1" ]
          }
        },
        {
          "name":"MyVar",
          "command":
          {
            "name":"const",
            "parameters": ["0.2"]
          }
        }
      ],
  
      "writers":
      [
        {
          "command": 
          {
            "name": "console",
            "parameters": ["Version $$MyVar$$"]
          }
        },
        {
          "command":
          {
            "name":"dump-to-file",
            "parameters": ["Integration-Test.txt","Version $$MyVar$$"]
          }
        }
      ]
    }

This file contains two definitions of the variable `MyVar`. Keep in mind that subsequent definitions of an identical variable will only be executed if the value is still empty (e.g. the first definition tried to read from a environment variable that does not exist).
This example uses the command `const`for both definitions; the list of available definition commands and their parameters is available at the end of this file; you may also use the command line `veronique help COMMAND_NAME`.

In this example the variable MyVar will hold the value "0.1" since the first definition command succeeded and therefore the second identical variable definition will be skipped.

After the definitions have been evaluated the writers will be executed.
If a parameter of a writer command contains a reference to a defined variable (e.g. $$MyVar$$) it will be replaced with the actual value. Please find the available writer commands at the end of this file.

## Additional information

* variable names are case-sensitive
* when using paths in a parameter always use the path seperator "/"; it will be replaced by the platform-specific seperator

## Build

Switch to the directory that contains the configuration file `ohlala.json`. Call `veronique execute` to execute the configuration.

## Commands

The following commands are available for definitions and writers:

### Definitions

 * [const](./Veronique/Veronique/Help/const.txt)

### Writers

 * [console](./Veronique/Veronique/Help/console.txt)
 * [dump-to-file](./Veronique/Veronique/Help/dump-to-file.txt)