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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class RealR2PropertyFormatterTest
	{
		private class TestableRealR2PropertyFormatter : RealR2PropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter
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
			IDictionary<string, string> result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", "REAL", 
				null, null, false), null, new REALImpl());
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
			IDictionary<string, string> result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", "REAL", 
				null, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(realValue, result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueNegative()
		{
			string realValue = "-0.56";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			string result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", "REAL", null, null, false), new REALImpl(bigDecimal));
			Assert.AreEqual("<name value=\"-0.56\"/>", result.Trim(), "xml output");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueEqualsToZero()
		{
			string realValue = "0.0";
			IDictionary<string, string> result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", "REAL", 
				null, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.0", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestManyDecimalPlaces()
		{
			string realValue = "0.256444444";
			IDictionary<string, string> result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", "REAL", 
				null, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("0.256444444", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValueEqualsToOne()
		{
			string realValue = "1.0";
			IDictionary<string, string> result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.modelToXmlResult, null, "name", "REAL", 
				null, null, false), new BigDecimal(realValue), null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("1.0", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(this.modelToXmlResult.IsValid(), "no errors");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOperatorNotAllowed()
		{
			string realValue = "123.56";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			REALImpl dataType = new REALImpl(bigDecimal);
			dataType.Operator = SetOperator.EXCLUDE;
			string result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", "REAL", null, null, false), dataType);
			Assert.AreEqual("<name value=\"123.56\"/>", result.Trim(), "xml output");
			Assert.IsFalse(this.modelToXmlResult.IsValid());
			Assert.AreEqual(1, this.modelToXmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSxcmOperatorAllowed()
		{
			string realValue = "123.56";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			REALImpl dataType = new REALImpl(bigDecimal);
			dataType.Operator = SetOperator.EXCLUDE;
			string result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", "SXCM<REAL>", null, null, false), dataType);
			Assert.AreEqual("<name operator=\"E\" value=\"123.56\"/>", result.Trim(), "xml output");
			Assert.IsTrue(this.modelToXmlResult.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSxcmNoOperator()
		{
			string realValue = "123.56";
			BigDecimal bigDecimal = new BigDecimal(realValue);
			REALImpl dataType = new REALImpl(bigDecimal);
			string result = new RealR2PropertyFormatterTest.TestableRealR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.modelToXmlResult, null, "name", "SXCM<REAL>", null, null, false), dataType);
			Assert.AreEqual("<name value=\"123.56\"/>", result.Trim(), "xml output");
			Assert.IsTrue(this.modelToXmlResult.IsValid());
		}
	}
}
