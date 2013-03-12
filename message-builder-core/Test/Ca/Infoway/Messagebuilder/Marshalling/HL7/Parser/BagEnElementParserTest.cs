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
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[TestFixture]
	public class BagEnElementParserTest : ParserTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseSimpleBag()
		{
			XmlNode node = CreateNode("<top><name><family>Flinstone</family><given>Fred</given></name>" + "<name><family>Flinstone</family><given>Wilma</given></name></top>"
				);
			BareANY result = new BagElementParser().Parse(ParserContextImpl.Create("BAG<PN>", null, SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), AsList(node.ChildNodes), this.xmlResult);
			IList<PersonName> list = ((LIST<PN, PersonName>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(2, list.Count, "size");
			EntityName fred = list[0];
			EntityName wilma = list[1];
			Assert.AreEqual("Flinstone", fred.Parts[0].Value);
			Assert.AreEqual("Fred", fred.Parts[1].Value);
			Assert.AreEqual("Flinstone", wilma.Parts[0].Value);
			Assert.AreEqual("Wilma", wilma.Parts[1].Value);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseEmptyBag()
		{
			XmlNode node = CreateNode("<top></top>");
			BareANY result = new BagElementParser().Parse(ParserContextImpl.Create("BAG<PN>", null, SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), AsList(node.ChildNodes), this.xmlResult);
			IList<PersonName> list = ((LIST<PN, PersonName>)result).RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(0, list.Count, "size");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldParseNullFlavor()
		{
			XmlNode node = CreateNode("<top><name nullFlavor=\"NI\"/></top>");
			BareANY result = new BagElementParser().Parse(ParserContextImpl.Create("BAG<PN>", null, SpecificationVersion.V02R02, null
				, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY), AsList(node.ChildNodes), this.xmlResult);
			LIST<PN, PersonName> hl7List = (LIST<PN, PersonName>)result;
			IList<PersonName> list = hl7List.RawList();
			Assert.IsNotNull(list, "null");
			Assert.AreEqual(1, list.Count, "size");
			IList<PN> pnList = (IList<PN>)hl7List.Value;
			PN firstName = pnList[0];
			Assert.IsTrue(firstName.Null, "null");
		}
	}
}
