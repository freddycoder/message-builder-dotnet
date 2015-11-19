using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class AssociationBridgeImpl : AssociationBridge
	{
		private readonly Relationship relationship;

		private readonly IList<PartBridge> parts;

		public AssociationBridgeImpl(Relationship relationship, IList<PartBridge> parts)
		{
			this.relationship = relationship;
			this.parts = parts;
		}

		public AssociationBridgeImpl(Relationship relationship, PartBridge bridge) : this(relationship, Arrays.AsList(bridge))
		{
		}

		public virtual ICollection<PartBridge> GetAssociationValues()
		{
			return this.parts;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual bool IsAssociation()
		{
			return true;
		}

		public virtual bool IsEmpty()
		{
			bool empty = true;
			foreach (PartBridge part in this.parts)
			{
				empty &= part.IsEmpty();
			}
			return empty;
		}

		public virtual string GetPropertyName()
		{
			return null;
		}
	}
}
