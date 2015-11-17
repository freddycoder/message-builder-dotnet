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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[TestFixture]
	public class SetRtoPqPqPropertyFormatterTest : FormatterTestCase
	{
		private FormatterRegistry formatterRegistry = FormatterRegistry.GetInstance();

		[SetUp]
		public virtual void Setup()
		{
			DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			PhysicalQuantity numerator1 = new PhysicalQuantity(BigDecimal.ONE, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CENTIMETRE);
			PhysicalQuantity denominator1 = new PhysicalQuantity(new BigDecimal(2), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CUBIC_CENTIMETER);
			PhysicalQuantity numerator2 = new PhysicalQuantity(BigDecimal.TEN, Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.MILLIMETER);
			PhysicalQuantity denominator2 = new PhysicalQuantity(new BigDecimal(11), Ca.Infoway.Messagebuilder.Domainvalue.Basic.UnitsOfMeasureCaseSensitive
				.CUBIC_MILIMETER);
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio1 = new Ratio<PhysicalQuantity, PhysicalQuantity>(numerator1, denominator1
				);
			Ratio<PhysicalQuantity, PhysicalQuantity> ratio2 = new Ratio<PhysicalQuantity, PhysicalQuantity>(numerator2, denominator2
				);
			SETImpl<RTO<PhysicalQuantity, PhysicalQuantity>, Ratio<PhysicalQuantity, PhysicalQuantity>> set = new SETImpl<RTO<PhysicalQuantity
                , PhysicalQuantity>, Ratio<PhysicalQuantity, PhysicalQuantity>>(typeof(RTOImpl<PhysicalQuantity, PhysicalQuantity>));
			set.RawSet().AddAll(MakeSet(ratio1, ratio2));
			string result = new SetPropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(new ModelToXmlResult(), null, "blah", "SET<RTO<PQ.DRUG,PQ.TIME>>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY
				, Cardinality.Create("1-4"), false, SpecificationVersion.R02_04_02, null, null, null, false), set);
			AssertXml("non null", "<blah><numerator unit=\"cm\" value=\"1\"/><denominator unit=\"cm3\" value=\"2\"/></blah><blah><numerator unit=\"mm\" value=\"10\"/><denominator unit=\"mm3\" value=\"11\"/></blah>"
				, result);
		}

		private ICollection<Ratio<PhysicalQuantity, PhysicalQuantity>> MakeSet(params Ratio<PhysicalQuantity, PhysicalQuantity>[]
			 ratios)
		{
			return new LinkedSet<Ratio<PhysicalQuantity, PhysicalQuantity>>(Arrays.AsList(ratios));
		}
	}
}
