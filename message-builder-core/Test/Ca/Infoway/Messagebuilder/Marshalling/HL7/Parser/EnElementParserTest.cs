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
			return ParseContextImpl.Create("EN", typeof(EntityName), SpecificationVersion.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.POPULATED, null, null, false);
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
		public virtual void TestParseTrivialNameNoSpecializationType()
		{
			XmlNode node = CreateNode("<something>trivial name</something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(1, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			Assert.IsTrue(entityName is TrivialName, "returned class");
			Assert.IsFalse(this.xmlResult.IsValid());
			Assert.AreEqual(1, this.xmlResult.GetHl7Errors().Count);
			Assert.AreEqual("EN field has been handled as type TN", this.xmlResult.GetHl7Errors()[0].GetMessage());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTrivialNameWithSpecializationTypeAndXsiType()
		{
			XmlNode node = CreateNode("<something specializationType=\"TN\" xsi:type=\"TN\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">trivial name</something>"
				);
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(1, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			Assert.IsTrue(entityName is TrivialName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTrivialNameWithSpecializationType()
		{
			XmlNode node = CreateNode("<something specializationType=\"TN\">trivial name</something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(1, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			Assert.IsTrue(entityName is TrivialName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseTrivialNameWithXsiType()
		{
			XmlNode node = CreateNode("<something xsi:type=\"TN\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">trivial name</something>"
				);
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(1, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			Assert.IsTrue(entityName is TrivialName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseOrganizationName()
		{
			XmlNode node = CreateNode("<something specializationType=\"ON\">trivial name<suffix>Inc</suffix></something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsTrue(this.xmlResult.IsValid());
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(2, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("name", entityName.Parts[0], null, "trivial name");
			AssertNamePartAsExpected("suffix", entityName.Parts[1], OrganizationNamePartType.SUFFIX, "Inc");
			Assert.IsTrue(entityName is OrganizationName, "returned class");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParsePersonNameWithoutSpecializationType()
		{
			XmlNode node = CreateNode("<something><given>Steve</given><family>Shaw</family><suffix>Inc</suffix></something>");
			EntityName entityName = (EntityName)new EnElementParser().Parse(CreateContext(), node, this.xmlResult).BareValue;
			Assert.IsNotNull(entityName, "entity name");
			Assert.AreEqual(3, entityName.Parts.Count, "number of name parts");
			AssertNamePartAsExpected("given", entityName.Parts[0], PersonNamePartType.GIVEN, "Steve");
			AssertNamePartAsExpected("family", entityName.Parts[1], PersonNamePartType.FAMILY, "Shaw");
			AssertNamePartAsExpected("suffix", entityName.Parts[2], PersonNamePartType.SUFFIX, "Inc");
			Assert.IsTrue(entityName is PersonName, "returned class");
			Assert.AreEqual(2, this.xmlResult.GetHl7Errors().Count);
		}

		// 1 warning stating EN treated as PN, 1 for missing "use"
		private void AssertNamePartAsExpected(string message, EntityNamePart namePart, NamePartType expectedType, string expectedValue
			)
		{
			Assert.AreEqual(expectedType, namePart.Type, message + " type");
			Assert.AreEqual(expectedValue, namePart.Value, message + " value");
		}
	}
}
