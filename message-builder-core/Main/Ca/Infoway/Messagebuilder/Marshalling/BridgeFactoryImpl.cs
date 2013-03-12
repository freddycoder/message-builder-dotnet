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
using System.Collections;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using ILOG.J2CsMapping.Text;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class BridgeFactoryImpl : BridgeFactory
	{
		private readonly ILog log = log4net.LogManager.GetLogger(typeof(BridgeContext));

		private readonly VersionNumber version;

		private readonly MessageDefinitionService service;

		public BridgeFactoryImpl(MessageDefinitionService service, VersionNumber version)
		{
			this.service = service;
			this.version = version;
		}

		public virtual PartBridge CreateInteractionBridge(IInteraction tealBean)
		{
			Interaction interaction = GetInteraction(tealBean);
			return new TopLevelBeanBridgeWrapper(CreatePartBridgeFromBean(tealBean.GetType().Name, tealBean, interaction, GetMessagePart
				(interaction)), interaction.Name, this.version);
		}

		internal virtual PartBridge CreatePartBridgeFromBean(string propertyPath, object tealBean, Interaction interaction, MessagePartHolder
			 currentMessagePart)
		{
			RelationshipSorter sorter = RelationshipSorter.Create(propertyPath, tealBean);
			return CreatePartBridge(sorter, interaction, currentMessagePart, new BridgeContext(), false);
		}

		private PartBridge CreatePartBridge(RelationshipSorter sorter, Interaction interaction, MessagePartHolder currentMessagePart
			, BridgeContext context, bool nullPart)
		{
			IList<BaseRelationshipBridge> relationships = new List<BaseRelationshipBridge>();
			foreach (Relationship relationship in currentMessagePart.GetRelationships())
			{
				object o = sorter.Get(relationship);
				if (relationship.Attribute && relationship.Fixed)
				{
					relationships.Add(new FixedValueAttributeBeanBridge(relationship, (BareANY)null));
				}
				else
				{
					if (relationship.Attribute)
					{
						if (o == null)
						{
							CreateWarningIfPropertyIsNotMapped(sorter, currentMessagePart, relationship);
							relationships.Add(new AttributeBridgeImpl(relationship, null));
						}
						else
						{
							if (context.IsIndexed())
							{
								CreateWarningIfConformanceLevelIsNotAllowed(relationship);
								object field = sorter.GetField(relationship);
								if (ListElementUtil.IsCollection(field))
								{
									relationships.Add(new CollapsedAttributeBridge(((BeanProperty)o).Name, relationship, ListElementUtil.GetElement(field, context
										.GetIndex())));
								}
								else
								{
									throw new MarshallingException("Expected relationship " + relationship.Name + " on " + sorter + " to resolve to a List because we think it's a collapsed "
										 + " attribute");
								}
							}
							else
							{
								CreateWarningIfConformanceLevelIsNotAllowed(relationship);
								relationships.Add(CreateAttributeBridge(relationship, (BeanProperty)o, sorter, currentMessagePart));
							}
						}
					}
					else
					{
						if (IsIndicator(relationship))
						{
							CreateWarningIfConformanceLevelIsNotAllowed(relationship);
							relationships.Add(CreateIndicatorAssociationBridge(relationship, sorter, interaction, context, (BeanProperty)o));
						}
						else
						{
							if (o == null)
							{
								CreateWarningIfPropertyIsNotMapped(sorter, currentMessagePart, relationship);
								if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY || relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
									.POPULATED)
								{
									relationships.Add(new AssociationBridgeImpl(relationship, CreateNullPartBridge(relationship, interaction)));
								}
							}
							else
							{
								CreateWarningIfConformanceLevelIsNotAllowed(relationship);
								relationships.Add(CreateAssociationBridge(relationship, sorter, interaction, currentMessagePart, context));
							}
						}
					}
				}
			}
			if (sorter.GetPropertyName() == null || sorter.GetPropertyName().Equals("null"))
			{
				System.Console.Out.WriteLine("not correct");
			}
			return new PartBridgeImpl(sorter.GetPropertyName(), sorter.GetBean(), currentMessagePart.GetName(), relationships, context
				.IsCollapsed(), nullPart);
		}

		private void CreateWarningIfConformanceLevelIsNotAllowed(Relationship relationship)
		{
			if (ConformanceLevelUtil.IsIgnoredNotAllowed() && relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.IGNORED)
			{
				this.log.Debug(System.String.Format(relationship.Association ? ConformanceLevelUtil.ASSOCIATION_IS_IGNORED_AND_CAN_NOT_BE_USED
					 : ConformanceLevelUtil.ATTRIBUTE_IS_IGNORED_AND_CAN_NOT_BE_USED, relationship.Name));
			}
			else
			{
				if (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.NOT_ALLOWED)
				{
					this.log.Debug(System.String.Format(relationship.Association ? ConformanceLevelUtil.ASSOCIATION_IS_NOT_ALLOWED : ConformanceLevelUtil
						.ATTRIBUTE_IS_NOT_ALLOWED, relationship.Name));
				}
			}
		}

		private IndicatorAssociationBridgeImpl CreateIndicatorAssociationBridge(Relationship relationship, RelationshipSorter sorter
			, Interaction interaction, BridgeContext context, BeanProperty beanProperty)
		{
			PartBridge partBridge = null;
			if (beanProperty == null || beanProperty.Get() == null)
			{
				partBridge = CreateNullPartBridge(relationship, interaction);
			}
			else
			{
				partBridge = CreatePartBridge(sorter, interaction, GetMessagePart(interaction, relationship, null), new BridgeContext(), 
					false);
			}
			return new IndicatorAssociationBridgeImpl(relationship, partBridge, beanProperty);
		}

		private bool IsIndicator(Relationship relationship)
		{
			bool result = (!relationship.Mandatory && !relationship.Choice && relationship.Type != null && !relationship.Structural);
			if (result)
			{
				string type = relationship.Type;
				MessagePart messagePart = this.service.GetMessagePart(this.version, type);
				foreach (Relationship innerRelationship in messagePart.Relationships)
				{
					if (!innerRelationship.Fixed)
					{
						result = false;
						break;
					}
				}
			}
			return result;
		}

		private void CreateWarningIfPropertyIsNotMapped(RelationshipSorter sorter, MessagePartHolder currentMessagePart, Relationship
			 relationship)
		{
			if (sorter.GetBeanType() != null)
			{
				this.log.Debug("Relationship " + Describer.Describe(currentMessagePart, relationship) + " does not appear to be mapped to any property of "
					 + ClassUtils.GetShortClassName(sorter.GetBeanType()));
			}
		}

		private PartBridge CreateNullPartBridge(Relationship relationship, Interaction interaction)
		{
			RelationshipSorter sorter = RelationshipSorter.Create(relationship.Name, null);
			MessagePartHolder currentMessagePart = GetMessagePart(interaction, relationship, null);
			if (currentMessagePart != null)
			{
				return CreatePartBridge(sorter, interaction, currentMessagePart, new BridgeContext(), true);
			}
			else
			{
				return new PartBridgeImpl(relationship.Name, null, relationship.Type, CollUtils.EmptyList<BaseRelationshipBridge>(), false
					, true);
			}
		}

		private AssociationBridge CreateAssociationBridge(Relationship relationship, RelationshipSorter sorter, Interaction interaction
			, MessagePartHolder currentMessagePart, BridgeContext context)
		{
			if (sorter.IsCollapsedRelationship(relationship))
			{
				if (relationship.Cardinality.Multiple)
				{
					return CreateCollectionRelationshipBridge(relationship, sorter, interaction);
				}
				else
				{
					RelationshipSorter collapsedSorter = sorter.GetAsRelationshipSorter(relationship);
					PartBridge bridge = CreatePartBridge(collapsedSorter, interaction, GetMessagePart(interaction, relationship, collapsedSorter
						.GetBean()), new BridgeContext(true, context.GetOriginalIndex()), false);
					return new AssociationBridgeImpl(relationship, bridge);
				}
			}
			else
			{
				object o = sorter.Get(relationship);
				BeanProperty property = (BeanProperty)o;
				object value = property.Get();
				MessagePartHolder part = GetMessagePart(interaction, relationship, value);
				if (relationship.Cardinality.Multiple && value is IEnumerable)
				{
					this.log.Debug("Association " + Describer.Describe(currentMessagePart, relationship) + " maps to collection property " + 
						Describer.Describe(sorter.GetBeanType(), property));
					return CreateCollectionOfCompositeBeanBridges(property.Name, relationship, (IEnumerable)value, interaction);
				}
				else
				{
					if (context.IsIndexed() && property.Collection)
					{
						this.log.Debug("Association " + Describer.Describe(currentMessagePart, relationship) + " maps to index " + context.GetIndex
							() + " of collection property " + Describer.Describe(sorter.GetBeanType(), property));
						object elementValue = ListElementUtil.GetElement(value, context.GetIndex());
						// use the indexed object's part instead
						part = GetMessagePart(interaction, relationship, elementValue);
						return new AssociationBridgeImpl(relationship, CreatePartBridgeFromBean(property.Name + "[" + context.GetIndex() + "]", elementValue
							, interaction, part));
					}
					else
					{
						this.log.Debug("Association " + Describer.Describe(currentMessagePart, relationship) + " maps to property " + Describer.Describe
							(sorter.GetBeanType(), property));
						// Bug 13050 - should handle a single cardinality relationship if mapped to a collection
						if (ListElementUtil.IsCollection(value))
						{
							value = ListElementUtil.IsEmpty(value) ? null : ListElementUtil.GetElement(value, 0);
						}
						return new AssociationBridgeImpl(relationship, CreatePartBridgeFromBean(property.Name, value, interaction, part));
					}
				}
			}
		}

		private AssociationBridge CreateCollectionRelationshipBridge(Relationship relationship, RelationshipSorter sorter, Interaction
			 interaction)
		{
			RelationshipSorter association = sorter.GetAsRelationshipSorter(relationship);
			List<PartBridge> list = new List<PartBridge>();
			int length = association.GetSingleCollapsedPropertySize();
			for (int i = 0; i < length; i++)
			{
				list.Add(CreatePartBridge(association, interaction, GetMessagePart(interaction, relationship, null), new BridgeContext(true
					, i), false));
			}
			// bug 13240 - if empty collection and pop/mand, add a placeholder bridge - this will output a nullflavor element, and a warning for mandatory
			if (list.IsEmpty() && (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED || relationship
				.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY))
			{
				list.Add(CreatePartBridgeFromBean(string.Empty, null, interaction, GetMessagePart(interaction, relationship, null)));
			}
			return new AssociationBridgeImpl(relationship, list);
		}

		protected virtual BaseRelationshipBridge CreateAttributeBridge(Relationship relationship, BeanProperty property, RelationshipSorter
			 sorter, MessagePartHolder currentMessagePart)
		{
			this.log.Debug("Attribute " + Describer.Describe(currentMessagePart, relationship) + " maps to property " + Describer.Describe
				(sorter.GetBeanType(), property));
			return new AttributeBridgeImpl(relationship, property);
		}

		private AssociationBridge CreateCollectionOfCompositeBeanBridges(string propertyName, Relationship relationship, IEnumerable
			 value, Interaction interaction)
		{
			IList<PartBridge> list = new List<PartBridge>();
			foreach (object @object in value)
			{
				list.Add(CreatePartBridgeFromBean(propertyName, @object, interaction, GetMessagePart(interaction, relationship, value)));
			}
			// bug 13240 - if empty collection and pop/mand, add a placeholder bridge - this will output a nullflavor element, and a warning for mandatory
			if (list.IsEmpty() && (relationship.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.POPULATED || relationship
				.Conformance == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY))
			{
				list.Add(CreatePartBridgeFromBean(propertyName, null, interaction, GetMessagePart(interaction, relationship, value)));
			}
			return new AssociationBridgeImpl(relationship, list);
		}

		private MessagePartHolder GetMessagePart(Interaction interaction, Relationship relationship, object value)
		{
			string typeName = relationship.Type;
			if (relationship.TemplateRelationship)
			{
				Argument argument = interaction.GetArgumentByTemplateParameterName(relationship.TemplateParameterName);
				if (argument.Choice)
				{
					Ca.Infoway.Messagebuilder.Xml.Predicate<Relationship> predicate = ChoiceSupport.ChoiceOptionTypePredicate(GetTypes(value)
						);
					Relationship option = argument.FindChoiceOption(predicate);
					if (option != null)
					{
						typeName = option.Type;
					}
					else
					{
						// couldn't find a choice type to use (most likely, value is null)
						// can't leave typeName as null, so just use first choice type from argument
						typeName = argument.Choices[0].Type;
					}
				}
				else
				{
					typeName = argument.Name;
				}
			}
			else
			{
				if (relationship.Choice)
				{
					Relationship option = relationship.FindChoiceOption(ChoiceSupport.ChoiceOptionTypePredicate(GetTypes(value)));
					if (option != null)
					{
						typeName = option.Type;
					}
				}
			}
			return BuildMessagePartHolder(relationship, typeName, interaction);
		}

		private MessagePartHolder BuildMessagePartHolder(Relationship relationship, string typeName, Interaction interaction)
		{
			TypeName start = new TypeName(GetActualType(interaction, relationship));
			TypeName end = new TypeName(typeName);
			// Sigh. Missing some template info on choices in Location messages within the NFLD messageset.
			if (RequiresNewfoundlandHack(relationship))
			{
				start = end;
			}
			IList<TypeName> typeHierarchy = new PathBuilder(this.service, this.version).FindPathTo(start, end);
			return new MessagePartHolder(this.service, this.version, typeName, typeHierarchy);
		}

		private string GetActualType(Interaction interaction, Relationship relationship)
		{
			string typeName = relationship.Type;
			if (relationship.TemplateRelationship)
			{
				Argument argument = interaction.GetArgumentByTemplateParameterName(relationship.TemplateParameterName);
				typeName = argument.Name;
			}
			return typeName;
		}

		private bool RequiresNewfoundlandHack(Relationship relationship)
		{
			return IsNewfoundland(this.version) && relationship.Choice && relationship.Type == null;
		}

		private bool IsNewfoundland(VersionNumber version)
		{
			// this version is not currently supported by MB and is not in the SpecificationVersion enum
			// TODO - TM - NEWFOUNDLAND TEST HACK
			return version != null && StringUtils.Equals(version.VersionLiteral, "NEWFOUNDLAND");
		}

		private string[] GetTypes(object value)
		{
			Type c = value == null ? null : value.GetType();
			if (c != null && c.IsAnnotationPresent(typeof(Hl7PartTypeMappingAttribute)))
			{
				return c.GetAnnotation<Hl7PartTypeMappingAttribute>().Value;
			}
			else
			{
				return new string[0];
			}
		}

		private MessagePartHolder GetMessagePart(Interaction interaction)
		{
			return new MessagePartHolder(this.service, this.version, interaction.SuperTypeName);
		}

		public virtual Interaction GetInteraction(IInteraction tealBean)
		{
			MessageTypeKey type = MessageBeanRegistry.GetInstance().GetMessageTypeKey(this.version, tealBean);
			return this.service.GetInteraction(this.version, type.GetMessageId());
		}
	}
}
