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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class RealConfPropertyFormatterTest
	{
		private class TestableRealConfPropertyFormatter : RealConfPropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter
			<BigDecimal>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, BigDecimal t, BareANY
				 bareAny)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}
		}

		private ModelToXmlResult modelToXmlResult = new ModelToXmlResult();

		[TearDown]
		public virtual void Teardown()
		{
			this.modelToXmlResult.ClearErrors();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), null, new REALImpl());
			// a null value for REAL elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatCorrectly()
		{
			string realValue = "0.2564";
			IDictionary<string, string> result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(realValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueShouldBeGreaterThanZero()
		{
			string realValue = "-0.56";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			string result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", null, null, null, false), new REALImpl(bigDecimal));
			Assert.AreEqual("<name value=\"-0.56\"/>", result.Trim(), "xml output");
			Assert.AreEqual(1, this.modelToXmlResult.GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueEqualsToZero()
		{
			string realValue = "0.0";
			IDictionary<string, string> result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.0", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueShouldBeLessThanOne()
		{
			string realValue = "1.0001";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			string result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", null, null, null, false), new REALImpl(bigDecimal));
			Assert.AreEqual("<name value=\"1.0001\"/>", result.Trim(), "xml output");
			Assert.AreEqual(1, this.modelToXmlResult.GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueShouldBeLessThanOnePassingInALargeNumber()
		{
			string realValue = "1234.01";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			string result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", null, null, null, false), new REALImpl(bigDecimal));
			Assert.AreEqual("<name value=\"4.01\"/>", result.Trim(), "xml output");
			Assert.AreEqual(1, this.modelToXmlResult.GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestRoundedToFourDecimalPlacesFloor()
		{
			string realValue = "0.256444444";
			IDictionary<string, string> result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.2564", result.SafeGet("value"), "value as expected");
			Assert.AreEqual(1, this.modelToXmlResult.GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestRoundedToFourDecimalPlacesCeiling()
		{
			string realValue = "0.256455555";
			IDictionary<string, string> result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.2565", result.SafeGet("value"), "value as expected");
			Assert.AreEqual(1, this.modelToXmlResult.GetHl7Errors().Count, "1 error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueEqualsToOne()
		{
			string realValue = "1.0";
			IDictionary<string, string> result = new RealConfPropertyFormatterTest.TestableRealConfPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("1.0", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}
	}
}
