using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class NonStructuralHl7AttributeRenderer
	{
		internal static object GetFixedValue(Relationship relationship)
		{
			if (StringUtils.Equals("BL", relationship.Type))
			{
				return true.ToString().EqualsIgnoreCase(relationship.FixedValue);
			}
			else
			{
				if (StringUtils.Equals("INT.POS", relationship.Type))
				{
					return System.Convert.ToInt32(relationship.FixedValue);
				}
				else
				{
					if (relationship.CodedType)
					{
						return CodeResolverRegistry.Lookup(DomainTypeHelper.GetReturnType(relationship), relationship.FixedValue);
					}
					else
					{
						throw new MarshallingException("Cannot handle a fixed relationship of type: " + relationship.Type);
					}
				}
			}
		}
	}
}
