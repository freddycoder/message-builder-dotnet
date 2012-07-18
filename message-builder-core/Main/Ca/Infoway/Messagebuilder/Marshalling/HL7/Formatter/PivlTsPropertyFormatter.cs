using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("PIVL<TS>")]
	internal class PivlTsPropertyFormatter : AbstractPivlPropertyFormatter
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override string Format(DateDiff period)
		{
			IDictionary<string, string> attributes = GetAttributes(period);
			return attributes.SafeGet(PqPropertyFormatter.ATTRIBUTE_VALUE);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected override string GetUnits(DateDiff period)
		{
			IDictionary<string, string> attributes = GetAttributes(period);
			return attributes.SafeGet(PqPropertyFormatter.ATTRIBUTE_UNIT);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private IDictionary<string, string> GetAttributes(DateDiff period)
		{
			PhysicalQuantity quantity = period.ValueAsPhysicalQuantity;
			return new PqPropertyFormatter().GetAttributeNameValuePairs((FormatContext)null, quantity);
		}
	}
}
