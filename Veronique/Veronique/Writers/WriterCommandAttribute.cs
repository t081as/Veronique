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
#endregion

namespace Veronique.Writers
{
    /// <summary>
    /// Represents the attribute used for a writer.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class WriterCommandAttribute : CommandAttribute
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WriterCommandAttribute"/> class.
        /// </summary>
        /// <param name="command">The command used by this definition.</param>
        public WriterCommandAttribute(string command)
            : base(command)
        {
        }

        #endregion
    }
}
