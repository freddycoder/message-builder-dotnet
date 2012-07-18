using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
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
	internal class RtoPqPqElementParser : AbstractRtoElementParser<PhysicalQuantity, PhysicalQuantity>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PhysicalQuantity GetNumeratorValue(XmlElement element)
		{
			return GetValue(element);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PhysicalQuantity GetDenominatorValue(XmlElement element)
		{
			return GetValue(element);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private PhysicalQuantity GetValue(XmlElement element)
		{
			return new PhysicalQuantity(new BigDecimal(GetAttributeValue(element, "value")), CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
				>(GetAttributeValue(element, "unit")));
		}
	}
}
