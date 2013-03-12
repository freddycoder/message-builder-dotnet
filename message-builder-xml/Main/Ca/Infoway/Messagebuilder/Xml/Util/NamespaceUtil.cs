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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
using System.Xml;

namespace Ca.Infoway.Messagebuilder.Xml.Util
{
	/// <summary>A utility to determine if an XML node is in the HL7 namespace.</summary>
	/// <remarks>A utility to determine if an XML node is in the HL7 namespace.</remarks>
	/// <author>Intelliware Development</author>
	public class NamespaceUtil
	{
		private static readonly string HL7_NAMESPACE_URI = "urn:hl7-org:v3";

		/// <summary>Determine if the node in the HL7 namespace.</summary>
		/// <remarks>Determine if the node in the HL7 namespace.</remarks>
		/// <param name="node">- the node being considered</param>
		/// <returns>true if the node is part of the HL7 namespace; false otherwise</returns>
		public static bool IsHl7Node(XmlNode node)
		{
			if (HL7_NAMESPACE_URI.Equals(node.NamespaceURI))
			{
				return true;
			}
			else
			{
				if (node is XmlAttribute && (node.NamespaceURI == null || node.NamespaceURI == string.Empty))
				{
					return HL7_NAMESPACE_URI.Equals(((XmlAttribute)node).OwnerElement.NamespaceURI);
				}
				else
				{
					return false;
				}
			}
		}
	}
}
