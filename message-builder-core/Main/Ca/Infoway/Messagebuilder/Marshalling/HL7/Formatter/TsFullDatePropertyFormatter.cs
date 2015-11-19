using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using ILOG.J2CsMapping.Text;

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

		protected override string GetValue(PlatformDate date, FormatContext context, BareANY bareAny)
		{
			TimeZoneInfo timeZone = context != null && context.GetDateTimeZone() != null ? context.GetDateTimeZone() : System.TimeZoneInfo.Local;
			string datePattern = DetermineDatePattern(date);
			ValidateDatePattern(datePattern, context);
			return DateFormatUtil.Format(date, datePattern, timeZone);
		}

		private string DetermineDatePattern(PlatformDate date)
		{
			string datePattern = GetPatternFromDateWithPattern(date);
			if (datePattern == null)
			{
				datePattern = DATE_FORMAT_YYYYMMDD;
			}
			return datePattern;
		}

		private void ValidateDatePattern(string datePattern, FormatContext context)
		{
			StandardDataType standardDataType = StandardDataType.GetByTypeName(context);
			VersionNumber version = (context == null ? null : context.GetVersion());
			string[] allowedDateFormats = TsDateFormats.GetAllDateFormats(standardDataType, version);
			if (!ArrayContains(allowedDateFormats, datePattern))
			{
				Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Invalid date format {0} supplied for value of type {1}"
					, datePattern, context == null ? "TS" : context.Type), context.GetPropertyPath());
				context.GetModelToXmlResult().AddHl7Error(hl7Error);
			}
		}

		private bool ArrayContains(string[] allowedDateFormats, string datePattern)
		{
			for (int i = 0; i < allowedDateFormats.Length; i++)
			{
				if (allowedDateFormats[i].Equals(datePattern))
				{
					return true;
				}
			}
			return false;
		}

		private string GetPatternFromDateWithPattern(PlatformDate date)
		{
			if (date is DateWithPattern)
			{
				return ((DateWithPattern)date).DatePattern;
			}
			return null;
		}
	}
}
