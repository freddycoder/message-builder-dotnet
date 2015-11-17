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
using System.Text;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	public abstract class AbstractRtoR2PropertyFormatter<T, U> : AbstractNullFlavorPropertyFormatter<BareRatio>
	{
		protected override string FormatNonNullValue(FormatContext context, BareRatio value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, null, indentLevel, false, true));
			T bareNumerator = (T)value.BareNumerator;
			U bareDenominator = (U)value.BareDenominator;
			if (bareNumerator == null || bareDenominator == null)
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Numerator and denominator must be non-null; both are mandatory for RTO types."
					, context.GetPropertyPath()));
			}
			buffer.Append(FormatNumerator(context, bareNumerator, indentLevel + 1));
			buffer.Append(FormatDenominator(context, bareDenominator, indentLevel + 1));
			buffer.Append(CreateElementClosure(context.GetElementName(), indentLevel, true));
			return buffer.ToString();
		}

		protected abstract string FormatNumerator(FormatContext context, T numerator, int indentLevel);

		protected abstract string FormatDenominator(FormatContext context, U denominator, int indentLevel);
	}
}
