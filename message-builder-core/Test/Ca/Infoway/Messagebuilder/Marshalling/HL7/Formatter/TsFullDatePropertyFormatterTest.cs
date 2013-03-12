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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
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
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDatePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(xmlResult
				, null, "name", null, null), null, new TSImpl());
			// a null value for TS elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsDate()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDatePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(xmlResult
				, null, "name", "TS.DATE", null, false, SpecificationVersion.R02_04_02, null, null, null), calendar, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("19990423", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsInvalidDatePattern()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithInvalidPattern = new DateWithPattern(calendar, "yyyyMMMdd");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDatePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(xmlResult
				, null, "name", "TS.DATE", null, false, SpecificationVersion.R02_04_02, null, null, null), dateWithInvalidPattern, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("1999Apr23", result.SafeGet("value"), "value as expected (even though invalid)");
			Assert.AreEqual(1, xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsForDateWithPattern()
		{
			// used as expected: a date object is passed in
			PlatformDate calendar = DateUtil.GetDate(1999, 3, 23, 10, 11, 12, 0);
			DateWithPattern dateWithPattern = new DateWithPattern(calendar, "yyyyMM");
			ModelToXmlResult xmlResult = new ModelToXmlResult();
			IDictionary<string, string> result = new TsFullDatePropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(xmlResult
				, null, "name", "TS.DATE", null, false, SpecificationVersion.R02_04_02, null, null, null), dateWithPattern, null);
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual("199904", result.SafeGet("value"), "value as expected");
			Assert.IsTrue(xmlResult.GetHl7Errors().IsEmpty());
		}

		private FormatContextImpl CreateFormatContextWithTimeZone(TimeZone timeZone)
		{
			return new FormatContextImpl(new ModelToXmlResult(), null, "name", null, null, null, false, null, timeZone, null, true, null
				);
		}
	}
}
