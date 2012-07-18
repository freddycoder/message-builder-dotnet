using System;
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class ConversionContext
	{
		private readonly MessageDefinitionService service;

		private readonly VersionNumber version;

		private readonly Interaction interaction;

		private readonly TimeZone dateTimeTimeZone;

		private readonly TimeZone dateTimeZone;

		internal ConversionContext(MessageDefinitionService service, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			, string messageId)
		{
			this.service = service;
			this.version = version;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.dateTimeZone = dateTimeZone;
			this.interaction = service.GetInteraction(version, messageId);
		}

		public virtual MessageDefinitionService GetService()
		{
			return this.service;
		}

		public virtual VersionNumber GetVersion()
		{
			return this.version;
		}

		public virtual TimeZone GetDateTimeTimeZone()
		{
			return dateTimeTimeZone;
		}

		public virtual TimeZone GetDateTimeZone()
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
						// BCH: TODO: this looks suspicious.  Investigate later...
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
