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


using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class AdR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new AdR2PropertyFormatter().Format(GetContext("addr", "AD"), new ADImpl());
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<addr nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress postalAddress = new PostalAddress();
			postalAddress.AddPostalAddressPart(new PostalAddressPart("something"));
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(postalAddress));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("empty address node", "<addr>something</addr>", result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "<cats think they're > humans & dogs 99% of the time/>"
				));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node", "<addr><city>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</city><state>ON</state><postalCode>H0H0H0</postalCode><country>Canada</country></addr>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleAddressParts()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress postalAddress = new PostalAddress();
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "cityname"));
			postalAddress.AddPostalAddressPart(new PostalAddressPart("freeform"));
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.DELIMITER, ","));
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(postalAddress));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("something in text node with goofy sub nodes allowed", "<addr><city>cityname</city>freeform<delimiter>,</delimiter><state>ON</state></addr>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleAddressPartsWithUseablePeriods()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress postalAddress = new PostalAddress();
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "cityname"));
			postalAddress.AddPostalAddressPart(new PostalAddressPart("freeform"));
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.DELIMITER, ","));
			postalAddress.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			postalAddress.IsNotOrdered = true;
			postalAddress.AddUseablePeriod(new DateWithPattern(DateUtil.GetDate(2007, 2, 23), "yyyyMMdd"), SetOperator.PERIODIC_HULL);
			postalAddress.AddUseablePeriod(new DateWithPattern(DateUtil.GetDate(2009, 9, 17), "yyyyMMdd"), null);
			postalAddress.AddUseablePeriod(new DateWithPattern(DateUtil.GetDate(2014, 6, 8), "yyyyMMdd"), SetOperator.INCLUDE);
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(postalAddress));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("addr with useable periods", "<addr isNotOrdered=\"true\"><city>cityname</city>freeform<delimiter>,</delimiter><state>ON</state><useablePeriod operator=\"P\" value=\"20070323\"/><useablePeriod operator=\"I\" value=\"20091017\"/><useablePeriod operator=\"I\" value=\"20140708\"/></addr>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPostalAddressUses()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.PHYSICAL);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			// since the uses as a set, order is not guaranteed
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.StartsWith("<addr use=\""), "open tag");
			Assert.IsTrue(result.Contains("\"H PHYS\"") || result.Contains("\"H PHYS\""), "H PHYS");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatManyPostalAddressUses()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.PHYSICAL);
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.DIRECT);
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.CONFIDENTIAL);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.StartsWith("<addr use=\""), "open tag");
			Assert.IsTrue(result.Contains("\"H PHYS DIR CONF\""));
			AssertXml("xml as expected", "<addr use=\"H PHYS DIR CONF\"><city>Toronto</city><state>ON</state><postalCode>H0H0H0</postalCode><country>Canada</country></addr>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatDuplicatePartTypesAllowed()
		{
			// confirmed via Sam that all part types can occur multiple times
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "US"));
			formatter.Format(GetContext("addr", "AD"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatWeirdUseOfCodeAndCodeSystem()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml as expected", "<addr use=\"H\"><city>Toronto</city><state>ON</state><postalCode>H0H0H0</postalCode><country>Canada</country></addr>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatLongValue()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "12345678901234567890123456789012345678901234567890123456789012345678901234567890"
				));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "123456789012345678901234567890123456789012345678901234567890123456789012345678901"
				));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml as expected", "<addr use=\"H\"><city>12345678901234567890123456789012345678901234567890123456789012345678901234567890</city><state>123456789012345678901234567890123456789012345678901234567890123456789012345678901</state><postalCode>H0H0H0</postalCode><country>Canada</country></addr>"
				, result, true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatAddressUnusualPartType()
		{
			AdR2PropertyFormatter formatter = new AdR2PropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse.HOME);
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.DELIVERY_INSTALLATION_TYPE, "this is unusual"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.CITY, "Toronto"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STATE, "ON"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, "H0H0H0"));
			address.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.COUNTRY, "Canada"));
			string result = formatter.Format(GetContext("addr", "AD"), new ADImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml as expected", "<addr use=\"H\"><deliveryInstallationType>this is unusual</deliveryInstallationType><city>Toronto</city><state>ON</state><postalCode>H0H0H0</postalCode><country>Canada</country></addr>"
				, result, true);
		}
	}
}
