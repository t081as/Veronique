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
#endregion

namespace Veronique.Commands
{
    /// <summary>
    /// Executes the git describe command.
    /// </summary>
    public class GitDescribeCommand : DefaultCommand
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GitDescribeCommand"/> class.
        /// </summary>
        public GitDescribeCommand()
            : base("git", "describe --long")
        {
        }

        #endregion
    }
}
