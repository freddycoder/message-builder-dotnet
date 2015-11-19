using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class TelR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			TEL tel = (TEL)new TelR2ElementParser().Parse(CreateContext("TEL", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(tel.Value, "null returned");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, tel.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext(string type, VersionNumber version)
		{
			return ParseContextImpl.Create(type, typeof(TelecommunicationAddress), version, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			new TelR2ElementParser().Parse(CreateContext("TEL", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}

		//missing address
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			new TelR2ElementParser().Parse(CreateContext("TEL", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}

		// missing address
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidValueAttributeNodeMinimumSpecified()
		{
			XmlNode node = CreateNode("<something value=\"1234\" />");
			new TelR2ElementParser().Parse(CreateContext("TEL", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueUrlScheme()
		{
			XmlNode node = CreateNode("<something value=\"mailfrom://monkey\" />");
			new TelR2ElementParser().Parse(CreateContext("TEL", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "HL7 error count");
			// invalid scheme
			Hl7Error hl7Error = this.xmlResult.GetHl7Errors()[0];
			Assert.AreEqual("Unrecognized URL scheme 'mailfrom' in element /something", hl7Error.GetMessage(), "error message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidPlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"mailto://monkey@monkey\" />");
			TelecommunicationAddress address = (TelecommunicationAddress)new TelR2ElementParser().Parse(CreateContext("TEL", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("monkey@monkey", address.Address, "correct address returned");
			Assert.AreEqual(CeRxDomainTestValues.MAILTO.CodeValue, address.UrlScheme.CodeValue, "correct urlscheme returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAll()
		{
			XmlNode node = CreateNode("<something value=\"http://www.fred.ca\" use=\"HP CONF TMP\">\n" + "<useablePeriod value=\"19990303101112\"/>"
				 + "<useablePeriod operator=\"E\" value=\"20050303101112\"/>" + "</something>");
			TelecommunicationAddress address = (TelecommunicationAddress)new TelR2ElementParser().Parse(CreateContext("TEL", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("www.fred.ca", address.Address, "correct address returned");
			Assert.AreEqual(CeRxDomainTestValues.HTTP.CodeValue, address.UrlScheme.CodeValue, "correct urlscheme returned");
			Assert.AreEqual(3, address.AddressUses.Count, "correct address uses");
			Assert.IsTrue(address.AddressUses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PRIMARY_HOME
				));
			Assert.IsTrue(address.AddressUses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.CONFIDENTIAL
				));
			Assert.IsTrue(address.AddressUses.Contains(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.TEMPORARY
				));
			Assert.AreEqual(2, address.UseablePeriods.Count, "correct number of useable periods");
			IEnumerator<KeyValuePair<PlatformDate, SetOperator>> iterator = address.UseablePeriods.GetEnumerator();
			KeyValuePair<PlatformDate, SetOperator> firstPeriod = iterator.MoveNext() ? iterator.Current : (KeyValuePair<PlatformDate
				, SetOperator>)(object)null;
			KeyValuePair<PlatformDate, SetOperator> secondPeriod = iterator.MoveNext() ? iterator.Current : (KeyValuePair<PlatformDate
				, SetOperator>)(object)null;
			Assert.AreEqual(DateUtil.GetDate(1999, 2, 3, 10, 11, 12, 0), firstPeriod.Key, "first period");
			Assert.AreEqual(SetOperator.INCLUDE, firstPeriod.Value, "first operator");
			Assert.AreEqual(DateUtil.GetDate(2005, 2, 3, 10, 11, 12, 0), secondPeriod.Key, "second period");
			Assert.AreEqual(SetOperator.EXCLUDE, secondPeriod.Value, "second operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyChildNodes()
		{
			XmlNode node = CreateNode("<something value=\"mailto:me@you.ca\">\n" + "<monkey/>" + "</something>");
			new TelR2ElementParser().Parse(new TrivialContext("TEL"), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("Unexpected TEL child element: \"monkey\"", this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseBlankChildNode()
		{
			XmlNode node = CreateNode("<something value=\"mailto://monkey\">\n" + "</something>");
			new TelR2ElementParser().Parse(CreateContext("TEL", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeAllUrlSchemes()
		{
			AssertValidValueAttribute("TEL", "fax:1234", "1234", CeRxDomainTestValues.FAX);
			AssertValidValueAttribute("TEL", "file:c:/temp", "c:/temp", CeRxDomainTestValues.FILE);
			AssertValidValueAttribute("TEL", "file://c:/temp", "c:/temp", CeRxDomainTestValues.FILE);
			AssertValidValueAttribute("TEL", "ftp:ftp.monkey.com", "ftp.monkey.com", CeRxDomainTestValues.FTP);
			AssertValidValueAttribute("TEL", "ftp://ftp.monkey.com", "ftp.monkey.com", CeRxDomainTestValues.FTP);
			AssertValidValueAttribute("TEL", "http:www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTP);
			AssertValidValueAttribute("TEL", "http://www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTP);
			AssertValidValueAttribute("TEL", "https:www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTPS);
			AssertValidValueAttribute("TEL", "https://www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTPS);
			AssertValidValueAttribute("TEL", "mailto://monkey@monkey", "monkey@monkey", CeRxDomainTestValues.MAILTO);
			AssertValidValueAttribute("TEL", "mailto:monkey@monkey", "monkey@monkey", CeRxDomainTestValues.MAILTO);
			AssertValidValueAttribute("TEL", "nfs://nfs.ca", "nfs.ca", CeRxDomainTestValues.NFS);
			AssertValidValueAttribute("TEL", "nfs:nfs.ca", "nfs.ca", CeRxDomainTestValues.NFS);
			AssertValidValueAttribute("TEL", "tel:567-1111", "567-1111", CeRxDomainTestValues.TELEPHONE);
		}

		/// <exception cref="System.Exception"></exception>
		private void AssertValidValueAttribute(string type, string value, string address, Ca.Infoway.Messagebuilder.Domainvalue.URLScheme
			 urlScheme)
		{
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			TelecommunicationAddress telecommunicationAddress = (TelecommunicationAddress)new TelR2ElementParser().Parse(CreateContext
				(type, SpecificationVersion.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(address, telecommunicationAddress.Address, "correct address returned");
			Assert.AreEqual(urlScheme.CodeValue, telecommunicationAddress.UrlScheme.CodeValue, "correct urlscheme returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAddressUse()
		{
			AbstractSingleElementParser<TelecommunicationAddress> parser = new TelR2ElementParser();
			XmlNode node = CreateNode("<something use=\"H\" value=\"mailto://monkey@monkey\" />");
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse> addressUses = ((TelecommunicationAddress)parser
				.Parse(CreateContext("TEL", SpecificationVersion.V02R02), node, this.xmlResult).BareValue).AddressUses;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, addressUses.Count, "address use count");
			AssertContains("address use HOME", addressUses, CeRxDomainTestValues.HOME_ADDRESS);
			node = CreateNode("<something use=\"H WP\" value=\"mailto://monkey@monkey\" />");
			addressUses = ((TelecommunicationAddress)parser.Parse(CreateContext("TEL", SpecificationVersion.V02R02), node, this.xmlResult
				).BareValue).AddressUses;
			Assert.IsTrue(this.xmlResult.IsValid());
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
