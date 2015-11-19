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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class IvlTsFullDateElementParserTest : CeRxDomainValueTestCase
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
			return (Interval<PlatformDate>)this.parser.Parse(ParseContextImpl.Create(type, typeof(Interval<object>), SpecificationVersion
				.V02R02, null, null, null, null, null, false), Arrays.AsList(node), this.result).BareValue;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHigh()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20060810\" /><high value=\"20060812\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2006-08-10"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE, ParseDate("2006-08-12"), interval.High);
			AssertDateEquals("centre", MarshallingTestCase.FULL_DATE_TIME, ParseDate("2006-08-11T00:00:00"), interval.Centre);
			Assert.AreEqual(DateUtils.MILLIS_PER_DAY * 2L, interval.Width.Value.Time, "width");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowWidth()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20050810\" /><width value=\"10\" unit=\"d\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-10"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-20"), interval.High);
			AssertDateEquals("centre", MarshallingTestCase.FULL_DATE_TIME, ParseDate("2005-08-15T00:00:00"), interval.Centre);
			Assert.AreEqual(new BigDecimal("10"), ((DateDiff)interval.Width).ValueAsPhysicalQuantity.Quantity, "width");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLow()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20050810\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-10"), interval.Low);
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNull(interval.Width, "width");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowFullDateTime()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20050810230327\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATETIME>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE_TIME, ParseDate("2005-08-10T23:03:27"), interval.Low);
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNull(interval.Width, "width");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidthFailureValue()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1.d\" unit=\"d\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			// errors = need second value (low or high) to go with width; width value is not a number; width value must contain digits only
			Assert.AreEqual(2, this.result.GetHl7Errors().Count, "error count");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidthFailureUnit()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <width unit=\"monkeys\" value=\"1\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			// errors: need one additional element (low or high); units are not valid
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
			XmlNode node = CreateNode("<effectiveTime>" + "   <width unit=\"monkey\" value=\"1.d\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS.FULLDATE>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			// errors: new one of high/low; value must only contain digits; monkey invalid units
			Assert.AreEqual(3, this.result.GetHl7Errors().Count, "error count");
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		private PlatformDate ParseDate(string date)
		{
			return DateUtils.ParseDate(date, new string[] { "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss" });
		}
	}
}
