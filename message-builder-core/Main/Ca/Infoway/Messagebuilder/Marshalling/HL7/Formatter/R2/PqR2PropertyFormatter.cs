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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// PQ - Physical Quantity (R2)
	/// Represents a Physical Quantity object as an element:
	/// &lt;element-name value="123.33" unit="mg"/&gt;
	/// </summary>
	[DataTypeHandler(new string[] { "PQ", "SXCM<PQ>" })]
	public class PqR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<PhysicalQuantity>
	{
		public static readonly string ATTRIBUTE_UNIT = "unit";

		public static readonly string ATTRIBUTE_VALUE = "value";

		private readonly PqValidationUtils pqValidationUtils = new PqValidationUtils();

		private readonly SxcmR2PropertyFormatterHelper sxcmHelper = new SxcmR2PropertyFormatterHelper();

		private readonly PqrR2PropertyFormatter pqrPropertyFormatter = new PqrR2PropertyFormatter();

		protected override string FormatNonNullDataType(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			PhysicalQuantity pq = ExtractBareValue(hl7Value);
			StringBuilder result = new StringBuilder();
			IDictionary<string, string> attributes = GetAttributeNameValuePairs(context, pq, hl7Value);
			bool hasChildContent = !pq.Translation.IsEmpty();
			result.Append(CreateElement(context, attributes, indentLevel, !hasChildContent, true));
			if (hasChildContent)
			{
				CreateChildContent(pq, context, indentLevel + 1, result);
				result.Append(CreateElementClosure(context, indentLevel, true));
			}
			return result.ToString();
		}

		private void CreateChildContent(PhysicalQuantity pq, FormatContext context, int indentLevel, StringBuilder result)
		{
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("PQR", "translation"
				, context);
			foreach (CodedTypeR2<Code> translation in pq.Translation)
			{
				string formattedTranslation = this.pqrPropertyFormatter.Format(newContext, new PQRImpl<Code>(translation), indentLevel);
				result.Append(formattedTranslation);
			}
		}

		protected override string FormatNonNullValue(FormatContext context, PhysicalQuantity pq, int indentLevel)
		{
			throw new NotSupportedException("Call formatNonNullDataType() instead.");
		}

		protected virtual IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, PhysicalQuantity physicalQuantity
			, BareANY bareANY)
		{
			ValidatePhysicalQuantity(physicalQuantity, bareANY, context);
			return CreatePhysicalQuantityAttributes(physicalQuantity, bareANY, context);
		}

		private void ValidatePhysicalQuantity(PhysicalQuantity physicalQuantity, BareANY bareANY, FormatContext context)
		{
			string type = context.Type;
			ModelToXmlResult errors = context.GetModelToXmlResult();
			// nothing to validate for value, based on R2 schema 
			string unitsAsString = (physicalQuantity.Unit == null ? null : physicalQuantity.Unit.CodeValue);
			this.pqValidationUtils.ValidateUnits(type, unitsAsString, null, context.GetPropertyPath(), errors, true);
		}

		private IDictionary<string, string> CreatePhysicalQuantityAttributes(PhysicalQuantity physicalQuantity, BareANY bareAny, 
			FormatContext context)
		{
			// according to the schema, nullFlavor, value, and unit are all optional (though unit does have a default of "1")
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			if (physicalQuantity.Quantity != null)
			{
				attributes[ATTRIBUTE_VALUE] = FormatQuantity(physicalQuantity.Quantity);
			}
			// if unit is null, then this is considered an "each"
			if (physicalQuantity.Unit != null)
			{
				attributes[ATTRIBUTE_UNIT] = physicalQuantity.Unit.CodeValue;
			}
			this.sxcmHelper.HandleOperator(attributes, context, (ANYMetaData)bareAny);
			return attributes;
		}

		private string FormatQuantity(BigDecimal quantity)
		{
			// Redmine 1570 - don't change value even if incorrect; just call toString on it
			return quantity.ToPlainString();
		}
	}
}
