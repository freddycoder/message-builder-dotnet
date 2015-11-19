using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class AnyR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseStTextNodeAsCdata()
		{
			XmlNode node = CreateNode("<something xsi:type=\"ST\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><![CDATA[<cats think they're > humans & dogs 99% of the time/>]]></something>"
				);
			ParseContext context = ParseContextImpl.Create("ANY", typeof(object), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, null, null, false);
			BareANY parseResult = new AnyR2ElementParser().Parse(context, node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(StandardDataType.ST, parseResult.DataType);
			Assert.IsTrue(((ANYMetaData)parseResult).IsCdata, "noted as cdata");
			Assert.AreEqual("<cats think they're > humans & dogs 99% of the time/>", parseResult.BareValue, "proper text returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAnyWithTypeInOuterElement()
		{
			XmlNode node = CreateNode("<range xsi:type=\"IVL_PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" + "<low value=\"123\" unit=\"kg\" />"
				 + "<high value=\"567\" unit=\"kg\" />" + "</range>");
			Interval<PhysicalQuantity> range = (Interval<PhysicalQuantity>)new AnyR2ElementParser().Parse(ParseContextImpl.Create("ANY"
				, typeof(object), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, 
				null, null, false), node, this.xmlResult).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAnyIvlTypeInInnerElements()
		{
			XmlNode node = CreateNode("<range xsi:type=\"IVL\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" + "<low xsi:type=\"PQ\" value=\"123\" unit=\"kg\" />"
				 + "<high xsi:type=\"PQ\" value=\"567\" unit=\"kg\" />" + "</range>");
			BareANY parseResult = new AnyR2ElementParser().Parse(ParseContextImpl.Create("ANY", typeof(object), SpecificationVersion.
				R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, null, false), node, this.xmlResult
				);
			Interval<PhysicalQuantity> range = (Interval<PhysicalQuantity>)parseResult.BareValue;
			System.Console.Out.WriteLine(this.xmlResult.GetHl7Errors());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(range, "null");
			Assert.AreEqual(StandardDataType.IVL_PQ, parseResult.DataType, "type");
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRetainsProperDatatype()
		{
			XmlNode node = CreateNode("<value xsi:type=\"PQ\" value=\"80\" unit=\"pg/mL\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>"
				);
			BareANY result = new AnyR2ElementParser().Parse(ParseContextImpl.Create("ANY", typeof(object), SpecificationVersion.V02R02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(result, "null");
			Assert.AreEqual(StandardDataType.PQ, result.DataType, "type");
			Assert.IsNotNull(result.BareValue, "null");
			Assert.AreEqual("pg/mL", ((PhysicalQuantity)result.BareValue).Unit.CodeValue, "unit");
			Assert.AreEqual(new BigDecimal(80), ((PhysicalQuantity)result.BareValue).Quantity, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseStWithLanguage()
		{
			XmlNode node = CreateNode("<value xsi:type=\"ST\" language=\"fr-CA\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">some text</value>"
				);
			BareANY result = new AnyR2ElementParser().Parse(ParseContextImpl.Create("ANY", typeof(object), SpecificationVersion.V02R02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(result, "null");
			Assert.AreEqual(StandardDataType.ST, result.DataType, "type");
			Assert.IsNotNull(result.BareValue, "null");
			Assert.AreEqual("some text", ((string)result.BareValue), "string");
			Assert.AreEqual("fr-CA", ((ANYImpl<object>)result).Language, "language");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithMissingSpecializationType()
		{
			XmlNode node = CreateNode("<value xsi:type=\"PQ\" value=\"80\" unit=\"pg/mL\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>"
				);
			BareANY result = new AnyR2ElementParser().Parse(ParseContextImpl.Create("ANY.LAB", typeof(object), null, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, null, null, false), node, this.xmlResult);
			Assert.IsNotNull(result);
			Assert.IsNull(result.BareValue);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "has error");
			Assert.AreEqual("Cannot support properties of type \"PQ\" for \"ANY.LAB\"", this.xmlResult.GetHl7Errors()[0].GetMessage()
				, "error message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestReportErrorForMissingSpecializationType()
		{
			XmlToModelResult xmlResult = new XmlToModelResult();
			XmlNode node = CreateNode("<range><low value=\"123\" unit=\"m\" /><high value=\"567\" unit=\"HOUR\" /></range>");
			object range = new AnyR2ElementParser().Parse(null, node, xmlResult).BareValue;
			Assert.IsNull(range, "null");
			Assert.IsFalse(xmlResult.GetHl7Errors().IsEmpty(), "has error");
			Assert.AreEqual(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, xmlResult.GetHl7Errors()[0].GetHl7ErrorCode(), "error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRetainsProperDatatypeForSpecializationTypeWhenAnyOnlySpecifiesOkToUseAbstractType()
		{
			XmlNode node = CreateNode("<value xsi:type=\"IVL_PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" + "<low value=\"0.0\" unit=\"pg/mL\"/>"
				 + "<high value=\"0.5\" unit=\"pg/mL\"/>" + "</value>");
			BareANY result = new AnyR2ElementParser().Parse(ParseContextImpl.Create("ANY", typeof(object), SpecificationVersion.V02R02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, null, null, false), node, new XmlToModelResult()
				);
			Assert.IsNotNull(result, "null");
			Assert.AreEqual(StandardDataType.IVL_PQ, result.DataType, "type");
			Assert.IsNotNull(result.BareValue, "null");
			Interval<PhysicalQuantity> interval = (Interval<PhysicalQuantity>)result.BareValue;
			Assert.AreEqual("pg/mL", interval.Low.Unit.CodeValue, "low unit");
			Assert.AreEqual(new BigDecimal(0).SetScale(1), interval.Low.Quantity, "low quantity");
			Assert.AreEqual("pg/mL", interval.High.Unit.CodeValue, "high unit");
			Assert.AreEqual(new BigDecimal(0.5), interval.High.Quantity, "high quantity");
		}

		//	@Test
		//	public void testParseCdWithAllMetadata() throws Exception {
		//		Node node = createNode("<something code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" displayName=\"a display name\" specializationType=\"CD.LAB\">" +
		//				"<originalText>some original text</originalText>" +
		//				"<translation code=\"FRED\" codeSystem=\"1.2.3.4.5\" />" +
		//				"<translation code=\"WILMA\" codeSystem=\"1.2.3.4.5\" />" +
		//				"<translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\" />" +
		//				"<translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\" /></something>");
		//		
		//		BareANY cdAny = new AnyR2ElementParser().parse(
		//				ParserContextImpl.create("ANY", Object.class, SpecificationVersion.V02R02, null, null, ConformanceLevel.MANDATORY, null), 
		//				node, this.xmlResult);
		//
		//		assertTrue(this.xmlResult.isValid());
		//		assertNotNull(cdAny.getBareValue());
		//		assertTrue(cdAny.getBareValue() instanceof Code);
		//		
		//        Code value = (Code) cdAny.getBareValue();
		//		assertNotNull("main enum found", value);
		//		assertEquals("main code", "BARNEY", value.getCodeValue());
		//		
		//		ANYMetaData cd = (ANYMetaData) cdAny;
		//		assertFalse("translation enums found", cd.getTranslations().isEmpty());
		//		assertTrue("translation enums found", cd.getTranslations().size() == 4);
		//		assertEquals("error message count", 0, this.xmlResult.getHl7Errors().size());
		//		assertEquals("translation", "FRED", cd.getTranslations().get(0).getValue().getCodeValue());
		//		assertEquals("translation", "WILMA", cd.getTranslations().get(1).getValue().getCodeValue());
		//		assertEquals("translation", "BETTY", cd.getTranslations().get(2).getValue().getCodeValue());
		//		assertEquals("translation", "BAM_BAM", cd.getTranslations().get(3).getValue().getCodeValue());
		//	}
		//	
		//	@Test
		//	public void testParseCdWithNullFlavorAndMetaData() throws Exception {
		//		Node node = createNode("<something nullFlavor=\"UNK\" specializationType=\"CD.LAB\">" +
		//				"<originalText>some original text</originalText>" +
		//				"</something>");
		//		
		//		BareANY cdAny = new AnyR2ElementParser().parse(
		//				ParserContextImpl.create("ANY", Object.class, SpecificationVersion.V02R02, null, null, ConformanceLevel.POPULATED, null), 
		//				node, this.xmlResult);
		//
		//		assertTrue(this.xmlResult.isValid());
		//		assertNull(cdAny.getBareValue());
		//		assertEquals(NullFlavor.UNKNOWN, cdAny.getNullFlavor());
		//		
		//		ANYMetaData cd = (ANYMetaData) cdAny;
		//		assertEquals("some original text", cd.getOriginalText());
		//	}
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParsePqWithNullFlavor()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"ASKU\" xsi:type=\"PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" />"
				);
			BareANY pqAny = new AnyR2ElementParser().Parse(ParseContextImpl.Create("ANY", typeof(object), SpecificationVersion.R02_04_03
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, null, false), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pqAny.BareValue);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.ASKED_BUT_UNKNOWN, pqAny.NullFlavor);
		}
		//	@SuppressWarnings("unchecked")
		//	@Test
		//	public void testParseAnyAsRtoPqPq() throws Exception {
		//		// only ANY (i.e. no ANY sub-variants) supports RTO
		//		// note that this test is not correct in the way it specifies ST and XT
		//		Node node = createNode("<something specializationType=\"RTO_PQ.DRUG_PQ.DRUG\" xsi:type=\"RTO_PQ_PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><numerator value=\"1234.45\" unit=\"mg\"/><denominator value=\"2345.67\" unit=\"mL\" /></something>");
		//		ParseContext context = ParserContextImpl.create("ANY", Object.class, SpecificationVersion.R02_04_02, null, null, ConformanceLevel.MANDATORY, null);
		//		
		//		Object anyResult = new AnyR2ElementParser().parse(context, node, this.xmlResult).getBareValue();
		//		
		//		assertTrue(this.xmlResult.isValid());
		//        Ratio<PhysicalQuantity, PhysicalQuantity> ratio = (Ratio<PhysicalQuantity, PhysicalQuantity>) anyResult;
		//        
		//        assertNotNull("ratio", ratio);
		//        assertEquals("numerator", new BigDecimal("1234.45"), ratio.getNumerator().getQuantity());
		//        assertEquals("numerator unit", MILLIGRAM.getCodeValue(), ratio.getNumerator().getUnit().getCodeValue());
		//        assertEquals("denominator", new BigDecimal("2345.67"), ratio.getDenominator().getQuantity());
		//        assertEquals("denominator unit", MILLILITRE.getCodeValue(), ratio.getDenominator().getUnit().getCodeValue());
		//	}
		//	@SuppressWarnings("unchecked")
		//	@Test
		//	public void testParseAnyWithSpecializationTypeInOuterElement() throws Exception {
		//		Node node = createNode(
		//				"<range xsi:type=\"URG_PQ\" specializationType=\"URG_PQ.BASIC\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
		//					"<low value=\"123\" unit=\"kg\" />" +
		//					"<high value=\"567\" unit=\"kg\" />" +
		//				"</range>");
		//		UncertainRange<PhysicalQuantity> range = 
		//			(UncertainRange<PhysicalQuantity>)new AnyR2ElementParser().parse(
		//				ParserContextImpl.create("ANY.LAB", Object.class, SpecificationVersion.R02_04_02, null, null, ConformanceLevel.MANDATORY, null), 
		//				node, this.xmlResult).getBareValue();
		//		assertNotNull("null", range);
		//		assertTrue(this.xmlResult.isValid());
		//		assertEquals("low", new BigDecimal("123"), range.getLow().getQuantity());
		//		assertEquals("high", new BigDecimal("567"), range.getHigh().getQuantity());
		//		assertEquals("centre", new BigDecimal("345.0"), range.getCentre().getQuantity());
		//		assertEquals("width", new BigDecimal("444"), range.getWidth().getValue().getQuantity());
		//		assertEquals("representation", Representation.LOW_HIGH, range.getRepresentation());
		//	}
	}
}
