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
#endregion

namespace Veronique
{
    /// <summary>
    /// Provides help based on predefined help topics.
    /// </summary>
    public class HelpProvider : ICommandLineInterface
    {
        #region Methods

        /// <summary>
        /// Executes the action of the given command line interface.
        /// </summary>
        /// <param name="args">The arguments given to this command line interface.</param>
        /// <exception cref="ApplicationException">An error occured while executing the command.</exception>
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("USAGE: Veronique [command] [params]");
                Console.WriteLine();
                Console.WriteLine("COMMANDS:");
                Console.WriteLine("  init         Creates a configuration file in the current directory");
                Console.WriteLine("  execute      Executes the configuration file in the current directory");
                Console.WriteLine("  help         Shows this usage guide or detailled topic based help");
                Console.WriteLine();
                Console.WriteLine("HELP:");
                Console.WriteLine("  help list    Lists all available help topics");
                Console.WriteLine("  help [topic] Shows help for the given topic");
            }

            return;
        }

        #endregion
    }
}
