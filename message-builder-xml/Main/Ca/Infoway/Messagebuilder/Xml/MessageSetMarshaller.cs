/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2014-01-30 15:25:26 -0500 (Thu, 30 Jan 2014) $
 * Revision:      $LastChangedRevision: 8372 $
 */
using System.IO;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A utility to read and write the object representation of a message set.</summary>
	/// <remarks>A utility to read and write the object representation of a message set.</remarks>
	/// <author>Intelliware Development</author>
	public class MessageSetMarshaller
	{
		private Serializer serializer = new Persister();

		/// <summary>Unmarshall a message set to a file.</summary>
		/// <remarks>Unmarshall a message set to a file.</remarks>
		/// <param name="file">- the file to read</param>
		/// <returns>the message set.</returns>
		/// <exception cref="System.Exception">- if any underlying exception occurs</exception>
		public virtual MessageSet Unmarshall(FileInfo file)
		{
			return (MessageSet)this.serializer.Read(typeof(MessageSet), file);
		}

		/// <summary>Marshall a message set to an output stream.</summary>
		/// <remarks>Marshall a message set to an output stream.</remarks>
		/// <param name="domain">- the message set to marshall</param>
		/// <param name="output">- the output stream</param>
		/// <exception cref="System.Exception">- if any underlying exception occurs</exception>
		public virtual void Marshall(MessageSet domain, Stream output)
		{
			this.serializer.Write(domain, output);
		}

		/// <summary>Marshall a message set to an output stream.</summary>
		/// <remarks>Marshall a message set to an output stream.</remarks>
		/// <param name="domain">- the message set to marshall</param>
		/// <param name="file">- the file to write to</param>
		/// <exception cref="System.Exception">- if any underlying exception occurs</exception>
		public virtual void Marshall(MessageSet domain, FileInfo file)
		{
			this.serializer.Write(domain, file);
		}

		/// <summary>Unmarshall a message set to a file.</summary>
		/// <remarks>Unmarshall a message set to a file.</remarks>
		/// <param name="input">- the input stream</param>
		/// <returns>the message set.</returns>
		/// <exception cref="System.Exception">- if any underlying exception occurs</exception>
		public virtual MessageSet Unmarshall(Stream input)
		{
			return (MessageSet)this.serializer.Read(typeof(MessageSet), input);
		}
	}
}
