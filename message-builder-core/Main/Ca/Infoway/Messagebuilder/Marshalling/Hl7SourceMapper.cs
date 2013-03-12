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
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Util;
using ILOG.J2CsMapping.Text;
using log4net;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class Hl7SourceMapper
	{
		private readonly ILog log = log4net.LogManager.GetLogger(typeof(Hl7SourceMapper));

		public virtual XmlToModelResult MapToTeal(Hl7MessageSource hl7MessageSource)
		{
			if (hl7MessageSource.GetInteraction() != null)
			{
				Type messsageBeanType = MessageBeanRegistry.GetInstance().GetInteractionBeanType(hl7MessageSource.GetMessageTypeKey());
				object messageBean = BeanUtil.Instantiate<object>(messsageBeanType);
				BeanWrapper wrapper = new BeanWrapper(messageBean);
				MapToTeal(hl7MessageSource, wrapper, null);
				hl7MessageSource.GetResult().SetMessageObject(messageBean);
				CreateBeanPathOnErrorMessages(hl7MessageSource.GetResult(), messageBean);
			}
			return hl7MessageSource.GetResult();
		}

		private void CreateBeanPathOnErrorMessages(XmlToModelResult result, object messageBean)
		{
			// would be nice to push this entire method into XmlToModelResult, but BeanUtil not visible from XmlToModelResult
			// (and moving classes or adding a dependency causes all sorts of problems)
			foreach (Hl7Error hl7Error in result.GetHl7Errors())
			{
				string beanPath = BeanUtil.DescribeBeanPath(messageBean, hl7Error.GetPath());
				hl7Error.SetBeanPath(beanPath);
			}
		}

		internal virtual object MapPartSourceToTeal(Hl7PartSource source, Relationship relationship)
		{
			object bean = Instantiator.GetInstance().InstantiateMessagePartBean(source.GetVersion(), source.Type, source.GetInteraction
				());
			BeanWrapper wrapper = new BeanWrapper(bean);
			MapToTeal(source, wrapper, relationship);
			return bean;
		}

		private void MapToTeal(Hl7Source source, BeanWrapper wrapper, Relationship relationship)
		{
			MapNodeAttributesToTeal(source, wrapper, relationship);
			IList<XmlElement> elements = NodeUtil.ToElementList(source.GetCurrentElement());
			int length = elements.Count;
			for (int j = 0; j < length; j++)
			{
				XmlElement element = elements[j];
				string nodeName = NodeUtil.GetLocalOrTagName(element);
				IList<XmlNode> nodes = new List<XmlNode>();
				nodes.Add(element);
				while (j + 1 < length && IsSameElementName(element, elements[j + 1]))
				{
					nodes.Add(elements[++j]);
				}
				if (NamespaceUtil.IsHl7Node(element))
				{
					Process(wrapper, source, nodes, nodeName);
				}
			}
		}

		private bool IsSameElementName(XmlElement element, XmlElement nextElement)
		{
			return StringUtils.Equals(element.NamespaceURI, nextElement.NamespaceURI) && StringUtils.Equals(NodeUtil.GetLocalOrTagName
				(element), NodeUtil.GetLocalOrTagName(nextElement));
		}

		private void Process(BeanWrapper bean, Hl7Source source, IList<XmlNode> nodes, string traversalName)
		{
			Relationship relationship = source.GetRelationship(traversalName);
			try
			{
				if (relationship == null)
				{
					string message = "Can't find a relationship named : " + traversalName + " on messagePart named " + source.GetMessagePartName
						();
					if (MappingNotYetSupported(traversalName))
					{
						this.log.Info(message);
					}
					else
					{
						throw new MarshallingException(message);
					}
				}
				else
				{
					if (relationship.Attribute)
					{
						WriteAttribute(bean, source, nodes, relationship, traversalName);
					}
					else
					{
						if (IsIndicator(source, relationship))
						{
							WriteIndicator(bean, source, nodes, relationship, traversalName);
						}
						else
						{
							WriteAssociation(bean, source, nodes, relationship, traversalName);
						}
					}
				}
			}
			catch (XmlToModelTransformationException e)
			{
				throw new MarshallingException(e);
			}
		}

		private bool IsIndicator(Hl7Source source, Relationship relationship)
		{
			if (relationship.TemplateRelationship || relationship.Choice || relationship.Structural)
			{
				return false;
			}
			return IsFullyFixedType(relationship, source) && IsNotMandatory(relationship.Conformance);
		}

		private bool IsNotMandatory(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance)
		{
			return conformance != null && conformance != Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private void WriteIndicator(BeanWrapper bean, Hl7Source source, IList<XmlNode> nodes, Relationship relationship, string traversalName
			)
		{
			try
			{
				// if "false", as in the indicator element is absent, we will never actually get here :)
				// can't really parse a boolean here, but we need to check for null flavor
				NullFlavorHelper nullFlavorHelper = new NullFlavorHelper(relationship.Conformance, nodes.IsEmpty() ? null : nodes[0], new 
					XmlToModelResult(), true);
				NullFlavor nullFlavor = nullFlavorHelper.ParseNullNode();
				object value = (nullFlavor == null ? new BLImpl(!nodes.IsEmpty()) : new BLImpl((Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
					)nullFlavor));
				bean.Write(relationship, value);
			}
			catch (InvalidCastException e)
			{
				this.log.Info("Can't parse relationship name=" + relationship.Name + ", traversalName=" + traversalName + " [" + e.Message
					 + "]");
			}
		}

		[Obsolete]
		private bool MappingNotYetSupported(string traversalName)
		{
			if (traversalName == null)
			{
				return false;
			}
			else
			{
				return traversalName.EndsWith("realmCode");
			}
		}

		private void WriteAssociation(BeanWrapper beanWrapper, Hl7Source source, IList<XmlNode> nodes, Relationship relationship, 
			string traversalName)
		{
			this.log.Debug("Writing association: traversalName=" + traversalName + ", relationshipType=" + relationship.Type);
			// 1. collapsed relationship
			if (relationship.Cardinality.Single && beanWrapper.IsAssociationMappedToSameBean(relationship))
			{
				this.log.Debug("COLLAPSE RECURSE : " + traversalName + " as collapsed relationship to " + beanWrapper.GetWrappedType());
				BeanWrapper childBeanWrapper = beanWrapper.CreateSubWrapper(relationship);
				WriteSpecialAssociation(childBeanWrapper, source, nodes, relationship);
			}
			else
			{
				//1b. trivial collapsed relationship with cardinality change (e.g. "RecordId" collapsed into "Location criteria"
				if (relationship.Cardinality.Multiple && beanWrapper.IsAssociationMappedToSameBean(relationship) && IsTypeWithSingleNonFixedRelationship
					(relationship, source))
				{
					BeanWrapper childBeanWrapper = beanWrapper.CreateSubWrapper(relationship);
					foreach (XmlNode node in nodes)
					{
						WriteAssociation(childBeanWrapper, source, (XmlElement)node, relationship);
					}
				}
				else
				{
					// 2. initialized read-only association
					if (relationship.Cardinality.Single && beanWrapper.IsPreInitializedDelegate(relationship))
					{
						this.log.Debug("READ-ONLY ASSOCIATION: " + traversalName + " as collapsed relationship to " + beanWrapper.GetWrappedType(
							));
						BeanWrapper childBeanWrapper = new BeanWrapper(beanWrapper.GetInitializedReadOnlyAssociation(relationship));
						WriteSpecialAssociation(childBeanWrapper, source, nodes, relationship);
					}
					else
					{
						// 3. non-collapsed (including choice, specializationChild, and template type, handling for which is encapsulated in
						//			Source.createChildSource())
						if (relationship.TemplateRelationship || relationship.Choice || MessageBeanRegistry.GetInstance().IsMessagePartDefined(source
							.GetVersion(), relationship.Type))
						{
							IList<object> convertedBeans = new List<object>();
							foreach (XmlNode node in nodes)
							{
								XmlElement childNode = (XmlElement)node;
								Hl7PartSource childSource = source.CreatePartSource(relationship, childNode);
								this.log.Debug("RECURSE for node=" + source.GetCurrentElement().Name + " - relationship=" + relationship.Name + ", tarversalName="
									 + traversalName + ", of type: " + childSource.Type);
								object tealChild = MapPartSourceToTeal(childSource, relationship);
								convertedBeans.Add(tealChild);
							}
							if (relationship.Cardinality.Multiple)
							{
								this.log.Debug("WRITING MULTIPLE: " + beanWrapper.GetWrappedType() + " property with annotation=" + traversalName + " - values="
									 + convertedBeans);
								beanWrapper.Write(relationship, convertedBeans);
							}
							else
							{
								if (relationship.Cardinality.Single && convertedBeans.IsEmpty())
								{
									throw new MarshallingException("Why is this empty? : " + relationship.Name + " on " + source.Type);
								}
								else
								{
									if (relationship.Cardinality.Single && convertedBeans.Count == 1)
									{
										this.log.Debug("WRITING SINGLE: " + beanWrapper.GetWrappedType() + " property with annotation=" + traversalName + " - value="
											 + convertedBeans[0]);
										beanWrapper.Write(relationship, convertedBeans[0]);
									}
									else
									{
										throw new MarshallingException("Unexpected cardinality on : " + relationship.Name + " on " + source.Type);
									}
								}
							}
						}
						else
						{
							if (IsNotOptional(relationship.Conformance) && !IsFullyFixedType(relationship, source))
							{
								this.log.Info("IGNORING: HL7 type " + relationship.Type + " with traversalName=" + traversalName + "(" + Describer.Describe
									(source.GetMessagePartName(), relationship) + ") cannot be mapped to any teal bean");
							}
						}
					}
				}
			}
		}

		private bool IsTypeWithSingleNonFixedRelationship(Relationship relationship, Hl7Source source)
		{
			return IsTypeWithSpecificNumberOfNonFixedRelationships(relationship, source, 1);
		}

		private bool IsFullyFixedType(Relationship relationship, Hl7Source source)
		{
			return IsTypeWithSpecificNumberOfNonFixedRelationships(relationship, source, 0);
		}

		private bool IsTypeWithSpecificNumberOfNonFixedRelationships(Relationship relationship, Hl7Source source, int numberOfNonFixedRelationships
			)
		{
			MessagePart messagePart = source.GetService().GetMessagePart(source.GetVersion(), relationship.Type);
			if (messagePart == null)
			{
				throw new MarshallingException("Could not find a message part for " + relationship.Type);
			}
			else
			{
				int count = 0;
				foreach (Relationship r in messagePart.Relationships)
				{
					if (!r.Fixed)
					{
						count++;
					}
				}
				return count == numberOfNonFixedRelationships;
			}
		}

		private void WriteSpecialAssociation(BeanWrapper childBeanWrapper, Hl7Source source, IList<XmlNode> nodes, Relationship relationship
			)
		{
			if (nodes.Count == 1)
			{
				XmlElement childNode = (XmlElement)nodes[0];
				WriteAssociation(childBeanWrapper, source, childNode, relationship);
			}
			else
			{
				throw new MarshallingException("Expected a single cardinality element to have only one node: ");
			}
		}

		private void WriteAssociation(BeanWrapper childBeanWrapper, Hl7Source source, XmlElement element, Relationship relationship
			)
		{
			Hl7PartSource childSource = source.CreatePartSource(relationship, element);
			MapToTeal(childSource, childBeanWrapper, relationship);
		}

		private bool IsNotOptional(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance)
		{
			return conformance != null && conformance != Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private void WriteAttribute(BeanWrapper bean, Hl7Source source, IList<XmlNode> nodes, Relationship relationship, string traversalName
			)
		{
			if (relationship.Structural)
			{
				source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "Data found for relationship as an element but should have been an attribute. "
					 + (nodes.IsEmpty() ? ("(" + relationship.Name + ")") : XmlDescriber.DescribePath(nodes[0])), CollUtils.IsEmpty(nodes) ? 
					null : (XmlElement)nodes[0]));
			}
			string type = relationship.Type;
			ElementParser parser = ParserRegistry.GetInstance().Get(type);
			if (parser != null)
			{
				try
				{
					BareANY @object = parser.Parse(ParseContextImpl.Create(relationship, source.GetVersion(), source.GetDateTimeZone(), source
						.GetDateTimeTimeZone()), nodes, source.GetResult());
					if (relationship.HasFixedValue())
					{
						ValidateNonstructuralFixedValue(relationship, @object, source, nodes);
					}
					// fixed means nothing to write to bean
					if (!relationship.Fixed)
					{
						bean.Write(relationship, @object);
					}
				}
				catch (InvalidCastException e)
				{
					this.log.Info("Can't parse relationship name=" + relationship.Name + ", traversalName=" + traversalName + " [" + e.Message
						 + "]");
				}
			}
			else
			{
				source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "No parser for type \"" + type + "\". " + (nodes
					.IsEmpty() ? ("(" + relationship.Name + ")") : XmlDescriber.DescribePath(nodes[0])), CollUtils.IsEmpty(nodes) ? null : (
					XmlElement)nodes[0]));
			}
		}

		private void ValidateNonstructuralFixedValue(Relationship relationship, BareANY value, Hl7Source source, IList<XmlNode> nodes
			)
		{
			if (relationship.HasFixedValue())
			{
				bool valid = (value != null && value.BareValue != null);
				if (valid)
				{
					if ("BL".Equals(relationship.Type) && value is BL)
					{
						string valueAsString = ((BL)value).Value.ToString();
						valid = relationship.FixedValue.EqualsIgnoreCase(valueAsString);
					}
					else
					{
						if ("INT.POS".Equals(relationship.Type) && value is INT)
						{
							string valueAsString = ((INT)value).Value.ToString();
							valid = relationship.FixedValue.EqualsIgnoreCase(valueAsString);
						}
						else
						{
							if (relationship.CodedType && value is CD)
							{
								Code code = ((CD)value).Value;
								valid = (code.CodeValue != null && StringUtils.Equals(relationship.FixedValue, code.CodeValue));
							}
							else
							{
								source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "Non-structural fixed-value attribute '" + relationship
									.Name + "' was of unexpected type '" + relationship.Type + "'", CollUtils.IsEmpty(nodes) ? null : (XmlElement)nodes[0]));
							}
						}
					}
				}
				if (!valid)
				{
					source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED, "Fixed-value attribute '" + relationship
						.Name + "' must have value '" + relationship.FixedValue + "'", CollUtils.IsEmpty(nodes) ? null : (XmlElement)nodes[0]));
				}
			}
		}

		private void MapNodeAttributesToTeal(Hl7Source source, BeanWrapper wrapper, Relationship relationship)
		{
			XmlElement currentElement = source.GetCurrentElement();
			NullFlavorHelper nullFlavorHelper = new NullFlavorHelper(relationship != null ? relationship.Conformance : Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, currentElement, source.GetResult(), true);
			if (nullFlavorHelper.HasValidNullFlavorAttribute())
			{
				wrapper.WriteNullFlavor(source, relationship, nullFlavorHelper.ParseNullNode());
			}
			else
			{
				XmlAttributeCollection map = currentElement.Attributes;
				int length = map.Count;
				for (int i = 0; i < length; i++)
				{
					XmlNode attributeNode = map.Item(i);
					Relationship attributeRelationship = source.GetRelationship(NodeUtil.GetLocalOrTagName(attributeNode));
					if (!NamespaceUtil.IsHl7Node(attributeNode))
					{
					}
					else
					{
						// quietly ignore it
						if (attributeRelationship == null)
						{
							this.log.Info("Can't find NodeAttribute relationship named: " + attributeNode.Name);
						}
						else
						{
							if (attributeRelationship.HasFixedValue())
							{
								ValidateFixedValue(source, currentElement, (XmlAttribute)attributeNode, attributeRelationship);
							}
							wrapper.WriteNodeAttribute(attributeRelationship, attributeNode.Value, source.GetVersion());
						}
					}
					ValidateMandatoryAttributesExist(source, currentElement);
				}
			}
		}

		private void ValidateMandatoryAttributesExist(Hl7Source source, XmlElement element)
		{
			foreach (Relationship relationship in GetMessagePart(source).Relationships)
			{
				if (relationship.Structural && relationship.Mandatory && !element.HasAttribute(relationship.Name))
				{
					source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, System.String.Format("Attribute {0} missing ({1})"
						, relationship.Name, XmlDescriber.DescribeSingleElement(element)), element));
				}
			}
		}

		private MessagePart GetMessagePart(Hl7Source source)
		{
			if (source is Hl7MessageSource)
			{
				return source.GetService().GetMessagePart(source.GetVersion(), source.Type);
			}
			else
			{
				return source.GetService().GetMessagePart(source.GetVersion(), source.GetMessagePartName());
			}
		}

		private void ValidateFixedValue(Hl7Source source, XmlElement currentElement, XmlAttribute attributeNode, Relationship relationship
			)
		{
			ValidateFixedValue(source.GetResult(), currentElement, attributeNode, relationship);
		}

		private void ValidateFixedValue(XmlToModelResult result, XmlElement element, XmlAttribute attributeNode, Relationship relationship
			)
		{
			string value = attributeNode.Value;
			if (!StringUtils.Equals(value, relationship.FixedValue))
			{
				result.AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, System.String.Format("Invalid attribute value: expected \"{0}\" but was \"{1}\" ({2})"
					, relationship.FixedValue, value, XmlDescriber.DescribeSingleElement(element)), attributeNode));
			}
		}
	}
}
