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
	public class CdR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavor()
		{
			string result = new CdR2PropertyFormatter().Format(GetContext("name", "CD"), new CD_R2Impl<Code>(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
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
			codedType.Qualifier.Add(codeRole1);
			codedType.Qualifier.Add(codeRole2);
			codedType.Translation.Add(translation1);
			codedType.Translation.Add(translation2);
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			string result = new CdR2PropertyFormatter().Format(GetContext("name", "CD"), new CD_R2Impl<Code>(codedType));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">"
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
			CD_R2<Code> cd = new CD_R2Impl<Code>(codedType);
			cd.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;
			string result = new CdR2PropertyFormatter().Format(GetContext("name", "CD"), cd);
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
			codedType.Qualifier.Add(codeRole1);
			codedType.Qualifier.Add(codeRole2);
			codedType.Translation.Add(translation1);
			codedType.Translation.Add(translation2);
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			CD_R2<Code> cd = new CD_R2Impl<Code>(codedType);
			string result = new CdR2PropertyFormatter().Format(GetContext("name", "CD"), cd);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(3, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">"
				 + "<originalText>some original text</originalText>" + "<qualifier inverted=\"true\"><name code=\"cm\" codeSystem=\"1.2.3.4\"/><value code=\"normal\" codeSystem=\"2.16.840.1.113883.5.14\" displayName=\"Normal\"/></qualifier>"
				 + "<qualifier inverted=\"true\"><name code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\" displayName=\"Male\"/><value code=\"ACT\" codeSystem=\"2.16.840.1.113883.5.6\" displayName=\"Act\"/></qualifier>"
				 + "<translation code=\"kg\" codeSystem=\"1.2.3.4\"/>" + "<translation code=\"[foz_br]\" codeSystem=\"1.2.3.4\"/>" + "</name>"
				, StringUtils.Trim(result), true);
		}
	}
}
