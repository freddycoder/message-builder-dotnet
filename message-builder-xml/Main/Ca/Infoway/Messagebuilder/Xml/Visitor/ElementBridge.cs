using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Visitor;

namespace Ca.Infoway.Messagebuilder.Xml.Visitor
{
	internal class ElementBridge
	{
		private readonly XmlElement @base;

		private readonly MessagePart messagePart;

		private readonly Interaction interaction;

		public ElementBridge(XmlElement element, MessagePart messagePart, Interaction interaction)
		{
			this.@base = element;
			this.messagePart = messagePart;
			this.interaction = interaction;
		}

		public virtual IList<XmlElement> GetElements(Relationship relationship)
		{
			IList<XmlElement> result = new List<XmlElement>();
			ICollection<string> name = GetElementNames(relationship);
			foreach (XmlElement element in NodeUtil.ToElementList(this.@base))
			{
				string elementName = NodeUtil.GetLocalOrTagName(element);
				if (name.Contains(elementName))
				{
					result.Add(element);
				}
			}
			return result;
		}

		internal virtual string GetXmlName(Relationship relationship)
		{
			if (relationship.TemplateRelationship)
			{
				Argument argument = this.interaction.GetArgumentByTemplateParameterName(relationship.TemplateParameterName);
				// HACK: IW/RC: bug 11067: the data in the messageSets is incomplete.  Don't NPE, just carry on.
				return (argument == null) ? null : argument.TraversalName;
			}
			else
			{
				return relationship.Name;
			}
		}

		private ICollection<string> GetElementNames(Relationship relationship)
		{
			ICollection<string> result = new HashSet<string>();
			if (relationship.Choice)
			{
				foreach (Relationship choice in relationship.Choices)
				{
					result.AddAll(GetElementNames(choice));
				}
			}
			else
			{
				if (relationship.TemplateRelationship)
				{
					Argument argument = this.interaction.GetArgumentByTemplateParameterName(relationship.TemplateParameterName);
					if (argument != null && argument.Choice)
					{
						result.AddAll(GetElementNames(argument));
					}
					else
					{
						if (argument != null)
						{
							result.Add(argument.TraversalName);
						}
					}
				}
				else
				{
					result.Add(relationship.Name);
				}
			}
			return result;
		}

		private ICollection<string> GetElementNames(Argument argument)
		{
			ICollection<string> result = new HashSet<string>();
			foreach (Relationship relationship in argument.Choices)
			{
				result.AddAll(GetElementNames(relationship));
			}
			return result;
		}

		public virtual IList<RelationshipBridge> GetRelationships()
		{
			IList<RelationshipBridge> result = new List<RelationshipBridge>();
			// HACK: DGH: bug 11067: the data in the messageSets is incomplete.  Don't NPE, just carry on.
			if (this.messagePart != null)
			{
				foreach (Relationship relationship in this.messagePart.Relationships)
				{
					result.Add(new RelationshipBridge(this, relationship));
				}
			}
			return result;
		}

		internal virtual XmlElement GetBase()
		{
			return this.@base;
		}

		public virtual XmlAttribute GetAttribute(Relationship relationship)
		{
			if (relationship.Attribute && relationship.Structural)
			{
				return this.@base.GetAttributeNode(relationship.Name);
			}
			else
			{
				return null;
			}
		}
	}
}
