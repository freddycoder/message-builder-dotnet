using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>CV - Coded Value (R2 datatype variant)</summary>
	[DataTypeHandler(new string[] { "CV", "CO" })]
	internal class CvR2PropertyFormatter : ScR2PropertyFormatter
	{
		protected override bool OriginalTextAllowed()
		{
			return true;
		}

		protected override bool SimpleValueAllowed()
		{
			return false;
		}
	}
}
