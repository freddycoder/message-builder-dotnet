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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	[DataTypeHandler("PIVL<TS>")]
	internal class PivlTsR2ElementParser : AbstractSingleElementParser<PeriodicIntervalTimeR2>
	{
		private IvlTsR2ElementParser ivlTsParser = new IvlTsR2ElementParser();

		private PqR2ElementParser pqParser = new PqR2ElementParser();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PIVL_R2Impl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PeriodicIntervalTimeR2 ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			XmlElement periodElement = (XmlElement)GetNamedChildNode(node, "period");
			PhysicalQuantity period = CreatePeriodType(context, periodElement, xmlToModelResult);
			XmlElement phaseElement = (XmlElement)GetNamedChildNode(node, "phase");
			Interval<PlatformDate> phase = CreatePhaseType(context, phaseElement, xmlToModelResult);
			CalendarCycle alignment = ObtainAlignment(context, (XmlElement)node, xmlToModelResult);
			bool institutionSpecified = ObtainInstitutionSpecified(context, (XmlElement)node, xmlToModelResult);
			return new PeriodicIntervalTimeR2(phase, period, alignment, institutionSpecified, null, null);
		}

		protected virtual PhysicalQuantity CreatePeriodType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult
			)
		{
			if (element == null)
			{
				return null;
			}
			ParseContext pqContext = ParseContextImpl.Create("PQ", context);
			BareANY pqAny = this.pqParser.Parse(pqContext, element, xmlToModelResult);
			return (PhysicalQuantity)pqAny.BareValue;
		}

		protected virtual Interval<PlatformDate> CreatePhaseType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult
			)
		{
			if (element == null)
			{
				return null;
			}
			ParseContext ivlTsContext = ParseContextImpl.Create("IVL<TS>", context);
			BareANY periodAny = this.ivlTsParser.Parse(ivlTsContext, Arrays.AsList((XmlNode)element), xmlToModelResult);
			DateInterval dateInterval = (DateInterval)periodAny.BareValue;
			return dateInterval == null ? null : dateInterval.Interval;
		}

		private CalendarCycle ObtainAlignment(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			CalendarCycle alignment = null;
			if (element.HasAttribute("alignment"))
			{
				string alignmentString = element.GetAttribute("alignment");
				foreach (CalendarCycle calendarCycle in EnumPattern.Values<CalendarCycle>())
				{
					if (StringUtils.Equals(calendarCycle.CalendarCycleCode, alignmentString))
					{
						alignment = calendarCycle;
						break;
					}
				}
				if (alignment == null)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Alignment attribute is not a valid CalendarCycle value. Value found: \""
						 + alignmentString + "\"", element));
				}
			}
			return alignment;
		}

		private bool ObtainInstitutionSpecified(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			bool institutionSpecified = false;
			if (element.HasAttribute("institutionSpecified"))
			{
				string institutionSpecifiedString = element.GetAttribute("institutionSpecified");
				institutionSpecified = Ca.Infoway.Messagebuilder.BooleanUtils.ValueOf(institutionSpecifiedString);
				if (!institutionSpecified && !"false".EqualsIgnoreCase(institutionSpecifiedString))
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "If institutionSpecified attribute is provided, it must be \"true\" or \"false\". Value found: \""
						 + institutionSpecifiedString + "\"", element));
				}
			}
			return institutionSpecified;
		}
	}
}
