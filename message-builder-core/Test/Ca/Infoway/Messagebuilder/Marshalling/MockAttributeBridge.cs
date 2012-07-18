using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MockAttributeBridge : AttributeBridge
	{
		private BareANY hl7Value;

		private object value;

		private bool isEmpty;

		internal Relationship relationship;

		public virtual void SetHl7Value(BareANY hl7Value)
		{
			this.hl7Value = hl7Value;
		}

		public virtual BareANY GetHl7Value()
		{
			return this.hl7Value;
		}

		public virtual BareANY GetHl7Value(int index)
		{
			return null;
		}

		public virtual object GetValue()
		{
			return this.value;
		}

		public virtual bool IsEmpty()
		{
			return this.isEmpty;
		}

		public virtual string GetPropertyName()
		{
			return null;
		}

		public virtual Relationship GetRelationship()
		{
			return this.relationship;
		}

		public virtual bool IsAssociation()
		{
			return false;
		}

		public virtual void SetValue(object value)
		{
			this.value = value;
		}

		public virtual void SetEmpty(bool isEmpty)
		{
			this.isEmpty = isEmpty;
		}
	}
}
