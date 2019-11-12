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
#endregion

namespace Veronique.Utilities
{
    /// <summary>
    /// Allows to set the console color in a clear way.
    /// </summary>
    public class CurrentConsoleColor : IDisposable
    {
        #region Properties and Fields

        /// <summary>
        /// Represents the original foreground color.
        /// </summary>
        private ConsoleColor? originalForegroundColor = null;

        /// <summary>
        /// Represents the original background color.
        /// </summary>
        private ConsoleColor? originalBackgroundColor = null;

        /// <summary>
        /// Indicates if the class has already been disposed.
        /// </summary>
        private bool disposed = false;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentConsoleColor"/> class.
        /// </summary>
        /// <param name="foregroundColor">The foreground color that shall be applied.</param>
        public CurrentConsoleColor(ConsoleColor foregroundColor)
        {
            this.originalForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentConsoleColor"/> class.
        /// </summary>
        /// <param name="foregroundColor">The foreground color that shall be applied.</param>
        /// <param name="backgroundColor">The background color that shall be applied.</param>
        public CurrentConsoleColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.originalForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;

            this.originalBackgroundColor = Console.BackgroundColor;
            Console.BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CurrentConsoleColor"/> class.
        /// </summary>
        ~CurrentConsoleColor()
        {
            this.Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Indicates whether managed resources shall also be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    try
                    {
                        if (this.originalForegroundColor != null)
                        {
                            Console.ForegroundColor = this.originalForegroundColor.Value;
                        }

                        if (this.originalBackgroundColor != null)
                        {
                            Console.BackgroundColor = this.originalBackgroundColor.Value;
                        }
                    }
                    catch
                    {
                        // The Dispose method must never throw exceptions
                    }
                }

                this.disposed = true;
            }
        }

        #endregion
    }
}
