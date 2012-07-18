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

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
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

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private void AppendValues(StringBuilder buffer, GeneralTimingSpecification value, int indentLevel, FormatContext context)
		{
			Interval<PlatformDate> duration = value.Duration;
			IVL<TS, Interval<PlatformDate>> ivlDuration = new IVLImpl<TS, Interval<PlatformDate>>(duration);
			IvlTsPropertyFormatter formatter = new GtsBoundedPivlFormatter.CustomIvlTsPropertyFormatter(RequiresOperatorOnFirstRepetition
				(context), RequiresSpecializationType(context));
			PeriodicIntervalTime frequency = value.Frequency;
			buffer.Append(formatter.Format(new FormatContextImpl("comp", "IVL<TS.FULLDATE>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, RequiresSpecializationType(context), context == null ? null : context.GetVersion(), context == null ? null : 
				context.GetDateTimeZone(), null, false), ivlDuration, indentLevel + 1));
			buffer.Append(CreateElement(new FormatContextImpl("comp", "PIVL<TS.DATETIME>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, RequiresSpecializationType(context), context == null ? null : context.GetVersion(), null, context == null ? 
				null : context.GetDateTimeTimeZone()), frequency, indentLevel + 1));
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual string CreateElement(FormatContext context, PeriodicIntervalTime value, int indentLevel)
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
				result = !SpecificationVersion.IsVersion(SpecificationVersion.V01R04_3, formatContext.GetVersion());
			}
			return result;
		}

		private bool RequiresOperatorOnFirstRepetition(FormatContext formatContext)
		{
			bool result = false;
			if (formatContext != null && formatContext.GetVersion() != null)
			{
				result = SpecificationVersion.IsVersion(SpecificationVersion.V01R04_3, formatContext.GetVersion()) || SpecificationVersion
					.IsVersion(SpecificationVersion.V02R01, formatContext.GetVersion()) || SpecificationVersion.IsVersion(SpecificationVersion
					.V02R02, formatContext.GetVersion());
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
