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
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.CodeRegistry;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Marshalling.Polymorphism;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Schema;
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

		private PolymorphismHandler polymorphismHandler = new PolymorphismHandler();

		public virtual XmlToModelResult MapToTeal(Hl7MessageSource hl7MessageSource)
		{
			if (hl7MessageSource.GetInteraction() != null)
			{
				Type messageBeanType = MessageBeanRegistry.GetInstance().GetInteractionBeanType(hl7MessageSource.GetMessageTypeKey());
				object messageBean = BeanUtil.Instantiate<object>(messageBeanType);
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
			bool hasNullFlavor = MapNodeAttributesToTeal(source, wrapper, relationship);
			IList<XmlElement> elements = NodeUtil.ToElementList(source.GetCurrentElement());
			if (hasNullFlavor && elements.IsEmpty())
			{
				// don't bother processing/validating any further
				// however, if there are elements and the association has a nullFlavor, something weird is going on so keep processing
				return;
			}
			// 1) "elements" contains the xml-order of the current part's relationships - note that this can have duplicates at this point
			// 2) "source" contains the message part being processed - this is not exposed
			// 3) "source" contains the result bean where errors can be stored - this *is* exposed
			// 4) need to watch choice/template cases (including choices with supertypes)
			// relationship.getType() is 
			//		- choice type (if choice)
			//		- null (if template)
			//		- or the actual type
			// source.getMessagePartName() is
			//      - the choice option (if above was a choice)
			//      - the actual template type (if above was null)
			//      - or the actual type (which it is in all cases, really)
			IList<string> xmlElementNamesInProvidedOrder = new List<string>();
			List<Relationship> sortedRelationshipsMatchingUpToXmlElementNames = new List<Relationship>();
			IDictionary<string, string> resolvedRelationshipNames = new Dictionary<string, string>();
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
					Relationship xmlRelationship = source.GetRelationship(nodeName);
					if (xmlRelationship != null)
					{
						ValidateNamespace(element, xmlRelationship, source);
						// since we have a match we know that the xml name is correct; all we need the xmlRelationship for is sorting purposes
						// however, for choice and template relationships, there will be an apparent mismatch between relationship names 
						xmlElementNamesInProvidedOrder.Add(nodeName);
						sortedRelationshipsMatchingUpToXmlElementNames.Add(xmlRelationship);
						resolvedRelationshipNames[GenerateRelationshipKey(xmlRelationship)] = nodeName;
					}
					Process(wrapper, source, nodes, nodeName);
				}
			}
			ValidateElementOrder(source, xmlElementNamesInProvidedOrder, sortedRelationshipsMatchingUpToXmlElementNames, resolvedRelationshipNames
				);
			// only do this if relationship not null and relationship not a null flavor???
			ValidateMissingMandatoryNonStructuralRelationships(source, resolvedRelationshipNames);
		}

		private void ValidateNamespace(XmlNode node, Relationship xmlRelationship, Hl7Source source)
		{
			if (!NamespaceUtil.IsNamespaceCorrect(node, xmlRelationship))
			{
				string message = System.String.Format("Expected relationship {0}.{1} to have namespace {2} but was {3}", xmlRelationship.
					ParentType, xmlRelationship.Name, NamespaceUtil.GetExpectedNamespace(xmlRelationship), NamespaceUtil.GetActualNamespace(
					node));
				Hl7Error hl7Error = new Hl7Error(Hl7ErrorCode.UNEXPECTED_NAMESPACE, ErrorLevel.ERROR, message, node);
				source.GetResult().AddHl7Error(hl7Error);
			}
		}

		private void ValidateMissingMandatoryNonStructuralRelationships(Hl7Source source, IDictionary<string, string> resolvedRelationshipNames
			)
		{
			// compare xml provided elements with all known mandatory relationships (watch for nested)
			IList<Relationship> allRelationships = source.GetAllRelationships();
			foreach (Relationship relationship in allRelationships)
			{
				// ignore structural - this has been checked elsewhere (and isn't contained in the resolved relationships anyway)
				if (!relationship.Structural && relationship.Cardinality.Min > 0)
				{
					if (!resolvedRelationshipNames.ContainsKey(GenerateRelationshipKey(relationship)))
					{
						Hl7Error error = new Hl7Error(relationship.Association ? Hl7ErrorCode.MANDATORY_ASSOCIATION_NOT_PROVIDED : Hl7ErrorCode.MANDATORY_FIELD_NOT_PROVIDED
							, "Relationship '" + relationship.Name + "' has a minimum cardinality greater than zero, but no value was provided.", source
							.GetCurrentElement());
						source.GetResult().AddHl7Error(error);
						// check for missing fixed constraints
						ConstrainedDatatype constraints = source.GetService().GetConstraints(source.GetVersion(), relationship.ConstrainedType);
						if (constraints != null)
						{
							bool isTemplateId = constraints.Name.EndsWith("templateId");
							foreach (Relationship constraint in constraints.Relationships)
							{
								if (constraint.HasFixedValue())
								{
									string msg = System.String.Format("{0}.{1} property constrained to {2} but no value was provided.", relationship.Name, constraint
										.Name, constraint.FixedValue);
									Hl7ErrorCode errorCode = (isTemplateId ? Hl7ErrorCode.CDA_TEMPLATEID_FIXED_CONSTRAINT_MISSING : Hl7ErrorCode.CDA_FIXED_CONSTRAINT_MISSING
										);
									source.GetResult().AddHl7Error(new Hl7Error(errorCode, ErrorLevel.WARNING, msg, source.GetCurrentElement()));
								}
							}
						}
					}
				}
			}
		}

		private string GenerateRelationshipKey(Relationship xmlRelationship)
		{
			return xmlRelationship.ParentType + "." + xmlRelationship.Name;
		}

		private void ValidateElementOrder(Hl7Source source, IList<string> xmlElementNamesInProvidedOrder, IList<Relationship> sortedRelationshipsMatchingUpToXmlElementNames
			, IDictionary<string, string> resolvedRelationshipNames)
		{
			for (int i = 0; i < sortedRelationshipsMatchingUpToXmlElementNames.Count; i++)
			{
				Relationship rel = sortedRelationshipsMatchingUpToXmlElementNames[i];
				string name1 = xmlElementNamesInProvidedOrder[i];
				string name2 = resolvedRelationshipNames.SafeGet(GenerateRelationshipKey(rel));
				if (!StringUtils.Equals(name1, name2))
				{
					string message = "Elements appear to be out of expected order starting around '" + name1 + "'" + ". " + "Expected order to be: "
						 + ListNames(sortedRelationshipsMatchingUpToXmlElementNames, resolvedRelationshipNames);
					// would be nice to merge this error in at the correct place if new errors added by the call to process() within mapToTeal()
					source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, message, source.GetCurrentElement()));
					break;
				}
			}
		}

		private string ListNames(IList<Relationship> sortedRelationshipsMatchingUpToXmlElementNames, IDictionary<string, string> 
			resolvedRelationshipNames)
		{
			IEnumerator<Relationship> iterator = sortedRelationshipsMatchingUpToXmlElementNames.GetEnumerator();
			if (!iterator.MoveNext())
			{
				return "[]";
			}
			StringBuilder sb = new StringBuilder();
			sb.Append('[');
			for (; ; )
			{
				Relationship relationship = iterator.Current;
				sb.Append(resolvedRelationshipNames.SafeGet(GenerateRelationshipKey(relationship)));
				if (!iterator.MoveNext())
				{
					return sb.Append(']').ToString();
				}
				sb.Append(", ");
			}
		}

		private bool IsSameElementName(XmlElement element, XmlElement nextElement)
		{
			return StringUtils.Equals(element.NamespaceURI, nextElement.NamespaceURI) && StringUtils.Equals(NodeUtil.GetLocalOrTagName
				(element), NodeUtil.GetLocalOrTagName(nextElement));
		}

		private void Process(BeanWrapper bean, Hl7Source source, IList<XmlNode> nodes, string traversalName)
		{
			if ("realmCode".Equals(traversalName))
			{
				WriteRealmCode(bean, source, nodes, traversalName);
			}
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
						if (nodes == null || nodes.IsEmpty())
						{
							throw new MarshallingException(message);
						}
						else
						{
							source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, message, (XmlElement)nodes[0]));
						}
					}
				}
				else
				{
					if (relationship.Attribute)
					{
						// attribute cardinality checked at datatype level
						WriteAttribute(bean, source, nodes, relationship, traversalName);
					}
					else
					{
						// need to check association cardinality here
						ValidateAssociationCardinality(source, nodes, traversalName, relationship);
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
			catch (MarshallingException e)
			{
				// RM18422 - log an error rather than throwing an exception up the chain
				// this is a "known" exception that has been handled to some extent
				XmlElement element = nodes == null || nodes.IsEmpty() ? null : (XmlElement)nodes[0];
				source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, e.Message, element));
			}
			catch (Exception e)
			{
				// RM18422 - unexpected (and thus unhandled) exception; still, likely best to log it rather than kill entire process
				XmlElement element = nodes == null || nodes.IsEmpty() ? null : (XmlElement)nodes[0];
				source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Unexpected error: " + e.Message, element));
			}
		}

		private void ValidateAssociationCardinality(Hl7Source source, IList<XmlNode> nodes, string traversalName, Relationship relationship
			)
		{
			Cardinality cardinality = relationship.Cardinality;
			int numberOfAssociations = nodes.Count;
			if (cardinality != null && !cardinality.Contains(numberOfAssociations))
			{
				Hl7Error error = Hl7Error.CreateWrongNumberOfAssociationsError(traversalName, source.GetCurrentElement(), numberOfAssociations
					, cardinality);
				source.GetResult().AddHl7Error(error);
			}
		}

		private bool IsIndicator(Hl7Source source, Relationship relationship)
		{
			if (relationship.TemplateRelationship || relationship.Choice || relationship.Structural)
			{
				return false;
			}
			return IsFullyFixedType(relationship, source) && !ConformanceLevelUtil.IsMandatory(relationship);
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
				object value = (nullFlavor == null ? new BLImpl(!nodes.IsEmpty()) : new BLImpl(nullFlavor));
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
						// 3a. non-collapsed, multiple-cardinality choice or single-cardinality choice with node name same as choice name
						if (IsCdaChoice(nodes, relationship, source))
						{
							IList<object> convertedBeans = HandleCdaChoice(nodes, traversalName, relationship, source);
							if (relationship.Cardinality.Multiple)
							{
								this.log.Debug("Special choice handling: WRITING MULTIPLE-CARDINALITY CHOICE: " + beanWrapper.GetWrappedType() + " property with annotation="
									 + traversalName + " - values=" + convertedBeans);
								beanWrapper.Write(relationship, convertedBeans);
							}
							else
							{
								if (relationship.Cardinality.Single && convertedBeans.IsEmpty())
								{
									throw new MarshallingException("Special choice handling: Why is this empty? : " + relationship.Name + " on " + source.Type
										);
								}
								else
								{
									this.log.Debug("Special choice handling: WRITING SINGLE: " + beanWrapper.GetWrappedType() + " property with annotation=" 
										+ traversalName + " - value=" + convertedBeans[0]);
									// may need to ignore values beyond the first; an error will have been logged
									beanWrapper.Write(relationship, convertedBeans[0]);
								}
							}
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
										this.log.Debug("WRITING SINGLE: " + beanWrapper.GetWrappedType() + " property with annotation=" + traversalName + " - value="
											 + convertedBeans[0]);
										// may need to ignore values beyond the first; an error will have been logged
										beanWrapper.Write(relationship, convertedBeans[0]);
									}
								}
							}
							else
							{
								if (!ConformanceLevelUtil.IsOptional(relationship) && !IsFullyFixedType(relationship, source))
								{
									this.log.Info("IGNORING: HL7 type " + relationship.Type + " with traversalName=" + traversalName + "(" + Describer.Describe
										(source.GetMessagePartName(), relationship) + ") cannot be mapped to any teal bean");
								}
							}
						}
					}
				}
			}
		}

		private IList<object> HandleCdaChoice(IList<XmlNode> nodes, string traversalName, Relationship relationship, Hl7Source source
			)
		{
			IList<object> convertedBeans = new List<object>();
			foreach (XmlNode node in nodes)
			{
				XmlElement childNode = (XmlElement)node;
				int currentNodeDepth = XmlDescriber.GetDepth(childNode);
				int currentErrorCount = source.GetResult().GetHl7Errors().Count;
				IList<Relationship> allChoiceTypes = DetermineAllChoiceTypes(relationship.Choices);
				Hl7SourceMapperChoiceCandidate choiceCandidate = null;
				Relationship choiceCandidateRelationship = null;
				bool foundMultipleChoiceCandidates = false;
				foreach (Relationship choiceType in allChoiceTypes)
				{
					Hl7PartSource childSource = source.CreatePartSourceForSpecificType(relationship, childNode, choiceType.Type);
					this.log.Debug("RECURSE for node=" + source.GetCurrentElement().Name + " - relationship=" + relationship.Name + ", tarversalName="
						 + traversalName + ", of type: " + childSource.Type);
					// after creating tealChild for each choiceType
					// - store tealChild
					// - store all new errors, removing them from the main error container
					object tealChild = MapPartSourceToTeal(childSource, relationship);
					Hl7SourceMapperChoiceCandidate newChoiceCandidate = new Hl7SourceMapperChoiceCandidate(tealChild);
					int newErrorsCount = (source.GetResult().GetHl7Errors().Count - currentErrorCount);
					for (int i = 0; i < newErrorsCount; i++)
					{
						IList<Hl7Error> hl7Errors = source.GetResult().GetHl7Errors();
						Hl7Error removedError = hl7Errors[currentErrorCount];
						hl7Errors.RemoveAt(currentErrorCount);
						//.NET conversion
						newChoiceCandidate.AddError(removedError);
					}
					if (newChoiceCandidate.IsAcceptableChoiceCandidate(currentNodeDepth))
					{
						if (newChoiceCandidate.HasTemplateIdMatch(currentNodeDepth))
						{
							// we'll take the first one that has a template id match, even if we found other acceptable candidates
							choiceCandidate = newChoiceCandidate;
							choiceCandidateRelationship = choiceType;
							foundMultipleChoiceCandidates = false;
							break;
						}
						else
						{
							if (choiceCandidate == null || choiceCandidateRelationship.DefaultChoice)
							{
								// we have found our first match, or we are dumping the default choice in favor of a better match
								choiceCandidate = newChoiceCandidate;
								choiceCandidateRelationship = choiceType;
							}
							else
							{
								if (!choiceType.DefaultChoice)
								{
									foundMultipleChoiceCandidates = true;
								}
							}
						}
					}
				}
				// else newChoiceCandidate is a default, and we ignore it in favor of the non-default we previously found
				// error if no candidates found
				if (choiceCandidate == null)
				{
					source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.CDA_NO_ACCEPTABLE_CHOICE_OPTION, ErrorLevel.WARNING, "Could not determine an appropriate match for a choice element: "
						 + XmlDescriber.DescribePath(node), childNode));
				}
				else
				{
					// error if multiple candidates found (excluding the default; but still take the first acceptable candidate)
					if (foundMultipleChoiceCandidates)
					{
						source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.CDA_MULTIPLE_CHOICE_OPTIONS_FOUND, ErrorLevel.WARNING, "Multiple appropriate matches for a choice element found - choosing first one: "
							 + XmlDescriber.DescribePath(node), childNode));
					}
					convertedBeans.Add(choiceCandidate.GetParsedBean());
					source.GetResult().GetHl7Errors().AddAll(choiceCandidate.GetStoredErrors());
				}
			}
			return convertedBeans;
		}

		private bool IsCdaChoice(IList<XmlNode> nodes, Relationship relationship, Hl7Source source)
		{
			bool result = relationship.Choice;
			if (result)
			{
				// a multiple cardinality choice is automatically considered a "cda choice"
				result = relationship.Cardinality.Multiple;
			}
			// TM - all multiple-cardinality choices should now be a "CDA choice"
			//			if (!result && nodes.size() == 1) {
			//				// this is a "cda choice" if the element name matches the choice name *and* does not have a match in the choice options (including nested options)
			//				List<String> allOptionNames = relationship.getAllBottomMostOptionNames();
			//				String nodeName = nodes.get(0).getNodeName();
			//				result = StringUtils.equals(nodeName, relationship.getName()) && !allOptionNames.contains(nodeName);
			//			}
			return result;
		}

		private IList<Relationship> DetermineAllChoiceTypes(IList<Relationship> choices)
		{
			List<Relationship> results = new List<Relationship>();
			foreach (Relationship rel in choices)
			{
				if (rel.Choices.IsEmpty())
				{
					results.Add(rel);
				}
				else
				{
					results.AddAll(DetermineAllChoiceTypes(rel.Choices));
				}
			}
			return results;
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
					if (!r.HasFixedValue())
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
			string type = DetermineType(nodes, relationship, source, source.GetResult());
			ElementParser parser = (source.IsR2() ? ParserR2Registry.GetInstance().Get(type) : ParserRegistry.GetInstance().Get(type)
				);
			if (parser != null)
			{
				try
				{
					ConstrainedDatatype constraints = source.GetService().GetConstraints(source.GetVersion(), relationship.ConstrainedType);
					ParseContextImpl context = new ParseContextImpl(relationship, constraints, source.GetVersion(), source.GetDateTimeZone(), 
						source.GetDateTimeTimeZone(), CodeTypeRegistry.GetInstance(), source.IsCda());
					BareANY @object = parser.Parse(context, nodes, source.GetResult());
					ChangeDatatypeIfNecessary(type, relationship, @object);
					if (relationship.HasFixedValue())
					{
						ValidateNonstructuralFixedValue(relationship, @object, source, nodes);
					}
					else
					{
						// fixed means nothing to write to bean
						bean.Write(relationship, @object);
					}
				}
				catch (InvalidCastException e)
				{
					source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "Can't parse relationship name=" + relationship.
						Name + ", traversalName=" + traversalName + " [" + e.Message + "]", CollUtils.IsEmpty(nodes) ? null : (XmlElement)nodes[
						0]));
				}
			}
			else
			{
				source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, "No parser for type \"" + type + "\". " + (nodes
					.IsEmpty() ? ("(" + relationship.Name + ")") : XmlDescriber.DescribePath(nodes[0])), CollUtils.IsEmpty(nodes) ? null : (
					XmlElement)nodes[0]));
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private void WriteRealmCode(BeanWrapper bean, Hl7Source source, IList<XmlNode> nodes, string traversalName)
		{
			XPathHelper xPathHelper = new XPathHelper();
			foreach (XmlNode node in nodes)
			{
				try
				{
					string codeValue = xPathHelper.GetAttributeValue(node, "@code", null);
					if (codeValue != null)
					{
						bean.WriteRealmCode(RealmCodeHelper.LookupRealm(codeValue));
					}
				}
				catch (XPathException e)
				{
					throw new XmlToModelTransformationException("Exception encountered while parsing realmCode", e);
				}
			}
		}

		private void ChangeDatatypeIfNecessary(string type, Relationship relationship, BareANY @object)
		{
			// if the type parsed was different from the relationship type, preserve that info in the parsed object
			if (@object != null && !relationship.Type.Equals(type))
			{
				StandardDataType newDataType = StandardDataType.GetByTypeName(type);
				if (newDataType != null)
				{
					@object.DataType = newDataType;
				}
			}
		}

		private string DetermineType(IList<XmlNode> nodes, Relationship relationship, Hl7Source source, Hl7Errors errors)
		{
			string type = relationship.Type;
			if (nodes.Count >= 1)
			{
				string newType = ((XmlElement)nodes[0]).GetAttribute("type", XmlSchemas.SCHEMA_INSTANCE);
				type = this.polymorphismHandler.DetermineActualDataTypeFromXsiType(type, newType, source.IsCda(), !source.IsR2(), CreateErrorLogger
					((XmlElement)nodes[0], errors));
			}
			return type;
		}

		private ErrorLogger CreateErrorLogger(XmlElement element, Hl7Errors errors)
		{
			return new _ErrorLogger_682(errors, element);
		}

		private sealed class _ErrorLogger_682 : ErrorLogger
		{
			public _ErrorLogger_682(Hl7Errors errors, XmlElement element)
			{
				this.errors = errors;
				this.element = element;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, (XmlNode)element));
			}

			private readonly Hl7Errors errors;

			private readonly XmlElement element;
		}

		private void ValidateNonstructuralFixedValue(Relationship relationship, BareANY value, Hl7Source source, IList<XmlNode> nodes
			)
		{
			if (relationship.HasFixedValue())
			{
				bool valueProvided = (value != null && value.BareValue != null);
				bool valid = valueProvided || (!ConformanceLevelUtil.IsMandatory(relationship) && !ConformanceLevelUtil.IsPopulated(relationship
					));
				// optional and required fixed values do not have to provide a value, but if they do they must conform to specified value
				if (valueProvided)
				{
					if ("BL".Equals(relationship.Type) && value is BL)
					{
						string valueAsString = ((BL)value).Value.ToString();
						valid = relationship.FixedValue.EqualsIgnoreCase(valueAsString);
					}
					else
					{
						if ("ST".Equals(relationship.Type) && value is ST)
						{
							string valueAsString = ((ST)value).Value.ToString();
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
								if (relationship.CodedType)
								{
									if (source.IsR2())
									{
										if (GenericClassUtil.IsInstanceOfANY(value))
										{
											object value2 = GenericClassUtil.GetValueFromANY(value);
											Code code = value2 == null ? null : CodedTypeR2Helper.GetCode(value2);
											valid = (code != null && code.CodeValue != null && StringUtils.Equals(relationship.FixedValue, code.CodeValue));
										}
									}
									else
									{
										if (value is CD)
										{
											Code code = ((CD)value).Value;
											valid = (code.CodeValue != null && StringUtils.Equals(relationship.FixedValue, code.CodeValue));
										}
									}
								}
								else
								{
									source.GetResult().AddHl7Error(new Hl7Error(Hl7ErrorCode.SYNTAX_ERROR, "Non-structural fixed-value attribute '" + relationship
										.Name + "' was of unexpected type '" + relationship.Type + "'", CollUtils.IsEmpty(nodes) ? null : (XmlElement)nodes[0]));
								}
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

		private bool MapNodeAttributesToTeal(Hl7Source source, BeanWrapper wrapper, Relationship relationship)
		{
			XmlElement currentElement = source.GetCurrentElement();
			NullFlavorHelper nullFlavorHelper = new NullFlavorHelper(relationship != null ? relationship.Conformance : Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, currentElement, source.GetResult(), true);
			bool hasValidNullFlavorAttribute = nullFlavorHelper.HasValidNullFlavorAttribute();
			if (hasValidNullFlavorAttribute)
			{
				wrapper.WriteNullFlavor(source, relationship, nullFlavorHelper.ParseNullNode());
			}
			else
			{
				XmlAttributeCollection map = currentElement.Attributes;
				foreach (XmlNode attributeNode in new XmlNamedNodeMapIterable(map))
				{
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
							ValidateNamespace(attributeNode, attributeRelationship, source);
							if (attributeRelationship.HasFixedValue())
							{
								ValidateFixedValue(source, currentElement, (XmlAttribute)attributeNode, attributeRelationship);
							}
							wrapper.WriteNodeAttribute(attributeRelationship, attributeNode.Value, source.GetVersion(), source.IsR2());
						}
					}
					ValidateMandatoryAttributesExist(source, currentElement);
				}
			}
			return hasValidNullFlavorAttribute;
		}

		private void ValidateMandatoryAttributesExist(Hl7Source source, XmlElement element)
		{
			foreach (Relationship relationship in GetMessagePart(source).Relationships)
			{
				if (relationship.Structural && ConformanceLevelUtil.IsMandatory(relationship) && !element.HasAttribute(relationship.Name))
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
