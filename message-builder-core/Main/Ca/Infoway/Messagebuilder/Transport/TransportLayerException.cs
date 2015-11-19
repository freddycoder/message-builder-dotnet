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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */
using System;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>An exception for general problems encountered within the transport layers.</summary>
	/// <remarks>An exception for general problems encountered within the transport layers.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	[System.Serializable]
	public class TransportLayerException : Exception
	{
		private const long serialVersionUID = -5941185034989629293L;

		/// <summary>Constructs a basic transport exception.</summary>
		/// <remarks>Constructs a basic transport exception.</remarks>
		public TransportLayerException()
		{
		}

		/// <summary>Constructs a transport exception with a message and a cause.</summary>
		/// <remarks>Constructs a transport exception with a message and a cause.</remarks>
		/// <param name="message">the exception error message</param>
		/// <param name="cause">the root exception</param>
		public TransportLayerException(string message, Exception cause) : base(message, cause)
		{
		}

		/// <summary>Constructs a transport exception with a message.</summary>
		/// <remarks>Constructs a transport exception with a message.</remarks>
		/// <param name="message">the exception error message</param>
		public TransportLayerException(string message) : base(message)
		{
		}

		/// <summary>Constructs a transport exception with a cause.</summary>
		/// <remarks>Constructs a transport exception with a cause.</remarks>
		/// <param name="cause">the root exception</param>
		public TransportLayerException(Exception cause) : base(cause.ToString(), cause)
		{
		}
	}
}
