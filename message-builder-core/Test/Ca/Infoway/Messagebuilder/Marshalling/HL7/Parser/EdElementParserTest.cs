using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class EdElementParserTest : CeRxDomainValueTestCase
	{
		private static readonly string TEXT_SIMPLE = Base64.EncodeBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("This is a test"
			));

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			ED<EncapsulatedData> ed = (ED<EncapsulatedData>)new EdElementParser().Parse(CreateContext(), node, null);
			Assert.IsNull(ed.Value, "data");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ed.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("ED", typeof(EncapsulatedData), SpecificationVersion.NEWFOUNDLAND, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Assert.AreEqual(null, new EdElementParser().Parse(null, node, null).BareValue, "data");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeNoCompression()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\">" + TEXT_SIMPLE + "</something>");
			EncapsulatedData data = (EncapsulatedData)new EdElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(TEXT_SIMPLE, System.Text.ASCIIEncoding.ASCII.GetString(data.Content), "content");
			Assert.AreEqual(MediaType.PLAIN_TEXT, data.MediaType, "media type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithCompression()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\" representation=\"B64\">" + TEXT_SIMPLE + "</something>");
			EncapsulatedData data = (EncapsulatedData)new EdElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual("This is a test", System.Text.ASCIIEncoding.ASCII.GetString(data.Content), "content");
			Assert.AreEqual(MediaType.PLAIN_TEXT, data.MediaType, "media type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "<shines/>" + "</something>");
			try
			{
				new EdElementParser().Parse(null, node, null);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException)
			{
			}
		}

		// expected
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"ENG\" mediaType=\"text/xml\" representation=\"B64\">" + "H4sIAAAAAAAAALOpyM2xS8vPt9EHMQATOK6nDgAAAA==</name>"
				);
			CompressedData data = (CompressedData)new EdElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(MediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("ENG", data.Language, "language");
			Assert.AreEqual("<xml>foo</xml>", BytesUtil.AsString(data.UncompressedContent), "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlEmptyData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"ENG\" mediaType=\"text/xml\" representation=\"B64\">" + "H4sIAAAAAAAAAAMAAAAAAAAAAAA=</name>"
				);
			CompressedData data = (CompressedData)new EdElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(MediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("ENG", data.Language, "language");
			Assert.AreEqual(string.Empty, BytesUtil.AsString(data.UncompressedContent), "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlNullData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"ENG\" mediaType=\"text/xml\" representation=\"B64\"></name>"
				);
			CompressedData data = (CompressedData)new EdElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(MediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("ENG", data.Language, "language");
			Assert.IsNull(data.UncompressedContent, "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedTextData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"ENG\" mediaType=\"text/plain\" representation=\"B64\">" + 
				"H4sIAAAAAAAAALOpyM2xS8vPt9EHMQATOK6nDgAAAA==</name>");
			CompressedData data = (CompressedData)new EdElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual(MediaType.PLAIN_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("ENG", data.Language, "language");
			Assert.AreEqual("<xml>foo</xml>", BytesUtil.AsString(data.UncompressedContent), "content");
		}

		private ParseContext CreateEdContext()
		{
			return ParserContextImpl.Create("ED.DOCORREF", typeof(string), SpecificationVersion.V02R02, null, null, null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			XmlNode node = CreateNode("<something>this is a text node</something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateEdContext(), node, null).BareValue;
			Assert.AreEqual("this is a text node", System.Text.ASCIIEncoding.ASCII.GetString(value.Content), "signature");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\">text value</something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateEdContext(), node, null).BareValue;
			Assert.AreEqual("text value", BytesUtil.AsString(value.Content), "proper text returned");
		}
	}
}
