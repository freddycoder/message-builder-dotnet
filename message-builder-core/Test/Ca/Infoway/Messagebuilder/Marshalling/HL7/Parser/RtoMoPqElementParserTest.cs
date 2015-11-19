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
	public class RtoMoPqElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			RTO<Money, PhysicalQuantity> rto = (RTO<Money, PhysicalQuantity>)new RtoMoPqElementParser().Parse(CreateContext(), node, 
				null);
			Assert.IsNull(rto.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, rto.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("RTO<PQ.DRUG,PQ.DRUG>", typeof(Ratio<object, object>), SpecificationVersion.V02R02, null, 
				null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Ratio<Money, PhysicalQuantity> ratio = (Ratio<Money, PhysicalQuantity>)new RtoMoPqElementParser().Parse(CreateContext(), 
				node, this.xmlResult).BareValue;
			Assert.IsNotNull(ratio, "ratio");
			Assert.IsNull(ratio.Numerator, "numerator");
			Assert.IsNull(ratio.Denominator, "denominator");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributes()
		{
			XmlNode node = CreateNode("<something><numerator value=\"1234.45\" currency=\"CAD\"/><denominator value=\"2345.67\" unit=\"mL\" /></something>"
				);
			Ratio<Money, PhysicalQuantity> ratio = (Ratio<Money, PhysicalQuantity>)new RtoMoPqElementParser().Parse(CreateContext(), 
				node, this.xmlResult).BareValue;
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
			new RtoMoPqElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}
		// no currency; monkey is invalid value
	}
}
