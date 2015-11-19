using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>An implementation of the AttributeBridge interface.</summary>
	/// <remarks>
	/// An implementation of the AttributeBridge interface.  This class
	/// provides access to a single HL7 attribute in a part.
	/// </remarks>
	/// <author>Intelliware Development</author>
	internal class AttributeBridgeImpl : AttributeBridge
	{
		private readonly Relationship relationship;

		private readonly BeanProperty property;

		internal AttributeBridgeImpl(Relationship relationship, BeanProperty property)
		{
			this.relationship = relationship;
			this.property = property;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual bool IsAssociation()
		{
			return false;
		}

		public virtual object GetValue()
		{
			return this.property == null ? null : this.property.Get();
		}

		public virtual bool IsEmpty()
		{
			return EmptinessUtil.IsEmpty(GetValue());
		}

		public virtual BareANY GetHl7Value()
		{
			return this.property == null ? null : new DataTypeFieldHelper(property.Bean, property.Name).Get<BareANY>();
		}

		public virtual string GetPropertyName()
		{
			return this.property == null ? string.Empty : this.property.Name;
		}

		public override string ToString()
		{
			return this.relationship.ToString() + " -> " + DescribeProperty();
		}

		private string DescribeProperty()
		{
			if (this.property == null)
			{
				return "nothing";
			}
			else
			{
				return ClassUtils.GetShortClassName(this.property.BeanType) + "." + this.property.Name;
			}
		}

		public virtual BareANY GetHl7Value(int index)
		{
			object list = this.property == null ? null : new DataTypeFieldHelper(property.Bean, property.Name).Get<object>();
			if (this.property.Collection && ListElementUtil.Count(list) < index)
			{
				return (BareANY)ListElementUtil.GetElement(list, index);
			}
			else
			{
				return null;
			}
		}
	}
}
