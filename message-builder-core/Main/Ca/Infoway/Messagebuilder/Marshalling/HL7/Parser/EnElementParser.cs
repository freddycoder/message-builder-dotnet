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
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
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
		private OnElementParser onElementParser = new OnElementParser();

		private PnElementParser pnElementParser = new PnElementParser();

		private TnElementParser tnElementParser = new TnElementParser();

		private readonly IDictionary<string, NameParser> nameParsers = new Dictionary<string, NameParser>();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override EntityName ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			EntityName result = null;
			// The incoming xml should specify a specializationType or xsi:type in order to determine how to process the field. (CDA/R1 does allow for EN)
			// However, it should be possible to determine which concrete type to use by applying all known name parsers.
			string specializationType = GetSpecializationType(node);
			if (StringUtils.IsBlank(specializationType))
			{
				specializationType = GetXsiType(node);
			}
			string upperCaseST = StringUtils.IsBlank(specializationType) ? string.Empty : specializationType.ToUpper();
			NameParser nameParser = nameParsers.SafeGet(upperCaseST);
			if (nameParser == null && StringUtils.IsNotBlank(specializationType))
			{
				// log error based on bad ST/XT
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Could not determine appropriate parser to use for EN specializationType/xsi:type of: "
					 + specializationType, (XmlElement)node));
			}
			if (nameParser != null && nameParser.IsParseable(node, context))
			{
				result = (EntityName)nameParser.Parse(context, node, xmlToModelResult).BareValue;
			}
			else
			{
				string actualParserUsed = null;
				// try all known name parsers
				if (tnElementParser.IsParseable(node, context))
				{
					actualParserUsed = "TN";
					result = (EntityName)tnElementParser.Parse(context, node, xmlToModelResult).BareValue;
				}
				else
				{
					if (pnElementParser.IsParseable(node, context))
					{
						actualParserUsed = "PN";
						result = (EntityName)pnElementParser.Parse(context, node, xmlToModelResult).BareValue;
					}
					else
					{
						if (onElementParser.IsParseable(node, context))
						{
							actualParserUsed = "ON";
							result = (EntityName)onElementParser.Parse(context, node, xmlToModelResult).BareValue;
						}
						else
						{
							throw new XmlToModelTransformationException("Cannot figure out how to parse EN node " + node.ToString());
						}
					}
				}
				// need to log warning - not able to parse name as expected
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, ErrorLevel.WARNING, "EN field has been handled as type "
					 + actualParserUsed, (XmlElement)node));
			}
			return result;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ENImpl<EntityName>();
		}

		public EnElementParser()
		{
			{
				this.nameParsers["ON"] = this.onElementParser;
				this.nameParsers["PN"] = this.pnElementParser;
				this.nameParsers["TN"] = this.tnElementParser;
			}
		}
	}
}
