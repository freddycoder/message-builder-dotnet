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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class IvlTsElementParserTest : CeRxDomainValueTestCase
	{
		private XmlToModelResult result;

		private IvlTsElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.result = new XmlToModelResult();
			this.parser = new IvlTsElementParser();
			CodeResolverRegistry.RegisterResolver(typeof(x_TimeUnitsOfMeasure), new EnumBasedCodeResolver(typeof(Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				)));
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Interval<PlatformDate> Parse(XmlNode node, string type)
		{
			return Parse(node, type, null);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Interval<PlatformDate> Parse(XmlNode node, string type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel
			)
		{
			TimeZoneInfo timeZone = TimeZoneUtil.GetTimeZone("America/Toronto");
			return (Interval<PlatformDate>)this.parser.Parse(ParseContextImpl.Create(type, typeof(Interval<object>), SpecificationVersion
				.V02R02, timeZone, timeZone, conformanceLevel, null, null, false), Arrays.AsList(node), this.result).BareValue;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHigh()
		{
			PlatformDate expectedResultLow = DateUtil.GetDate(2006, 7, 10, 12, 0, 0, 0, TimeZoneUtil.GetTimeZone("America/Toronto"));
			PlatformDate expectedResultHigh = DateUtil.GetDate(2006, 7, 12, 15, 0, 0, 0, TimeZoneUtil.GetTimeZone("America/Toronto"));
			int offset = TimeZoneUtil.GetUTCOffset("America/Toronto", expectedResultLow);
			int hours = -1 * offset / (1000 * 60 * 60);
			XmlNode node = CreateNode("<effectiveTime><low value=\"20060810120000-0" + hours + "00\" /><high value=\"20060812150000-0"
				 + hours + "00\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.DATETIME>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE_TIME, expectedResultLow, interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE_TIME, expectedResultHigh, interval.High);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEffectiveTimeDate()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20080918\"/></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL.LOW<TS.DATE>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2008-09-18"), interval.Low);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEffectiveTimeDateWithSpecializationType()
		{
			XmlNode node = CreateNode("<effectiveTime specializationType=\"IVL&lt;TS.FULLDATE&gt;\"><low value=\"20080918\"/><high value=\"20090918\"/></effectiveTime>"
				);
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATEWITHTIME>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2008-09-18"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE, ParseDate("2009-09-18"), interval.High);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEffectiveTimeDateWithSpecializationTypeAlternative()
		{
			PlatformDate expectedResultLow = DateUtil.GetDate(2013, 2, 11, 16, 44, 2, 0, TimeZoneUtil.GetTimeZone("America/Toronto"));
			int offset = TimeZoneUtil.GetUTCOffset("America/Toronto", expectedResultLow);
			int hours = -1 * offset / (1000 * 60 * 60);
			// specializationType should not have to be specified as "IVL&lt;TS.FULLDATETIME&gt;", but should be accepted as "IVL_TS.FULLDATETIME" (which is how the MB formatter would write it)
			XmlNode node = CreateNode("<effectiveTime specializationType=\"IVL_TS.FULLDATETIME\"><low value=\"20130311164402.7530-0" 
				+ hours + "00\"/><high nullFlavor=\"NA\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATEWITHTIME>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE_TIME, expectedResultLow, interval.Low);
			Assert.IsNull(interval.High);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE.CodeValue, interval.HighNullFlavor
				.CodeValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEffectiveTimeDateWithSpecializationTypeAlternative2()
		{
			PlatformDate expectedResultLow = DateUtil.GetDate(2013, 2, 11, 16, 44, 2, 0, TimeZoneUtil.GetTimeZone("America/Toronto"));
			int offset = TimeZoneUtil.GetUTCOffset("America/Toronto", expectedResultLow);
			int hours = -1 * offset / (1000 * 60 * 60);
			XmlNode node = CreateNode("<effectiveTime specializationType=\"IVL&lt;TS.FULLDATETIME&gt;\"><low value=\"20130311164402.7530-0"
				 + hours + "00\"/><high nullFlavor=\"NA\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATEWITHTIME>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE_TIME, expectedResultLow, interval.Low);
			Assert.IsNull(interval.High);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE.CodeValue, interval.HighNullFlavor
				.CodeValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParsePartTimeDateWithSpecializationType()
		{
			PlatformDate expectedResultLow = DateUtil.GetDate(2013, 2, 11, 16, 0, 0, 0, TimeZoneUtil.GetTimeZone("America/Toronto"));
			int offset = TimeZoneUtil.GetUTCOffset("America/Toronto", expectedResultLow);
			int hours = -1 * offset / (1000 * 60 * 60);
			XmlNode node = CreateNode("<effectiveTime specializationType=\"IVL_TS.FULLDATEPARTTIME\"><low value=\"2013031116-0" + hours
				 + "00\"/><high nullFlavor=\"NA\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATEWITHTIME>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE_TIME, expectedResultLow, interval.Low);
			Assert.IsNull(interval.High);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE.CodeValue, interval.HighNullFlavor
				.CodeValue);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEffectiveTimeDateWithMissingSpecializationType()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20080918\"/><high value=\"20090918\"/></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATEWITHTIME>");
			Assert.IsFalse(this.result.IsValid(), "valid");
			Assert.AreEqual(3, this.result.GetHl7Errors().Count);
			// no ST; low and high should be datetimes 
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2008-09-18"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE, ParseDate("2009-09-18"), interval.High);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEffectiveTimeDateWithInvalidSpecializationType()
		{
			XmlNode node = CreateNode("<effectiveTime specializationType=\"IVL&lt;TS.DATE&gt;\"><low value=\"20080918\"/><high value=\"20090918\"/></effectiveTime>"
				);
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATEWITHTIME>");
			Assert.IsFalse(this.result.IsValid(), "valid");
			Assert.AreEqual(3, this.result.GetHl7Errors().Count);
			// invalid ST; low and high should be datetimes 
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2008-09-18"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE, ParseDate("2009-09-18"), interval.High);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMissingMandatoryEffectiveTimeDate()
		{
			XmlNode node = CreateNode("<effectiveTime/>");
			Parse(node, "IVL.LOW<TS.DATE>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			Assert.IsFalse(this.result.IsValid(), "not valid");
			IList<Hl7Error> hl7Errors = this.result.GetHl7Errors();
			Assert.IsFalse(hl7Errors.IsEmpty(), "has error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestRegistered()
		{
			Assert.IsNotNull(ParserRegistry.GetInstance().Get("IVL.LOW<TS.DATE>"), "parser");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowWidth()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20050810\" /><width value=\"10\" unit=\"d\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-10"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-20"), interval.High);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowWidthInvalidUnits()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20050810\" /><width value=\"10\" unit=\"s\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// seconds not valid for width for this type
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-10"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-10"), interval.High);
		}

		// width of 10 seconds changes nothing
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCaseThatLooksLikeSetComponent()
		{
			XmlNode node = CreateNode("<effectiveTime value=\"20050810\"></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// IVL<TS> must have two of low/high/width provided (even though this example is a correct representation of a "simple" interval)
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("value", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-10"), interval.Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLow()
		{
			PlatformDate expectedResultLow = DateUtil.GetDate(2005, 7, 10, 14, 34, 56, 0, TimeZoneUtil.GetTimeZone("America/Toronto")
				);
			int offset = TimeZoneUtil.GetUTCOffset("America/Toronto", expectedResultLow);
			int hours = -1 * offset / (1000 * 60 * 60);
			XmlNode node = CreateNode("<effectiveTime><low value=\"20050810143456-0" + hours + "00\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL.LOW<TS>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE_TIME, expectedResultLow, interval.Low);
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNull(interval.Width, "width");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidth()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1\" unit=\"d\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL.WIDTH<TS>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			Assert.IsNull(interval.Low, "low");
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNotNull(interval.Width, "width");
			DateDiff diff = (DateDiff)interval.Width;
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = diff.Unit;
			Assert.AreEqual("d", unit.CodeValue, "unit");
			Assert.IsNull(diff.NullFlavor, "null flavor");
			node = CreateNode("<effectiveTime>" + "   <low nullFlavor=\"OTH\"/>" + "   <width nullFlavor=\"OTH\"/>" + "</effectiveTime>"
				);
			interval = Parse(node, "IVL<TS>");
			Assert.IsTrue(this.result.IsValid(), "valid");
			Assert.IsNotNull(interval, "null");
			Assert.IsNull(interval.Low, "low");
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNotNull(interval.Width, "width");
			diff = (DateDiff)interval.Width;
			Assert.AreEqual("OTH", diff.NullFlavor.CodeValue, "nullFlavor");
			Assert.IsNull(diff.Unit, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidNullFlavor()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <low nullFlavor=\"NINF\"/>" + "   <width nullFlavor=\"PINF\"/>" + "</effectiveTime>"
				);
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsNotNull(interval);
			Assert.IsNull(interval.Low);
			Assert.IsNull(interval.High);
			Assert.IsNull(interval.Width.Value);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NEGATIVE_INFINITY, interval.LowNullFlavor);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.POSITIVE_INFINITY, interval.Width.NullFlavor);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
		}

		// PINF and NINF are not legal null flavors
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOtherInvalidNullFlavors()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <center nullFlavor=\"MSK\"/>" + "   <high nullFlavor=\"ASKU\"/>" + "</effectiveTime>"
				);
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsNotNull(interval);
			Assert.IsNull(interval.Low);
			Assert.IsNull(interval.Centre);
			Assert.IsNull(interval.High);
			Assert.IsNull(interval.Width);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.MASKED, interval.CentreNullFlavor);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.ASKED_BUT_UNKNOWN, interval.HighNullFlavor);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
		}

		// center not allowed; need two of low/high/width
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidthFailureValue()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1.d\" unit=\"d\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			System.Console.Out.WriteLine(this.result.GetHl7Errors()[1]);
			Assert.AreEqual(2, this.result.GetHl7Errors().Count, "error count");
			Hl7Error hl7Error = this.result.GetHl7Errors()[1];
			Assert.AreEqual("value \"1.d\" must contain digits only (<width unit=\"d\" value=\"1.d\"/>)", hl7Error.GetMessage(), "message"
				);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidthFailureUnit()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1\" unit=\"monkeys\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			Assert.AreEqual(2, this.result.GetHl7Errors().Count, "error count");
			Hl7Error hl7Error = this.result.GetHl7Errors()[1];
			Assert.AreEqual("Unit \"monkeys\" is not valid for type PQ.TIME (<width unit=\"monkeys\" value=\"1\"/>)", hl7Error.GetMessage
				(), "message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidthFailureValueAndUnit()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1.d\" unit=\"monkey\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			Assert.AreEqual(3, this.result.GetHl7Errors().Count, "error count");
			Hl7Error hl7Error = this.result.GetHl7Errors()[1];
			Assert.AreEqual("value \"1.d\" must contain digits only (<width unit=\"monkey\" value=\"1.d\"/>)", hl7Error.GetMessage(), 
				"message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error type");
			hl7Error = this.result.GetHl7Errors()[2];
			Assert.AreEqual("Unit \"monkey\" is not valid for type PQ.TIME (<width unit=\"monkey\" value=\"1.d\"/>)", hl7Error.GetMessage
				(), "message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyValue()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <value/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			Assert.AreEqual(3, this.result.GetHl7Errors().Count, "error count");
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		private PlatformDate ParseDate(string date)
		{
			return DateUtils.ParseDate(date, new string[] { "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss" });
		}
	}
}
