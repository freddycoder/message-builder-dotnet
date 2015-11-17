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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints
{
	[TestFixture]
	public class EdConstraintsHandlerTest
	{
		private EdConstraintsHandler constraintsHandler = new EdConstraintsHandler();

		private IList<Hl7Error> errors;

		private sealed class _ErrorLogger_51 : ErrorLogger
		{
			public _ErrorLogger_51(EdConstraintsHandlerTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string message)
			{
				this._enclosing.errors.Add(new Hl7Error(errorCode, errorLevel, message, string.Empty));
			}

			private readonly EdConstraintsHandlerTest _enclosing;
		}

		private ErrorLogger errorLogger;

		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			//NUnit does not allocate a new instance for each test method. Need to do this in setUp.
			errors = new List<Hl7Error>();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestNullCases()
		{
			this.constraintsHandler.HandleConstraints(null, null, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			EncapsulatedData ed = new EncapsulatedData();
			this.constraintsHandler.HandleConstraints(null, ed, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			this.constraintsHandler.HandleConstraints(null, ed, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			ConstrainedDatatype constraints = new ConstrainedDatatype();
			this.constraintsHandler.HandleConstraints(constraints, null, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			ed.Content = "some content";
			ed.ReferenceObj = new TelecommunicationAddress(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.TEL, "4167620032");
			ed.MediaType = Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HTML_TEXT;
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestPassingConstraints()
		{
			EncapsulatedData ed = CreateEd(true, true, Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.DICOM);
			ConstrainedDatatype constraints = CreateConstraints(true);
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingReferenceFailingConstraint()
		{
			EncapsulatedData ed = CreateEd(false, false, Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.DICOM);
			ConstrainedDatatype constraints = CreateConstraints(true);
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" reference "));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingReferenceValueFailingConstraint()
		{
			EncapsulatedData ed = CreateEd(true, false, Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.DICOM);
			ConstrainedDatatype constraints = CreateConstraints(true);
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" reference.value "));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingReferenceValuePassesIfReferenceMissingAndNotMandatory()
		{
			EncapsulatedData ed = CreateEd(true, false, Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.DICOM);
			ed.ReferenceObj = null;
			ConstrainedDatatype constraints = CreateConstraints(false);
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingReferenceValueFailsIfReferenceProvidedAndNotMandatory()
		{
			EncapsulatedData ed = CreateEd(true, false, Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.DICOM);
			ConstrainedDatatype constraints = CreateConstraints(false);
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_MANDATORY_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" reference.value "));
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestIncorrectMediaTypeFailingConstraint()
		{
			EncapsulatedData ed = CreateEd(true, true, Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HL7_CDA);
			ConstrainedDatatype constraints = CreateConstraints(true);
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsFalse(this.errors.IsEmpty());
			Assert.AreEqual(1, this.errors.Count);
			Assert.AreEqual(Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING, this.errors[0].GetHl7ErrorCode());
			Assert.IsTrue(this.errors[0].GetMessage().Contains(" mediaType "));
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.HL7_CDA, ed.MediaType);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestMissingMediaTypeFailingConstraint()
		{
			EncapsulatedData ed = CreateEd(true, true, null);
			ConstrainedDatatype constraints = CreateConstraints(true);
			this.constraintsHandler.HandleConstraints(constraints, ed, this.errorLogger);
			Assert.IsTrue(this.errors.IsEmpty());
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.DICOM, ed.MediaType);
		}

		/// <exception cref="System.Exception"></exception>
		private EncapsulatedData CreateEd(bool createReference, bool createReferenceValue, x_DocumentMediaType mediaType)
		{
			EncapsulatedData ed = new EncapsulatedData();
			if (createReference)
			{
				ed.ReferenceObj = new TelecommunicationAddress();
				if (createReferenceValue)
				{
					ed.ReferenceObj.UrlScheme = Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.TEL;
					ed.ReferenceObj.Address = "4167620032";
				}
			}
			if (mediaType != null)
			{
				ed.MediaType = mediaType;
			}
			ed.Content = "some content";
			return ed;
		}

		private ConstrainedDatatype CreateConstraints(bool referenceMandatory)
		{
			//        <relationship name="reference" attribute="false" cardinality="1"/>
			//        <relationship name="reference.value" attribute="false" cardinality="1"/>
			//
			//        <relationship name="reference" attribute="false" cardinality="0-1"/>
			//        <relationship name="reference.value" attribute="false" cardinality="1"/>
			//
			//        <relationship name="mediaType" attribute="false" cardinality="1" fixedValue="application/dicom"/>
			//        <relationship name="reference" attribute="false" cardinality="1"/>
			ConstrainedDatatype constraints = new ConstrainedDatatype("MessagePart.relationshipName", "ED");
			constraints.SetRestriction();
			Relationship referenceConstraint = new Relationship("reference", null, Cardinality.Create(referenceMandatory ? "1" : "0-1"
				));
			constraints.Relationships.Add(referenceConstraint);
			Relationship referenceValueConstraint = new Relationship("reference.value", null, Cardinality.Create("1"));
			constraints.Relationships.Add(referenceValueConstraint);
			Relationship mediaTypeConstraint = new Relationship("mediaType", null, Cardinality.Create("1"));
			mediaTypeConstraint.FixedValue = "application/dicom";
			constraints.Relationships.Add(mediaTypeConstraint);
			return constraints;
		}

		public EdConstraintsHandlerTest()
		{
			errorLogger = new _ErrorLogger_51(this);
		}
	}
}
