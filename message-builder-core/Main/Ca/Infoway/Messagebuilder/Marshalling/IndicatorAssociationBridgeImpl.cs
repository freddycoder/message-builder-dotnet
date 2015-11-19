using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class IndicatorAssociationBridgeImpl : AssociationBridge
	{
		private readonly Relationship relationship;

		private readonly IList<PartBridge> parts;

		private readonly BeanProperty beanProperty;

		public IndicatorAssociationBridgeImpl(Relationship relationship, PartBridge bridge, BeanProperty beanProperty)
		{
			this.relationship = relationship;
			this.beanProperty = beanProperty;
			this.parts = Arrays.AsList(bridge);
		}

		public virtual ICollection<PartBridge> GetAssociationValues()
		{
			return IsEmpty() ? CollUtils.EmptyList<PartBridge>() : this.parts;
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
			// null flavor does *not* read as empty
			return false.Equals(this.beanProperty == null ? null : this.beanProperty.Get());
		}

		public virtual string GetPropertyName()
		{
			return null;
		}
	}
}
