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
	[DataTypeHandler("PIVL<TS>")]
	public class PivlTsR2PropertyFormatter : AbstractNullFlavorPropertyFormatter<PeriodicIntervalTimeR2>
	{
		private static readonly string PHASE = "phase";

		private static readonly string PERIOD = "period";

		private static readonly string ALIGNMENT = "alignment";

		private static readonly string INSTITUTION_SPECIFIED = "institutionSpecified";

		private IvlTsR2PropertyFormatter ivlTsFormatter = new IvlTsR2PropertyFormatter();

		private PqR2PropertyFormatter pqFormatter = new PqR2PropertyFormatter();

		protected override string FormatNonNullValue(FormatContext context, PeriodicIntervalTimeR2 value, int indentLevel)
		{
			// create alignment and institutionSpecified attributes
			IDictionary<string, string> attributesMap = GetAttributesMap(value);
			// create phase (IVL<TS>
			string phase = value.Phase != null ? CreatePhase(value, context, indentLevel + 1) : string.Empty;
			// create period (PQ)
			string period = value.Period != null ? CreatePeriod(value, context, indentLevel + 1) : string.Empty;
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, attributesMap, indentLevel, false, true));
			buffer.Append(phase);
			buffer.Append(period);
			buffer.Append(CreateElementClosure(context, indentLevel, true));
			return buffer.ToString();
		}

		protected virtual IDictionary<string, string> GetAttributesMap(PeriodicIntervalTimeR2 value)
		{
			IDictionary<string, string> attributesMap = new Dictionary<string, string>();
			if (value.Alignment != null)
			{
				attributesMap[ALIGNMENT] = value.Alignment.CalendarCycleCode;
			}
			if (value.InstitutionSpecified != null)
			{
				attributesMap[INSTITUTION_SPECIFIED] = value.InstitutionSpecified.ToString().ToLower();
			}
			return attributesMap;
		}

		private string CreatePhase(PeriodicIntervalTimeR2 value, FormatContext context, int indentLevel)
		{
			Interval<PlatformDate> phase = value.Phase;
			IVL_TS phaseWrapper = new IVL_TSImpl(phase == null ? null : new DateInterval(phase));
			FormatContext phaseContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("IVL<TS>", PHASE, 
				context);
			return this.ivlTsFormatter.Format(phaseContext, phaseWrapper, indentLevel);
		}

		private string CreatePeriod(PeriodicIntervalTimeR2 value, FormatContext context, int indentLevel)
		{
			PhysicalQuantity period = value.Period;
			FormatContext periodContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("PQ", PERIOD, context
				);
			PQ periodWrapper = new PQImpl(period);
			return this.pqFormatter.Format(periodContext, periodWrapper, indentLevel);
		}
	}
}
