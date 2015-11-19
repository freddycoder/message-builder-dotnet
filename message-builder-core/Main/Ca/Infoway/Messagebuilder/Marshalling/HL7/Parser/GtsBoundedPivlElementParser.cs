using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Collections.Generics;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	[DataTypeHandler("GTS.BOUNDEDPIVL")]
	internal class GtsBoundedPivlElementParser : AbstractSingleElementParser<GeneralTimingSpecification>
	{
		protected override GeneralTimingSpecification ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlResult)
		{
			return ParseNonNullNode(context, (XmlElement)node, expectedReturnType, xmlResult);
		}

		protected virtual GeneralTimingSpecification ParseNonNullNode(ParseContext context, XmlElement element, Type expectedReturnType
			, XmlToModelResult xmlResult)
		{
			GeneralTimingSpecification result = null;
			IList<XmlElement> components = FindComponents(element, xmlResult);
			if (components.Count == 2)
			{
				Interval<PlatformDate> duration = ParseDuration(context, xmlResult, components[0]);
				PeriodicIntervalTime frequency = ParseFrequency(context, xmlResult, components[1]);
				if (duration != null && frequency != null)
				{
					result = new GeneralTimingSpecification(duration, frequency);
				}
				else
				{
					if (duration == null)
					{
						xmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Could not parse the duration portion of the GTS.BOUNDEDPIVL"
							, components[0]));
					}
					if (frequency == null)
					{
						xmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Could not parse the frequency portion of the GTS.BOUNDEDPIVL"
							, components[1]));
					}
				}
			}
			else
			{
				xmlResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Expected to find 2 <comp> sub-elements, but found {0}"
					, components.Count), element));
			}
			return result;
		}

		private Interval<PlatformDate> ParseDuration(ParseContext context, XmlToModelResult xmlResult, XmlElement durationElement
			)
		{
			ParseContext subContext = ParseContextImpl.Create("IVL<TS.FULLDATE>", typeof(Interval<object>), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), context);
			return (Interval<PlatformDate>)ParserRegistry.GetInstance().Get("IVL<TS.FULLDATE>").Parse(subContext, Arrays.AsList((XmlNode
				)durationElement), xmlResult).BareValue;
		}

		private PeriodicIntervalTime ParseFrequency(ParseContext context, XmlToModelResult xmlToModelResult, XmlElement durationElement
			)
		{
			ParseContext subContext = ParseContextImpl.Create("PIVL<TS.DATETIME>", typeof(PeriodicIntervalTime), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
				.MANDATORY, Cardinality.Create("1"), context);
			return (PeriodicIntervalTime)ParserRegistry.GetInstance().Get("PIVL<TS.DATETIME>").Parse(subContext, Arrays.AsList((XmlNode
				)durationElement), xmlToModelResult).BareValue;
		}

		private IList<XmlElement> FindComponents(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			IList<XmlElement> result = new List<XmlElement>();
			XmlNodeList list = element.ChildNodes;
			if (list != null)
			{
				foreach (XmlNode node in new XmlNodeListIterable(list))
				{
					if (node.NodeType != System.Xml.XmlNodeType.Element)
					{
					}
					else
					{
						// skip it
						if (StringUtils.Equals("comp", NodeUtil.GetLocalOrTagName((XmlElement)node)))
						{
							result.Add((XmlElement)node);
						}
						else
						{
							xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Unexpected tag {0} in GTS.BOUNDEDPIVL"
								, XmlDescriber.DescribeSingleElement((XmlElement)node)), (XmlElement)node));
						}
					}
				}
			}
			return result;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new GTSImpl();
		}
	}
}
