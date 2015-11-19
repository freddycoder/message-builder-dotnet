using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>SC - Coded String (R2 datatype variant)</summary>
	[DataTypeHandler("SC")]
	internal class ScR2PropertyFormatter : CsR2PropertyFormatter
	{
		protected override bool CodeSystemAllowed()
		{
			return true;
		}

		protected override bool CodeSystemNameAllowed()
		{
			return true;
		}

		protected override bool CodeSystemVersionAllowed()
		{
			return true;
		}

		protected override bool DisplayNameAllowed()
		{
			return true;
		}

		protected override bool SimpleValueAllowed()
		{
			return true;
		}
	}
}
