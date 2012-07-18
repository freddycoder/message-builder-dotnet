using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TelPhonemailPropertyFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new TelPhonemailPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null), null);
			// a null value for TEL.PHONEMAIL elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey(AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelPhonemailValid()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "value";
			IDictionary<string, string> result = new TelPhonemailPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null), address);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:value", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsPhonemailAllValidSchemes()
		{
			FormatterAssert.AssertValidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.FAX, "fax:");
			FormatterAssert.AssertValidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.MAILTO, "mailto://");
			FormatterAssert.AssertValidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.TELEPHONE, "tel:");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidSchemes()
		{
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.FILE);
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.FTP);
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.HTTP);
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.HTTPS);
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.MLLP);
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.MODEM);
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.TELNET);
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatter(), CeRxDomainTestValues.NFS);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIncludeUses()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "value";
			address.AddAddressUse(CeRxDomainTestValues.HOME_ADDRESS);
			IDictionary<string, string> result = new TelPhonemailPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null), address);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:value", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(result.ContainsKey("use"), "use key as expected");
			Assert.AreEqual("H", result.SafeGet("use"), "use as expected");
			address.AddAddressUse(CeRxDomainTestValues.MOBILE_CONTACT);
			result = new TelPhonemailPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null, null), address
				);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("use"), "use key as expected");
			ICollection<string> uses = FormatterAssert.ToSet(result.SafeGet("use"));
			FormatterAssert.AssertContainsSame("uses", FormatterAssert.ToSet("H MC"), uses);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidAddressUses()
		{
			AssertInvalidAddressUse(CeRxDomainTestValues.ANSWERING_SERVICE);
			AssertInvalidAddressUse(CeRxDomainTestValues.BAD_ADDRESS);
			AssertInvalidAddressUse(CeRxDomainTestValues.DIRECT);
			AssertInvalidAddressUse(CeRxDomainTestValues.PRIMARY_HOME);
			AssertInvalidAddressUse(CeRxDomainTestValues.PUBLIC);
			AssertInvalidAddressUse(CeRxDomainTestValues.VACATION_HOME);
		}

		private void AssertInvalidAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse addressUse)
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FAX;
			address.AddAddressUse(addressUse);
			try
			{
				new TelPhonemailPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null, null), address);
				Assert.Fail("expected exception");
			}
			catch (ModelToXmlTransformationException e)
			{
				Assert.AreEqual("Telecommunication address use " + addressUse.CodeValue + " is not supported for TEL.PHONEMAIL data", e.Message
					, "expected message");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllValidAddressUses()
		{
			AssertValidAddressUse(CeRxDomainTestValues.EMERGENCY_CONTACT);
			AssertValidAddressUse(CeRxDomainTestValues.HOME_ADDRESS);
			AssertValidAddressUse(CeRxDomainTestValues.MOBILE_CONTACT);
			AssertValidAddressUse(CeRxDomainTestValues.PAGER);
			AssertValidAddressUse(CeRxDomainTestValues.TEMPORARY_ADDRESS);
			AssertValidAddressUse(CeRxDomainTestValues.WORK_PLACE);
		}

		/// <exception cref="System.Exception"></exception>
		private void AssertValidAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse addressUse)
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FAX;
			address.AddAddressUse(addressUse);
			IDictionary<string, string> result = new TelPhonemailPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl
				("name", null, null), address);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("use"), "key as expected");
			Assert.AreEqual(addressUse.CodeValue, result.SafeGet("use"), "value as expected");
		}
	}
}
