using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class AnyPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUrg()
		{
			UncertainRange<PhysicalQuantity> urg = UncertainRangeFactory.CreateLowHigh(CreateQuantity("55", Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER), CreateQuantity("60", Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLIMETER));
			ANYImpl<object> urgImpl = new ANYImpl<object>(urg, null, StandardDataType.URG_PQ_BASIC);
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY.LAB", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), urgImpl, 0);
			AssertXml("result", "<name specializationType=\"URG_PQ.BASIC\" xsi:type=\"URG_PQ\"><low unit=\"mm\" value=\"55\"/><high unit=\"mm\" value=\"60\"/></name>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPq()
		{
			object quantity = CreateQuantity("12", Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.GRAM);
			ANYImpl<object> pqImpl = new ANYImpl<object>(quantity, null, StandardDataType.PQ_BASIC);
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), pqImpl, 0);
			AssertXml("result", "<name specializationType=\"PQ.BASIC\" unit=\"g\" value=\"12\" xsi:type=\"PQ\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTs()
		{
			object time = DateUtil.GetDate(2003, 2, 27);
			ANYImpl<object> tsImpl = new ANYImpl<object>(time, null, StandardDataType.TS_FULLDATE);
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), tsImpl, 0);
			AssertXml("result", "<name specializationType=\"TS.FULLDATE\" value=\"20030327\" xsi:type=\"TS\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPn()
		{
			PersonName name = PersonName.CreateFirstNameLastName("John", "Smith");
			ANYImpl<object> pnImpl = new ANYImpl<object>(name, null, StandardDataType.PN_BASIC);
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), pnImpl, 0);
			AssertXml("result", "<name specializationType=\"PN.BASIC\" use=\"L\" xsi:type=\"PN\"><given>John</given><family>Smith</family></name>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestStLang()
		{
			string myString = "some value";
			ANYImpl<object> stImpl = new ANYImpl<object>(myString, null, StandardDataType.ST_LANG);
			stImpl.Language = "en-CA";
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), stImpl, 0);
			AssertXml("result", "<name language=\"en-CA\" specializationType=\"ST.LANG\" xsi:type=\"ST\">some value</name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestRto()
		{
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio = new Ratio<PhysicalQuantity, PhysicalQuantity>();
			ratio.Numerator = new PhysicalQuantity(new BigDecimal(1), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE);
			ratio.Denominator = new PhysicalQuantity(new BigDecimal(2), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.METRE);
			ANYImpl<object> rtoImpl = new ANYImpl<object>(ratio, null, StandardDataType.RTO_PQ_DRUG_PQ_DRUG);
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), rtoImpl, 0);
			// FIXME: TM (see RM18656) - this is not quite right - I believe the specializationType should be omitted (though should check if it is ok as is)
			AssertXml("result", "<name specializationType=\"RTO_PQ.DRUG_PQ.DRUG\" xsi:type=\"RTO_PQ_PQ\"><numerator specializationType=\"PQ.DRUG\" unit=\"cm\" value=\"1\" xsi:type=\"PQ\"/><denominator specializationType=\"PQ.DRUG\" unit=\"m\" value=\"2\" xsi:type=\"PQ\"/></name>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestCdWithAllMetadata()
		{
			ANYImpl<MockEnum> cdImpl = new ANYImpl<MockEnum>(MockEnum.BARNEY, null, StandardDataType.CD_LAB);
			cdImpl.DisplayName = "disp name";
			cdImpl.OriginalText = "orig text";
			cdImpl.Translations.Add(new CDImpl(MockEnum.BETTY));
			cdImpl.Translations.Add(new CDImpl(MockEnum.BAM_BAM));
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false), cdImpl, 
				0);
			AssertXml("result", "<name code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" displayName=\"disp name\" specializationType=\"CD.LAB\" xsi:type=\"CD\"><originalText>orig text</originalText><translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\"/><translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\"/></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestCdWithNullFlavorAndMetadata()
		{
			ANYImpl<object> cdImpl = new ANYImpl<object>(null, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.UNKNOWN, StandardDataType
				.CD_LAB);
			cdImpl.OriginalText = "orig text";
			cdImpl.Translations.Add(new CDImpl(MockEnum.BETTY));
			cdImpl.Translations.Add(new CDImpl(MockEnum.BAM_BAM));
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), cdImpl, 0);
			AssertXml("result", "<name nullFlavor=\"UNK\" specializationType=\"CD.LAB\" xsi:type=\"CD\"><originalText>orig text</originalText><translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\"/><translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\"/></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPqLabWithNullFlavorAndMetadata()
		{
			ANYImpl<object> pqImpl = new ANYImpl<object>(null, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.UNKNOWN, StandardDataType
				.PQ_LAB);
			pqImpl.OriginalText = "orig text";
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), pqImpl, 0);
			AssertXml("result", "<name nullFlavor=\"UNK\" specializationType=\"PQ.LAB\" xsi:type=\"PQ\"><originalText>orig text</originalText></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatStWithCdataValue()
		{
			AnyPropertyFormatter formatter = new AnyPropertyFormatter();
			FormatContext context = GetContext("name", "ANY");
			ANYImpl<object> dataType = new ANYImpl<object>("something", null, StandardDataType.ST);
			dataType.IsCdata = true;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual(AddLineSeparator("<name xsi:type=\"ST\"><![CDATA[something]]></name>"), result, "something in text node");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestUrgPqLabForBC()
		{
			UncertainRange<PhysicalQuantity> urg = new UncertainRange<PhysicalQuantity>(new PhysicalQuantity(new BigDecimal(1), null)
				, new PhysicalQuantity(new BigDecimal(124), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.GRAMS_PER_LITRE
				), null, null, Representation.LOW_HIGH, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, null
				, null, true, false);
			AnyPropertyFormatter formatter = new AnyPropertyFormatter();
			FormatContext context = GetContext("name", "ANY", SpecificationVersion.V02R04_BC);
			ANYImpl<object> any = new ANYImpl<object>(urg, null, StandardDataType.URG_PQ_LAB);
			any.OriginalText = "<124";
			string result = formatter.Format(context, any);
			AssertXml("result", "<name specializationType=\"URG_PQ.LAB\" xsi:type=\"URG_PQ\"><originalText>&lt;124</originalText><low inclusive=\"true\" nullFlavor=\"NI\" value=\"1\"/><high inclusive=\"false\" unit=\"g/L\" value=\"124\"/></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			ANYImpl<object> urgImpl = new ANYImpl<object>(null, null, StandardDataType.URG_PQ_BASIC);
			string result = new AnyPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "name", "ANY.LAB", null, null, false), urgImpl, 0);
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		private PhysicalQuantity CreateQuantity(string quantity, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
			 unit)
		{
			return new PhysicalQuantity(new BigDecimal(quantity), unit);
		}
	}
}
