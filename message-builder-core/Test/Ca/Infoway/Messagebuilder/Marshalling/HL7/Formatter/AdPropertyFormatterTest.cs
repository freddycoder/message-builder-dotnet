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
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class AdPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new AdPropertyFormatter().Format(GetContext("addr", "AD.FULL"), new ADImpl());
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<addr nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress postalAddress = new PostalAddress();
			postalAddress.AddPostalAddressPart(new PostalAddressPart("something"));
			string result = formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(postalAddress));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(5, this.result.GetHl7Errors().Count);
			// city/state/postalcode/country are mandatory; part without types not allowed 
			Assert.AreEqual("<addr></addr>", result.Trim(), "empty address node node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "<cats think they're > humans & dogs 99% of the time/>"
				));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			string result = formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<addr><city>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</city><state>ON</state><postalCode>H0H0H0</postalCode><country>Canada</country></addr>"
				.Trim(), result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleAddressParts()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress postalAddress = new PostalAddress();
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "cityname"));
			postalAddress.AddPostalAddressPart(new PostalAddressPart("freeform"));
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.DELIMITER, ","));
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			string result = formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(postalAddress));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(4, this.result.GetHl7Errors().Count);
			// no parts without part type; delimiter not allowed; postal code and country mandatory
			Assert.AreEqual("<addr><city>cityname</city><state>ON</state></addr>", result.Trim(), "something in text node with goofy sub nodes suppressed"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPostalAddressUses()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.PHYSICAL);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			// since the uses as a set, order is not guaranteed
			string result = formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.StartsWith("<addr use=\""), "open tag");
			Assert.IsTrue(result.Contains("\"H PHYS\"") || result.Contains("\"H PHYS\""), "H PHYS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatTooManyPostalAddressUses()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.PHYSICAL);
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.DIRECT);
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.CONFIDENTIAL);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			string result = formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(address));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(result.StartsWith("<addr use=\""), "open tag");
			Assert.IsTrue(result.Contains("\"H PHYS DIR CONF\""));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatDuplicatePartTypesAllowed()
		{
			// confirmed via Sam that all part types can occur multiple times
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "US"));
			formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatInvalidUseOfCodeAndCodeSystem()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, CodeUtil.ConvertToCode("Toronto", "1.2.3.4.5"
				)));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(address));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueTooLong()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "12345678901234567890123456789012345678901234567890123456789012345678901234567890"
				));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "123456789012345678901234567890123456789012345678901234567890123456789012345678901"
				));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(address));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatInvalidPartTypeForFull()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.DELIVERY_INSTALLATION_TYPE, "this isn't allowed"
				));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			formatter.Format(GetContext("addr", "AD.FULL"), new ADImpl(address));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValidSearch()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			string formattedAddress = formatter.Format(GetContext("addr", "AD.SEARCH"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<addr><city>Toronto</city></addr>", formattedAddress.Trim());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSearchMustHaveAtLeastOnePartType()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			formatter.Format(GetContext("addr", "AD.SEARCH"), new ADImpl(address));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatSearchCannotHaveUses()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			string formattedAddress = formatter.Format(GetContext("addr", "AD.SEARCH"), new ADImpl(address));
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<addr><city>Toronto</city></addr>", formattedAddress.Trim());
		}
	}
}
