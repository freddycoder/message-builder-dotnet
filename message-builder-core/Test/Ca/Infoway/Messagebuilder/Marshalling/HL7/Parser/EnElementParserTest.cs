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
	public class EnElementParserTest : MarshallingTestCase
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseNullNode()
		{
			XmlNode node = CreateNode("<something nullFlavor=\"NI\" />");
			EN<EntityName> en = (EN<EntityName>)new EnElementParser().Parse(CreateContext(), node, this.xmlResult);
			Assert.IsNull(en.Value, "entity name");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION, en.NullFlavor, "null flavor");
		}

		private ParseContext CreateContext()
		{
			return ParserContextImpl.Create("EN", typeof(EntityName), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseEmptyNode()
		{
			XmlNode node = CreateNode("<something/>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(0, entityName.Parts.Count, "number of name parts");
			Assert.AreEqual(0, entityName.Uses.Count, "number of name uses");
			Assert.IsTrue(entityName is TrivialName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTrivialName()
		{
			XmlNode node = CreateNode("<something>trivial name</something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(1, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			Assert.IsTrue(entityName is TrivialName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOrganizationName()
		{
			XmlNode node = CreateNode("<something>trivial name<suffix>Inc</suffix></something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(2, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			AssertNamePartAsExpected("suffix", entityName.Parts[1], OrganizationNamePartType.SUFFIX, "Inc");
			Assert.IsTrue(entityName is OrganizationName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParsePersonName()
		{
			XmlNode node = CreateNode("<something><given>Steve</given><family>Shaw</family><suffix>Inc</suffix></something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(3, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("given", entityName.Parts[0], PersonNamePartType.GIVEN, "Steve");
			AssertNamePartAsExpected("family", entityName.Parts[1], PersonNamePartType.FAMILY, "Shaw");
			AssertNamePartAsExpected("suffix", entityName.Parts[2], PersonNamePartType.SUFFIX, "Inc");
			Assert.IsTrue(entityName is PersonName, "returned class");
		}

		private void AssertNamePartAsExpected(string message, EntityNamePart namePart, NamePartType expectedType, string expectedValue
			)
		{
			Assert.AreEqual(expectedType, namePart.Type, message + " type");
			Assert.AreEqual(expectedValue, namePart.Value, message + " value");
		}
	}
}
