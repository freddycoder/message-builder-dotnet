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
	public class PqElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			PQ pq = (PQ)new PqElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsNull(pq.Value, "PhysicalQuantity");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, pq.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("PQ.BASIC", typeof(PhysicalQuantity), SpecificationVersion.V02R02, null, null, null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext(), node, this.xmlResult).
				BareValue;
			Assert.IsNull(physicalQuantity, "PhysicalQuantity");
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCorrectAttributeNodes()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext(), node, this.xmlResult).
				BareValue;
			Assert.IsNull(physicalQuantity, "PhysicalQuantity");
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributes()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext(), node, this.xmlResult).
				BareValue;
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributesWithElementClosure()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\"></something>");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext(), node, this.xmlResult).
				BareValue;
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributesNoUnit()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext(), node, this.xmlResult).
				BareValue;
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.IsNotNull(physicalQuantity.Quantity, "value");
			Assert.IsNull(physicalQuantity.Unit, "value");
			Assert.IsTrue(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"monkey\" />");
			new PqElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyIntegerDigitsValueAttribute()
		{
			string element = "<something value=\"123456789012.12\" unit=\"kg\"/>";
			XmlNode node = CreateNode(element);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext(), node, this.xmlResult).
				BareValue;
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("PhysicalQuantity (<something unit=\"kg\" value=\"123456789012.12\"/>) can contain a maximum of 11 integer places"
				, this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyDecimalDigitsValueAttribute()
		{
			string element = "<something value=\"12345678901.1234\" unit=\"kg\"/>";
			XmlNode node = CreateNode(element);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext(), node, this.xmlResult).
				BareValue;
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("PhysicalQuantity (<something unit=\"kg\" value=\"12345678901.1234\"/>) can contain a maximum of 2 decimal places"
				, this.xmlResult.GetHl7Errors()[0].GetMessage());
		}
	}
}
