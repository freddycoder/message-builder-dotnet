using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using ILOG.J2CsMapping.Collections.Generics;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	[TestFixture]
	public class ValidatingVisitorTest
	{
		public static readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel MANDATORY = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			.MANDATORY;

		public static readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel POPULATED = Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			.POPULATED;

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHaveValidationErrors()
		{
			AssertShouldHaveValidationErrorsFor(MANDATORY);
			AssertShouldHaveValidationErrorsFor(POPULATED);
		}

		/// <exception cref="System.Exception"></exception>
		public virtual void AssertShouldHaveValidationErrorsFor(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel)
		{
			ValidatingVisitor validatingVisitor = new ValidatingVisitor(SpecificationVersion.R02_04_02);
			Relationship relationship = new Relationship();
			relationship.Name = "value";
			relationship.Conformance = conformanceLevel;
			validatingVisitor.VisitNonStructuralAttribute(CreateElement("<node/>"), new List<XmlElement>(), relationship);
			IList<Hl7Error> hl7Errors = validatingVisitor.GetResult().GetHl7Errors();
			Assert.IsFalse(hl7Errors.IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHaveValidationErrorForFixedNonStructural()
		{
			CodeResolverRegistry.Register(new EnumBasedCodeResolver(typeof(Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				)));
			Relationship relationship = new Relationship();
			relationship.Name = "statusCode";
			relationship.Conformance = MANDATORY;
			relationship.FixedValue = "completed";
			relationship.DomainType = "ActStatus";
			relationship.CodingStrength = CodingStrength.CNE;
			relationship.Type = "CS";
			relationship.Structural = false;
			ValidatingVisitor validatingVisitor = new ValidatingVisitor(SpecificationVersion.R02_04_02);
			validatingVisitor.VisitNonStructuralAttribute(CreateElement("<node/>"), Arrays.AsList(CreateElement("<statusCode code=\"completed\"/>"
				)), relationship);
			IList<Hl7Error> hl7Errors = validatingVisitor.GetResult().GetHl7Errors();
			Assert.IsTrue(hl7Errors.IsEmpty());
			validatingVisitor = new ValidatingVisitor(SpecificationVersion.R02_04_02);
			validatingVisitor.VisitNonStructuralAttribute(CreateElement("<node/>"), Arrays.AsList(CreateElement("<statusCode code=\"new\"/>"
				)), relationship);
			hl7Errors = validatingVisitor.GetResult().GetHl7Errors();
			Assert.IsFalse(hl7Errors.IsEmpty());
			validatingVisitor = new ValidatingVisitor(SpecificationVersion.R02_04_02);
			validatingVisitor.VisitNonStructuralAttribute(CreateElement("<node/>"), Arrays.AsList(CreateElement("<statusCode code=\"completedABC\"/>"
				)), relationship);
			hl7Errors = validatingVisitor.GetResult().GetHl7Errors();
			Assert.IsFalse(hl7Errors.IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHaveNoValidationErrorForFixedNonStructuralWhenBoolean()
		{
			CodeResolverRegistry.Register(new EnumBasedCodeResolver(typeof(Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				)));
			Relationship relationship = new Relationship();
			relationship.Name = "statusCode";
			relationship.Conformance = MANDATORY;
			relationship.FixedValue = "true";
			relationship.Structural = false;
			relationship.Type = "BL";
			ValidatingVisitor validatingVisitor = new ValidatingVisitor(SpecificationVersion.R02_04_02);
			validatingVisitor.VisitNonStructuralAttribute(CreateElement("<node/>"), Arrays.AsList(CreateElement("<statusCode value=\"true\"/>"
				)), relationship);
			IList<Hl7Error> hl7Errors = validatingVisitor.GetResult().GetHl7Errors();
			Assert.IsTrue(hl7Errors.IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHaveNoValidationErrorForFixedNonStructuralWhenIntPos()
		{
			CodeResolverRegistry.Register(new EnumBasedCodeResolver(typeof(Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				)));
			Relationship relationship = new Relationship();
			relationship.Name = "statusCode";
			relationship.Conformance = MANDATORY;
			relationship.FixedValue = "112233";
			relationship.Structural = false;
			relationship.Type = "INT.POS";
			ValidatingVisitor validatingVisitor = new ValidatingVisitor(SpecificationVersion.R02_04_02);
			validatingVisitor.VisitNonStructuralAttribute(CreateElement("<node/>"), Arrays.AsList(CreateElement("<statusCode value=\"112233\"/>"
				)), relationship);
			IList<Hl7Error> hl7Errors = validatingVisitor.GetResult().GetHl7Errors();
			Assert.IsTrue(hl7Errors.IsEmpty());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHaveValidationErrorForFixedNonStructuralWhenNotValidType()
		{
			CodeResolverRegistry.Register(new EnumBasedCodeResolver(typeof(Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActStatus
				)));
			Relationship relationship = new Relationship();
			relationship.Name = "statusCode";
			relationship.Conformance = MANDATORY;
			relationship.FixedValue = "123";
			relationship.Structural = false;
			relationship.Type = "INT.NONNEG";
			ValidatingVisitor validatingVisitor = new ValidatingVisitor(SpecificationVersion.R02_04_02);
			validatingVisitor.VisitNonStructuralAttribute(CreateElement("<node/>"), Arrays.AsList(CreateElement("<statusCode value=\"123\"/>"
				)), relationship);
			IList<Hl7Error> hl7Errors = validatingVisitor.GetResult().GetHl7Errors();
			Assert.IsFalse(hl7Errors.IsEmpty());
		}

		/// <exception cref="org.xml.sax.SAXException"></exception>
		private XmlElement CreateElement(string xml)
		{
			return new DocumentFactory().CreateFromString(xml).DocumentElement;
		}
	}
}
