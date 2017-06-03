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

namespace Veronique.IO
{
    /// <summary>
    /// An <see cref="EventArgs"/> indicating an event from the <see cref="ConfigurationFileParser"/>.
    /// </summary>
    public abstract class ConfigurationFileEventArgs : EventArgs
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the filename of the configuration file.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Represents the line number within the configuration file.
        /// </summary>
        private uint lineNumber;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFileEventArgs"/> class.
        /// </summary>
        public ConfigurationFileEventArgs()
            : base()
        {
            this.fileName = string.Empty;
            this.lineNumber = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFileEventArgs"/> class.
        /// </summary>
        /// <param name="fileName">The filename of the configuration file</param>
        /// <param name="lineNumber">The line number within the configuration file.</param>
        public ConfigurationFileEventArgs(string fileName, uint lineNumber)
            : this()
        {
            this.fileName = fileName;
            this.lineNumber = lineNumber;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the filename of the configuration file.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                this.fileName = value;
            }
        }

        /// <summary>
        /// Gets or sets the line number within the configuration file.
        /// </summary>
        public uint LineNumber
        {
            get
            {
                return this.lineNumber;
            }

            set
            {
                this.lineNumber = value;
            }
        }

        #endregion
    }
}
