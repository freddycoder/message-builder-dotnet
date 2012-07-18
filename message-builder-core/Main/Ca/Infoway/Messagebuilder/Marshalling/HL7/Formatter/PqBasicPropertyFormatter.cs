using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// PQ.BASIC - Physical Quantity (basic)
	/// Represents a Physical Quantity object as an element:
	/// &lt;element-name value="123.33" unit="validBasicUnit"/&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PQ
	/// </summary>
	[DataTypeHandler("PQ.BASIC")]
	public class PqBasicPropertyFormatter : AbstractCerxPqPropertyFormatter
	{
	}
}
