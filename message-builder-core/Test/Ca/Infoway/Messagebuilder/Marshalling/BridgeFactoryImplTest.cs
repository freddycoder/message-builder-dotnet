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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model.Cr;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class BridgeFactoryImplTest
	{
		private static readonly VersionNumber VERSION = MockVersionNumber.MOCK_NEWFOUNDLAND;

		private MessageDefinitionService service;

		private MockMessageDefinitionService mockService;

		/// <exception cref="System.Exception"></exception>
		[NUnit.Framework.SetUp]
		public virtual void SetUp()
		{
			MockMessageBeanRegistry.Initialize();
			this.service = new MockTestCaseMessageDefinitionService();
			this.mockService = new MockMessageDefinitionService();
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandleSimpleCollapsedTypes()
		{
			FindCandidatesCriteria bean = new FindCandidatesCriteria();
			bean.BirthDate = new PlatformDate();
			MessagePart part = this.service.GetMessagePart(VERSION, "PRPA_MT101103CA.ParameterList");
			PartBridge bridge = new BridgeFactoryImpl(this.service, VERSION).CreatePartBridgeFromBean(string.Empty, bean, this.service
				.GetInteraction(VERSION, "PRPA_IN101103CA"), new MessagePartHolder(this.service, VERSION, "PRPA_MT101103CA.ParameterList"
				));
			Assert.AreEqual(6, bridge.GetRelationshipBridges().Count, "bridge");
			BaseRelationshipBridge relationshipBridge = bridge.GetRelationshipBridges()[0];
			Assert.AreEqual("administrativeGender", relationshipBridge.GetRelationship().Name, "type");
			relationshipBridge = bridge.GetRelationshipBridges()[1];
			Assert.AreEqual("clientId", relationshipBridge.GetRelationship().Name, "type");
			relationshipBridge = bridge.GetRelationshipBridges()[2];
			Assert.AreEqual("personAddress", relationshipBridge.GetRelationship().Name, "type");
			relationshipBridge = bridge.GetRelationshipBridges()[3];
			Assert.AreEqual("personBirthtime", relationshipBridge.GetRelationship().Name, "type");
			relationshipBridge = bridge.GetRelationshipBridges()[4];
			Assert.AreEqual("personName", relationshipBridge.GetRelationship().Name, "type");
			relationshipBridge = bridge.GetRelationshipBridges()[5];
			Assert.AreEqual("personTelecom", relationshipBridge.GetRelationship().Name, "type");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldProcessInteraction()
		{
			Interaction interaction = new Interaction();
			interaction.Name = "ABCD_IN123456CA.SimpleInteraction";
			interaction.SuperTypeName = "ABCD_MT123456CA.MessageBean";
			MessagePart partB = new MessagePart("ABCD_MT123456CA.BeanB");
			partB.Relationships.Add(new Relationship("text", "ST", Cardinality.Create("1")));
			MessagePart message = new MessagePart("ABCD_MT123456CA.MessageBean");
			message.Relationships.Add(new Relationship("bean", "ABCD_MT123456CA.BeanB", Cardinality.Create("1")));
			mockService.AddPart("ABCD_MT123456CA.MessageBean", message);
			mockService.AddPart("ABCD_MT123456CA.BeanB", partB);
			mockService.AddInteraction("ABCD_IN123456CA.SimpleInteraction", interaction);
			SimpleInteraction interactionBean = new SimpleInteraction();
			interactionBean.Bean = new BeanB();
			PartBridge bridge = new BridgeFactoryImpl(this.mockService, VERSION).CreateInteractionBridge(interactionBean);
			Assert.IsNotNull(bridge, "bridge");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandleCollapsedTypesWithOuterMultipleCardinalityAndSeveralLevelsOfCollapsing()
		{
			MessagePart partB = new MessagePart("ABCE_MT123456CA.BeanB");
			partB.Relationships.Add(new Relationship("text", "ST", Cardinality.Create("1")));
			MessagePart elidedPart1 = new MessagePart("ABCE_MT123456CA.ElidedPart1");
			elidedPart1.Relationships.Add(new Relationship("component", "ABCE_MT123456CA.ElidedPart2", Cardinality.Create("1")));
			MessagePart elidedPart2 = new MessagePart("ABCE_MT123456CA.ElidedPart2");
			elidedPart2.Relationships.Add(new Relationship("issue", "ABCE_MT123456CA.BeanB", Cardinality.Create("1")));
			mockService.AddPart(elidedPart1.Name, elidedPart1);
			mockService.AddPart(elidedPart2.Name, elidedPart2);
			mockService.AddPart(partB.Name, partB);
			BeanAPrime bean = new BeanAPrime();
			bean.Issues.Add(new BeanB());
			bean.Issues.Add(new BeanB());
			MessagePart part = new MessagePart();
			Relationship subjectOfRelationship = new Relationship("subjectOf", "ABCE_MT123456CA.ElidedPart1", Cardinality.Create("0-50"
				));
			Assert.IsTrue(subjectOfRelationship.Association, "association");
			part.Relationships.Add(subjectOfRelationship);
			PartBridge bridge = new BridgeFactoryImpl(this.mockService, VERSION).CreatePartBridgeFromBean("controlAct", bean, new Interaction
				(), new MessagePartHolder(part));
			Assert.AreEqual(1, bridge.GetRelationshipBridges().Count, "size");
			Assert.AreEqual("subjectOf", bridge.GetRelationshipBridges()[0].GetRelationship().Name, "name of relationship");
			BaseRelationshipBridge relationship = bridge.GetRelationshipBridges()[0];
			Assert.IsTrue(relationship.IsAssociation(), "association relationship");
			ICollection<PartBridge> values = ((AssociationBridge)relationship).GetAssociationValues();
			Assert.AreEqual(2, values.Count, "number of values");
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandleCollapsedTypesWithOuterMultipleCardinality()
		{
			MessagePart partB = new MessagePart("ABCE_MT123456CA.BeanB");
			partB.Relationships.Add(new Relationship("text", "ST", Cardinality.Create("1")));
			MessagePart elidedPart = new MessagePart("ABCE_MT123456CA.ElidedPart");
			elidedPart.Relationships.Add(new Relationship("issue", "ABCE_MT123456CA.BeanB", Cardinality.Create("1")));
			mockService.AddPart(elidedPart.Name, elidedPart);
			mockService.AddPart(partB.Name, partB);
			BeanA bean = new BeanA();
			bean.Issues.Add(new BeanB());
			bean.Issues.Add(new BeanB());
			MessagePart part = new MessagePart();
			Relationship subjectOfRelationship = new Relationship("subjectOf", "ABCE_MT123456CA.ElidedPart", Cardinality.Create("0-50"
				));
			Assert.IsTrue(subjectOfRelationship.Association, "association");
			part.Relationships.Add(subjectOfRelationship);
			PartBridge bridge = new BridgeFactoryImpl(this.mockService, VERSION).CreatePartBridgeFromBean("controlAct", bean, new Interaction
				(), new MessagePartHolder(part));
			Assert.AreEqual(1, bridge.GetRelationshipBridges().Count, "size");
			Assert.AreEqual("subjectOf", bridge.GetRelationshipBridges()[0].GetRelationship().Name, "name of relationship");
			BaseRelationshipBridge relationship = bridge.GetRelationshipBridges()[0];
			Assert.IsTrue(relationship.IsAssociation(), "association relationship");
			ICollection<PartBridge> values = ((AssociationBridge)relationship).GetAssociationValues();
			Assert.AreEqual(2, values.Count, "number of values");
			foreach (PartBridge partBridge in values)
			{
				IList<BaseRelationshipBridge> relationshipBridges = partBridge.GetRelationshipBridges();
				Assert.AreEqual(1, relationshipBridges.Count, "inner relationships");
				BaseRelationshipBridge temp = relationshipBridges[0];
				AssociationBridge association = (AssociationBridge)temp;
				ICollection<PartBridge> innerValues = association.GetAssociationValues();
				Assert.IsFalse(innerValues.IsEmpty(), "has value");
			}
		}
	}
}
