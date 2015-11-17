/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class EdR2ElementParserTest : CeRxDomainValueTestCase
	{
		private static readonly string TEXT_SIMPLE_B64 = Base64.EncodeBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("This is a test"
			));

		private TelR2ElementParser telParser = new TelR2ElementParser();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\"/>");
			ED<EncapsulatedData> ed = (ED<EncapsulatedData>)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.V02R02), node, this.xmlResult);
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
			BareANY parseResult = new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion.V02R02), node
				, this.xmlResult);
			Assert.IsNull(parseResult.BareValue, "data");
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeNoCompression()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\">" + TEXT_SIMPLE_B64 + "</something>");
			EncapsulatedData data = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(TEXT_SIMPLE_B64, data.Content, "content");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, data.MediaType, "media type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNodeWithCompression()
		{
			XmlNode node = CreateNode("<something mediaType=\"text/plain\" representation=\"B64\">" + TEXT_SIMPLE_B64 + "</something>"
				);
			EncapsulatedData data = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(TEXT_SIMPLE_B64, data.Content, "content");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, data.MediaType, "media type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseManyChildTextNodesAllowed()
		{
			XmlNode node = CreateNode("<something>" + "<monkey/>" + "<shines/>" + "<through/>" + "</something>");
			EncapsulatedData data = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(data);
			Assert.IsNotNull(data.Content);
			AssertXml("content", "<monkey/>" + Runtime.GetProperty("line.separator") + "<shines/>" + Runtime.GetProperty("line.separator"
				) + "<through/>", RemoveExtraSpaces(data.Content));
		}

		//For .NET compatibility
		private string RemoveExtraSpaces(string xmlString)
		{
			return System.Text.RegularExpressions.Regex.Replace(xmlString, " />", "/>");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\" representation=\"B64\">" + 
				"H4sIAAAAAAAAALOpyM2xS8vPt9EHMQATOK6nDgAAAA==</name>");
			EncapsulatedData data = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("en-CA", data.Language, "language");
			Assert.AreEqual(EdRepresentation.B64, data.Representation, "representation");
			Assert.AreEqual("H4sIAAAAAAAAALOpyM2xS8vPt9EHMQATOK6nDgAAAA==", data.Content, "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlEmptyData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\" representation=\"B64\">" + 
				"H4sIAAAAAAAAAAMAAAAAAAAAAAA=</name>");
			EncapsulatedData data = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("en-CA", data.Language, "language");
			Assert.AreEqual(EdRepresentation.B64, data.Representation, "representation");
			Assert.AreEqual("H4sIAAAAAAAAAAMAAAAAAAAAAAA=", data.Content, "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueCompressedXmlNullData()
		{
			XmlNode node = CreateNode("<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\" representation=\"B64\"></name>"
				);
			EncapsulatedData data = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, data.MediaType, "media type");
			Assert.AreEqual(Compression.GZIP, data.Compression, "Compression type");
			Assert.AreEqual("en-CA", data.Language, "language");
			Assert.AreEqual(EdRepresentation.B64, data.Representation, "representation");
			Assert.IsNull(data.Content, "content");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextNode()
		{
			XmlNode node = CreateNode("<something>this is a text node</something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("this is a text node", value.Content, "signature");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTrickyTextNodeThatReallyIsntText()
		{
			XmlNode node = CreateNode("<something>this is a text node<br/>with some extra<br/>formatting</something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("this is a text node<br/>with some extra<br/>formatting", RemoveExtraSpaces(value.Content), "mixed text");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTextCommentsCdataAndElements()
		{
			XmlNode node = CreateNode("<text>\n" + "	this is some text\n" + "	<![CDATA[& this is some > CDATA text]]>\n" + "	<!--  with a comment -->\n"
				 + "	<table xmlns:fred=\"urn:hl7-org:fred\">\n" + "		<thead>\n" + "			<tr>\n" + "				<th>and some html</th>\n" + "			</tr>\n"
				 + "		</thead>\n" + "	</table>\n" + "</text>\n");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			AssertXml("mixed text", "this is some text\n" + "\t&amp; this is some &gt; CDATA text\n" + "<!--  with a comment -->\n" +
				 "<table xmlns:fred=\"urn:hl7-org:fred\">\n" + "<thead>\n" + "<tr>\n" + "<th>and some html</th>\n" + "</tr>\n" + "</thead>\n"
				 + "</table>\n", value.Content, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDocAndReferenceUsingNewerReferenceFormat()
		{
			XmlNode node = CreateNode("<text mediaType=\"text/html\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/>text value</text>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value", value.Content, "text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.ReferenceObj.Address, "proper reference returned"
				);
			Assert.AreEqual("https", value.ReferenceObj.UrlScheme.CodeValue, "proper reference returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseDocWithTooManyReferences()
		{
			XmlNode node = CreateNode("<text mediaType=\"text/html\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/><reference value=\"https://should.not.be.here.ca/monograph/WPDM00002197.html\"/>text value</text>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("ED types only allow a single reference. Found: 2", this.xmlResult.GetHl7Errors()[0].GetMessage());
			Assert.AreEqual("text value", value.Content, "text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.ReferenceObj.Address, "proper reference returned"
				);
			Assert.AreEqual("https", value.ReferenceObj.UrlScheme.CodeValue, "proper reference returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRepresentationInvalid()
		{
			XmlNode node = CreateNode("<something representation=\"TXTB64\" compression=\"DF\" mediaType=\"text/plain\">text value</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("text value", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.ReferenceObj, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRepresentationValidTXT()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" compression=\"DF\" mediaType=\"text/plain\">text value</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.ReferenceObj, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRepresentationValidTXTWithEmbeddedElements()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" compression=\"DF\" mediaType=\"text/plain\">text value<br/>with some<br/>unescaped characters;</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value<br/>with some<br/>unescaped characters;", RemoveExtraSpaces(value.Content), "proper text returned"
				);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.ReferenceObj, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRepresentationValidTXTWithEscapedValues()
		{
			XmlNode node = CreateNode("<something representation=\"TXT\" compression=\"DF\" mediaType=\"text/plain\">text value&lt;br/&gt;with some&lt;br/&gt;escaped characters;</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value&lt;br/&gt;with some&lt;br/&gt;escaped characters;", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.ReferenceObj, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTxtButSentWithB64()
		{
			string content = "text value should be b64 encoded";
			XmlNode node = CreateNode("<something representation=\"B64\" compression=\"DF\" mediaType=\"text/plain\">" + content + "</something>"
				);
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("text value should be b64 encoded", value.Content, "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.IsNull(value.ReferenceObj, "no reference");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFullWithCdataNoThumbnail()
		{
			XmlNode node = CreateNode("<something representation=\"B64\" compression=\"DF\" mediaType=\"text/plain\">" + "<reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/>"
				 + string.Empty + "<![CDATA[" + "Since this is a CDATA section" + "I can use all sorts of reserved characters" + "like > < \" and &"
				 + "or write things like" + "<foo></bar>" + "but my document is still well formed!" + "]]>" + "</something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsTrue(value.Content.StartsWith("Since this is a CDATA"), "proper text returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual("pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.ReferenceObj.Address, "proper reference returned"
				);
			Assert.AreEqual("https", value.ReferenceObj.UrlScheme.CodeValue, "proper reference returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFullWithCdataAndThumbnail()
		{
			XmlNode node = CreateNode("<something representation=\"B64\" compression=\"DF\" mediaType=\"text/plain\">" + "<reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/>"
				 + "<thumbnail representation=\"TXT\" mediaType=\"text/html\"><reference value=\"https://thumbnail.ca/monograph/WPDM00002197.html\"/>thumbnail text value</thumbnail>"
				 + "<![CDATA[" + "Since this is a CDATA section" + "I can use all sorts of reserved characters" + "like > < \" and &" + 
				"or write things like" + "<foo></bar>" + "but my document is still well formed!" + "]]>" + "</something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual(EdRepresentation.B64, value.Representation, "proper representation returned");
			Assert.AreEqual("pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.ReferenceObj.Address, "proper reference returned"
				);
			Assert.AreEqual("https", value.ReferenceObj.UrlScheme.CodeValue, "proper reference returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, value.Thumbnail.MediaType, "proper thumbnail media type returned"
				);
			Assert.AreEqual(EdRepresentation.TXT, value.Thumbnail.Representation, "proper thumbnail representation returned");
			Assert.AreEqual("thumbnail.ca/monograph/WPDM00002197.html", value.Thumbnail.ReferenceObj.Address, "proper thumbnail reference returned"
				);
			Assert.AreEqual("https", value.Thumbnail.ReferenceObj.UrlScheme.CodeValue, "proper thumbnail reference returned");
			Assert.AreEqual("thumbnail text value", value.Thumbnail.Content, "proper thumbnail text returned");
			Assert.IsTrue(value.Content.StartsWith("Since this is a CDATA"), "proper text returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseFullWithCdataAndThumbnailOutOfOrder()
		{
			XmlNode node = CreateNode("<something representation=\"B64\" compression=\"DF\" mediaType=\"text/plain\">" + "<thumbnail representation=\"TXT\" mediaType=\"text/html\"><reference value=\"https://thumbnail.ca/monograph/WPDM00002197.html\"/>thumbnail text value</thumbnail>"
				 + "<reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/>" + "<![CDATA[" + "Since this is a CDATA section"
				 + "I can use all sorts of reserved characters" + "like > < \" and &" + "or write things like" + "<foo></bar>" + "but my document is still well formed!"
				 + "]]>" + "</something>");
			EncapsulatedData value = (EncapsulatedData)new EdElementParser(this.telParser, true).Parse(CreateContext("ED", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsTrue(this.xmlResult.GetHl7Errors()[0].GetMessage().Contains("ED properties appear to be out of order"));
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, value.MediaType, "proper media type returned"
				);
			Assert.AreEqual(EdRepresentation.B64, value.Representation, "proper representation returned");
			Assert.AreEqual("pipefq.ehealthsask.ca/monograph/WPDM00002197.html", value.ReferenceObj.Address, "proper reference returned"
				);
			Assert.AreEqual("https", value.ReferenceObj.UrlScheme.CodeValue, "proper reference returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, value.Thumbnail.MediaType, "proper thumbnail media type returned"
				);
			Assert.AreEqual(EdRepresentation.TXT, value.Thumbnail.Representation, "proper thumbnail representation returned");
			Assert.AreEqual("thumbnail.ca/monograph/WPDM00002197.html", value.Thumbnail.ReferenceObj.Address, "proper thumbnail reference returned"
				);
			Assert.AreEqual("https", value.Thumbnail.ReferenceObj.UrlScheme.CodeValue, "proper thumbnail reference returned");
			Assert.AreEqual("thumbnail text value", value.Thumbnail.Content, "proper thumbnail text returned");
			Assert.IsTrue(value.Content.StartsWith("Since this is a CDATA"), "proper text returned");
		}
	}
}
