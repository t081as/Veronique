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
using System.Text;
#endregion

namespace Veronique.IO
{
    /// <summary>
    /// Represents a parser for Veronique configuration files.
    /// </summary>
    public sealed class ConfigurationFileParser
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the characters used to indicate a comment.
        /// </summary>
        public const string CommentMarker = "#";

        /// <summary>
        /// Represents the configuration that shall be used by this parser.
        /// </summary>
        private string configurationFileName;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFileParser"/> class.
        /// </summary>
        /// <param name="configurationFileName">The path and filename of the configuration that shall be used.</param>
        public ConfigurationFileParser(string configurationFileName)
        {
            if (configurationFileName == null)
            {
                throw new ArgumentNullException("configuration");
            }

            this.configurationFileName = configurationFileName;
        }

        #endregion

        #region Events

        /// <summary>
        /// Triggered when a new definition has been detected in the configuration file.
        /// </summary>
        public event EventHandler<DefinitionDetectedEventArgs> DefinitionDetected;

        /// <summary>
        /// Triggered when a new output has been detected in the configuration file.
        /// </summary>
        public event EventHandler<OutputDetectedEventArgs> OutputDetected;

        /// <summary>
        /// Triggered when an error has been detected in the configuration file.
        /// </summary>
        public event EventHandler<OutputDetectedEventArgs> ErrorDetected;

        #endregion

        #region Methods

        /// <summary>
        /// Starts parsing the given configuration file.
        /// </summary>
        public void Parse()
        {
            using (Stream configuration = File.Open(this.configurationFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader reader = new StreamReader(configuration, Encoding.UTF8))
                {
                    string line = string.Empty;
                    uint lineNumber = 1;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string lineWithoutComments = StripComments(line.Trim());

                        lineNumber++;
                    }
                }
            }
        }

        /// <summary>
        /// Removes the comment from the given line if a comment is presents.
        /// </summary>
        /// <param name="configurationLine">The line of the configuration file.</param>
        /// <returns>The line of the configurationfile without comments.</returns>
        private static string StripComments(string configurationLine)
        {
            if (configurationLine == null)
            {
                throw new ArgumentNullException("configurationLine");
            }

            if (configurationLine.Contains(CommentMarker))
            {
                if (configurationLine.StartsWith(CommentMarker))
                {
                    return string.Empty;
                }
                else
                {
                    return configurationLine.Substring(configurationLine.IndexOf(CommentMarker));
                }
            }
            else
            {
                return configurationLine;
            }
        }

        #endregion
    }
}
