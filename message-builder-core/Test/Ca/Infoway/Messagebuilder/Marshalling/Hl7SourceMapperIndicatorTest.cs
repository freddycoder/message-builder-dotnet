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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class Hl7SourceMapperIndicatorTest
	{
		private static readonly string XML_TRUE = "<inFulfillmentOf contextConductionInd=\"true\" contextControlCode=\"AN\" typeCode=\"FLFS\" xmlns=\"urn:hl7-org:v3\" >"
			 + "<sequenceNumber value=\"2\"/>" + "<immunizationPlan classCode=\"SBADM\" moodCode=\"INT\">" + "<code code=\"IMMUNIZ\" codeSystem=\"2.16.840.1.113883.5.4\"/>"
			 + "<statusCode code=\"active\"/>" + "</immunizationPlan>" + "</inFulfillmentOf>";

		private static readonly string XML_FALSE = "<inFulfillmentOf contextConductionInd=\"true\" contextControlCode=\"AN\" typeCode=\"FLFS\" xmlns=\"urn:hl7-org:v3\" >"
			 + "<sequenceNumber value=\"2\"/>" + "</inFulfillmentOf>";

		private static readonly string XML_NULL = "<inFulfillmentOf contextConductionInd=\"true\" contextControlCode=\"AN\" typeCode=\"FLFS\" xmlns=\"urn:hl7-org:v3\" >"
			 + "<sequenceNumber value=\"2\"/>" + "<immunizationPlan nullFlavor=\"UNK\" />" + "</inFulfillmentOf>";

		private XmlDocument document;

		private MessageDefinitionService service;

		private XmlElement element;

		private Hl7PartSource partSource;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
			CodeResolverRegistry.Register(new TrivialCodeResolver());
			this.service = new MockTestCaseMessageDefinitionService();
		}

		[NUnit.Framework.TearDown]
		public virtual void TearDown()
		{
			CodeResolverRegistry.UnregisterAll();
		}

		private Relationship CreateRelationship(string type)
		{
			Relationship relationship = new Relationship();
			relationship.Type = type;
			return relationship;
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMapIndicatorAttributesWhenPresent()
		{
			this.document = GetSourceDocument(XML_TRUE);
			this.element = this.document.DocumentElement;
			Hl7MessageSource rootSource = new Hl7MessageSource(MockVersionNumber.MOCK_MR2009, this.document, null, null, this.service
				);
			this.partSource = rootSource.CreatePartSource(CreateRelationship("POIZ_MT030050CA.InFulfillmentOf"), element);
			InFulfillmentOfBean teal = (InFulfillmentOfBean)new Hl7SourceMapper().MapPartSourceToTeal(this.partSource, null);
			Assert.IsNotNull(teal, "teal");
			Assert.IsNotNull(teal.ImmunizationPlan, "indicator");
			bool indValue = teal.ImmunizationPlan.Value;
			Assert.IsTrue(indValue, "indicator");
			Assert.IsFalse(((BL)teal.GetField("immunizationPlan")).Null, "indicator");
			Assert.AreEqual(2, teal.DoseNumber.Value, "dose number");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandleIndicatorAttributesWhenAbsent()
		{
			this.document = GetSourceDocument(XML_FALSE);
			this.element = this.document.DocumentElement;
			Hl7MessageSource rootSource = new Hl7MessageSource(MockVersionNumber.MOCK_MR2009, this.document, null, null, this.service
				);
			this.partSource = rootSource.CreatePartSource(CreateRelationship("POIZ_MT030050CA.InFulfillmentOf"), element);
			InFulfillmentOfBean teal = (InFulfillmentOfBean)new Hl7SourceMapper().MapPartSourceToTeal(this.partSource, null);
			Assert.IsNotNull(teal, "teal");
			Assert.IsFalse(((BL)teal.GetField("immunizationPlan")).Null, "null flavor");
			Assert.AreEqual(2, teal.DoseNumber.Value, "dose number");
			bool indValue = teal.ImmunizationPlan.Value;
			Assert.IsNotNull(indValue, "indicator");
			Assert.IsFalse(teal.ImmunizationPlan.Value, "indicator");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandleIndicatorAttributesWhenNullFlavor()
		{
			this.document = GetSourceDocument(XML_NULL);
			this.element = this.document.DocumentElement;
			Hl7MessageSource rootSource = new Hl7MessageSource(MockVersionNumber.MOCK_MR2009, this.document, null, null, this.service
				);
			this.partSource = rootSource.CreatePartSource(CreateRelationship("POIZ_MT030050CA.InFulfillmentOf"), element);
			InFulfillmentOfBean teal = (InFulfillmentOfBean)new Hl7SourceMapper().MapPartSourceToTeal(this.partSource, null);
			Assert.IsNotNull(teal, "teal");
			Assert.IsTrue(((BL)teal.GetField("immunizationPlan")).Null, "null flavor");
			Assert.AreEqual(2, teal.DoseNumber.Value, "dose number");
			Assert.IsNull(teal.ImmunizationPlan, "indicator");
		}

		//assertFalse("indicator", teal.getImmunizationPlan()); // indicator boolean value is not present (null) when has null flavor
		/// <exception cref="System.Exception"></exception>
		private XmlDocument GetSourceDocument(string xml)
		{
			return new DocumentFactory().CreateFromString(xml);
		}
	}
}
