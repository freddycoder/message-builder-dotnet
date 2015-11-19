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
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class RelationshipFormat
	{
		private readonly string traversalName;

		private readonly string type;

		private readonly Argument argument;

		public RelationshipFormat(string traversalName, string type)
		{
			this.traversalName = traversalName;
			this.type = type;
			this.argument = null;
		}

		public RelationshipFormat(string traversalName, string type, Argument argument)
		{
			this.traversalName = traversalName;
			this.type = type;
			this.argument = argument;
		}

		public virtual string GetTraversalName()
		{
			return this.traversalName;
		}

		public virtual string GetXmlElementName()
		{
			return this.traversalName;
		}

		public virtual string Type
		{
			get
			{
				return this.type;
			}
		}

		internal static Ca.Infoway.Messagebuilder.Marshalling.RelationshipFormat GetRelationshipFormat(ConversionContext context, 
			Relationship relationship)
		{
			if (relationship.TemplateRelationship)
			{
				return context.ResolveTemplateType(relationship);
			}
			else
			{
				return new Ca.Infoway.Messagebuilder.Marshalling.RelationshipFormat(relationship.Name, relationship.Type);
			}
		}

		public virtual Argument GetArgument()
		{
			return this.argument;
		}
	}
}
