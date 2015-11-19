using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("PIVL<TS>")]
	internal class PivlTsElementParser : AbstractPivlElementParser
	{
		// TM - VALIDATION - this approach to PIVL is not used by the current set of pan-Canadian standards (CeRx, MR2007, MR2009)
		//                 - leaving this code as-is, with no validation updates; the code could be removed, but it may be useful in a future standard
		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override DateDiff CreatePeriodType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			return (DateDiff)new IvlTsElementParser().CreateDiffType(ParseContextImpl.Create("IVL<TS>", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, Cardinality.Create("0-1"), context), element, xmlToModelResult);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Interval<PlatformDate> CreatePhaseType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult
			)
		{
			return (Interval<PlatformDate>)new IvlTsElementParser().Parse(ParseContextImpl.Create("IVL<TS>", null, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.OPTIONAL, Cardinality.Create("0-1"), context), Arrays.AsList((XmlNode)element), xmlToModelResult).BareValue;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PIVLImpl();
		}
	}
}
