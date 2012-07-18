using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
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
			string result = new EdPropertyFormatter().Format(GetContext("name"), new EDImpl<EncapsulatedData>());
			Assert.AreEqual(expectedResult, result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string expectedResult = "<name>" + "this is some text &amp; some &quot;more&quot;</name>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdPropertyFormatter().Format(GetContext("name"), new EDImpl<EncapsulatedData>(new EncapsulatedData(MediaType
				.PLAIN_TEXT, null, System.Text.ASCIIEncoding.ASCII.GetBytes("this is some text & some \"more\""))));
			Assert.AreEqual(expectedResult, result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueWithNoMediaType()
		{
			string expectedResult = "<name representation=\"B64\">" + "dGhpcyBpcyBzb21lIHRleHQ=</name>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdPropertyFormatter().Format(GetContext("name"), new EDImpl<EncapsulatedData>(new EncapsulatedData(null
				, null, System.Text.ASCIIEncoding.ASCII.GetBytes("this is some text"))));
			Assert.AreEqual(expectedResult, result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCompressedXmlData()
		{
			string expectedResult = "<name compression=\"GZ\" language=\"ENG\" mediaType=\"text/xml\" reference=\"http://www.i-proving.ca\" representation=\"B64\">"
				 + "H4sIAAAAAAAAALOpyM2xS8vPt9EHMQATOK6nDgAAAA==</name>" + SystemUtils.LINE_SEPARATOR;
			EncapsulatedData data = new CompressedData(MediaType.XML_TEXT, "http://www.i-proving.ca", System.Text.ASCIIEncoding.ASCII.GetBytes
				("<xml>foo</xml>"), Compression.GZIP, CompressedData.LANGUAGE_ENGLISH);
			string result = new EdPropertyFormatter().Format(GetContext("name"), new EDImpl<EncapsulatedData>(data));
			Assert.AreEqual(ClearPayload(expectedResult), ClearPayload(result), "element");
			Assert.AreEqual(DecodeAndUnzip(ExtractPayload(result)), "<xml>foo</xml>", "element payload");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCompressedXmlDataEmptyContent()
		{
			string expectedResult = "<name compression=\"GZ\" language=\"ENG\" mediaType=\"text/xml\" reference=\"http://www.i-proving.ca\" representation=\"B64\">"
				 + "H4sIAAAAAAAAAAMAAAAAAAAAAAA=</name>" + SystemUtils.LINE_SEPARATOR;
			EncapsulatedData data = new CompressedData(MediaType.XML_TEXT, "http://www.i-proving.ca", System.Text.ASCIIEncoding.ASCII.GetBytes
				(string.Empty), Compression.GZIP, CompressedData.LANGUAGE_ENGLISH);
			string result = new EdPropertyFormatter().Format(GetContext("name"), new EDImpl<EncapsulatedData>(data));
			Assert.AreEqual(ClearPayload(expectedResult), ClearPayload(result), "element");
			Assert.AreEqual(DecodeAndUnzip(ExtractPayload(result)), string.Empty, "element payload");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCompressedXmlDataNullContent()
		{
			string expectedResult = "<name compression=\"GZ\" language=\"ENG\" mediaType=\"text/xml\" reference=\"http://www.i-proving.ca\" representation=\"B64\"></name>"
				 + SystemUtils.LINE_SEPARATOR;
			EncapsulatedData data = new CompressedData(MediaType.XML_TEXT, "http://www.i-proving.ca", null, Compression.GZIP, CompressedData
				.LANGUAGE_ENGLISH);
			string result = new EdPropertyFormatter().Format(GetContext("name"), new EDImpl<EncapsulatedData>(data));
			Assert.AreEqual(expectedResult, result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCompressedTextData()
		{
			string expectedResult = "<name compression=\"GZ\" language=\"ENG\" mediaType=\"text/plain\" reference=\"http://www.i-proving.ca\" representation=\"B64\">"
				 + "H4sIAAAAAAAAALOpyM2xS8vPt9EHMQATOK6nDgAAAA==</name>" + SystemUtils.LINE_SEPARATOR;
			EncapsulatedData data = new CompressedData(MediaType.PLAIN_TEXT, "http://www.i-proving.ca", System.Text.ASCIIEncoding.ASCII.GetBytes
				("<xml>foo</xml>"), Compression.GZIP, CompressedData.LANGUAGE_ENGLISH);
			string result = new EdPropertyFormatter().Format(GetContext("name"), new EDImpl<EncapsulatedData>(data));
			Assert.AreEqual(ClearPayload(expectedResult), ClearPayload(result), "element");
			Assert.AreEqual(DecodeAndUnzip(ExtractPayload(result)), "<xml>foo</xml>", "element payload");
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
			string expectedResult = "<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>" + SystemUtils
				.LINE_SEPARATOR;
			EncapsulatedData ed = new EncapsulatedData(MediaType.PLAIN_TEXT, null, System.Text.ASCIIEncoding.ASCII.GetBytes("<cats think they're > humans & dogs 99% of the time/>"
				));
			string result = new EdPropertyFormatter().Format(GetContext("name"), new EDImpl<EncapsulatedData>(ed));
			Assert.AreEqual(expectedResult.Trim(), result.Trim(), "something in text node");
		}

		private string ClearPayload(string result)
		{
			return System.Text.RegularExpressions.Regex.Replace(result, ">.*<", "><");
		}

		private string ExtractPayload(string result)
		{
			return System.Text.RegularExpressions.Regex.Replace(result, "(<name.*>(.*)</name>)", "$2");
		}
	}
}
