using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal interface AttributeBridge : BaseRelationshipBridge
	{
		object GetValue();

		bool IsEmpty();

		BareANY GetHl7Value();

		BareANY GetHl7Value(int index);
	}
}
