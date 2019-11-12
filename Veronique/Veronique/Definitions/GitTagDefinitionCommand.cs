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
using System.Text.RegularExpressions;
using Veronique.Commands;
using Veronique.Utilities;
#endregion

namespace Veronique.Definitions
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDefinitionCommand"/> interface returning details of a git repository.
    /// </summary>
    [DefinitionCommand("git-tag")]
    public class GitTagDefinitionCommand : IDefinitionCommand
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the command that shall be executed to determine details of the git repository.
        /// </summary>
        private ICommand gitDescribeCommand;

        #endregion

        #region Constrcutors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GitTagDefinitionCommand"/> class.
        /// </summary>
        public GitTagDefinitionCommand()
        {
            this.gitDescribeCommand = new GitDescribeCommand();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the command that shall be executed to determine details of the git repository.
        /// </summary>
        public ICommand GitDescribeCommand
        {
            get
            {
                return this.gitDescribeCommand;
            }

            set
            {
                this.gitDescribeCommand = value;
            }
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
            Parameter.Check(parameters, 1, 1);

            string gitDescribeResult = this.gitDescribeCommand.Execute();
            string[] gitDescribeResultParts = gitDescribeResult.Split('-');

            // Output of the git describe command should be tag-number of commits (since last tag)-shasum
            if (gitDescribeResultParts.Length < 3)
            {
                return null;
            }

            // Retrieve last tag, number of commits since last tag and shasum
            string shasum = gitDescribeResultParts[gitDescribeResultParts.Length - 1];
            string numberOfCommits = gitDescribeResultParts[gitDescribeResultParts.Length - 2];
            string lastTag = string.Empty;

            if (gitDescribeResultParts.Length == 3)
            {
                lastTag = gitDescribeResultParts[0];
            }
            else
            {
                for (int i = 0; i < gitDescribeResultParts.Length - 2; i++)
                {
                    lastTag += gitDescribeResultParts[i] + "-";
                }
            }

            // Retrieve version numbers used in the last tag
            List<string> versionNumbers = new List<string>();

            foreach (Match match in Regex.Matches(lastTag, @"[\d]+"))
            {
                versionNumbers.Add(match.Value);
            }

            // Return desired part
            switch (parameters[0].ToLower())
            {
                case "major":
                    return versionNumbers.Count > 0 ? versionNumbers[0] : null;

                case "minor":
                    return versionNumbers.Count > 1 ? versionNumbers[1] : null;

                case "revision":
                    return versionNumbers.Count > 2 ? versionNumbers[2] : null;

                case "commits":
                    return numberOfCommits;

                case "shasum":
                    return shasum;

                default:
                    return null;
            }
        }

        #endregion
    }
}
