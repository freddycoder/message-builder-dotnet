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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using Ca.Infoway.Messagebuilder.Xml.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class TealBeanRenderWalker
	{
		private readonly IInteraction tealBean;

		private readonly BridgeFactory factory;

		private readonly VersionNumber version;

		private readonly TimeZoneInfo dateTimeZone;

		private readonly TimeZoneInfo dateTimeTimeZone;

		public TealBeanRenderWalker(IInteraction tealBean, VersionNumber version) : this(tealBean, version, null, null, new MessageDefinitionServiceFactory
			().Create())
		{
		}

		internal TealBeanRenderWalker(IInteraction tealBean, VersionNumber version, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone
			, MessageDefinitionService service) : this(tealBean, version, dateTimeZone, dateTimeTimeZone, new BridgeFactoryImpl(service
			, version))
		{
		}

		internal TealBeanRenderWalker(IInteraction tealBean, VersionNumber version, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone
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
				ConstrainedDatatype constraints = this.factory.GetConstraints(relationship.GetRelationship());
				visitor.VisitAttribute((AttributeBridge)relationship, relationship.GetRelationship(), constraints, this.version, this.dateTimeZone
					, this.dateTimeTimeZone);
			}
		}

		internal virtual void ProcessAllRelationshipValues(Interaction interaction, AssociationBridge relationshipBridge, Visitor
			 visitor)
		{
			ICollection<PartBridge> associationValues = relationshipBridge.GetAssociationValues();
			ValidateAssociationCardinality(relationshipBridge, associationValues, visitor);
			foreach (PartBridge child in associationValues)
			{
				ProcessAssociation(interaction, relationshipBridge, visitor, child);
			}
		}

		// RM16130 - the MB marshaller was not validating association cardinality
		// TODO TM - this should really be in the visitor, but would pollute the interface a bit
		private void ValidateAssociationCardinality(AssociationBridge relationshipBridge, ICollection<PartBridge> associationValues
			, Visitor visitor)
		{
			// can't just check the size of associationValues: need to iterate and only count each "not empty" or each with NF
			int size = 0;
			foreach (PartBridge partBridge in associationValues)
			{
				if (!partBridge.IsEmpty() || partBridge.HasNullFlavor())
				{
					size++;
				}
			}
			Relationship relationship = relationshipBridge.GetRelationship();
			Cardinality cardinality = relationship.Cardinality;
			if (size > cardinality.Max)
			{
				string errorMessage = "Expected no more than " + cardinality.Max + " entries for association " + relationship.ParentType 
					+ "." + relationship.Name + " but found " + size;
				visitor.LogError(new Hl7Error(Hl7ErrorCode.NUMBER_OF_ASSOCIATIONS_EXCEEDS_LIMIT, errorMessage, visitor.GetCurrentPropertyPath
					() + "." + relationship.Name));
			}
			else
			{
				if (size != 0 && size < cardinality.Min)
				{
					// cases where at least 1 association is required are handled elsewhere (under mandatory checks)
					string errorMessage = "Expected at least " + cardinality.Min + " entries for association " + relationship.ParentType + "."
						 + relationship.Name + " but only found " + size;
					visitor.LogError(new Hl7Error(Hl7ErrorCode.MANDATORY_ASSOCIATION_NOT_PROVIDED, errorMessage, visitor.GetCurrentPropertyPath
						() + "." + relationship.Name));
				}
			}
		}

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
			if (child.IsEmpty() && !ConformanceLevelUtil.IsMandatory(relationshipBridge.GetRelationship()))
			{
			}
			else
			{
				ProcessAllRelationships(child, interaction, visitor);
			}
		}
	}
}
