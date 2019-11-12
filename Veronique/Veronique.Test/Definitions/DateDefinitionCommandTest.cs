#region GNU General Public License 3
// Veronique - Easy versioning for software projects
// Copyright (C) 2017-2019  Tobias Koch
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
    /// Contains unit tests for the <see cref="DateDefinitionCommand"/> class.
    /// </summary>
    [TestFixture]
    public class DateDefinitionCommandTest
    {
        #region Methods

        /// <summary>
        /// Checks the definition command.
        /// </summary>
        [Test]
        public void TestDefinition()
        {
            IDefinitionCommand test = DefinitionCommandManager.CreateByName("date");

            DateTime refLocal = DateTime.Now;

            string year = test.Evaluate(new string[] { "local", "year" });
            string shortYear = test.Evaluate(new string[] { "utc", "short-year" });
            string veryShortYear = test.Evaluate(new string[] { "local", "very-short-year" });
            string month = test.Evaluate(new string[] { "local", "month" });
            string shortMonth = test.Evaluate(new string[] { "local", "short-month" });
            string day = test.Evaluate(new string[] { "local", "day" });
            string shortDay = test.Evaluate(new string[] { "local", "short-day" });

            Assert.That(int.Parse(year) == refLocal.Year);
            Assert.That(int.Parse(month) == refLocal.Month);
            Assert.That(int.Parse(day) == refLocal.Day);

            Assert.That(int.Parse(month) == int.Parse(shortMonth));
            Assert.That(int.Parse(day) == int.Parse(shortDay));

            Assert.That(shortYear == refLocal.ToString("yy"));
            Assert.That(int.Parse(veryShortYear) == int.Parse(refLocal.ToString("yy")));
        }

        #endregion
    }
}
