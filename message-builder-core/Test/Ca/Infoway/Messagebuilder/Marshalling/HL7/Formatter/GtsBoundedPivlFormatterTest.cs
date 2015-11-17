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
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class GtsBoundedPivlFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		[TearDown]
		public virtual void Teardown()
		{
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicAsMR2009()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreatePeriod(new DateDiff(CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY))));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name specializationType=\"GTS.BOUNDEDPIVL\" xsi:type=\"SXPR_TS\">" + "<comp specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\">"
				 + "<low value=\"19691231\"/>" + "<high value=\"19691231\"/>" + "</comp>" + "<comp operator=\"I\" specializationType=\"PIVL_TS.DATETIME\" xsi:type=\"PIVL_TS\">"
				 + "<period unit=\"d\" value=\"3\"/>" + "</comp>" + "</name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicAsCeRx()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreatePeriod(new DateDiff(CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit
				.DAY))));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.V01R04_3, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name xsi:type=\"SXPR_TS\">" + "<comp operator=\"I\" xsi:type=\"IVL_TS\">" + "<low value=\"19691231\"/>"
				 + "<high value=\"19691231\"/>" + "</comp>" + "<comp xsi:type=\"PIVL_TS\">" + "<period unit=\"d\" value=\"3\"/>" + "</comp>"
				 + "</name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicFreq()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowWidth<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), new DateDiff(CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY))), PeriodicIntervalTime
				.CreateFrequency(3, CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY)));
			string result = new GtsBoundedPivlFormatter().Format(GetContext("name"), new GTSImpl(gts));
			AssertXml("result", "<name specializationType=\"GTS.BOUNDEDPIVL\" xsi:type=\"SXPR_TS\">" + "<comp specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\">"
				 + "<low value=\"19691231\"/>" + "<width unit=\"d\" value=\"3\"/></comp>" + "<comp operator=\"I\" specializationType=\"PIVL_TS.DATETIME\" xsi:type=\"PIVL_TS\">"
				 + "<frequency><numerator specializationType=\"INT.NONNEG\" value=\"3\" xsi:type=\"INT\"/>" + "<denominator specializationType=\"PQ.TIME\" unit=\"d\" value=\"3\" xsi:type=\"PQ\"/>"
				 + "</frequency></comp></name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicFreqAsMR2009()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowWidth<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), new DateDiff(CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY))), PeriodicIntervalTime
				.CreateFrequency(3, CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY)));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name specializationType=\"GTS.BOUNDEDPIVL\" xsi:type=\"SXPR_TS\">" + "<comp specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\">"
				 + "<low value=\"19691231\"/>" + "<width unit=\"d\" value=\"3\"/></comp>" + "<comp operator=\"I\" specializationType=\"PIVL_TS.DATETIME\" xsi:type=\"PIVL_TS\">"
				 + "<frequency><numerator specializationType=\"INT.NONNEG\" value=\"3\" xsi:type=\"INT\"/>" + "<denominator specializationType=\"PQ.TIME\" unit=\"d\" value=\"3\" xsi:type=\"PQ\"/>"
				 + "</frequency></comp></name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicFreqAsCeRx()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowWidth<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), new DateDiff(CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY))), PeriodicIntervalTime
				.CreateFrequency(3, CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY)));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.V01R04_3, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name xsi:type=\"SXPR_TS\">" + "<comp operator=\"I\" xsi:type=\"IVL_TS\">" + "<low value=\"19691231\"/>"
				 + "<width unit=\"d\" value=\"3\"/></comp>" + "<comp xsi:type=\"PIVL_TS\">" + "<frequency><numerator value=\"3\"/>" + "<denominator unit=\"d\" value=\"3\"/>"
				 + "</frequency></comp></name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicFreqAsCeRxAndSask()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowWidth<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), new DateDiff(CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY))), PeriodicIntervalTimeSk
				.CreateFrequencySk(3, CreateQuantity("3", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY), CreateQuantity
				("10", Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.DAY)));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.V01R04_2_SK, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name xsi:type=\"SXPR_TS\">" + "<comp operator=\"I\" xsi:type=\"IVL_TS\">" + "<low value=\"19691231\"/>"
				 + "<width unit=\"d\" value=\"3\"/></comp>" + "<comp xsi:type=\"PIVL_TS\">" + "<frequency><numerator value=\"3\"/>" + "<denominator>"
				 + "<low unit=\"d\" value=\"3\"/>" + "<high unit=\"d\" value=\"10\"/>" + "</denominator>" + "</frequency></comp></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicPeriodPhase()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreatePeriodPhase(new DateDiff(new PlatformDate(0)
				), IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate(1969, 11, 31), DateUtil.GetDate(1969, 11, 31))));
			string result = new GtsBoundedPivlFormatter().Format(GetContext("name"), new GTSImpl(gts));
			AssertXml("result", "<name specializationType=\"GTS.BOUNDEDPIVL\" xsi:type=\"SXPR_TS\">" + "<comp specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\">"
				 + "<low value=\"19691231\"/>" + "<high value=\"19691231\"/></comp>" + "<comp operator=\"I\" specializationType=\"PIVL_TS.DATETIME\" xsi:type=\"PIVL_TS\">"
				 + "<period/><phase><low value=\"19691231\"/><high value=\"19691231\"/></phase></comp></name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicPeriodPhaseAsMR2009()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreatePeriodPhase(new DateDiff(new PlatformDate(0)
				), IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate(1969, 11, 31), DateUtil.GetDate(1969, 11, 31))));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name specializationType=\"GTS.BOUNDEDPIVL\" xsi:type=\"SXPR_TS\">" + "<comp specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\">"
				 + "<low value=\"19691231\"/>" + "<high value=\"19691231\"/></comp>" + "<comp operator=\"I\" specializationType=\"PIVL_TS.DATETIME\" xsi:type=\"PIVL_TS\">"
				 + "<period/><phase><low value=\"19691231\"/><high value=\"19691231\"/></phase></comp></name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicPeriodPhaseAsCeRx()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreatePeriodPhase(new DateDiff(new PlatformDate(0)
				), IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate(1969, 11, 31), DateUtil.GetDate(1969, 11, 31))));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.V01R04_3, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name xsi:type=\"SXPR_TS\">" + "<comp operator=\"I\" xsi:type=\"IVL_TS\">" + "<low value=\"19691231\"/>"
				 + "<high value=\"19691231\"/></comp>" + "<comp xsi:type=\"PIVL_TS\">" + "<period/><phase><low value=\"19691231\"/><high value=\"19691231\"/></phase></comp></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicPhase()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreatePhase(IntervalFactory.CreateLowHigh<PlatformDate
				>(DateUtil.GetDate(1969, 11, 31), DateUtil.GetDate(1969, 11, 31))));
			string result = new GtsBoundedPivlFormatter().Format(GetContext("name"), new GTSImpl(gts));
			AssertXml("result", "<name specializationType=\"GTS.BOUNDEDPIVL\" xsi:type=\"SXPR_TS\">" + "<comp specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\">"
				 + "<low value=\"19691231\"/>" + "<high value=\"19691231\"/></comp>" + "<comp operator=\"I\" specializationType=\"PIVL_TS.DATETIME\" xsi:type=\"PIVL_TS\">"
				 + "<phase><low value=\"19691231\"/><high value=\"19691231\"/></phase></comp></name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicPhaseAsMR2009()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreatePhase(IntervalFactory.CreateLowHigh<PlatformDate
				>(DateUtil.GetDate(1969, 11, 31), DateUtil.GetDate(1969, 11, 31))));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name specializationType=\"GTS.BOUNDEDPIVL\" xsi:type=\"SXPR_TS\">" + "<comp specializationType=\"IVL_TS.FULLDATE\" xsi:type=\"IVL_TS\">"
				 + "<low value=\"19691231\"/>" + "<high value=\"19691231\"/></comp>" + "<comp operator=\"I\" specializationType=\"PIVL_TS.DATETIME\" xsi:type=\"PIVL_TS\">"
				 + "<phase><low value=\"19691231\"/><high value=\"19691231\"/></phase></comp></name>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasicPhaseAsCeRx()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreatePhase(IntervalFactory.CreateLowHigh<PlatformDate
				>(DateUtil.GetDate(1969, 11, 31), DateUtil.GetDate(1969, 11, 31))));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.V01R04_3, null, null, null, false
				), new GTSImpl(gts));
			AssertXml("result", "<name xsi:type=\"SXPR_TS\">" + "<comp operator=\"I\" xsi:type=\"IVL_TS\">" + "<low value=\"19691231\"/>"
				 + "<high value=\"19691231\"/></comp>" + "<comp xsi:type=\"PIVL_TS\">" + "<phase><low value=\"19691231\"/><high value=\"19691231\"/></phase></comp></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new UrgPqPropertyFormatter().Format(GetContext("name"), new URGImpl<PQ, PhysicalQuantity>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseAsMR2009()
		{
			string result = new UrgPqPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.R02_04_02, null, null, null, false
				), new URGImpl<PQ, PhysicalQuantity>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCaseAsCeRx()
		{
			string result = new UrgPqPropertyFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.V01R04_3, null, null, null, false
				), new URGImpl<PQ, PhysicalQuantity>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
			Assert.IsTrue(this.result.IsValid());
		}

		private PhysicalQuantity CreateQuantity(string quantity, Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
			 unit)
		{
			return new PhysicalQuantity(new BigDecimal(quantity), unit);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TimeZoneHandling()
		{
			GeneralTimingSpecification gts = new GeneralTimingSpecification(IntervalFactory.CreateLowHigh<PlatformDate>(DateUtil.GetDate
				(1969, 11, 31), DateUtil.GetDate(1969, 11, 31)), PeriodicIntervalTime.CreateFrequency(2, new PhysicalQuantity(BigDecimal
				.TEN, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.DAY)));
			string result = new GtsBoundedPivlFormatter().Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "name", "GTS.BOUNDEDPIVL", null, null, false, SpecificationVersion.V01R04_3, TimeZoneUtil.GetTimeZone
				("GMT-7"), null, null, false), new GTSImpl(gts));
			AssertXml("result", "<name xsi:type=\"SXPR_TS\">" + "<comp operator=\"I\" xsi:type=\"IVL_TS\">" + "<low value=\"19691230\"/>"
				 + "<high value=\"19691230\"/></comp>" + "<comp xsi:type=\"PIVL_TS\">" + "<frequency><numerator value=\"2\"/><denominator unit=\"d\" value=\"10\"/></frequency></comp></name>"
				, result);
			Assert.IsTrue(this.result.IsValid());
		}
	}
}
