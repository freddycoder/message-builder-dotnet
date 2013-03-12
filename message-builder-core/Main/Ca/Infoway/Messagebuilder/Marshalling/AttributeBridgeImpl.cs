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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>An implementation of the AttributeBridge interface.</summary>
	/// <remarks>
	/// An implementation of the AttributeBridge interface.  This class
	/// provides access to a single HL7 attribute in a part.
	/// </remarks>
	/// <author>Intelliware Development</author>
	internal class AttributeBridgeImpl : AttributeBridge
	{
		private readonly Relationship relationship;

		private readonly BeanProperty property;

		internal AttributeBridgeImpl(Relationship relationship, BeanProperty property)
		{
			this.relationship = relationship;
			this.property = property;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual bool IsAssociation()
		{
			return false;
		}

		public virtual object GetValue()
		{
			return this.property == null ? null : this.property.Get();
		}

		public virtual bool IsEmpty()
		{
			return EmptinessUtil.IsEmpty(GetValue());
		}

		public virtual BareANY GetHl7Value()
		{
			return this.property == null ? null : new DataTypeFieldHelper(property.Bean, property.Name).Get<BareANY>();
		}

		public virtual string GetPropertyName()
		{
			return this.property == null ? string.Empty : this.property.Name;
		}

		public override string ToString()
		{
			return this.relationship.ToString() + " -> " + DescribeProperty();
		}

		private string DescribeProperty()
		{
			if (this.property == null)
			{
				return "nothing";
			}
			else
			{
				return ClassUtils.GetShortClassName(this.property.BeanType) + "." + this.property.Name;
			}
		}

		public virtual BareANY GetHl7Value(int index)
		{
			object list = this.property == null ? null : new DataTypeFieldHelper(property.Bean, property.Name).Get<object>();
			if (this.property.Collection && ListElementUtil.Count(list) < index)
			{
				return (BareANY)ListElementUtil.GetElement(list, index);
			}
			else
			{
				return null;
			}
		}
	}
}
