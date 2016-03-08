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
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	[Ignore]
	[TestFixture]
	public class ValidatorTest
	{
		// TM - FIXME - CDA -  need to determine if these can be adjusted to work with new validator
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
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA.xml");
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidateCaseWhereTemplateTypeIsAlsoChoiceType()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPM_IN306011CA.xml");
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidateMessageWithLocalExtensions()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_with_additional_namespace.xml");
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
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_invalid.xml");
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
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_with_fixed_value_error.xml");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/controlActEvent/@classCode", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithExtraAttributed()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_with_extra_structural_attribute.xml");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/controlActEvent/@fred", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithMissingAssociation()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_with_missing_association.xml");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/sender", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithTooManyInstancesOfAssociation()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_with_too_many_associations.xml");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/sender", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithMissingNamespace()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_missing_namespace.xml");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationFailureWithExtraElements()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_with_extra_elements.xml");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
			Assert.AreEqual("/PRPA_IN101101CA/fred", result.GetHl7Errors()[0].GetPath(), "message");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationNoFailureDueToSchemaLocation()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_with_schema_location.xml");
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationOfUnknownType()
		{
			MessageValidatorResult result = ValidateWithMockService("COMT_IN700001CA.xml");
			Assert.AreEqual(1, result.GetHl7Errors().Count, "result");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void TestValidationWithNullFlavor()
		{
			MessageValidatorResult result = ValidateWithMockService("PRPA_IN101101CA_with_nullFlavor.xml");
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="Platform.Xml.Sax.SAXException"></exception>
		private MessageValidatorResult ValidateWithMockService(string resourceName)
		{
			if (!resourceName.StartsWith("/"))
			{
				resourceName = "/" + resourceName;
			}
			XmlDocument document = new DocumentFactory().CreateFromResource(new ClasspathResource(this.GetType(), resourceName));
			MessageDefinitionService messageDefinitionService = new MessageDefinitionServiceFactory().Create();
			return new MessageValidatorImpl(messageDefinitionService).Validate(document, SpecificationVersion.V02R02);
		}

		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="Platform.Xml.Sax.SAXException"></exception>
		private MessageValidatorResult ValidateWithActualService(string resourceName)
		{
			XmlDocument document = new DocumentFactory().CreateFromResource(new ClasspathResource(this.GetType(), resourceName));
			MessageDefinitionService messageDefinitionService = new MessageDefinitionServiceFactory().Create();
			return new MessageValidatorImpl(messageDefinitionService).Validate(document, SpecificationVersion.R02_04_02);
		}

		// SPD: the sample xmls are not interactions defined in MR2009
		/// <exception cref="System.Exception"></exception>
		[Test]
		[Ignore]
		public virtual void TestChiSampleXml1()
		{
			MessageValidatorResult result = ValidateWithActualService("Test 1 PORX_IN000001CA.xml");
			AssertNoErrors("result", result.GetHl7Errors());
		}

		// SPD: the sample xmls are not interactions defined in MR2009
		/// <exception cref="System.Exception"></exception>
		[Test]
		[Ignore]
		public virtual void TestChiSampleXml2()
		{
			MessageValidatorResult result = ValidateWithActualService("Test 2 PORX_IN000003CA.xml");
			AssertNoErrors("result", result.GetHl7Errors());
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		[Ignore]
		public virtual void TestIntelliwareSampleXml()
		{
			MessageValidatorResult result = ValidateWithActualService("findCandidatesMr2009Sample.xml");
			AssertNoErrors("result", result.GetHl7Errors());
		}
	}
}
