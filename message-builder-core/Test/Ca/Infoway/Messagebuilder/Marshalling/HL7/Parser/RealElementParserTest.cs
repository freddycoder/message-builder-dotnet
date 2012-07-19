using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class RealElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			REAL real = (REAL)new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult);
			Assert.IsNull(real.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, real.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext(string type)
		{
			return ParserContextImpl.Create(type, typeof(BigDecimal), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.IsNull(new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult).BareValue, "null returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			Assert.IsNull(new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult).BareValue, "null returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValid()
		{
			XmlNode node = CreateNode("<something value=\"0.2345\" />");
			Assert.AreEqual(new BigDecimal("0.2345"), new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult)
				.BareValue, "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidRealCoord()
		{
			XmlNode node = CreateNode("<something value=\"78.2345\" />");
			Assert.AreEqual(new BigDecimal("78.2345"), new RealElementParser().Parse(CreateContext("REAL.COORD"), node, this.xmlResult
				).BareValue, "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidZero()
		{
			XmlNode node = CreateNode("<something value=\"0\" />");
			Assert.AreEqual(new BigDecimal(0), new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult).BareValue
				, "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidNegative()
		{
			XmlNode node = CreateNode("<something value=\"-1\" />");
			Assert.AreEqual(new BigDecimal("-1"), new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult).BareValue
				, "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidPlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"value\" value=\"1345\" />");
			Assert.AreEqual(new BigDecimal("1345"), new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult).BareValue
				, "correct value returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected REAL.CONF node to have no children", e.Message, "proper exception returned");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"monkey\" />");
			new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "errors");
			Assert.AreEqual("Value \"monkey\" of type REAL.CONF is not a valid number", this.xmlResult.GetHl7Errors()[0].GetMessage()
				, "error message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute1()
		{
			XmlNode node = CreateNode("<something value=\"1.11\" />");
			new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "errors");
			Assert.AreEqual("Value 1.11 of type REAL.CONF must be between 0 and 1.", this.xmlResult.GetHl7Errors()[0].GetMessage(), "error message"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute2()
		{
			XmlNode node = CreateNode("<something value=\".11\" />");
			new RealElementParser().Parse(CreateContext("REAL.CONF"), node, this.xmlResult);
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count, "errors");
		}
	}
}
