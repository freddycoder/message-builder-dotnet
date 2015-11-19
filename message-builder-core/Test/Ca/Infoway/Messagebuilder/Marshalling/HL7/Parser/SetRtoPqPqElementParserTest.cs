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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class SetRtoPqPqElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something>" + "<numerator unit=\"mg\" value=\"1000\" />" + "<denominator unit=\"d\" value=\"1\" />"
				 + "</something>" + "<something>" + "<numerator unit=\"mg\" value=\"1001\"	/>" + "<denominator unit=\"d\" value=\"2\" />"
				 + "</something>" + "</top>");
			BareANY result = new SetElementParser(ParserRegistry.GetInstance()).Parse(ParseContextImpl.Create("SET<RTO<PQ.DRUG,PQ.TIME>>"
				, null, SpecificationVersion.V01R04_2_SK, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality
				.Create("1-5"), null, false), AsList(node.ChildNodes), null);
			ICollection<Ratio<PhysicalQuantity, PhysicalQuantity>> set = ((SET<RTO<PhysicalQuantity, PhysicalQuantity>, Ratio<PhysicalQuantity
				, PhysicalQuantity>>)result).RawSet();
			Assert.IsNotNull(set, "null");
			Assert.AreEqual(2, set.Count, "size");
			bool foundFirst = false;
			bool foundSecond = false;
			foreach (Ratio<PhysicalQuantity, PhysicalQuantity> ratio in set)
			{
				if (ratio.Numerator.Quantity.Value == 1000 && ratio.Denominator.Quantity.Value == 1)
				{
					foundFirst = true;
				}
				else
				{
					if (ratio.Numerator.Quantity.Value == 1001 && ratio.Denominator.Quantity.Value == 2)
					{
						foundSecond = true;
					}
				}
			}
			Assert.IsTrue(foundFirst);
			Assert.IsTrue(foundSecond);
		}
	}
}
