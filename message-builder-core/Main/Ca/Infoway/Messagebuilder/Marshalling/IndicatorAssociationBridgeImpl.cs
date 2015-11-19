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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class IndicatorAssociationBridgeImpl : AssociationBridge
	{
		private readonly Relationship relationship;

		private readonly IList<PartBridge> parts;

		private readonly BeanProperty beanProperty;

		public IndicatorAssociationBridgeImpl(Relationship relationship, PartBridge bridge, BeanProperty beanProperty)
		{
			this.relationship = relationship;
			this.beanProperty = beanProperty;
			this.parts = Arrays.AsList(bridge);
		}

		public virtual ICollection<PartBridge> GetAssociationValues()
		{
			return IsEmpty() ? CollUtils.EmptyList<PartBridge>() : this.parts;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual bool IsAssociation()
		{
			return true;
		}

		public virtual bool IsEmpty()
		{
			// null flavor does *not* read as empty
			return false.Equals(this.beanProperty == null ? null : this.beanProperty.Get());
		}

		public virtual string GetPropertyName()
		{
			return null;
		}
	}
}
