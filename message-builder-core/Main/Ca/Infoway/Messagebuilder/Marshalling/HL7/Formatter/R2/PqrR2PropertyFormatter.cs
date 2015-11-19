using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.R2
{
	/// <summary>PQR - PhysicalQuantity with Alternate Code (R2 datatype variant)</summary>
	[DataTypeHandler("PQR")]
	internal class PqrR2PropertyFormatter : CvR2PropertyFormatter
	{
		protected override bool ValueAllowed()
		{
			return true;
		}
	}
}
