/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


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
