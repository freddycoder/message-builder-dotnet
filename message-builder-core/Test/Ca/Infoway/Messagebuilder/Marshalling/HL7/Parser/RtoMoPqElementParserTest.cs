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
	public class RtoMoPqElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			RTO<Money, PhysicalQuantity> rto = (RTO<Money, PhysicalQuantity>)new RtoMoPqElementParser().Parse(CreateContext(), node, 
				null);
			Assert.IsNull(rto.Value, "value");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, rto.NullFlavor, "null flavor"
				);
		}

		private ParseContext CreateContext()
		{
			return ParseContextImpl.Create("RTO<PQ.DRUG,PQ.DRUG>", typeof(Ratio<object, object>), SpecificationVersion.V02R02, null, 
				null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			Ratio<Money, PhysicalQuantity> ratio = (Ratio<Money, PhysicalQuantity>)new RtoMoPqElementParser().Parse(CreateContext(), 
				node, this.xmlResult).BareValue;
			Assert.IsNotNull(ratio, "ratio");
			Assert.IsNull(ratio.Numerator, "numerator");
			Assert.IsNull(ratio.Denominator, "denominator");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributes()
		{
			XmlNode node = CreateNode("<something><numerator value=\"1234.45\" currency=\"CAD\"/><denominator value=\"2345.67\" unit=\"mL\" /></something>"
				);
			Ratio<Money, PhysicalQuantity> ratio = (Ratio<Money, PhysicalQuantity>)new RtoMoPqElementParser().Parse(CreateContext(), 
				node, this.xmlResult).BareValue;
			Assert.IsNotNull(ratio, "ratio");
			Assert.AreEqual(new BigDecimal("1234.45"), ratio.Numerator.Amount, "numerator");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR.CodeValue, ratio.Numerator.Currency.
				CodeValue, "numerator unit");
			Assert.AreEqual(new BigDecimal("2345.67"), ratio.Denominator.Quantity, "denominator");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLILITRE.CodeValue, ratio.Denominator
				.Unit.CodeValue, "denominator unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something><numerator value=\"monkey\" /><denominator value=\"2345.67\" /></something>");
			new RtoMoPqElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}
		// no currency; monkey is invalid value
	}
}
