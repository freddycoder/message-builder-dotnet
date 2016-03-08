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


using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class IvlPqR2ElementParserTest : CeRxDomainValueTestCase
	{
		private static readonly string mL = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLILITRE.CodeValue;

		private XmlToModelResult result;

		private IvlPqR2ElementParser parser;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public override void SetUp()
		{
			base.SetUp();
			this.result = new XmlToModelResult();
			this.parser = new IvlPqR2ElementParser();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Interval<PhysicalQuantity> Parse(XmlNode node)
		{
			return (Interval<PhysicalQuantity>)this.parser.Parse(ParseContextImpl.Create("IVL<PQ>", typeof(Interval<object>), SpecificationVersion
				.V02R02, null, null, null, null, null, false), Arrays.AsList(node), this.result).BareValue;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowHigh()
		{
			XmlNode node = CreateNode("<name><low unit=\"mL\" value=\"1000\"/><high unit=\"mL\" value=\"2000\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(1000, interval.Low.Quantity.Value, "low - value");
			Assert.AreEqual(mL, interval.Low.Unit.CodeValue, "low - unit");
			Assert.AreEqual(2000, interval.High.Quantity.Value, "high - value");
			Assert.AreEqual(mL, interval.High.Unit.CodeValue, "high - unit");
			Assert.AreEqual(1500, interval.Centre.Quantity.Value, "centre - value");
			Assert.AreEqual(mL, interval.Centre.Unit.CodeValue, "centre - unit");
			Assert.AreEqual(1000, interval.Width.Value.Quantity.Value, "width - value");
			Assert.AreEqual(mL, interval.Width.Value.Unit.CodeValue, "width - unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLow()
		{
			XmlNode node = CreateNode("<name><low unit=\"mL\" value=\"1000\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.AreEqual(1000, interval.Low.Quantity.Value, "low - value");
			Assert.AreEqual(mL, interval.Low.Unit.CodeValue, "low - unit");
			Assert.IsNull(interval.High, "high");
			Assert.IsNull(interval.Centre, "centre");
			Assert.IsNull(interval.Width, "width");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseLowInvalidBothNull()
		{
			XmlNode node = CreateNode("<name><low nullFlavor=\"OTH\"/><high nullFlavor=\"NI\"/></name>");
			Interval<PhysicalQuantity> interval = Parse(node);
			Assert.IsTrue(this.result.IsValid());
			Assert.IsNotNull(interval, "null");
			Assert.IsNull(interval.Low);
			Assert.IsNull(interval.High);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, interval.LowNullFlavor);
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, interval.HighNullFlavor);
		}
	}
}
