using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// TN (R2) - TrivialName
	/// Parses a TN element into a TrivialName.
	/// </summary>
	/// <remarks>
	/// TN (R2) - TrivialName
	/// Parses a TN element into a TrivialName. The element looks like this:
	/// This is a trivial name
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TN
	/// </remarks>
	[DataTypeHandler("TN")]
	internal class TnR2ElementParser : AbstractNameR2ElementParser<TrivialName>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new TNImpl();
		}

		protected override TrivialName CreateEntityName()
		{
			return new TrivialName();
		}
	}
}
