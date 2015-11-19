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
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using NUnit.Framework;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[TestFixture]
	public class RelationshipSorterTest
	{
		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandleCollapsedProperties()
		{
			RelationshipSorter sorter = RelationshipSorter.Create(string.Empty, new MockMessageBean());
			Relationship relationship = new Relationship("theType", "MOCK_MT898989CA.SubType", Cardinality.Create("1"));
			Assert.IsNotNull(sorter.Get(relationship), "type exists");
			Assert.IsTrue(sorter.Get(relationship) is BeanProperty, "type");
			sorter = RelationshipSorter.Create(string.Empty, new MockSubType());
			relationship = new Relationship("component", "MOCK_MT123456CA.Component", Cardinality.Create("1"));
			Assert.IsNotNull(sorter.Get(relationship), "component exists");
			Assert.IsTrue(sorter.Get(relationship) is RelationshipSorter, "component");
			RelationshipSorter deviceSorter = (RelationshipSorter)sorter.Get(relationship);
			Assert.IsNotNull(deviceSorter.Get(new Relationship("subject3", "MOCK_MT123456CA.Subject6", Cardinality.Create("1"))), "id exists"
				);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandlePropertiesWithMapByPartType()
		{
			RelationshipSorter sorter = RelationshipSorter.Create(string.Empty, new MockMultiplyMappedMessagePartBean());
			Relationship relationship = new Relationship("theType", "MOCK_MT898989CA.SubType", Cardinality.Create("1"));
			object @object = sorter.Get(relationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is BeanProperty, "type");
			AssertPropertyNamesEqual("property name", "type2", @object);
			Relationship otherRelationship = new Relationship("theType", "MOCK_MT123456CA.SubType", Cardinality.Create("1"));
			object otherObject = sorter.Get(otherRelationship);
			Assert.IsNotNull(otherObject, "other type exists");
			Assert.IsTrue(otherObject is BeanProperty, "other type");
			AssertPropertyNamesEqual("other property name", "type", otherObject);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandleCompoundPropertiesWithMapByPartType()
		{
			RelationshipSorter sorter = RelationshipSorter.Create(string.Empty, new MockMultiplyCompoundMappedMessagePartBean());
			Relationship relationship1 = new Relationship("theType", "MOCK_MT123458CA.SubTypeA", Cardinality.Create("1"));
			Relationship relationship2 = new Relationship("theSubType", "MOCK_MT123457CA.SubTypeB", Cardinality.Create("1"));
			Relationship relationship3 = new Relationship("theSubSubType", "MOCK_MT898989CA.SubType", Cardinality.Create("1"));
			// first level
			object @object = sorter.Get(relationship1);
			Assert.IsNotNull(@object, "exists");
			Assert.IsTrue(@object is RelationshipSorter, "type");
			RelationshipSorter tempSorter = (RelationshipSorter)@object;
			// second level
			@object = tempSorter.Get(relationship2);
			Assert.IsNotNull(@object, "exists");
			Assert.IsTrue(@object is RelationshipSorter, "type");
			tempSorter = (RelationshipSorter)@object;
			// third level
			@object = tempSorter.Get(relationship3);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is BeanProperty, "type");
			AssertPropertyNamesEqual("property name", "type2", @object);
			Relationship otherRelationship1 = new Relationship("theType", "MOCK_MT123458CA.SubTypeA", Cardinality.Create("1"));
			Relationship otherRelationship2 = new Relationship("theSubType", "MOCK_MT123457CA.SubTypeB", Cardinality.Create("1"));
			Relationship otherRelationship3 = new Relationship("theSubSubType", "MOCK_MT123456CA.SubType", Cardinality.Create("1"));
			// first level
			@object = sorter.Get(otherRelationship1);
			Assert.IsNotNull(@object, "other exists");
			Assert.IsTrue(@object is RelationshipSorter, "other type");
			tempSorter = (RelationshipSorter)@object;
			// second level
			@object = tempSorter.Get(otherRelationship2);
			Assert.IsNotNull(@object, "other exists");
			Assert.IsTrue(@object is RelationshipSorter, "other type");
			tempSorter = (RelationshipSorter)@object;
			// third level
			@object = tempSorter.Get(otherRelationship3);
			Assert.IsNotNull(@object, "other type exists");
			Assert.IsTrue(@object is BeanProperty, "other type");
			AssertPropertyNamesEqual("other property name", "type", @object);
		}

		/// <exception cref="System.Exception"></exception>
		[Test]
		public virtual void ShouldHandleInlinedPropertiesWithMapByPartTypeAndWithout()
		{
			RelationshipSorter sorter = RelationshipSorter.Create(string.Empty, new MockMultiplyCompoundNestedMappedMessagePartBean()
				);
			Relationship organizationInMapByPartTypeRelationship = new Relationship("representedOrganization", "COCT_MT090102CA.Organization"
				, Cardinality.Create("1"));
			Relationship organizationNotInMapByPartTypeRelationship = new Relationship("representedOrganization", "MOCK_MT090102CA.Organization"
				, Cardinality.Create("1"));
			Relationship assignedOrganizationInMapByPartTypeRelationship = new Relationship("assignedOrganization", "COCT_MT260030CA.Organization"
				, Cardinality.Create("1"));
			Relationship nameRelationship = new Relationship("name", "ST", Cardinality.Create("1"));
			Relationship idRelationship = new Relationship("id", "II", Cardinality.Create("1"));
			Relationship otherIdRelationship = new Relationship("otherId", "II", Cardinality.Create("1"));
			// >>>>>>>>>>>>>>>>>>
			object @object = sorter.Get(organizationInMapByPartTypeRelationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is RelationshipSorter, "type");
			RelationshipSorter innerSorter = (RelationshipSorter)@object;
			@object = innerSorter.Get(nameRelationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is BeanProperty, "type");
			AssertPropertyNamesEqual("property name", "assignedOrganizationName", @object);
			@object = innerSorter.Get(idRelationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is BeanProperty, "type");
			AssertPropertyNamesEqual("property id", "organizationIdentifier", @object);
			@object = innerSorter.Get(otherIdRelationship);
			Assert.IsNull(@object, "type does not exists");
			// >>>>>>>>>>>>>>>>>>
			@object = sorter.Get(organizationNotInMapByPartTypeRelationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is RelationshipSorter, "type");
			innerSorter = (RelationshipSorter)@object;
			@object = innerSorter.Get(nameRelationship);
			Assert.IsNull(@object, "type does not exist");
			@object = innerSorter.Get(idRelationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is BeanProperty, "type");
			AssertPropertyNamesEqual("property id", "organizationIdentifier", @object);
			@object = innerSorter.Get(otherIdRelationship);
			Assert.IsNull(@object, "type does not exist");
			// >>>>>>>>>>>>>>>>>>
			@object = sorter.Get(assignedOrganizationInMapByPartTypeRelationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is RelationshipSorter, "type");
			innerSorter = (RelationshipSorter)@object;
			@object = innerSorter.Get(nameRelationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is BeanProperty, "type");
			AssertPropertyNamesEqual("property name", "assignedOrganizationName", @object);
			@object = innerSorter.Get(idRelationship);
			Assert.IsNull(@object, "type should not exist");
			@object = innerSorter.Get(otherIdRelationship);
			Assert.IsNotNull(@object, "type exists");
			Assert.IsTrue(@object is BeanProperty, "type");
			AssertPropertyNamesEqual("other property id", "otherOrganizationIdentifier", @object);
		}

		private void AssertPropertyNamesEqual(string message, string expected, object beanProperty)
		{
			Assert.AreEqual(expected.ToLower(), GetNameFromProperty(beanProperty).ToLower(), message);
		}

		private string GetNameFromProperty(object beanProperty)
		{
			return ((BeanProperty)beanProperty).Name;
		}
	}
}
