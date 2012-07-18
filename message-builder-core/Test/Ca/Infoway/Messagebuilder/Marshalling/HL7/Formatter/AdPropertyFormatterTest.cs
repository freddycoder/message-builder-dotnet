using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
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
			string result = new AdPropertyFormatter().Format(GetContext("addr"), new ADImpl());
			Assert.AreEqual("<addr nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress postalAddress = new PostalAddress();
			postalAddress.AddPostalAddressPart(new PostalAddressPart("something"));
			string result = formatter.Format(GetContext("addr"), new ADImpl(postalAddress));
			Assert.AreEqual("<addr>something</addr>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress postalAddress = new PostalAddress();
			postalAddress.AddPostalAddressPart(new PostalAddressPart("<cats think they're > humans & dogs 99% of the time/>"));
			string result = formatter.Format(GetContext("addr"), new ADImpl(postalAddress));
			Assert.AreEqual("<addr>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</addr>".Trim(), result.Trim
				(), "something in text node");
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
			string result = formatter.Format(GetContext("addr"), new ADImpl(postalAddress));
			Assert.AreEqual("<addr><city>cityname</city>freeform<delimiter>,</delimiter><state>ON</state></addr>", result.Trim(), "something in text node with goofy sub nodes"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPostalAddressUses()
		{
			AdPropertyFormatter formatter = new AdPropertyFormatter();
			PostalAddress address = new PostalAddress();
			address.AddUse(Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse.HOME);
			address.AddUse(Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse.PUBLIC);
			// since the uses as a set, order is not guaranteed
			string result = formatter.Format(GetContext("addr"), new ADImpl(address));
			Assert.IsTrue(result.StartsWith("<addr use=\""), "open tag");
			Assert.IsTrue(result.Contains("H PUB") || result.Contains("PUB H"), "H PUB");
			Assert.IsTrue(result.Trim().EndsWith("\"></addr>"), "close tag");
		}
	}
}
