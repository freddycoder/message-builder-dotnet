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
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>Parses an BL element into a Boolean.</summary>
	/// <remarks>
	/// Parses an BL element into a Boolean. The element looks like this:
	/// 
	/// If a BL is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-BL
	/// </remarks>
	[DataTypeHandler("BL")]
	public class BlElementParser : AbstractSingleElementParser<Boolean?>
	{
		private static IList<string> VALID_BOOLEAN_STRINGS = new List<string>();

		static BlElementParser()
		{
			VALID_BOOLEAN_STRINGS.Add("true");
			VALID_BOOLEAN_STRINGS.Add("false");
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new BLImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Boolean? ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType, 
			XmlToModelResult xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			return ParseBooleanValue(xmlToModelResult, GetAttributeValue(element, "value"), element, null);
		}

		// public as a result of needing to call this method from ValidatingVistor
		public virtual Boolean? ParseBooleanValue(XmlToModelResult result, string unparsedBoolean, XmlElement element, XmlAttribute
			 attr)
		{
			Boolean? booleanResult = null;
			if (StringUtils.IsBlank(unparsedBoolean))
			{
				result.AddHl7Error(Hl7Error.CreateMandatoryBooleanValueError(element, attr));
			}
			else
			{
				if (VALID_BOOLEAN_STRINGS.Contains(unparsedBoolean))
				{
					booleanResult = ILOG.J2CsMapping.Util.BooleanUtil.ValueOf(unparsedBoolean);
				}
				else
				{
					if (VALID_BOOLEAN_STRINGS.Contains(unparsedBoolean.ToLower()))
					{
						result.AddHl7Error(Hl7Error.CreateIncorrectCapitalizationBooleanValueError(unparsedBoolean, element, attr));
						booleanResult = ILOG.J2CsMapping.Util.BooleanUtil.ValueOf(unparsedBoolean);
					}
					else
					{
						result.AddHl7Error(Hl7Error.CreateInvalidBooleanValueError(element, attr));
					}
				}
			}
			return booleanResult;
		}
	}
}
