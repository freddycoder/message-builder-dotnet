using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>CE - Coded Data (R2 datatype variant)</summary>
	[DataTypeHandler("HXIT<CE>")]
	internal class HxitCeR2PropertyFormatter : CeR2PropertyFormatter
	{
		protected override bool ValidTimeAllowed()
		{
			return true;
		}
	}
}
