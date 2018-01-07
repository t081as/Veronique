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
using System.Collections.Generic;
using System.IO;
#endregion

namespace Veronique.Commands
{
    /// <summary>
    /// Provides the ability to execute an external command and return the output of the command.
    /// </summary>
    public interface ICommand
    {
        #region Methods

        /// <summary>
        /// Executes the command and returns the output.
        /// </summary>
        /// <returns>The output of the external command.</returns>
        /// <exception cref="IOException">An error occured while executing the external command.</exception>
        string Execute();

        /// <summary>
        /// Executes the command and returns the output.
        /// </summary>
        /// <param name="arguments">The arguments that shall be given to the external application.</param>
        /// <returns>The output of the external command.</returns>
        /// <exception cref="IOException">An error occured while executing the external command.</exception>
        string Execute(IEnumerable<string> arguments);

        #endregion
    }
}
