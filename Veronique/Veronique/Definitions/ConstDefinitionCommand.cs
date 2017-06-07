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

namespace Veronique.Definitions
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDefinitionCommand"/> interface returning a constant text.
    /// </summary>
    [DefinitionCommand("const")]
    public class ConstDefinitionCommand
    {
        #region Methods

        /// <summary>
        /// Evaluates a definition.
        /// </summary>
        /// <param name="parameters">The parameters given to this evaluation.</param>
        /// <returns>The evaluated definition.</returns>
        /// <exception cref="ArgumentNullException"><c>parameters</c> is null.</exception>
        /// <exception cref="ArgumentNullException">A parameter is null.</exception>
        /// <exception cref="ArgumentException">The number of arguments is invalid.</exception>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        /// <exception cref="ApplicationException">An error occured during the operation.</exception>
        public string Evaluate(string[] parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            if (parameters.Length != 1)
            {
                throw new ArgumentException("Invalid parameter count");
            }

            if (parameters[0] == null)
            {
                throw new ArgumentNullException("parameters[0]");
            }

            return parameters[0];
        }

        #endregion
    }
}
