using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class RtoMoPqR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			RTO<Money, PhysicalQuantity> rto = (RTO<Money, PhysicalQuantity>)new RtoMoPqR2ElementParser().Parse(CreateContext(), node
				, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(rto.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, rto.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("RTO<MO,PQ>", typeof(Ratio<object, object>), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Ratio<Money, PhysicalQuantity> ratio = (Ratio<Money, PhysicalQuantity>)new RtoMoPqR2ElementParser().Parse(CreateContext()
				, node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNotNull(ratio, "ratio");
			Assert.IsNull(ratio.Numerator, "numerator");
			Assert.IsNull(ratio.Denominator, "denominator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributes()
		{
			XmlNode node = CreateNode("<something><numerator value=\"1234.45\" currency=\"CAD\"/><denominator value=\"2345.67\" unit=\"mL\" /></something>"
				);
			Ratio<Money, PhysicalQuantity> ratio = (Ratio<Money, PhysicalQuantity>)new RtoMoPqR2ElementParser().Parse(CreateContext()
				, node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(ratio, "ratio");
			Assert.AreEqual(new BigDecimal("1234.45"), ratio.Numerator.Amount, "numerator");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR.CodeValue, ratio.Numerator.Currency.
				CodeValue, "numerator unit");
			Assert.AreEqual(new BigDecimal("2345.67"), ratio.Denominator.Quantity, "denominator");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLILITRE.CodeValue, ratio.Denominator
				.Unit.CodeValue, "denominator unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something><numerator value=\"monkey\" /><denominator value=\"2345.67\" /></something>");
			new RtoMoPqR2ElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}
	}
}
