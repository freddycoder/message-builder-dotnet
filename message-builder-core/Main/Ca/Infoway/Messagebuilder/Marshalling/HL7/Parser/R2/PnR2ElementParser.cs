using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// PN (R2) - Personal Name
	/// Parses a PN element into a PersonName.
	/// </summary>
	/// <remarks>
	/// PN (R2) - Personal Name
	/// Parses a PN element into a PersonName. The element looks like this:
	/// 
	/// Mr.
	/// John
	/// Jimmy
	/// Smith
	/// Sr.
	/// 
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PN
	/// </remarks>
	[DataTypeHandler("PN")]
	internal class PnR2ElementParser : AbstractNameR2ElementParser<PersonName>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PNImpl();
		}

		protected override PersonName CreateEntityName()
		{
			return new PersonName();
		}
	}
}
