/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TsFullDateTimePropertyFormatterTest
	{
		private class TestableTsFullDateTimePropertyFormatter : TsFullDateTimePropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter
			<PlatformDate>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, PlatformDate t, BareANY
				 bareAny)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}

			public virtual string GetValueForTest(PlatformDate date, FormatContext context, BareANY bareAny)
			{
				return base.GetValue(date, context, bareAny);
			}
		}

		private sealed class _VersionNumber_63 : VersionNumber
		{
			public _VersionNumber_63()
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

			public Hl7BaseVersion GetBaseVersion()
			{
				return Hl7BaseVersion.MR2007;
			}

			// Newfoundland (as IWD currently implements it) is a mix of CeRx and V02R02
			public Hl7BaseVersion GetBaseVersion(Typed datatype)
			{
				return this.GetBaseVersion();
			}
		}

		private static readonly VersionNumber NEWFOUNDLAND_LEGACY_VERSION_HACK = new _VersionNumber_63();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false), null, new TSImpl());
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
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false), calendar1, null);
			Assert.AreEqual(1, result.Count, "map size");
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
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.DATETIME", null, 
				null, false, SpecificationVersion.R02_04_02, null, null, null, false), dateWithInvalidPattern, null);
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
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.DATETIME", null, 
				null, false, SpecificationVersion.R02_04_02, null, null, null, false), dateWithInvalidPattern, null);
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
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.FULLDATEPARTTIME"
				, null, null, false, SpecificationVersion.R02_04_02, null, null, null, false), dateWithInvalidPattern, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "1999042310" + GetCurrentTimeZone(calendar);
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsInvalidPartTimePattern()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMM");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.FULLDATEPARTTIME"
				, null, null, false, SpecificationVersion.R02_04_02, null, null, null, false), dateWithInvalidPattern, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "199904";
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsValidDatePatternMissingTimezone()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithValidPatternMissingTZ = new DateWithPattern(calendar, "yyyyMMddHH");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.DATETIME", null, 
				null, false, SpecificationVersion.R02_04_02, null, null, null, false), dateWithValidPatternMissingTZ, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("1999042310", result.SafeGet("value"), "value as expected");
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
			Assert.IsTrue(xmlResult.GetHl7Errors()[0].GetMessage().Contains("ZZZZZ"));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsInvalidDatePatternMissingTimezone()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMMddHH");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.DATETIME", null, 
				null, false, SpecificationVersion.R02_04_02, null, null, null, false), dateWithInvalidPattern, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			string expectedValue = "1999042310";
			Assert.AreEqual(expectedValue, result.SafeGet("value"), "value as expected");
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsValidDatePatternForCeRxMissingTimezone()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMMddHH");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.DATETIME", null, 
				null, false, SpecificationVersion.V01R04_3, null, null, null, false), dateWithInvalidPattern, null);
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
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false), new DateWithPattern(calendar1, "yyyyMMddHHmmss"), null);
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
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false, SpecificationVersion.R02_04_02, null, null, null, false), new DateWithPattern(calendar, "yyyyMMddHHmmss.SSSZZZZZ"
				), null);
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
			string resultXml = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", null, null, null, false, SpecificationVersion.R02_04_02, null, null, null, false)
				, new TSImpl(calendar));
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

		private void HandleVersion(SpecificationVersion version, string expected, bool withTimeZone)
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			IDictionary<string, string> result = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null, null
				, null, false, version, null, null, null, false), calendar, null);
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
			string gmtSixValue = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetValueForTest(calendar
				, CreateFormatContextWithTimeZone(TimeZoneUtil.GetTimeZone("GMT-6")), null);
			string gmtFiveValue = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter().GetValueForTest(calendar
				, CreateFormatContextWithTimeZone(TimeZoneUtil.GetTimeZone("GMT-5")), null);
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
			Runtime.ClearProperty(TsFullDateTimePropertyFormatter.DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral);
			string dateWithPatternPattern = "test1_mmddyy";
			string overridePattern = "test2_MMDDYY";
			PlatformDate dateWithPattern = new DateWithPattern(new PlatformDate(), dateWithPatternPattern);
			PlatformDate normalDate = new PlatformDate();
			TsFullDateTimePropertyFormatter formatter = new TsFullDateTimePropertyFormatterTest.TestableTsFullDateTimePropertyFormatter
				();
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(StandardDataType
				.TS_FULLDATETIME, normalDate, version), "Should use default format if nothing else provided");
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS, formatter.DetermineDateFormat(StandardDataType
				.TS_FULLDATETIME, normalDate, SpecificationVersion.V01R04_3), "Should use old default format if nothing else provided and version is CeRx"
				);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS, formatter.DetermineDateFormat(StandardDataType
				.TS_FULLDATETIME, normalDate, SpecificationVersion.V01R04_2_SK), "Should use old default format if nothing else provided and version is SK CeRx"
				);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(StandardDataType
				.TS_FULLDATETIME, normalDate, NEWFOUNDLAND_LEGACY_VERSION_HACK), "Should NOW use default format if nothing else provided and version is NFLD"
				);
			Runtime.SetProperty(TsFullDateTimePropertyFormatter.DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral, overridePattern
				);
			Assert.AreEqual(overridePattern, formatter.DetermineDateFormat(StandardDataType.TS_FULLDATETIME, normalDate, version), "Should use override format when provided"
				);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(StandardDataType
				.TS_FULLDATETIME, normalDate, SpecificationVersion.V02R02), "Should not use override format when provided version is only the base version of provided version"
				);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS, formatter.DetermineDateFormat(StandardDataType
				.TS_FULLDATETIME, normalDate, SpecificationVersion.V01R04_3), "Should not use override format when provided version does not match"
				);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS, formatter.DetermineDateFormat(StandardDataType
				.TS_FULLDATETIME, normalDate, SpecificationVersion.V01R04_2_SK), "Should not use override format when provided version does not match"
				);
			Assert.AreEqual(TsFullDateTimePropertyFormatter.DATE_FORMAT_YYYYMMDDHHMMSS_SSSZZZZZ, formatter.DetermineDateFormat(StandardDataType
				.TS_FULLDATETIME, normalDate, NEWFOUNDLAND_LEGACY_VERSION_HACK), "Should not use override format when provided version does not match"
				);
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(StandardDataType.TS_FULLDATETIME, dateWithPattern, 
				version), "Should use date with pattern always when provided");
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(StandardDataType.TS_FULLDATETIME, dateWithPattern, 
				SpecificationVersion.V01R04_3), "Should use date with pattern always when provided even if version is CeRx");
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(StandardDataType.TS_FULLDATETIME, dateWithPattern, 
				SpecificationVersion.V01R04_2_SK), "Should use date with pattern always when provided even if version is SK CeRx");
			Assert.AreEqual(dateWithPatternPattern, formatter.DetermineDateFormat(StandardDataType.TS_FULLDATETIME, dateWithPattern, 
				NEWFOUNDLAND_LEGACY_VERSION_HACK), "Should use date with pattern always when provided even if version is NFLD");
			Runtime.ClearProperty(TsFullDateTimePropertyFormatter.DATE_FORMAT_OVERRIDE_BASE_PROPERTY_NAME + version.VersionLiteral);
		}

		private string GetCurrentTimeZone(PlatformDate calendar)
		{
			return DateFormatUtil.Format(calendar, "Z");
		}
	}
}
