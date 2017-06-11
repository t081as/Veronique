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
using System.Reflection;
using NUnit.Framework;
using Veronique.IO;
#endregion

namespace Veronique.Test.IO
{
    /// <summary>
    /// Contains tests for the <see cref="Configuration"/> class.
    /// </summary>
    [TestFixture]
    public class ConfigurationTest
    {
        #region Methods

        /// <summary>
        /// Checks reading an existing configuration.
        /// </summary>
        [Test]
        public void ReadConfigurationTest()
        {
            Configuration config = Configuration.Read(File.OpenRead(Path.Combine(new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName, "TestFiles", "ohlala.json")));

            Assert.That(config.FormatVersion == "v1", "Incorrect format");
            Assert.That(config.Definitions.Count == 2, "Incorrect definition count");
            Assert.That(config.Writers.Count == 2, "Incorrect writer count");
        }

        #endregion
    }
}
