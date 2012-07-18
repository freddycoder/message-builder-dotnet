using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class StElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			ST st = (ST)new StElementParser().Parse(CreateStContext("ST"), node, this.xmlResult);
			Assert.IsNull(st.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, st.NullFlavor, "null flavor");
		}

		private ParseContext CreateStContext(string type)
		{
			return ParserContextImpl.Create(type, typeof(string), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, 25);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.AreEqual(string.Empty, new StElementParser().Parse(CreateStContext("ST"), node, this.xmlResult).BareValue, "null returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRespectMaximumLength()
		{
			ParseContext context = CreateStContext("ST");
			XmlNode node = CreateNode("<something>This is a fairly long value; too long, in fact, for the field</something>");
			Assert.AreEqual("This is a fairly long val", new StElementParser().Parse(context, node, this.xmlResult).BareValue, "null returned"
				);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
			System.Console.Out.WriteLine(this.xmlResult.GetHl7Errors()[0].GetMessage());
			Assert.AreEqual("The specified string (\"This is a fairly long value; too long, in fact,...\") exceeds the maximum length of 25.  The string has been truncated."
				, this.xmlResult.GetHl7Errors()[0].GetMessage(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseTextNode()
		{
			XmlNode node = CreateNode("<something>text value</something>");
			Assert.AreEqual("text value", new StElementParser().Parse(CreateStContext("ST"), node, this.xmlResult).BareValue, "proper text returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something language=\"fr-CA\" representation=\"TXT\" mediaType=\"text/plain\">text value</something>"
				);
			ST result = (ST)new StElementParser().Parse(CreateStContext("ST.LANG"), node, this.xmlResult);
			Assert.AreEqual("text value", result.Value, "proper text returned");
			Assert.AreEqual("fr-CA", result.Language, "proper language returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "<shines/>" + "</something>");
			try
			{
				new StElementParser().Parse(CreateStContext("ST"), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected ST node to have at most one child", e.Message, "proper exception returned");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseNotATextNode()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new StElementParser().Parse(CreateStContext("ST"), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected ST node to have a text node", e.Message, "proper exception returned");
			}
		}
	}
}
