using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// PQ - Physical Quantity
	/// Represents a Physical Quantity object as an element:
	/// &lt;element-name value="123.33" unit="mg"/&gt;
	/// This is the default HL7 implementation of the formatter without any wacky CeRx additions.
	/// </summary>
	/// <remarks>
	/// PQ - Physical Quantity
	/// Represents a Physical Quantity object as an element:
	/// &lt;element-name value="123.33" unit="mg"/&gt;
	/// This is the default HL7 implementation of the formatter without any wacky CeRx additions.
	/// </remarks>
	[DataTypeHandler("PQ")]
	public class PqPropertyFormatter : AbstractPqPropertyFormatter
	{
	}
}
