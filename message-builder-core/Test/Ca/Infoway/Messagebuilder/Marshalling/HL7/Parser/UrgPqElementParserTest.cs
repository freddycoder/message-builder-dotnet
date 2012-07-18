using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class UrgPqElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<range><low value=\"123\" unit=\"kg\" /><high value=\"567\" unit=\"kg\" /></range>");
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new UrgPqElementParser().Parse(null, node, null
				).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestReportError()
		{
			XmlToModelResult xmlResult = new XmlToModelResult();
			XmlNode node = CreateNode("<range><low value=\"123\" unit=\"m\" /><high value=\"567\" unit=\"HOUR\" /></range>");
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new UrgPqElementParser().Parse(null, node, xmlResult
				).BareValue;
			Assert.IsNull(range, "null");
			Assert.IsFalse(xmlResult.GetHl7Errors().IsEmpty(), "has error");
			Assert.AreEqual(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "Can't add two quantities of different units: m and HOUR", (XmlElement
				)node), xmlResult.GetHl7Errors()[0], "syntax error");
		}
	}
}
