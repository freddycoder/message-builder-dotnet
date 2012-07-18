using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class RtoPqPqPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio = new Ratio<PhysicalQuantity, PhysicalQuantity>();
			ratio.Numerator = new PhysicalQuantity(new BigDecimal("1.00"), Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
				.MILLIGRAM);
			ratio.Denominator = new PhysicalQuantity(new BigDecimal("10.00"), Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive
				.MILLILITRE);
			string result = new RtoPqPqPropertyFormatter().Format(GetContext("name"), new RTOImpl<PhysicalQuantity, PhysicalQuantity>
				(ratio));
			AssertXml("result", "<name><numerator unit=\"mg\" value=\"1.00\" xsi:type=\"PQ\"/><denominator unit=\"ml\" value=\"10.00\" xsi:type=\"PQ\"/></name>"
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
