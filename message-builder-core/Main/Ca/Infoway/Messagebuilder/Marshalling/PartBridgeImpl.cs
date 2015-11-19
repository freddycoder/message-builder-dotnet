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
using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class PartBridgeImpl : PartBridge
	{
		private readonly IList<BaseRelationshipBridge> relationshipBridges;

		private readonly string typeName;

		private readonly bool collapsed;

		private readonly string propertyPath;

		private readonly object bean;

		private readonly bool nullPart;

		public PartBridgeImpl(string propertyPath, object bean, string typeName, IList<BaseRelationshipBridge> relationshipBridges
			, bool collapsed) : this(propertyPath, bean, typeName, relationshipBridges, collapsed, false)
		{
		}

		public PartBridgeImpl(string propertyPath, object bean, string typeName, IList<BaseRelationshipBridge> relationshipBridges
			, bool collapsed, bool nullPart)
		{
			this.propertyPath = propertyPath;
			this.bean = bean;
			this.typeName = typeName;
			this.relationshipBridges = relationshipBridges;
			this.collapsed = collapsed;
			this.nullPart = nullPart;
		}

		public virtual IList<BaseRelationshipBridge> GetRelationshipBridges()
		{
			return this.relationshipBridges;
		}

		public virtual string GetTypeName()
		{
			return this.typeName;
		}

		/// <summary>Determine if a part has any content.</summary>
		/// <remarks>
		/// Determine if a part has any content.
		/// For the purposes of determining emptiness, we don't consider fixed attributes.
		/// We consider fixed values as not providing real content -- only meta-data.
		/// There are some part types that cause especial concern.  For example, the
		/// COCT_MT141007CA.PackagedDevice has only fixed values, and yet it is mandatory.
		/// </remarks>
		public virtual bool IsEmpty()
		{
			bool empty = true;
			foreach (BaseRelationshipBridge relationship in this.relationshipBridges)
			{
				Relationship r = relationship.GetRelationship();
				if (!relationship.GetRelationship().Attribute || !r.HasFixedValue())
				{
					empty &= relationship.IsEmpty();
				}
			}
			// watch out for "indicators", etc.
			if (empty)
			{
				empty = this.collapsed || this.bean == null || HasNullFlavor();
			}
			return empty;
		}

		public virtual bool HasNullFlavor()
		{
			bool result = false;
			if (this.bean is NullFlavorSupport)
			{
				NullFlavorSupport nullable = (NullFlavorSupport)this.bean;
				result = nullable.HasNullFlavor();
			}
			return result;
		}

		public virtual NullFlavor GetNullFlavor()
		{
			NullFlavor result = null;
			if (this.bean is NullFlavorSupport)
			{
				NullFlavorSupport nullable = (NullFlavorSupport)this.bean;
				result = nullable.NullFlavor;
			}
			return result;
		}

		public virtual bool IsCollapsed()
		{
			return this.collapsed;
		}

		public virtual string GetPropertyName()
		{
			return this.propertyPath;
		}

		public virtual bool IsNullPart()
		{
			return this.nullPart;
		}
	}
}
