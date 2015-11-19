using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;
using Platform.Xml.Sax;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class EdR2PropertyFormatterTest : FormatterTestCase
	{
		private TelR2PropertyFormatter telFormatter = new TelR2PropertyFormatter();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string expectedResult = "<name nullFlavor=\"NI\"/>" + SystemUtils.LINE_SEPARATOR;
			string result = new EdPropertyFormatter(this.telFormatter, true).Format(GetContext("name", "ED"), new EDImpl<EncapsulatedData
				>());
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(expectedResult, result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestInvalidTextContent()
		{
			TelecommunicationAddress reference = new TelecommunicationAddress();
			reference.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			reference.Address = "aValue";
			reference.AddAddressUse(CeRxDomainTestValues.HOME_ADDRESS);
			try
			{
				CreateEd(reference, "some content & that will <b>not</b> be escaped");
				Assert.Fail("Should not get here due to unescaped content");
			}
			catch (SAXException)
			{
			}
		}

		// expected to throw an exception on the "&"
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTextContent()
		{
			TelecommunicationAddress reference = new TelecommunicationAddress();
			reference.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			reference.Address = "aValue";
			reference.AddAddressUse(CeRxDomainTestValues.HOME_ADDRESS);
			EncapsulatedData data = CreateEd(reference, "some content &amp; that will <b>not</b> be escaped");
			string result = new EdPropertyFormatter(this.telFormatter, true).Format(GetContext("text", "ED"), new EDImpl<EncapsulatedData
				>(data));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<text compression=\"ZL\" integrityCheck=\"c29tZXRoaW5nIHRvIGVuY29kZQ==\" integrityCheckAlgorithm=\"SHA-256\" language=\"en-CA\" mediaType=\"text/plain\" representation=\"TXT\">"
				 + "<reference use=\"H\" value=\"tel:aValue\"/>" + "some content &amp; that will <b>not</b> be escaped" + "</text>", result
				, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestAllProperties()
		{
			TelecommunicationAddress reference = new TelecommunicationAddress();
			reference.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			reference.Address = "aValue";
			reference.AddAddressUse(CeRxDomainTestValues.HOME_ADDRESS);
			EncapsulatedData data = CreateEd(reference, "<content>this is some <b>bolded</b> content</content>");
			data.Thumbnail = CreateEd(reference, "<![CDATA[some cdata <& <> content]]>");
			string result = new EdPropertyFormatter(this.telFormatter, true).Format(GetContext("text", "ED"), new EDImpl<EncapsulatedData
				>(data));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<text compression=\"ZL\" integrityCheck=\"c29tZXRoaW5nIHRvIGVuY29kZQ==\" integrityCheckAlgorithm=\"SHA-256\" language=\"en-CA\" mediaType=\"text/plain\" representation=\"TXT\">"
				 + "<reference use=\"H\" value=\"tel:aValue\"/>" + "<thumbnail compression=\"ZL\" integrityCheck=\"c29tZXRoaW5nIHRvIGVuY29kZQ==\" integrityCheckAlgorithm=\"SHA-256\" language=\"en-CA\" mediaType=\"text/plain\" representation=\"TXT\">"
				 + "<reference use=\"H\" value=\"tel:aValue\"/>" + "<![CDATA[some cdata <& <> content]]>" + "</thumbnail>" + "<content>this is some <b>bolded</b> content</content>"
				 + "</text>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		private EncapsulatedData CreateEd(TelecommunicationAddress reference, string content)
		{
			EncapsulatedData data = new EncapsulatedData();
			data.Compression = Compression.ZLIB;
			data.IntegrityCheck = Base64.EncodeBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes("something to encode"));
			data.IntegrityCheckAlgorithm = IntegrityCheckAlgorithm.SHA_256;
			data.Language = "en-CA";
			data.MediaType = Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.PLAIN_TEXT;
			data.ReferenceObj = reference;
			data.Representation = EdRepresentation.TXT;
			if (content != null)
			{
				data.Content = content;
			}
			return data;
		}
	}
}
