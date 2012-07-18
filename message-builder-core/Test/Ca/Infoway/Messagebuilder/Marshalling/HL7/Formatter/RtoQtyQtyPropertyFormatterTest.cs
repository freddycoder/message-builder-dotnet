using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class RtoQtyQtyPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Ratio<BigDecimal, BigDecimal> ratio = new Ratio<BigDecimal, BigDecimal>();
			ratio.Numerator = new BigDecimal("1.00");
			ratio.Denominator = new BigDecimal("10.00");
			string result = new RtoQtyQtyPropertyFormatter().Format(GetContext("name"), new RTOImpl<BigDecimal, BigDecimal>(ratio));
			AssertXml("result", "<name><numerator value=\"1.00\" xsi:type=\"QTY\"/><denominator value=\"10.00\" xsi:type=\"QTY\"/></name>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new RtoQtyQtyPropertyFormatter().Format(GetContext("name"), new RTOImpl<BigDecimal, BigDecimal>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}
	}
}
