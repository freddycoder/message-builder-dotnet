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
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class ListErrorElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParse()
		{
			XmlToModelResult result = new XmlToModelResult();
			XmlNode node = CreateNode("<top><name>Fred</name>" + "<name>Flinstone</name></top>");
			new ListElementParser(ParserRegistry.GetInstance()).Parse(ParseContextImpl.Create("LIST<ABCDEFGHIJKLMNOPQRSTUVWXYZ>", null
				, SpecificationVersion.V02R02, null, null, null, Cardinality.Create("1-5"), null, false), AsList(node.ChildNodes), result
				);
			Assert.IsFalse(result.IsValid(), "valid");
			foreach (Hl7Error error in result.GetHl7Errors())
			{
				System.Console.Out.WriteLine(error);
			}
		}
	}
}
