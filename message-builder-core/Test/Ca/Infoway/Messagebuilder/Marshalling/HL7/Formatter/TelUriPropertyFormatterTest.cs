using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TelUriPropertyFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new TelUriPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), null);
			// a null value for TEL.URI elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey(AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelUriValid()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FILE;
			address.Address = "value";
			IDictionary<string, string> result = new TelUriPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), address);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("file://value", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelAllValidUris()
		{
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.FILE, "file://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.FTP, "ftp://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.HTTP, "http://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.HTTPS, "https://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.MAILTO, "mailto://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.NFS, "nfs://");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidUris()
		{
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.FAX);
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.MLLP);
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.MODEM);
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.TELEPHONE);
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.TELNET);
		}
	}
}
