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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Model.Mock;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class Hl7SourceMapperNullFlavorTest
	{
		private MessageDefinitionService service;

		private static readonly string XML_WITH_NULL_FLAVOR = "<sender typeCode=\"SND\" xmlns=\"urn:hl7-org:v3\">" + "  <telecom nullFlavor=\"OTH\" />"
			 + "  <device classCode=\"DEV\" determinerCode=\"INSTANCE\">" + "    <id extension=\"123\" root=\"2.16.840.1.113883.4.262.12\" use=\"BUS\" />"
			 + "    <manufacturerModelName>1.0</manufacturerModelName>" + "    <softwareName>Panacea Pharmacy</softwareName>" + "  </device>"
			 + "</sender>";

		private static readonly string XML_CHOICE_WITH_NULL_FLAVOR = "<author xmlns=\"urn:hl7-org:v3\">" + "  <time value=\"20080918181800\"/>"
			 + "  <assignedEntity1 nullFlavor=\"OTH\" />" + "</author>";

		private static readonly string XML_CODE_WITH_NULL_FLAVOR = "<queryByParameter xmlns=\"urn:hl7-org:v3\">" + "  <queryId root=\"1ee83ff1-08ab-4fe7-b573-ea777e9bad31\" />"
			 + "  <initialQuantityCode nullFlavor=\"OTH\" codeSystem=\"2.16.840.1.113883.5.1\" />" + "  <parameterList>" + "    <personName>"
			 + "      <value><given>J</given><family>Smith</family></value>" + "    </personName>" + "  </parameterList>" + "</queryByParameter>";

		// FIXME - TM - 3 tests are commented out below and should be re-implemented
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
		public virtual void ShouldMapAttributeWithNullFlavor()
		{
			Sender bean = (Sender)MapPartSourceToTeal(MockVersionNumber.MOCK_NEWFOUNDLAND, XML_WITH_NULL_FLAVOR, "MCCI_MT002100CA.Sender"
				);
			Assert.IsNotNull(bean, "teal");
			Assert.IsNull(bean.TelecommunicationAddress, "telecom");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, new DataTypeFieldHelper(bean, "telecommunicationAddress"
				).GetNullFlavor(), "null flavor");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMapCDAttributeWithNullFlavor()
		{
			QueryByParameterBean<FindCandidatesCriteria> bean = (QueryByParameterBean<FindCandidatesCriteria>)MapPartSourceToTeal(MockVersionNumber
				.MOCK_NEWFOUNDLAND, XML_CODE_WITH_NULL_FLAVOR, "MFMI_MT700751CA.QueryByParameter");
			Assert.IsNotNull(bean.QueryLimitType, "CD");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER, new DataTypeFieldHelper(bean, "queryLimitType"
				).GetNullFlavor(), "null flavor");
			Assert.AreEqual("2.16.840.1.113883.5.1", bean.QueryLimitType.CodeSystem, "code system");
			Assert.IsNull(bean.QueryLimitType.CodeValue, "code");
		}

		//	@Test
		//	public void shouldMapAssociationWithNullFlavor() throws Exception {
		//		DispenseInstructionsBean bean = (DispenseInstructionsBean) mapPartSourceToTeal(
		//				SpecificationVersion.V02R02, 
		//				"activatePrescriptionRequestWithNullFlavor.xml", 
		//				"./x:controlActEvent/x:subject/x:combinedMedicationRequest/x:component3/x:supplyRequest", 
		//				"PORX_MT010120CA.SupplyRequest");
		//		
		//		assertNotNull("teal bean", bean);
		////		assertTrue("has null flavor", bean.getLocation().hasNullFlavor());
		////		assertEquals("null flavor", NullFlavor.OTHER, bean.getLocation().getNullFlavor());
		//	}
		//
		//	@Test
		//	public void shouldMapCollapsedAssociationWithNullFlavor() throws Exception {
		//		CombinedMedication2Bean bean = (CombinedMedication2Bean) mapPartSourceToTeal(
		//				SpecificationVersion.V02R02, 
		//				"activatePrescriptionRequestWithNullFlavor.xml", 
		//				"./x:controlActEvent/x:subject/x:combinedMedicationRequest", 
		//				"PORX_MT060160CA.CombinedMedicationRequest");
		//		
		//		assertNotNull("teal bean", bean);
		//		assertTrue("has null flavor", bean.getLocation().hasNullFlavor());
		//		assertEquals("null flavor", NullFlavor.OTHER, bean.getLocation().getNullFlavor());
		//	}
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldMapChoiceWithNullFlavor()
		{
			AuthorBean bean = (AuthorBean)MapPartSourceToTeal(MockVersionNumber.MOCK_NEWFOUNDLAND, XML_CHOICE_WITH_NULL_FLAVOR, "MFMI_MT700751CA.Author_V02R02"
				);
			Assert.IsNotNull(bean, "teal bean");
			Assert.IsTrue(((AssignedPersonBean)bean.AuthorPerson).HasNullFlavor(), "choice has null flavor");
			Assert.AreEqual(Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER.CodeValue, ((AssignedPersonBean)bean.AuthorPerson
				).NullFlavor.CodeValue, "choice null flavor");
		}

		//	@Test
		//	public void shouldMapMultipleCardinalityAssociationWithNullFlavor() throws Exception {
		//		Document document1 = new DocumentFactory().createFromResource(
		//				new ClasspathResource(this.getClass(), "findCandidatesQuery_withNullFlavor.xml"));
		//		
		//		Hl7MessageSource rootPartSource1 = new Hl7MessageSource(SpecificationVersion.V02R02.getVersionLiteral(), 
		//				document1, 
		//				this.service);
		//		
		//		FindCandidatesQueryMessageBean bean = (FindCandidatesQueryMessageBean)new Hl7SourceMapper().mapToTeal(rootPartSource1).getMessageObject();
		//
		//		assertNotNull("teal bean", bean);
		//		assertFalse("first reason has no null flavor", bean.getReasons().get(0).hasNullFlavor());
		//		assertTrue("second reason has null flavor", bean.getReasons().get(1).hasNullFlavor());		
		//		assertEquals("second reason null flavor", NullFlavor.OTHER, bean.getReasons().get(1).getNullFlavor());
		//	}
		/// <exception cref="System.IO.IOException"></exception>
		/// <exception cref="org.xml.sax.SAXException"></exception>
		/// <exception cref="javax.xml.xpath.XPathExpressionException"></exception>
		private object MapPartSourceToTeal(VersionNumber version, string xml, string relationshipType)
		{
			XmlDocument document1 = new DocumentFactory().CreateFromString(xml);
			Hl7MessageSource rootPartSource1 = new Hl7MessageSource(version, new DocumentFactory().CreateFromString("<PRPA_IN101103CA xmlns=\"urn:hl7-org:v3\" />"
				), null, null, this.service);
			Hl7PartSource partSource1 = rootPartSource1.CreatePartSource(CreateRelationship(relationshipType), document1.DocumentElement
				);
			return new Hl7SourceMapper().MapPartSourceToTeal(partSource1, null);
		}
	}
}
