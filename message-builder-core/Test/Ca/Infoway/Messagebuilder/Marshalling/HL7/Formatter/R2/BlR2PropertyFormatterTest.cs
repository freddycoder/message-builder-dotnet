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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class BlR2PropertyFormatterTest : FormatterTestCase
	{
		private class TestableBlR2PropertyFormatter : BlR2PropertyFormatter, TestableAbstractValueNullFlavorPropertyFormatter<Boolean?
			>
		{
			public virtual IDictionary<string, string> GetAttributeNameValuePairsForTest(FormatContext context, Boolean? t, BareANY bareAny
				)
			{
				return base.GetAttributeNameValuePairs(context, t, bareAny);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValueBL()
		{
			IDictionary<string, string> result = new BlR2PropertyFormatterTest.TestableBlR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", "BL", null, null, 
				false), null, new BLImpl());
			// a null value for BL elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsSpecifiedNullValueBL()
		{
			IDictionary<string, string> result = new BlR2PropertyFormatterTest.TestableBlR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", "BL", null, null, 
				false), null, new BLImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE));
			// a null value for BL elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NOT_APPLICABLE.CodeValue, result.SafeGet("nullFlavor"
				), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsBooleanTrueBL()
		{
			IDictionary<string, string> result = new BlR2PropertyFormatterTest.TestableBlR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", "BL", null, null, 
				false), true, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("true", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsBooleanFalseBL()
		{
			IDictionary<string, string> result = new BlR2PropertyFormatterTest.TestableBlR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", "BL", null, null, 
				false), false, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("false", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullValueBN()
		{
			// this test should go through the full formatter (as NFs can sometimes cause a short-circuit of the code path to follow)
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "BN", null, null, false);
			string xml = new BlR2PropertyFormatterTest.TestableBlR2PropertyFormatter().Format(context, new BLImpl());
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("xml output", "<name nullFlavor=\"NI\"/>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSpecifiedNullValueBN()
		{
			// this test should go through the full formatter (as NFs can sometimes cause a short-circuit of the code path to follow)
			Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl context = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "BN", null, null, false);
			string xml = new BlR2PropertyFormatterTest.TestableBlR2PropertyFormatter().Format(context, new BLImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NOT_APPLICABLE));
			// a null value for BL elements results in a nullFlavor attribute
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			AssertXml("xml output", "<name nullFlavor=\"NA\"/>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsBooleanTrueBN()
		{
			IDictionary<string, string> result = new BlR2PropertyFormatterTest.TestableBlR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", "BN", null, null, 
				false), true, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("true", result.SafeGet("value"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsBooleanFalseBN()
		{
			IDictionary<string, string> result = new BlR2PropertyFormatterTest.TestableBlR2PropertyFormatter().GetAttributeNameValuePairsForTest
				(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", "BN", null, null, 
				false), false, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(this.result.IsValid());
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("false", result.SafeGet("value"), "value as expected");
		}
	}
}
