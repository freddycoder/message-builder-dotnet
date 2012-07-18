using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class ScElementParserTest : CeRxDomainValueTestCase
	{
		private static string EMPTY_STRING = string.Empty;

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			SC<Code> sc = (SC<Code>)new ScElementParser<Code>().Parse(CreateContext(), node, null);
			Assert.IsNull(sc.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, sc.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("SC", typeof(CodedString<Code>), SpecificationVersion.NEWFOUNDLAND, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			CodedString<Code> result = (CodedString<Code>)new ScElementParser<Code>().Parse(null, node, null).BareValue;
			Assert.AreEqual(EMPTY_STRING, result.Value, "empty string returned");
			Assert.AreEqual(null, result.Code, "null code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			XmlNode node = CreateNode("<something>text value</something>");
			CodedString<Code> result = (CodedString<Code>)new ScElementParser<Code>().Parse(null, node, null).BareValue;
			Assert.AreEqual("text value", result.Value, "proper text returned");
			Assert.AreEqual(null, result.Code, "null code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" mediaType=\"text/plain\">text value</something>");
			CodedString<Code> result = (CodedString<Code>)new ScElementParser<Code>().Parse(null, node, null).BareValue;
			Assert.AreEqual("text value", result.Value, "proper text returned");
			Assert.AreEqual(null, result.Code, "null code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithCodeAttributes()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" mediaType=\"text/plain\" code=\"AB\">text value</something>"
				);
			CodedString<Code> result = (CodedString<Code>)new ScElementParser<Code>().Parse(ParserContextImpl.Create("SC", new CodedString
				<State>(null, null).GetType(), SpecificationVersion.V02R02, null, null, null), node, null).BareValue;
			Assert.AreEqual("text value", result.Value, "proper text returned");
			Assert.AreEqual(null, result.Code, "null code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "<shines/>" + "</something>");
			try
			{
				new ScElementParser<Code>().Parse(null, node, null);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected SC node to have at most one child", e.Message, "proper exception returned");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNotATextNode()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new ScElementParser<Code>().Parse(null, node, null);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected SC node to have a text node", e.Message, "proper exception returned");
			}
		}
	}
}
