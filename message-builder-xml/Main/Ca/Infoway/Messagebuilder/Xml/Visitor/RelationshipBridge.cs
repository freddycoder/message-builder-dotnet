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
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Visitor;

namespace Ca.Infoway.Messagebuilder.Xml.Visitor
{
	internal class RelationshipBridge
	{
		private readonly Relationship relationship;

		private readonly ElementBridge elementBridge;

		public RelationshipBridge(ElementBridge elementBridge, Relationship relationship)
		{
			this.elementBridge = elementBridge;
			this.relationship = relationship;
		}

		public virtual bool IsAssociation()
		{
			return this.relationship.Association;
		}

		public virtual bool IsStructuralAttribute()
		{
			return this.relationship.Attribute && this.relationship.Structural;
		}

		public virtual IList<XmlElement> GetElements()
		{
			return this.elementBridge.GetElements(this.relationship);
		}

		internal virtual XmlElement GetBase()
		{
			return this.elementBridge.GetBase();
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual XmlAttribute GetAttribute()
		{
			return this.elementBridge.GetAttribute(this.relationship);
		}

		internal virtual string GetXmlName()
		{
			return this.elementBridge.GetXmlName(this.relationship);
		}

		public override string ToString()
		{
			return "Relationship: " + this.relationship.Name;
		}

		public virtual ICollection<string> GetNames()
		{
			ICollection<string> names = new HashSet<string>();
			if (IsStructuralAttribute())
			{
				names.Add(this.relationship.Name);
			}
			else
			{
				foreach (XmlElement element in GetElements())
				{
					names.Add(NodeUtil.GetLocalOrTagName(element));
				}
			}
			return names;
		}
	}
}
