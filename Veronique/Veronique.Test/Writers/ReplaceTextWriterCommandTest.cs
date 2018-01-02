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
using System.IO;
using System.Text;
using NUnit.Framework;
using Veronique.Writers;
#endregion

namespace Veronique.Test.Writers
{
    /// <summary>
    /// Contains tests for the <see cref="ReplaceTextWriterCommand"/> class.
    /// </summary>
    [TestFixture]
    public class ReplaceTextWriterCommandTest
    {
        #region Methods

        /// <summary>
        /// Checks the writer command.
        /// </summary>
        [Test]
        public void TestWriter()
        {
            string testFileName = Path.Combine(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName, "TestFiles", "ReplaceText.txt");
            IWriterCommand test = WriterCommandManager.CreateByName("replace-text");
            test.Write(new string[] { testFileName, "replace?", "test" });

            string[] lines = File.ReadAllLines(testFileName, new UTF8Encoding(false));

            Assert.That(lines[0].Trim() == "LINE1", "Incorrect file contents");
            Assert.That(lines[1].Trim() == "generic-text test generic-text", "Incorrect file contents");
            Assert.That(lines[2].Trim() == "LINE3", "Incorrect file contents");
        }

        #endregion
    }
}
