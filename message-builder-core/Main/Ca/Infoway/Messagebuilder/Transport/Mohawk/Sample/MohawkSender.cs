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
using Ca.Infoway.Messagebuilder.Transport.Mohawk;
using Ca.Infoway.Messagebuilder.Transport.Mohawk.Sample;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Transport.Mohawk.Sample
{
	/// <summary>Sends a sample message to the Mohawk HIAL using the MohawkTransportLayer.</summary>
	/// <remarks>Sends a sample message to the Mohawk HIAL using the MohawkTransportLayer.</remarks>
	/// <author>
	/// <a href="http://www.intelliware.ca/">Intelliware Development</a>
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public class MohawkSender
	{
		/// <summary>Sends a sample message to the Mohawk HIAL using the MohawkTransportLayer.</summary>
		/// <remarks>Sends a sample message to the Mohawk HIAL using the MohawkTransportLayer.</remarks>
		/// <param name="args">standard "main" args (not used in this case)</param>
		/// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException">if the message or its response encountered problems
		/// 	</exception>
		/// <exception cref="SAXException">if the sample xml could not be converted into a Document (parsing problem)</exception>
		/// <exception cref="System.IO.IOException">if the sample xml could not be converted into a Document (resource problem)</exception>
/*		public static void Main(string[] args)
		{
			MohawkTransportLayer transportLayer = new MohawkTransportLayer();
			CredentialsProvider credentialsProvider = new _CredentialsProvider_35();
			RequestMessage requestMessage = SimpleRequestMessage.Create(new DocumentFactory().CreateFromStream(Ca.Infoway.Messagebuilder.Platform.ResourceLoader.GetResource
				(typeof(MohawkSender), "findCandidatesQuery.xml")));
			string response = transportLayer.SendRequestAndGetResponse(credentialsProvider, requestMessage);
			System.Console.Out.WriteLine(response);
		}*/

		private sealed class _CredentialsProvider_35 : CredentialsProvider
		{
			public _CredentialsProvider_35()
			{
			}

			public Credentials GetCredentials()
			{
				return new UsernamePasswordCredentials("username", "password");
			}
		}
	}
}
