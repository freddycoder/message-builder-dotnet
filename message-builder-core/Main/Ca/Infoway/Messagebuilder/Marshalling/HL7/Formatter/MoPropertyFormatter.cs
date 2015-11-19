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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// MO - Money
	/// Represents an MO object as an element:
	/// &lt;amt value="10" currency="CAD"/&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-MO
	/// </summary>
	[DataTypeHandler("MO")]
	internal class MoPropertyFormatter : AbstractAttributePropertyFormatter<Money>
	{
		private const int MAX_DIGITS_BEFORE_DECIMAL = 11;

		private const int MAX_DIGITS_AFTER_DECIMAL = 2;

		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Money money, BareANY bareAny
			)
		{
			Validate(money, context);
			IDictionary<string, string> result = new Dictionary<string, string>();
			BigDecimal value = money.Amount;
			if (value != null)
			{
				result["value"] = value.ToString();
			}
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency currency = money.Currency;
			if (currency != null)
			{
				result["currency"] = currency.CodeValue;
			}
			return result;
		}

		private void Validate(Money money, FormatContext context)
		{
			ModelToXmlResult modelToXmlResult = context.GetModelToXmlResult();
			string propertyPath = context.GetPropertyPath();
			BigDecimal amount = money.Amount;
			if (amount == null)
			{
				RecordMissingValueError(propertyPath, modelToXmlResult);
			}
			else
			{
				string value = amount.ToString();
				string integerPart = value.Contains(".") ? StringUtils.SubstringBefore(value, ".") : value;
				string decimalPart = value.Contains(".") ? StringUtils.SubstringAfter(value, ".") : string.Empty;
				if (StringUtils.Length(integerPart) > MAX_DIGITS_BEFORE_DECIMAL)
				{
					RecordTooManyDigitsBeforeDecimalError(value, propertyPath, modelToXmlResult);
				}
				if (StringUtils.Length(decimalPart) > MAX_DIGITS_AFTER_DECIMAL)
				{
					RecordTooManyDigitsAfterDecimalError(value, propertyPath, modelToXmlResult);
				}
				if (!StringUtils.IsNumeric(integerPart) || !StringUtils.IsNumeric(decimalPart))
				{
					RecordMustContainDigitsOnlyError(value, propertyPath, modelToXmlResult);
				}
			}
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency currency = money.Currency;
			if (currency == null)
			{
				RecordMissingCurrencyError(propertyPath, modelToXmlResult);
			}
			else
			{
				if (!Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR.CodeValue.Equals(currency.CodeValue))
				{
					RecordCurrencyMustBeCadError(propertyPath, modelToXmlResult);
				}
			}
		}

		private void RecordTooManyDigitsAfterDecimalError(string value, string propertyPath, ModelToXmlResult result)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type MO.CAD" + " should have no more than "
				 + MAX_DIGITS_AFTER_DECIMAL + " digits after the decimal", propertyPath));
		}

		private void RecordTooManyDigitsBeforeDecimalError(string value, string propertyPath, ModelToXmlResult result)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value " + value + " of type MO.CAD" + " should have no more than "
				 + MAX_DIGITS_BEFORE_DECIMAL + " digits before the decimal", propertyPath));
		}

		private void RecordMustContainDigitsOnlyError(string value, string propertyPath, ModelToXmlResult result)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + value + "\" can only contain digits, with a maximum of "
				 + MAX_DIGITS_BEFORE_DECIMAL + " before the decimal and " + MAX_DIGITS_AFTER_DECIMAL + " after the decimal.", propertyPath
				));
		}

		private void RecordCurrencyMustBeCadError(string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"currency\" has been provided, but it must be CAD."
				, propertyPath));
		}

		private void RecordMissingCurrencyError(string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"currency\" is mandatory and must be specified."
				, propertyPath));
		}

		private void RecordMissingValueError(string propertyPath, ModelToXmlResult modelToXmlResult)
		{
			modelToXmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "The attribute \"value\" is mandatory and must be specified."
				, propertyPath));
		}
	}
}
