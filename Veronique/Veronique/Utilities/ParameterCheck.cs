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
using Veronique.Definitions;
using Veronique.Writers;
#endregion

namespace Veronique.Utilities
{
    /// <summary>
    /// Represents a class containing methods to check the prameters of an <see cref="IDefinitionCommand"/> or <see cref="IWriterCommand"/> implementation.
    /// </summary>
    public static class ParameterCheck
    {
        #region Methods

        /// <summary>
        /// Checks the given parameters and throws an appropriate exception if parameters are invalid.
        /// </summary>
        /// <param name="parameters">The parameters that shall be checked.</param>
        /// <param name="minCount">The minimum count of allowed parameters.</param>
        /// <param name="maxCount">The maximum count of allowed parameters.</param>
        /// <exception cref="ArgumentNullException"><c>parameters</c> is null.</exception>
        /// <exception cref="ArgumentNullException">A parameter is null.</exception>
        /// <exception cref="ArgumentException">The number of arguments is invalid.</exception>
        public static void Check(string[] parameters, uint minCount, uint maxCount)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == null)
                {
                    throw new ArgumentNullException(string.Format("parameters[{0}]", i));
                }
            }

            if (parameters.Length < minCount || parameters.Length > maxCount)
            {
                throw new ArgumentException("Invalid parameter count");
            }
        }

        #endregion
    }
}
