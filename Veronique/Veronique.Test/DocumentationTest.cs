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
using System.Collections.Generic;
using NUnit.Framework;
using Veronique.Definitions;
using Veronique.Writers;
#endregion

namespace Veronique.Test
{
    /// <summary>
    /// Checks the documentation files of all definition and writer commands.
    /// </summary>
    [TestFixture]
    public class DocumentationTest
    {
        #region Methods

        /// <summary>
        /// Checks if all implementations of <see cref="IDefinitionCommand"/> are documented correctly.
        /// </summary>
        [Test]
        public void CheckDefinitionDocumentation()
        {
            List<string> helpTopics = new List<string>(new HelpProvider().HelpTopics);

            foreach (string command in DefinitionCommandManager.DefinitionCommands)
            {
                Assert.That(helpTopics.Contains(command), $"Definition {command}: no documentation found");
            }
        }

        /// <summary>
        /// Checks if all implementations of <see cref="IWriterCommand"/> are documented correctly.
        /// </summary>
        [Test]
        public void CheckWriterDocumentation()
        {
            List<string> helpTopics = new List<string>(new HelpProvider().HelpTopics);

            foreach (string command in WriterCommandManager.WriterCommands)
            {
                Assert.That(helpTopics.Contains(command), $"Writer {command}: no documentation found");
            }
        }

        #endregion
    }
}
