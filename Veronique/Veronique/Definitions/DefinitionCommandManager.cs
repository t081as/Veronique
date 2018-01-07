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
using System.Collections.Generic;
using System.Reflection;
#endregion

namespace Veronique.Definitions
{
    /// <summary>
    /// Allows to find specific implementatons of the <see cref="IDefinitionCommand"/> interface.
    /// </summary>
    public static class DefinitionCommandManager
    {
        #region Properties

        /// <summary>
        /// Gets a list of all available definition commands.
        /// </summary>
        public static IEnumerable<string> DefinitionCommands
        {
            get
            {
                List<string> commands = new List<string>();

                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    object[] attributes = type.GetCustomAttributes(typeof(DefinitionCommandAttribute), true);

                    if (attributes.Length > 0)
                    {
                        foreach (object attribute in attributes)
                        {
                            DefinitionCommandAttribute definitionCommandAttribute = (DefinitionCommandAttribute)attribute;
                            commands.Add(definitionCommandAttribute.Command);
                        }
                    }
                }

                return commands;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a specific implementation of the <see cref="IDefinitionCommand"/> interface by the given name
        /// </summary>
        /// <param name="name">The name of the definition command.</param>
        /// <returns>A specific implementation of the <see cref="IDefinitionCommand"/> interface.</returns>
        public static IDefinitionCommand CreateByName(string name)
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                object[] attributes = type.GetCustomAttributes(typeof(DefinitionCommandAttribute), true);

                if (attributes.Length > 0)
                {
                    foreach (object attribute in attributes)
                    {
                        DefinitionCommandAttribute definitionCommandAttribute = (DefinitionCommandAttribute)attribute;

                        if (definitionCommandAttribute.Command.ToLowerInvariant() == name.ToLowerInvariant())
                        {
                            return (IDefinitionCommand)Activator.CreateInstance(type);
                        }
                    }
                }
            }

            throw new NotImplementedException(string.Format("Definition command {0} is not implemented", name));
        }

        #endregion
    }
}
