using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MockPartBridge : PartBridge
	{
		private bool isEmpty;

		private string typeName;

		private NullFlavor nullFlavor;

		private IList<Realm> realmCode;

		public virtual void SetTypeName(string typeName)
		{
			this.typeName = typeName;
		}

		public virtual void SetEmpty(bool isEmpty)
		{
			this.isEmpty = isEmpty;
		}

		public virtual string GetPropertyName()
		{
			return "aPropertyName2";
		}

		public virtual IList<BaseRelationshipBridge> GetRelationshipBridges()
		{
			return CollUtils.EmptyList<BaseRelationshipBridge>();
		}

		public virtual string GetTypeName()
		{
			return this.typeName;
		}

		public virtual bool IsCollapsed()
		{
			return false;
		}

		public virtual bool IsEmpty()
		{
			return this.isEmpty;
		}

		public virtual NullFlavor GetNullFlavor()
		{
			return this.nullFlavor;
		}

		public virtual void SetNullFlavor(NullFlavor nullFlavor)
		{
			this.nullFlavor = nullFlavor;
		}

		public virtual bool HasNullFlavor()
		{
			return this.nullFlavor != null;
		}

		public virtual bool IsNullPart()
		{
			return false;
		}

		public virtual void AddRealmCode(Realm realmCode)
		{
			this.realmCode = new List<Realm>();
			this.realmCode.Add(realmCode);
		}

		public virtual IList<Realm> GetRealmCode()
		{
			return this.realmCode;
		}
	}
}
