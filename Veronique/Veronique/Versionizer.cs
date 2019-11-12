#region GNU General Public License 3
// Veronique - Easy versioning for software projects
// Copyright (C) 2017-2019  Tobias Koch
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
using Veronique.Utilities;
using Veronique.Writers;
#endregion

namespace Veronique
{
    /// <summary>
    /// Versionizes the current project by interpreting the configuration file located in the current working directory
    /// and executung the given definitions and writers.
    /// </summary>
    public class Versionizer : ICommandLineInterface
    {
        #region Methods

        /// <summary>
        /// Executes the action of the given command line interface.
        /// </summary>
        /// <param name="args">The arguments given to this command line interface.</param>
        /// <exception cref="ApplicationException">An error occured while executing the command.</exception>
        public void Execute(string[] args)
        {
            List<string> fileNames = new List<string>();
            fileNames.Add("veronique.json");
            fileNames.Add(".veronique.json");

            try
            {
                string fileName = string.Empty;

                foreach (string currentFileName in fileNames)
                {
                    string tempFileName = Path.Combine(Environment.CurrentDirectory, currentFileName);

                    if (File.Exists(tempFileName))
                    {
                        fileName = tempFileName;
                        break;
                    }
                }

                if (fileName == null || fileName == string.Empty)
                {
                    throw new ApplicationException($"Configuration file not found in current working directory '{Environment.CurrentDirectory}'");
                }

                Configuration configuration = Configuration.Read(File.OpenRead(fileName));

                Console.WriteLine("Project: {0}", configuration.ProjectName);
                Console.WriteLine("Definitions: {0}", configuration.Definitions.Count);
                Console.WriteLine("Writers: {0}", configuration.Writers.Count);
                Console.WriteLine();

                using (CurrentConsoleColor color = new CurrentConsoleColor(ConsoleColor.Green))
                {
                    Console.WriteLine("Processing definitions");
                }

                IDictionary<string, string> definitions = this.ProcessDefinitions(configuration.Definitions);

                using (CurrentConsoleColor color = new CurrentConsoleColor(ConsoleColor.Green))
                {
                    Console.WriteLine("Processing writers");
                }

                this.ProcessWriters(configuration.Writers, definitions);

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

        /// <summary>
        /// Processes the given <see cref="Definition">definitions</see> and returns the values.
        /// </summary>
        /// <param name="definitions">The <see cref="Definition">definitions</see> that shall be processed.</param>
        /// <returns>An <see cref="IDictionary{TKey, TValue}"/> containg the definition names and the processed values.</returns>
        /// <exception cref="ArgumentNullException"><c>definitions</c> is null.</exception>
        public IDictionary<string, string> ProcessDefinitions(IEnumerable<Definition> definitions)
        {
            if (definitions == null)
            {
                throw new ArgumentNullException("definitions");
            }

            Dictionary<string, string> processedDefinitions = new Dictionary<string, string>();

            foreach (Definition definition in definitions)
            {
                try
                {
                    if (processedDefinitions.ContainsKey(definition.Name))
                    {
                        Console.WriteLine("Skipping definition {0} (value already set to '{1}')", definition.Name, processedDefinitions[definition.Name]);
                    }
                    else
                    {
                        Console.WriteLine("Processing definition {0}", definition.Name);

                        IDefinitionCommand definitionCommand = DefinitionCommandManager.CreateByName(definition.Command.Name);
                        string definitionCommandValue = definitionCommand.Evaluate(definition.Command.Parameters.ToArray());

                        if (definitionCommandValue != null && definitionCommandValue != string.Empty)
                        {
                            Console.WriteLine("Definition {0} processed; value: {1}", definition.Name, definitionCommandValue);
                            processedDefinitions.Add(definition.Name, definitionCommandValue);
                        }
                        else
                        {
                            Console.WriteLine("Definition {0} processed; value: {1}", definition.Name, "EMPTY");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Skipping definition {0}; error: {1}", definition.Name, ex.Message);
                }
            }

            return processedDefinitions;
        }

        /// <summary>
        /// Processes the given <see cref="Writer">writers</see> using the given <see cref="Definition">definitions</see>.
        /// </summary>
        /// <param name="writers">The writers that shall be processed.</param>
        /// <param name="definitions">The definitions that shall be used.</param>
        /// <exception cref="ArgumentNullException"><c>definitions</c> is null.</exception>
        /// <exception cref="ArgumentNullException"><c>writers</c> is null.</exception>
        public void ProcessWriters(IEnumerable<Writer> writers, IDictionary<string, string> definitions)
        {
            if (definitions == null)
            {
                throw new ArgumentNullException("definitions");
            }

            if (writers == null)
            {
                throw new ArgumentNullException("writers");
            }

            foreach (Writer writer in writers)
            {
                Console.WriteLine("Writer: {0}", writer.Command.Name);

                for (int i = 0; i < writer.Command.Parameters.Count; i++)
                {
                    foreach (string key in definitions.Keys)
                    {
                        writer.Command.Parameters[i] = writer.Command.Parameters[i].Replace(string.Format("$${0}$$", key), definitions[key]);
                    }

                    Console.WriteLine("    {0}", writer.Command.Parameters[i]);
                }

                try
                {
                    IWriterCommand writerCommand = WriterCommandManager.CreateByName(writer.Command.Name);
                    writerCommand.Write(writer.Command.Parameters.ToArray());

                    Console.WriteLine("Success");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed: {0}", ex.Message);
                }

                Console.WriteLine();
            }
        }

        #endregion
    }
}
