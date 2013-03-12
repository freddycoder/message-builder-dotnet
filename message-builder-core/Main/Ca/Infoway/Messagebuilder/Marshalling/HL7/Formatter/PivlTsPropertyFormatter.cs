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
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("PIVL<TS>")]
	internal class PivlTsPropertyFormatter : AbstractNullFlavorPropertyFormatter<PeriodicIntervalTime>
	{
		private static readonly string FREQUENCY = "frequency";

		private static readonly string UNIT = "unit";

		private static readonly string VALUE = "value";

		private static readonly string PERIOD = "period";

		private static readonly string PHASE = "phase";

		private PropertyFormatter intNonNegPropertyFormatter = new IntNonNegPropertyFormatter();

		private PropertyFormatter ivlPqPropertyFormatter = new IvlPqPropertyFormatter();

		internal override string FormatNonNullValue(FormatContext context, PeriodicIntervalTime value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, GetAttributesMap(), indentLevel, false, true));
			AppendIntervalBounds(value, buffer, indentLevel + 1, context);
			buffer.Append(CreateElementClosure(context, indentLevel, true));
			return buffer.ToString();
		}

		// leave this as-is in case subclasses need to provide extra attributes (such as GTS.BOUNDEDPIVL)
		protected virtual IDictionary<string, string> GetAttributesMap()
		{
			return null;
		}

		private void AppendIntervalBounds(PeriodicIntervalTime value, StringBuilder buffer, int indentLevel, FormatContext context
			)
		{
			string period = CreatePeriodElement(value.Period, indentLevel, context);
			string phase = CreatePhaseElement(value.Phase, context.GetVersion(), context.GetPropertyPath(), indentLevel, context.GetModelToXmlResult
				());
			switch (value.Representation)
			{
				case Representation.PERIOD:
				{
					buffer.Append(period);
					break;
				}

				case Representation.PHASE:
				{
					buffer.Append(phase);
					break;
				}

				case Representation.PERIOD_PHASE:
				{
					buffer.Append(period);
					buffer.Append(phase);
					break;
				}

				case Representation.FREQUENCY:
				{
					// Change for Saskatchewan
					bool isSask = SpecificationVersion.IsExactVersion(SpecificationVersion.V01R04_2_SK, context != null ? context.GetVersion(
						) : null);
					if (isSask && value is PeriodicIntervalTimeSk)
					{
						buffer.Append(CreateFrequencyElementForSk(FREQUENCY, value.Repetitions, ((PeriodicIntervalTimeSk)value).QuantitySk, indentLevel
							, context));
					}
					else
					{
						buffer.Append(CreateFrequencyElement(value.Repetitions, value.Quantity, indentLevel, context));
					}
					break;
				}

				default:
				{
					break;
				}
			}
		}

		// removed "break" to correct c# translation
		private string CreateFrequencyElementForSk(string name, Int32? repetitions, Interval<PhysicalQuantity> quantity, int indentLevel
			, FormatContext context)
		{
			string result = string.Empty;
			if (repetitions != null && quantity != null)
			{
				StringBuilder buffer = new StringBuilder();
				buffer.Append(CreateElement(name, null, indentLevel, false, true));
				AppendSk(buffer, repetitions, quantity, indentLevel + 1, context);
				buffer.Append(XmlRenderingUtils.CreateEndElement(name, indentLevel, true));
				result = buffer.ToString();
			}
			else
			{
				CreateMissingFrequencyFieldsError(context);
			}
			return result;
		}

		private void AppendSk(StringBuilder buffer, Int32? repetitions, Interval<PhysicalQuantity> quantity, int indentLevel, FormatContext
			 context)
		{
			INTImpl intImpl = new INTImpl(repetitions);
			FormatContextImpl formatContext = new FormatContextImpl(context.GetModelToXmlResult(), context.GetPropertyPath(), "numerator"
				, "INT.NONNEG", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, context.IsSpecializationType(), context.GetVersion
				(), null, null, null);
			buffer.Append(this.intNonNegPropertyFormatter.Format(formatContext, intImpl, indentLevel));
			IVLImpl<PQ, Interval<PhysicalQuantity>> ivlImpl = new IVLImpl<PQ, Interval<PhysicalQuantity>>(quantity);
			formatContext = new FormatContextImpl(context.GetModelToXmlResult(), context.GetPropertyPath(), "denominator", "IVL<PQ.BASIC>"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, context.IsSpecializationType(), context.GetVersion(), null, 
				null, null);
			buffer.Append(this.ivlPqPropertyFormatter.Format(formatContext, ivlImpl, indentLevel));
		}

		/// <summary>This is the code that will be called for all current (CeRx, MR2007, MR2009) pan-Canadian standard usage of PIVL (PIVL to be exact)
		/// 	</summary>
		/// <param name="repetitions"></param>
		/// <param name="quantity"></param>
		/// <param name="indentLevel"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		private string CreateFrequencyElement(Int32? repetitions, PhysicalQuantity quantity, int indentLevel, FormatContext context
			)
		{
			string result = string.Empty;
			if (repetitions != null && quantity != null)
			{
				StringBuilder buffer = new StringBuilder();
				buffer.Append(CreateElement(FREQUENCY, null, indentLevel, false, true));
				FormatFrequency(buffer, repetitions, quantity, indentLevel + 1, context);
				buffer.Append(XmlRenderingUtils.CreateEndElement(FREQUENCY, indentLevel, true));
				result = buffer.ToString();
			}
			else
			{
				CreateMissingFrequencyFieldsError(context);
			}
			return result;
		}

		private void CreateMissingFrequencyFieldsError(FormatContext context)
		{
			context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Both repetitions and quantity must be non-null for values of type PIVL<TS.DATETIME>"
				, context.GetPropertyPath()));
		}

		private void FormatFrequency(StringBuilder buffer, Int32? repetitions, PhysicalQuantity quantity, int indentLevel, FormatContext
			 context)
		{
			FormatContext formatContext = new FormatContextImpl(context.GetModelToXmlResult(), context.GetPropertyPath(), "numerator"
				, "INT.NONNEG", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, context.IsSpecializationType(), context.GetVersion
				(), null, null, null);
			buffer.Append(this.intNonNegPropertyFormatter.Format(formatContext, new INTImpl(repetitions), indentLevel));
			IDictionary<string, string> tempAttributes = GetAttributes(new DateDiff(quantity), context);
			string value = tempAttributes.SafeGet(PqPropertyFormatter.ATTRIBUTE_VALUE);
			string units = tempAttributes.SafeGet(PqPropertyFormatter.ATTRIBUTE_UNIT);
			IDictionary<string, string> attributes = ToStringMap(VALUE, value, UNIT, units);
			context = new FormatContextImpl(context.GetModelToXmlResult(), context.GetPropertyPath(), "denominator", "PQ.TIME", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, context.IsSpecializationType(), context.GetVersion(), null, null, null);
			buffer.Append(CreateElement(context, attributes, indentLevel, true, true));
		}

		private string CreatePeriodElement(DateDiff period, int indentLevel, FormatContext context)
		{
			if (period != null)
			{
				IDictionary<string, string> tempAttributes = GetAttributes(period, context);
				string value = tempAttributes.SafeGet(PqPropertyFormatter.ATTRIBUTE_VALUE);
				string units = tempAttributes.SafeGet(PqPropertyFormatter.ATTRIBUTE_UNIT);
				IDictionary<string, string> attributes = ToStringMap(VALUE, value, UNIT, units);
				return CreateElement(PERIOD, attributes, indentLevel, true, true);
			}
			return string.Empty;
		}

		private string CreatePhaseElement(Interval<PlatformDate> phase, VersionNumber version, string propertyPath, int indentLevel
			, ModelToXmlResult result)
		{
			if (phase != null)
			{
				return new IvlTsPropertyFormatter().Format(new FormatContextImpl(result, propertyPath, PHASE, "IVL<TS.FULLDATE>", null, false
					, version, null, null, null), new IVLImpl<TS, Interval<PlatformDate>>(phase), indentLevel);
			}
			return string.Empty;
		}

		private IDictionary<string, string> GetAttributes(DateDiff period, FormatContext context)
		{
			PhysicalQuantity quantity = period.ValueAsPhysicalQuantity;
			FormatContext newContext = new FormatContextImpl("PQ.TIME", context);
			// getAttributeNameValuePairs is never called with a null value; directly calling it from here is a bit of a cheat, so ensure no null passed in
			return quantity == null ? new Dictionary<string, string>() : new PqPropertyFormatter().GetAttributeNameValuePairs(newContext
				, quantity, null);
		}
	}
}
