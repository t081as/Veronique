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
using Veronique.Utilities;
#endregion

namespace Veronique.Definitions
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDefinitionCommand"/> interface returning a unique build number
    /// that is incremented on every command execution.
    /// </summary>
    [DefinitionCommand("build-number")]
    public class BuildNumberDefinitionCommand : IDefinitionCommand
    {
        #region Constants and Fields

        /// <summary>
        /// The filename of the persistent file used to store the last returned build number.
        /// </summary>
        public const string BuildNumberFileName = "build-number";

        /// <summary>
        /// The path and filename of the persistent file used to store the last returned build number.
        /// </summary>
        private string buildNumberFile;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildNumberDefinitionCommand"/> class.
        /// </summary>
        public BuildNumberDefinitionCommand()
        {
            string applicationDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".veronique");

            if (!Directory.Exists(applicationDataDirectory))
            {
                Directory.CreateDirectory(applicationDataDirectory);
            }

            this.buildNumberFile = Path.Combine(applicationDataDirectory, BuildNumberFileName);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Evaluates a definition.
        /// </summary>
        /// <param name="parameters">The parameters given to this evaluation.</param>
        /// <returns>The evaluated definition.</returns>
        /// <exception cref="ArgumentNullException"><c>parameters</c> is null.</exception>
        /// <exception cref="ArgumentNullException">A parameter is null.</exception>
        /// <exception cref="ArgumentException">The number of arguments is invalid.</exception>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        /// <exception cref="ApplicationException">An error occured during the operation.</exception>
        /// <remarks>
        /// If this method returns <c>null</c> or <see cref="string.Empty"/> the variable defined
        /// will contain the value <c>EMPTY</c> and subsequent definitions of the identical
        /// variable will be executed.
        /// </remarks>
        public string Evaluate(string[] parameters)
        {
            Parameter.Check(parameters, 0, 0);

            int buildNumber;

            try
            {
                buildNumber = int.Parse(File.ReadAllText(this.buildNumberFile).Trim());
                buildNumber++;
            }
            catch
            {
                buildNumber = 1;
            }

            File.WriteAllText(this.buildNumberFile, buildNumber.ToString());

            return buildNumber.ToString();
        }

        #endregion
    }
}
