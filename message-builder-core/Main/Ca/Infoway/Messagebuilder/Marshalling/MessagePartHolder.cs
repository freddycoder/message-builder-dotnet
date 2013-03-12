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
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MessagePartHolder
	{
		private class RelationshipComparator : IComparer<Relationship>
		{
			public virtual int Compare(Relationship o1, Relationship o2)
			{
				// apply sort: attributes/choices/associations/templates (?? confirm with Mario), then alphabetically within each section
				return new CompareToBuilder().Append(o1.Attribute, o2.Attribute).Append(o1.Choice, o2.Choice).Append(!o1.TemplateRelationship
					, !o2.TemplateRelationship).Append(o1.Name, o2.Name).ToComparison();
			}

			internal RelationshipComparator(MessagePartHolder _enclosing)
			{
				this._enclosing = _enclosing;
			}

			private readonly MessagePartHolder _enclosing;
		}

		private readonly MessagePart messagePart;

		private readonly IList<Relationship> allRelationships;

		private IComparer<Relationship> relationshipComparator;

		internal MessagePartHolder(MessageDefinitionService service, VersionNumber version, string superTypeName) : this(service, 
			version, superTypeName, Arrays.AsList(new TypeName(superTypeName)))
		{
			relationshipComparator = new MessagePartHolder.RelationshipComparator(this);
		}

		internal MessagePartHolder(MessageDefinitionService service, VersionNumber version, string typeName, IList<TypeName> typeHierarchy
			)
		{
			relationshipComparator = new MessagePartHolder.RelationshipComparator(this);
			this.messagePart = service.GetMessagePart(version, typeName);
			this.allRelationships = MergeRelationships(service, version, typeHierarchy);
		}

		internal MessagePartHolder(MessagePart partForTestOnly)
		{
			relationshipComparator = new MessagePartHolder.RelationshipComparator(this);
			// FIXME - TM - relationships should be sorted in a particular order; hold off on this until discuss with Mario
			//            - also, numerous transformation tests will fail once this change is made 
			//Collections.sort(this.allRelationships, this.relationshipComparator);
			// tests only
			this.messagePart = partForTestOnly;
			this.allRelationships = partForTestOnly.Relationships;
		}

		private IList<Relationship> MergeRelationships(MessageDefinitionService service, VersionNumber version, IList<TypeName> typeHierarchy
			)
		{
			IList<Relationship> mergedRelationships = new List<Relationship>();
			foreach (TypeName type in typeHierarchy)
			{
				MessagePart part = service.GetMessagePart(version, type.Name);
				if (part != null)
				{
					mergedRelationships.AddAll(part.Relationships);
				}
			}
			return mergedRelationships;
		}

		internal virtual string GetName()
		{
			return this.messagePart.Name;
		}

		internal virtual IList<Relationship> GetRelationships()
		{
			return this.allRelationships;
		}
	}
}
