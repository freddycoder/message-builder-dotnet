using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
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

		/// <exception cref="System.Exception"></exception>
		[SetUp]
		public virtual void SetUp()
		{
			CodeResolverRegistry.RegisterResolver(typeof(ActStatus), new EnumBasedCodeResolver(typeof(Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				)));
			this.visitor = new XmlRenderingVisitor();
			this.partBridge = new MockPartBridge();
			this.attributeBridge = new MockAttributeBridge();
			this.interation = new Interaction();
			this.interation.Name = "ABCD_IN123456CA";
			Argument argument = new Argument();
			argument.Name = "ABCD_MT987654CA.Baby";
			argument.TemplateParameterName = "act";
			argument.TraversalName = "bambino";
			this.interation.Arguments.Add(argument);
			Runtime.SetProperty(ConformanceLevelUtil.IGNORED_AS_NOT_ALLOWED, string.Empty);
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
		public virtual void ShouldRenderNonStructuralAttributeWithNullFlavor()
		{
			this.attributeBridge.SetHl7Value(new IIImpl(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.MASKED));
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAttribute(this.attributeBridge, CreateNonStructuralRelationship(), null, null, null);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<id nullFlavor=\"MSK\"/>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderNonStructuralAttribute()
		{
			this.attributeBridge.SetHl7Value(new IIImpl(new Identifier("1ee83ff1-08ab-4fe7-b573-ea777e9bad51")));
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAttribute(this.attributeBridge, CreateNonStructuralRelationship(), null, null, null);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<id root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad51\"/>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderNonStructuralAttributeString()
		{
			this.attributeBridge.SetHl7Value(new STImpl("some string"));
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			Relationship relationship = new Relationship();
			relationship.Name = "value";
			relationship.Type = StandardDataType.ANY_LAB.Type;
			this.visitor.VisitAttribute(this.attributeBridge, relationship, null, null, null);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<value specializationType=\"ST\" xsi:type=\"ST\">some string</value>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderNotNonStructuralAttributeFullDate()
		{
			this.attributeBridge.SetHl7Value(new TNImpl(new TrivialName("Trivial Name")));
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			Relationship relationship = new Relationship();
			relationship.Name = "value";
			relationship.Type = StandardDataType.ANY_LAB.Type;
			this.visitor.VisitAttribute(attributeBridge, relationship, null, null, null);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
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
				 + "<baby/></ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderCombinationOfAttributesAndAssociations()
		{
			this.attributeBridge.SetEmpty(false);
			this.attributeBridge.SetHl7Value(new IIImpl(new Identifier("1ee83ff1-08ab-4fe7-b573-ea777e9bad51")));
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

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderWarningsForAssociationWithIgnoreConformanceAsOptional()
		{
			Relationship relationship = CreateSimpleAssociationRelationship();
			relationship.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			Relationship nonStructuralAttr = CreateNonStructuralRelationship();
			nonStructuralAttr.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			Relationship structuralAttr = CreateStructuralRelationship();
			structuralAttr.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			RunVisitor(relationship, nonStructuralAttr, structuralAttr);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<!-- WARNING: Association is ignored and will not be used: (receiver) -->" + "<receiver negationInd=\"false\">" + "<id root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad51\"/>"
				 + "</receiver>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderWarningsForInternalAttributesWithIgnoreConformanceAsOptional()
		{
			Relationship relationship = CreateSimpleAssociationRelationship();
			Relationship nonStructuralAttr = CreateNonStructuralRelationship();
			nonStructuralAttr.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			Relationship structuralAttr = CreateStructuralRelationship();
			structuralAttr.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			RunVisitor(relationship, nonStructuralAttr, structuralAttr);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<!-- WARNING: Attribute is ignored and will not be used: (negationInd) -->" + "<receiver negationInd=\"false\">" + "<!-- WARNING: Attribute is ignored and will not be used: (id) -->"
				 + "<id root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad51\"/>" + "</receiver>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderWarningsForAssociationWithIgnoreConformanceAsNotAllowed()
		{
			Runtime.SetProperty(ConformanceLevelUtil.IGNORED_AS_NOT_ALLOWED, "true");
			Relationship relationship = CreateSimpleAssociationRelationship();
			relationship.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			Relationship nonStructuralAttr = CreateNonStructuralRelationship();
			nonStructuralAttr.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			Relationship structuralAttr = CreateStructuralRelationship();
			structuralAttr.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			RunVisitor(relationship, nonStructuralAttr, structuralAttr);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<!-- WARNING: Association is ignored and can not be used: (receiver) -->" + "<receiver negationInd=\"false\">" + "<id root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad51\"/>"
				 + "</receiver>" + "</ABCD_IN123456CA>", xml);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldRenderWarningsForInternalAttributesWithIgnoreConformanceAsNotAllowed()
		{
			Runtime.SetProperty(ConformanceLevelUtil.IGNORED_AS_NOT_ALLOWED, "true");
			Relationship relationship = CreateSimpleAssociationRelationship();
			Relationship nonStructuralAttr = CreateNonStructuralRelationship();
			nonStructuralAttr.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			Relationship structuralAttr = CreateStructuralRelationship();
			structuralAttr.Conformance = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.IGNORED;
			RunVisitor(relationship, nonStructuralAttr, structuralAttr);
			string xml = this.visitor.ToXml().GetXmlMessage();
			AssertXmlEquals("xml", "<ABCD_IN123456CA xmlns=\"urn:hl7-org:v3\" " + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ITSVersion=\"XML_1.0\">"
				 + "<!-- WARNING: Attribute is ignored and can not be used: (negationInd) -->" + "<receiver negationInd=\"false\">" + "<!-- WARNING: Attribute is ignored and can not be used: (id) -->"
				 + "<id root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad51\"/>" + "</receiver>" + "</ABCD_IN123456CA>", xml);
		}

		private void RunVisitor(Relationship relationship, Relationship nonStructuralAttr, Relationship structuralAttr)
		{
			this.attributeBridge.SetEmpty(false);
			this.attributeBridge.SetHl7Value(new IIImpl(new Identifier("1ee83ff1-08ab-4fe7-b573-ea777e9bad51")));
			this.attributeBridge.SetValue(false);
			this.visitor.VisitRootStart(this.partBridge, this.interation);
			this.visitor.VisitAssociationStart(this.partBridge, relationship);
			this.visitor.VisitAttribute(this.attributeBridge, nonStructuralAttr, null, null, null);
			this.visitor.VisitAttribute(this.attributeBridge, structuralAttr, null, null, null);
			this.visitor.VisitAssociationEnd(this.partBridge, relationship);
			this.visitor.VisitRootEnd(this.partBridge, this.interation);
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
			Assert.AreEqual(WhitespaceUtil.NormalizeWhitespace(expected), WhitespaceUtil.NormalizeWhitespace(actual), @string);
		}
	}
}
