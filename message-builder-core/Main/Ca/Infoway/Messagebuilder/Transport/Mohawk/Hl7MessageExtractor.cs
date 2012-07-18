/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System.IO;
using System.Xml;

namespace Ca.Infoway.Messagebuilder.Transport.Mohawk
{
	
	/// <summary>sharpen.ignore - transport - TBD!</summary>
	internal class Hl7MessageExtractor
	{
		/// <summary>Extracts an HL7 message as a string from an input stream.</summary>
		/// <remarks>Extracts an HL7 message as a string from an input stream.</remarks>
		/// <param name="input">the input stream from which a message can be extracted</param>
		/// <returns>the message in string format</returns>
		/// <exception cref="System.IO.IOException">if there is a problem in reading data from the input stream</exception>
		/// <exception cref="soap.SOAPException">may be thrown if the message is invalid</exception>
		public virtual string GetHl7Message(Stream input)
		{
			var document = new XmlDocument();
            document.Load(input);

            var nsmgr = new XmlNamespaceManager(document.NameTable);
            nsmgr.AddNamespace("soap", "http://www.w3.org/2003/05/soap-envelope");

		    var singleNode = document.SelectSingleNode("//soap:Body",nsmgr);

		    return singleNode.InnerXml;

		}

	}
	
}
