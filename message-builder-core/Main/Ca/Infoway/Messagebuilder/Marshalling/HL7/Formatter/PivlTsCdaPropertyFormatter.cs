using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("PIVLTSCDAR1")]
	internal class PivlTsCdaPropertyFormatter : PropertyFormatter
	{
		private PivlTsPropertyFormatter r1Formatter = new PivlTsPropertyFormatter();

		public virtual string Format(FormatContext formatContext, BareANY dataType)
		{
			return Format(formatContext, dataType, 0);
		}

		public virtual string Format(FormatContext formatContext, BareANY dataType, int indentLevel)
		{
			if (dataType == null)
			{
				return string.Empty;
			}
			FormatContext newFormatContext = ConvertContext(formatContext);
			BareANY newDataType = ConvertDataType(dataType);
			return this.r1Formatter.Format(newFormatContext, newDataType, indentLevel);
		}

		private BareANY ConvertDataType(BareANY dataType)
		{
			object bareValue = dataType.BareValue;
			PeriodicIntervalTimeR2 pivlR2 = (bareValue is PeriodicIntervalTimeR2 ? (PeriodicIntervalTimeR2)bareValue : null);
			PeriodicIntervalTime pivlR1 = (pivlR2 == null ? null : ConvertPivl(pivlR2));
			BareANY result = new PIVLImpl();
			result.DataType = dataType.DataType;
			result.BareValue = pivlR1;
			result.NullFlavor = dataType.NullFlavor;
			return result;
		}

		private PeriodicIntervalTime ConvertPivl(PeriodicIntervalTimeR2 pivlR2)
		{
			return PeriodicIntervalTime.CreateFromPivlR2(pivlR2);
		}

		private FormatContext ConvertContext(FormatContext formatContext)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("PIVL<TS>", formatContext);
		}
	}
}
