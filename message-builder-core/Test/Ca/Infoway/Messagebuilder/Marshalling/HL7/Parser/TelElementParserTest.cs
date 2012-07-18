using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class TelElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			TEL tel = (TEL)new TelElementParser().Parse(CreateContext(), node, null);
			Assert.IsNull(tel.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, tel.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("TEL", typeof(TelecommunicationAddress), SpecificationVersion.NEWFOUNDLAND, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			try
			{
				new TelElementParser().Parse(null, node, null);
				Assert.Fail("Expected exception");
			}
			catch (ArgumentNullException)
			{
			}
		}

		// expected
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			try
			{
				new TelElementParser().Parse(null, node, null);
				Assert.Fail("Expected exception");
			}
			catch (ArgumentNullException)
			{
			}
		}

		// expected
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttributeNode()
		{
			XmlNode node = CreateNode("<something value=\"1234\" />");
			XmlToModelResult xmlResult = new XmlToModelResult();
			new TelElementParser().Parse(null, node, xmlResult);
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count, "HL7 error count");
			Hl7Error hl7Error = xmlResult.GetHl7Errors()[0];
			Assert.AreEqual("Expected TEL.URI node to have a URL scheme (e.g. 'http://')", hl7Error.GetMessage(), "error message");
			Assert.AreEqual(Hl7ErrorCode.SYNTAX_ERROR, hl7Error.GetHl7ErrorCode(), "error message code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueUrlScheme()
		{
			resolver.AddDomainValue(null, typeof(Ca.Infoway.Messagebuilder.Domainvalue.URLScheme));
			XmlNode node = CreateNode("<something value=\"mailfrom://monkey\" />");
			XmlToModelResult xmlResult = new XmlToModelResult();
			new TelElementParser().Parse(null, node, xmlResult);
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count, "HL7 error count");
			Hl7Error hl7Error = xmlResult.GetHl7Errors()[0];
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message code");
			Assert.AreEqual("Unrecognized URL scheme 'mailfrom' in element /something", hl7Error.GetMessage(), "error message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidPlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"mailto://monkey@monkey\" />");
			TelecommunicationAddress address = (TelecommunicationAddress)new TelElementParser().Parse(null, node, null).BareValue;
			Assert.AreEqual("monkey@monkey", address.Address, "correct address returned");
			Assert.AreEqual(CeRxDomainTestValues.MAILTO.CodeValue, address.UrlScheme.CodeValue, "correct urlscheme returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something>\n" + "<monkey/>" + "</something>");
			try
			{
				new TelElementParser().Parse(new TrivialContext("TEL.URI"), node, null);
				Assert.Fail("expected exception");
			}
			catch (XmlToModelTransformationException e)
			{
				// expected
				Assert.AreEqual("Expected TEL.URI node to have no children", e.Message, "proper exception returned");
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseBlankChildNode()
		{
			XmlNode node = CreateNode("<something value=\"mailfrom://monkey\">\n" + "</something>");
			new TelElementParser().Parse(null, node, null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeAllUrlSchemes()
		{
			AssertValidValueAttribute("fax:1234", "1234", CeRxDomainTestValues.FAX);
			AssertValidValueAttribute("fax:", string.Empty, CeRxDomainTestValues.FAX);
			AssertValidValueAttribute("file:c:/temp", "c:/temp", CeRxDomainTestValues.FILE);
			AssertValidValueAttribute("file://c:/temp", "c:/temp", CeRxDomainTestValues.FILE);
			AssertValidValueAttribute("file:", string.Empty, CeRxDomainTestValues.FILE);
			AssertValidValueAttribute("ftp:ftp.monkey.com", "ftp.monkey.com", CeRxDomainTestValues.FTP);
			AssertValidValueAttribute("ftp://ftp.monkey.com", "ftp.monkey.com", CeRxDomainTestValues.FTP);
			AssertValidValueAttribute("ftp:", string.Empty, CeRxDomainTestValues.FTP);
			AssertValidValueAttribute("http:www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTP);
			AssertValidValueAttribute("http://www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTP);
			AssertValidValueAttribute("http:", string.Empty, CeRxDomainTestValues.HTTP);
			AssertValidValueAttribute("https:www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTPS);
			AssertValidValueAttribute("https://www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTPS);
			AssertValidValueAttribute("https:", string.Empty, CeRxDomainTestValues.HTTPS);
			AssertValidValueAttribute("mailto://monkey@monkey", "monkey@monkey", CeRxDomainTestValues.MAILTO);
			AssertValidValueAttribute("mailto:monkey@monkey", "monkey@monkey", CeRxDomainTestValues.MAILTO);
			AssertValidValueAttribute("mailto:", string.Empty, CeRxDomainTestValues.MAILTO);
			AssertValidValueAttribute("nfs://nfs.ca", "nfs.ca", CeRxDomainTestValues.NFS);
			AssertValidValueAttribute("nfs:nfs.ca", "nfs.ca", CeRxDomainTestValues.NFS);
			AssertValidValueAttribute("nfs:", string.Empty, CeRxDomainTestValues.NFS);
			AssertValidValueAttribute("tel:567-1111", "567-1111", CeRxDomainTestValues.TELEPHONE);
			AssertValidValueAttribute("tel:", string.Empty, CeRxDomainTestValues.TELEPHONE);
		}

		/// <exception cref="System.Exception"></exception>
		private void AssertValidValueAttribute(string value, string address, Ca.Infoway.Messagebuilder.Domainvalue.URLScheme urlScheme
			)
		{
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			TelecommunicationAddress telecommunicationAddress = (TelecommunicationAddress)new TelElementParser().Parse(null, node, null
				).BareValue;
			Assert.AreEqual(address, telecommunicationAddress.Address, "correct address returned");
			Assert.AreEqual(urlScheme.CodeValue, telecommunicationAddress.UrlScheme.CodeValue, "correct urlscheme returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAddressUse()
		{
			AbstractSingleElementParser<TelecommunicationAddress> parser = new TelElementParser();
			XmlNode node = CreateNode("<something use=\"H\" value=\"mailto://monkey@monkey\" />");
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse> addressUses = ((TelecommunicationAddress)parser
				.Parse(null, node, null).BareValue).AddressUses;
			Assert.AreEqual(1, addressUses.Count, "address use count");
			AssertContains("address use HOME", addressUses, CeRxDomainTestValues.HOME_ADDRESS);
			node = CreateNode("<something use=\"H WP\" value=\"mailto://monkey@monkey\" />");
			addressUses = ((TelecommunicationAddress)parser.Parse(null, node, null).BareValue).AddressUses;
			Assert.AreEqual(2, addressUses.Count, "address use count (2)");
			AssertContains("address use HOME (2)", addressUses, CeRxDomainTestValues.HOME_ADDRESS);
			AssertContains("address use WORKPLACE (2)", addressUses, CeRxDomainTestValues.WORK_PLACE);
		}

		private void AssertContains(string description, ICollection<Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse
			> addressUses, Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse use)
		{
			bool found = false;
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse telecommunicationAddressUse in addressUses)
			{
				if (StringUtils.Equals(use.CodeValue, telecommunicationAddressUse.CodeValue))
				{
					found = true;
					break;
				}
			}
			if (!found)
			{
				Assert.Fail(description);
			}
		}
	}
}
