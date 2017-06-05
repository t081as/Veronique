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
using System.Collections.Generic;
using System.IO;
using Veronique.Definitions;
using Veronique.IO;
using Veronique.Properties;
#endregion

namespace Veronique
{
    /// <summary>
    /// Versionizes the current project by interpreting the configuration file located in the current working directory
    /// and executung the given definitions and writers.
    /// </summary>
    public class Versionizer : ICommandLineInterface
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the dictionary used to store the processed definitions.
        /// </summary>
        private Dictionary<string, string> definitions = new Dictionary<string, string>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets all processed definitions.
        /// </summary>
        public IDictionary<string, string> Definitions
        {
            get
            {
                return new Dictionary<string, string>(this.definitions);
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
            try
            {
                string fileName = Path.Combine(Environment.CurrentDirectory, Settings.Default.ConfigurationFileName);

                if (!File.Exists(fileName))
                {
                    throw new ApplicationException($"Configuration file '{fileName}' not found");
                }

                Configuration configuration = Configuration.Read(File.OpenRead(fileName));

                Console.WriteLine("Project: {0}", configuration.ProjectName);
                Console.WriteLine("Definitions: {0}", configuration.Definitions.Count);
                Console.WriteLine("Writers: {0}", configuration.Writers.Count);
                Console.WriteLine();

                foreach (Definition definition in configuration.Definitions)
                {
                    if (this.definitions.ContainsKey(definition.Name.ToLowerInvariant()))
                    {
                        Console.WriteLine("Skipping definition {0} (value already set to '{1}')", definition.Name, this.definitions[definition.Name.ToLowerInvariant()]);
                    }
                    else
                    {
                        Console.WriteLine("Processing definition {0}", definition.Name);

                        IDefinitionCommand definitionCommand = DefinitionCommandManager.CreateByName(definition.Command.Name);
                        string definitionCommandValue = definitionCommand.Evaluate(definition.Command.Parameters.ToArray());

                        if (definitionCommandValue != null && definitionCommandValue != string.Empty)
                        {
                            Console.WriteLine("Defition {0} processed; value: {1}", definition.Name, definitionCommandValue);
                            this.definitions.Add(definition.Name.ToLowerInvariant(), definitionCommandValue);
                        }
                        else
                        {
                            Console.WriteLine("Defition {0} processed; value: {1}", definition.Name, "EMPTY");
                        }
                    }

                    Console.WriteLine();
                }

                foreach (Writer writer in configuration.Writers)
                {
                    // TODO
                }

                return;
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while executing Veronique for the current project", ex);
            }
        }

        #endregion
    }
}
