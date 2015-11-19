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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// TN - TrivialName
	/// Parses a TN element into a TrivialName.
	/// </summary>
	/// <remarks>
	/// TN - TrivialName
	/// Parses a TN element into a TrivialName. The element looks like this:
	/// This is a trivial name
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TN
	/// </remarks>
	[DataTypeHandler("TN")]
	internal class TnElementParser : AbstractEntityNameElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new TNImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNode(XmlNode node, XmlToModelResult xmlToModelResult)
		{
			string name = null;
			int childNodeCount = node.ChildNodes.Count;
			if (childNodeCount == 0)
			{
			}
			else
			{
				// name portion is null
				if (childNodeCount == 1)
				{
					XmlNode childNode = node.FirstChild;
					if (childNode.NodeType != System.Xml.XmlNodeType.Text)
					{
						throw new XmlToModelTransformationException("Expected TN node to have a text node");
					}
					name = childNode.Value;
				}
				else
				{
					throw new XmlToModelTransformationException("Expected TN node to have at most one child");
				}
			}
			return new TrivialName(name);
		}
	}
}
