using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class MoPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new MoPropertyFormatter().Format(GetContext("name"), new MOImpl((Money)null));
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			MoPropertyFormatter formatter = new MoPropertyFormatter();
			Money money = new Money(new BigDecimal("12.00"), Currency.CANADIAN_DOLLAR);
			string result = formatter.Format(GetContext("amount"), new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"12.00\"/>", result.Trim(), "something in text node");
			money = new Money(new BigDecimal("12"), Currency.CANADIAN_DOLLAR);
			result = formatter.Format(GetContext("amount"), new MOImpl(money));
			Assert.AreEqual("<amount currency=\"CAD\" value=\"12\"/>", result.Trim(), "something in text node");
			money = new Money(new BigDecimal("12.0000"), Currency.EURO);
			result = formatter.Format(GetContext("amount"), new MOImpl(money));
			Assert.AreEqual("<amount currency=\"EUR\" value=\"12.0000\"/>", result.Trim(), "something in text node");
			money = new Money(null, Currency.EURO);
			result = formatter.Format(GetContext("amount"), new MOImpl(money));
			Assert.AreEqual("<amount currency=\"EUR\"/>", result.Trim(), "something in text node");
			money = new Money(new BigDecimal("12.0000"), null);
			result = formatter.Format(GetContext("amount"), new MOImpl(money));
			Assert.AreEqual("<amount value=\"12.0000\"/>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleNameParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddNamePart(new EntityNamePart("prefix", PersonNamePartType.PREFIX));
			personName.AddNamePart(new EntityNamePart("given", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("family", PersonNamePartType.FAMILY));
			personName.AddNamePart(new EntityNamePart("suffix", PersonNamePartType.SUFFIX));
			string result = formatter.Format(GetContext("name"), new PNImpl(personName));
			Assert.AreEqual("<name><prefix>prefix</prefix><given>given</given><family>family</family><suffix>suffix</suffix></name>", 
				result.Trim(), "well formed name");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddNamePart(new EntityNamePart("<cats think they're > humans & dogs 99% of the time/>"));
			string result = formatter.Format(GetContext("name"), new PNImpl(personName));
			Assert.AreEqual("<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result.Trim
				(), "something in text node");
		}
	}
}
