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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MessagePartHolder
	{
		private readonly MessagePart messagePart;

		private readonly List<Relationship> allRelationships;

		internal MessagePartHolder(MessageDefinitionService service, VersionNumber version, string superTypeName) : this(service, 
			version, superTypeName, Arrays.AsList(new TypeName(superTypeName)))
		{
		}

		internal MessagePartHolder(MessageDefinitionService service, VersionNumber version, string typeName, IList<TypeName> typeHierarchy
			)
		{
			// intentionally specified as an ArrayList for translation purposes
			this.messagePart = service.GetMessagePart(version, typeName);
			this.allRelationships = MergeRelationships(service, version, typeHierarchy);
			if (typeHierarchy.Count > 1)
			{
				this.allRelationships.Sort();
			}
		}

		internal MessagePartHolder(MessagePart partForTestOnly)
		{
			// tests only
			this.messagePart = partForTestOnly;
			this.allRelationships = new List<Relationship>(partForTestOnly.Relationships);
		}

		private List<Relationship> MergeRelationships(MessageDefinitionService service, VersionNumber version, IList<TypeName> typeHierarchy
			)
		{
			List<Relationship> mergedRelationships = new List<Relationship>();
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
