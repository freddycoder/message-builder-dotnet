using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
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
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", null, null, null, false);
			IDictionary<string, string> result = new TestableIntPosPropertyFormatter().GetAttributeNameValuePairsForTest(context, null
				, new INTImpl());
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
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", null, null, null, false);
			Int32? integer = System.Convert.ToInt32(integerValue);
			IDictionary<string, string> result = new TestableIntPosPropertyFormatter().GetAttributeNameValuePairsForTest(context, integer
				, new INTImpl(integer));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerValidWithMaxLength()
		{
			string integerValue = "1234567890";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", null, null, null, false);
			Int32? integer = System.Convert.ToInt32(integerValue);
			IDictionary<string, string> result = new TestableIntPosPropertyFormatter().GetAttributeNameValuePairsForTest(context, integer
				, new INTImpl(integer));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerZero()
		{
			string integerValue = "0";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "INT.POS", null, null, false);
			Int32? integer = System.Convert.ToInt32(integerValue);
			IDictionary<string, string> result = new TestableIntPosPropertyFormatter().GetAttributeNameValuePairsForTest(context, integer
				, new INTImpl(integer));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			context.GetModelToXmlResult().ClearErrors();
			string output = new TestableIntPosPropertyFormatter().Format(context, new INTImpl(integer));
			Assert.AreEqual("<name value=\"0\"/>", output.Trim(), "xml output as expected");
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerNegative()
		{
			string integerValue = "-1";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", null, null, null, false);
			Int32? integer = System.Convert.ToInt32(integerValue);
			IDictionary<string, string> result = new TestableIntPosPropertyFormatter().GetAttributeNameValuePairsForTest(context, integer
				, new INTImpl(integer));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			context.GetModelToXmlResult().ClearErrors();
			string output = new TestableIntPosPropertyFormatter().Format(context, new INTImpl(integer));
			Assert.AreEqual("<name value=\"-1\"/>", output.Trim(), "xml output as expected");
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count, "1 error");
		}
	}
}
