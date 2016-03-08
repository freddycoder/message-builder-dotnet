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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class AbstractCerxPqPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityNull()
		{
			string formatResult = new PqPropertyFormatter().Format(CreateContext(), new PQImpl());
			// a null value for PQ elements results in a nullFlavor attribute
			Assert.AreEqual("<name nullFlavor=\"NI\"/>", formatResult.Trim(), "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityEmpty()
		{
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), new PhysicalQuantity
				());
			// an empty value for PQ elements results in a nullFlavor attribute
			Assert.AreEqual(1, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("nullFlavor"), "key as expected");
			Assert.AreEqual(AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION, result.SafeGet("nullFlavor"), "value as expected");
		}

		private Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl CreateContext()
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(this.result, null, "name", "PQ.BASIC", null
				, null, false, SpecificationVersion.V01R04_3, null, null, null, false);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValueOrUnitNull()
		{
			// no name-value pairs
			PqPropertyFormatter formatter = new PqPropertyFormatter();
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Unit = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive.MILLIGRAM;
			formatter.Format(CreateContext(), new PQImpl(physicalQuantity));
			Assert.AreEqual("No value provided for physical quantity", this.result.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatPhysicalQuantityValid()
		{
			string quantity = "33.45";
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLILITRE;
			PhysicalQuantity physicalQuantity = new PhysicalQuantity();
			physicalQuantity.Quantity = new BigDecimal(quantity);
			physicalQuantity.Unit = unit;
			IDictionary<string, string> result = new PqPropertyFormatter().GetAttributeNameValuePairs(CreateContext(), physicalQuantity
				);
			Assert.AreEqual(2, result.Count, "map size");
			Assert.IsTrue(result.ContainsKey("value"), "key as expected");
			Assert.AreEqual(quantity, result.SafeGet("value"), "value");
			Assert.IsTrue(result.ContainsKey("unit"), "unit key as expected");
			Assert.AreEqual(unit.CodeValue, result.SafeGet("unit"), "unit");
		}
	}
}
