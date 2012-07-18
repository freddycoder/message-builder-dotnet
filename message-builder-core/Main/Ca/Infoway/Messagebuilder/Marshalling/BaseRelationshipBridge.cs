using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>
	/// An interface that represents the bridge that associates a bean property with
	/// a particular HL7 attribute or association.
	/// </summary>
	/// <remarks>
	/// An interface that represents the bridge that associates a bean property with
	/// a particular HL7 attribute or association.
	/// </remarks>
	/// <author>Intelliware Development</author>
	internal interface BaseRelationshipBridge
	{
		bool IsAssociation();

		Relationship GetRelationship();

		bool IsEmpty();

		string GetPropertyName();
	}
}
