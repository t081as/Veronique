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
using Veronique.Definitions;
#endregion

namespace Veronique.Test.Definitions
{
    /// <summary>
    /// Contains unit tests for the <see cref="BuildNumberDefinitionCommandTest"/> class.
    /// </summary>
    [TestFixture]
    public class BuildNumberDefinitionCommandTest
    {
        #region Methods

        /// <summary>
        /// Checks the definition command.
        /// </summary>
        [Test]
        public void TestDefinition()
        {
            IDefinitionCommand test = DefinitionCommandManager.CreateByName("build-number");

            int number1 = int.Parse(test.Evaluate(new string[] { }));
            int number2 = int.Parse(test.Evaluate(new string[] { }));
            int number3 = int.Parse(test.Evaluate(new string[] { }));

            Assert.That(number1 < number2, "Incorrect result from definition command");
            Assert.That(number2 < number3, "Incorrect result from definition command");

            Console.WriteLine("build-number: {0} {1} {2}", number1, number2, number3);
        }

        #endregion
    }
}
