using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>SCXM - Coded Descriptor with Operator (R2 datatype variant)</summary>
	[DataTypeHandler("SXCM<CD>")]
	internal class SxcmCdR2PropertyFormatter : CdR2PropertyFormatter
	{
		protected override bool OperatorAllowed()
		{
			return true;
		}
	}
}
