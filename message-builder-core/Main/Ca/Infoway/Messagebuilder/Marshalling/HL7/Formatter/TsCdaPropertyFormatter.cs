using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// TS (R2) - Timestamp
	/// Represents a TS object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// TS (R2) - Timestamp
	/// Represents a TS object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TSCDAR1", "SXCMTSCDAR1" })]
	public class TsCdaPropertyFormatter : PropertyFormatter
	{
		private readonly TsFullDateTimePropertyFormatter tsFormatter = new TsFullDateTimePropertyFormatter();

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
			return this.tsFormatter.Format(ConvertContext(formatContext), ConvertDataType(dataType), indentLevel);
		}

		private BareANY ConvertDataType(BareANY dataType)
		{
			object bareValue = dataType.BareValue;
			MbDate mbDate = (bareValue is MbDate ? (MbDate)bareValue : null);
			PlatformDate date = (mbDate == null ? null : mbDate.Value);
			ANYImpl<PlatformDate> result = new TSImpl();
			result.DataType = dataType.DataType;
			result.NullFlavor = dataType.NullFlavor;
			result.BareValue = date;
			result.Operator = ((ANYMetaData)dataType).Operator;
			return result;
		}

		private FormatContext ConvertContext(FormatContext formatContext)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl("TS", formatContext);
		}
	}
}
