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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
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
			TEL tel = (TEL)new TelElementParser().Parse(CreateContext("TEL.PHONE", SpecificationVersion.V02R02), node, this.xmlResult
				);
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
			new TelElementParser().Parse(CreateContext("TEL.PHONE", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		// missing scheme; missing address
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoValueAttributeNode()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			new TelElementParser().Parse(CreateContext("TEL.PHONE", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		// missing scheme; missing address
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttributeNode()
		{
			XmlNode node = CreateNode("<something value=\"1234\" />");
			new TelElementParser().Parse(CreateContext("TEL.PHONE", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "HL7 error count");
			Hl7Error hl7Error = this.xmlResult.GetHl7Errors()[0];
			Assert.AreEqual("TelecomAddress must have a valid URL scheme (e.g. 'http://') (<something value=\"1234\"/>)", hl7Error.GetMessage
				(), "error message");
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message code");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueUrlScheme()
		{
			XmlNode node = CreateNode("<something value=\"mailfrom://monkey\" />");
			new TelElementParser().Parse(CreateContext("TEL.PHONE", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count, "HL7 error count");
			// invalid scheme; must have a valid scheme
			Hl7Error hl7Error = this.xmlResult.GetHl7Errors()[0];
			Assert.AreEqual(Hl7ErrorCode.DATA_TYPE_ERROR, hl7Error.GetHl7ErrorCode(), "error message code");
			Assert.AreEqual("Unrecognized URL scheme 'mailfrom' in element /something", hl7Error.GetMessage(), "error message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMixedcaseUrlScheme()
		{
			XmlNode node = CreateNode("<something value=\"mailTO://monkey\" />");
			new TelElementParser().Parse(CreateContext("TEL.URI", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidPlusExtraAttribute()
		{
			XmlNode node = CreateNode("<something extra=\"extra\" value=\"mailto://monkey@monkey\" />");
			TelecommunicationAddress address = (TelecommunicationAddress)new TelElementParser().Parse(CreateContext("TEL.EMAIL", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
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
				new TelElementParser().Parse(new TrivialContext("TEL.URI"), node, this.xmlResult);
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
			XmlNode node = CreateNode("<something value=\"mailto://monkey\">\n" + "</something>");
			new TelElementParser().Parse(CreateContext("TEL.EMAIL", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeAllUrlSchemes()
		{
			AssertValidValueAttribute("TEL.PHONE", "fax:1234", "1234", CeRxDomainTestValues.FAX);
			AssertValidValueAttribute("TEL.URI", "file:c:/temp", "c:/temp", CeRxDomainTestValues.FILE);
			AssertValidValueAttribute("TEL.URI", "file://c:/temp", "c:/temp", CeRxDomainTestValues.FILE);
			AssertValidValueAttribute("TEL.URI", "ftp:ftp.monkey.com", "ftp.monkey.com", CeRxDomainTestValues.FTP);
			AssertValidValueAttribute("TEL.URI", "ftp://ftp.monkey.com", "ftp.monkey.com", CeRxDomainTestValues.FTP);
			AssertValidValueAttribute("TEL.URI", "http:www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTP);
			AssertValidValueAttribute("TEL.URI", "http://www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTP);
			AssertValidValueAttribute("TEL.URI", "https:www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTPS);
			AssertValidValueAttribute("TEL.URI", "https://www.monkey.com", "www.monkey.com", CeRxDomainTestValues.HTTPS);
			AssertValidValueAttribute("TEL.EMAIL", "mailto://monkey@monkey", "monkey@monkey", CeRxDomainTestValues.MAILTO);
			AssertValidValueAttribute("TEL.EMAIL", "mailto:monkey@monkey", "monkey@monkey", CeRxDomainTestValues.MAILTO);
			AssertValidValueAttribute("TEL.URI", "nfs://nfs.ca", "nfs.ca", CeRxDomainTestValues.NFS);
			AssertValidValueAttribute("TEL.URI", "nfs:nfs.ca", "nfs.ca", CeRxDomainTestValues.NFS);
			AssertValidValueAttribute("TEL.PHONE", "tel:567-1111", "567-1111", CeRxDomainTestValues.TELEPHONE);
		}

		/// <exception cref="System.Exception"></exception>
		private void AssertValidValueAttribute(string type, string value, string address, Ca.Infoway.Messagebuilder.Domainvalue.URLScheme
			 urlScheme)
		{
			XmlNode node = CreateNode("<something value=\"" + value + "\" />");
			TelecommunicationAddress telecommunicationAddress = (TelecommunicationAddress)new TelElementParser().Parse(CreateContext(
				type, SpecificationVersion.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(address, telecommunicationAddress.Address, "correct address returned");
			Assert.AreEqual(urlScheme.CodeValue, telecommunicationAddress.UrlScheme.CodeValue, "correct urlscheme returned");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAddressUse()
		{
			AbstractSingleElementParser<TelecommunicationAddress> parser = new TelElementParser();
			XmlNode node = CreateNode("<something use=\"H\" value=\"Mailto://monkey@monkey\" />");
			ICollection<Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse> addressUses = ((TelecommunicationAddress)parser
				.Parse(CreateContext("TEL.EMAIL", SpecificationVersion.V02R02), node, this.xmlResult).BareValue).AddressUses;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, addressUses.Count, "address use count");
			AssertContains("address use HOME", addressUses, CeRxDomainTestValues.HOME_ADDRESS);
			node = CreateNode("<something use=\"H WP\" value=\"mailto://monkey@monkey\" />");
			addressUses = ((TelecommunicationAddress)parser.Parse(CreateContext("TEL.EMAIL", SpecificationVersion.V02R02), node, this
				.xmlResult).BareValue).AddressUses;
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
