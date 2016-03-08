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


using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class CvR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavor()
		{
			string result = new CvR2PropertyFormatter().Format(GetContext("name", "CV"), new CV_R2Impl<Code>(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidFull()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			string result = new CvR2PropertyFormatter().Format(GetContext("name", "CV"), new CV_R2Impl<Code>(codedType));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\"><originalText>some original text</originalText></name>"
				, StringUtils.Trim(result), true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "original text allowed for CV";
			codedType.OriginalText = originalText;
			CV_R2<Code> cv = new CV_R2Impl<Code>(codedType);
			cv.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
			string result = new CvR2PropertyFormatter().Format(GetContext("name", "CV"), cv);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"><originalText>original text allowed for CV</originalText></name>", StringUtils
				.Trim(result), true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEverythingSpecified()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.SimpleValue = "simpleValue";
			codedType.Operator = SetOperator.CONVEX_HULL;
			codedType.Value = BigDecimal.ONE;
			codedType.Translation.Add(new CodedTypeR2<Code>());
			codedType.Qualifier.Add(new CodeRole());
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			CV_R2<Code> cv = new CV_R2Impl<Code>(codedType);
			string result = new CvR2PropertyFormatter().Format(GetContext("name", "CV"), cv);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(5, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\"><originalText>some original text</originalText></name>"
				, StringUtils.Trim(result), true);
		}

		// CO tests (CO and CV share the same formatter)
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavorCo()
		{
			string result = new CvR2PropertyFormatter().Format(GetContext("name", "CO"), new COImpl<Code>(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidFullCo()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			string result = new CvR2PropertyFormatter().Format(GetContext("name", "CO"), new COImpl<Code>(codedType));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\"><originalText>some original text</originalText></name>"
				, StringUtils.Trim(result), true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavorCo()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "original text allowed for CO";
			codedType.OriginalText = originalText;
			CO<Code> co = new COImpl<Code>(codedType);
			co.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
			string result = new CvR2PropertyFormatter().Format(GetContext("name", "CO"), co);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"><originalText>original text allowed for CO</originalText></name>", StringUtils
				.Trim(result), true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEverythingSpecifiedCo()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.SimpleValue = "simpleValue";
			codedType.Operator = SetOperator.CONVEX_HULL;
			codedType.Value = BigDecimal.ONE;
			codedType.Translation.Add(new CodedTypeR2<Code>());
			codedType.Qualifier.Add(new CodeRole());
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			CO<Code> co = new COImpl<Code>(codedType);
			string result = new CvR2PropertyFormatter().Format(GetContext("name", "CO"), co);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(5, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\"><originalText>some original text</originalText></name>"
				, StringUtils.Trim(result), true);
		}
	}
}
