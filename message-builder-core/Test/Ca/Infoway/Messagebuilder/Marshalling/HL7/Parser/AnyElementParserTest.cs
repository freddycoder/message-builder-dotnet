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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class AnyElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAnyWithSpecializationTypeInOuterElement()
		{
			XmlNode node = CreateNode("<range xsi:type=\"URG_PQ\" specializationType=\"URG_PQ.BASIC\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
				 + "<low value=\"123\" unit=\"kg\" />" + "<high value=\"567\" unit=\"kg\" />" + "</range>");
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new AnyElementParser().Parse(ParserContextImpl
				.Create("ANY.LAB", typeof(object), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), node, this.xmlResult).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAnyWithSpecializationTypeInOuterElementWithAlternativeDesignation()
		{
			XmlNode node = CreateNode("<range xsi:type=\"URG_PQ\" specializationType=\"URG&lt;PQ.BASIC&gt;\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
				 + "<low value=\"123\" unit=\"kg\" />" + "<high value=\"567\" unit=\"kg\" />" + "</range>");
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)new AnyElementParser().Parse(ParserContextImpl
				.Create("ANY.LAB", typeof(object), SpecificationVersion.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), node, this.xmlResult).BareValue;
			Assert.IsNotNull(range, "null");
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseAnyUrgExampleFromChiDocsWithSpecializationTypeInInnerElements()
		{
			XmlNode node = CreateNode("<range xsi:type=\"URG_PQ\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" + "<low xsi:type=\"PQ\" specializationType=\"PQ.HEIGHTWEIGHT\" value=\"123\" unit=\"kg\" />"
				 + "<high xsi:type=\"PQ\" specializationType=\"PQ.HEIGHTWEIGHT\" value=\"567\" unit=\"kg\" />" + "</range>");
			BareANY parseResult = new AnyElementParser().Parse(ParserContextImpl.Create("ANY.LAB", typeof(object), SpecificationVersion
				.R02_04_02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), node, this.xmlResult);
			UncertainRange<PhysicalQuantity> range = (UncertainRange<PhysicalQuantity>)parseResult.BareValue;
			System.Console.Out.WriteLine(this.xmlResult.GetHl7Errors());
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(range, "null");
			Assert.AreEqual(StandardDataType.URG_PQ_HEIGHTWEIGHT, parseResult.DataType, "type");
			Assert.AreEqual(new BigDecimal("123"), range.Low.Quantity, "low");
			Assert.AreEqual(new BigDecimal("567"), range.High.Quantity, "high");
			Assert.AreEqual(new BigDecimal("345.0"), range.Centre.Quantity, "centre");
			Assert.AreEqual(new BigDecimal("444"), range.Width.Value.Quantity, "width");
			Assert.AreEqual(Representation.LOW_HIGH, range.Representation, "representation");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRetainsProperDatatype()
		{
			XmlNode node = CreateNode("<value xsi:type=\"PQ\" specializationType=\"PQ.LAB\" value=\"80\" unit=\"mg/dL\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>"
				);
			BareANY result = new AnyElementParser().Parse(ParserContextImpl.Create("ANY.LAB", typeof(object), SpecificationVersion.V02R02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(result, "null");
			Assert.AreEqual(StandardDataType.PQ_LAB, result.DataType, "type");
			Assert.IsNotNull(result.BareValue, "null");
			Assert.AreEqual("mg/dL", ((PhysicalQuantity)result.BareValue).Unit.CodeValue, "unit");
			Assert.AreEqual(new BigDecimal(80), ((PhysicalQuantity)result.BareValue).Quantity, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseWithMissingSpecializationType()
		{
			XmlNode node = CreateNode("<value xsi:type=\"PQ\" value=\"80\" unit=\"mg/dL\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"/>"
				);
			BareANY result = new AnyElementParser().Parse(ParserContextImpl.Create("ANY.LAB", typeof(object), null, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY), node, this.xmlResult);
			Assert.IsNotNull(result);
			Assert.IsNull(result.BareValue);
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "has error");
			Assert.AreEqual("Cannot support properties of type \"PQ\" for \"ANY.LAB\"", this.xmlResult.GetHl7Errors()[0].GetMessage()
				, "error message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestReportErrorForMissingSpecializationType()
		{
			XmlToModelResult xmlResult = new XmlToModelResult();
			XmlNode node = CreateNode("<range><low value=\"123\" unit=\"m\" /><high value=\"567\" unit=\"HOUR\" /></range>");
			object range = new AnyElementParser().Parse(null, node, xmlResult).BareValue;
			Assert.IsNull(range, "null");
			Assert.IsFalse(xmlResult.GetHl7Errors().IsEmpty(), "has error");
			Assert.AreEqual(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, xmlResult.GetHl7Errors()[0].GetHl7ErrorCode(), "error");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseRetainsProperDatatypeForSpecializationTypeWhenAnyOnlySpecifiesOkToUseAbstractType()
		{
			XmlNode node = CreateNode("<value xsi:type=\"IVL_PQ\" specializationType=\"IVL_PQ.LAB\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
				 + "<low specializationType=\"PQ.LAB\" value=\"0.0\" unit=\"mg/dL\"/>" + "<high specializationType=\"PQ.LAB\" value=\"0.5\" unit=\"mg/dL\"/>"
				 + "</value>");
			BareANY result = new AnyElementParser().Parse(ParserContextImpl.Create("ANY.LAB", typeof(object), SpecificationVersion.V02R02
				, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), node, new XmlToModelResult());
			Assert.IsNotNull(result, "null");
			Assert.AreEqual(StandardDataType.IVL_PQ_LAB, result.DataType, "type");
			Assert.IsNotNull(result.BareValue, "null");
			Interval<PhysicalQuantity> interval = (Interval<PhysicalQuantity>)result.BareValue;
			Assert.AreEqual("mg/dL", interval.Low.Unit.CodeValue, "low unit");
			Assert.AreEqual(new BigDecimal(0).SetScale(1), interval.Low.Quantity, "low quantity");
			Assert.AreEqual("mg/dL", interval.High.Unit.CodeValue, "high unit");
			Assert.AreEqual(new BigDecimal(0.5), interval.High.Quantity, "high quantity");
		}
	}
}
