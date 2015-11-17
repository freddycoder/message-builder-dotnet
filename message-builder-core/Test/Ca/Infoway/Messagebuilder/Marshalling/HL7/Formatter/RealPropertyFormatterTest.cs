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
	public class RealPropertyFormatterTest
	{
		private class TestableRealPropertyFormatter : RealPropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<BigDecimal
			>
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
			IDictionary<string, string> result = new RealPropertyFormatterTest.TestableRealPropertyFormatter().GetAttributeNameValuePairsForTest
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
			IDictionary<string, string> result = new RealPropertyFormatterTest.TestableRealPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(realValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNegativeValue()
		{
			string realValue = "-0.56899";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			string result = new RealPropertyFormatterTest.TestableRealPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", null, null, null, false), new REALImpl(bigDecimal));
			Assert.AreEqual("<name value=\"-0.56899\"/>", result.Trim(), "xml output");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueEqualsToZero()
		{
			string realValue = "0.0";
			IDictionary<string, string> result = new RealPropertyFormatterTest.TestableRealPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.0", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueManyDigitsToLeftOfDecimal()
		{
			string realValue = "12345.0001";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			string result = new RealPropertyFormatterTest.TestableRealPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", null, null, null, false), new REALImpl(bigDecimal));
			Assert.AreEqual("<name value=\"12345.0001\"/>", result.Trim(), "xml output");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueManyDigitsOnBothSidesOfDecimal()
		{
			string realValue = "123456.123456";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			string result = new RealPropertyFormatterTest.TestableRealPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", null, null, null, false), new REALImpl(bigDecimal));
			Assert.AreEqual("<name value=\"123456.123456\"/>", result.Trim(), "xml output");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueEqualsToOne()
		{
			string realValue = "1.0";
			IDictionary<string, string> result = new RealPropertyFormatterTest.TestableRealPropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", null, null
				, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("1.0", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}
	}
}
