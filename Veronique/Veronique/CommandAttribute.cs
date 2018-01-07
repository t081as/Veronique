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
#endregion

namespace Veronique
{
    /// <summary>
    /// Represents the attribute describing a command.
    /// </summary>
    public class CommandAttribute : Attribute
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the command used by this definition.
        /// </summary>
        private string command;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttribute"/> class.
        /// </summary>
        /// <param name="command">The command used by this definition.</param>
        public CommandAttribute(string command)
        {
            this.command = command;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the command used by this definition.
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

        #endregion
    }
}
