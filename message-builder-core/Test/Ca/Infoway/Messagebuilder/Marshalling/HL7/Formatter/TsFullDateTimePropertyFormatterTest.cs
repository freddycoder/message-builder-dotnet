using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using ILOG.J2CsMapping.Text;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TsFullDateTimePropertyFormatterTest
	{
		private sealed class _VersionNumber_48 : VersionNumber
		{
			public _VersionNumber_48()
			{
			}

			public string VersionLiteral
			{
				get
				{
					// a hack to make sure our legacy NEWFOUNDLAND tests work
					return "NEWFOUNDLAND";
				}
			}

			public VersionNumber GetBaseVersion()
			{
				return null;
			}
		}

		private static readonly VersionNumber NEWFOUNDLAND_LEGACY_VERSION_HACK = new _VersionNumber_48();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null), null);
			// a null value for TS elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDate()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar1 = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null), calendar1);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "19990423101112.0000" + GetCurrentTimeZone(calendar1);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDateWithDatePatternInformation()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar1 = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null), new DateWithPattern(calendar1, "yyyyMMddHHmmss"));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("19990423101112", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDateWithMillisAndTimezoneDatePatternInformation()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null, false, SpecificationVersion.R02_04_02, null, null), new DateWithPattern(calendar, "yyyyMMddHHmmss.SSSZZZZZ"
				));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			// SPD: hard to verify result date string since it is timezone dependent. we check length instead
			Assert.AreEqual("yyyyMMddHHmmss.SSSZZZZZ".Length, result.SafeGet("value").Length, "value length as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDateWithMillisAndTimezone()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			string resultXml = new TsFullDateTimePropertyFormatter().Format(new FormatContextImpl("name", null, null, false, SpecificationVersion
				.R02_04_02, null, null), new TSImpl(calendar));
			string result = Ca.Infoway.Messagebuilder.StringUtils.Substring(resultXml, "<name value=\"".Length, resultXml.IndexOf("\"/>"
				));
			Assert.AreEqual("yyyyMMddHHmmss.SSS0ZZZZZ".Length, result.Length, "value length as expected");
			Assert.IsTrue(result.StartsWith("19990423101112.000"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestVersionDefault()
		{
			string value = "19990423101112.0000";
			HandleVersion((SpecificationVersion)null, value, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestVersionNew()
		{
			string value = "19990423101112.0000";
			HandleVersion(SpecificationVersion.R02_04_02, value, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestVersionOld()
		{
			HandleVersion(SpecificationVersion.V01R04_3, "19990423101112", false);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		private void HandleVersion(SpecificationVersion version, string expected, bool withTimeZone)
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null, false, version, null, null), calendar);
			Assert.AreEqual(1, result.Count, "map size");
			string expectedValue = withTimeZone ? expected + GetCurrentTimeZone(calendar) : expected;
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
		}

		private FormatContextImpl CreateFormatContextWithTimeZone(TimeZone timeZone)
		{
			return new FormatContextImpl("name", null, null, false, null, null, timeZone, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestDateFormatPrecedence()
		{
			VersionNumber version = SpecificationVersion.V02R02_AB;
			string dateWithPatternPattern = "test1_mmddyy";
			string overridePattern = "test2_MMDDYY";
			PlatformDate dateWithPattern = new DateWithPattern(new PlatformDate(), dateWithPatternPattern);
			PlatformDate normalDate = new PlatformDate();
			TsFullDateTimePropertyFormatter formatter = new TsFullDateTimePropertyFormatter();
            Runtime.SetProperty(TsFullDateTimePropertyFormatter.DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral, null);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(normalDate
				, version), "Should use default format if nothing else provided");
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS, formatter.DetermineDateFormat(normalDate, SpecificationVersion
				.V01R04_3), "Should use old default format if nothing else provided and version is CeRx");
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS, formatter.DetermineDateFormat(normalDate, SpecificationVersion
				.V01R04_2_SK), "Should use old default format if nothing else provided and version is SK CeRx");
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSSZZZZZ, formatter.DetermineDateFormat(normalDate
				, NEWFOUNDLAND_LEGACY_VERSION_HACK), "Should use old 'bad' default format if nothing else provided and version is NFLD");
			Runtime.SetProperty(TsFullDateTimePropertyFormatter.DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral, overridePattern
				);
			Assert.AreEqual(overridePattern, formatter.DetermineDateFormat(normalDate, version), "Should use override format when provided"
				);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(normalDate
				, SpecificationVersion.V02R02), "Should not use override format when provided version is only the base version of provided version"
				);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS, formatter.DetermineDateFormat(normalDate, SpecificationVersion
				.V01R04_3), "Should not use override format when provided version does not match");
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS, formatter.DetermineDateFormat(normalDate, SpecificationVersion
				.V01R04_2_SK), "Should not use override format when provided version does not match");
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSSZZZZZ, formatter.DetermineDateFormat(normalDate
				, NEWFOUNDLAND_LEGACY_VERSION_HACK), "Should not use override format when provided version does not match");
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(dateWithPattern, version), "Should use date with pattern always when provided"
				);
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(dateWithPattern, SpecificationVersion.V01R04_3), "Should use date with pattern always when provided even if version is CeRx"
				);
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(dateWithPattern, SpecificationVersion.V01R04_2_SK), 
				"Should use date with pattern always when provided even if version is SK CeRx");
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(dateWithPattern, NEWFOUNDLAND_LEGACY_VERSION_HACK), 
				"Should use date with pattern always when provided even if version is NFLD");
		}

		private string GetCurrentTimeZone(PlatformDate calendar)
		{
            DateTimeOffset expectedDate1 = TimeZoneInfo.ConvertTime(calendar, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            String timeZoneString = expectedDate1.Offset.ToString().Split(":")[0];
            String currentTimeZone = timeZoneString;
            while (currentTimeZone.Length <= 4)
            {
                currentTimeZone += "0";
            }
            return currentTimeZone;
		}
	}
}
