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
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class UrgPqElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<range><low value=\"123\" unit=\"kg\" /><high value=\"567\" unit=\"kg\" /></range>");
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new UrgPqElementParser().Parse(CreateContext()
				, node, this.xmlResult).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
			Assert.IsNull(range.LowInclusive);
			Assert.IsNull(range.HighInclusive);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithInclusive()
		{
			XmlNode node = CreateNode("<range><low inclusive=\"true\" value=\"123\" unit=\"kg\" /><high inclusive=\"false\" value=\"567\" unit=\"kg\" /></range>"
				);
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new UrgPqElementParser().Parse(CreateContext()
				, node, this.xmlResult).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
			Assert.IsTrue(range.LowInclusive.Value);
			Assert.IsFalse(range.HighInclusive.Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestReportError()
		{
			XmlNode node = CreateNode("<range><low value=\"123\" unit=\"m\" /><high value=\"567\" unit=\"h\" /></range>");
			UncertainRange<PhysicalQuantity> range = null;
			try
			{
				range = (UncertainRange<PhysicalQuantity>)new UrgPqElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
				Assert.Fail("Should fail trying to add quantities of different units");
			}
			catch (ArgumentException e)
			{
				// expected
				Assert.AreEqual("Can't add two quantities of different units: m and h", e.Message, "syntax error");
			}
			Assert.IsNull(range, "null");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("URG<PQ.BASIC>", null, SpecificationVersion.R02_04_02, null, null, null, null, null);
		}
	}
}
