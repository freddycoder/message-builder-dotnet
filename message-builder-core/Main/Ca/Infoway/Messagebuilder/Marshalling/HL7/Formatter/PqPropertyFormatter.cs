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
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// PQ - Physical Quantity
	/// Represents a Physical Quantity object as an element:
	/// &lt;element-name value="123.33" unit="mg"/&gt;
	/// </summary>
	[DataTypeHandler("PQ")]
	public class PqPropertyFormatter : AbstractAttributePropertyFormatter<PhysicalQuantity>
	{
		public static readonly string ATTRIBUTE_UNIT = "unit";

		public static readonly string ATTRIBUTE_VALUE = "value";

		private readonly PqValidationUtils pqValidationUtils = new PqValidationUtils();

		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, PhysicalQuantity physicalQuantity
			, BareANY bareANY)
		{
			ValidatePhysicalQuantity(context, physicalQuantity, bareANY);
			return CreatePhysicalQuantityAttributes(physicalQuantity, bareANY);
		}

		//.NET conversion. Create a public method for PivlTsPropertyFormatter and unit tests 
		public virtual IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, PhysicalQuantity physicalQuantity
			)
		{
			return GetAttributeNameValuePairs(context, physicalQuantity, null);
		}

		private void ValidatePhysicalQuantity(FormatContext context, PhysicalQuantity physicalQuantity, BareANY bareANY)
		{
			// does not validate originalText here as this section is bypassed when value is a NullFlavor
			string type = context.Type;
			ModelToXmlResult errors = context.GetModelToXmlResult();
			bool hasNullFlavor = (bareANY == null || bareANY.NullFlavor != null);
			string quantityAsString = physicalQuantity.Quantity == null ? null : physicalQuantity.Quantity.ToPlainString();
			this.pqValidationUtils.ValidateValue(quantityAsString, context.GetVersion(), type, hasNullFlavor, null, context.GetPropertyPath
				(), errors);
			string unitsAsString = (physicalQuantity.Unit == null ? null : physicalQuantity.Unit.CodeValue);
			this.pqValidationUtils.ValidateUnits(type, unitsAsString, null, context.GetPropertyPath(), errors, false);
		}

		private IDictionary<string, string> CreatePhysicalQuantityAttributes(PhysicalQuantity physicalQuantity, BareANY bareANY)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (physicalQuantity.Quantity == null)
			{
				result[AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME] = AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION;
			}
			else
			{
				result[ATTRIBUTE_VALUE] = FormatQuantity(physicalQuantity.Quantity);
			}
			// if unit is null, then this is considered an "each"
			if (physicalQuantity.Unit != null)
			{
				result[ATTRIBUTE_UNIT] = physicalQuantity.Unit.CodeValue;
			}
			return result;
		}

		public override string Format(FormatContext context, BareANY hl7Value, int indentLevel)
		{
			string result = base.Format(context, hl7Value, indentLevel);
			if (hl7Value != null)
			{
				string originalText = ((ANYMetaData)hl7Value).OriginalText;
				bool hasNullFlavor = hl7Value.HasNullFlavor();
				bool hasAnyValues = HasAnyValues(hl7Value);
				this.pqValidationUtils.ValidateOriginalText(context.Type, originalText, hasAnyValues, hasNullFlavor, context.GetVersion()
					, null, context.GetPropertyPath(), context.GetModelToXmlResult());
				// complete hack for BC
				if (SpecificationVersion.IsExactVersion(context.GetVersion(), SpecificationVersion.V02R04_BC))
				{
					if (hasNullFlavor && HasAnyValues(hl7Value))
					{
						// dump the result and rebuild, adding in NF
						IDictionary<string, string> attributeNameValuePairs = GetAttributeNameValuePairs(context, (PhysicalQuantity)hl7Value.BareValue
							, hl7Value);
						attributeNameValuePairs.PutAll(CreateNullFlavorAttributes(hl7Value.NullFlavor));
						result = CreateElement(context, attributeNameValuePairs, indentLevel, true, true);
					}
				}
				if (StringUtils.IsNotBlank(originalText))
				{
					string otElement = CreateElement("originalText", null, indentLevel + 1, false, false);
					otElement += XmlStringEscape.Escape(originalText);
					otElement += CreateElementClosure("originalText", 0, true);
					// pulling off the end "/>" is not the most elegant solution, but superclass would need significant refactoring otherwise
					result = Ca.Infoway.Messagebuilder.StringUtils.Substring(result, 0, result.IndexOf("/>")) + ">" + SystemUtils.LINE_SEPARATOR
						 + otElement + CreateElementClosure(context.GetElementName(), indentLevel, true);
				}
			}
			return result;
		}

		private bool HasAnyValues(BareANY hl7Value)
		{
			bool result = false;
			if (hl7Value != null && hl7Value.BareValue != null && hl7Value.BareValue is PhysicalQuantity)
			{
				PhysicalQuantity pq = (PhysicalQuantity)hl7Value.BareValue;
				result = (pq.Quantity != null || pq.Unit != null);
			}
			return result;
		}

		private string FormatQuantity(BigDecimal quantity)
		{
			// Redmine 1570 - don't change value even if incorrect; just call toString on it
			return quantity.ToPlainString();
		}
	}
}
