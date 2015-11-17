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
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class PivlTsCdaElementParserTest : MarshallingTestCase
	{
		private PivlTsCdaElementParser parser = new PivlTsCdaElementParser();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPivlPhasePeriod()
		{
			XmlToModelResult result = new XmlToModelResult();
			XmlNode node = CreateNode("<pivl><period unit=\"d\" value=\"1\"/><phase><low value=\"20120503\"/><high value=\"20120708\"/></phase></pivl>"
				);
			ParseContext context = ParseContextImpl.Create("PIVLTSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), null, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), result);
			PhysicalQuantity expectedPeriod = new PhysicalQuantity(BigDecimal.ONE, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.DAY);
			PlatformDate dateLow = DateUtil.GetDate(2012, 4, 3);
			DateWithPattern dateWithPatternLow = new DateWithPattern(dateLow, "yyyyMMdd");
			PlatformDate dateHigh = DateUtil.GetDate(2012, 6, 8);
			DateWithPattern dateWithPatternHigh = new DateWithPattern(dateHigh, "yyyyMMdd");
			Interval<PlatformDate> expectedPhase = IntervalFactory.CreateLowHigh((PlatformDate)dateWithPatternLow, (PlatformDate)dateWithPatternHigh
				);
			Assert.IsTrue(result.IsValid());
			Assert.IsTrue(parseResult is PIVLTSCDAR1);
			PeriodicIntervalTimeR2 pivl = (PeriodicIntervalTimeR2)parseResult.BareValue;
			Assert.AreEqual(expectedPeriod.Quantity, pivl.Period.Quantity);
			Assert.AreEqual(expectedPeriod.Unit.CodeValue, pivl.Period.Unit.CodeValue);
			Assert.AreEqual(expectedPhase, pivl.Phase);
			Assert.IsNull(pivl.FrequencyRepetitions);
			Assert.IsNull(pivl.FrequencyQuantity);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPivlFrequency()
		{
			XmlToModelResult result = new XmlToModelResult();
			XmlNode node = CreateNode("<pivl><frequency><numerator value=\"4\"/><denominator unit=\"d\" value=\"1\"/></frequency></pivl>"
				);
			ParseContext context = ParseContextImpl.Create("PIVLTSCDAR1", null, SpecificationVersion.R02_04_03, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), null, true);
			BareANY parseResult = this.parser.Parse(context, Arrays.AsList(node), result);
			PhysicalQuantity expectedFrequencyQuantity = new PhysicalQuantity(BigDecimal.ONE, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.DAY);
			Assert.IsTrue(result.IsValid());
			Assert.IsTrue(parseResult is PIVLTSCDAR1);
			PeriodicIntervalTimeR2 pivl = (PeriodicIntervalTimeR2)parseResult.BareValue;
			Assert.AreEqual(expectedFrequencyQuantity.Quantity, pivl.FrequencyQuantity.Quantity);
			Assert.AreEqual(expectedFrequencyQuantity.Unit.CodeValue, pivl.FrequencyQuantity.Unit.CodeValue);
			Assert.AreEqual((Int32?)4, pivl.FrequencyRepetitions);
			Assert.IsNull(pivl.Period);
			Assert.IsNull(pivl.Phase);
		}
	}
}
