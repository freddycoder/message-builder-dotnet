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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[TestFixture]
	public class ListIiR2PropertyFormatterTest : FormatterTestCase
	{
		private FormatterR2Registry formatterRegistry = FormatterR2Registry.GetInstance();

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNull()
		{
			string result = new ListR2PropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "ids", "LIST<II>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, null, false), (BareANY)new 
				LISTImpl<II, Identifier>(typeof(IIImpl)));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(0, this.result.GetHl7Errors().Count);
			AssertXml("null", string.Empty, result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatValueNonNull()
		{
			string result = new ListR2PropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "ids", "LIST<II>", Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, Cardinality.Create("0-4"
				), false, SpecificationVersion.R02_04_03, null, null, null, false), (BareANY)LISTImpl<ANY<object>, object>.Create<II, Identifier
				>(typeof(IIImpl), CreateIdentifierList()));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(0, this.result.GetHl7Errors().Count);
			AssertXml("non null", "<ids extension=\"123\" root=\"1.2.3\"/>" + "<ids extension=\"256\" root=\"2.5.6\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatWithMatchingConstraint()
		{
			Relationship rootConstraint = new Relationship();
			rootConstraint.Name = "root";
			rootConstraint.FixedValue = "2.5.6";
			Relationship extConstraint = new Relationship();
			extConstraint.Name = "extension";
			extConstraint.FixedValue = "256";
			ConstrainedDatatype constraints = new ConstrainedDatatype("iiConstraint", "II");
			constraints.Relationships.Add(rootConstraint);
			constraints.Relationships.Add(extConstraint);
			string result = new ListR2PropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "ids", "LIST<II>", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, Cardinality.Create
				("0-4"), false, SpecificationVersion.R02_04_03, null, null, null, constraints, false), (BareANY)LISTImpl<ANY<object>, object
				>.Create<II, Identifier>(typeof(IIImpl), CreateIdentifierList()));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(0, this.result.GetHl7Errors().Count);
			AssertXml("non null", "<ids extension=\"123\" root=\"1.2.3\"/>" + "<ids extension=\"256\" root=\"2.5.6\"/>", result);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestFormatWithMissingConstraint()
		{
			Relationship rootConstraint = new Relationship();
			rootConstraint.Name = "root";
			rootConstraint.FixedValue = "1.22.33.44";
			Relationship extConstraint = new Relationship();
			extConstraint.Name = "extension";
			extConstraint.FixedValue = "1223344";
			ConstrainedDatatype constraints = new ConstrainedDatatype("iiConstraint", "II");
			constraints.Relationships.Add(rootConstraint);
			constraints.Relationships.Add(extConstraint);
			string result = new ListR2PropertyFormatter(this.formatterRegistry).Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl
				(this.result, null, "ids", "LIST<II>", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL, Cardinality.Create
				("0-4"), false, SpecificationVersion.R02_04_03, null, null, null, constraints, false), (BareANY)LISTImpl<ANY<object>, object
				>.Create<II, Identifier>(typeof(IIImpl), CreateIdentifierList()));
			Assert.IsTrue(this.result.IsValid());
			Assert.AreEqual(1, this.result.GetHl7Errors().Count);
			Assert.AreEqual(ErrorLevel.INFO, this.result.GetHl7Errors()[0].GetHl7ErrorLevel());
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_PROVIDED, this.result.GetHl7Errors()[0].GetHl7ErrorCode());
			Assert.AreEqual("A fixed constraint was added for compliance: root={1.22.33.44},extension={1223344}", this.result.GetHl7Errors
				()[0].GetMessage());
			AssertXml("non null", "<ids extension=\"123\" root=\"1.2.3\"/>" + "<ids extension=\"256\" root=\"2.5.6\"/>" + "<ids extension=\"1223344\" root=\"1.22.33.44\"/>"
				, result);
		}

		private IList<Identifier> CreateIdentifierList()
		{
			List<Identifier> result = new List<Identifier>();
			result.Add(new Identifier("1.2.3", "123"));
			result.Add(new Identifier("2.5.6", "256"));
			return result;
		}
	}
}
