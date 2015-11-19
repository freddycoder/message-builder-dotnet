using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MessagePartHolder
	{
		private readonly MessagePart messagePart;

		private readonly List<Relationship> allRelationships;

		internal MessagePartHolder(MessageDefinitionService service, VersionNumber version, string superTypeName) : this(service, 
			version, superTypeName, Arrays.AsList(new TypeName(superTypeName)))
		{
		}

		internal MessagePartHolder(MessageDefinitionService service, VersionNumber version, string typeName, IList<TypeName> typeHierarchy
			)
		{
			// intentionally specified as an ArrayList for translation purposes
			this.messagePart = service.GetMessagePart(version, typeName);
			this.allRelationships = MergeRelationships(service, version, typeHierarchy);
			if (typeHierarchy.Count > 1)
			{
				this.allRelationships.Sort();
			}
		}

		internal MessagePartHolder(MessagePart partForTestOnly)
		{
			// tests only
			this.messagePart = partForTestOnly;
			this.allRelationships = new List<Relationship>(partForTestOnly.Relationships);
		}

		private List<Relationship> MergeRelationships(MessageDefinitionService service, VersionNumber version, IList<TypeName> typeHierarchy
			)
		{
			List<Relationship> mergedRelationships = new List<Relationship>();
			foreach (TypeName type in typeHierarchy)
			{
				MessagePart part = service.GetMessagePart(version, type.Name);
				if (part != null)
				{
					mergedRelationships.AddAll(part.Relationships);
				}
			}
			return mergedRelationships;
		}

		internal virtual string GetName()
		{
			return this.messagePart.Name;
		}

		internal virtual IList<Relationship> GetRelationships()
		{
			return this.allRelationships;
		}
	}
}
