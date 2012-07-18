using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// ANY, ANY.LAB, ANY.CA.IZ, ANY.PATH
	/// Each value sent over the wire must correspond to one of the
	/// following non-abstract data type flavor specifications defined below:
	/// ANY:       all types allowed
	/// ANY.LAB:   CD.LAB, ST, PQ.LAB, IVL, INT.NONNEG, INT.POS, TS.FULLDATETIME, URG
	/// ANY.CA.IZ: ST, PN.BASIC, INT.POS, BL
	/// ANY.PATH:  ST, PQ, ED.DOCORREF or CD.LAB
	/// </summary>
	[DataTypeHandler(new string[] { "ANY", "ANY.LAB", "ANY.CA.IZ", "ANY.PATH" })]
	public class AnyPropertyFormatter : AbstractPropertyFormatter
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		public override string Format(FormatContext formatContext, BareANY hl7Value, int indentLevel)
		{
			string type = hl7Value.DataType.Type;
			PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(type);
			string parentType = formatContext.Type;
			if (formatter == null || !AnyHelper.IsValidTypeForAny(parentType, type))
			{
				string errorText = "Cannot support properties of type " + type + " for " + parentType + ". Please specify a specializationType applicable for "
					 + parentType + " in the appropriate message bean.";
				throw new ModelToXmlTransformationException(errorText);
			}
			else
			{
				return formatter.Format(new FormatContextImpl(formatContext.GetElementName(), type, formatContext.GetConformanceLevel(), 
					true, null, null, null), hl7Value, indentLevel);
			}
		}
	}
}
