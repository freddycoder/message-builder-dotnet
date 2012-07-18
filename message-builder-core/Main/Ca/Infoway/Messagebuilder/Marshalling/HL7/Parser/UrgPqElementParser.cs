using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler(new string[] { "URG<PQ>", "URG<PQ.DRUG>", "URG<PQ.TIME>", "URG<PQ.BASIC>" })]
	internal class UrgPqElementParser : UrgElementParser<PQ, PhysicalQuantity>
	{
		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PhysicalQuantity CreateType(XmlElement element)
		{
			string quantity = element.GetAttribute("value");
			string unitString = element.GetAttribute("unit");
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = (CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive
				>(unitString));
			return new PhysicalQuantity(new BigDecimal(quantity), unit);
		}
	}
}
