using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class TelR2PropertyFormatterTest : FormatterTestCase
	{
		[TearDown]
		public virtual void Teardown()
		{
			this.result.ClearErrors();
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateContext(string type)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", type, null, null
				, false, SpecificationVersion.R02_04_03, null, null, null, false);
		}

		// tests for valid/invalid schemes?? valid/invalid address uses? 
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestImpliedNullValue()
		{
			string result = new TelR2PropertyFormatter().Format(CreateContext("TEL"), new TELImpl());
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullValue()
		{
			string result = new TelR2PropertyFormatter().Format(CreateContext("TEL"), new TELImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NOT_APPLICABLE));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<name nullFlavor=\"NA\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelPhoneValid()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "aValue";
			string result = new TelR2PropertyFormatter().Format(CreateContext("TEL"), new TELImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<name value=\"tel:aValue\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIncludeUses()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "aValue";
			address.AddAddressUse(CeRxDomainTestValues.HOME_ADDRESS);
			string result = new TelR2PropertyFormatter().Format(CreateContext("TEL"), new TELImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<name use=\"H\" value=\"tel:aValue\"/>", result);
			address.AddAddressUse(CeRxDomainTestValues.MOBILE_CONTACT);
			result = new TelR2PropertyFormatter().Format(CreateContext("TEL"), new TELImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<name use=\"H MC\" value=\"tel:aValue\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTelEmail()
		{
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.MAILTO;
			address.Address = "1234567890123456789012345678901234567890123";
			string result = new TelR2PropertyFormatter().Format(CreateContext("TEL"), new TELImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<name value=\"mailto:1234567890123456789012345678901234567890123\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIncludeUsesAndUseablePeriods()
		{
			PlatformDate date1 = DateUtil.GetDate(2004, 5, 10, 9, 42, 43, 123);
			PlatformDate date2 = DateUtil.GetDate(2006, 6, 11, 11, 31, 32, 444);
			TelecommunicationAddress address = new TelecommunicationAddress();
			address.UrlScheme = CeRxDomainTestValues.TELEPHONE;
			address.Address = "aValue";
			address.AddAddressUse(CeRxDomainTestValues.HOME_ADDRESS);
			address.AddAddressUse(CeRxDomainTestValues.MOBILE_CONTACT);
			address.AddUseablePeriod(new DateWithPattern(date1, "yyyyMMddHHmmss.SSS0"), SetOperator.EXCLUDE);
			address.AddUseablePeriod(new DateWithPattern(date2, "yyyyMMddHHmmss.SSS0"), null);
			string result = new TelR2PropertyFormatter().Format(CreateContext("TEL"), new TELImpl(address));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("xml output", "<name use=\"H MC\" value=\"tel:aValue\"><useablePeriod operator=\"E\" value=\"20040610094243.1230\"/><useablePeriod operator=\"I\" value=\"20060711113132.4440\"/></name>"
				, result);
		}
	}
}
