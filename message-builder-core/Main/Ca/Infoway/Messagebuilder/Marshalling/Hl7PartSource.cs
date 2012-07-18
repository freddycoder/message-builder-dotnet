using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class Hl7PartSource : Hl7Source
	{
		private readonly XmlElement currentElement;

		private readonly string hl7Type;

		private readonly Hl7MessageSource hl7InteractionSource;

		private readonly MessagePart messagePart;

		private readonly MessagePart originalMessagePart;

		public Hl7PartSource(Hl7MessageSource hl7InteractionSource, string hl7Type, XmlElement currentElement, string originalHl7Type
			)
		{
			this.hl7InteractionSource = hl7InteractionSource;
			this.hl7Type = hl7Type;
			this.currentElement = currentElement;
			this.messagePart = InitMessagePart(hl7Type);
			this.originalMessagePart = originalHl7Type == null ? this.messagePart : InitMessagePart(originalHl7Type);
		}

		public virtual MessageDefinitionService GetService()
		{
			return this.hl7InteractionSource.GetService();
		}

		private MessagePart InitMessagePart(string type)
		{
			MessagePart result = GetService().GetMessagePart(GetVersion(), type);
			if (result == null)
			{
				throw new MarshallingException("No message part " + type + " for version " + GetVersion());
			}
			else
			{
				return result;
			}
		}

		public virtual XmlElement GetCurrentElement()
		{
			return this.currentElement;
		}

		public virtual VersionNumber GetVersion()
		{
			return this.hl7InteractionSource.GetVersion();
		}

		public virtual TimeZone GetDateTimeZone()
		{
			return this.hl7InteractionSource.GetDateTimeZone();
		}

		public virtual TimeZone GetDateTimeTimeZone()
		{
			return this.hl7InteractionSource.GetDateTimeTimeZone();
		}

		public virtual string Type
		{
			get
			{
				return this.hl7Type;
			}
		}

		public virtual XmlToModelResult GetResult()
		{
			return this.hl7InteractionSource.GetResult();
		}

		public virtual Ca.Infoway.Messagebuilder.Marshalling.Hl7PartSource CreatePartSource(Relationship relationship, XmlElement
			 currentElement)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.Hl7PartSource(this.hl7InteractionSource, ResolveType(relationship, currentElement
				), currentElement, ResolveTopmostType(relationship, currentElement));
		}

		private string ResolveType(Relationship relationship, XmlElement currentElement)
		{
			return this.hl7InteractionSource.GetConversionContext().ResolveType(relationship, NodeUtil.GetLocalOrTagName(currentElement
				));
		}

		private string ResolveTopmostType(Relationship relationship, XmlElement currentElement)
		{
			return this.hl7InteractionSource.GetConversionContext().ResolveTopmostType(relationship, NodeUtil.GetLocalOrTagName(currentElement
				));
		}

		public virtual Relationship GetRelationship(string name)
		{
			Relationship result = this.messagePart.GetRelationship(name, this.hl7InteractionSource.GetInteraction());
			if (result == null && !StringUtils.Equals(this.messagePart.Name, this.originalMessagePart.Name))
			{
				result = GetNestedRelationship(this.originalMessagePart, name);
			}
			return result;
		}

		private Relationship GetNestedRelationship(MessagePart part, string name)
		{
			Relationship relationship = part.GetRelationship(name, this.hl7InteractionSource.GetInteraction());
			if (relationship == null)
			{
				foreach (string childType in part.SpecializationChilds)
				{
					if (TypeIsAssignable(childType))
					{
						MessagePart childPart = GetService().GetMessagePart(GetVersion(), childType);
						relationship = GetNestedRelationship(childPart, name);
						if (relationship != null)
						{
							break;
						}
					}
				}
			}
			return relationship;
		}

		/// <summary>Is our type an implementation of the given child type?</summary>
		/// <param name="childType"></param>
		/// <returns>whether our type is an implementation of the given child type</returns>
		private bool TypeIsAssignable(string childType)
		{
			bool result = false;
			MessagePart childPart = GetService().GetMessagePart(GetVersion(), childType);
			if (!childPart.Abstract)
			{
				result = StringUtils.Equals(Type, childPart.Name);
			}
			else
			{
				foreach (string specializationChild in childPart.SpecializationChilds)
				{
					if (TypeIsAssignable(specializationChild))
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		public virtual string GetMessagePartName()
		{
			return this.messagePart.Name;
		}

		public virtual Interaction GetInteraction()
		{
			return this.hl7InteractionSource.GetConversionContext().GetInteraction();
		}
	}
}
