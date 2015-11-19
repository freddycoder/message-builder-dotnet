using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class StR2ElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			ST st = (ST)new StR2ElementParser().Parse(CreateStContext("ST"), node, this.xmlResult);
			Assert.IsNull(st.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, st.NullFlavor, "null flavor");
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		private ParseContext CreateStContext(string type)
		{
			return CreateStContext(type, 25);
		}

		private ParseContext CreateStContext(string type, int length)
		{
			return ParseContextImpl.Create(type, typeof(string), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, null, null, length, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.AreEqual(string.Empty, new StR2ElementParser().Parse(CreateStContext("ST"), node, this.xmlResult).BareValue, "null returned"
				);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRespectMaximumLength()
		{
			ParseContext context = CreateStContext("ST");
			XmlNode node = CreateNode("<something>This is a fairly long value; too long, in fact, for the field</something>");
			Assert.AreEqual("This is a fairly long val", new StR2ElementParser().Parse(context, node, this.xmlResult).BareValue, "null returned"
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
			XmlNode node = CreateNode("<something mediaType=\"text/plain\" representation=\"TXT\">text value</something>");
			Assert.AreEqual("text value", new StR2ElementParser().Parse(CreateStContext("ST"), node, this.xmlResult).BareValue, "proper text returned"
				);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseTextNodeAsCdata()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\" representation=\"TXT\"><![CDATA[<cats think they're > humans & dogs 99% of the time/>]]></something>"
				);
			BareANY parseResult = new StR2ElementParser().Parse(CreateStContext("ST", 100), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(parseResult is ST);
			Assert.IsTrue(((ST)parseResult).IsCdata, "noted as cdata");
			Assert.AreEqual("<cats think they're > humans & dogs 99% of the time/>", parseResult.BareValue, "proper text returned");
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseTextNodeWithEmptyCdata()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\" representation=\"TXT\"><![CDATA[]]></something>");
			BareANY parseResult = new StR2ElementParser().Parse(CreateStContext("ST"), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(parseResult is ST);
			Assert.IsTrue(((ST)parseResult).IsCdata, "noted as cdata");
			Assert.AreEqual(string.Empty, parseResult.BareValue, "proper text returned");
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseTextNodeWithSpecialCharactersNotCdata()
		{
			XmlNode node = CreateNode("<something>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</something>"
				);
			BareANY parseResult = new StR2ElementParser().Parse(CreateStContext("ST", 100), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(parseResult is ST);
			Assert.IsFalse(((ST)parseResult).IsCdata, "not cdata");
			Assert.AreEqual("<cats think they're > humans & dogs 99% of the time/>", parseResult.BareValue, "proper text returned");
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something language=\"fr-CA\" representation=\"TXT\" mediaType=\"text/plain\">text value</something>"
				);
			ST result = (ST)new StR2ElementParser().Parse(CreateStContext("ST"), node, this.xmlResult);
			Assert.AreEqual("text value", result.Value, "proper text returned");
			Assert.AreEqual("fr-CA", result.Language, "proper language returned");
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "<shines/>" + "</something>");
			try
			{
				new StR2ElementParser().Parse(CreateStContext("ST"), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected ST node to have at most one child", e.Message, "proper exception returned");
			}
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseNotATextNode()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "</something>");
			try
			{
				new StR2ElementParser().Parse(CreateStContext("ST"), node, this.xmlResult);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected ST node to have a text node", e.Message, "proper exception returned");
			}
			Assert.IsTrue(this.xmlResult.IsValid());
		}
	}
}
