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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Veronique.Utilities;
#endregion

namespace Veronique.Writers
{
    /// <summary>
    /// Represents an implementation of the <see cref="IWriterCommand"/> interface replacing a text string in a utf8 file
    /// using a regular expression.
    /// </summary>
    [WriterCommand("replace-text-regex")]
    public class ReplaceTextRegexWriterCommand : IWriterCommand
    {
        #region Methods

        /// <summary>
        /// Writes a definition based variable to a destination.
        /// </summary>
        /// <param name="parameters">The parameters given to this writer.</param>
        /// <exception cref="ArgumentNullException"><c>parameters</c> is null.</exception>
        /// <exception cref="ArgumentNullException">A parameter is null.</exception>
        /// <exception cref="ArgumentException">The number of arguments is invalid.</exception>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        /// <exception cref="ApplicationException">An error occured during the operation.</exception>
        public void Write(string[] parameters)
        {
            Parameter.Check(parameters, 3, 3);

            try
            {
                string fileName = Parameter.ToPlatformSpecificPath(parameters[0]);
                string pattern = parameters[1];
                string replaceText = parameters[2];

                Encoding utf8 = new UTF8Encoding(false);

                string fileContents = File.ReadAllText(fileName, utf8);
                fileContents = Regex.Replace(fileContents, pattern, replaceText);
                File.WriteAllText(fileName, fileContents, utf8);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while replacing text in file using a regular expression", ex);
            }
        }

        #endregion
    }
}
