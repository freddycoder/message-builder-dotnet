using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class HxitCeR2PropertyFormatterTest : FormatterTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullFlavor()
		{
			string result = new HxitCeR2PropertyFormatter().Format(GetContext("name", "HXIT<CE>"), new CE_R2Impl<Code>(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
				.NO_INFORMATION));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", StringUtils.Trim(result), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidFull()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(new DateWithPattern(DateUtil.GetDate(2006, 
				11, 25), "yyyyMMdd"), new DateWithPattern(DateUtil.GetDate(2007, 0, 2), "yyyyMMdd"));
			CodedTypeR2<Code> translation1 = new CodedTypeR2<Code>();
			translation1.Code = CeRxDomainTestValues.KILOGRAM;
			CodedTypeR2<Code> translation2 = new CodedTypeR2<Code>();
			translation2.Code = CeRxDomainTestValues.FLUID_OUNCE;
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>();
			codedType.Code = CeRxDomainTestValues.CENTIMETRE;
			codedType.CodeSystemName = "aCodeSystemName";
			codedType.CodeSystemVersion = "aCodeSystemVersion";
			codedType.DisplayName = "aDisplayName";
			codedType.Translation.Add(translation1);
			codedType.Translation.Add(translation2);
			codedType.ValidTime = interval;
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			string result = new HxitCeR2PropertyFormatter().Format(GetContext("name", "HXIT<CE>"), new CE_R2Impl<Code>(codedType));
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">"
				 + "<originalText>some original text</originalText>" + "<translation code=\"kg\" codeSystem=\"1.2.3.4\"/>" + "<translation code=\"[foz_br]\" codeSystem=\"1.2.3.4\"/>"
				 + "<validTime><low value=\"20061225\"/><high value=\"20070102\"/></validTime>" + "</name>", StringUtils.Trim(result), true
				);
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
			string result = new HxitCeR2PropertyFormatter().Format(GetContext("name", "HXIT<CE>"), ce);
			Assert.IsTrue(this.result.IsValid());
			AssertXml("result", "<name nullFlavor=\"NI\"><originalText>original text allowed for CE</originalText></name>", StringUtils
				.Trim(result), true);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestEverythingSpecified()
		{
			Interval<PlatformDate> interval = IntervalFactory.CreateLowHigh<PlatformDate>(new DateWithPattern(DateUtil.GetDate(2006, 
				11, 25), "yyyyMMdd"), new DateWithPattern(DateUtil.GetDate(2007, 0, 2), "yyyyMMdd"));
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
			codedType.ValidTime = interval;
			EncapsulatedData originalText = new EncapsulatedData();
			originalText.Content = "some original text";
			codedType.OriginalText = originalText;
			CE_R2<Code> ce = new CE_R2Impl<Code>(codedType);
			string result = new HxitCeR2PropertyFormatter().Format(GetContext("name", "HXIT<CE>"), ce);
			Assert.IsFalse(this.result.IsValid());
			Assert.AreEqual(4, this.result.GetHl7Errors().Count);
			AssertXml("result", "<name code=\"cm\" codeSystem=\"1.2.3.4\" codeSystemName=\"aCodeSystemName\" codeSystemVersion=\"aCodeSystemVersion\" displayName=\"aDisplayName\">"
				 + "<originalText>some original text</originalText>" + "<translation code=\"kg\" codeSystem=\"1.2.3.4\"/>" + "<translation code=\"[foz_br]\" codeSystem=\"1.2.3.4\"/>"
				 + "<validTime><low value=\"20061225\"/><high value=\"20070102\"/></validTime>" + "</name>", StringUtils.Trim(result), true
				);
		}
	}
}
