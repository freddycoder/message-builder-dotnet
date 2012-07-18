using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class BlPropertyFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new BlPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), null);
			// a null value for BL elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsBooleanTrue()
		{
			IDictionary<string, string> result = new BlPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), true);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("true", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsBooleanFalse()
		{
			IDictionary<string, string> result = new BlPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name", null
				, null), false);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("false", result.SafeGet("value"), "value as expected");
		}
	}
}
