using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class RtoQtyQtyElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			RTO<BigDecimal, BigDecimal> rto = (RTO<BigDecimal, BigDecimal>)new RtoQtyQtyElementParser().Parse(CreateContext(), node, 
				null);
			Assert.IsNull(rto.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, rto.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("RTO<QTY,QTY>", typeof(Ratio<object, object>), SpecificationVersion.NEWFOUNDLAND, null, null
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Ratio<BigDecimal, BigDecimal> ratio = (Ratio<BigDecimal, BigDecimal>)new RtoQtyQtyElementParser().Parse(null, node, null)
				.BareValue;
			Assert.IsNotNull(ratio, "ratio");
			Assert.IsNull(ratio.Numerator, "numerator");
			Assert.IsNull(ratio.Denominator, "denominator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributes()
		{
			XmlNode node = CreateNode("<something><numerator value=\"1234.45\" /><denominator value=\"2345.67\" /></something>");
			Ratio<BigDecimal, BigDecimal> ratio = (Ratio<BigDecimal, BigDecimal>)new RtoQtyQtyElementParser().Parse(null, node, null)
				.BareValue;
			Assert.IsNotNull(ratio, "ratio");
			Assert.AreEqual(new BigDecimal("1234.45"), ratio.Numerator, "numerator");
			Assert.AreEqual(new BigDecimal("2345.67"), ratio.Denominator, "denominator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something><numerator value=\"monkey\" /><denominator value=\"2345.67\" /></something>");
			try
			{
				new RtoQtyQtyElementParser().Parse(null, node, null);
				Assert.Fail("expected exception");
			}
			catch (FormatException)
			{
			}
		}
		// expected
	}
}
