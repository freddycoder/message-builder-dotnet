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
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class RtoMoPqPropertyFormatterTest : FormatterTestCase
	{
		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestBasic()
		{
			Ratio<Money, PhysicalQuantity> ratio = new Ratio<Money, PhysicalQuantity>();
			ratio.Numerator = new Money(new BigDecimal("1.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.Currency.CANADIAN_DOLLAR);
			ratio.Denominator = new PhysicalQuantity(new BigDecimal("10.00"), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLILITRE);
			string result = new RtoMoPqPropertyFormatter().Format(GetContext("name", "RTO<MO.CAD,PQ.BASIC>"), new RTOImpl<Money, PhysicalQuantity
				>(ratio));
			AssertXml("result", "<name><numerator currency=\"CAD\" value=\"1.00\"/><denominator unit=\"mL\" value=\"10.00\"/></name>"
				, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCase()
		{
			string result = new RtoMoPqPropertyFormatter().Format(GetContext("name", "RTO<MO.CAD,PQ.BASIC>"), new RTOImpl<PhysicalQuantity
				, PhysicalQuantity>());
			AssertXml("result", "<name nullFlavor=\"NI\"/>", result);
		}
	}
}
