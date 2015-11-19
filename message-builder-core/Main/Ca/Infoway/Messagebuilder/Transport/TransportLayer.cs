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
using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A transport mechanism for sending requests (as requestMessages) and receiving responses (as strings).</summary>
	/// <remarks>A transport mechanism for sending requests (as requestMessages) and receiving responses (as strings).</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public interface TransportLayer
	{
		/// <summary>Sends a RequestMessage using the provided credentials and returns a response message as a string.</summary>
		/// <remarks>Sends a RequestMessage using the provided credentials and returns a response message as a string.</remarks>
		/// <param name="credentialsProvider">a way to obtain credentials</param>
		/// <param name="requestMessage">the message to be sent across the transport layer</param>
		/// <returns>the response message as a string</returns>
		/// <exception cref="TransportLayerException">if any problems occurred during send or receive of the message</exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException"></exception>
		string SendRequestAndGetResponse(CredentialsProvider credentialsProvider, RequestMessage requestMessage);
	}
}
