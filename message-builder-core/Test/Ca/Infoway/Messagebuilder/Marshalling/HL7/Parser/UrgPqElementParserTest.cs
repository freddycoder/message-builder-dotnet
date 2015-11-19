using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
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
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new UrgPqElementParser().Parse(CreateContext()
				, node, this.xmlResult).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
			Assert.IsNull(range.LowInclusive);
			Assert.IsNull(range.HighInclusive);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithInclusive()
		{
			XmlNode node = CreateNode("<range><low inclusive=\"true\" value=\"123\" unit=\"kg\" /><high inclusive=\"false\" value=\"567\" unit=\"kg\" /></range>"
				);
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new UrgPqElementParser().Parse(CreateContext()
				, node, this.xmlResult).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
			Assert.IsTrue(range.LowInclusive.Value);
			Assert.IsFalse(range.HighInclusive.Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseUrgForBC()
		{
			ParseContext context = ParseContextImpl.Create("URG<PQ.LAB>", null, SpecificationVersion.V02R04_BC, null, null, null, null
				, null, null, null, false);
			string xml = "<value specializationType=\"URG_PQ.LAB\" unit=\"1\" xsi:type=\"URG_PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
				 + "<originalText mediaType=\"text/plain\" representation=\"TXT\">&lt;124</originalText>" + "<low inclusive=\"true\" nullFlavor=\"NI\" specializationType=\"PQ.LAB\" value=\"1\" />"
				 + "<high inclusive=\"false\" specializationType=\"PQ.LAB\" unit=\"g/L\" value=\"124\"/>" + "</value>";
			XmlNode node = CreateNode(xml);
			BareANY URG = new UrgPqElementParser().Parse(context, node, this.xmlResult);
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)URG.BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
			Assert.AreEqual("<124", ((ANYMetaData)URG).OriginalText, "OT");
			Assert.IsTrue(range.LowInclusive.Value, "low inclusive");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, range.LowNullFlavor, "low NF"
				);
			Assert.AreEqual(BigDecimal.ONE, range.Low.Quantity, "low value");
			Assert.IsNull(range.Low.Unit, "low unit");
			Assert.IsFalse(range.HighInclusive.Value, "high inclusive");
			Assert.IsNull(range.HighNullFlavor, "high NF");
			Assert.AreEqual(new BigDecimal("124"), range.High.Quantity, "high value");
			Assert.AreEqual("g/L", range.High.Unit.CodeValue, "high units");
			Assert.IsTrue(range.High.Unit is x_LabUnitsOfMeasure);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseUrgForBCAlt()
		{
			ParseContext context = ParseContextImpl.Create("URG<PQ.LAB>", null, SpecificationVersion.V02R04_BC, null, null, null, null
				, null, null, null, false);
			string xml = "<value specializationType=\"URG_PQ.LAB\" unit=\"1\" xsi:type=\"URG_PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
				 + "<originalText mediaType=\"text/plain\" representation=\"TXT\">&lt;124</originalText>" + "<low inclusive=\"true\" nullFlavor=\"NI\" specializationType=\"PQ.LAB\" unit=\"1\" />"
				 + "<high inclusive=\"false\" specializationType=\"PQ.LAB\" unit=\"g/L\" value=\"124\"/>" + "</value>";
			XmlNode node = CreateNode(xml);
			BareANY URG = new UrgPqElementParser().Parse(context, node, this.xmlResult);
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)URG.BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
			Assert.AreEqual("<124", ((ANYMetaData)URG).OriginalText, "OT");
			Assert.IsTrue(range.LowInclusive.Value, "low inclusive");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, range.LowNullFlavor, "low NF"
				);
			Assert.IsNull(range.Low.Quantity, "low value");
			Assert.AreEqual("1", range.Low.Unit.CodeValue, "low unit");
			Assert.IsNull(range.Low.Unit.CodeSystem, "low unit");
			Assert.IsFalse(range.HighInclusive.Value, "high inclusive");
			Assert.IsNull(range.HighNullFlavor, "high NF");
			Assert.AreEqual(new BigDecimal("124"), range.High.Quantity, "high value");
			Assert.AreEqual("g/L", range.High.Unit.CodeValue, "high units");
			Assert.IsTrue(range.High.Unit is x_LabUnitsOfMeasure);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestReportError()
		{
			XmlNode node = CreateNode("<range><low value=\"123\" unit=\"m\" /><high value=\"567\" unit=\"h\" /></range>");
			UncertainRange<PhysicalQuantity> range = null;
			try
			{
				range = (UncertainRange<PhysicalQuantity>)new UrgPqElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
				Assert.Fail("Should fail trying to add quantities of different units");
			}
			catch (ArgumentException e)
			{
				// expected
				Assert.AreEqual("Can't add two quantities of different units: m and h", e.Message, "syntax error");
			}
			Assert.IsNull(range, "null");
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("URG<PQ.BASIC>", null, SpecificationVersion.R02_04_02, null, null, null, null, null, null, 
				null, false);
		}
	}
}
