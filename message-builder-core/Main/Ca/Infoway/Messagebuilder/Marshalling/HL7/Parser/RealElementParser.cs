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
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// REAL - BigDecimal
	/// Parses an REAL element into a BigDecimal.
	/// </summary>
	/// <remarks>
	/// REAL - BigDecimal
	/// Parses an REAL element into a BigDecimal. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-REAL
	/// CHI further breaks down the datatype into REAL.CONF and REAL.COORD subtypes.
	/// </remarks>
	[DataTypeHandler(new string[] { "REAL.CONF", "REAL.COORD" })]
	internal class RealElementParser : AbstractSingleElementParser<BigDecimal>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override BigDecimal ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			ValidateNoChildren(context, node);
			BigDecimal result = null;
			string unparsedReal = GetAttributeValue(node, "value");
			ValidateDecimal(unparsedReal, context.Type, xmlToModelResult, (XmlElement)node);
			if (unparsedReal != null)
			{
				try
				{
					result = new BigDecimal(unparsedReal);
				}
				catch (FormatException)
				{
					RecordInvalidNumberError(context, node, xmlToModelResult, unparsedReal);
				}
			}
			return result;
		}

		private void ValidateDecimal(string value, string type, XmlToModelResult result, XmlElement element)
		{
			if (NumberUtil.IsNumber(value))
			{
				string integerPart = value.Contains(".") ? StringUtils.SubstringBefore(value, ".") : value;
				string decimalPart = value.Contains(".") ? StringUtils.SubstringAfter(value, ".") : string.Empty;
				RealFormat format = GetFormat(type);
				if (StandardDataType.REAL_CONF.Type.Equals(type) && !ValueIsBetweenZeroAndOneInclusive(integerPart, decimalPart))
				{
					RecordValueMustBeBetweenZeroAndOneError(value, type, result, element);
				}
				// TM - decided to remove check on overall length; we check before and after decimal lengths, which should be sufficient
				if (StringUtils.Length(integerPart) > format.GetMaxIntegerPartLength())
				{
					RecordTooManyCharactersBeforeDecimalError(value, type, result, element, format);
				}
				if (StringUtils.Length(decimalPart) > format.GetMaxDecimalPartLength())
				{
					RecordTooManyDigitsAfterDecimalError(value, type, result, element, format);
				}
			}
			else
			{
				if (StringUtils.IsBlank(value))
				{
					RecordValueMustBeSpecifiedError(result, element);
				}
			}
		}

		private void RecordValueMustBeSpecifiedError(XmlToModelResult result, XmlElement element)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value must be specified", element));
		}

		private bool ValueIsBetweenZeroAndOneInclusive(string integerPart, string decimalPart)
		{
			// integer part must be a single zeros or empty; otherwise integer must be 1 and decimal must be all zeros or empty
			// TM - if this doesn't translate to .NET, then this can be replaced with a simple StringBuilder in a loop
			string repeatedZerosInteger = new string(new char[integerPart.Length]).Replace("\0", "0");
			string repeatedZerosDecimal = new string(new char[decimalPart.Length]).Replace("\0", "0");
			bool integerPartAllZerosOrEmpty = repeatedZerosInteger.Equals(integerPart) || string.Empty.Equals(integerPart);
			bool integerIsOneAndDecimalAllZerosOrEmpty = "1".Equals(integerPart) && (repeatedZerosDecimal.Equals(decimalPart));
			return integerPartAllZerosOrEmpty || integerIsOneAndDecimalAllZerosOrEmpty;
		}

		private void RecordValueMustBeBetweenZeroAndOneError(string value, string type, XmlToModelResult result, XmlElement element
			)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " must be between 0 and 1 (inclusive)."
				, element));
		}

		private void RecordTooManyDigitsAfterDecimalError(string value, string type, XmlToModelResult result, XmlElement element, 
			RealFormat format)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " should have no more than "
				 + format.GetMaxDecimalPartLength() + " digits after the decimal", element));
		}

		private void RecordTooManyCharactersBeforeDecimalError(string value, string type, XmlToModelResult result, XmlElement element
			, RealFormat format)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " should have no more than "
				 + format.GetMaxIntegerPartLength() + " characters before the decimal", element));
		}

		private void RecordInvalidNumberError(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult, string unparsedReal
			)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + unparsedReal + "\" of type " + context
				.Type + " is not a valid number", (XmlElement)node));
		}

		private RealFormat GetFormat(string type)
		{
			return StandardDataType.REAL_CONF.Type.Equals(type) ? (RealFormat)new RealConfFormat() : (RealFormat)new RealCoordFormat(
				);
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new REALImpl();
		}
	}
}
