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
using System.Runtime.Serialization;
#endregion

namespace Veronique.IO
{
    /// <summary>
    /// Represents a single writer.
    /// </summary>
    [DataContract]
    public class Writer
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the command that shall be executed.
        /// </summary>
        private Command command;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Writer"/> class.
        /// </summary>
        public Writer()
        {
            this.command = new Command();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the command that shall be executed.
        /// </summary>
        [DataMember(Name = "command", Order = 0)]
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