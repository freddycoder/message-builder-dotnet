using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class IntNonNegPropertyFormatterTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new IntNonNegPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), null);
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
			IDictionary<string, string> result = new IntNonNegPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), System.Convert.ToInt32(integerValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseMandatory()
		{
			string result = new IntNonNegPropertyFormatter().Format(new FormatContextImpl("name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED), new INTImpl());
			MarshallingTestCase.AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCasePopulated()
		{
			string result = new IntNonNegPropertyFormatter().Format(new FormatContextImpl("name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED), new INTImpl());
			MarshallingTestCase.AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseNotMandatory()
		{
			string result = new IntNonNegPropertyFormatter().Format(new FormatContextImpl("name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL), null);
			Assert.IsTrue(StringUtils.IsBlank(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerZero()
		{
			string integerValue = "0";
			IDictionary<string, string> result = new IntNonNegPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl("name"
				, null, null), System.Convert.ToInt32(integerValue));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerNegative()
		{
			string integerValue = "-1";
			FormatContextImpl context = new FormatContextImpl("name", "INT.NONNEG", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED
				);
			Int32? intActual = System.Convert.ToInt32(integerValue);
			INTImpl intImpl = new INTImpl(intActual);
			IDictionary<string, string> result = new IntNonNegPropertyFormatter().GetAttributeNameValuePairs(context, intActual);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			string @string = new IntNonNegPropertyFormatter().Format(context, intImpl);
			Assert.IsTrue(@string.Contains("<!-- WARNING:"), "warning: ");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerZeroNoWarnings()
		{
			string integerValue = "0";
			string @string = new IntNonNegPropertyFormatter().Format(new FormatContextImpl("name", "INT.NONNEG", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.REQUIRED), new INTImpl(System.Convert.ToInt32(integerValue)));
			Assert.IsFalse(@string.Contains("<!-- WARNING:"), "warning: " + @string);
		}
	}
}
