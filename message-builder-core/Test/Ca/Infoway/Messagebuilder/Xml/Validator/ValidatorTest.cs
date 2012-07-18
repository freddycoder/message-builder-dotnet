using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	[TestFixture]
	public class ValidatorTest
	{
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			CodeResolverRegistry.Register(new TrivialCodeResolver());
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidate()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA.xml").Validate();
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidateCaseWhereTemplateTypeIsAlsoChoiceType()
		{
			MessageValidatorResult result = CreateValidator("PRPM_IN306011CA.xml").Validate();
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidateMessageWithLocalExtensions()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_with_additional_namespace.xml").Validate();
			AssertNoErrors("result", result.GetHl7Errors());
		}

		private void AssertNoErrors(string @string, IList<Hl7Error> hl7Errors)
		{
			foreach (Hl7Error hl7Error in hl7Errors)
			{
				Assert.Fail(hl7Error.GetMessage());
			}
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureOnAttribute()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_invalid.xml").Validate();
			foreach (Hl7Error error in result.GetHl7Errors())
			{
				System.Console.Out.WriteLine(error);
			}
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/receiver/device/id", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureOnFixedValue()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_with_fixed_value_error.xml").Validate();
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/controlActEvent/@classCode", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithExtraAttributed()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_with_extra_structural_attribute.xml").Validate();
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/controlActEvent/@fred", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithMissingAssociation()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_with_missing_association.xml").Validate();
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/sender", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithTooManyInstancesOfAssociation()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_with_too_many_associations.xml").Validate();
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/sender", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithMissingNamespace()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_missing_namespace.xml").Validate();
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithExtraElements()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_with_extra_elements.xml").Validate();
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/fred", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationNoFailureDueToSchemaLocation()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_with_schema_location.xml").Validate();
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationOfUnknownType()
		{
			MessageValidatorResult result = CreateValidator("COMT_IN700001CA.xml").Validate();
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationWithNullFlavor()
		{
			MessageValidatorResult result = CreateValidator("PRPA_IN101101CA_with_nullFlavor.xml").Validate();
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="org.xml.sax.SAXException"></exception>
		private Ca.Infoway.Messagebuilder.Xml.Validator.Validator CreateValidator(string resourceName)
		{
			if (!resourceName.StartsWith("/"))
			{
				resourceName = "/" + resourceName;
			}
			XmlDocument document = new DocumentFactory().CreateFromResource(new ClasspathResource(this.GetType(), resourceName));
			return new Ca.Infoway.Messagebuilder.Xml.Validator.Validator(new Service(), document, SpecificationVersion.V02R02);
		}

		// SPD: the sample xmls are not interactions defined in MR2009
		/// <exception cref="System.Exception"></exception>
		[Test]
		[Ignore]
		public virtual void TestChiSampleXml1()
		{
			Ca.Infoway.Messagebuilder.Xml.Validator.Validator validator = CreateNewValidator("Test 1 PORX_IN000001CA.xml");
			MessageValidatorResult result = validator.Validate();
			AssertNoErrors("result", result.GetHl7Errors());
		}

		// SPD: the sample xmls are not interactions defined in MR2009
		/// <exception cref="System.Exception"></exception>
		[Test]
		[Ignore]
		public virtual void TestChiSampleXml2()
		{
			Ca.Infoway.Messagebuilder.Xml.Validator.Validator validator = CreateNewValidator("Test 2 PORX_IN000003CA.xml");
			MessageValidatorResult result = validator.Validate();
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		[Ignore]
		public virtual void TestIntelliwareSampleXml()
		{
			Ca.Infoway.Messagebuilder.Xml.Validator.Validator validator = CreateNewValidator("findCandidatesMr2009Sample.xml");
			MessageValidatorResult result = validator.Validate();
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="org.xml.sax.SAXException"></exception>
		private Ca.Infoway.Messagebuilder.Xml.Validator.Validator CreateNewValidator(string resourceName)
		{
			XmlDocument document = new DocumentFactory().CreateFromResource(new ClasspathResource(this.GetType(), resourceName));
			MessageDefinitionService messageDefinitionService = new MessageDefinitionServiceFactory().Create();
			return new Ca.Infoway.Messagebuilder.Xml.Validator.Validator(messageDefinitionService, document, SpecificationVersion.R02_04_02
				);
		}
	}
}
