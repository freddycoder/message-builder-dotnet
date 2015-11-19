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
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// MO - Money
	/// Represents an MO elements into a MO object.
	/// </summary>
	/// <remarks>
	/// MO - Money
	/// Represents an MO elements into a MO object. The element looks like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-MO
	/// </remarks>
	[DataTypeHandler("MO")]
	internal class MoElementParser : AbstractSingleElementParser<Money>
	{
		private const int MAX_DIGITS_BEFORE_DECIMAL = 11;

		private const int MAX_DIGITS_AFTER_DECIMAL = 2;

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new MOImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Money ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			ValidateNoChildren(context, node);
			string value = GetMandatoryAttributeValue(node, "value", xmlToModelResult);
			BigDecimal amount = ValidateValue(value, context.Type, xmlToModelResult, (XmlElement)node);
			string currencyCode = GetMandatoryAttributeValue(node, "currency", xmlToModelResult);
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency currency = ValidateCurrency(currencyCode, node, xmlToModelResult);
			return amount == null && currency == null ? null : new Money(amount, currency);
		}

		private BigDecimal ValidateValue(string value, string type, XmlToModelResult xmlToModelResult, XmlElement element)
		{
			if (StringUtils.IsBlank(value))
			{
				return null;
			}
			if (NumberUtil.IsNumber(value))
			{
				string integerPart = value.Contains(".") ? StringUtils.SubstringBefore(value, ".") : value;
				string decimalPart = value.Contains(".") ? StringUtils.SubstringAfter(value, ".") : string.Empty;
				if (StringUtils.Length(integerPart) > MAX_DIGITS_BEFORE_DECIMAL)
				{
					RecordTooManyDigitsBeforeDecimalError(value, type, xmlToModelResult, element);
				}
				if (StringUtils.Length(decimalPart) > MAX_DIGITS_AFTER_DECIMAL)
				{
					RecordTooManyDigitsAfterDecimalError(value, type, xmlToModelResult, element);
				}
				if (!StringUtils.IsNumeric(integerPart) || !StringUtils.IsNumeric(decimalPart))
				{
					RecordMustContainDigitsOnlyError(value, xmlToModelResult, element);
				}
			}
			BigDecimal result = null;
			try
			{
				result = new BigDecimal(value);
			}
			catch (FormatException)
			{
				RecordInvalidNumberError(value, type, element, xmlToModelResult);
			}
			return result;
		}

		private Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency ValidateCurrency(string currencyCode, XmlNode node, XmlToModelResult
			 xmlToModelResult)
		{
			if (StringUtils.IsBlank(currencyCode))
			{
				return null;
			}
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency currency = CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency
				>(currencyCode);
			if (currency == null)
			{
				RecordUnknownCurrencyError(currencyCode, node, xmlToModelResult);
			}
			else
			{
				if (!Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR.CodeValue.Equals(currencyCode))
				{
					RecordCurrencyMustBeCanadianError(currencyCode, node, xmlToModelResult);
				}
			}
			return currency;
		}

		private void RecordCurrencyMustBeCanadianError(string currencyCode, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Currency " + currencyCode + "is not allowed. Currency must be set to CAD. ("
				 + XmlDescriber.DescribeSingleElement((XmlElement)node) + ")", (XmlElement)node));
		}

		private void RecordUnknownCurrencyError(string currencyCode, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Could not decode currency value " + currencyCode
				 + " (" + XmlDescriber.DescribeSingleElement((XmlElement)node) + ")", (XmlElement)node));
		}

		private void RecordTooManyDigitsAfterDecimalError(string value, string type, XmlToModelResult result, XmlElement element)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " should have no more than "
				 + MAX_DIGITS_AFTER_DECIMAL + " digits after the decimal (" + XmlDescriber.DescribeSingleElement(element) + ")", element
				));
		}

		private void RecordTooManyDigitsBeforeDecimalError(string value, string type, XmlToModelResult result, XmlElement element
			)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type " + type + " should have no more than "
				 + MAX_DIGITS_BEFORE_DECIMAL + " digits before the decimal (" + XmlDescriber.DescribeSingleElement(element) + ")", element
				));
		}

		private void RecordInvalidNumberError(string value, string type, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + value + "\" of type " + type + " is not a valid number ("
				 + XmlDescriber.DescribeSingleElement(element) + ")", element));
		}

		private void RecordMustContainDigitsOnlyError(string value, XmlToModelResult xmlToModelResult, XmlElement element)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + value + "\" can only contain digits, with a maximum of "
				 + MAX_DIGITS_BEFORE_DECIMAL + " before the decimal and " + MAX_DIGITS_AFTER_DECIMAL + " after the decimal. (" + XmlDescriber
				.DescribeSingleElement(element) + ")", element));
		}
	}
}
