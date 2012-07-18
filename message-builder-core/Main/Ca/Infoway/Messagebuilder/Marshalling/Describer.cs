using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class Describer
	{
		internal static string Describe(MessagePartHolder messagePart, Relationship relationship)
		{
			return Describe(messagePart.GetName(), relationship);
		}

		internal static string Describe(Type tealClass, BeanProperty property)
		{
			return Describe(tealClass, property.Name);
		}

		internal static string Describe(Type tealClass, string name)
		{
			return ClassUtils.GetShortClassName(tealClass) + "." + name;
		}

		internal static string Describe(string messagePartName, Relationship relationship)
		{
			return relationship.Name + " of type " + messagePartName;
		}
	}
}
