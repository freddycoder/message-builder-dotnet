using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class TsR2PropertyFormatterTest
	{
		private class TestableTsR2PropertyFormatter : TsR2PropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<MbDate
			>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, MbDate t, BareANY bareAny
				)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}

			public virtual string GetValueForTest(MbDate mbDate, FormatContext context, BareANY bareAny)
			{
				return base.GetValue(mbDate, context, bareAny);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false), null, new TS_R2Impl());
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
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false), new MbDate(calendar1), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "19990423101112.0000" + GetCurrentTimeZone(calendar1);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDateWithOperatorNotAllowed()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar1 = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			TS_R2 ts = new TS_R2Impl(new MbDate(calendar1));
			ts.Operator = SetOperator.PERIODIC_HULL;
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS", null, null, false
				, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(calendar1), ts);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "19990423101112.0000" + GetCurrentTimeZone(calendar1);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.IsFalse(xmlResult.IsValid());
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSxcmGetAttributeNameValuePairsDateWithOperatorAllowed()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar1 = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			TS_R2 ts = new TS_R2Impl(new MbDate(calendar1));
			ts.Operator = SetOperator.PERIODIC_HULL;
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "SXCM<TS>", null, null
				, false, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(calendar1), ts);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(xmlResult.IsValid());
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "19990423101112.0000" + GetCurrentTimeZone(calendar1);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(result.ContainsKey("operator"), "key as expected");
			Assert.AreEqual("P", result.SafeGet("operator"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSxcmGetAttributeNameValuePairsDateWithNoOperator()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar1 = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			TS_R2 ts = new TS_R2Impl(new MbDate(calendar1));
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "SXCM<TS>", null, null
				, false, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(calendar1), ts);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(xmlResult.IsValid());
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "19990423101112.0000" + GetCurrentTimeZone(calendar1);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsInvalidDatePattern()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMMMddHHmmss.SSS0ZZZZZ");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS", null, null, false
				, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(dateWithInvalidPattern), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "1999Apr23101112.0000" + GetCurrentTimeZone(calendar);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsValidPartialDateTimePatternWithTimezone()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMMddHHZZZZZ");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS", null, null, false
				, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(dateWithInvalidPattern), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "1999042310" + GetCurrentTimeZone(calendar);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsValidPartTimePattern()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMMddHHZZZZZ");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS", null, null, false
				, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(dateWithInvalidPattern), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "1999042310" + GetCurrentTimeZone(calendar);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsUsingPartTimePattern()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMM");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS", null, null, false
				, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(dateWithInvalidPattern), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "199904";
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsValidDatePatternMissingTimezone()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithValidPatternMissingTZ = new DateWithPattern(calendar, "yyyyMMddHH");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS", null, null, false
				, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(dateWithValidPatternMissingTZ), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("1999042310", result.SafeGet("value"), "value as expected");
			// non-R2 formatter would complain about missing TZ; R2 schema does not explicitly state this is true
			Assert.IsTrue(xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsValidDatePatternForCeRxMissingTimezone()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMMddHH");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS", null, null, false
				, SpecificationVersion.V01R04_3, null, null, null, false), new MbDate(dateWithInvalidPattern), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "1999042310";
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDateWithDatePatternInformation()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar1 = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithPattern = new DateWithPattern(calendar1, "yyyyMMddHHmmss");
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false), new MbDate(dateWithPattern), null);
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
			DateWithPattern dateWithPattern = new DateWithPattern(calendar, "yyyyMMddHHmmss.SSSZZZZZ");
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false, SpecificationVersion.R02_04_02, null, null, null, false), new MbDate(dateWithPattern), null);
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
			string resultXml = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", null, null, null, false, SpecificationVersion.R02_04_02, null, null, null, false)
				, new TS_R2Impl(new MbDate(calendar)));
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
			HandleVersion(SpecificationVersion.V01R04_3, "19990423101112.0000", true);
		}

		private void HandleVersion(SpecificationVersion version, string expected, bool withTimeZone)
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			IDictionary<string, string> result = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false, version, null, null, null, false), new MbDate(calendar), null);
			Assert.AreEqual(1, result.Count, "map size");
			string expectedValue = withTimeZone ? expected + GetCurrentTimeZone(calendar) : expected;
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetValueGeneratesDifferentStringsForDifferentTimeZones()
		{
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			string gmtSixValue = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetValueForTest(new MbDate(calendar), 
				CreateFormatContextWithTimeZone(TimeZoneUtil.GetTimeZone("GMT-6")), null);
			string gmtFiveValue = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter().GetValueForTest(new MbDate(calendar), 
				CreateFormatContextWithTimeZone(TimeZoneUtil.GetTimeZone("GMT-5")), null);
			Assert.IsFalse(StringUtils.Equals(gmtSixValue, gmtFiveValue));
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateFormatContextWithTimeZone(TimeZoneInfo
			 timeZone)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null
				, null, null, null, false, null, null, timeZone, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestDateFormatPrecedence()
		{
			VersionNumber version = SpecificationVersion.V02R02_AB;
			Runtime.ClearProperty(TsR2PropertyFormatter.DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral);
			string dateWithPatternPattern = "test1_mmddyy";
			string overridePattern = "test2_MMDDYY";
			PlatformDate dateWithPattern = new DateWithPattern(new PlatformDate(), dateWithPatternPattern);
			PlatformDate normalDate = new PlatformDate();
			TsR2PropertyFormatter formatter = new TsR2PropertyFormatterTest.TestableTsR2PropertyFormatter();
			Assert.AreEqual(TsR2PropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(normalDate, version
				), "Should use default format if nothing else provided");
			Runtime.SetProperty(TsR2PropertyFormatter.DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral, overridePattern
				);
			Assert.AreEqual(overridePattern, formatter.DetermineDateFormat(normalDate, version), "Should use override format when provided"
				);
			Assert.AreEqual(TsR2PropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(normalDate, SpecificationVersion
				.V02R02), "Should always use override format when provided");
			Assert.AreEqual(TsR2PropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(normalDate, SpecificationVersion
				.V01R04_3), "Should always use override format when provided");
			Assert.AreEqual(TsR2PropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(normalDate, SpecificationVersion
				.V01R04_2_SK), "Should always use override format when provided");
			Assert.AreEqual(TsR2PropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(normalDate, SpecificationVersion
				.R02_04_03), "Should always use override format when provided");
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(dateWithPattern, version), "Should use date with pattern always when provided"
				);
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(dateWithPattern, SpecificationVersion.V01R04_3), "Should use date with pattern always when provided even if version is CeRx"
				);
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(dateWithPattern, SpecificationVersion.V01R04_2_SK), 
				"Should use date with pattern always when provided even if version is SK CeRx");
			Runtime.ClearProperty(TsR2PropertyFormatter.DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral);
		}

		private string GetCurrentTimeZone(PlatformDate calendar)
		{
			return DateFormatUtil.Format(calendar, "Z");
		}
	}
}
