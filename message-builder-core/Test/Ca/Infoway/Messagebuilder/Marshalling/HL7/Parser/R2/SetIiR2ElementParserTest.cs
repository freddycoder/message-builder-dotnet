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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[TestFixture]
	public class SetIiR2ElementParserTest : ParserTestCase
	{
		private ParserR2Registry parserR2Registry = ParserR2Registry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMissingFixedConstraint()
		{
			XmlNode node = CreateNode("<top>" + "<something root=\"1.2.3.4\" extension=\"5678\" />" + "</top>");
			ConstrainedDatatype constraints = new ConstrainedDatatype("constraintName", "II");
			Relationship rootConstraint = new Relationship();
			rootConstraint.Name = "root";
			rootConstraint.FixedValue = "a_fixed_value";
			constraints.Relationships.Add(rootConstraint);
			Relationship extConstraint = new Relationship();
			extConstraint.Name = "extension";
			extConstraint.FixedValue = "an_extension";
			constraints.Relationships.Add(extConstraint);
			XmlToModelResult xmlToModelResult = new XmlToModelResult();
			BareANY result = new SetR2ElementParser(this.parserR2Registry).Parse(ParseContextImpl.Create("SET<II>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), constraints, false
				), AsList(node.ChildNodes), xmlToModelResult);
			ICollection<Identifier> rawSet = ((SET<II, Identifier>)result).RawSet();
			Assert.IsFalse(xmlToModelResult.IsValid());
			Assert.AreEqual(1, xmlToModelResult.GetHl7Errors().Count, "size");
			Assert.AreEqual("Expected to find an identifier with: root={a_fixed_value},extension={an_extension}", xmlToModelResult.GetHl7Errors
				()[0].GetMessage());
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING, xmlToModelResult.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.AreEqual(ErrorLevel.WARNING, xmlToModelResult.GetHl7Errors()[0].GetHl7ErrorLevel());
			Assert.IsNotNull(rawSet, "null");
			Assert.AreEqual(1, rawSet.Count, "size");
			IEnumerator<Identifier> iterator = rawSet.GetEnumerator();
			if (iterator.MoveNext())
			{
				Assert.AreEqual(new Identifier("1.2.3.4", "5678"), iterator.Current);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMissingFixedtemplateIdConstraint()
		{
			XmlNode node = CreateNode("<top>" + "<something root=\"1.2.3.4\" extension=\"5678\" />" + "</top>");
			ConstrainedDatatype constraints = new ConstrainedDatatype("constraintName.templateId", "II");
			Relationship rootConstraint = new Relationship();
			rootConstraint.Name = "root";
			rootConstraint.FixedValue = "a_fixed_value";
			constraints.Relationships.Add(rootConstraint);
			XmlToModelResult xmlToModelResult = new XmlToModelResult();
			BareANY result = new SetR2ElementParser(this.parserR2Registry).Parse(ParseContextImpl.Create("SET<II>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), constraints, false
				), AsList(node.ChildNodes), xmlToModelResult);
			ICollection<Identifier> rawSet = ((SET<II, Identifier>)result).RawSet();
			Assert.IsFalse(xmlToModelResult.IsValid());
			Assert.AreEqual(1, xmlToModelResult.GetHl7Errors().Count, "size");
			Assert.AreEqual("Expected to find an identifier with: root={a_fixed_value},extension={null}", xmlToModelResult.GetHl7Errors
				()[0].GetMessage());
			Assert.AreEqual(Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING, xmlToModelResult.GetHl7Errors()[0].GetHl7ErrorCode(
				));
			Assert.AreEqual(ErrorLevel.WARNING, xmlToModelResult.GetHl7Errors()[0].GetHl7ErrorLevel());
			Assert.IsNotNull(rawSet, "null");
			Assert.AreEqual(1, rawSet.Count, "size");
			IEnumerator<Identifier> iterator = rawSet.GetEnumerator();
			if (iterator.MoveNext())
			{
				Assert.AreEqual(new Identifier("1.2.3.4", "5678"), iterator.Current);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMatchingFixedTemplateIdConstraint()
		{
			XmlNode node = CreateNode("<top>" + "<something root=\"1.2.3.4\"/>" + "</top>");
			ConstrainedDatatype constraints = new ConstrainedDatatype("constraintName.templateId", "II");
			Relationship rootConstraint = new Relationship();
			rootConstraint.Name = "root";
			rootConstraint.FixedValue = "1.2.3.4";
			constraints.Relationships.Add(rootConstraint);
			XmlToModelResult xmlToModelResult = new XmlToModelResult();
			BareANY result = new SetR2ElementParser(this.parserR2Registry).Parse(ParseContextImpl.Create("SET<II>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), constraints, false
				), AsList(node.ChildNodes), xmlToModelResult);
			ICollection<Identifier> rawSet = ((SET<II, Identifier>)result).RawSet();
			Assert.IsTrue(xmlToModelResult.IsValid());
			// only has an info message
			Assert.AreEqual(1, xmlToModelResult.GetHl7Errors().Count, "size");
			Assert.AreEqual("Found match for templateId fixed constraint: root={1.2.3.4},extension={null}", xmlToModelResult.GetHl7Errors
				()[0].GetMessage());
			Assert.AreEqual(Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MATCH, xmlToModelResult.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.AreEqual(ErrorLevel.INFO, xmlToModelResult.GetHl7Errors()[0].GetHl7ErrorLevel());
			Assert.IsNotNull(rawSet, "null");
			Assert.AreEqual(1, rawSet.Count, "size");
			IEnumerator<Identifier> iterator = rawSet.GetEnumerator();
			if (iterator.MoveNext())
			{
				Assert.AreEqual(new Identifier("1.2.3.4"), iterator.Current);
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestParseMatchingFixedNonTemplateIdConstraint()
		{
			XmlNode node = CreateNode("<top>" + "<something root=\"1.2.3.4\"/>" + "</top>");
			ConstrainedDatatype constraints = new ConstrainedDatatype("constraintName.somethingElse", "II");
			Relationship rootConstraint = new Relationship();
			rootConstraint.Name = "root";
			rootConstraint.FixedValue = "1.2.3.4";
			constraints.Relationships.Add(rootConstraint);
			XmlToModelResult xmlToModelResult = new XmlToModelResult();
			BareANY result = new SetR2ElementParser(this.parserR2Registry).Parse(ParseContextImpl.Create("SET<II>", null, SpecificationVersion
				.V02R02, null, null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality.Create("1-5"), constraints, false
				), AsList(node.ChildNodes), xmlToModelResult);
			ICollection<Identifier> rawSet = ((SET<II, Identifier>)result).RawSet();
			Assert.IsTrue(xmlToModelResult.IsValid());
			// only has an info message
			Assert.IsTrue(xmlToModelResult.GetHl7Errors().IsEmpty());
			Assert.IsNotNull(rawSet, "null");
			Assert.AreEqual(1, rawSet.Count, "size");
			IEnumerator<Identifier> iterator = rawSet.GetEnumerator();
			if (iterator.MoveNext())
			{
				Assert.AreEqual(new Identifier("1.2.3.4"), iterator.Current);
			}
		}
	}
}
