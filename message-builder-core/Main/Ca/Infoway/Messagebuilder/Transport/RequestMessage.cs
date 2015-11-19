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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Xml;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A message that can be sent across a transport layer.</summary>
	/// <remarks>A message that can be sent across a transport layer.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public interface RequestMessage
	{
		/// <summary>Obtains the message as a string, converting the underlying structure if necessary (i.e.</summary>
		/// <remarks>Obtains the message as a string, converting the underlying structure if necessary (i.e. DOM -&gt; string).</remarks>
		/// <returns>the underlying message rendered as a string</returns>
		/// <exception cref="TransportLayerException">if a string representation of the message could not be constructed</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		string GetMessageAsString();

		/// <summary>Obtains the message's interaction id.</summary>
		/// <remarks>Obtains the message's interaction id.</remarks>
		/// <returns>the message's interaction id</returns>
		/// <exception cref="TransportLayerException">if the message's interaction id could not be determined</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		string GetInteractionId();

		/// <summary>Obtains the message as a DOM, converting the underlying structure if necessary (i.e.</summary>
		/// <remarks>Obtains the message as a DOM, converting the underlying structure if necessary (i.e. string -&gt; DOM).</remarks>
		/// <returns>the underlying message in a DOM structure</returns>
		/// <exception cref="TransportLayerException">if there were problems creating the DOM</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		XmlDocument GetMessageAsDocument();
	}
}
