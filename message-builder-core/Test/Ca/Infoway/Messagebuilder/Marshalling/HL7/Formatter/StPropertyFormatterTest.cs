using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class StPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new StPropertyFormatter().Format(GetContext("name"), null);
			Assert.IsTrue(StringUtils.IsBlank(result), "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			AbstractPropertyFormatter formatter = new StPropertyFormatter();
			string result = formatter.Format(GetContext("name"), new STImpl("something"));
			Assert.AreEqual(AddLineSeparator("<name>something</name>"), result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNullWithLanguage()
		{
			AbstractPropertyFormatter formatter = new StPropertyFormatter();
			string result = formatter.Format(new FormatContextImpl("name", "ST.LANG", null), new STImpl("something", "fr-CA"));
			Assert.AreEqual(AddLineSeparator("<name language=\"fr-CA\">something</name>"), result, "something in text node");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueReservedXmlChars()
		{
			AbstractPropertyFormatter formatter = new StPropertyFormatter();
			string result = formatter.Format(GetContext("name"), new STImpl("<cats think they're > humans & dogs 99% of the time/>"));
			Assert.AreEqual("<name>&lt;cats think they&apos;re &gt; humans &amp; dogs 99% of the time/&gt;</name>".Trim(), result.Trim
				(), "something in text node");
		}

		private string AddLineSeparator(string value)
		{
			return value + SystemUtils.LINE_SEPARATOR;
		}
	}
}
