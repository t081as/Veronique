﻿#region GNU General Public License 3
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
using System.Diagnostics;
using System.IO;
using System.Text;
#endregion

namespace Veronique.Commands
{
    /// <summary>
    /// Represents an abstract base class for simple commands.
    /// </summary>
    public abstract class DefaultCommand
    {
        #region Constants and Fields

        /// <summary>
        /// Represents the command that shall be executed.
        /// </summary>
        private string command;

        /// <summary>
        /// Represents the command line arguments that shall be used.
        /// </summary>
        private string commandLine;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCommand"/> class.
        /// </summary>
        /// <param name="command">The command that shall be executed.</param>
        public DefaultCommand(string command)
        {
            this.command = command;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCommand"/> class.
        /// </summary>
        /// <param name="command">The command that shall be executed.</param>
        /// <param name="commandLine">The command line arguments that shall be used.</param>
        public DefaultCommand(string command, string commandLine)
            : this(command)
        {
            this.commandLine = command;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the command and returns the output.
        /// </summary>
        /// <returns>The output of the external command.</returns>
        /// <exception cref="IOException">An error occured while executing the external command.</exception>
        public string Execute()
        {
            try
            {
                Process process = new Process();

                process.StartInfo.FileName = this.command;
                process.StartInfo.Arguments = this.commandLine;
                process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.StandardErrorEncoding = Encoding.UTF8;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();
                process.Close();

                return output.Trim();
            }
            catch (Exception ex)
            {
                throw new IOException($"Error while executing the {this.command}-command", ex);
            }
        }

        #endregion
    }
}
