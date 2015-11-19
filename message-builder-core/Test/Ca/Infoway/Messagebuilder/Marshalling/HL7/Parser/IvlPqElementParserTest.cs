using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class IvlPqElementParserTest : CeRxDomainValueTestCase
	{
		private static readonly string mL = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLILITRE.CodeValue;

		private XmlToModelResult result;

		private IvlPqElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.result = new XmlToModelResult();
			this.parser = new IvlPqElementParser();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Interval<PhysicalQuantity> Parse(XmlNode node)
		{
			return (Interval<PhysicalQuantity>)this.parser.Parse(ParseContextImpl.Create("IVL<PQ.BASIC>", typeof(Interval<object>), SpecificationVersion
				.V02R02, null, null, null, null, null, false), Arrays.AsList(node), this.result).BareValue;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHigh()
		{
			XmlNode node = CreateNode("<name><low unit=\"mL\" value=\"1000\"/><high unit=\"mL\" value=\"2000\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(1000, interval.Low.Quantity.Value, "low - value");
			Assert.AreEqual(mL, interval.Low.Unit.CodeValue, "low - unit");
			Assert.AreEqual(2000, interval.High.Quantity.Value, "high - value");
			Assert.AreEqual(mL, interval.High.Unit.CodeValue, "high - unit");
			Assert.AreEqual(1500, interval.Centre.Quantity.Value, "centre - value");
			Assert.AreEqual(mL, interval.Centre.Unit.CodeValue, "centre - unit");
			Assert.AreEqual(1000, interval.Width.Value.Quantity.Value, "width - value");
			Assert.AreEqual(mL, interval.Width.Value.Unit.CodeValue, "width - unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLow()
		{
			XmlNode node = CreateNode("<name><low unit=\"mL\" value=\"1000\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// high must be provided
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(1000, interval.Low.Quantity.Value, "low - value");
			Assert.AreEqual(mL, interval.Low.Unit.CodeValue, "low - unit");
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNull(interval.Width, "width");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowInvalidBothNull()
		{
			XmlNode node = CreateNode("<name><low nullFlavor=\"OTH\"/><high nullFlavor=\"NI\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// low and high can't both be null
			Assert.IsNotNull(interval, "null");
			Assert.IsNull(interval.Low);
			Assert.IsNull(interval.High);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, interval.LowNullFlavor);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, interval.HighNullFlavor);
		}
	}
}
