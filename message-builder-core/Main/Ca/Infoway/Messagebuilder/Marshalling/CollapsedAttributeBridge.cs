using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class CollapsedAttributeBridge : AttributeBridge
	{
		private readonly Relationship relationship;

		private BareANY any;

		private object value;

		private readonly string propertyName;

		public CollapsedAttributeBridge(string propertyName, Relationship relationship, object value)
		{
			this.propertyName = propertyName;
			this.relationship = relationship;
			if (value is BareANY)
			{
				this.any = (BareANY)value;
				this.value = this.any.BareValue;
			}
			else
			{
				this.value = value;
				this.any = null;
			}
		}

		public virtual BareANY GetHl7Value()
		{
			return this.any;
		}

		public virtual BareANY GetHl7Value(int index)
		{
			throw new NotSupportedException();
		}

		public virtual object GetValue()
		{
			return this.value;
		}

		public virtual bool IsEmpty()
		{
			return this.value == null;
		}

		public virtual string GetPropertyName()
		{
			return this.propertyName;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual bool IsAssociation()
		{
			return false;
		}
	}
}
