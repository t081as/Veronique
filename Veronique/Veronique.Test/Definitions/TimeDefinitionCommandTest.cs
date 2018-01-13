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
using System;
using NUnit.Framework;
using Veronique.Definitions;
#endregion

namespace Veronique.Test.Definitions
{
    /// <summary>
    /// Contains unit tests for the <see cref="TimeDefinitionCommand"/> class.
    /// </summary>
    [TestFixture]
    public class TimeDefinitionCommandTest
    {
        #region Methods

        /// <summary>
        /// Checks the definition command.
        /// </summary>
        [Test]
        public void TestDefinition()
        {
            IDefinitionCommand test = DefinitionCommandManager.CreateByName("time");

            string hour = test.Evaluate(new string[] { "local", "hour" });
            string shortHour = test.Evaluate(new string[] { "local", "short-hour" });
            string minute = test.Evaluate(new string[] { "local", "minute" });
            string shortMinute = test.Evaluate(new string[] { "local", "short-minute" });
            string second = test.Evaluate(new string[] { "local", "second" });
            string shortSecond = test.Evaluate(new string[] { "local", "short-second" });
            string totalMinutes = test.Evaluate(new string[] { "local", "total-minutes" });
            string totalSeconds = test.Evaluate(new string[] { "local", "total-seconds" });
        }

        #endregion
    }
}
