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
	public class CeR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavor()
		{
			string result = new CeR2PropertyFormatter().Format(GetContext("name", "CE"), new CE_R2Impl<Code>(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidFull()
		{
			CodedTypeR2<Code> translation1 = new CodedTypeR2<Code>();
			translation1.Code = CeRxDomainTestValues.KILOGRAM;
			CodedTypeR2<Code> translation2 = new CodedTypeR2<Code>();
			translation2.Code = CeRxDomainTestValues.FLUID_OUNCE;
			CodedTypeR2<Code> translation3 = new CodedTypeR2<Code>();
			translation3.Code = new _Code_62();
			translation3.NullFlavorForTranslationOnly = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER;
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.Translation.Add(translation1);
			codedType.Translation.Add(translation2);
			codedType.Translation.Add(translation3);
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			string result = new CeR2PropertyFormatter().Format(GetContext("name", "CE"), new CE_R2Impl<Code>(codedType));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">"
				 + "<originalText>some original text</originalText>" + "<translation code=\"kg\" codeSystem=\"1.2.3.4\"/>" + "<translation code=\"[foz_br]\" codeSystem=\"1.2.3.4\"/>"
				 + "<translation codeSystem=\"1.2.3.4\" nullFlavor=\"OTH\"/>" + "</name>", StringUtils.Trim(result), true);
		}

		private sealed class _Code_62 : Code
		{
			public _Code_62()
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
					return CeRxDomainTestValues.FLUID_OUNCE.CodeSystem;
				}
			}

			public string CodeSystemName
			{
				get
				{
					return null;
				}
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "original text allowed for CE";
			codedType.OriginalText = originalText;
			CE_R2<Code> ce = new CE_R2Impl<Code>(codedType);
			ce.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
			string result = new CeR2PropertyFormatter().Format(GetContext("name", "CE"), ce);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"><originalText>original text allowed for CE</originalText></name>", StringUtils
				.Trim(result), true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEverythingSpecified()
		{
			CodedTypeR2<Code> translation1 = new CodedTypeR2<Code>();
			translation1.Code = CeRxDomainTestValues.KILOGRAM;
			CodedTypeR2<Code> translation2 = new CodedTypeR2<Code>();
			translation2.Code = CeRxDomainTestValues.FLUID_OUNCE;
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.SimpleValue = "simpleValue";
			codedType.Operator = SetOperator.CONVEX_HULL;
			codedType.Value = BigDecimal.ONE;
			codedType.Translation.Add(translation1);
			codedType.Translation.Add(translation2);
			codedType.Qualifier.Add(new CodeRole());
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			CE_R2<Code> ce = new CE_R2Impl<Code>(codedType);
			string result = new CeR2PropertyFormatter().Format(GetContext("name", "CE"), ce);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(4, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">"
				 + "<originalText>some original text</originalText>" + "<translation code=\"kg\" codeSystem=\"1.2.3.4\"/>" + "<translation code=\"[foz_br]\" codeSystem=\"1.2.3.4\"/>"
				 + "</name>", StringUtils.Trim(result), true);
		}
	}
}
