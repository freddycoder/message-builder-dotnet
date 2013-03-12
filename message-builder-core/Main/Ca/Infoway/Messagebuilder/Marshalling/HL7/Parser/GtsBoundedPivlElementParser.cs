/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
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
			ParseContext subContext = ParserContextImpl.Create("IVL<TS.FULLDATE>", typeof(Interval<object>), context.GetVersion(), context
				.GetDateTimeZone(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			return (Interval<PlatformDate>)ParserRegistry.GetInstance().Get("IVL<TS.FULLDATE>").Parse(subContext, Arrays.AsList((XmlNode
				)durationElement), xmlResult).BareValue;
		}

		private PeriodicIntervalTime ParseFrequency(ParseContext context, XmlToModelResult xmlToModelResult, XmlElement durationElement
			)
		{
			ParseContext subContext = ParserContextImpl.Create("PIVL<TS.DATETIME>", typeof(PeriodicIntervalTime), context.GetVersion(
				), context.GetDateTimeZone(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			return (PeriodicIntervalTime)ParserRegistry.GetInstance().Get("PIVL<TS.DATETIME>").Parse(subContext, Arrays.AsList((XmlNode
				)durationElement), xmlToModelResult).BareValue;
		}

		private IList<XmlElement> FindComponents(XmlElement element, XmlToModelResult xmlToModelResult)
		{
			IList<XmlElement> result = new List<XmlElement>();
			XmlNodeList list = element.ChildNodes;
			int length = list == null ? 0 : list.Count;
			for (int i = 0; i < length; i++)
			{
				XmlNode node = list.Item(i);
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
			return result;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new GTSImpl();
		}
	}
}
