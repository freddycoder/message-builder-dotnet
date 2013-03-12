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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("GTS.BOUNDEDPIVL")]
	internal class GtsBoundedPivlFormatter : AbstractNullFlavorPropertyFormatter<GeneralTimingSpecification>
	{
		public static readonly string GTS_BOUNDED_PIVL = "GTS.BOUNDEDPIVL";

		internal override string FormatNonNullValue(FormatContext context, GeneralTimingSpecification value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			buffer.Append(CreateElement(context, CreateTypeAttributes(context), indentLevel, false, true));
			AppendValues(buffer, value, indentLevel, context);
			buffer.Append(CreateElementClosure(context, indentLevel, true));
			return buffer.ToString();
		}

		private IDictionary<string, string> CreateTypeAttributes(FormatContext context)
		{
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			if (RequiresSpecializationType(context))
			{
				attributes["specializationType"] = GTS_BOUNDED_PIVL;
			}
			attributes["xsi:type"] = "SXPR_TS";
			return attributes;
		}

		private void AppendValues(StringBuilder buffer, GeneralTimingSpecification value, int indentLevel, FormatContext context)
		{
			Interval<PlatformDate> duration = value.Duration;
			IVL<TS, Interval<PlatformDate>> ivlDuration = new IVLImpl<TS, Interval<PlatformDate>>(duration);
			IvlTsPropertyFormatter formatter = new GtsBoundedPivlFormatter.CustomIvlTsPropertyFormatter(RequiresOperatorOnFirstRepetition
				(context), RequiresSpecializationType(context));
			PeriodicIntervalTime frequency = value.Frequency;
			buffer.Append(formatter.Format(new FormatContextImpl(context == null ? null : context.GetModelToXmlResult(), context == null
				 ? null : context.GetPropertyPath(), "comp", "IVL<TS.FULLDATE>", context == null ? null : context.GetDomainType(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, RequiresSpecializationType(context), context == null ? null : context.GetVersion(), context == null ? null : 
				context.GetDateTimeZone(), null, false, null), ivlDuration, indentLevel + 1));
			buffer.Append(CreatePivlTsElement(new FormatContextImpl(context == null ? null : context.GetModelToXmlResult(), context ==
				 null ? null : context.GetPropertyPath(), "comp", "PIVL<TS.DATETIME>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY
				, RequiresSpecializationType(context), context == null ? null : context.GetVersion(), null, context == null ? null : context
				.GetDateTimeTimeZone(), null), frequency, indentLevel + 1));
		}

		protected virtual string CreatePivlTsElement(FormatContext context, PeriodicIntervalTime value, int indentLevel)
		{
			PivlTsPropertyFormatter formatter = new GtsBoundedPivlFormatter.CustomPivlTsPropertyFormatter(!RequiresOperatorOnFirstRepetition
				(context), RequiresSpecializationType(context));
			return formatter.Format(context, new PIVLImpl(value), indentLevel);
		}

		private bool RequiresSpecializationType(FormatContext formatContext)
		{
			bool result = true;
			if (formatContext != null && formatContext.GetVersion() != null)
			{
				result = !SpecificationVersion.IsVersion(formatContext.GetVersion(), Hl7BaseVersion.CERX);
			}
			return result;
		}

		private bool RequiresOperatorOnFirstRepetition(FormatContext formatContext)
		{
			bool result = false;
			if (formatContext != null && formatContext.GetVersion() != null)
			{
				result = SpecificationVersion.IsVersion(formatContext.GetVersion(), Hl7BaseVersion.CERX) || SpecificationVersion.IsVersion
					(formatContext.GetVersion(), Hl7BaseVersion.MR2007_V02R01) || SpecificationVersion.IsVersion(formatContext.GetVersion(), 
					Hl7BaseVersion.MR2007);
			}
			return result;
		}

		private class CustomPivlTsPropertyFormatter : PivlTsPropertyFormatter
		{
			private readonly bool requiresOperator;

			private readonly bool requiresSpecializationType;

			public CustomPivlTsPropertyFormatter(bool requiresOperator, bool requiresSpecializationType)
			{
				this.requiresOperator = requiresOperator;
				this.requiresSpecializationType = requiresSpecializationType;
			}

			protected override IDictionary<string, string> GetAttributesMap()
			{
				return this.requiresOperator ? ToStringMap("operator", "I") : base.GetAttributesMap();
			}

			protected override string CreateElement(string name, IDictionary<string, string> attributes, int indentLevel, bool close, 
				bool lineBreak)
			{
				if ("comp".Equals(name) && !this.requiresSpecializationType && attributes != null)
				{
					attributes["xsi:type"] = "PIVL_TS";
				}
				return base.CreateElement(name, attributes, indentLevel, close, lineBreak);
			}
		}

		private class CustomIvlTsPropertyFormatter : IvlTsPropertyFormatter
		{
			private readonly bool requiresOperator;

			private readonly bool requiresSpecializationType;

			public CustomIvlTsPropertyFormatter(bool requiresOperator, bool requiresSpecializationType)
			{
				this.requiresOperator = requiresOperator;
				this.requiresSpecializationType = requiresSpecializationType;
			}

			protected override string CreateElement(string name, IDictionary<string, string> attributes, int indentLevel, bool close, 
				bool lineBreak)
			{
				if ("comp".Equals(name))
				{
					if (!IsNullFlavor(attributes) && this.requiresOperator)
					{
						if (attributes == null)
						{
							attributes = new Dictionary<string, string>();
						}
						attributes["operator"] = "I";
					}
					if (!this.requiresSpecializationType && attributes != null)
					{
						attributes["xsi:type"] = "IVL_TS";
					}
				}
				return base.CreateElement(name, attributes, indentLevel, close, lineBreak);
			}
		}
	}
}
