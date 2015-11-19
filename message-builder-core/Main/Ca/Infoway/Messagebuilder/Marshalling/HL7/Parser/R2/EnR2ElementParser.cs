using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// EN - EntityName
	/// Parses an EN element into a EntityName.
	/// </summary>
	/// <remarks>
	/// EN - EntityName
	/// Parses an EN element into a EntityName. The element looks like this:
	/// This is a trivial name
	/// This class makes a decision on which parser to use based on the format of the
	/// XML.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-EN
	/// </remarks>
	[DataTypeHandler("EN")]
	internal class EnR2ElementParser : AbstractNameR2ElementParser<EntityName>
	{
		protected override EntityName CreateEntityName()
		{
			return new EntityName();
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ENImpl<EntityName>();
		}
	}
}
