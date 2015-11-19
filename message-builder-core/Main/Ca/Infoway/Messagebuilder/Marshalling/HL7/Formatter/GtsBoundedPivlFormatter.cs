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
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("GTS.BOUNDEDPIVL")]
	internal class GtsBoundedPivlFormatter : AbstractNullFlavorPropertyFormatter<GeneralTimingSpecification>
	{
		public static readonly string GTS_BOUNDED_PIVL = "GTS.BOUNDEDPIVL";

		protected override string FormatNonNullValue(FormatContext context, GeneralTimingSpecification value, int indentLevel)
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
			// add specializationType manually; do not use AbstractPropertyFormatter.addSpecializationType() here, as the xsi:type is non-standard
			if (RequiresSpecializationType(context))
			{
				attributes[AbstractPropertyFormatter.SPECIALIZATION_TYPE] = GTS_BOUNDED_PIVL;
			}
			// the datatype specifications show that xsi:type is always present, but specializationType is not included for CeRx (which may be incorrect, but we'll follow the specs until we hear otherwise)
			attributes[AbstractPropertyFormatter.XSI_TYPE] = "SXPR_TS";
			return attributes;
		}

		private void AppendValues(StringBuilder buffer, GeneralTimingSpecification value, int indentLevel, FormatContext context)
		{
			Interval<PlatformDate> duration = value.Duration;
			IVL<TS, Interval<PlatformDate>> ivlDuration = new IVLImpl<TS, Interval<PlatformDate>>(duration);
			IvlTsPropertyFormatter formatter = new GtsBoundedPivlFormatter.CustomIvlTsPropertyFormatter(RequiresOperatorOnFirstRepetition
				(context), RequiresSpecializationType(context));
			PeriodicIntervalTime frequency = value.Frequency;
			buffer.Append(formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("IVL<TS.FULLDATE>"
				, RequiresSpecializationType(context), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1")
				, "comp", context), ivlDuration, indentLevel + 1));
			// constraints not passed down 
			buffer.Append(CreatePivlTsElement(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("PIVL<TS.DATETIME>"
				, RequiresSpecializationType(context), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1")
				, "comp", context), frequency, indentLevel + 1));
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
				result = !SpecificationVersion.IsVersion(StandardDataType.GTS_BOUNDEDPIVL, formatContext.GetVersion(), Hl7BaseVersion.CERX
					);
			}
			return result;
		}

		private bool RequiresOperatorOnFirstRepetition(FormatContext formatContext)
		{
			bool result = false;
			if (formatContext != null && formatContext.GetVersion() != null)
			{
				result = SpecificationVersion.IsVersion(StandardDataType.GTS_BOUNDEDPIVL, formatContext.GetVersion(), Hl7BaseVersion.CERX
					) || SpecificationVersion.IsVersion(StandardDataType.GTS_BOUNDEDPIVL, formatContext.GetVersion(), Hl7BaseVersion.MR2007);
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
					attributes[AbstractPropertyFormatter.XSI_TYPE] = "PIVL_TS";
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
						attributes[AbstractPropertyFormatter.XSI_TYPE] = "IVL_TS";
					}
				}
				return base.CreateElement(name, attributes, indentLevel, close, lineBreak);
			}
		}
	}
}
