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
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class AnyR2PropertyFormatterTest : FormatterTestCase
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
		public virtual void TestPq()
		{
			object quantity = CreateQuantity("12", Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.GRAM);
			ANYImpl<object> pqImpl = new ANYImpl<object>(quantity, null, StandardDataType.PQ);
			string result = new AnyR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false), pqImpl, 
				0);
			AssertXml("result", "<name unit=\"g\" value=\"12\" xsi:type=\"PQ\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestTs()
		{
			PlatformDate date = DateUtil.GetDate(2003, 2, 27);
			DateWithPattern dateWithPattern = new DateWithPattern(date, "yyyyMMdd");
			ANYImpl<object> tsImpl = new ANYImpl<object>(new MbDate(dateWithPattern), null, StandardDataType.TS);
			string result = new AnyR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false), tsImpl, 
				0);
			AssertXml("result", "<name value=\"20030327\" xsi:type=\"TS\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPn()
		{
			PersonName name = PersonName.CreateFirstNameLastName("John", "Smith");
			ANYImpl<object> pnImpl = new ANYImpl<object>(name, null, StandardDataType.PN);
			string result = new AnyR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false), pnImpl, 
				0);
			AssertXml("result", "<name use=\"L\" xsi:type=\"PN\"><given>John</given><family>Smith</family></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestSt()
		{
			string myString = "some value";
			ANYImpl<object> stImpl = new ANYImpl<object>(myString, null, StandardDataType.ST);
			stImpl.Language = "en-CA";
			string result = new AnyR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false), stImpl, 
				0);
			AssertXml("result", "<name language=\"en-CA\" xsi:type=\"ST\">some value</name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPqWithNullFlavor()
		{
			ANYImpl<object> pqImpl = new ANYImpl<object>(null, Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.UNKNOWN, StandardDataType
				.PQ);
			pqImpl.OriginalText = "orig text";
			string result = new AnyR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false), pqImpl, 
				0);
			AssertXml("result", "<name nullFlavor=\"UNK\"/>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatStWithCdataValue()
		{
			AnyR2PropertyFormatter formatter = new AnyR2PropertyFormatter();
			FormatContext context = GetContext("name", "ANY");
			ANYImpl<object> dataType = new ANYImpl<object>("something", null, StandardDataType.ST);
			dataType.IsCdata = true;
			string result = formatter.Format(context, dataType);
			Assert.AreEqual(AddLineSeparator("<name xsi:type=\"ST\"><![CDATA[something]]></name>"), result, "something in text node");
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			ANYImpl<object> urgImpl = new ANYImpl<object>(null, null, StandardDataType.AD);
			string result = new AnyR2PropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "ANY", null, null, false), urgImpl, 0);
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		private PhysicalQuantity CreateQuantity(string quantity, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
			 unit)
		{
			return new PhysicalQuantity(new BigDecimal(quantity), unit);
		}
		//	@Test
		//	public void testRto() throws Exception {
		//		Ratio<PhysicalQuantity, PhysicalQuantity> ratio = new Ratio<PhysicalQuantity, PhysicalQuantity>();
		//		ratio.setNumerator(new PhysicalQuantity(new BigDecimal(1), ca.infoway.messagebuilder.domainvalue.basic.UnitsOfMeasureCaseSensitive.CENTIMETRE));
		//		ratio.setDenominator(new PhysicalQuantity(new BigDecimal(2), ca.infoway.messagebuilder.domainvalue.basic.UnitsOfMeasureCaseSensitive.METRE));
		//		
		//		ANYImpl<Object> rtoImpl = new ANYImpl<Object>(ratio, null, StandardDataType.RTO_PQ_DRUG_PQ_DRUG);
		//		
		//		String result = new AnyR2PropertyFormatter().format(new FormatContextImpl(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null), rtoImpl, 0);
		//		assertXml("result", "<name xsi:type=\"RTO_PQ_PQ\"><numerator unit=\"cm\" value=\"1\" xsi:type=\"PQ\"/><denominator unit=\"m\" value=\"2\" xsi:type=\"PQ\"/></name>", result);
		//	}
		//	@Test
		//	public void testCdWithAllMetadata() throws Exception {
		//		ANYImpl<Object> cdImpl = new ANYImpl<Object>(MockEnum.BARNEY, null, StandardDataType.CD_LAB);
		//		cdImpl.setDisplayName("disp name");
		//		cdImpl.setOriginalText("orig text");
		//		cdImpl.getTranslations().add(new CDImpl(MockEnum.BETTY));
		//		cdImpl.getTranslations().add(new CDImpl(MockEnum.BAM_BAM));
		//		
		//		String result = new AnyR2PropertyFormatter().format(new FormatContextImpl(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null), cdImpl, 0);
		//		assertXml("result", "<name code=\"BARNEY\" codeSystem=\"1.2.3.4.5\" displayName=\"disp name\" xsi:type=\"CD\"><originalText>orig text</originalText><translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\"/><translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\"/></name>", result);
		//		assertTrue(this.result.isValid());
		//	}
		//	@Test
		//	public void testCdWithNullFlavorAndMetadata() throws Exception {
		//		ANYImpl<Object> cdImpl = new ANYImpl<Object>(null, NullFlavor.UNKNOWN, StandardDataType.CD_LAB);
		//		cdImpl.setOriginalText("orig text");
		//		cdImpl.getTranslations().add(new CDImpl(MockEnum.BETTY));
		//		cdImpl.getTranslations().add(new CDImpl(MockEnum.BAM_BAM));
		//		
		//		String result = new AnyR2PropertyFormatter().format(new FormatContextImpl(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null), cdImpl, 0);
		//		assertXml("result", "<name nullFlavor=\"UNK\" xsi:type=\"CD\"><originalText>orig text</originalText><translation code=\"BETTY\" codeSystem=\"1.2.3.4.5\"/><translation code=\"BAM_BAM\" codeSystem=\"1.2.3.4.5\"/></name>", result);
		//		assertTrue(this.result.isValid());
		//	}
		//	@Test
		//	public void testUrg() throws Exception {
		//		UncertainRange<PhysicalQuantity> urg = UncertainRangeFactory.createLowHigh(createQuantity("55", ca.infoway.messagebuilder.domainvalue.basic.UnitsOfMeasureCaseSensitive.MILLIMETER), createQuantity("60", ca.infoway.messagebuilder.domainvalue.basic.UnitsOfMeasureCaseSensitive.MILLIMETER));
		//		ANYImpl<Object> urgImpl = new ANYImpl<Object>(urg, null, StandardDataType.URG_PQ_BASIC);
		//		String result = new AnyR2PropertyFormatter().format(new FormatContextImpl(this.result, null, "name", "ANY", null, null, false, SpecificationVersion.R02_04_02, null, null, null), urgImpl, 0);
		//		assertXml("result", "<name xsi:type=\"URG_PQ\"><low unit=\"mm\" value=\"55\"/><high unit=\"mm\" value=\"60\"/></name>", result);
		//		
		//	}
	}
}
