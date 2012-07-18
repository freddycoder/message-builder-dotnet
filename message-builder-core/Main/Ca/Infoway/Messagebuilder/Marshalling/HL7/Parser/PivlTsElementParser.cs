using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("PIVL<TS>")]
	internal class PivlTsElementParser : AbstractPivlElementParser
	{
		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override DateDiff CreatePeriodType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			return (DateDiff)new IvlTsElementParser().CreateDiffType(ParserContextImpl.Create("IVL<TS>", null, context.GetVersion(), 
				context.GetDateTimeZone(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), element
				, xmlToModelResult);
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Interval<PlatformDate> CreatePhaseType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult
			)
		{
			return (Interval<PlatformDate>)new IvlTsElementParser().Parse(ParserContextImpl.Create("IVL<TS>", null, context.GetVersion
				(), context.GetDateTimeZone(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.OPTIONAL), 
				Arrays.AsList((XmlNode)element), xmlToModelResult).BareValue;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PIVLImpl();
		}
	}
}
