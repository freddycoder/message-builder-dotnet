using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class AbstractAttributePropertyFormatterTest : FormatterTestCase
	{
		private class TestableAttributePropertyFormatter : AbstractAttributePropertyFormatter<string>
		{
			private readonly IDictionary<string, string> nameValuePairs = new Dictionary<string, string>();

			protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, string @string, BareANY 
				bareANY)
			{
				return this.nameValuePairs;
			}

			public virtual void AddNameValuePair(string name, string value)
			{
				this.nameValuePairs[name] = value;
			}

			internal TestableAttributePropertyFormatter(AbstractAttributePropertyFormatterTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly AbstractAttributePropertyFormatterTest _enclosing;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			// no name-value pairs
			AbstractAttributePropertyFormatterTest.TestableAttributePropertyFormatter formatter = new AbstractAttributePropertyFormatterTest.TestableAttributePropertyFormatter
				(this);
			string result = formatter.Format(GetContext("name"), new STImpl("something"));
			Assert.AreEqual(AddLineSeparator("<name/>"), result, "named null format");
			// one name-value pair
			formatter.AddNameValuePair("name1", "value1");
			result = formatter.Format(GetContext("name"), new STImpl("something"));
			Assert.AreEqual(AddLineSeparator("<name name1=\"value1\"/>"), result, "named null format");
			// two name-value pairs
			formatter.AddNameValuePair("name2", "value2");
			result = formatter.Format(GetContext("name"), new STImpl("something"));
			Assert.AreEqual(AddLineSeparator("<name name1=\"value1\" name2=\"value2\"/>"), result, "named null format");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueIndent()
		{
			AbstractAttributePropertyFormatterTest.TestableAttributePropertyFormatter formatter = new AbstractAttributePropertyFormatterTest.TestableAttributePropertyFormatter
				(this);
			string result = formatter.Format(GetContext("name"), new STImpl(), 0);
			Assert.AreEqual(AddLineSeparator("<name nullFlavor=\"NI\"/>"), result, "named null format");
			result = formatter.Format(GetContext("name"), new STImpl(), 1);
			Assert.AreEqual(AddLineSeparator("  <name nullFlavor=\"NI\"/>"), result, "named null format");
			result = formatter.Format(GetContext("name"), new STImpl(), 2);
			Assert.AreEqual(AddLineSeparator("    <name nullFlavor=\"NI\"/>"), result, "named null format");
		}
	}
}
