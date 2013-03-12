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
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
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
			IDictionary<string, string> result = new IntNonNegPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new 
				ModelToXmlResult(), null, "name", null, null), null, new INTImpl());
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
			IDictionary<string, string> result = new IntNonNegPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new 
				ModelToXmlResult(), null, "name", null, null), System.Convert.ToInt32(integerValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseMandatory()
		{
			string result = new IntNonNegPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "name", "INT"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED), new INTImpl());
			MarshallingTestCase.AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCasePopulated()
		{
			string result = new IntNonNegPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "name", "INT"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED), new INTImpl());
			MarshallingTestCase.AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseNotMandatory()
		{
			string result = new IntNonNegPropertyFormatter().Format(new FormatContextImpl(new ModelToXmlResult(), null, "name", "INT"
				, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), null);
			Assert.IsTrue(StringUtils.IsBlank(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerZero()
		{
			string integerValue = "0";
			IDictionary<string, string> result = new IntNonNegPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(new 
				ModelToXmlResult(), null, "name", null, null), System.Convert.ToInt32(integerValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerNegative()
		{
			string integerValue = "-1";
			FormatContextImpl context = new FormatContextImpl(new ModelToXmlResult(), null, "name", "INT.NONNEG", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.REQUIRED);
			Int32? integer = System.Convert.ToInt32(integerValue);
			IDictionary<string, string> result = new IntPosPropertyFormatter().GetAttributeNameValuePairs(context, integer, new INTImpl
				(integer));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			context.GetModelToXmlResult().ClearErrors();
			string output = new IntPosPropertyFormatter().Format(context, new INTImpl(integer));
			Assert.AreEqual("<name value=\"-1\"/>", output.Trim(), "xml output as expected");
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerZeroNoWarnings()
		{
			string integerValue = "0";
			FormatContextImpl context = new FormatContextImpl(new ModelToXmlResult(), null, "name", "INT.NONNEG", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.REQUIRED);
			string output = new IntNonNegPropertyFormatter().Format(context, new INTImpl(System.Convert.ToInt32(integerValue)));
			Assert.AreEqual("<name value=\"0\"/>", output.Trim(), "xml output as expected");
			Assert.IsTrue(context.GetModelToXmlResult().GetHl7Errors().IsEmpty(), "no errors");
		}
	}
}
