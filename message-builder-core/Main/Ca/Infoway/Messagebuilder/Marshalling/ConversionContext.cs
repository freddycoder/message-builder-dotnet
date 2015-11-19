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
using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class ConversionContext
	{
		private readonly MessageDefinitionService service;

		private readonly VersionNumber version;

		private readonly Interaction interaction;

		private readonly TimeZoneInfo dateTimeTimeZone;

		private readonly TimeZoneInfo dateTimeZone;

		internal ConversionContext(MessageDefinitionService service, VersionNumber version, TimeZoneInfo dateTimeZone, TimeZoneInfo
			 dateTimeTimeZone, string messageId, ICollection<string> templateIdsFromDocument, Hl7Errors errors)
		{
			this.service = service;
			this.version = version;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.dateTimeZone = dateTimeZone;
			this.interaction = DetermineInteraction(messageId, templateIdsFromDocument, version, service, errors);
		}

		public virtual MessageDefinitionService GetService()
		{
			return this.service;
		}

		public virtual VersionNumber GetVersion()
		{
			return this.version;
		}

		public virtual TimeZoneInfo GetDateTimeTimeZone()
		{
			return dateTimeTimeZone;
		}

		public virtual TimeZoneInfo GetDateTimeZone()
		{
			return dateTimeZone;
		}

		public virtual MessagePart GetMessagePart(string type)
		{
			return this.service.GetMessagePart(this.version, type);
		}

		public virtual MessagePart GetMessagePartOfRelationship(Relationship relationship)
		{
			return this.service.GetMessagePart(this.version, relationship.Type);
		}

		public virtual Interaction GetInteraction()
		{
			return this.interaction;
		}

		private Interaction DetermineInteraction(string messageId, ICollection<string> templateIdsFromDocument, VersionNumber version
			, MessageDefinitionService service, Hl7Errors errors)
		{
			Interaction result = null;
			if (service.IsCda(version))
			{
				result = ObtainCdaInteraction(templateIdsFromDocument, version, service, errors);
			}
			else
			{
				result = ObtainHl7v3Interaction(messageId, version, service, errors);
			}
			return result;
		}

		private Interaction ObtainHl7v3Interaction(string messageId, VersionNumber version, MessageDefinitionService service, Hl7Errors
			 errors)
		{
			Interaction result = service.GetInteraction(version, messageId);
			if (result == null)
			{
				string message = System.String.Format("The interaction {0} for version {1} could not be found (and is possibly not supported). Please ensure an appropriate version code has been provided."
					, messageId, version);
				errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.UNSUPPORTED_INTERACTION, message, (string)null));
			}
			return result;
		}

		private Interaction ObtainCdaInteraction(ICollection<string> templateIdsFromDocument, VersionNumber version, MessageDefinitionService
			 service, Hl7Errors errors)
		{
			Interaction baseModel = null;
			Interaction firstInteractionMatch = null;
			ICollection<string> parentTemplateIds = new HashSet<string>();
			IDictionary<string, Interaction> candidateInteractions = new Dictionary<string, Interaction>();
			foreach (Interaction matchingInteraction in service.GetAllInteractions(version))
			{
				string templateId = matchingInteraction.TemplateId;
				if (templateIdsFromDocument.Contains(templateId))
				{
					if (firstInteractionMatch == null)
					{
						// first matching interaction will not necessarily be the first templateId in the document
						firstInteractionMatch = matchingInteraction;
					}
					candidateInteractions[templateId] = matchingInteraction;
					string parentTemplateId = matchingInteraction.ParentTemplateId;
					if (parentTemplateId != null)
					{
						parentTemplateIds.Add(parentTemplateId);
					}
				}
				else
				{
					if (templateId == null)
					{
						baseModel = matchingInteraction;
					}
				}
			}
			ICollection<string> keysToRemove = new HashSet<string>();
			for (IEnumerator<KeyValuePair<string, Interaction>> iterator = candidateInteractions.GetEnumerator(); iterator.MoveNext()
				; )
			{
				KeyValuePair<string, Interaction> entry = iterator.Current;
				if (parentTemplateIds.Contains(entry.Key))
				{
					keysToRemove.Add(entry.Key);
				}
			}
			foreach (string key in keysToRemove)
			{
				candidateInteractions.Remove(key);
			}
			return DetermineSuitableInteraction(candidateInteractions, baseModel, firstInteractionMatch, version, errors);
		}

		private Interaction DetermineSuitableInteraction(IDictionary<string, Interaction> candidateInteractions, Interaction baseModel
			, Interaction firstInteractionMatch, VersionNumber version, Hl7Errors errors)
		{
			Interaction result = null;
			if (candidateInteractions.IsEmpty())
			{
				// use base model; there will be an error if the base model was not found
				result = baseModel;
				if (baseModel == null)
				{
					string versionLiteral = version == null ? "(none provided)" : version.VersionLiteral;
					string message = System.String.Format("No document model could be identified based on the supplied templateIds, and no base model could be found. Please ensure an appropriate version code has been provided. (version={0})"
						, versionLiteral, result.TemplateId, result.Name);
					errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, ErrorLevel.ERROR, message, (string)null));
				}
			}
			else
			{
				if (candidateInteractions.Count == 1)
				{
					// this should be the normal case
					IEnumerator<Interaction> iterator = candidateInteractions.Values.GetEnumerator();
					result = iterator.MoveNext() ? iterator.Current : null;
				}
				else
				{
					//For .NET translation						
					// more than one interaction matched; error, and use "first" matching interaction
					result = firstInteractionMatch;
					string message = System.String.Format("Unable to determine the most suitable templateId to use. A suitable templateId has been arbitrarily chosen: {0} ({1})"
						, result.TemplateId, result.Name);
					errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.INTERNAL_ERROR, ErrorLevel.WARNING, message, (string)null));
				}
			}
			if (result != null)
			{
				string item = ((result == baseModel) ? "the base model " : "templateId ");
				string templateId = ((result == baseModel) ? string.Empty : result.TemplateId);
				string message = System.String.Format("Document being parsed using {0}{1} ({2})", item, templateId, result.Name);
				errors.AddHl7Error(new Hl7Error(Hl7ErrorCode.CDA_TEMPLATE_CHOSEN, ErrorLevel.INFO, message, (string)null));
			}
			return result;
		}

		public virtual string ResolveType(Relationship relationship, string selectedElementName)
		{
			string resolvedType;
			if (relationship.TemplateRelationship)
			{
				resolvedType = ResolveTemplateType(relationship.TemplateParameterName, selectedElementName, false);
			}
			else
			{
				if (relationship.Choice)
				{
					resolvedType = ResolveChoiceType(relationship, selectedElementName);
				}
				else
				{
					resolvedType = relationship.Type;
				}
			}
			return resolvedType;
		}

		public virtual string ResolveTopmostType(Relationship relationship, string selectedElementName)
		{
			string resolvedType;
			if (relationship.TemplateRelationship)
			{
				resolvedType = ResolveTemplateType(relationship.TemplateParameterName, selectedElementName, true);
			}
			else
			{
				resolvedType = relationship.Type;
			}
			return resolvedType;
		}

		private string ResolveTemplateType(string templateName, string elementName, bool topmostOnly)
		{
			RelationshipFormat format = ResolveTemplateType(GetInteraction().Arguments, templateName);
			if (format == null)
			{
				throw new MarshallingException("Could not resolve Hl7 template information for template " + templateName);
			}
			else
			{
				if (!topmostOnly && format.GetArgument().Choice)
				{
					Relationship option = format.GetArgument().FindChoiceOption(ChoiceSupport.ChoiceOptionNamePredicate(elementName));
					if (option == null)
					{
						throw new MarshallingException("Could not resolve Hl7 template choice information for template " + templateName + " and element name "
							 + elementName);
					}
					else
					{
						return option.Type;
					}
				}
				else
				{
					return format.Type;
				}
			}
		}

		internal virtual RelationshipFormat ResolveTemplateType(Relationship relationship)
		{
			RelationshipFormat result = ResolveTemplateType(GetInteraction().Arguments, relationship.TemplateParameterName);
			if (result == null)
			{
				throw new MarshallingException("Could not resolve Hl7 type for template " + relationship.TemplateParameterName);
			}
			else
			{
				return result;
			}
		}

		internal virtual string ResolveChoiceType(Relationship relationship, string selectedElementName)
		{
			return relationship.FindChoiceOption(ChoiceSupport.ChoiceOptionNamePredicate(selectedElementName)).Type;
		}

		private RelationshipFormat ResolveTemplateType(IList<Argument> arguments, string templateName)
		{
			RelationshipFormat templateFormatInfo = null;
			foreach (Argument argument in arguments)
			{
				if (StringUtils.Equals(argument.TemplateParameterName, templateName))
				{
					templateFormatInfo = new RelationshipFormat(argument.TraversalName, argument.Name, argument);
				}
				else
				{
					if (argument.Name != null && argument.Name.EndsWith("." + templateName))
					{
						// BCH: this looks suspicious.  Investigate later...
						templateFormatInfo = new RelationshipFormat(argument.TraversalName, argument.Name, argument);
					}
					else
					{
						templateFormatInfo = ResolveTemplateType(argument.Arguments, templateName);
					}
				}
				if (templateFormatInfo != null)
				{
					break;
				}
			}
			return templateFormatInfo;
		}
	}
}
