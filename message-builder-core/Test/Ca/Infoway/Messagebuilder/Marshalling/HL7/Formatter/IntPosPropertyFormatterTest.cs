using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IntPosPropertyFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			FormatContextImpl context = new FormatContextImpl("name", null, null);
			IDictionary<string, string> result = new IntPosPropertyFormatter().GetAttributeNameValuePairs(context, null);
			// a null value for INT elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerValid()
		{
			string integerValue = "34";
			FormatContextImpl context = new FormatContextImpl("name", null, null);
			IDictionary<string, string> result = new IntPosPropertyFormatter().GetAttributeNameValuePairs(context, System.Convert.ToInt32
				(integerValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerValidWithMaxLength()
		{
			string integerValue = "1234567890";
			FormatContextImpl context = new FormatContextImpl("name", null, null);
			IDictionary<string, string> result = new IntPosPropertyFormatter().GetAttributeNameValuePairs(context, System.Convert.ToInt32
				(integerValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerZero()
		{
			string integerValue = "0";
			FormatContextImpl context = new FormatContextImpl("name", null, null);
			IDictionary<string, string> result = new IntPosPropertyFormatter().GetAttributeNameValuePairs(context, System.Convert.ToInt32
				(integerValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			string @string = new IntPosPropertyFormatter().Format(context, new INTImpl(System.Convert.ToInt32(integerValue)));
			Assert.IsTrue(@string.Contains("<!-- WARNING:"), "warning: " + @string);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerNegative()
		{
			string integerValue = "-1";
			FormatContextImpl context = new FormatContextImpl("name", null, null);
			IDictionary<string, string> result = new IntPosPropertyFormatter().GetAttributeNameValuePairs(context, System.Convert.ToInt32
				(integerValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			string @string = new IntPosPropertyFormatter().Format(context, new INTImpl(System.Convert.ToInt32(integerValue)));
			Assert.IsTrue(@string.Contains("<!-- WARNING:"), "warning: " + @string);
		}
	}
}
