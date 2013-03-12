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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// Currently this is a copy of the CS test, since the class is identical
	/// to the CS class.
	/// </summary>
	/// <remarks>
	/// Currently this is a copy of the CS test, since the class is identical
	/// to the CS class. This will likely change in the future.
	/// </remarks>
	[TestFixture]
	public class CvPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new CvPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(this.result
				, null, "name", null, null, false, SpecificationVersion.R02_04_02, null, null, CodingStrength.CNE), null, null);
			Assert.AreEqual(0, result.Count, "map size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairs()
		{
			// used as expected: an enumerated object is passed in
			IDictionary<string, string> result = new CvPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(this.result
				, null, "name", null, null, false, SpecificationVersion.R02_04_02, null, null, CodingStrength.CNE), CeRxDomainTestValues
				.CENTIMETRE, null);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("code"), "key as expected");
			Assert.AreEqual("cm", result.SafeGet("code"), "value as expected");
			Assert.IsTrue(result.ContainsKey("codeSystem"), "key as expected");
			Assert.AreEqual("1.2.3.4", result.SafeGet("codeSystem"), "value as expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfTrivialCodes()
		{
			string result = new CvPropertyFormatter().Format(GetContext("name"), new CVImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfSimpleCodes()
		{
			string result = new CvPropertyFormatter().Format(GetContext("name"), new CVImpl(CeRxDomainTestValues.CENTIMETRE));
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("Could not locate a registered domain type to match "
				));
			Assert.AreEqual("<name code=\"cm\" codeSystem=\"1.2.3.4\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CVImpl cv = new CVImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION);
			cv.OriginalText = "some original text";
			string result = new CvPropertyFormatter().Format(GetContext("name"), cv);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"><originalText>some original text</originalText></name>", StringUtils.Trim(result
				), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalText()
		{
			CVImpl cv = new CVImpl(null);
			cv.OriginalText = "some original text";
			string result = new CvPropertyFormatter().Format(new FormatContextImpl(this.result, null, "name", "CV", null, false, SpecificationVersion
				.R02_04_03, null, null, CodingStrength.CWE), cv);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name><originalText>some original text</originalText></name>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValueAndOptional()
		{
			CVImpl cv = new CVImpl(null);
			string result = new CvPropertyFormatter().Format(new FormatContextImpl(this.result, null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, false, SpecificationVersion.R02_04_02, null, null, CodingStrength.CNE), cv);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(string.Empty, StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValueAndMandatory()
		{
			CVImpl cv = new CVImpl(null);
			string result = new CvPropertyFormatter().Format(new FormatContextImpl(this.result, null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, false, SpecificationVersion.R02_04_02, null, null, CodingStrength.CNE), cv);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual("<name/>", StringUtils.Trim(result), "result");
		}
	}
}
