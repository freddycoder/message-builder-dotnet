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
	public class SxcmCdR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavor()
		{
			string result = new SxcmCdR2PropertyFormatter().Format(GetContext("name", "SXCM<CD>"), new SXCM_R2Impl<CodedTypeR2<Code>>
				(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION));
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
			CodedTypeR2<Code> name1 = new CodedTypeR2<Code>();
			name1.Code = CeRxDomainTestValues.CENTIMETRE;
			CodedTypeR2<Code> name2 = new CodedTypeR2<Code>();
			name2.Code = Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE;
			CodedTypeR2<Code> value1 = new CodedTypeR2<Code>();
			value1.Code = Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus.NORMAL;
			CodedTypeR2<Code> value2 = new CodedTypeR2<Code>();
			value2.Code = Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass.ACT;
			CodeRole codeRole1 = new CodeRole(name1, value1, true);
			CodeRole codeRole2 = new CodeRole(name2, value2, true);
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.Operator = SetOperator.INTERSECT;
			codedType.Qualifier.Add(codeRole1);
			codedType.Qualifier.Add(codeRole2);
			codedType.Translation.Add(translation1);
			codedType.Translation.Add(translation2);
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			string result = new SxcmCdR2PropertyFormatter().Format(GetContext("name", "SXCM<CD>"), new SXCM_R2Impl<CodedTypeR2<Code>>
				(codedType));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\" operator=\"A\">"
				 + "<originalText>some original text</originalText>" + "<qualifier inverted=\"true\"><name code=\"cm\" codeSystem=\"1.2.3.4\"/><value code=\"normal\" codeSystem=\"2.16.840.1.113883.5.14\" displayName=\"Normal\"/></qualifier>"
				 + "<qualifier inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" displayName=\"Male\"/><value code=\"ACT\" codeSystem=\"2.16.840.1.113883.5.6\" displayName=\"Act\"/></qualifier>"
				 + "<translation code=\"kg\" codeSystem=\"1.2.3.4\"/>" + "<translation code=\"[foz_br]\" codeSystem=\"1.2.3.4\"/>" + "</name>"
				, StringUtils.Trim(result), true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestOriginalTextAndNullFlavor()
		{
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "original text allowed for CD";
			codedType.OriginalText = originalText;
			SXCM_R2<CodedTypeR2<Code>> sxcmCd = new SXCM_R2Impl<CodedTypeR2<Code>>(codedType);
			sxcmCd.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
			string result = new SxcmCdR2PropertyFormatter().Format(GetContext("name", "SXCM<CD>"), sxcmCd);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"><originalText>original text allowed for CD</originalText></name>", StringUtils
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
			CodedTypeR2<Code> name1 = new CodedTypeR2<Code>();
			name1.Code = CeRxDomainTestValues.CENTIMETRE;
			CodedTypeR2<Code> name2 = new CodedTypeR2<Code>();
			name2.Code = Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.MALE;
			CodedTypeR2<Code> value1 = new CodedTypeR2<Code>();
			value1.Code = Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus.NORMAL;
			CodedTypeR2<Code> value2 = new CodedTypeR2<Code>();
			value2.Code = Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass.ACT;
			CodeRole codeRole1 = new CodeRole(name1, value1, true);
			CodeRole codeRole2 = new CodeRole(name2, value2, true);
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.SimpleValue = "simpleValue";
			codedType.Operator = SetOperator.CONVEX_HULL;
			codedType.Value = BigDecimal.ONE;
			codedType.Operator = SetOperator.INTERSECT;
			codedType.Qualifier.Add(codeRole1);
			codedType.Qualifier.Add(codeRole2);
			codedType.Translation.Add(translation1);
			codedType.Translation.Add(translation2);
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			SXCM_R2<CodedTypeR2<Code>> sxcm_cd = new SXCM_R2Impl<CodedTypeR2<Code>>(codedType);
			string result = new SxcmCdR2PropertyFormatter().Format(GetContext("name", "SXCM<CD>"), sxcm_cd);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(2, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\" operator=\"A\">"
				 + "<originalText>some original text</originalText>" + "<qualifier inverted=\"true\"><name code=\"cm\" codeSystem=\"1.2.3.4\"/><value code=\"normal\" codeSystem=\"2.16.840.1.113883.5.14\" displayName=\"Normal\"/></qualifier>"
				 + "<qualifier inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" displayName=\"Male\"/><value code=\"ACT\" codeSystem=\"2.16.840.1.113883.5.6\" displayName=\"Act\"/></qualifier>"
				 + "<translation code=\"kg\" codeSystem=\"1.2.3.4\"/>" + "<translation code=\"[foz_br]\" codeSystem=\"1.2.3.4\"/>" + "</name>"
				, StringUtils.Trim(result), true);
		}
	}
}
