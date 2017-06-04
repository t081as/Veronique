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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
#endregion

namespace Veronique.IO
{
    /// <summary>
    /// Represents a project configuration.
    /// </summary>
    [DataContract]
    public class Configuration
    {
        #region Constants and Fields

        /// <summary>
        /// Represets the name of the project.
        /// </summary>
        private string projectName;

        /// <summary>
        /// Represents the version number of this file format.
        /// </summary>
        private string formatVersion;

        /// <summary>
        /// Represents the defiitions.
        /// </summary>
        private Definition[] definitions;

        /// <summary>
        /// Represents the writers.
        /// </summary>
        private Writer[] writers;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.projectName = string.Empty;
            this.formatVersion = "v1";
            this.definitions = new Definition[0];
            this.writers = new Writer[0];
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [DataMember(Name = "projectname")]
        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                this.projectName = value;
            }
        }

        /// <summary>
        /// Gets or sets the version number of this file format.
        /// </summary>
        [DataMember(Name = "formatversion")]
        public string FormatVersion
        {
            get
            {
                return this.formatVersion;
            }

            set
            {
                this.formatVersion = value;
            }
        }

        /// <summary>
        /// Gets or sets the defiitions.
        /// </summary>
        [DataMember(Name = "definitions")]
        public Definition[] Definitions
        {
            get
            {
                return this.definitions;
            }

            set
            {
                this.definitions = value;
            }
        }

        /// <summary>
        /// Gets or sets the writers.
        /// </summary>
        [DataMember(Name = "writers")]
        public Writer[] Writers
        {
            get
            {
                return this.writers;
            }

            set
            {
                this.writers = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Writes the given configuration to the given stream.
        /// </summary>
        /// <param name="stream">The stream the configuration shall be writen to.</param>
        /// <param name="configuration">The configuration that shall be written.</param>
        public static void Write(Stream stream, Configuration configuration)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Configuration));
            serializer.WriteObject(stream, configuration);
        }

        /// <summary>
        /// Reads a configuration from the given stream.
        /// </summary>
        /// <param name="stream">The stream that contains a configuration.</param>
        /// <returns>The configuration read from the given stream.</returns>
        public static Configuration Read(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Configuration));
            return (Configuration)serializer.ReadObject(stream);
        }

        #endregion
    }
}
