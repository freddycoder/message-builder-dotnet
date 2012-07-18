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
	public class AnyElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<range xsi:type=\"URG\" specializationType=\"URG_PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
				 + "<low value=\"123\" unit=\"kg\" />" + "<high value=\"567\" unit=\"kg\" />" + "</range>");
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new AnyElementParser().Parse(ParserContextImpl
				.Create("ANY.LAB", typeof(object), null, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), node, null
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
		public virtual void TestParseAbsentSpecializationTypeUrgExampleFromChiDocs()
		{
			XmlNode node = CreateNode("<range xsi:type=\"URG_PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" + "<low xsi:type=\"PQ\" specializationType=\"PQ.HEIGHTWEIGHT\" value=\"123\" unit=\"kg\" />"
				 + "<high xsi:type=\"PQ\" specializationType=\"PQ.HEIGHTWEIGHT\" value=\"567\" unit=\"kg\" />" + "</range>");
			XmlToModelResult xmlToModelResult = new XmlToModelResult();
			BareANY parseResult = new AnyElementParser().Parse(ParserContextImpl.Create("ANY.LAB", typeof(object), null, null, null, 
				Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), node, xmlToModelResult);
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)parseResult.BareValue;
			Assert.IsTrue(xmlToModelResult.GetHl7Errors().IsEmpty(), "no errors");
			Assert.IsNotNull(range, "null");
			Assert.AreEqual(StandardDataType.URG_PQ, parseResult.DataType, "type");
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
			XmlNode node = CreateNode("<value xsi:type=\"PQ\" specializationType=\"PQ.LAB\" value=\"80\" unit=\"mg/dL\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>"
				);
			BareANY result = new AnyElementParser().Parse(ParserContextImpl.Create("ANY.LAB", typeof(object), null, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), node, null);
			Assert.IsNotNull(result, "null");
			Assert.AreEqual(StandardDataType.PQ_LAB, result.DataType, "type");
			Assert.IsNotNull(result.BareValue, "null");
			Assert.AreEqual("mg/dL", ((PhysicalQuantity)result.BareValue).Unit.CodeValue, "unit");
			Assert.AreEqual(new BigDecimal(80), ((PhysicalQuantity)result.BareValue).Quantity, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithMissingSpecializationType()
		{
			XmlNode node = CreateNode("<value xsi:type=\"PQ\" value=\"80\" unit=\"mg/dL\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>"
				);
			XmlToModelResult xmlToModelResult = new XmlToModelResult();
			BareANY result = new AnyElementParser().Parse(ParserContextImpl.Create("ANY.LAB", typeof(object), null, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), node, xmlToModelResult);
			Assert.AreEqual(1, xmlToModelResult.GetHl7Errors().Count, "has error");
			Assert.AreEqual("Cannot support properties of type \"PQ\" for \"ANY.LAB\"", xmlToModelResult.GetHl7Errors()[0].GetMessage
				(), "error message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestReportErrorForMissingSpecializationType()
		{
			XmlToModelResult xmlResult = new XmlToModelResult();
			XmlNode node = CreateNode("<range><low value=\"123\" unit=\"m\" /><high value=\"567\" unit=\"HOUR\" /></range>");
			object range = new AnyElementParser().Parse(null, node, xmlResult).BareValue;
			Assert.IsNull(range, "null");
			Assert.IsFalse(xmlResult.GetHl7Errors().IsEmpty(), "has error");
			Assert.AreEqual(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, xmlResult.GetHl7Errors()[0].GetHl7ErrorCode(), "error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRetainsProperDatatypeForSpecializationTypeWhenAnyOnlySpecifiesOkToUseAbstractType()
		{
			XmlNode node = CreateNode("<value xsi:type=\"IVL_PQ\" specializationType=\"IVL_PQ.LAB\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
				 + "<low specializationType=\"PQ.LAB\" value=\"0.0\" unit=\"mg/dL\"/>" + "<high specializationType=\"PQ.LAB\" value=\"0.5\" unit=\"mg/dL\"/>"
				 + "</value>");
			BareANY result = new AnyElementParser().Parse(ParserContextImpl.Create("ANY.LAB", typeof(object), null, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), node, null);
			Assert.IsNotNull(result, "null");
			Assert.AreEqual(StandardDataType.IVL_PQ, result.DataType, "type");
			Assert.IsNotNull(result.BareValue, "null");
			Interval<PhysicalQuantity> interval = (Interval<PhysicalQuantity>)result.BareValue;
			Assert.AreEqual("mg/dL", interval.Low.Unit.CodeValue, "low unit");
			Assert.AreEqual(new BigDecimal(0).SetScale(1), interval.Low.Quantity, "low quantity");
			Assert.AreEqual("mg/dL", interval.High.Unit.CodeValue, "high unit");
			Assert.AreEqual(new BigDecimal(0.5), interval.High.Quantity, "high quantity");
		}
	}
}
