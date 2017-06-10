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
using System.IO;
using System.Reflection;
using NUnit.Framework;
#endregion

namespace Veronique.Test
{
    /// <summary>
    /// Contains integration tests.
    /// </summary>
    [TestFixture]
    public class IntegrationTest
    {
        #region Methods

        /// <summary>
        /// Tests initializing a new project by creating an empty project definition file.
        /// </summary>
        [Test]
        public void InitTest()
        {
            string currentWorkingDirectory = Environment.CurrentDirectory;
            Environment.CurrentDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string expectedFile = Path.Combine(Environment.CurrentDirectory, "ohlala.json");

            Console.WriteLine($"Setting directory to '{Environment.CurrentDirectory}' (original: '{currentWorkingDirectory}')");

            string[] args = new string[1] { "init" };
            Program.Main(args);

            Environment.CurrentDirectory = currentWorkingDirectory;

            Assert.That(File.Exists(expectedFile), $"File '{expectedFile}' does not exist");
        }

        /// <summary>
        /// Tests executing a project.
        /// </summary>
        [Test]
        public void ExecuteTest()
        {
            string currentWorkingDirectory = Environment.CurrentDirectory;
            Environment.CurrentDirectory = Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "TestFiles");
            string expectedFile = Path.Combine(Environment.CurrentDirectory, "Integration-Test.txt");

            Console.WriteLine($"Setting directory to '{Environment.CurrentDirectory}' (original: '{currentWorkingDirectory}')");

            string[] args = new string[1] { "execute" };
            Program.Main(args);

            Environment.CurrentDirectory = currentWorkingDirectory;

            Assert.That(File.Exists(expectedFile), $"File '{expectedFile}' does not exist");

            string writtenContent = File.ReadAllText(expectedFile).Trim();
            Assert.That(writtenContent == "Version 0.1", $"File '{expectedFile}' incorrect: {writtenContent}");
        }

        /// <summary>
        /// Tests displaying the command line help.
        /// </summary>
        [Test]
        public void HelpUsageTest()
        {
            string[] args = new string[1] { "help" };
            Program.Main(args);
        }

        /// <summary>
        /// Tests displaying the help topic list.
        /// </summary>
        [Test]
        public void HelpListTest()
        {
            string[] args = new string[2] { "help", "list" };
            Program.Main(args);
        }

        /// <summary>
        /// Tests displaying a specific help topic.
        /// </summary>
        [Test]
        public void HelpTopicTest()
        {
            string[] args = new string[2] { "help", "init" };
            Program.Main(args);
        }

        #endregion
    }
}
