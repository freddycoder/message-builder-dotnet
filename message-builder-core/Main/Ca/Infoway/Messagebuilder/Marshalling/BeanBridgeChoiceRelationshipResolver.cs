using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class BeanBridgeChoiceRelationshipResolver
	{
		internal static Relationship ResolveChoice(PartBridge tealBean, Relationship relationship)
		{
			return relationship.FindChoiceOption(ChoiceSupport.ChoiceOptionTypePredicate(new string[] { tealBean.GetTypeName() }));
		}
	}
}
