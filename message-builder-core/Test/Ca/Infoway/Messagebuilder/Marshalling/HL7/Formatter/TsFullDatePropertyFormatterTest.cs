using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TsFullDatePropertyFormatterTest
	{
		private class TestableTsFullDatePropertyFormatter : TsFullDatePropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter
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

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDatePropertyFormatterTest.TestableTsFullDatePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", null, null, null, false
				), null, new TSImpl());
			// a null value for TS elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDate()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDatePropertyFormatterTest.TestableTsFullDatePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.DATE", null, null
				, false, SpecificationVersion.R02_04_02, null, null, null, false), calendar, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("19990423", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsInvalidDatePattern()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMMMdd");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDatePropertyFormatterTest.TestableTsFullDatePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.DATE", null, null
				, false, SpecificationVersion.R02_04_02, null, null, null, false), dateWithInvalidPattern, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("1999Apr23", result.SafeGet("value"), "value as expected (even though invalid)");
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForDateWithPattern()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithPattern = new DateWithPattern(calendar, "yyyyMM");
			// note that a Date and a DateWithPattern only work for equals() because the
			// Java implementation we are using uses "instanceof" instead of "getClass()" for its preliminary comparison 
			Assert.AreEqual(calendar, dateWithPattern, "same dates should be equal");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDatePropertyFormatterTest.TestableTsFullDatePropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(xmlResult, null, "name", "TS.DATE", null, null
				, false, SpecificationVersion.R02_04_02, null, null, null, false), dateWithPattern, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("199904", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetValueGeneratesDifferentStringsForDifferentTimeZones()
		{
			PlatformDate date = DateUtil.GetDate(1992, 1, 1, 0, 0, 0, 0, TimeZoneUtil.GetTimeZone("Canada/Ontario"));
			string gmtSixValue = new TsFullDatePropertyFormatterTest.TestableTsFullDatePropertyFormatter().GetValueForTest(date, CreateFormatContextWithTimeZone
				(TimeZoneUtil.GetTimeZone("Canada/Saskatchewan")), null);
			string gmtFiveValue = new TsFullDatePropertyFormatterTest.TestableTsFullDatePropertyFormatter().GetValueForTest(date, CreateFormatContextWithTimeZone
				(TimeZoneUtil.GetTimeZone("Canada/Ontario")), null);
			Assert.IsFalse(StringUtils.Equals(gmtSixValue, gmtFiveValue));
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateFormatContextWithTimeZone(TimeZoneInfo
			 timeZone)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, "name", null
				, null, null, null, false, null, timeZone, null, null, null, false);
		}
	}
}
