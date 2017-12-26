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
using NUnit.Framework;
using Veronique.Writers;
#endregion

namespace Veronique.Test.Writers
{
    /// <summary>
    /// Contains tests for the <see cref="DumpToFileWriterCommand"/> class.
    /// </summary>
    [TestFixture]
    public class DumpToFileWriterCommandTest
    {
        #region Methods

        /// <summary>
        /// Checks the writer command.
        /// </summary>
        [Test]
        public void TestWriter()
        {
            string testFileName = Path.Combine(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).DirectoryName, "DumpTest.txt");
            IWriterCommand test = WriterCommandManager.CreateByName("dump-to-file");
            test.Write(new string[] { testFileName, "V1-2" });

            string contents = File.ReadAllText(testFileName);

            Assert.That(contents == "V1-2", "Incorrect file contents");
        }

        #endregion
    }
}
