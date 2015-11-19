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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class EdPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string expectedResult = "<name nullFlavor=\"NI\"/>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>());
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(expectedResult, result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string expectedResult = "<name mediaType=\"text/plain\">" + "this is some text &amp; some &quot;more&quot;</name>" + SystemUtils
				.LINE_SEPARATOR;
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>(new EncapsulatedData
				(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, null, null, System.Text.ASCIIEncoding.ASCII.GetBytes
				("this is some text & some \"more\""))));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", expectedResult, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueMissingContent()
		{
			string expectedResult = "<name mediaType=\"text/plain\"/>";
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>(new EncapsulatedData
				(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, null, null, System.Text.ASCIIEncoding.ASCII.GetBytes
				(string.Empty))));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(expectedResult, result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueWithSpecializationType()
		{
			string expectedResult = "<name mediaType=\"text/plain\" specializationType=\"ED.DOC\" xsi:type=\"ED\">" + "this is some text &amp; some &quot;more&quot;</name>"
				 + SystemUtils.LINE_SEPARATOR;
			EDImpl<EncapsulatedData> edImp = new EDImpl<EncapsulatedData>(new EncapsulatedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
				.PLAIN_TEXT, null, null, System.Text.ASCIIEncoding.ASCII.GetBytes("this is some text & some \"more\"")));
			edImp.DataType = StandardDataType.ED_DOC;
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOCORREF"), edImp);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", expectedResult, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueWithMissingSpecializationType()
		{
			string expectedResult = "<name mediaType=\"text/plain\" specializationType=\"ED.DOC\" xsi:type=\"ED\">" + "this is some text &amp; some &quot;more&quot;</name>"
				 + SystemUtils.LINE_SEPARATOR;
			EDImpl<EncapsulatedData> edImp = new EDImpl<EncapsulatedData>(new EncapsulatedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
				.PLAIN_TEXT, null, null, System.Text.ASCIIEncoding.ASCII.GetBytes("this is some text & some \"more\"")));
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOCORREF"), edImp);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("something in text node", expectedResult, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueWithWrongSpecializationType()
		{
			string expectedResult = "<name mediaType=\"text/plain\" specializationType=\"ED.DOC\" xsi:type=\"ED\">" + "this is some text &amp; some &quot;more&quot;</name>"
				 + SystemUtils.LINE_SEPARATOR;
			EDImpl<EncapsulatedData> edImp = new EDImpl<EncapsulatedData>(new EncapsulatedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType
				.PLAIN_TEXT, null, null, System.Text.ASCIIEncoding.ASCII.GetBytes("this is some text & some \"more\"")));
			edImp.DataType = StandardDataType.ED_SIGNATURE;
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOCORREF"), edImp);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("something in text node", expectedResult, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueWithNoMediaType()
		{
			string expectedResult = "<name>" + "this is some text</name>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>(new EncapsulatedData
				(null, null, null, System.Text.ASCIIEncoding.ASCII.GetBytes("this is some text"))));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("something in text node", expectedResult, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCompressedXmlData()
		{
			byte[] content = System.Text.ASCIIEncoding.ASCII.GetBytes("<xml>foo</xml>");
			string finalContent = Base64.EncodeBase64String(Compression.Gzip(content));
			string expectedResult = "<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\" representation=\"B64\">" + finalContent
				 + "</name>" + SystemUtils.LINE_SEPARATOR;
			EncapsulatedData data = new CompressedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, null
				, System.Text.ASCIIEncoding.ASCII.GetBytes(finalContent), Compression.GZIP, "en-CA");
			data.Representation = EdRepresentation.B64;
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>(data));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(ClearPayload(expectedResult), ClearPayload(result), "element");
			string extractPayload = ExtractPayload(result);
			Assert.AreEqual(DecodeAndUnzip(extractPayload), "<xml>foo</xml>", "element payload");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCompressedXmlDataEmptyContent()
		{
			byte[] content = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Empty);
			string expectedResult = "<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\"/>" + SystemUtils.LINE_SEPARATOR;
			EncapsulatedData data = new CompressedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, null
				, content, Compression.GZIP, "en-CA");
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>(data));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(ClearPayload(expectedResult), ClearPayload(result), "element");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCompressedXmlDataNullContent()
		{
			string expectedResult = "<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/xml\"><reference value=\"http://www.i-proving.ca\"/></name>";
			EncapsulatedData data = new CompressedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.XML_TEXT, null
				, null, Compression.GZIP, "en-CA");
			data.ReferenceObj = new TelecommunicationAddress(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.HTTP, "www.i-proving.ca"
				);
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>(data));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(expectedResult, ClearPayload(result), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCompressedTextData()
		{
			string contentAsString = "<xml>foo</xml>";
			byte[] content = System.Text.ASCIIEncoding.ASCII.GetBytes(contentAsString);
			string finalContent = Base64.EncodeBase64String(Compression.Gzip(content));
			string expectedResult = "<name compression=\"GZ\" language=\"en-CA\" mediaType=\"text/plain\" representation=\"B64\">" + 
				finalContent + "</name>" + SystemUtils.LINE_SEPARATOR;
			EncapsulatedData data = new CompressedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, null
				, System.Text.ASCIIEncoding.ASCII.GetBytes(finalContent), Compression.GZIP, "en-CA");
			data.Representation = EdRepresentation.B64;
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>(data));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(ClearPayload(expectedResult), ClearPayload(result), "element");
			Assert.AreEqual(DecodeAndUnzip(ExtractPayload(result)), contentAsString, "element payload");
		}

		/// <exception cref="System.IO.IOException"></exception>
		private string DecodeAndUnzip(string payload)
		{
			return System.Text.ASCIIEncoding.ASCII.GetString(Compression.Gunzip(Base64.DecodeBase64String(payload)));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			string expectedResult = "<name mediaType=\"text/plain\">&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>"
				 + SystemUtils.LINE_SEPARATOR;
			EncapsulatedData ed = new EncapsulatedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, null
				, null, System.Text.ASCIIEncoding.ASCII.GetBytes("<cats think they're > humans & dogs 99% of the time/>"));
			string result = new EdPropertyFormatter().Format(GetContext("name", "ED.DOC"), new EDImpl<EncapsulatedData>(ed));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", expectedResult.Trim(), result.Trim(), true);
		}

		private string ClearPayload(string result)
		{
			return System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace
				(System.Text.RegularExpressions.Regex.Replace(System.Text.RegularExpressions.Regex.Replace(result, "\n", string.Empty), 
				"\t", string.Empty), "\r", string.Empty), "> +", ">"), " +<", "<");
		}

		private string ExtractPayload(string result)
		{
			return System.Text.RegularExpressions.Regex.Replace(result, "(?s)(<name.*>(.*)</name>)", "$2").Trim();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestReferenceForSKBug()
		{
			string expectedResult = "<text mediaType=\"text/html\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/></text>";
			EncapsulatedData data = new EncapsulatedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, "https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html"
				, null, null);
			string result = new EdPropertyFormatter().Format(GetContext("text", "ED.DOCREF"), new EDImpl<EncapsulatedData>(data));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(expectedResult, ClearPayload(result), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestReferenceWithContent()
		{
			string expectedResult = "<text mediaType=\"text/plain\"><reference value=\"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html\"/>this is some text</text>";
			EncapsulatedData data = new EncapsulatedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT, 
				"https://pipefq.ehealthsask.ca/monograph/WPDM00002197.html", null, System.Text.ASCIIEncoding.ASCII.GetBytes("this is some text"
				));
			string result = new EdPropertyFormatter().Format(GetContext("text", "ED.DOC"), new EDImpl<EncapsulatedData>(data));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(expectedResult, ClearPayload(result), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingReference()
		{
			string expectedResult = "<text mediaType=\"text/html\"/>";
			EncapsulatedData data = new EncapsulatedData(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT, null
				, null, null);
			string result = new EdPropertyFormatter().Format(GetContext("text", "ED.DOCREF"), new EDImpl<EncapsulatedData>(data));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(expectedResult, ClearPayload(result), "something in text node");
		}
	}
}
