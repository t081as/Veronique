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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Xml;
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
        /// Represents the definitions.
        /// </summary>
        private List<Definition> definitions;

        /// <summary>
        /// Represents the writers.
        /// </summary>
        private List<Writer> writers;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.projectName = string.Empty;
            this.formatVersion = "v1";
            this.definitions = new List<Definition>();
            this.writers = new List<Writer>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        [DataMember(Name = "projectname", Order = 0)]
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
        [DataMember(Name = "formatversion", Order = 1)]
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
        /// Gets or sets the definitions.
        /// </summary>
        [DataMember(Name = "definitions", Order = 2)]
        public List<Definition> Definitions
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
        [DataMember(Name = "writers", Order = 3)]
        public List<Writer> Writers
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
        /// <exception cref="IOException">Error while writing the configuration.</exception>
        public static void Write(Stream stream, Configuration configuration)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            try
            {
                using (XmlDictionaryWriter writer = JsonReaderWriterFactory.CreateJsonWriter(stream, new UTF8Encoding(false), false, true, " "))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Configuration));
                    serializer.WriteObject(writer, configuration);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Error while writing the configuration", ex);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = currentCulture;
            }
        }

        /// <summary>
        /// Reads a configuration from the given stream.
        /// </summary>
        /// <param name="stream">The stream that contains a configuration.</param>
        /// <returns>The configuration read from the given stream.</returns>
        /// <exception cref="IOException">Error while reading the configuration.</exception>
        public static Configuration Read(Stream stream)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Configuration));
                return (Configuration)serializer.ReadObject(stream);
            }
            catch (Exception ex)
            {
                throw new IOException("Error while reading the configuration", ex);
            }
        }

        #endregion
    }
}
