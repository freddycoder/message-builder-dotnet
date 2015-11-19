using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// REAL - BigDecimal
	/// Represents a REAL object as an element:
	/// &lt;element-name value="4321.1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// REAL - BigDecimal
	/// Represents a REAL object as an element:
	/// &lt;element-name value="4321.1234"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// </remarks>
	[DataTypeHandler(new string[] { "REAL" })]
	public class RealPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<BigDecimal>
	{
		protected override string GetValue(BigDecimal bigDecimal, FormatContext context, BareANY bareAny)
		{
			return bigDecimal.ToPlainString();
		}
	}
}
