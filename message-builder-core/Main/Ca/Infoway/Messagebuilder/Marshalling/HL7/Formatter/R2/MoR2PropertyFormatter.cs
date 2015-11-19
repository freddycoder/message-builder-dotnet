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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// MO - Money (R2)
	/// Represents an MO object as an element:
	/// &lt;amt value="10" currency="CAD"/&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-MO
	/// </summary>
	[DataTypeHandler(new string[] { "MO", "SXCM<MO>" })]
	internal class MoR2PropertyFormatter : AbstractAttributePropertyFormatter<Money>
	{
		private readonly SxcmR2PropertyFormatterHelper sxcmHelper = new SxcmR2PropertyFormatterHelper();

		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Money money, BareANY bareAny
			)
		{
			Validate(money, context);
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			BigDecimal value = money.Amount;
			if (value != null)
			{
				attributes["value"] = value.ToString();
			}
			Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency currency = money.Currency;
			if (currency != null)
			{
				attributes["currency"] = currency.CodeValue;
			}
			this.sxcmHelper.HandleOperator(attributes, context, (ANYMetaData)bareAny);
			return attributes;
		}

		private void Validate(Money money, FormatContext context)
		{
			// nothing much to validate for R2 version of datatype
			ModelToXmlResult modelToXmlResult = context.GetModelToXmlResult();
			string propertyPath = context.GetPropertyPath();
			BigDecimal amount = money.Amount;
			if (amount != null)
			{
				string value = amount.ToString();
				string integerPart = value.Contains(".") ? StringUtils.SubstringBefore(value, ".") : value;
				string decimalPart = value.Contains(".") ? StringUtils.SubstringAfter(value, ".") : string.Empty;
				if (!StringUtils.IsNumeric(integerPart) || !StringUtils.IsNumeric(decimalPart))
				{
					RecordMustContainDigitsOnlyError(value, propertyPath, modelToXmlResult);
				}
			}
		}

		private void RecordMustContainDigitsOnlyError(string value, string propertyPath, ModelToXmlResult result)
		{
			result.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Value \"" + value + "\" can only contain digits.", propertyPath
				));
		}
	}
}
