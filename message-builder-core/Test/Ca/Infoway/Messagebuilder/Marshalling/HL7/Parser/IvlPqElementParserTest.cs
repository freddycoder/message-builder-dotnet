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
		private static readonly string mL = Ca.Infoway.Messagebuilder.Datatype.Lang.UnitsOfMeasureCaseSensitive.MILLILITRE.CodeValue;

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
			return (Interval<PhysicalQuantity>)this.parser.Parse(ParserContextImpl.Create("IVL<PQ>", typeof(Interval<object>), SpecificationVersion
				.V02R02, null, null, null), Arrays.AsList(node), this.result).BareValue;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHigh()
		{
			XmlNode node = CreateNode("<name><low unit=\"ml\" value=\"1000\"/><high unit=\"ml\" value=\"2000\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
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
		public virtual void TestParseLowWidth()
		{
			XmlNode node = CreateNode("<name><low unit=\"ml\" value=\"1000\"/><width unit=\"ml\" value=\"1000\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
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
			XmlNode node = CreateNode("<name><low unit=\"ml\" value=\"1000\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(1000, interval.Low.Quantity.Value, "low - value");
			Assert.AreEqual(mL, interval.Low.Unit.CodeValue, "low - unit");
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNull(interval.Width, "width");
		}
	}
}
