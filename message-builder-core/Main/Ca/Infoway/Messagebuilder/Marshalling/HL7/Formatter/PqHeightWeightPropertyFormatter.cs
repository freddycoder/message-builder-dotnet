using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// PQ.HEIGHTWEIGHT- Physical Quantity (height or weight)
	/// Represents a Physical Quantity object as an element:
	/// &lt;element-name value="123.33" unit="validHeightWeightUnit"/&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PQ
	/// </summary>
	[DataTypeHandler("PQ.HEIGHTWEIGHT")]
	public class PqHeightWeightPropertyFormatter : AbstractCerxPqPropertyFormatter
	{
	}
}
