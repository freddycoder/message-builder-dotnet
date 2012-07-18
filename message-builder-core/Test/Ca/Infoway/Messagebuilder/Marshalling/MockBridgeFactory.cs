using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MockBridgeFactory : BridgeFactory
	{
		internal PartBridge partBridge;

		internal Interaction interaction;

		public virtual PartBridge CreateInteractionBridge(IInteraction tealBean)
		{
			return this.partBridge;
		}

		public virtual Interaction GetInteraction(IInteraction tealBean)
		{
			return this.interaction;
		}
	}
}
