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
    /// Represents a project configuration.
    /// </summary>
    public class Configuration
    {
        #region Constants and Fields

        /// <summary>
        /// Represets the name of the project.
        /// </summary>
        private string projectName;

        /// <summary>
        /// Represents the version number of this file format.
        /// </summary>
        private string formatVersion;

        /// <summary>
        /// Represents the defiitions.
        /// </summary>
        private Definition[] definitions;

        /// <summary>
        /// Represents the writers.
        /// </summary>
        private Writer[] writers;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.projectName = string.Empty;
            this.formatVersion = "v1";
            this.definitions = new Definition[0];
            this.writers = new Writer[0];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                this.projectName = value;
            }
        }

        /// <summary>
        /// Gets or sets the version number of this file format.
        /// </summary>
        public string FormatVersion
        {
            get
            {
                return this.formatVersion;
            }

            set
            {
                this.formatVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the defiitions.
        /// </summary>
        public Definition[] Definitions
        {
            get
            {
                return this.definitions;
            }

            set
            {
                this.definitions = value;
            }
        }

        /// <summary>
        /// Gets or sets the writers.
        /// </summary>
        public Writer[] Writers
        {
            get
            {
                return this.writers;
            }

            set
            {
                this.writers = value;
            }
        }

        #endregion
    }
}
