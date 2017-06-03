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
#endregion

namespace Veronique.IO
{
    /// <summary>
    /// An <see cref="EventArgs"/> indicating that a definition has been detected within the configuration file.
    /// </summary>
    public class DefinitionDetectedEventArgs : ConfigurationFileEventArgs
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the variable name of the detected definition.
        /// </summary>
        private string variable;

        /// <summary>
        /// Represents the command of the detected definition.
        /// </summary>
        private string command;

        /// <summary>
        /// Represents the parameters of the detected definition.
        /// </summary>
        private List<string> parameters;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinitionDetectedEventArgs"/> class.
        /// </summary>
        public DefinitionDetectedEventArgs()
            : base()
        {
            this.parameters = new List<string>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the variable name of the detected definition.
        /// </summary>
        public string Variable
        {
            get
            {
                return this.variable;
            }

            set
            {
                this.variable = value;
            }
        }

        /// <summary>
        /// Gets or sets the command of the detected definition.
        /// </summary>
        public string Command
        {
            get
            {
                return this.command;
            }

            set
            {
                this.command = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameters of the detected definition.
        /// </summary>
        public IEnumerable<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            set
            {
                this.parameters = new List<string>(value);
            }
        }

        #endregion
    }
}
