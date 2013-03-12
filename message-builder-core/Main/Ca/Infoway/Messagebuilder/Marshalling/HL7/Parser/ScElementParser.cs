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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// SC - Coded String (CS was already taken for coded simple)
	/// Parses an SC element into a CodedString.
	/// </summary>
	/// <remarks>
	/// SC - Coded String (CS was already taken for coded simple)
	/// Parses an SC element into a CodedString. The element looks like this:
	/// Assistant to the Regional Manager
	/// Regional Manager
	/// HL7 defines other optional attributes such as code system version and description.
	/// Currently this class does nothing with codeSystem.
	/// This class is a mix of StElementParser and CvElementParser.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-SC
	/// TODO: handle code properly
	/// </remarks>
	[DataTypeHandler("SC")]
	internal class ScElementParser<V> : AbstractSingleElementParser<CodedString<V>> where V : Code
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override CodedString<V> ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			string value = null;
			int childNodeCount = node.ChildNodes.Count;
			if (childNodeCount == 0)
			{
				// this is an empty node, return empty string (null should have a null flavor attribute)
				value = AbstractSingleElementParser<CodedString<V>>.EMPTY_STRING;
			}
			else
			{
				if (childNodeCount == 1)
				{
					XmlNode childNode = node.FirstChild;
					if (childNode.NodeType != System.Xml.XmlNodeType.Text)
					{
						throw new XmlToModelTransformationException("Expected SC node to have a text node");
					}
					value = childNode.Value;
				}
				else
				{
					throw new XmlToModelTransformationException("Expected SC node to have at most one child");
				}
			}
			return new CodedString<V>(value, default(V));
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new SCImpl<V>();
		}
	}
}
