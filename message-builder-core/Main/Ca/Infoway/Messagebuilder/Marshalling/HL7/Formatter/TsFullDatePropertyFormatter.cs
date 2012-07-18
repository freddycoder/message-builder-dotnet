using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// TS.FULLDATE - Timestamp (fully-specified date only)
	/// Represents a TS.FULLDATE object as an element:
	/// &lt;element-name value="yyyyMMdd"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// TS.FULLDATE - Timestamp (fully-specified date only)
	/// Represents a TS.FULLDATE object as an element:
	/// &lt;element-name value="yyyyMMdd"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TS.FULLDATE", "TS.DATE" })]
	public class TsFullDatePropertyFormatter : AbstractValueNullFlavorPropertyFormatter<PlatformDate>
	{
		private static readonly string DATE_FORMAT_YYYYMMDD = "yyyyMMdd";

		protected override string GetValue(PlatformDate date, FormatContext context)
		{
			TimeZone timeZone = context != null && context.GetDateTimeZone() != null ? context.GetDateTimeZone() : System.TimeZone.CurrentTimeZone;
			return DateFormatUtil.Format(date, DATE_FORMAT_YYYYMMDD, timeZone);
		}
	}
}
