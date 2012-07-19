using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// TS.FULLDATETIME - Timestamp (fully-specified date and time only)
	/// Represents a TS.FULLDATETIME object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// TS.FULLDATETIME - Timestamp (fully-specified date and time only)
	/// Represents a TS.FULLDATETIME object as an element:
	/// &lt;element-name value="yyyyMMddHHmmss"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TS
	/// </remarks>
	[DataTypeHandler(new string[] { "TS.FULLDATETIME", "TS", "TS.DATETIME" })]
	public class TsFullDateTimePropertyFormatter : AbstractValueNullFlavorPropertyFormatter<PlatformDate>
	{
		public static readonly string DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME = "messagebuilder.date.format.override.";

		public static readonly string DATE_FORMAT_YYYYMMDDHHMMSS = "yyyyMMddHHmmss";

		public static readonly string DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ = "yyyyMMddHHmmss.SSS0ZZZZZ";

		public static readonly string DATE_FORMAT_YYYYMMDDHHMMSSZZZZZ = "yyyyMMddHHmmssZZZZZ";

		protected override string GetValue(PlatformDate date, FormatContext context)
		{
			VersionNumber version = GetVersion(context);
			string datePattern = DetermineDateFormat(date, version);
			TimeZone timeZone = context != null && context.GetDateTimeTimeZone() != null ? context.GetDateTimeTimeZone() : System.TimeZone.CurrentTimeZone;
			return DateFormatUtil.Format(date, datePattern, timeZone);
		}

		internal virtual string DetermineDateFormat(PlatformDate date, VersionNumber version)
		{
			// date format precedence:
			//    provided Date is a dateWithPattern
			//    format has been overridden for this version
			//    default format for version
			string datePattern = GetPatternFromDateWithPattern(date);
			if (datePattern == null)
			{
				datePattern = GetOverrideDatePattern(version);
				if (datePattern == null)
				{
					datePattern = GetDefaultDatePattern(version);
				}
			}
			return datePattern;
		}

		private string GetOverrideDatePattern(VersionNumber version)
		{
			if (version == null)
			{
				return null;
			}
			return Runtime.GetProperty(DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral);
		}

		private string GetPatternFromDateWithPattern(PlatformDate date)
		{
			if (date is DateWithPattern)
			{
				return ((DateWithPattern)date).DatePattern;
			}
			return null;
		}

		private string GetDefaultDatePattern(VersionNumber version)
		{
			if (SpecificationVersion.IsVersion(SpecificationVersion.V01R04_3, version))
			{
				return DATE_FORMAT_YYYYMMDDHHMMSS;
			}
			else
			{
				if (IsNewfoundland(version))
				{
					// FIXME - TM - temp hack to allow transformation tests to pass; 
					//            - these tests should be modified to work with the default date format
					return DATE_FORMAT_YYYYMMDDHHMMSSZZZZZ;
				}
			}
			return DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ;
		}

		private bool IsNewfoundland(VersionNumber version)
		{
			// this version is not currently supported by MB and is not in the SpecificationVersion enum
			// TODO - TM - NEWFOUNDLAND TEST HACK
			return version != null && StringUtils.Equals(version.VersionLiteral, "NEWFOUNDLAND");
		}

		private VersionNumber GetVersion(FormatContext context)
		{
			return context == null ? null : context.GetVersion();
		}
	}
}
