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
	public class CdPropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairsNullValue()
		{
			IDictionary<string, string> result = new CdPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(this.result
				, null, "name", null, null), null, null);
			Assert.AreEqual(0, result.Count, "map size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestGetAttributeNameValuePairs()
		{
			// used as expected: an enumerated object is passed in
			IDictionary<string, string> result = new CdPropertyFormatter().GetAttributeNameValuePairs(new FormatContextImpl(this.result
				, null, "name", null, null), CeRxDomainTestValues.CENTIMETRE, new CDImpl());
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
			string result = new CdPropertyFormatter().Format(GetContext("name"), new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestHandlingOfSimpleCodes()
		{
			string result = new CdPropertyFormatter().Format(GetContext("name"), new CDImpl(CeRxDomainTestValues.CENTIMETRE));
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("Could not locate a registered domain type to match "
				));
			Assert.AreEqual("<name code=\"cm\" codeSystem=\"1.2.3.4\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CDImpl cd = new CDImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION);
			cd.OriginalText = "some original text";
			string result = new CdPropertyFormatter().Format(GetContext("name"), cd);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"><originalText>some original text</originalText></name>", StringUtils.Trim(result
				), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalText()
		{
			CDImpl cd = new CDImpl(null);
			cd.OriginalText = "some original text";
			string result = new CdPropertyFormatter().Format(GetContext("name"), cd);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// code/codeSystem mandatory (need a CWE coding strength to allow this run to pass without errors)
			Assert.AreEqual("<name><originalText>some original text</originalText></name>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValueAndOptional()
		{
			CDImpl cd = new CDImpl(null);
			string result = new CdPropertyFormatter().Format(new FormatContextImpl(this.result, null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, false, SpecificationVersion.R02_04_03, null, null, CodingStrength.CNE), cd);
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(string.Empty, StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoValueAndMandatory()
		{
			CDImpl cd = new CDImpl(null);
			string result = new CdPropertyFormatter().Format(new FormatContextImpl(this.result, null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, false, SpecificationVersion.R02_04_03, null, null, CodingStrength.CNE), cd);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// "name" mandatory
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("name is a mandatory field, but no value is specified"
				), "error");
			Assert.AreEqual("<name/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNoInternalValuesAndMandatory()
		{
			CDImpl cd = new CDImpl(new _Code_126());
			string result = new CdPropertyFormatter().Format(new FormatContextImpl(this.result, null, "name", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, false, SpecificationVersion.R02_04_03, null, null, CodingStrength.CNE), cd);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.IsTrue(this.result.GetHl7Errors()[0].GetMessage().StartsWith("For codes with codingStrength of CNE, code and codeSystem properties must be provided."
				));
			Assert.AreEqual("<name/>", StringUtils.Trim(result), "result");
		}

		private sealed class _Code_126 : Code
		{
			public _Code_126()
			{
			}

			public string CodeValue
			{
				get
				{
					return null;
				}
			}

			public string CodeSystem
			{
				get
				{
					return null;
				}
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSingleTranslation()
		{
			CDImpl cd = new CDImpl(null);
			cd.Translations.Add(new CDImpl(MockEnum.FRED));
			string result = new CdPropertyFormatter().Format(GetContext("name"), cd);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// code/codeSystem mandatory
			Assert.AreEqual("<name><translation code=\"FRED\" codeSystem=\"1.2.3.4.5\"/></name>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMultipleTranslations()
		{
			CDImpl cd = new CDImpl(null);
			cd.Translations.Add(new CDImpl(MockEnum.FRED));
			cd.Translations.Add(new CDImpl(MockEnum.BARNEY));
			string result = new CdPropertyFormatter().Format(GetContext("name"), cd);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			// code/codeSystem mandatory
			Assert.AreEqual("<name><translation code=\"FRED\" codeSystem=\"1.2.3.4.5\"/><translation code=\"BARNEY\" codeSystem=\"1.2.3.4.5\"/></name>"
				, StringUtils.Trim(result), "result");
		}
	}
}
