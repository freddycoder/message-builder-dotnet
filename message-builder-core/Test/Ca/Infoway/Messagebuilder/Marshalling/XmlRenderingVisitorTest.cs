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
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Util;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class XmlRenderingVisitorTest
	{
		[Hl7PartTypeMappingAttribute("ABCD_MT987654CA.Baby")]
		public class Part
		{
			internal Part(XmlRenderingVisitorTest _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly XmlRenderingVisitorTest _enclosing;
		}

		private XmlRenderingVisitor visitor;

		private Interaction interation;

		private MockPartBridge partBridge;

		private MockAttributeBridge attributeBridge;

        private string ignoredAsNotAllowedOriginalValue;

        /// <exception cref="System.Exception"></exception>
        [SetUp]
		public virtual void SetUp()
		{
            ignoredAsNotAllowedOriginalValue = Runtime.GetProperty(ConformanceLevelUtil.IGNORED_AS_NOT_ALLOWED);
            
            CodeResolverRegistry.RegisterResolver(typeof(ActStatus), new EnumBasedCodeResolver(typeof(Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				)));
			CodeResolverRegistry.RegisterResolver(typeof(Realm), new EnumBasedCodeResolver(typeof(Domainvalue.Transport.Realm)));
			this.visitor = new XmlRenderingVisitor(MockVersionNumber.MOCK_MR2009);
			this.partBridge = new MockPartBridge();
			this.attributeBridge = new MockAttributeBridge("aPropertyName");
			this.interation = new Interaction();
			this.interation.Name = "ABCD_IN123456CA";
			Argument argument = new Argument();
			argument.Name = "ABCD_MT987654CA.Baby";
			argument.TemplateParameterName = "act";
			argument.TraversalName = "bambino";
			this.interation.Arguments.Add(argument);
		}

		[TearDown]
		public virtual void TearDown()
		{
            if (ignoredAsNotAllowedOriginalValue == null)
            {
                Runtime.ClearProperty(ConformanceLevelUtil.IGNORED_AS_NOT_ALLOWED);
            }
            else
            {
                Runtime.SetProperty(ConformanceLevelUtil.IGNORED_AS_NOT_ALLOWED, ignoredAsNotAllowedOriginalValue);
            }
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderRootElement()
		{
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\"/>"
				, xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderRootElementWithRealmCode()
		{
			this.partBridge.AddRealmCode(Domainvalue.Transport.Realm.ALBERTA);
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<realmCode code=\"AB\"/>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderNonStructuralAttributeWithNullFlavor()
		{
            IIImpl attributeValue = new IIImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.MASKED);
            Relationship relationship = CreateNonStructuralRelationship();
            ExerciseVisitorOverInteractionWithAttribute(attributeValue, relationship);
            string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<id nullFlavor=\"MSK\"/>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderNonStructuralAttributeWithNullFlavorForCDA()
		{
			this.visitor = new XmlRenderingVisitor(true, true, null);
            IIImpl attributeValue = new IIImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.MASKED);
            Relationship relationship = CreateNonStructuralRelationship();
            ExerciseVisitorOverInteractionWithAttribute(attributeValue, relationship);
            string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ClinicalDocument xmlns=\"urn:hl7-org:v3\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:sdtc=\"urn:hl7-org:sdtc\" xmlns:cda=\"urn:hl7-org:v3\""
				 + ">" + "<id nullFlavor=\"MSK\"/>" + "</ClinicalDocument>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderNonStructuralAttribute()
		{
			BareANY attributeHl7Value = CreateIITokenFromUuid("1ee83ff1-08ab-4fe7-b573-ea777e9bad51");
            Relationship attributeRelationship = CreateNonStructuralRelationship();
            ExerciseVisitorOverInteractionWithAttribute(attributeHl7Value, attributeRelationship);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<id root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad51\"/>" + "</ABCD_IN123456CA>", xml);
		}

        [Test]
        public virtual void ShouldLogInfoMessageForUseOfIgnoredNonStructuralAttribute()
        {
            IIImpl iiImpl = CreateIITokenFromUuid("1ee83ff1-08ab-4fe7-b573-ea777e9bad51");
            Relationship relationship = CreateNonStructuralRelationship();
            relationship.Conformance = ConformanceLevel.IGNORED;

            ExerciseVisitorOverInteractionWithAttribute(iiImpl, relationship);

            AssertXmlContains(
                    "<!-- INFO - DATA_TYPE_ERROR : Attribute is ignored and will not be used: (id) (aPropertyName2.aPropertyName) -->",
                    this.visitor.ToXml().GetXmlMessage());
        }

        [Test]
        public void ShouldNotLogInfoMessageForUseOfIgnoredNonStructuralAttributeWhenNoValueIsSet()
        {
            IIImpl emptyII = new IIImpl();  // don't set the value inside it
            emptyII.DataType = StandardDataType.II_TOKEN;
            Relationship relationship = CreateNonStructuralRelationship();
            relationship.Conformance = ConformanceLevel.IGNORED;

            ExerciseVisitorOverInteractionWithAttribute(emptyII, relationship);

            Assert.IsFalse(StringUtils.Contains(this.visitor.ToXml().GetXmlMessage(), "Attribute is ignored and will not be used"));
        }

        /// <exception cref="System.Exception"></exception>
        [Test]
        public void ShouldNotLogInfoMessageForUseOfIgnoredNonStructuralAttributeWhenListIsEmpty()
        {
            LIST<II, Identifier> idList = new LISTImpl<II, Identifier>(typeof(IIImpl));
		Relationship relationship = CreateNonStructuralRelationship();
        relationship.Conformance = ConformanceLevel.IGNORED;

		ExerciseVisitorOverInteractionWithAttribute(idList, relationship);

        Assert.IsFalse(StringUtils.Contains(this.visitor.ToXml().GetXmlMessage(), "Attribute is ignored and will not be used"));
        }


        [Test]
        public void ShouldLogInfoMessageForUseOfIgnoredNonStructuralAttributeWithNullFlavour()
        {
            IIImpl emptyII = new IIImpl();  // don't set the value inside it
            emptyII.DataType = StandardDataType.II_TOKEN;
            emptyII.NullFlavor = Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.NO_INFORMATION;   // do set a null flavour

            Relationship relationship = CreateNonStructuralRelationship();
            relationship.Conformance = ConformanceLevel.IGNORED;

            ExerciseVisitorOverInteractionWithAttribute(emptyII, relationship);

            AssertXmlContains(
                    "<!-- INFO - DATA_TYPE_ERROR : Attribute is ignored and will not be used: (id) (aPropertyName2.aPropertyName) -->",
                    this.visitor.ToXml().GetXmlMessage());
        }
        [Test]
        public virtual void ShouldLogErrorForUseOfIgnoredNonStructuralAttributeWhenIgnoreConfiguredAsNotAllowed()
        {
            Runtime.SetProperty(ConformanceLevelUtil.IGNORED_AS_NOT_ALLOWED, "true");

            IIImpl iiImpl = CreateIITokenFromUuid("1ee83ff1-08ab-4fe7-b573-ea777e9bad51");
            Relationship relationship = CreateNonStructuralRelationship();
            relationship.Conformance = ConformanceLevel.IGNORED;

            ExerciseVisitorOverInteractionWithAttribute(iiImpl, relationship);

            AssertXmlContains(
                    "<!-- ERROR - DATA_TYPE_ERROR : Attribute is ignored and cannot be used: (id) (aPropertyName2.aPropertyName) -->",
                    this.visitor.ToXml().GetXmlMessage());
        }

        [Test]
        public void shouldLogErrorForUseOfNotAllowedNonStructuralAttribute()
        {
            IIImpl iiImpl = CreateIITokenFromUuid("1ee83ff1-08ab-4fe7-b573-ea777e9bad51");
            Relationship relationship = CreateNonStructuralRelationship();
            relationship.Conformance = ConformanceLevel.NOT_ALLOWED;

            ExerciseVisitorOverInteractionWithAttribute(iiImpl, relationship);

            AssertXmlContains(
                    "<!-- ERROR - DATA_TYPE_ERROR : Attribute is not allowed: (id) (aPropertyName2.aPropertyName) -->",
                    this.visitor.ToXml().GetXmlMessage());
        }

        /// <exception cref="System.Exception"></exception>
        [Test]
		public virtual void ShouldRenderNonStructuralAttributeString()
		{
			STImpl attributeValue = new STImpl("some string");
			Relationship relationship = new Relationship();
			relationship.Name = "value";
			relationship.Type = StandardDataType.ANY_LAB.Type;
            ExerciseVisitorOverInteractionWithAttribute(attributeValue, relationship);
            string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<value xsi:type=\"ST\">some string</value>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderNotNonStructuralAttributeFullDate()
		{
			TNImpl attributeValue = new TNImpl(new TrivialName("Trivial Name"));
			Relationship relationship = new Relationship();
			relationship.Name = "value";
			relationship.Type = StandardDataType.ANY_LAB.Type;
            ExerciseVisitorOverInteractionWithAttribute(attributeValue, relationship);
            ModelToXmlResult result = this.visitor.ToXml();
			result.GetXmlMessage();
			IList<Hl7Error> hl7Errors = result.GetHl7Errors();
			Assert.IsFalse(hl7Errors.IsEmpty(), "should have incompatable ANY.LAB value");
			Assert.AreEqual(1, hl7Errors.Count, "should have incompatable ANY.LAB value");
			Assert.AreEqual("Cannot support properties of type TN for ANY.LAB. Please specify a specializationType applicable for ANY.LAB in the appropriate message bean."
				, hl7Errors[0].GetMessage(), "should have incompatable ANY.LAB value");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderFixedValueNonStructuralAttribute()
		{
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAttribute(this.attributeBridge, CreateFixedValueNonStructuralRelationship(), null, null, null);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<code code=\"completed\" codeSystem=\"2.16.840.1.113883.5.14\"/>" + "</ABCD_IN123456CA>", xml);
		}

        private void ExerciseVisitorOverInteractionWithAttribute(BareANY attributeHl7Value, Relationship attributeRelationship)
        {

            this.attributeBridge.SetHl7Value(attributeHl7Value);
            this.visitor.VisitRootStart(this.partBridge, this.interation);
            this.visitor.VisitAttribute(this.attributeBridge, attributeRelationship, null, null, null);
            this.visitor.VisitRootEnd(this.partBridge, this.interation);
        }

        private IIImpl CreateIITokenFromUuid(string rootUuid)
        {
            IIImpl iiImpl = new IIImpl(new Identifier(rootUuid));
            iiImpl.DataType = StandardDataType.II_TOKEN;
            return iiImpl;
        }

        private Relationship CreateNonStructuralRelationship()
		{
			Relationship relationship = new Relationship();
			relationship.Name = "id";
			relationship.Type = StandardDataType.II_TOKEN.Type;
			return relationship;
		}

		private Relationship CreateFixedValueNonStructuralRelationship()
		{
			Relationship relationship = new Relationship();
			relationship.Name = "code";
			relationship.Type = StandardDataType.CV.Type;
			relationship.DomainType = "ActStatus";
			relationship.FixedValue = "completed";
			return relationship;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderStructuralAttribute()
		{
			this.attributeBridge.SetValue(false);
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAttribute(this.attributeBridge, CreateStructuralRelationship(), null, null, null);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\" negationInd=\"false\"/>"
				, xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderFixedValueStructuralAttribute()
		{
			this.attributeBridge.SetValue(false);
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAttribute(this.attributeBridge, CreateFixedValueStructuralRelationship(), null, null, null);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\" negationInd=\"true\"/>"
				, xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderDefaultValueStructuralAttribute()
		{
			this.attributeBridge.SetValue(null);
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAttribute(this.attributeBridge, CreateDefaultValueStructuralRelationship(), null, null, null);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\" classCode=\"ACT\"/>"
				, xml);
		}

        /// <exception cref="System.Exception"></exception>
        [Test]
        public void ShouldLogInfoMessageForUseOfIgnoredStructuralAttribute()
        {
		    this.attributeBridge.SetValue(false);

		    Relationship relationship = CreateStructuralRelationship();
            relationship.Conformance = ConformanceLevel.IGNORED;

		    this.visitor.VisitRootStart(this.partBridge, this.interation);
		    this.visitor.VisitAttribute(this.attributeBridge, relationship, null, null, null);
		    this.visitor.VisitRootEnd(this.partBridge, this.interation);

            string xml = this.visitor.ToXml().GetXmlMessage();
            AssertXmlEquals("xml", "<!-- WARNING: INFO - DATA_TYPE_ERROR : Attribute is ignored and will not be used: (negationInd) (aPropertyName2.aPropertyName) -->" +
				"<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " +
				"xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\" negationInd=\"false\"/>", xml);
        }

        /// <exception cref="System.Exception"></exception>
        [Test]
        public void ShouldNotLogInfoMessageForUseOfIgnoredStructuralAttributeWhenNoValueSet()
        {
		    this.attributeBridge.SetValue(null);    // no value is set

            Relationship relationship = CreateStructuralRelationship();
            relationship.Conformance = ConformanceLevel.IGNORED;

		    this.visitor.VisitRootStart(this.partBridge, this.interation);
		    this.visitor.VisitAttribute(this.attributeBridge, relationship, null, null, null);
		    this.visitor.VisitRootEnd(this.partBridge, this.interation);

            Assert.IsFalse(StringUtils.Contains(this.visitor.ToXml().GetXmlMessage(), "Attribute is ignored and will not be used"));
        }

        private Relationship CreateStructuralRelationship()
		{
			Relationship relationship = new Relationship();
			relationship.Name = "negationInd";
			relationship.Type = StandardDataType.BL.Type;
			relationship.Structural = true;
			return relationship;
		}

		private Relationship CreateFixedValueStructuralRelationship()
		{
			Relationship relationship = new Relationship();
			relationship.Name = "negationInd";
			relationship.FixedValue = "true";
			relationship.Type = StandardDataType.BL.Type;
			relationship.Structural = true;
			return relationship;
		}

		private Relationship CreateDefaultValueStructuralRelationship()
		{
			Relationship relationship = new Relationship();
			relationship.Name = "classCode";
			relationship.DefaultValue = "ACT";
			relationship.Type = StandardDataType.CS.Type;
			relationship.Structural = true;
			relationship.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY;
			return relationship;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderSimpleAssociation()
		{
			Relationship relationship = CreateSimpleAssociationRelationship();
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(this.partBridge, relationship);
			this.visitor.VisitAssociationEnd(this.partBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<receiver/></ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderSimpleAssociationWithRealmCode()
		{
			Relationship relationship = CreateSimpleAssociationRelationship();
			MockPartBridge associationPartBridge = new MockPartBridge();
			associationPartBridge.AddRealmCode(Domainvalue.Transport.Realm.ALBERTA);
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(associationPartBridge, relationship);
			this.visitor.VisitAssociationEnd(associationPartBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<receiver><realmCode code=\"AB\"/></receiver></ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderSimpleAssociationWithNullFlavor()
		{
			Relationship relationship = CreateSimpleAssociationRelationship();
			this.partBridge.SetNullFlavor(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.MASKED);
			this.partBridge.SetEmpty(true);
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(this.partBridge, relationship);
			this.visitor.VisitAssociationEnd(this.partBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<receiver nullFlavor=\"MSK\" xsi:nil=\"true\"/></ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderSimpleAssociationWithNullFlavorWithoutXsiNil()
		{
			Relationship relationship = CreateSimpleAssociationRelationship();
			this.partBridge.SetNullFlavor(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.MASKED);
			this.partBridge.SetEmpty(true);
			Runtime.SetProperty(NullFlavorHelper.MB_SUPPRESS_XSI_NIL_ON_NULLFLAVOR, "true");
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(this.partBridge, relationship);
			this.visitor.VisitAssociationEnd(this.partBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			Runtime.ClearProperty(NullFlavorHelper.MB_SUPPRESS_XSI_NIL_ON_NULLFLAVOR);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<receiver nullFlavor=\"MSK\"/></ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderTemplateAssociation()
		{
			Relationship relationship = CreateTemplateAssociationRelationship();
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(this.partBridge, relationship);
			this.visitor.VisitAssociationEnd(this.partBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<bambino/></ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderNullAssociation()
		{
			this.partBridge.SetEmpty(true);
			Relationship relationship = CreateSimpleAssociationRelationship();
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(this.partBridge, relationship);
			this.visitor.VisitAssociationEnd(this.partBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<receiver nullFlavor=\"NI\" xsi:nil=\"true\"/></ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderChoiceAssociation()
		{
			this.partBridge.SetTypeName("ABCD_MT987654CA.Baby");
			Relationship relationship = CreateChoiceAssociationRelationship();
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(this.partBridge, relationship);
			this.visitor.VisitAssociationEnd(this.partBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<!-- INFO: Selected option ABCD_MT987654CA.Baby (baby) from choice PRPA_IN101103CA.Receiver -->" + "<baby/></ABCD_IN123456CA>"
				, xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderCombinationOfAttributesAndAssociations()
		{
			this.attributeBridge.SetEmpty(false);
			IIImpl iiImpl = new IIImpl(new Identifier("1ee83ff1-08ab-4fe7-b573-ea777e9bad51"));
			iiImpl.DataType = StandardDataType.II_TOKEN;
			this.attributeBridge.SetHl7Value(iiImpl);
			this.attributeBridge.SetValue(false);
			Relationship relationship = CreateSimpleAssociationRelationship();
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(this.partBridge, relationship);
			this.visitor.VisitAttribute(this.attributeBridge, CreateNonStructuralRelationship(), null, null, null);
			this.visitor.VisitAttribute(this.attributeBridge, CreateStructuralRelationship(), null, null, null);
			this.visitor.VisitAssociationEnd(this.partBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<receiver negationInd=\"false\"><id root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad51\"/></receiver>" + "</ABCD_IN123456CA>"
				, xml);
		}

		private Relationship CreateSimpleAssociationRelationship()
		{
			Relationship relationship = new Relationship();
			relationship.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED;
			relationship.Name = "receiver";
			relationship.Type = "PRPA_IN101103CA.Receiver";
			return relationship;
		}

		private Relationship CreateTemplateAssociationRelationship()
		{
			Relationship relationship = new Relationship();
			relationship.Name = "receiver";
			relationship.TemplateParameterName = "act";
			return relationship;
		}

		private Relationship CreateChoiceAssociationRelationship()
		{
			Relationship relationship = new Relationship();
			relationship.Name = "receiver";
			relationship.Type = "PRPA_IN101103CA.Receiver";
			Relationship choice = new Relationship();
			choice.Name = "baby";
			choice.Type = "ABCD_MT987654CA.Baby";
			relationship.Choices.Add(choice);
			return relationship;
		}

		private void AssertXmlEquals(string @string, string expected, string actual)
		{
			Assert.AreEqual(WhitespaceUtil.NormalizeWhitespace(expected, false), WhitespaceUtil.NormalizeWhitespace(actual, false), @string
				);
		}

        private void AssertXmlContains(string searchString, string actualXml)
        {
            Assert.IsTrue(
                StringUtils.Contains(WhitespaceUtil.NormalizeWhitespace(actualXml, false), searchString),
                System.String.Format("could not find {0} in xml message {1}", searchString, actualXml));
        }
    }
}
