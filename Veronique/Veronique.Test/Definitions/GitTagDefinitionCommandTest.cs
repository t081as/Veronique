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
using NUnit.Framework;
using Veronique.Definitions;
using Veronique.Test.CommandStubs;
#endregion

namespace Veronique.Test.Definitions
{
    /// <summary>
    /// Contains unit tests for the <see cref="GitTagDefinitionCommand"/> class.
    /// </summary>
    [TestFixture]
    public class GitTagDefinitionCommandTest
    {
        #region Methods

        /// <summary>
        /// Checks loading the definition command by name.
        /// </summary>
        [Test]
        public void TestDefinition()
        {
            IDefinitionCommand test = DefinitionCommandManager.CreateByName("git-tag");
            Assert.That(test != null);
        }

        /// <summary>
        /// Checks if a git tag with dots is supported.
        /// </summary>
        [Test]
        public void TestDots()
        {
            GitTagDefinitionCommand command = new GitTagDefinitionCommand();
            command.GitDescribeCommand = new SimpleCommandMock("v0.1-2-ab53e9");

            string major = command.Evaluate(new string[] { "major" });
            string minor = command.Evaluate(new string[] { "minor" });
            string revision = command.Evaluate(new string[] { "revision" });
            string commits = command.Evaluate(new string[] { "commits" });
            string shasum = command.Evaluate(new string[] { "shasum" });

            Assert.That(major == "0", "Result incorrect: major");
            Assert.That(minor == "1", "Result incorrect: minor");
            Assert.That(revision == null, "Result incorrect: revision");
            Assert.That(commits == "2", "Result incorrect: commits");
            Assert.That(shasum == "ab53e9", "Result incorrect: shasum");
        }

        /// <summary>
        /// Checks if a git tag with dots is supported.
        /// </summary>
        [Test]
        public void TestDashes()
        {
            GitTagDefinitionCommand command = new GitTagDefinitionCommand();
            command.GitDescribeCommand = new SimpleCommandMock("version 1-2-0-4-ef53e9");

            string major = command.Evaluate(new string[] { "major" });
            string minor = command.Evaluate(new string[] { "minor" });
            string revision = command.Evaluate(new string[] { "revision" });
            string commits = command.Evaluate(new string[] { "commits" });
            string shasum = command.Evaluate(new string[] { "shasum" });

            Assert.That(major == "1", "Result incorrect: major");
            Assert.That(minor == "2", "Result incorrect: minor");
            Assert.That(revision == "0", "Result incorrect: revision");
            Assert.That(commits == "4", "Result incorrect: commits");
            Assert.That(shasum == "ef53e9", "Result incorrect: shasum");
        }

        /// <summary>
        /// Checks if version numbers with more than one digit are returned correctly.
        /// </summary>
        /// <remarks>
        /// see Issue 25 (https://gitlab.com/tobiaskoch/Veronique/issues/25)
        /// </remarks>
        [Test]
        public void TestTwoDigits()
        {
            GitTagDefinitionCommand command = new GitTagDefinitionCommand();
            command.GitDescribeCommand = new SimpleCommandMock("v0.11-5-ab53e9");

            string major = command.Evaluate(new string[] { "major" });
            string minor = command.Evaluate(new string[] { "minor" });
            string revision = command.Evaluate(new string[] { "revision" });
            string commits = command.Evaluate(new string[] { "commits" });
            string shasum = command.Evaluate(new string[] { "shasum" });

            Assert.That(major == "0", "Result incorrect: major");
            Assert.That(minor == "11", "Result incorrect: minor");
            Assert.That(revision == null, "Result incorrect: revision");
            Assert.That(commits == "5", "Result incorrect: commits");
            Assert.That(shasum == "ab53e9", "Result incorrect: shasum");
        }

        #endregion
    }
}
