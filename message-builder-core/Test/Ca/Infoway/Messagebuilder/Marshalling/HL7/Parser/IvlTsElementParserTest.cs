using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;
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
			CodeResolverRegistry.RegisterResolver(typeof(x_TimeUnitsOfMeasure), new EnumBasedCodeResolver(typeof(DefaultTimeUnit)));
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
			return (Interval<PlatformDate>)this.parser.Parse(ParserContextImpl.Create(type, typeof(Interval<object>), SpecificationVersion
				.V02R02, null, null, conformanceLevel), Arrays.AsList(node), this.result).BareValue;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHigh()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20060810120000\" /><high value=\"20060812150000\" /></effectiveTime>"
				);
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE_TIME, ParseDate("2006-08-10T12:00:00"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE_TIME, ParseDate("2006-08-12T15:00:00"), interval.High);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEffectiveTimeDate()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20080918\"/></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL.LOW<TS.DATE>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2008-09-18"), interval.Low);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMissingMandatoryEffectiveTimeDate()
		{
			XmlNode node = CreateNode("<effectiveTime/>");
			Parse(node, "IVL.LOW<TS.DATE>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
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
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-10"), interval.Low);
			AssertDateEquals("high", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-20"), interval.High);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCaseThatLooksLikeSetComponent()
		{
			XmlNode node = CreateNode("<effectiveTime value=\"20050810\"></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("value", MarshallingTestCase.FULL_DATE, ParseDate("2005-08-10"), interval.Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLow()
		{
			XmlNode node = CreateNode("<effectiveTime><low value=\"20050810143456\" /></effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNotNull(interval, "null");
			AssertDateEquals("low", MarshallingTestCase.FULL_DATE_TIME, ParseDate("2005-08-10T14:34:56"), interval.Low);
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNull(interval.Width, "width");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidth()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1\" unit=\"d\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNotNull(interval, "null");
			Assert.IsNull(interval.Low, "low");
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNotNull(interval.Width, "width");
			DateDiff diff = (DateDiff)interval.Width;
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = diff.Unit;
			Assert.AreEqual("d", unit.CodeValue, "unit");
			Assert.IsNull(diff.NullFlavor, "null flavor");
			node = CreateNode("<effectiveTime>" + "   <width nullFlavor=\"OTH\"/>" + "</effectiveTime>");
			interval = Parse(node, "IVL<TS>");
			Assert.IsNotNull(interval, "null");
			Assert.IsNull(interval.Low, "low");
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNotNull(interval.Width, "width");
			diff = (DateDiff)interval.Width;
			NullFlavor nullFlavor = (diff).NullFlavor;
			Assert.AreEqual("OTH", nullFlavor.CodeValue, "nullFlavor");
			Assert.IsNull(diff.Unit, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidthFailureValue()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1.d\" unit=\"d\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			System.Console.Out.WriteLine(this.result.GetHl7Errors()[1]);
			Assert.AreEqual(3, this.result.GetHl7Errors().Count, "error count");
			Hl7Error hl7Error = this.result.GetHl7Errors()[0];
			Assert.AreEqual("value \"1.d\" is not a valid decimal value (<width unit=\"d\" value=\"1.d\"/>)", hl7Error.GetMessage(), 
				"message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidthFailureUnit()
		{
			resolver.AddDomainValue(null, typeof(Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive));
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1\" unit=\"monkeys\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			Assert.AreEqual(3, this.result.GetHl7Errors().Count, "error count");
			Hl7Error hl7Error = this.result.GetHl7Errors()[0];
			Assert.AreEqual("Unit \"monkeys\" is not valid (<width unit=\"monkeys\" value=\"1\"/>)", hl7Error.GetMessage(), "message"
				);
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWidthFailureValueAndUnit()
		{
			resolver.AddDomainValue(null, typeof(Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive));
			XmlNode node = CreateNode("<effectiveTime>" + "   <width value=\"1.d\" unit=\"monkey\"/>" + "</effectiveTime>");
			Interval<PlatformDate> interval = Parse(node, "IVL<TS>");
			Assert.IsNull(interval, "null");
			Assert.IsFalse(this.result.IsValid(), "not valid");
			Assert.AreEqual(4, this.result.GetHl7Errors().Count, "error count");
			Hl7Error hl7Error = this.result.GetHl7Errors()[0];
			Assert.AreEqual("value \"1.d\" is not a valid decimal value (<width unit=\"monkey\" value=\"1.d\"/>)", hl7Error.GetMessage
				(), "message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error type");
			hl7Error = this.result.GetHl7Errors()[1];
			Assert.AreEqual("Unit \"monkey\" is not valid (<width unit=\"monkey\" value=\"1.d\"/>)", hl7Error.GetMessage(), "message"
				);
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
			Assert.AreEqual(2, this.result.GetHl7Errors().Count, "error count");
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		private PlatformDate ParseDate(string date)
		{
			return DateUtils.ParseDate(date, new string[] { "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss" });
		}
	}
}
