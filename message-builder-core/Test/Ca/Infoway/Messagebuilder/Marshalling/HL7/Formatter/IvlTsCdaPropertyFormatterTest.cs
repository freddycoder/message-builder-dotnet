using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IvlTsCdaPropertyFormatterTest : FormatterTestCase
	{
		private IvlTsCdaPropertyFormatter formatter = new IvlTsCdaPropertyFormatter();

		[Test]
		public virtual void TestIvlTs()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate dateLow = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPatternLow = new DateWithPattern(dateLow, "yyyyMMdd");
			PlatformDate dateHigh = DateUtil.GetDate(2012, 6, 8);
			DateWithPattern dateWithPatternHigh = new DateWithPattern(dateHigh, "yyyyMMdd");
			Interval<PlatformDate> ivlTs = IntervalFactory.CreateLowHigh((PlatformDate)dateWithPatternLow, (PlatformDate)dateWithPatternHigh
				);
			DateInterval dateInterval = new DateInterval(ivlTs);
			BareANY dataType = new IVLTSCDAR1Impl(dateInterval);
			FormatContext formatContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, string.Empty
				, "ivl", "IVLTSCDAR1", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), false, SpecificationVersion
				.R02_04_03, null, null, null, null, true);
			string xml = this.formatter.Format(formatContext, dataType);
			Assert.IsTrue(result.IsValid());
			string expected = "<ivl><low value=\"20120503\"/><high value=\"20120708\"/></ivl>";
			AssertXml("pivl output", expected, xml, true);
		}

		[Test]
		public virtual void TestIvlTsWithConstraintsValid()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate dateLow = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPatternLow = new DateWithPattern(dateLow, "yyyyMMdd");
			PlatformDate dateHigh = DateUtil.GetDate(2012, 6, 8);
			DateWithPattern dateWithPatternHigh = new DateWithPattern(dateHigh, "yyyyMMdd");
			Interval<PlatformDate> ivlTs = IntervalFactory.CreateLowHigh((PlatformDate)dateWithPatternLow, (PlatformDate)dateWithPatternHigh
				);
			DateInterval dateInterval = new DateInterval(ivlTs);
			BareANY dataType = new IVLTSCDAR1Impl(dateInterval);
			ConstrainedDatatype constraints = new ConstrainedDatatype("ivl", "IVL<TS>");
			constraints.Relationships.Add(new Relationship("low", "TS", Cardinality.Create("1")));
			constraints.Relationships.Add(new Relationship("high", "TS", Cardinality.Create("1")));
			FormatContext formatContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, string.Empty
				, "ivl", "IVLTSCDAR1", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), false, SpecificationVersion
				.R02_04_03, null, null, null, constraints, true);
			string xml = this.formatter.Format(formatContext, dataType);
			Assert.IsTrue(result.IsValid());
			string expected = "<ivl><low value=\"20120503\"/><high value=\"20120708\"/></ivl>";
			AssertXml("ivl output", expected, xml, true);
		}

		[Test]
		public virtual void TestIvlTsWithConstraintsInValid()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate dateLow = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPatternLow = new DateWithPattern(dateLow, "yyyyMMdd");
			PlatformDate dateHigh = DateUtil.GetDate(2012, 6, 8);
			DateWithPattern dateWithPatternHigh = new DateWithPattern(dateHigh, "yyyyMMdd");
			Interval<PlatformDate> ivlTs = IntervalFactory.CreateLowHigh((PlatformDate)dateWithPatternLow, (PlatformDate)dateWithPatternHigh
				);
			DateInterval dateInterval = new DateInterval(ivlTs);
			BareANY dataType = new IVLTSCDAR1Impl(dateInterval);
			ConstrainedDatatype constraints = new ConstrainedDatatype("ivl", "IVL<TS>");
			constraints.Relationships.Add(new Relationship("low", "TS", Cardinality.Create("0")));
			constraints.Relationships.Add(new Relationship("high", "TS", Cardinality.Create("0")));
			FormatContext formatContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, string.Empty
				, "ivl", "IVLTSCDAR1", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), false, SpecificationVersion
				.R02_04_03, null, null, null, constraints, true);
			string xml = this.formatter.Format(formatContext, dataType);
			Assert.IsFalse(result.IsValid());
			Assert.AreEqual(2, result.GetHl7Errors().Count);
			string expected = "<ivl><low value=\"20120503\"/><high value=\"20120708\"/></ivl>";
			AssertXml("ivl output", expected, xml, true);
		}
	}
}
