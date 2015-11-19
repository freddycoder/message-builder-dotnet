using System;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("IVL<INT>")]
	internal class IvlIntElementParser : IvlElementParser<Int32?>
	{
		// IVL<INT> does not appear to be used anywhere in CeRx, MR2007 (including V02R01) or MR2009
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new IVLImpl<INT, Interval<Int32?>>();
		}
	}
}
