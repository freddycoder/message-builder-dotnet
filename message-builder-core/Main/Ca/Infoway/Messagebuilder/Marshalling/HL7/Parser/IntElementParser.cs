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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// INT - Integer
	/// Parses an INT element into a Integer.
	/// </summary>
	/// <remarks>
	/// INT - Integer
	/// Parses an INT element into a Integer. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-INT
	/// CeRx further breaks down the datatype into INT.NONNEG and INT.POS subtypes.
	/// </remarks>
	[DataTypeHandler(new string[] { "INT.NONNEG", "INT.POS", "INT" })]
	internal class IntElementParser : AbstractSingleElementParser<Int32?>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Int32? ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			ValidateNoChildren(context, node);
			return ParseNonNullNode(context, (XmlElement)node, xmlToModelResult);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Int32? ParseNonNullNode(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			Int32? result = null;
			string unparsedInteger = GetAttributeValue(element, "value");
			if (StringUtils.IsNotBlank(unparsedInteger))
			{
				if (!NumberUtil.IsNumber(unparsedInteger))
				{
					RecordNotAValidNumberError(element, xmlToModelResult);
				}
				else
				{
					result = NumberUtil.ParseAsInteger(unparsedInteger);
					// using the isNumeric check to catch silly things such as passing in a hexadecimal number (0x1a, for example)
					bool mustBePositive = StandardDataType.INT_POS.Type.Equals(context.Type);
					if (StandardDataType.INT.Type.Equals(context.Type) && unparsedInteger.StartsWith("-"))
					{
						// remove negative sign to not confuse isNumeric() check
						unparsedInteger = Ca.Infoway.Messagebuilder.StringUtils.Substring(unparsedInteger, 1);
					}
					if (!NumberUtil.IsInteger(unparsedInteger) || !StringUtils.IsNumeric(unparsedInteger))
					{
						RecordInvalidIntegerError(result, element, mustBePositive, xmlToModelResult);
					}
					else
					{
						if (mustBePositive && result.Value == 0)
						{
							RecordMustBeGreaterThanZeroError(element, xmlToModelResult);
						}
					}
				}
			}
			else
			{
				if (element.HasAttribute("value"))
				{
					RecordEmptyValueError(element, xmlToModelResult);
				}
				else
				{
					RecordMissingValueError(element, xmlToModelResult);
				}
			}
			return result;
		}

		private void RecordMissingValueError(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" must be specified. (" + 
				XmlDescriber.DescribeSingleElement(element) + ")", element));
		}

		private void RecordEmptyValueError(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" is specified, but empty. ("
				 + XmlDescriber.DescribeSingleElement(element) + ")", element));
		}

		private void RecordMustBeGreaterThanZeroError(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" must be greater than zero for INT.POS. ("
				 + XmlDescriber.DescribeSingleElement(element) + ")", element));
		}

		//	private void recordNotNegativeError(Element element, XmlToModelResult xmlToModelResult) {
		//		xmlToModelResult.addHl7Error(
		//				new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, 
		//						"The attribute \"value\" must not be negative for INT.NONNEG. (" 
		//						+ XmlDescriber.describeSingleElement(element)
		//						+ ")", element));
		//	}
		//
		private void RecordInvalidIntegerError(Int32? result, XmlElement element, bool mustBePositive, XmlToModelResult xmlToModelResult
			)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" is not a valid integer: it cannot be negative "
				 + (mustBePositive ? "or zero " : string.Empty) + "and must be digits only (maximum of 10), with a maximum value of " + 
				int.MaxValue + "." + " The value may have been truncated; processing value as " + result + " (" + XmlDescriber.DescribeSingleElement
				(element) + ")", element));
		}

		private void RecordNotAValidNumberError(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" does not contain a valid number ("
				 + XmlDescriber.DescribeSingleElement(element) + ")", element));
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new INTImpl();
		}
	}
}
