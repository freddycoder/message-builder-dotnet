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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TelPhonemailPropertyFormatterTest
	{
		private class TestableTelPhonemailPropertyFormatter : TelPhonemailPropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter
			<TelecommunicationAddress>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, TelecommunicationAddress
				 t, BareANY bareAny)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}
		}

		private ModelToXmlResult xmlResult = new ModelToXmlResult();

		[TearDown]
		public virtual void Teardown()
		{
			this.xmlResult.ClearErrors();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONE"), null, new TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			// a null value for TEL.PHONEMAIL elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey(AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateContext(string type)
		{
			return CreateContext(type, SpecificationVersion.R02_04_03);
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateContext(string type, SpecificationVersion
			 version)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.xmlResult, null, "name", type, null
				, null, false, version, null, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelPhonemailValid()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "value";
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONE"), address, new TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:value", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelPhonemailWithSpecializationType()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "value";
			TELImpl bareAny = new TELImpl();
			bareAny.DataType = StandardDataType.TEL_PHONE;
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONEMAIL"), address, bareAny);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(3, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:value", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(result.ContainsKey("specializationType"), "key as expected");
			Assert.AreEqual("TEL.PHONE", result.SafeGet("specializationType"), "value as expected");
			Assert.IsTrue(result.ContainsKey("xsi:type"), "key as expected");
			Assert.AreEqual("TEL", result.SafeGet("xsi:type"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelPhonemailMissingSpecializationType()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "value";
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONEMAIL"), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(3, result.Count, "map size");
			// ST and xsi:type are provided after detecting invalid/missing ST
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:value", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(result.ContainsKey("specializationType"), "key as expected");
			Assert.AreEqual("TEL.PHONE", result.SafeGet("specializationType"), "value as expected");
			Assert.IsTrue(result.ContainsKey("xsi:type"), "key as expected");
			Assert.AreEqual("TEL", result.SafeGet("xsi:type"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelAllMissingSpecializationType()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "value";
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.ALL"), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(3, result.Count, "map size");
			// ST and xsi:type are provided after detecting invalid/missing ST
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:value", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(result.ContainsKey("specializationType"), "key as expected");
			Assert.AreEqual("TEL.PHONE", result.SafeGet("specializationType"), "value as expected");
			Assert.IsTrue(result.ContainsKey("xsi:type"), "key as expected");
			Assert.AreEqual("TEL", result.SafeGet("xsi:type"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelPhonemailMissingSpecializationType2()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "value";
			TELImpl bareAny = new TELImpl();
			bareAny.DataType = null;
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONEMAIL"), address, bareAny);
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(3, result.Count, "map size");
			// ST and xsi:type are provided after detecting invalid/missing ST
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:value", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(result.ContainsKey("specializationType"), "key as expected");
			Assert.AreEqual("TEL.PHONE", result.SafeGet("specializationType"), "value as expected");
			Assert.IsTrue(result.ContainsKey("xsi:type"), "key as expected");
			Assert.AreEqual("TEL", result.SafeGet("xsi:type"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsPhonemailAllValidSchemes()
		{
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = CreateContext("TEL.PHONE");
			FormatterAssert.AssertValidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.FAX, context, "fax:");
			FormatterAssert.AssertValidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.TELEPHONE, context, "tel:");
			context = CreateContext("TEL.EMAIL");
			FormatterAssert.AssertValidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.MAILTO, context, "mailto:");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidSchemes()
		{
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = CreateContext("TEL.PHONE");
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.FILE, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.FTP, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.HTTP, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.HTTPS, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.MLLP, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.MODEM, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.TELNET, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter(), CeRxDomainTestValues
				.NFS, context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIncludeUses()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "value";
			address.AddAddressUse(CeRxDomainTestValues.HOME_ADDRESS);
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONE"), address, new TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:value", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(result.ContainsKey("use"), "use key as expected");
			Assert.AreEqual("H", result.SafeGet("use"), "use as expected");
			address.AddAddressUse(CeRxDomainTestValues.MOBILE_CONTACT);
			result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest(
				CreateContext("TEL.PHONE"), address, new TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
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
			AssertInvalidAddressUse(CeRxDomainTestValues.PRIMARY_HOME);
			AssertInvalidAddressUse(CeRxDomainTestValues.PUBLIC);
			AssertInvalidAddressUse(CeRxDomainTestValues.VACATION_HOME);
		}

		private void AssertInvalidAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse addressUse)
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FAX;
			address.Address = "4167620032";
			address.AddAddressUse(addressUse);
			this.xmlResult.ClearErrors();
			new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest(CreateContext
				("TEL.PHONE"), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("TelecomAddressUse is not valid: " + addressUse.CodeValue, this.xmlResult.GetHl7Errors()[0].GetMessage(), 
				"expected message");
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
			address.Address = "someAddress";
			this.xmlResult.ClearErrors();
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = CreateContext("TEL.PHONE");
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(context, address, new TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("use"), "key as expected");
			Assert.AreEqual(addressUse.CodeValue, result.SafeGet("use"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelEmailWithValidMaxLength()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.MAILTO;
			// mailto: + 43 = 50 (max)
			address.Address = "1234567890123456789012345678901234567890123";
			IDictionary<string, string> result = new TestableTelUriPropertyFormatter().GetAttributeNameValuePairsForTest(CreateContext
				("TEL.EMAIL"), address, new TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("mailto:" + address.Address, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelEmailWithInvalidMaxLength()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.MAILTO;
			// mailto: + 44 = 51 (max+1)
			address.Address = "12345678901234567890123456789012345678901234";
			IDictionary<string, string> result = new TestableTelUriPropertyFormatter().GetAttributeNameValuePairsForTest(CreateContext
				("TEL.EMAIL"), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("mailto:" + address.Address, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelPhoneForMr2009WithValidMaxLength()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			// tel: + 36 = 40 (max)
			address.Address = "123456789012345678901234567890123456";
			IDictionary<string, string> result = new TestableTelUriPropertyFormatter().GetAttributeNameValuePairsForTest(CreateContext
				("TEL.PHONE", SpecificationVersion.R02_04_02), address, new TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:" + address.Address, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelPhoneForMr2009WithInvalidMaxLength()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			// tel: + 37 = 41 (max + 1)
			address.Address = "1234567890123456789012345678901234567";
			IDictionary<string, string> result = new TestableTelUriPropertyFormatter().GetAttributeNameValuePairsForTest(CreateContext
				("TEL.PHONE", SpecificationVersion.R02_04_02), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:" + address.Address, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelPhoneForMr2007WithValidMaxLength()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			// tel: + 21 = 25 (max)
			address.Address = "123456789012345678901";
			IDictionary<string, string> result = new TestableTelUriPropertyFormatter().GetAttributeNameValuePairsForTest(CreateContext
				("TEL.PHONE", SpecificationVersion.V02R02), address, new TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:" + address.Address, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelPhoneForMr2007WithInvalidMaxLength()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			// tel: + 22 = 26 (max + 1)
			address.Address = "1234567890123456789012";
			IDictionary<string, string> result = new TestableTelUriPropertyFormatter().GetAttributeNameValuePairsForTest(CreateContext
				("TEL.PHONE", SpecificationVersion.V02R02), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("tel:" + address.Address, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidUsesForEmail()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.MAILTO;
			address.Address = "value";
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.ANSWERING_MACHINE);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.BAD);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.CONFIDENTIAL);
			// invalid 
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.DIRECT);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.EMERGENCY_CONTACT);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.HOME);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.MOBILE);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PAGER);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PRIMARY_HOME);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PUBLISHED);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.TEMPORARY);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.VACATION_HOME);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.WORKPLACE);
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.EMAIL"), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(9, this.xmlResult.GetHl7Errors().Count);
			// 8 bad uses + 1 for too many
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("mailto:value", result.SafeGet("value"), "value as expected");
			ICollection<string> uses = FormatterAssert.ToSet(result.SafeGet("use"));
			FormatterAssert.AssertContainsSame("uses", FormatterAssert.ToSet("EC H MC TMP WP"), uses);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidUsesForMr2009Phone()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FAX;
			address.Address = "value";
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.ANSWERING_MACHINE);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.BAD);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.CONFIDENTIAL);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.DIRECT);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.EMERGENCY_CONTACT);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.HOME);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.MOBILE);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PAGER);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PRIMARY_HOME);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PUBLISHED);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.TEMPORARY);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.VACATION_HOME);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.WORKPLACE);
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONE", SpecificationVersion.R02_04_02), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(6, this.xmlResult.GetHl7Errors().Count);
			// 5 bad uses + 1 for too many
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("fax:value", result.SafeGet("value"), "value as expected");
			ICollection<string> uses = FormatterAssert.ToSet(result.SafeGet("use"));
			FormatterAssert.AssertContainsSame("uses", FormatterAssert.ToSet("CONF DIR EC H MC PG TMP WP"), uses);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidUsesForMr2007Phone()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FAX;
			address.Address = "value";
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.ANSWERING_MACHINE);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.BAD);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.CONFIDENTIAL);
			// invalid 
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.DIRECT);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.EMERGENCY_CONTACT);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.HOME);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.MOBILE);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PAGER);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PRIMARY_HOME);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PUBLISHED);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.TEMPORARY);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.VACATION_HOME);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.WORKPLACE);
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONE", SpecificationVersion.V02R02), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(7, this.xmlResult.GetHl7Errors().Count);
			// 6 bad uses + 1 for too many
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("fax:value", result.SafeGet("value"), "value as expected");
			ICollection<string> uses = FormatterAssert.ToSet(result.SafeGet("use"));
			FormatterAssert.AssertContainsSame("uses", FormatterAssert.ToSet("DIR EC H MC PG TMP WP"), uses);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidUsesForCerxPhone()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FAX;
			address.Address = "value";
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.ANSWERING_MACHINE);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.BAD);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.CONFIDENTIAL);
			// invalid 
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.DIRECT);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.EMERGENCY_CONTACT);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.HOME);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.MOBILE);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PAGER);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PRIMARY_HOME);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PUBLISHED);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.TEMPORARY);
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.VACATION_HOME);
			// invalid
			address.AddAddressUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.WORKPLACE);
			IDictionary<string, string> result = new TelPhonemailPropertyFormatterTest.TestableTelPhonemailPropertyFormatter().GetAttributeNameValuePairsForTest
				(CreateContext("TEL.PHONE", SpecificationVersion.V01R04_3), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(8, this.xmlResult.GetHl7Errors().Count);
			// 7 bad uses + 1 for too many
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("fax:value", result.SafeGet("value"), "value as expected");
			ICollection<string> uses = FormatterAssert.ToSet(result.SafeGet("use"));
			FormatterAssert.AssertContainsSame("uses", FormatterAssert.ToSet("EC H MC PG TMP WP"), uses);
		}

		[Test]
		public virtual void TestCeRxDatatypeDetermination()
		{
			TelecommunicationAddress telecomAddress = new TelecommunicationAddress();
			string type = "TEL.PHONEMAIL";
			VersionNumber version = SpecificationVersion.V01R04_3;
			Hl7Errors errors = this.xmlResult;
			telecomAddress.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			Assert.AreEqual("TEL.PHONE", new TelValidationUtils().DetermineActualType(telecomAddress, type, null, version, null, null
				, errors, true));
			Assert.IsTrue(this.xmlResult.IsValid());
			telecomAddress.UrlScheme = CeRxDomainTestValues.FAX;
			Assert.AreEqual("TEL.PHONE", new TelValidationUtils().DetermineActualType(telecomAddress, type, null, version, null, null
				, errors, true));
			Assert.IsTrue(this.xmlResult.IsValid());
			telecomAddress.UrlScheme = CeRxDomainTestValues.MAILTO;
			Assert.AreEqual("TEL.EMAIL", new TelValidationUtils().DetermineActualType(telecomAddress, type, null, version, null, null
				, errors, true));
			Assert.IsTrue(this.xmlResult.IsValid());
			telecomAddress.UrlScheme = CeRxDomainTestValues.FTP;
			// this error will be caught elsewhere
			Assert.AreEqual("TEL.PHONE", new TelValidationUtils().DetermineActualType(telecomAddress, type, null, version, null, null
				, errors, true));
			Assert.IsTrue(this.xmlResult.IsValid());
		}
	}
}
