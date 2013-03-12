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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class TealBeanRenderWalker
	{
		private readonly IInteraction tealBean;

		private readonly BridgeFactory factory;

		private readonly VersionNumber version;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		public TealBeanRenderWalker(IInteraction tealBean, VersionNumber version) : this(tealBean, version, null, null, new MessageDefinitionServiceFactory
			().Create())
		{
		}

		internal TealBeanRenderWalker(IInteraction tealBean, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			, MessageDefinitionService service) : this(tealBean, version, dateTimeZone, dateTimeTimeZone, new BridgeFactoryImpl(service
			, version))
		{
		}

		internal TealBeanRenderWalker(IInteraction tealBean, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			, BridgeFactory factory)
		{
			this.tealBean = tealBean;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.factory = factory;
			this.version = version;
		}

		public virtual void Accept(Visitor visitor)
		{
			Interaction interaction = GetInteraction();
			if (interaction != null)
			{
				Walk(interaction, visitor);
			}
			else
			{
				throw new RenderingException("Cannot determine the interaction type for : " + (this.tealBean == null ? "null" : ClassUtils
					.GetShortClassName(this.tealBean.GetType())));
			}
		}

		private Interaction GetInteraction()
		{
			return this.factory.GetInteraction(this.tealBean);
		}

		private void Walk(Interaction interaction, Visitor visitor)
		{
			PartBridge bridge = GetBridge();
			visitor.VisitRootStart(bridge, interaction);
			ProcessAllRelationships(bridge, interaction, visitor);
			visitor.VisitRootEnd(bridge, interaction);
		}

		private PartBridge GetBridge()
		{
			return this.factory.CreateInteractionBridge(this.tealBean);
		}

		internal virtual void ProcessAllRelationships(PartBridge bridge, Interaction interaction, Visitor visitor)
		{
			foreach (BaseRelationshipBridge relationship in bridge.GetRelationshipBridges())
			{
				ProcessRelationship(interaction, relationship, visitor);
			}
		}

		internal virtual void ProcessRelationship(Interaction interaction, BaseRelationshipBridge relationship, Visitor visitor)
		{
			if (relationship.IsAssociation())
			{
				ProcessAllRelationshipValues(interaction, (AssociationBridge)relationship, visitor);
			}
			else
			{
				visitor.VisitAttribute((AttributeBridge)relationship, relationship.GetRelationship(), this.version, this.dateTimeZone, this
					.dateTimeTimeZone);
			}
		}

		internal virtual void ProcessAllRelationshipValues(Interaction interaction, AssociationBridge relationshipBridge, Visitor
			 visitor)
		{
			ICollection<PartBridge> associationValues = relationshipBridge.GetAssociationValues();
			//		if (associationValues.isEmpty() && relationshipBridge.getRelationship().isPopulated()) {
			//			processAssociation(interaction, relationshipBridge, visitor, null);
			//		} else {
			foreach (PartBridge child in associationValues)
			{
				ProcessAssociation(interaction, relationshipBridge, visitor, child);
			}
		}

		//		}
		private void ProcessAssociation(Interaction interaction, AssociationBridge relationshipBridge, Visitor visitor, PartBridge
			 child)
		{
			visitor.VisitAssociationStart(child, relationshipBridge.GetRelationship());
			ProcessPartValue(child, interaction, relationshipBridge, visitor);
			visitor.VisitAssociationEnd(child, relationshipBridge.GetRelationship());
		}

		private void ProcessPartValue(PartBridge child, Interaction interaction, AssociationBridge relationshipBridge, Visitor visitor
			)
		{
			if (child.IsEmpty() && !relationshipBridge.GetRelationship().Mandatory)
			{
			}
			else
			{
				ProcessAllRelationships(child, interaction, visitor);
			}
		}
	}
}
