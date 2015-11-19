using System;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	[DataTypeHandler("IVL<INT>")]
	internal class IvlIntPropertyFormatter : IvlPropertyFormatter<Int32?>
	{
	}
}
