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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class SetStringElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlNode node = CreateNode("<top>" + "<something>Fred</something>" + "<something>Wilma</something>" + "<something>Betty</something>"
				 + "</top>");
			BareANY result = new SetElementParser(ParserRegistry.GetInstance()).Parse(ParseContextImpl.Create("SET<ST>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), null, false), 
				AsList(node.ChildNodes), null);
			ICollection<string> set = ((SET<ST, string>)result).RawSet();
			Assert.IsNotNull(set, "null");
			Assert.AreEqual(3, set.Count, "size");
			Assert.IsTrue(set.Contains("Fred"), "Fred");
			Assert.IsTrue(set.Contains("Wilma"), "Wilma");
			Assert.IsTrue(set.Contains("Betty"), "Betty");
		}
	}
}
