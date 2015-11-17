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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class IntR2PropertyFormatterTest : FormatterTestCase
	{
		private class TestableIntR2PropertyFormatter : IntR2PropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<Int32?
			>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, Int32? t, BareANY bareAny
				)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", null, null, null, 
				false), null, new INTImpl());
			// a null value for INT elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
			Assert.IsTrue(this.result.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerValid()
		{
			string integerValue = "34";
			IDictionary<string, string> result = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", null, null, null, 
				false), System.Convert.ToInt32(integerValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.result.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseMandatory()
		{
			string result = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false), new INTImpl()
				);
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
			Assert.IsTrue(this.result.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCasePopulated()
		{
			string result = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false), new INTImpl()
				);
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
			Assert.IsTrue(this.result.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseNotMandatory()
		{
			string result = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, false), null);
			Assert.IsTrue(StringUtils.IsBlank(result), "result");
			Assert.IsTrue(this.result.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerZero()
		{
			string integerValue = "0";
			IDictionary<string, string> result = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", null, null, null, 
				false), System.Convert.ToInt32(integerValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.result.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerNegative()
		{
			string integerValue = "-1";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED, null, false);
			Int32? integer = System.Convert.ToInt32(integerValue);
			IDictionary<string, string> result = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(context, integer, new INTImpl(integer));
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(integerValue, result.SafeGet("value"), "value as expected");
			context.GetModelToXmlResult().ClearErrors();
			string output = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(context, new INTImpl(integer));
			Assert.AreEqual("<name value=\"-1\"/>", output.Trim(), "xml output as expected");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsIntegerZeroNoWarnings()
		{
			string integerValue = "0";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED, null, false);
			string output = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(context, new INTImpl(System.Convert.ToInt32
				(integerValue)));
			Assert.AreEqual("<name value=\"0\"/>", output.Trim(), "xml output as expected");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntegerOperatorNotAllowed()
		{
			string integerValue = "123";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED, null, false);
			INTImpl dataType = new INTImpl(System.Convert.ToInt32(integerValue));
			dataType.Operator = SetOperator.INCLUDE;
			string output = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(context, dataType);
			Assert.AreEqual("<name value=\"123\"/>", output.Trim(), "xml output as expected");
			Assert.IsFalse(context.GetModelToXmlResult().IsValid());
			Assert.AreEqual(1, context.GetModelToXmlResult().GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntegerWithRegionOfInterest()
		{
			string integerValue = "123";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "INT", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED, null, false);
			INTImpl dataType = new INTImpl(System.Convert.ToInt32(integerValue));
			dataType.Unsorted = true;
			string output = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(context, dataType);
			Assert.AreEqual("<name unsorted=\"true\" value=\"123\"/>", output.Trim(), "xml output as expected");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSxcmOperatorAllowed()
		{
			string integerValue = "123";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "SXCM<INT>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED, null, false);
			INTImpl dataType = new INTImpl(System.Convert.ToInt32(integerValue));
			dataType.Operator = SetOperator.INCLUDE;
			string output = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(context, dataType);
			Assert.AreEqual("<name operator=\"I\" value=\"123\"/>", output.Trim(), "xml output as expected");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSxcmNoOperator()
		{
			string integerValue = "123";
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "SXCM<INT>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.REQUIRED, null, false);
			INTImpl dataType = new INTImpl(System.Convert.ToInt32(integerValue));
			string output = new IntR2PropertyFormatterTest.TestableIntR2PropertyFormatter().Format(context, dataType);
			Assert.AreEqual("<name value=\"123\"/>", output.Trim(), "xml output as expected");
			Assert.IsTrue(context.GetModelToXmlResult().IsValid());
		}
	}
}
