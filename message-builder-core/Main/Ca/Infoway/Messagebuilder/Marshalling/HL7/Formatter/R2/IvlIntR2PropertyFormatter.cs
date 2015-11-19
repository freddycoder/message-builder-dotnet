using System;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	[DataTypeHandler("IVL<INT>")]
	internal class IvlIntR2PropertyFormatter : IvlR2PropertyFormatter<Int32?>
	{
	}
}
