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
	public class PqElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			PQ pq = (PQ)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pq.Value, "PhysicalQuantity");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, pq.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext(string type, VersionNumber version)
		{
			return ParserContextImpl.Create(type, typeof(PhysicalQuantity), version, null, null, null);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(physicalQuantity, "PhysicalQuantity");
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCorrectAttributeNodes()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(physicalQuantity, "PhysicalQuantity");
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributes()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributesWithDifferentUnitsAndTypes()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.KILOGRAM.CodeValue, physicalQuantity
				.Unit.CodeValue, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"mg\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.DRUG", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure.MILLIGRAM.CodeValue, physicalQuantity.Unit
				.CodeValue, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"mo\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.TIME", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.MONTH.CodeValue, physicalQuantity.Unit.CodeValue
				, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"[lb_av]\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.HEIGHTWEIGHT", SpecificationVersion.V02R02
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure.POUND.CodeValue, physicalQuantity
				.Unit.CodeValue, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"km\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.DISTANCE", SpecificationVersion.V02R02
				), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure.KILOMETER.CodeValue, physicalQuantity
				.Unit.CodeValue, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"any_units\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.LAB", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual("any_units", physicalQuantity.Unit.CodeValue, "unit");
		}

		// no MB-provided enum for units; code lookup will allow any value
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidAttributesWithDifferentUnitsAndTypes()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"xyzabc\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(physicalQuantity.Unit, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"mo\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.DRUG", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(physicalQuantity.Unit, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"kg\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.TIME", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(physicalQuantity.Unit, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"mo\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.HEIGHTWEIGHT", SpecificationVersion.V02R02
				), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(physicalQuantity.Unit, "unit");
			node = CreateNode("<something value=\"1234.45\" unit=\"mo\" />");
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.DISTANCE", SpecificationVersion.V02R02
				), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(physicalQuantity.Unit, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValue()
		{
			XmlNode node = CreateNode("<something value=\"-1234.45\" unit=\"kg\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual(new BigDecimal("-1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributesWithElementClosure()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\"></something>");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributesNoUnit()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.IsNotNull(physicalQuantity.Quantity, "value");
			Assert.IsNull(physicalQuantity.Unit, "value");
			Assert.IsTrue(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"monkey\" />");
			new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyIntegerDigitsValueAttribute()
		{
			string element = "<something value=\"123456789012.12\" unit=\"kg\"/>";
			XmlNode node = CreateNode(element);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsNotNull(physicalQuantity);
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("PhysicalQuantity for MR2007/PQ.BASIC can contain a maximum of 11 integer places (<something unit=\"kg\" value=\"123456789012.12\"/>)"
				, this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyIntegerDigitsValueAttributeForCeRx()
		{
			string element = "<something value=\"123456789.12\" unit=\"kg\"/>";
			XmlNode node = CreateNode(element);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			// CeRx only allows 8 digits before the decimal 
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion.V01R04_3)
				, node, this.xmlResult).BareValue;
			Assert.IsNotNull(physicalQuantity);
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("PhysicalQuantity for CERX/PQ.BASIC can contain a maximum of 8 integer places (<something unit=\"kg\" value=\"123456789.12\"/>)"
				, this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyDecimalDigitsValueAttribute()
		{
			string element = "<something value=\"12345678901.1234\" unit=\"kg\"/>";
			XmlNode node = CreateNode(element);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.BASIC", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsNotNull(physicalQuantity);
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("PhysicalQuantity for MR2007/PQ.BASIC can contain a maximum of 2 decimal places (<something unit=\"kg\" value=\"12345678901.1234\"/>)"
				, this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTooManyDecimalDigitsValueAttributeForPQDRUG()
		{
			string element = "<something value=\"12345678901.1234\" unit=\"kg\"/>";
			XmlNode node = CreateNode(element);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.DRUG", SpecificationVersion
				.R02_04_03), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid(), "result");
			element = "<something value=\"12345678901.12345\" unit=\"kg\"/>";
			node = CreateNode(element);
			physicalQuantity = (PhysicalQuantity)new PqElementParser().Parse(CreateContext("PQ.DRUG", SpecificationVersion.R02_04_03)
				, node, this.xmlResult).BareValue;
			Assert.IsNotNull(physicalQuantity);
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("PhysicalQuantity for MR2009/PQ.DRUG can contain a maximum of 4 decimal places (<something unit=\"kg\" value=\"12345678901.12345\"/>)"
				, this.xmlResult.GetHl7Errors()[0].GetMessage());
		}
	}
}
