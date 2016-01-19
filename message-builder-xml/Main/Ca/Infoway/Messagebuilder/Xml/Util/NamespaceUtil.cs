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


using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml.Util
{
	/// <summary>A utility to determine if an XML node is in the HL7 namespace.</summary>
	/// <remarks>A utility to determine if an XML node is in the HL7 namespace.</remarks>
	/// <author>Intelliware Development</author>
	public class NamespaceUtil
	{
		private static readonly string HL7_BASE_NAMESPACE_URI = "urn:hl7-org:";

		private static readonly string HL7_NAMESPACE_URI = HL7_BASE_NAMESPACE_URI + "v3";

		private static readonly string CDA_NAMESPACE_URI = HL7_BASE_NAMESPACE_URI + "v3";

		private static readonly string SDTC_NAMESPACE_URI = HL7_BASE_NAMESPACE_URI + "sdtc";

		private static ICollection<string> NAMESPACES = new HashSet<string>();

		static NamespaceUtil()
		{
			NAMESPACES.Add(HL7_NAMESPACE_URI);
			NAMESPACES.Add(CDA_NAMESPACE_URI);
			NAMESPACES.Add(SDTC_NAMESPACE_URI);
		}

		/// <summary>Determine if the node is in the HL7 namespace.</summary>
		/// <remarks>Determine if the node is in the HL7 namespace.</remarks>
		/// <param name="node">- the node being considered</param>
		/// <returns>true if the node is part of the HL7 namespace; false otherwise</returns>
		public static bool IsHl7Node(XmlNode node)
		{
			if (NAMESPACES.Contains(node.NamespaceURI))
			{
				return true;
			}
			else
			{
				if (node is XmlAttribute && (StringUtils.IsBlank(node.NamespaceURI)))
				{
					return HL7_NAMESPACE_URI.Equals(((XmlAttribute)node).OwnerElement.NamespaceURI);
				}
				else
				{
					return false;
				}
			}
		}

		public static bool IsNamespaceCorrect(XmlNode node, Relationship relationship)
		{
			if (relationship == null)
			{
				return false;
			}
			string nodeNamespace = GetActualNamespace(node);
			string expectedNamespace = GetExpectedNamespace(relationship);
			return StringUtils.Equals(nodeNamespace, expectedNamespace);
		}

		public static string GetActualNamespace(XmlNode node)
		{
			string nodeNamespace = node.NamespaceURI;
			if (node is XmlAttribute && (StringUtils.IsBlank(nodeNamespace)))
			{
				nodeNamespace = ((XmlAttribute)node).OwnerElement.NamespaceURI;
			}
			return nodeNamespace;
		}

		public static string GetExpectedNamespace(Relationship relationship)
		{
			string expectedNamespace = HL7_NAMESPACE_URI;
			if (StringUtils.IsNotBlank(relationship.Namespaze))
			{
				expectedNamespace = HL7_BASE_NAMESPACE_URI + relationship.Namespaze;
			}
			return expectedNamespace;
		}
	}
}
