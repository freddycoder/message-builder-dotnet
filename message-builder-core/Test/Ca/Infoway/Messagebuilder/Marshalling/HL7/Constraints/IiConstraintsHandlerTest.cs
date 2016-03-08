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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	[TestFixture]
	public class IiConstraintsHandlerTest
	{
		private IiConstraintsHandler constraintsHandler = new IiConstraintsHandler();

		private IList<Hl7Error> errors;

		private sealed class _ErrorLogger_47 : ErrorLogger
		{
			public _ErrorLogger_47(IiConstraintsHandlerTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string message)
			{
				this._enclosing.errors.Add(new Hl7Error(errorCode, errorLevel, message, string.Empty));
			}

			private readonly IiConstraintsHandlerTest _enclosing;
		}

		private ErrorLogger errorLogger;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			//NUnit does not allocate a new instance for each test method. Need to do this in setUp.
			errors = new List<Hl7Error>();
		}

		[Test]
		public virtual void TestNullCases()
		{
			this.constraintsHandler.HandleConstraints(null, null, this.errorLogger, false);
			Assert.IsTrue(this.errors.IsEmpty());
			Identifier identifier = new Identifier();
			this.constraintsHandler.HandleConstraints(null, identifier, this.errorLogger, false);
			Assert.IsTrue(this.errors.IsEmpty());
			this.constraintsHandler.HandleConstraints(null, identifier, this.errorLogger, false);
			Assert.IsTrue(this.errors.IsEmpty());
			ConstrainedDatatype constraints = new ConstrainedDatatype();
			this.constraintsHandler.HandleConstraints(constraints, null, this.errorLogger, false);
			Assert.IsTrue(this.errors.IsEmpty());
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, false);
			Assert.IsTrue(this.errors.IsEmpty());
			identifier.Root = "1.2.3";
			identifier.Extension = "123";
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, false);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		[Test]
		public virtual void TestPassingConstraints()
		{
			Identifier identifier = new Identifier("1.2.3.4", "1234");
			ConstrainedDatatype constraints = CreateConstraints(false);
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, true);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		[Test]
		public virtual void TestPassingTemplateIdConstraints()
		{
			Identifier identifier = new Identifier("1.2.3.4", "1234");
			ConstrainedDatatype constraints = CreateConstraints(true);
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, true);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MATCH, this.errors[0].GetHl7ErrorCode());
			Assert.AreEqual(ErrorLevel.INFO, this.errors[0].GetHl7ErrorLevel());
			Assert.AreEqual("1.2.3.4", identifier.Root);
			Assert.AreEqual("1234", identifier.Extension);
		}

		[Test]
		public virtual void TestExistingRootFailingConstraint()
		{
			Identifier identifier = new Identifier("1.7777", "1234");
			ConstrainedDatatype constraints = CreateConstraints(false);
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, false);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.AreEqual("1.7777", identifier.Root);
			Assert.AreEqual("1234", identifier.Extension);
		}

		[Test]
		public virtual void TestExistingtemplateIdRootFailingConstraint()
		{
			Identifier identifier = new Identifier("1.7777", "1234");
			ConstrainedDatatype constraints = CreateConstraints(true);
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, true);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.AreEqual("1.7777", identifier.Root);
			Assert.AreEqual("1234", identifier.Extension);
		}

		[Test]
		public virtual void TestExistingExtensionFailingConstraint()
		{
			Identifier identifier = new Identifier("1.2.3.4", "12347777");
			ConstrainedDatatype constraints = CreateConstraints(false);
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, false);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.AreEqual("1.2.3.4", identifier.Root);
			Assert.AreEqual("12347777", identifier.Extension);
		}

		[Test]
		public virtual void TestMissingRootFailingConstraint()
		{
			Identifier identifier = new Identifier((string)null, "1234");
			ConstrainedDatatype constraints = CreateConstraints(false);
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, false);
			Assert.IsTrue(this.errors.IsEmpty());
			Assert.AreEqual("1.2.3.4", identifier.Root);
			Assert.AreEqual("1234", identifier.Extension);
		}

		[Test]
		public virtual void TestMissingExtensionFailingConstraint()
		{
			Identifier identifier = new Identifier("1.2.3.4", (string)null);
			ConstrainedDatatype constraints = CreateConstraints(false);
			this.constraintsHandler.HandleConstraints(constraints, identifier, this.errorLogger, false);
			Assert.IsTrue(this.errors.IsEmpty());
			Assert.AreEqual("1.2.3.4", identifier.Root);
			Assert.AreEqual("1234", identifier.Extension);
		}

		private ConstrainedDatatype CreateConstraints(bool isTemplateId)
		{
			string name = (isTemplateId ? "MessagePart.templateId" : "MessagePart.relationshipName");
			ConstrainedDatatype constraints = new ConstrainedDatatype(name, "II");
			constraints.SetRestriction();
			Relationship rootConstraint = new Relationship("root", null, Cardinality.Create("1"));
			rootConstraint.FixedValue = "1.2.3.4";
			Relationship extensionConstraint = new Relationship("extension", null, Cardinality.Create("1"));
			extensionConstraint.FixedValue = "1234";
			constraints.Relationships.Add(rootConstraint);
			constraints.Relationships.Add(extensionConstraint);
			return constraints;
		}

		public IiConstraintsHandlerTest()
		{
			errorLogger = new _ErrorLogger_47(this);
		}
	}
}
