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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class GtsBoundedPivlElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseNullFlavor()
		{
			XmlNode node = CreateNode("<effectiveTime nullFlavor=\"NI\"></effectiveTime>");
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			GTS gts = (GTS)new GtsBoundedPivlElementParser().Parse(context, node, this.xmlResult);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, gts.NullFlavor, "null flavor"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseValidInformation()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "  <comp operator=\"I\">" + "    <low specializationType=\"TS.FULLDATE\" value=\"20050803\"/>"
				 + "    <width specializationType=\"TS.FULLDATE\" value=\"3\" unit=\"wk\"/>" + "  </comp>" + "  <comp>" + "    <frequency>"
				 + "      <numerator specializationType=\"INT.NONNEG\" value=\"3\"/>" + "      <denominator specializationType=\"PQ.TIME\" value=\"1\" unit=\"d\"/>"
				 + "    </frequency>" + "  </comp>" + "</effectiveTime>");
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			GeneralTimingSpecification result = (GeneralTimingSpecification)new GtsBoundedPivlElementParser().Parse(context, node, this
				.xmlResult).BareValue;
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(new BigDecimal("3"), ((DateDiff)result.Duration.Width).ValueAsPhysicalQuantity.Quantity, "interval width value"
				);
			Assert.AreEqual("wk", ((DateDiff)result.Duration.Width).Unit.CodeValue, "interval width unit");
			Assert.AreEqual(3, result.Frequency.Repetitions, "frequency times");
			Assert.AreEqual(new BigDecimal("1"), result.Frequency.Quantity.Quantity, "frequency period value");
			Assert.AreEqual("d", result.Frequency.Quantity.Unit.CodeValue, "frequency period unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseValidInformationForSk()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "  <comp operator=\"I\">" + "    <low specializationType=\"TS.FULLDATE\" value=\"20050803\"/>"
				 + "    <width specializationType=\"TS.FULLDATE\" value=\"3\" unit=\"wk\"/>" + "  </comp>" + "  <comp>" + "    <frequency>"
				 + "      <numerator specializationType=\"INT.NONNEG\" value=\"3\"/>" + "      <denominator>" + "        <low unit=\"d\" value=\"3\"/>"
				 + "        <high unit=\"d\" value=\"10\"/>" + "      </denominator>" + "    </frequency>" + "  </comp>" + "</effectiveTime>"
				);
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V01R04_2_SK, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			GeneralTimingSpecification result = (GeneralTimingSpecification)new GtsBoundedPivlElementParser().Parse(context, node, this
				.xmlResult).BareValue;
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(new BigDecimal("3"), ((DateDiff)result.Duration.Width).ValueAsPhysicalQuantity.Quantity, "interval width value"
				);
			Assert.AreEqual("wk", ((DateDiff)result.Duration.Width).Unit.CodeValue, "interval width unit");
			Assert.IsTrue(result.Frequency is PeriodicIntervalTimeSk, "frequency is for SK");
			Assert.AreEqual(3, result.Frequency.Repetitions, "frequency times");
			Assert.AreEqual(new BigDecimal("3"), ((PeriodicIntervalTimeSk)result.Frequency).QuantitySk.Low.Quantity, "low frequency period value"
				);
			Assert.AreEqual("d", ((PeriodicIntervalTimeSk)result.Frequency).QuantitySk.Low.Unit.CodeValue, "low frequency period unit"
				);
			Assert.AreEqual(new BigDecimal("10"), ((PeriodicIntervalTimeSk)result.Frequency).QuantitySk.High.Quantity, "high frequency period value"
				);
			Assert.AreEqual("d", ((PeriodicIntervalTimeSk)result.Frequency).QuantitySk.High.Unit.CodeValue, "high frequency period unit"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseValidInformationWhenMissingInnerSpecializationTypes()
		{
			XmlNode node = CreateNode("<effectiveTime specializationType=\"GTS.BOUNDEDPIVL\">" + "  <comp operator=\"I\">" + "    <low value=\"20050803\"/>"
				 + "    <width value=\"3\" unit=\"wk\"/>" + "  </comp>" + "  <comp>" + "    <frequency>" + "      <numerator value=\"3\"/>"
				 + "      <denominator value=\"1\" unit=\"d\"/>" + "    </frequency>" + "  </comp>" + "</effectiveTime>");
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			GeneralTimingSpecification result = (GeneralTimingSpecification)new GtsBoundedPivlElementParser().Parse(context, node, this
				.xmlResult).BareValue;
			Assert.IsNotNull(result, "result");
			Assert.AreEqual(new BigDecimal("3"), ((DateDiff)result.Duration.Width).ValueAsPhysicalQuantity.Quantity, "interval width value"
				);
			Assert.AreEqual("wk", ((DateDiff)result.Duration.Width).Unit.CodeValue, "interval width unit");
			Assert.AreEqual(3, result.Frequency.Repetitions, "frequency times");
			Assert.AreEqual(new BigDecimal("1"), result.Frequency.Quantity.Quantity, "frequency period value");
			Assert.AreEqual("d", result.Frequency.Quantity.Unit.CodeValue, "frequency period unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldDetectIncorrectElementType()
		{
			XmlNode node = CreateNode("<effectiveTime>" + "  <comp operator=\"I\">" + "    <low specializationType=\"TS.FULLDATE\" value=\"20050803\"/>"
				 + "    <width specializationType=\"TS.FULLDATE\" value=\"3\" unit=\"wk\"/>" + "  </comp>" + "  <fred>" + "    <frequency>"
				 + "      <numerator specializationType=\"INT.NONNEG\" value=\"3\"/>" + "      <denominator specializationType=\"PQ.TIME\" value=\"1\" unit=\"d\"/>"
				 + "    </frequency>" + "  </fred>" + "</effectiveTime>");
			ParseContext context = ParserContextImpl.Create("GTS.BOUNDEDPIVL", typeof(GeneralTimingSpecification), SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			new GtsBoundedPivlElementParser().Parse(context, node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "valid");
		}
	}
}
