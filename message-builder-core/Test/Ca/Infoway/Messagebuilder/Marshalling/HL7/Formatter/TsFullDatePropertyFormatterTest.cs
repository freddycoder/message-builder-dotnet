using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class TsFullDatePropertyFormatterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new TsFullDatePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), null);
			// a null value for TS elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDate()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			IDictionary<string, string> result = new TsFullDatePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), calendar);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("19990423", result.SafeGet("value"), "value as expected");
		}

		private FormatContextImpl CreateFormatContextWithTimeZone(TimeZone timeZone)
		{
			return new FormatContextImpl("name", null, null, false, null, timeZone, null, true);
		}
	}
}
