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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TelUriPropertyFormatterTest
	{
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
			IDictionary<string, string> result = new TelUriPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), null, new 
				TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			// a null value for TEL.URI elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey(AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		private FormatContextImpl CreateContext()
		{
			return new FormatContextImpl(this.xmlResult, null, "name", "TEL.URI", null, false, SpecificationVersion.R02_04_03, null, 
				null, null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelUriValid()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FILE;
			address.Address = "value";
			IDictionary<string, string> result = new TelUriPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), address, new 
				TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("file://value", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelUriInvalidUse()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FILE;
			address.Address = "value";
			address.AddressUses.Add(Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.HOME);
			new TelUriPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), address, new TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsTelAllValidUris()
		{
			FormatContextImpl context = CreateContext();
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.FILE, context, "file://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.FTP, context, "ftp://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.HTTP, context, "http://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.HTTPS, context, "https://");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.MAILTO, context, "mailto:");
			FormatterAssert.AssertValidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.NFS, context, "nfs://");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsAllInvalidUris()
		{
			FormatContextImpl context = CreateContext();
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.FAX, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.MLLP, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.MODEM, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.TELEPHONE, context);
			this.xmlResult.ClearErrors();
			FormatterAssert.AssertInvalidUrlScheme(new TelUriPropertyFormatter(), CeRxDomainTestValues.TELNET, context);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelUriWithValidMaxLength()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FILE;
			// file:// + 248 = 255 (max)
			address.Address = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678";
			IDictionary<string, string> result = new TelUriPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), address, new 
				TELImpl());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("file://" + address.Address, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelUriWithInvalidMaxLength()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.FILE;
			// file:// + 249 = 256 (1 over max)
			address.Address = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789";
			IDictionary<string, string> result = new TelUriPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), address, new 
				TELImpl());
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("file://" + address.Address, result.SafeGet("value"), "value as expected");
		}
	}
}
