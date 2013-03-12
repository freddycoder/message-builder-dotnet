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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
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

		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, PhysicalQuantity physicalQuantity
			, BareANY bareANY)
		{
			ValidatePhysicalQuantity(context, physicalQuantity);
			return CreatePhysicalQuantityAttributes(physicalQuantity);
		}

		private void ValidatePhysicalQuantity(FormatContext context, PhysicalQuantity physicalQuantity)
		{
			string type = context.Type;
			ModelToXmlResult errors = context.GetModelToXmlResult();
			string quantityAsString = physicalQuantity.Quantity == null ? null : physicalQuantity.Quantity.ToPlainString();
			this.pqValidationUtils.ValidateValue(quantityAsString, context.GetVersion(), type, null, context.GetPropertyPath(), errors
				);
			string unitsAsString = (physicalQuantity.Unit == null ? null : physicalQuantity.Unit.CodeValue);
			this.pqValidationUtils.ValidateUnits(type, unitsAsString, null, context.GetPropertyPath(), errors);
		}

		private IDictionary<string, string> CreatePhysicalQuantityAttributes(PhysicalQuantity physicalQuantity)
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

		private string FormatQuantity(BigDecimal quantity)
		{
			// Redmine 1570 - don't change value even if incorrect; just call toString on it
			return quantity.ToPlainString();
		}
	}
}
