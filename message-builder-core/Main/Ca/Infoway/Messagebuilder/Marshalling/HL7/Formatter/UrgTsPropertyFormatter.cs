using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("URG<TS>")]
	internal class UrgTsPropertyFormatter : AbstractNullFlavorPropertyFormatter<UncertainRange<PlatformDate>>
	{
		internal IvlTsPropertyFormatter formatter = new IvlTsPropertyFormatter();

		protected override string FormatNonNullValue(FormatContext context, UncertainRange<PlatformDate> value, int indentLevel)
		{
			// convert URG to an IVL and use IVL formatter
			Interval<PlatformDate> convertedInterval = IntervalFactory.CreateFromUncertainRange(value);
			IVLImpl<TS, Interval<PlatformDate>> convertedHl7Interval = new IVLImpl<TS, Interval<PlatformDate>>(convertedInterval);
			FormatContext ivlContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(context.Type.Replace
				("URG", "IVL"), context.IsSpecializationType(), context);
			string xml = this.formatter.Format(ivlContext, convertedHl7Interval, indentLevel);
			xml = ChangeAnyIvlRemnants(xml);
			// inclusive attributes not allowed for URG<TS>
			if (value.LowInclusive != null || value.HighInclusive != null)
			{
				context.GetModelToXmlResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "High/Low inclusive fields should not be set; these attributes are not allowed for "
					 + context.Type + " types", context.GetPropertyPath()));
			}
			return xml;
		}

		private string ChangeAnyIvlRemnants(string xml)
		{
			xml = xml.Replace(" specializationType=\"IVL_", " specializationType=\"URG_");
			return xml.Replace(" xsi:type=\"IVL_", " xsi:type=\"URG_");
		}
	}
}
