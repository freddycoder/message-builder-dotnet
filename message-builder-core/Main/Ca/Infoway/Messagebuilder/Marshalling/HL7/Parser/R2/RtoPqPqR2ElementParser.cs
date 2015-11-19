using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// RTO - Ratio (physical quantity, physical quantity)
	/// Parses into a Ratio of physical quantities.
	/// </summary>
	/// <remarks>
	/// RTO - Ratio (physical quantity, physical quantity)
	/// Parses into a Ratio of physical quantities. The elements looks like this:
	/// 
	/// 
	/// 
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-RTO
	/// </remarks>
	[DataTypeHandler("RTO<PQ,PQ>")]
	internal class RtoPqPqR2ElementParser : AbstractRtoR2ElementParser<PhysicalQuantity, PhysicalQuantity>
	{
		internal PqR2ElementParser parser = new PqR2ElementParser();

		protected override PhysicalQuantity GetNumeratorValue(XmlElement element, string type, ParseContext context, XmlToModelResult
			 xmlToModelResult)
		{
			return GetValue(element, type, context, xmlToModelResult);
		}

		protected override PhysicalQuantity GetDenominatorValue(XmlElement element, string type, ParseContext context, XmlToModelResult
			 xmlToModelResult)
		{
			return GetValue(element, type, context, xmlToModelResult);
		}

		private PhysicalQuantity GetValue(XmlElement element, string type, ParseContext context, XmlToModelResult xmlToModelResult
			)
		{
			// inner types (numerator and denominator) are guaranteed to be of type PQ.x due to the DataTypeHandler annotation; no need to validate this is a PQ
			// create new (mandatory) context
			ParseContext innerContext = ParseContextImpl.Create(type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality
				.Create("1"), context);
			// this loses any null flavor info; however, since both numerator and denominator are mandatory this is not a problem
			return (PhysicalQuantity)this.parser.Parse(innerContext, (XmlNode)element, xmlToModelResult).BareValue;
		}
	}
}
