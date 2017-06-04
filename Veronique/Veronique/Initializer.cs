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
using System.IO;
using System.Reflection;
using System.Text;
using Veronique.IO;
using Veronique.Properties;
#endregion

namespace Veronique
{
    /// <summary>
    /// Initializes veronique for the project by creating a configuration file in the current working directory.
    /// </summary>
    public class Initializer : ICommandLineInterface
    {
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

                if (File.Exists(fileName))
                {
                    throw new ApplicationException($"Configuration file '{fileName}' already exists");
                }

                Definition definition = new Definition();
                definition.Name = "MyVar";
                definition.Command.Name = "static";
                definition.Command.Parameters.Add("0.1");

                Writer writer = new Writer();
                writer.Command.Name = "console";
                writer.Command.Parameters.Add("Version %MyVar%");

                Configuration defaultConfiguration = new Configuration();
                defaultConfiguration.ProjectName = "MyProject";
                defaultConfiguration.Definitions.Add(definition);
                defaultConfiguration.Writers.Add(writer);

                Console.WriteLine("Writing configuration file {0}", fileName);

                using (Stream fileStream = File.Create(fileName))
                {
                    Configuration.Write(fileStream, defaultConfiguration);
                }
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while initializing Veronique for the current project", ex);
            }
        }

        #endregion
    }
}
