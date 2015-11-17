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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>
	/// RTO&lt;PQ, PQ&gt; - Ratio R2 (physical quantity, physical quantity)
	/// Represents a Ratio of physical quantities as an element:
	/// &lt;unitQuanity&gt;
	/// &lt;numerator value="1.0" xsi:type="PQ"/&gt;
	/// &lt;denominator value="64.0" xsi:type="/&gt;
	/// &lt;/unitQuanity&gt;
	/// </summary>
	[DataTypeHandler("RTO<MO,PQ>")]
	public class RtoMoPqR2PropertyFormatter : AbstractRtoR2PropertyFormatter<Money, PhysicalQuantity>
	{
		private PqR2PropertyFormatter pqFormatter = new PqR2PropertyFormatter();

		private MoR2PropertyFormatter moFormatter = new MoR2PropertyFormatter();

		protected override string FormatNumerator(FormatContext context, Money numerator, int indentLevel)
		{
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("MO", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, Cardinality.Create("0-1"), "numerator", context);
			return this.moFormatter.Format(newContext, new MOImpl(numerator), indentLevel);
		}

		protected override string FormatDenominator(FormatContext context, PhysicalQuantity denominator, int indentLevel)
		{
			if (denominator != null && BigDecimal.ZERO.Equals(denominator.Quantity))
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Denominator cannot be zero for RTO types."
					, context.GetPropertyPath()));
			}
			FormatContext newContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("PQ", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, Cardinality.Create("0-1"), "denominator", context);
			return this.pqFormatter.Format(newContext, new PQImpl(denominator), indentLevel);
		}
	}
}
