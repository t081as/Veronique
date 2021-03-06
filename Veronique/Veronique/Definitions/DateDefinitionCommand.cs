﻿#region GNU General Public License 3
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
using System.Globalization;
using Veronique.Utilities;
#endregion

namespace Veronique.Definitions
{
    /// <summary>
    /// Represents an implementation of the <see cref="IDefinitionCommand"/> interface returning parts of a date.
    /// </summary>
    [DefinitionCommand("date")]
    public class DateDefinitionCommand : IDefinitionCommand
    {
        #region Methods

        /// <summary>
        /// Evaluates a definition.
        /// </summary>
        /// <param name="parameters">The parameters given to this evaluation.</param>
        /// <returns>The evaluated definition.</returns>
        /// <exception cref="ArgumentNullException"><c>parameters</c> is null.</exception>
        /// <exception cref="ArgumentNullException">A parameter is null.</exception>
        /// <exception cref="ArgumentException">The number of arguments is invalid.</exception>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        /// <exception cref="ApplicationException">An error occured during the operation.</exception>
        /// <remarks>
        /// If this method returns <c>null</c> or <see cref="string.Empty"/> the variable defined
        /// will contain the value <c>EMPTY</c> and subsequent definitions of the identical
        /// variable will be executed.
        /// </remarks>
        public string Evaluate(string[] parameters)
        {
            Parameter.Check(parameters, 2, 2);

            DateTime refTime;

            switch (parameters[0].ToLower())
            {
                case "local":
                    refTime = DateTime.Now;
                    break;

                case "utc":
                    refTime = DateTime.UtcNow;
                    break;

                default:
                    return null;
            }

            string result = null;

            switch (parameters[1].ToLower())
            {
                case "year":
                    result = refTime.Year.ToString("00");
                    break;

                case "short-year":
                    result = refTime.ToString("yy");
                    break;

                case "very-short-year":
                    result = int.Parse(refTime.ToString("yy")).ToString();
                    break;

                case "month":
                    result = refTime.Month.ToString("00");
                    break;

                case "short-month":
                    result = refTime.Month.ToString();
                    break;

                case "day":
                    result = refTime.Day.ToString("00");
                    break;

                case "short-day":
                    result = refTime.Day.ToString();
                    break;

                default:
                    result = null;
                    break;
            }

            return result;
        }

        #endregion
    }
}
