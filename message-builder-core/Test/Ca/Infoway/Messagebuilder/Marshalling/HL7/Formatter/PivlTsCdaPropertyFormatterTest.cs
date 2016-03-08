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
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class PivlTsCdaPropertyFormatterTest : FormatterTestCase
	{
		private PivlTsCdaPropertyFormatter formatter = new PivlTsCdaPropertyFormatter();

		[Test]
		public virtual void TestPivlPhasePeriod()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PlatformDate dateLow = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPatternLow = new DateWithPattern(dateLow, "yyyyMMdd");
			PlatformDate dateHigh = DateUtil.GetDate(2012, 6, 8);
			DateWithPattern dateWithPatternHigh = new DateWithPattern(dateHigh, "yyyyMMdd");
			Interval<PlatformDate> phase = IntervalFactory.CreateLowHigh((PlatformDate)dateWithPatternLow, (PlatformDate)dateWithPatternHigh
				);
			PhysicalQuantity period = new PhysicalQuantity(BigDecimal.ONE, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.DAY);
			PeriodicIntervalTimeR2 pivl = new PeriodicIntervalTimeR2(phase, period);
			BareANY dataType = new PIVLTSCDAR1Impl(pivl);
			FormatContext formatContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, string.Empty
				, "pivl", "PIVLTSCDAR1", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), false, 
				SpecificationVersion.R02_04_03, null, null, null, null, true);
			string xml = this.formatter.Format(formatContext, dataType);
			Assert.IsTrue(result.IsValid());
			string expected = "<pivl><period unit=\"d\" value=\"1\"/><phase><low value=\"20120503\"/><high value=\"20120708\"/></phase></pivl>";
			AssertXml("pivl output", expected, xml, true);
		}

		[Test]
		public virtual void TestPivlFrequency()
		{
			ModelToXmlResult result = new ModelToXmlResult();
			PhysicalQuantity frequencyQuantity = new PhysicalQuantity(BigDecimal.ONE, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.DAY);
			PeriodicIntervalTimeR2 pivl = new PeriodicIntervalTimeR2(4, frequencyQuantity);
			BareANY dataType = new PIVLTSCDAR1Impl(pivl);
			FormatContext formatContext = new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(result, string.Empty
				, "pivl", "PIVLTSCDAR1", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1"), false, 
				SpecificationVersion.R02_04_03, null, null, null, null, true);
			string xml = this.formatter.Format(formatContext, dataType);
			Assert.IsTrue(result.IsValid());
			string expected = "<pivl><frequency><numerator value=\"4\"/><denominator unit=\"d\" value=\"1\"/></frequency></pivl>";
			AssertXml("pivl output", expected, xml, true);
		}
	}
}
