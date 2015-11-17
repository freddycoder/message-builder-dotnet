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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	[TestFixture]
	public class CodedTypesConstraintsHandlerTest
	{
		private static readonly Type TYPE = typeof(ActStatus);

		private CodedTypesConstraintsHandler constraintsHandler = new CodedTypesConstraintsHandler();

		private TrivialCodeResolver trivialCodeResolver = new TrivialCodeResolver();

		private IList<Hl7Error> errors;

		private sealed class _ErrorLogger_54 : ErrorLogger
		{
			public _ErrorLogger_54(CodedTypesConstraintsHandlerTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string message)
			{
				this._enclosing.errors.Add(new Hl7Error(errorCode, errorLevel, message, string.Empty));
			}

			private readonly CodedTypesConstraintsHandlerTest _enclosing;
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
			this.constraintsHandler.HandleConstraints(null, null, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			CodedTypeR2<Code> codedType = CreateCodedType();
			this.constraintsHandler.HandleConstraints(null, codedType, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			this.constraintsHandler.HandleConstraints(null, codedType, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			ConstrainedDatatype constraints = new ConstrainedDatatype();
			this.constraintsHandler.HandleConstraints(constraints, null, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			codedType.Code = Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus.ACTIVE;
			codedType.Qualifier.Add(new CodeRole());
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		[Test]
		public virtual void TestPassingConstraints()
		{
			CodedTypeR2<Code> codedType = CreateCodedType();
			ConstrainedDatatype constraints = CreateConstraints(true);
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		[Test]
		public virtual void TestTooManyQualifiersWhenQualifierMandatory()
		{
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier.Add(new CodeRole());
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_CARDINALITY_CONSTRAINT, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" qualifier "));
			Assert.IsTrue(this.errors[0].GetMessage().Contains("cardinality"));
		}

		[Test]
		public virtual void TestTooManyQualifiersWhenQualifier0To1()
		{
			ConstrainedDatatype constraints = CreateConstraints(false);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier.Add(new CodeRole());
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_CARDINALITY_CONSTRAINT, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" qualifier "));
			Assert.IsTrue(this.errors[0].GetMessage().Contains("cardinality"));
		}

		[Test]
		public virtual void TestMissingQualifierWhenQualifierMandatory()
		{
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier.Clear();
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" qualifier "));
		}

		[Test]
		public virtual void TestMissingQualifierPassesWhenQualifier0To1()
		{
			ConstrainedDatatype constraints = CreateConstraints(false);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier.Clear();
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		[Test]
		public virtual void TestMissingQualifierName()
		{
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier[0].Name = null;
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" qualifier.name "));
		}

		[Test]
		public virtual void TestMissingQualifierNameCodeAndQualifierNameCodeSystem()
		{
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier[0].Name = new CodedTypeR2<Code>();
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			Assert.AreEqual("121139", codedType.Qualifier[0].Name.GetCodeValue());
			Assert.AreEqual("1.2.840.10008.2.16.4", codedType.Qualifier[0].Name.GetCodeSystem());
		}

		[Test]
		public virtual void TestIncorrectQualifierNameCodeAndQualifierNameCodeSystem()
		{
			Code incorrectName = this.trivialCodeResolver.Lookup<ActStatus>(TYPE, "badCode", "badCodeSystem");
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier[0].Name = new CodedTypeR2<Code>(incorrectName);
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(2, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" qualifier.name.code "));
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING, this.errors[1].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[1].GetMessage().Contains(" qualifier.name.codeSystem "));
			Assert.AreEqual("badCode", codedType.Qualifier[0].Name.GetCodeValue());
			Assert.AreEqual("badCodeSystem", codedType.Qualifier[0].Name.GetCodeSystem());
		}

		[Test]
		public virtual void TestMissingQualifierValue()
		{
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier[0].Value = null;
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" qualifier.value "));
		}

		[Test]
		public virtual void TestMissingQualifierValueCodeAndCodeSystemPasses()
		{
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Qualifier[0].Value = new CodedTypeR2<Code>();
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			Assert.IsNull(codedType.Qualifier[0].Value.GetCodeValue());
			Assert.IsNull(codedType.Qualifier[0].Value.GetCodeSystem());
		}

		[Test]
		public virtual void TestMissingCodeSystem()
		{
			Code codeMissingCodeSystem = this.trivialCodeResolver.Lookup<ActStatus>(TYPE, "okCode", null);
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Code = codeMissingCodeSystem;
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" codeSystem "));
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" not provided"));
			// these checks may eventually change
			Assert.AreEqual("okCode", codedType.GetCodeValue());
			Assert.IsNull(codedType.GetCodeSystem());
		}

		//		assertEquals("1.2.840.10008.2.6.1", codedType.getCodeSystem());
		[Test]
		public virtual void TestIncorrectCodeSystem()
		{
			Code incorrectCode = this.trivialCodeResolver.Lookup<ActStatus>(TYPE, "badCode", "badCodeSystem");
			ConstrainedDatatype constraints = CreateConstraints(true);
			CodedTypeR2<Code> codedType = CreateCodedType();
			codedType.Code = incorrectCode;
			this.constraintsHandler.HandleConstraints(constraints, codedType, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" codeSystem "));
			Assert.AreEqual("badCode", codedType.GetCodeValue());
			Assert.AreEqual("badCodeSystem", codedType.GetCodeSystem());
		}

		private CodedTypeR2<Code> CreateCodedType()
		{
			Code codeWithFixedCodeSystem = this.trivialCodeResolver.Lookup<ActStatus>(TYPE, "aCode", "1.2.840.10008.2.6.1");
			Code name = this.trivialCodeResolver.Lookup<ActStatus>(TYPE, "121139", "1.2.840.10008.2.16.4");
			Code value = this.trivialCodeResolver.Lookup<ActStatus>(TYPE, "anotherCode", "1.2.88888888");
			CodeRole qualifier = new CodeRole(new CodedTypeR2<Code>(name), new CodedTypeR2<Code>(value));
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>(codeWithFixedCodeSystem);
			codedType.Qualifier.Add(qualifier);
			return codedType;
		}

		private ConstrainedDatatype CreateConstraints(bool qualifierMandatory)
		{
			//        <relationship name="qualifier" attribute="false" cardinality="0-1"/>
			//        <relationship name="qualifier" attribute="false" cardinality="1"/>
			//        <relationship name="qualifier.name" attribute="false" cardinality="1"/>
			//        <relationship name="qualifier.name.code" attribute="false" cardinality="1" fixedValue="121139"/>
			//        <relationship name="qualifier.name.codeSystem" attribute="false" cardinality="1" fixedValue="1.2.840.10008.2.16.4"/>
			//        <relationship name="qualifier.value" attribute="false" cardinality="1"/>
			//        <relationship name="qualifier.value.code" attribute="false" domainType="TargetSiteQualifiers" domainSource="VALUE_SET" cardinality="0-1"/>
			//        <relationship name="codeSystem" attribute="false" cardinality="1" fixedValue="1.2.840.10008.2.6.1"/>
			ConstrainedDatatype constraints = new ConstrainedDatatype("MessagePart.relationshipName", "CD");
			constraints.SetRestriction();
			Relationship qualifierConstraint = new Relationship("qualifier", null, Cardinality.Create(qualifierMandatory ? "1" : "0-1"
				));
			Relationship qualifierNameConstraint = new Relationship("qualifier.name", null, Cardinality.Create("1"));
			Relationship qualifierNameCodeConstraint = new Relationship("qualifier.name.code", null, Cardinality.Create("1"));
			qualifierNameCodeConstraint.FixedValue = "121139";
			Relationship qualifierNameCodeSystemConstraint = new Relationship("qualifier.name.codeSystem", null, Cardinality.Create("1"
				));
			qualifierNameCodeSystemConstraint.FixedValue = "1.2.840.10008.2.16.4";
			Relationship qualifierValueConstraint = new Relationship("qualifier.value", null, Cardinality.Create("1"));
			Relationship qualifierValueCodeConstraint = new Relationship("qualifier.value.code", null, Cardinality.Create("1"));
			Relationship codeSystemConstraint = new Relationship("codeSystem", null, Cardinality.Create("1"));
			codeSystemConstraint.FixedValue = "1.2.840.10008.2.6.1";
			constraints.Relationships.Add(qualifierConstraint);
			constraints.Relationships.Add(qualifierNameConstraint);
			constraints.Relationships.Add(qualifierNameCodeConstraint);
			constraints.Relationships.Add(qualifierNameCodeSystemConstraint);
			constraints.Relationships.Add(qualifierValueConstraint);
			constraints.Relationships.Add(qualifierValueCodeConstraint);
			constraints.Relationships.Add(codeSystemConstraint);
			return constraints;
		}

		public CodedTypesConstraintsHandlerTest()
		{
			errorLogger = new _ErrorLogger_54(this);
		}
	}
}
