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
using System.Runtime.Serialization;
#endregion

namespace Veronique.IO
{
    /// <summary>
    /// Represents a single definition.
    /// </summary>
    [DataContract]
    public class Definition
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the name of this definition.
        /// </summary>
        private string name;

        /// <summary>
        /// Represents the command that shall be executed.
        /// </summary>
        private Command command;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Definition"/> class.
        /// </summary>
        public Definition()
        {
            this.name = string.Empty;
            this.command = new Command();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of this definition.
        /// </summary>
        [DataMember(Name = "name", Order = 0)]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the command that shall be executed.
        /// </summary>
        [DataMember(Name = "command", Order = 1)]
        public Command Command
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
