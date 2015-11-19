using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>SCXM - Coded Descriptor with Operator (R2 datatype variant)</summary>
	[DataTypeHandler("BXIT<CD>")]
	internal class BxitCdR2PropertyFormatter : CdR2PropertyFormatter
	{
		protected override bool QtyAllowed()
		{
			return true;
		}
	}
}
