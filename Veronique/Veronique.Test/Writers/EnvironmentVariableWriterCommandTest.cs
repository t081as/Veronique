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
using NUnit.Framework;
using Veronique.Writers;
#endregion

namespace Veronique.Test.Writers
{
    /// <summary>
    /// Contains tests for the <see cref="EnvironmentVariableWriterCommandTest"/> class.
    /// </summary>
    [TestFixture]
    public class EnvironmentVariableWriterCommandTest
    {
        #region Methods

        /// <summary>
        /// Checks the writer command.
        /// </summary>
        [Test]
        public void TestWriter()
        {
            const string envVarName = "VERONIQUE_TEST_VAR";
            const string envVarValue = "test-123";
            Assert.That(Environment.GetEnvironmentVariable(envVarName) == null, "Environment variable already set");

            IWriterCommand test = WriterCommandManager.CreateByName("set-env-var");
            test.Write(new string[] { envVarName, envVarValue });

            Assert.That(Environment.GetEnvironmentVariable(envVarName) == envVarValue, "Incorrect result");
        }

        #endregion
    }
}
