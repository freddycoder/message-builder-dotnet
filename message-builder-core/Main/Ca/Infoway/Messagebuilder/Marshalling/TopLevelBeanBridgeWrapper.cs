using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class TopLevelBeanBridgeWrapper : PartBridge
	{
		public class FixedValueIfNotProvidedAttributeBeanBridge : FixedValueAttributeBeanBridge
		{
			private readonly AttributeBridge relationshipBridge;

			public FixedValueIfNotProvidedAttributeBeanBridge(TopLevelBeanBridgeWrapper _enclosing, AttributeBridge relationshipBridge
				, BareANY any) : base(relationshipBridge.GetRelationship(), any)
			{
				this._enclosing = _enclosing;
				this.relationshipBridge = relationshipBridge;
			}

			public override BareANY GetHl7Value()
			{
				BareANY any = this.relationshipBridge.GetHl7Value();
				if (any == null || any.BareValue == null)
				{
					return base.GetHl7Value();
				}
				else
				{
					return any;
				}
			}

			private readonly TopLevelBeanBridgeWrapper _enclosing;
		}

		private readonly PartBridge bridge;

		private readonly string interactionId;

		public TopLevelBeanBridgeWrapper(PartBridge bridge, string interactionId)
		{
			this.bridge = bridge;
			this.interactionId = interactionId;
		}

		public virtual IList<BaseRelationshipBridge> GetRelationshipBridges()
		{
			IList<BaseRelationshipBridge> result = new List<BaseRelationshipBridge>();
			foreach (BaseRelationshipBridge relationshipBridge in this.bridge.GetRelationshipBridges())
			{
				if ("versionCode".Equals(relationshipBridge.GetRelationship().Name) && !relationshipBridge.GetRelationship().Fixed)
				{
					result.Add(new TopLevelBeanBridgeWrapper.FixedValueIfNotProvidedAttributeBeanBridge(this, (AttributeBridge)relationshipBridge
						, new CSImpl(Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode.V3_2007_05)));
				}
				else
				{
					if ("interactionId".Equals(relationshipBridge.GetRelationship().Name))
					{
						IIImpl iiImpl = new IIImpl(new Identifier("2.16.840.1.113883.1.6", this.interactionId));
						if (StandardDataType.II.Type.Equals(relationshipBridge.GetRelationship().Type))
						{
							// we must set a concrete specialization type when defined as abstract
							iiImpl.DataType = StandardDataType.II_PUBLIC;
						}
						result.Add(new TopLevelBeanBridgeWrapper.FixedValueIfNotProvidedAttributeBeanBridge(this, (AttributeBridge)relationshipBridge
							, iiImpl));
					}
					else
					{
						result.Add(relationshipBridge);
					}
				}
			}
			return result;
		}

		public virtual string GetTypeName()
		{
			return this.interactionId;
		}

		public virtual bool IsEmpty()
		{
			return this.bridge.IsEmpty();
		}

		public virtual string GetPropertyName()
		{
			return this.bridge.GetPropertyName();
		}

		public virtual bool IsCollapsed()
		{
			return false;
		}

		public virtual NullFlavor GetNullFlavor()
		{
			return null;
		}

		public virtual bool HasNullFlavor()
		{
			return false;
		}
	}
}
