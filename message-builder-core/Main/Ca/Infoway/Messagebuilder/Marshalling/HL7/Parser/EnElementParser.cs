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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// EN - EntityName
	/// Parses an EN element into a EntityName.
	/// </summary>
	/// <remarks>
	/// EN - EntityName
	/// Parses an EN element into a EntityName. The element looks like this:
	/// This is a trivial name
	/// This class makes a decision on which parser to use based on the format of the
	/// XML.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-EN
	/// </remarks>
	[DataTypeHandler("EN")]
	internal class EnElementParser : AbstractSingleElementParser<EntityName>
	{
		private readonly AbstractEntityNameElementParser onElementParser = new OnElementParser();

		private readonly PnElementParser pnElementParser = new PnElementParser();

		private readonly TnElementParser tnElementParser = new TnElementParser();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			EntityName result;
			if (tnElementParser.IsParseable(node, context))
			{
				result = (EntityName)tnElementParser.Parse(context, node, xmlToModelResult).BareValue;
			}
			else
			{
				if (onElementParser.IsParseable(node, context))
				{
					result = (EntityName)onElementParser.Parse(context, node, xmlToModelResult).BareValue;
				}
				else
				{
					if (pnElementParser.IsParseable(node, context))
					{
						result = (EntityName)pnElementParser.Parse(context, node, xmlToModelResult).BareValue;
					}
					else
					{
						throw new XmlToModelTransformationException("Cannot figure out how to parse node " + node.ToString());
					}
				}
			}
			return result;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ENImpl<EntityName>();
		}
	}
}
