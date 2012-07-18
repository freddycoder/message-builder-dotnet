using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue.Basic;
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
			Assert.IsTrue(StringUtils.IsBlank(result), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNullCode()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("something", null);
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.AreEqual(AddLineSeparator("<name>something</name>"), result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueCode()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("something", State.ALBERTA);
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.AreEqual(AddLineSeparator("<name code=\"AB\">something</name>"), result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			ScPropertyFormatter formatter = new ScPropertyFormatter();
			CodedString<Code> codedString = new CodedString<Code>("<cats think they're > humans & dogs 99% of the time/>", null);
			string result = formatter.Format(GetContext("name"), new SCImpl<Code>(codedString));
			Assert.AreEqual("<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result.Trim
				(), "something in text node");
		}

		private string AddLineSeparator(string value)
		{
			return value + SystemUtils.LINE_SEPARATOR;
		}
	}
}
