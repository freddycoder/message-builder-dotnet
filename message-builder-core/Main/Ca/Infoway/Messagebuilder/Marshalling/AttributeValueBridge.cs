using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class AttributeValueBridge : AttributeBridge
	{
		private readonly ANY<object> any;

		private readonly object value;

		private readonly Relationship relationship;

		internal AttributeValueBridge(Relationship relationship, ANY<object> any)
		{
			this.relationship = relationship;
			this.any = any;
			this.value = any != null ? any.Value : null;
		}

		internal AttributeValueBridge(Relationship relationship, object value)
		{
			this.relationship = relationship;
			if (value is ANY<object>)
			{
				this.any = (ANY<object>)value;
				this.value = any.Value;
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
			return EmptinessUtil.IsEmpty(GetValue());
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
