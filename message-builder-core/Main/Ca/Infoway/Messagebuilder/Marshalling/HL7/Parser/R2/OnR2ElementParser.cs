using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// ON (R2) - OrganizationName
	/// Parses an ON element into a OrganizationName.
	/// </summary>
	/// <remarks>
	/// ON (R2) - OrganizationName
	/// Parses an ON element into a OrganizationName. The element looks like this:
	/// prefixIntelliware Development,Inc.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ON
	/// </remarks>
	[DataTypeHandler("ON")]
	internal class OnR2ElementParser : AbstractNameR2ElementParser<OrganizationName>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ONImpl();
		}

		protected override OrganizationName CreateEntityName()
		{
			return new OrganizationName();
		}
	}
}
