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
using System.Reflection;
#endregion

namespace Veronique.Writers
{
    /// <summary>
    /// Allows to find specific implementatons of the <see cref="IWriterCommand"/> interface.
    /// </summary>
    public static class WriterCommandManager
    {
        #region Properties

        /// <summary>
        /// Gets a list of all available writer commands.
        /// </summary>
        public static IEnumerable<string> WriterCommands
        {
            get
            {
                List<string> commands = new List<string>();

                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    object[] attributes = type.GetCustomAttributes(typeof(WriterCommandAttribute), true);

                    if (attributes.Length > 0)
                    {
                        foreach (object attribute in attributes)
                        {
                            WriterCommandAttribute definitionCommandAttribute = (WriterCommandAttribute)attribute;
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
        /// Returns a specific implementation of the <see cref="IWriterCommand"/> interface by the given name
        /// </summary>
        /// <param name="name">The name of the definition command.</param>
        /// <returns>A specific implementation of the <see cref="IWriterCommand"/> interface.</returns>
        public static IWriterCommand CreateByName(string name)
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                object[] attributes = type.GetCustomAttributes(typeof(WriterCommandAttribute), true);

                if (attributes.Length > 0)
                {
                    foreach (object attribute in attributes)
                    {
                        WriterCommandAttribute definitionCommandAttribute = (WriterCommandAttribute)attribute;

                        if (definitionCommandAttribute.Command.ToLowerInvariant() == name.ToLowerInvariant())
                        {
                            return (IWriterCommand)Activator.CreateInstance(type);
                        }
                    }
                }
            }

            throw new NotImplementedException(string.Format("Definition command {0} is not implemented", name));
        }

        #endregion
    }
}
