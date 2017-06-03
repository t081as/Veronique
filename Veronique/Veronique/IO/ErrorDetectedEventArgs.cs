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
    /// An <see cref="EventArgs"/> indicating that an error has been detected within the configuration file.
    /// </summary>
    public class ErrorDetectedEventArgs
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the line where the error has been detected.
        /// </summary>
        private string line;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDetectedEventArgs"/> class.
        /// </summary>
        public ErrorDetectedEventArgs()
            : base()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the line where the error has been detected.
        /// </summary>
        public string Line
        {
            get
            {
                return this.line;
            }

            set
            {
                this.line = value;
            }
        }

        #endregion
    }
}
