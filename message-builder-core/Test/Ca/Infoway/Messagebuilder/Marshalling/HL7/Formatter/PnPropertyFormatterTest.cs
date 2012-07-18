using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class PnPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new PnPropertyFormatter().Format(GetContext("name"), new PNImpl());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", result.Trim(), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddNamePart(new EntityNamePart("Steve Shaw"));
			string result = formatter.Format(GetContext("name"), new PNImpl(personName));
			Assert.AreEqual("<name>Steve Shaw</name>", result.Trim(), "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullMultipleNameParts()
		{
			PnPropertyFormatter formatter = new PnPropertyFormatter();
			PersonName personName = new PersonName();
			personName.AddNamePart(new EntityNamePart("prefix", PersonNamePartType.PREFIX, "IN"));
			personName.AddNamePart(new EntityNamePart("given", PersonNamePartType.GIVEN));
			personName.AddNamePart(new EntityNamePart("family", PersonNamePartType.FAMILY));
			personName.AddNamePart(new EntityNamePart("suffix", PersonNamePartType.SUFFIX, "IN"));
			string result = formatter.Format(GetContext("name"), new PNImpl(personName));
			Assert.AreEqual("<name><prefix qualifier=\"IN\">prefix</prefix><given>given</given><family>family</family><suffix qualifier=\"IN\">suffix</suffix></name>"
				, result.Trim(), "well formed name");
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
