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
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class PqR2ElementParserTest : CeRxDomainValueTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			PQ pq = (PQ)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(pq.Value, "PhysicalQuantity");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, pq.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext(string type, VersionNumber version)
		{
			return ParseContextImpl.Create(type, typeof(PhysicalQuantity), version, null, null, null, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(physicalQuantity, "PhysicalQuantity");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNoCorrectAttributeNodes()
		{
			XmlNode node = CreateNode("<something notvalue=\"\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNull(physicalQuantity, "PhysicalQuantity");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributes()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributesWithTranslation()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\">" + "<translation code=\"M\" codeSystem=\"2.16.840.1.113883.5.1\"/>"
				 + "<translation code=\"active\" codeSystem=\"2.16.840.1.113883.5.14\"/>" + "</something>");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
			Assert.AreEqual(2, physicalQuantity.Translation.Count);
			Assert.AreEqual("M", physicalQuantity.Translation[0].GetCodeValue());
			Assert.AreEqual("2.16.840.1.113883.5.1", physicalQuantity.Translation[0].GetCodeSystem());
			Assert.AreEqual("active", physicalQuantity.Translation[1].GetCodeValue());
			Assert.AreEqual("2.16.840.1.113883.5.14", physicalQuantity.Translation[1].GetCodeSystem());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithOperatorNotAllowed()
		{
			XmlNode node = CreateNode("<something operator=\"P\" value=\"1234.45\" unit=\"kg\" />");
			BareANY pqAny = new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node, this.xmlResult);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)pqAny.BareValue;
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
			Assert.IsNull(((ANYMetaData)pqAny).Operator, "no operator");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count, "1 error expected");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithOperatorAllowed()
		{
			XmlNode node = CreateNode("<something operator=\"P\" value=\"1234.45\" unit=\"kg\" />");
			BareANY pqAny = new PqR2ElementParser().Parse(CreateContext("SXCM<PQ>", SpecificationVersion.V02R02), node, this.xmlResult
				);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)pqAny.BareValue;
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(SetOperator.PERIODIC_HULL, ((ANYMetaData)pqAny).Operator, "operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValueAttributeValidWithDefaultOperator()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\" />");
			BareANY pqAny = new PqR2ElementParser().Parse(CreateContext("SXCM<PQ>", SpecificationVersion.V02R02), node, this.xmlResult
				);
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)pqAny.BareValue;
			Assert.AreEqual(new BigDecimal("1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
			Assert.IsTrue(this.xmlResult.IsValid(), "no errors");
			Assert.AreEqual(SetOperator.INCLUDE, ((ANYMetaData)pqAny).Operator, "operator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributesWithDifferentUnitsAndTypes()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.KILOGRAM.CodeValue, physicalQuantity
				.Unit.CodeValue, "unit");
			this.xmlResult.ClearErrors();
			node = CreateNode("<something value=\"1234.45\" unit=\"mg\" />");
			physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DrugUnitsOfMeasure.MILLIGRAM.CodeValue, physicalQuantity.Unit
				.CodeValue, "unit");
			this.xmlResult.ClearErrors();
			node = CreateNode("<something value=\"1234.45\" unit=\"mo\" />");
			physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.DefaultTimeUnit.MONTH.CodeValue, physicalQuantity.Unit.CodeValue
				, "unit");
			this.xmlResult.ClearErrors();
			node = CreateNode("<something value=\"1234.45\" unit=\"[lb_av]\" />");
			physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_HeightOrWeightObservationUnitsOfMeasure.POUND.CodeValue, physicalQuantity
				.Unit.CodeValue, "unit");
			this.xmlResult.ClearErrors();
			node = CreateNode("<something value=\"1234.45\" unit=\"km\" />");
			physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DistanceObservationUnitsOfMeasure.KILOMETER.CodeValue, physicalQuantity
				.Unit.CodeValue, "unit");
			this.xmlResult.ClearErrors();
			node = CreateNode("<something value=\"1234.45\" unit=\"any_units\" />");
			physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.IsNull(physicalQuantity.Unit, "unit");
			this.xmlResult.ClearErrors();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidAttributesWithDifferentUnitsAndTypes()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"xyzabc\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.IsNull(physicalQuantity.Unit, "unit");
			this.xmlResult.ClearErrors();
			node = CreateNode("<something value=\"1234.45\" unit=\"mo\" />");
			physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MONTH, physicalQuantity.Unit, "unit"
				);
			this.xmlResult.ClearErrors();
			node = CreateNode("<something value=\"1234.45\" unit=\"kg\" />");
			physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node
				, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.KILOGRAM, physicalQuantity.Unit, 
				"unit");
			this.xmlResult.ClearErrors();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValue()
		{
			XmlNode node = CreateNode("<something value=\"-1234.45\" unit=\"kg\" />");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual(new BigDecimal("-1234.45"), physicalQuantity.Quantity, "quantity");
			Assert.AreEqual(CeRxDomainTestValues.KILOGRAM.CodeValue, physicalQuantity.Unit.CodeValue, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseValidAttributesWithElementClosure()
		{
			XmlNode node = CreateNode("<something value=\"1234.45\" unit=\"kg\"></something>");
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
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
			PhysicalQuantity physicalQuantity = (PhysicalQuantity)new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion
				.V02R02), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(physicalQuantity, "PhysicalQuantity");
			Assert.AreEqual("1234.45", physicalQuantity.Quantity.ToString(), "value");
			Assert.IsNull(physicalQuantity.Unit, "unit");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseInvalidValueAttribute()
		{
			XmlNode node = CreateNode("<something value=\"monkey\" />");
			new PqR2ElementParser().Parse(CreateContext("PQ", SpecificationVersion.V02R02), node, this.xmlResult);
			Assert.IsFalse(this.xmlResult.IsValid(), "result");
		}
	}
}
