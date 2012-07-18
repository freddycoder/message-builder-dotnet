using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal interface BridgeFactory
	{
		PartBridge CreateInteractionBridge(IInteraction tealBean);

		Interaction GetInteraction(IInteraction tealBean);
	}
}
