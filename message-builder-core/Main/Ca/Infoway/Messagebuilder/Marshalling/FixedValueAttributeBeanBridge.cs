using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class FixedValueAttributeBeanBridge : AttributeBridge
	{
		private readonly BareANY any;

		private readonly object value;

		private readonly Relationship relationship;

		internal FixedValueAttributeBeanBridge(Relationship relationship, BareANY any)
		{
			this.relationship = relationship;
			this.any = any;
			this.value = any != null ? any.BareValue : null;
		}

		internal FixedValueAttributeBeanBridge(Relationship relationship, object value)
		{
			this.relationship = relationship;
			if (value is BareANY)
			{
				this.any = (BareANY)value;
				this.value = any.BareValue;
			}
			else
			{
				this.value = value;
				this.any = null;
			}
		}

		public virtual object GetValue()
		{
			return this.value;
		}

		public virtual bool IsEmpty()
		{
			return false;
		}

		public virtual BareANY GetHl7Value()
		{
			return any;
		}

		public virtual string GetPropertyName()
		{
			return "fixed";
		}

		public virtual bool IsAssociation()
		{
			return false;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual BareANY GetHl7Value(int index)
		{
			throw new NotSupportedException();
		}
	}
}
