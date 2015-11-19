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
	public class TsCdaPropertyFormatterTest
	{
		private TsCdaPropertyFormatter formatter = new TsCdaPropertyFormatter();

		[Test]
		public virtual void TestTs()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate date = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPattern = new DateWithPattern(date, "yyyyMMdd");
			BareANY dataType = new TSCDAR1Impl(new MbDate(dateWithPattern));
			FormatContext formatContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, string.Empty
				, "date", "TSCDAR1", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), false, SpecificationVersion
				.R02_04_03, null, null, null, null, true);
			string xml = this.formatter.Format(formatContext, dataType);
			Assert.IsTrue(result.IsValid());
			Assert.AreEqual("<date value=\"20120503\"/>", xml.Trim());
		}

		[Test]
		public virtual void TestSxcmTs()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate date = DateUtil.GetDate(2013, 5, 4);
			DateWithPattern dateWithPattern = new DateWithPattern(date, "yyyyMMdd");
			BareANY dataType = new SXCMTSCDAR1Impl(new MbDate(dateWithPattern));
			((ANYMetaData)dataType).Operator = SetOperator.EXCLUDE;
			FormatContext formatContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, string.Empty
				, "date", "SXCMTSCDAR1", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), false, 
				SpecificationVersion.R02_04_03, null, null, null, null, true);
			string xml = this.formatter.Format(formatContext, dataType);
			Assert.IsTrue(result.IsValid());
			Assert.AreEqual("<date operator=\"E\" value=\"20130604\"/>", xml.Trim());
		}
	}
}
