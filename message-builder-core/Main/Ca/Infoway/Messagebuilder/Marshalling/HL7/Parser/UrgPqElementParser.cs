using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("URG<PQ>")]
	internal class UrgPqElementParser : UrgElementParser<PQ, PhysicalQuantity>
	{
		protected override ElementParser GetIvlParser()
		{
			return new IvlPqElementParser(true);
		}

		protected override UncertainRange<PhysicalQuantity> ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, 
			Type expectedReturnType, XmlToModelResult xmlToModelResult)
		{
			// TM - RM20416: grab any original text (pre-adopted from R2 datatype)
			((ANYMetaData)result).OriginalText = GetOriginalText((XmlElement)node);
			return base.ParseNonNullNode(context, node, result, expectedReturnType, xmlToModelResult);
		}
	}
}
