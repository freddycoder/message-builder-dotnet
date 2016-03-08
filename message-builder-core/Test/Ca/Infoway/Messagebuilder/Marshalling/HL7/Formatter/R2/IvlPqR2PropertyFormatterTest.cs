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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class IvlPqR2PropertyFormatterTest : FormatterTestCase
	{
		private static readonly PhysicalQuantity PHYSICAL_QUANTITY_LOW = new PhysicalQuantity(new BigDecimal(1000), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
			.MILLILITRE);

		private static readonly PhysicalQuantity PHYSICAL_QUANTITY_HIGH = new PhysicalQuantity(new BigDecimal(2000), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
			.MILLILITRE);

		private IvlPqR2PropertyFormatter formatter;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			this.formatter = new IvlPqR2PropertyFormatter();
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		protected override FormatContext GetContext(string name)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(new ModelToXmlResult(), null, name, "IVL<PQ>"
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, false, SpecificationVersion.R02_04_03, null, null
				, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Interval<PhysicalQuantity> interval = IntervalFactory.CreateLowHigh<PhysicalQuantity>(PHYSICAL_QUANTITY_LOW, PHYSICAL_QUANTITY_HIGH
				);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>>(
				interval));
			AssertXml("result", "<name><low unit=\"mL\" value=\"1000\"/><high unit=\"mL\" value=\"2000\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalLow()
		{
			Interval<PhysicalQuantity> low = IntervalFactory.CreateLow<PhysicalQuantity>(PHYSICAL_QUANTITY_LOW);
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>>(
				low));
			AssertXml("result", "<name><low unit=\"mL\" value=\"1000\"/></name>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>>(
				));
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIntervalWidth()
		{
			Interval<PhysicalQuantity> interval = IntervalFactory.CreateWidth<PhysicalQuantity>(new Diff<PhysicalQuantity>(PHYSICAL_QUANTITY_LOW
				));
			string result = this.formatter.Format(GetContext("name"), new IVLImpl<QTY<PhysicalQuantity>, Interval<PhysicalQuantity>>(
				interval));
			AssertXml("result", "<name><width unit=\"mL\" value=\"1000\"/></name>", result);
		}
	}
}
