using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class ScPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ScPropertyFormatter().Format(GetContext("name"), null);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(StringUtils.IsBlank(result), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullCode()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("something", null);
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(AddLineSeparator("<name>something</name>"), result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCode()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("something", Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE, "aDisplayName", "aCodeSystemName", "aCodeSystemVersion");
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(AddLineSeparator("<name code=\"cm\" codeSystem=\"2.16.840.1.113883.5.141\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">something</name>"
				), result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("<cats think they're > humans & dogs 99% of the time/>", null);
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result.Trim
				(), "something in text node");
		}
	}
}
