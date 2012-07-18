using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class RelationshipFormat
	{
		private readonly string traversalName;

		private readonly string type;

		private readonly Argument argument;

		public RelationshipFormat(string traversalName, string type)
		{
			this.traversalName = traversalName;
			this.type = type;
			this.argument = null;
		}

		public RelationshipFormat(string traversalName, string type, Argument argument)
		{
			this.traversalName = traversalName;
			this.type = type;
			this.argument = argument;
		}

		public virtual string GetTraversalName()
		{
			return this.traversalName;
		}

		public virtual string GetXmlElementName()
		{
			return this.traversalName;
		}

		public virtual string Type
		{
			get
			{
				return this.type;
			}
		}

		internal static Ca.Infoway.Messagebuilder.Marshalling.RelationshipFormat GetRelationshipFormat(ConversionContext context, 
			Relationship relationship)
		{
			if (relationship.TemplateRelationship)
			{
				return context.ResolveTemplateType(relationship);
			}
			else
			{
				return new Ca.Infoway.Messagebuilder.Marshalling.RelationshipFormat(relationship.Name, relationship.Type);
			}
		}

		public virtual Argument GetArgument()
		{
			return this.argument;
		}
	}
}
