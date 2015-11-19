using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
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
			ED<EncapsulatedData> ed = (ED<EncapsulatedData>)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.
				V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(ed.Value, "data");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, ed.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext(string type, VersionNumber version)
		{
			return ParseContextImpl.Create(type, typeof(EncapsulatedData), version, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			BareANY parseResult = new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.V02R02), node, this.xmlResult
				);
			Assert.IsNull(parseResult.BareValue, "data");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		// missing mediaType and content
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeNoCompression()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\">" + TEXT_SIMPLE + "</something>");
			EncapsulatedData data = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.V02R02
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(TEXT_SIMPLE, data.Content, "content");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, data.MediaType, "media type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithCompression()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\" representation=\"B64\">" + TEXT_SIMPLE + "</something>");
			EncapsulatedData data = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.V02R02
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("This is a test", Unencode(System.Text.ASCIIEncoding.ASCII.GetBytes(data.Content)), "content");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, data.MediaType, "media type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestCommentsShouldNotCauseValidationErrors()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\">" + "<!--reference to CR DICOM image (PA view) -->" + "<reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/>"
				 + "This is a text node" + "</something>");
			new EdElementParser().Parse(CreateContext("ED", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(0, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseManyChildNodesAllowed()
		{
			XmlNode node = CreateNode("<something>" + "Some Text" + "<!-- a comment -->" + "And some more text" + "</something>");
			new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("MediaType must be provided and must be a value from x_DocumentMediaType. (<something>)", this.xmlResult.
				GetHl7Errors()[0].GetMessage());
			this.xmlResult.ClearErrors();
			node = CreateNode("<something>" + "Some Text" + "<!-- a comment -->" + "And some more text" + "</something>");
			new EdElementParser().Parse(CreateContext("ED.DOCREF", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(3, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("MediaType must be provided and must be a value from x_DocumentMediaType. (<something>)", this.xmlResult.
				GetHl7Errors()[0].GetMessage());
			Assert.AreEqual("Reference is mandatory. (<something>)", this.xmlResult.GetHl7Errors()[1].GetMessage());
			Assert.AreEqual("Content is not permitted for ED.DOCREF. (<something>)", this.xmlResult.GetHl7Errors()[2].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\" representation=\"B64\">" + 
				"H4sIAAAAAAAAALOpyM2xS8vPt9EHMQATOK6nDgAAAA==</name>");
			CompressedData data = (CompressedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("en-CA", data.Language, "language");
			Assert.AreEqual("<xml>foo</xml>", BytesUtil.AsString(data.UncompressedContent), "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlEmptyData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\" representation=\"B64\">" + 
				"H4sIAAAAAAAAAAMAAAAAAAAAAAA=</name>");
			CompressedData data = (CompressedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("en-CA", data.Language, "language");
			Assert.AreEqual(string.Empty, BytesUtil.AsString(data.UncompressedContent), "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlNullData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\" representation=\"B64\"></name>"
				);
			CompressedData data = (CompressedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			// content missing
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("en-CA", data.Language, "language");
			Assert.IsNull(data.UncompressedContent, "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedTextData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/plain\" representation=\"B64\">" 
				+ "H4sIAAAAAAAAALOpyM2xS8vPt9EHMQATOK6nDgAAAA==</name>");
			CompressedData data = (CompressedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("en-CA", data.Language, "language");
			Assert.AreEqual("<xml>foo</xml>", BytesUtil.AsString(data.UncompressedContent), "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			XmlNode node = CreateNode("<something>this is a text node</something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			// must provide specializationType and mediaType
			Assert.AreEqual("this is a text node", value.Content, "signature");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithAttributes()
		{
			XmlNode node = CreateNode("<something specializationType=\"ED.DOC\" mediaType=\"text/plain\" reference=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\">text value</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("text value", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseReferenceTypeUsingNewerReferenceFormat()
		{
			XmlNode node = CreateNode("<text specializationType=\"ED.DOCREF\" mediaType=\"text/html\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></text>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDocAndReferenceUsingNewerReferenceFormat()
		{
			XmlNode node = CreateNode("<text specializationType=\"ED.DOC\" mediaType=\"text/html\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/>text value</text>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.R02_04_03
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value", value.Content, "text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseReferenceTypeUsingNewerReferenceFormatWithInvalidSpecializationType()
		{
			XmlNode node = CreateNode("<text specializationType=\"ED.SIGNATURE\" mediaType=\"text/html\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></text>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCompressionNotAllowedForEdRef()
		{
			XmlNode node = CreateNode("<something compression=\"GZ\" mediaType=\"text/plain\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.REF", SpecificationVersion.V01R04_3
				), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCompressionPassesWithGZForCerxEdDocOrRef()
		{
			XmlNode node = CreateNode("<something compression=\"GZ\" mediaType=\"text/plain\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				V01R04_3), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCompressionFailsWithNonGZForCerxEdDocOrRef()
		{
			XmlNode node = CreateNode("<something compression=\"DF\" mediaType=\"text/plain\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				V01R04_3), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseCompressionMustBeDfOrGz()
		{
			XmlNode node = CreateNode("<text compression=\"DFGZ\" specializationType=\"ED.DOC\" mediaType=\"text/html\">text value</text>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("text value", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.Reference, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestCantHaveBothRefAndContentForCerxEdDocOrRef()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\" reference=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\">text value</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				V01R04_3), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			// reference should be as element; can't have both reference and content
			Assert.AreEqual("text value", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMustHaveOneOfRefOrContentForCerxEdDocOrRef()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\"></something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				V01R04_3), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.Reference, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRepresentationInvalid()
		{
			XmlNode node = CreateNode("<something representation=\"TXTB64\" compression=\"DF\" mediaType=\"text/plain\">text value</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.R02_04_03
				), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			// unknown value for representation; representation must be B64 or TXT
			Assert.AreEqual("text value", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.Reference, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRepresentationValidTXT()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" compression=\"DF\" mediaType=\"text/plain\">text value</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.R02_04_03
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.Reference, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRepresentationValidB64()
		{
			string content = Base64.EncodeBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("text value"));
			XmlNode node = CreateNode("<something representation=\"B64\" compression=\"DF\" mediaType=\"text/plain\">" + content + "</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOC", SpecificationVersion.R02_04_03
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value", BytesUtil.AsString(Base64.DecodeBase64(System.Text.ASCIIEncoding.ASCII.GetBytes(value.Content
				))), "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.Reference, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsDueToContentNotAllowed()
		{
			XmlNode node = CreateNode("<something reference=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\" compression=\"DF\" mediaType=\"text/plain\">text value</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCREF", SpecificationVersion.R02_04_03
				), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
			// reference should be an element; can't have content
			Assert.AreEqual("text value", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsDueToMissingReference()
		{
			XmlNode node = CreateNode("<something compression=\"DF\" mediaType=\"text/plain\"/>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCREF", SpecificationVersion.R02_04_03
				), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(value.Content, "nor text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.Reference, "no reference returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseSucceedsWithValidLanguage()
		{
			XmlNode node = CreateNode("<something language=\"en-CA\" compression=\"DF\" mediaType=\"text/plain\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCREF", SpecificationVersion.R02_04_03
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
			Assert.AreEqual("en-CA", value.Language);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsWithInvalidLanguage()
		{
			XmlNode node = CreateNode("<something language=\"eng\" compression=\"DF\" mediaType=\"text/plain\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCREF", SpecificationVersion.R02_04_03
				), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
			Assert.AreEqual("eng", value.Language);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFailsWithInvalidLanguageForCeRx()
		{
			XmlNode node = CreateNode("<something language=\"en-CA\" compression=\"GZ\" mediaType=\"text/plain\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				V01R04_3), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
			Assert.AreEqual("en-CA", value.Language);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParsePassesWithValidLanguageForCeRx()
		{
			XmlNode node = CreateNode("<something language=\"eng\" compression=\"GZ\" mediaType=\"text/plain\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser().Parse(CreateContext("ED.DOCORREF", SpecificationVersion.
				V01R04_3), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(value.Content, "no text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.Reference, "proper reference returned"
				);
			Assert.AreEqual("eng", value.Language);
		}

		// charset not permitted pre-MR2009
		private string Unencode(byte[] contentToBeUnencoded)
		{
			return System.Text.ASCIIEncoding.ASCII.GetString(Base64.DecodeBase64(contentToBeUnencoded));
		}
	}
}
