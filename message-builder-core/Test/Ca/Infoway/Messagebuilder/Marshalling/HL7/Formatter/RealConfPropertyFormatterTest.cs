using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class RealConfPropertyFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new RealConfPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), null);
			// a null value for REAL elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatCorrectly()
		{
			string realValue = "0.2564";
			IDictionary<string, string> result = new RealConfPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), new BigDecimal(realValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(realValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueShouldBeGreaterThanZero()
		{
			string realValue = "-0.56";
			Assert.IsTrue(new RealConfPropertyFormatter().IsInvalidValue(null, new BigDecimal(realValue)), "BigDecimal value must be greater than: 0"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueEqualsToZero()
		{
			string realValue = "0.0";
			IDictionary<string, string> result = new RealConfPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), new BigDecimal(realValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.0000", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueShouldBeLessThanOne()
		{
			string realValue = "1.001";
			Assert.IsTrue(new RealConfPropertyFormatter().IsInvalidValue(null, new BigDecimal(realValue)), "BigDecimal value must be Less than: 1"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestRoundedToFourDecimalPlacesFloor()
		{
			string realValue = "0.256444444";
			IDictionary<string, string> result = new RealConfPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), new BigDecimal(realValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.2564", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestRoundedToFourDecimalPlacesCieling()
		{
			string realValue = "0.256455555";
			IDictionary<string, string> result = new RealConfPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), new BigDecimal(realValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.2565", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueEqualsToOne()
		{
			string realValue = "1.0";
			IDictionary<string, string> result = new RealConfPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), new BigDecimal(realValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("1.0000", result.SafeGet("value"), "value as expected");
		}
	}
}
