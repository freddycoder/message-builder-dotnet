using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype.Nullflavor;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class PartBridgeImpl : PartBridge
	{
		private readonly IList<BaseRelationshipBridge> relationshipBridges;

		private readonly string typeName;

		private readonly bool collapsed;

		private readonly string propertyPath;

		private readonly object bean;

		public PartBridgeImpl(string propertyPath, object bean, string typeName, IList<BaseRelationshipBridge> relationshipBridges
			, bool collapsed)
		{
			this.propertyPath = propertyPath;
			this.bean = bean;
			this.typeName = typeName;
			this.relationshipBridges = relationshipBridges;
			this.collapsed = collapsed;
		}

		public virtual IList<BaseRelationshipBridge> GetRelationshipBridges()
		{
			return this.relationshipBridges;
		}

		public virtual string GetTypeName()
		{
			return this.typeName;
		}

		/// <summary>Determine if a part has any content.</summary>
		/// <remarks>
		/// Determine if a part has any content.
		/// For the purposes of determining emptiness, we don't consider fixed attributes.
		/// We consider fixed values as not providing real content -- only meta-data.
		/// There are some part types that cause especial concern.  For example, the
		/// COCT_MT141007CA.PackagedDevice has only fixed values, and yet it is mandatory.
		/// </remarks>
		public virtual bool IsEmpty()
		{
			bool empty = true;
			foreach (BaseRelationshipBridge relationship in this.relationshipBridges)
			{
				if (!relationship.GetRelationship().Attribute || !relationship.GetRelationship().Fixed)
				{
					empty &= relationship.IsEmpty();
				}
			}
			// watch out for "indicators", etc.
			if (empty)
			{
				empty = this.collapsed || this.bean == null || HasNullFlavor();
			}
			return empty;
		}

		public virtual bool HasNullFlavor()
		{
			bool result = false;
			if (this.bean is NullFlavorSupport)
			{
				NullFlavorSupport nullable = (NullFlavorSupport)this.bean;
				result = nullable.HasNullFlavor();
			}
			return result;
		}

		public virtual NullFlavor GetNullFlavor()
		{
			NullFlavor result = null;
			if (this.bean is NullFlavorSupport)
			{
				NullFlavorSupport nullable = (NullFlavorSupport)this.bean;
				result = nullable.NullFlavor;
			}
			return result;
		}

		public virtual bool IsCollapsed()
		{
			return this.collapsed;
		}

		public virtual string GetPropertyName()
		{
			return this.propertyPath;
		}
	}
}
