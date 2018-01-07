#region GNU General Public License 3
// Veronique - Easy versioning for software projects
// Copyright (C) 2017-2018  Tobias Koch
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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
#endregion

namespace Veronique
{
    /// <summary>
    /// Provides help based on predefined help topics.
    /// </summary>
    public class HelpProvider : ICommandLineInterface
    {
        #region Properties

        /// <summary>
        /// Gets the list of available help topics.
        /// </summary>
        public IEnumerable<string> HelpTopics
        {
            get
            {
                List<string> topics = new List<string>();

                string[] resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();

                Array.Sort(resourceNames);

                foreach (string resourceName in resourceNames)
                {
                    string[] resourceNameParts = resourceName.Split('.');

                    if (resourceNameParts.Length == 4 &&
                        resourceNameParts[3].ToLowerInvariant().Trim() == "txt" &&
                        resourceNameParts[1].ToLowerInvariant().Trim() == "help")
                    {
                        topics.Add(resourceNameParts[2]);
                    }
                }

                return topics;
            }
        }

        #endregion

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
                Console.WriteLine("  help         Shows this usage guide");
                Console.WriteLine("  help list    Lists all available help topics");
                Console.WriteLine("  help [topic] Shows help for the given topic");
            }
            else
            {
                if (args[0].ToLowerInvariant().Trim() == "list")
                {
                    this.ShowHelpList();
                }
                else
                {
                    this.ShowHelpTopic(args[0].ToLowerInvariant().Trim());
                }
            }
        }

        /// <summary>
        /// Reads the given help topic and returns it.
        /// </summary>
        /// <param name="topic">The name of the help topic that shall be read.</param>
        /// <returns>The help topic that has been read.</returns>
        /// <exception cref="ArgumentNullException"><c>topic</c> is null.</exception>
        public string ReadHelpTopic(string topic)
        {
            using (Stream helpTopicStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"Veronique.Help.{topic}.txt"))
            {
                StreamReader reader = new StreamReader(helpTopicStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        /// Shows the list of all available help topics.
        /// </summary>
        private void ShowHelpList()
        {
            foreach (string topic in this.HelpTopics)
            {
                Console.WriteLine(topic);
            }
        }

        /// <summary>
        /// Shows a specific help topic.
        /// </summary>
        /// <param name="topic">The help topic that shall be shown.</param>
        private void ShowHelpTopic(string topic)
        {
            Console.WriteLine(this.ReadHelpTopic(topic));
        }

        #endregion
    }
}
