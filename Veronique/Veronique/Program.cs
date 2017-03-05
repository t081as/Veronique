#region GNU General Public License 3
// Veronique - Easy versioning for software projects
// Copyright (C) 2017  Tobias Koch
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.
#endregion

#region Namespaces
using System;
using System.Reflection;
#endregion

namespace Veronique
{
    /// <summary>
    /// Contains the main entry point for the application.
    /// </summary>
    public class Program
    {
        #region Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <returns>The return value of the application.</returns>
        public static int Main(string[] args)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            Console.WriteLine($"Veronique {version.Major}.{version.Minor}.{version.Revision}");
            Console.WriteLine("(C) 2017  Tobias Koch");
            Console.WriteLine();

            try
            {
                ICommandLineInterface commandLineInterface;
                string[] commandLineInterfaceArgs;

                if (args.Length == 0)
                {
                    commandLineInterfaceArgs = new string[0];
                    commandLineInterface = new Versionizer();
                }
                else
                {
                    switch (args[0].ToLowerInvariant().Trim())
                    {
                        case "init":
                        case "-init":
                        case "--init":
                        case "/i":
                        case "-i":
                        case "--i":
                            commandLineInterfaceArgs = new string[args.Length - 1];
                            Array.Copy(args, 1, commandLineInterfaceArgs, 0, args.Length - 1);
                            commandLineInterface = new Initializer();
                            break;

                        case "execute":
                        case "-execute":
                        case "--execute":
                        case "/e":
                        case "-e":
                        case "--e":
                            commandLineInterfaceArgs = new string[args.Length - 1];
                            Array.Copy(args, 1, commandLineInterfaceArgs, 0, args.Length - 1);
                            commandLineInterface = new Versionizer();
                            break;

                        case "help":
                        case "-help":
                        case "--help":
                        case "/?":
                        case "-?":
                        case "--?":
                            commandLineInterfaceArgs = new string[args.Length - 1];
                            Array.Copy(args, 1, commandLineInterfaceArgs, 0, args.Length - 1);
                            commandLineInterface = new HelpProvider();
                            break;

                        default:
                            Console.WriteLine($"{args[0]}: unknown command");
                            Console.WriteLine("Type 'Veronique help' for help");
                            return 1;
                    }
                }

                commandLineInterface.Execute(commandLineInterfaceArgs);
                return 0;
            }
            catch (Exception ex)
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Error:");
                Console.WriteLine();

                Exception currentException = ex;
                while (currentException != null)
                {
                    Console.WriteLine($"{currentException.GetType().FullName}:");
                    Console.WriteLine($"{currentException.Message}");
                    Console.WriteLine();
                    currentException = currentException.InnerException;
                }

                Console.ForegroundColor = currentColor;

                return 1;
            }
        }

        #endregion
    }
}
