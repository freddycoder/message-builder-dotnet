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
	public class GtsBoundedPivlElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseNullFlavor()
		{
			XmlNode node = CreateNode("<effectiveTime nullFlavor=\"NI\"></effectiveTime>");
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			GTS gts = (GTS)new GtsBoundedPivlElementParser().Parse(context, node, this.xmlResult);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, gts.NullFlavor, "null flavor"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseValidInformation()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "  <comp operator=\"I\">" + "    <low specializationType=\"TS.FULLDATE\" value=\"20050803\"/>"
				 + "    <width specializationType=\"TS.FULLDATE\" value=\"3\" unit=\"wk\"/>" + "  </comp>" + "  <comp>" + "    <frequency>"
				 + "      <numerator specializationType=\"INT.NONNEG\" value=\"3\"/>" + "      <denominator specializationType=\"PQ.TIME\" value=\"1\" unit=\"d\"/>"
				 + "    </frequency>" + "  </comp>" + "</effectiveTime>");
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			GeneralTimingSpecification result = (GeneralTimingSpecification)new GtsBoundedPivlElementParser().Parse(context, node, this
				.xmlResult).BareValue;
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(new BigDecimal("3"), ((DateDiff)result.Duration.Width).ValueAsPhysicalQuantity.Quantity, "interval width value"
				);
			Assert.AreEqual("wk", ((DateDiff)result.Duration.Width).Unit.CodeValue, "interval width unit");
			Assert.AreEqual(3, result.Frequency.Repetitions, "frequency times");
			Assert.AreEqual(new BigDecimal("1"), result.Frequency.Quantity.Quantity, "frequency period value");
			Assert.AreEqual("d", result.Frequency.Quantity.Unit.CodeValue, "frequency period unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseValidInformationForSk()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "  <comp operator=\"I\">" + "    <low specializationType=\"TS.FULLDATE\" value=\"20050803\"/>"
				 + "    <width specializationType=\"TS.FULLDATE\" value=\"3\" unit=\"wk\"/>" + "  </comp>" + "  <comp>" + "    <frequency>"
				 + "      <numerator specializationType=\"INT.NONNEG\" value=\"3\"/>" + "      <denominator>" + "        <low unit=\"d\" value=\"3\"/>"
				 + "        <high unit=\"d\" value=\"10\"/>" + "      </denominator>" + "    </frequency>" + "  </comp>" + "</effectiveTime>"
				);
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V01R04_2_SK, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			GeneralTimingSpecification result = (GeneralTimingSpecification)new GtsBoundedPivlElementParser().Parse(context, node, this
				.xmlResult).BareValue;
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(new BigDecimal("3"), ((DateDiff)result.Duration.Width).ValueAsPhysicalQuantity.Quantity, "interval width value"
				);
			Assert.AreEqual("wk", ((DateDiff)result.Duration.Width).Unit.CodeValue, "interval width unit");
			Assert.IsTrue(result.Frequency is PeriodicIntervalTimeSk, "frequency is for SK");
			Assert.AreEqual(3, result.Frequency.Repetitions, "frequency times");
			Assert.AreEqual(new BigDecimal("3"), ((PeriodicIntervalTimeSk)result.Frequency).GetQuantitySk().Low.Quantity, "low frequency period value"
				);
			Assert.AreEqual("d", ((PeriodicIntervalTimeSk)result.Frequency).GetQuantitySk().Low.Unit.CodeValue, "low frequency period unit"
				);
			Assert.AreEqual(new BigDecimal("10"), ((PeriodicIntervalTimeSk)result.Frequency).GetQuantitySk().High.Quantity, "high frequency period value"
				);
			Assert.AreEqual("d", ((PeriodicIntervalTimeSk)result.Frequency).GetQuantitySk().High.Unit.CodeValue, "high frequency period unit"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseValidInformationWhenMissingInnerSpecializationTypes()
		{
			XmlNode node = CreateNode("<effectiveTime specializationType=\"GTS.BOUNDEDPIVL\">" + "  <comp operator=\"I\">" + "    <low value=\"20050803\"/>"
				 + "    <width value=\"3\" unit=\"wk\"/>" + "  </comp>" + "  <comp>" + "    <frequency>" + "      <numerator value=\"3\"/>"
				 + "      <denominator value=\"1\" unit=\"d\"/>" + "    </frequency>" + "  </comp>" + "</effectiveTime>");
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			GeneralTimingSpecification result = (GeneralTimingSpecification)new GtsBoundedPivlElementParser().Parse(context, node, this
				.xmlResult).BareValue;
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(new BigDecimal("3"), ((DateDiff)result.Duration.Width).ValueAsPhysicalQuantity.Quantity, "interval width value"
				);
			Assert.AreEqual("wk", ((DateDiff)result.Duration.Width).Unit.CodeValue, "interval width unit");
			Assert.AreEqual(3, result.Frequency.Repetitions, "frequency times");
			Assert.AreEqual(new BigDecimal("1"), result.Frequency.Quantity.Quantity, "frequency period value");
			Assert.AreEqual("d", result.Frequency.Quantity.Unit.CodeValue, "frequency period unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldDetectIncorrectElementType()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "  <comp operator=\"I\">" + "    <low specializationType=\"TS.FULLDATE\" value=\"20050803\"/>"
				 + "    <width specializationType=\"TS.FULLDATE\" value=\"3\" unit=\"wk\"/>" + "  </comp>" + "  <fred>" + "    <frequency>"
				 + "      <numerator specializationType=\"INT.NONNEG\" value=\"3\"/>" + "      <denominator specializationType=\"PQ.TIME\" value=\"1\" unit=\"d\"/>"
				 + "    </frequency>" + "  </fred>" + "</effectiveTime>");
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			new GtsBoundedPivlElementParser().Parse(context, node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
		}
	}
}
