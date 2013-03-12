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
	[DataTypeHandler("PIVL<TS.DATETIME>")]
	internal class PivlTsDateTimeElementParser : AbstractSingleElementParser<PeriodicIntervalTime>
	{
		protected override PeriodicIntervalTime ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			return ParseNonNullNode(context, (XmlElement)node, expectedReturnType, xmlToModelResult);
		}

		protected virtual PeriodicIntervalTime ParseNonNullNode(ParseContext context, XmlElement element, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			PeriodicIntervalTime result = null;
			ValidateNonAllowedChildNode(element, xmlToModelResult, "phase");
			ValidateNonAllowedChildNode(element, xmlToModelResult, "period");
			ValidateNonAllowedChildNode(element, xmlToModelResult, "alignment");
			ValidateNonAllowedChildNode(element, xmlToModelResult, "institutionSpecified");
			XmlElement frequency = (XmlElement)GetNamedChildNode(element, "frequency");
			if (frequency == null)
			{
				CreateMandatoryChildElementHl7Error(element, "frequency", xmlToModelResult);
			}
			else
			{
				result = ParseFrequency(context, frequency, expectedReturnType, xmlToModelResult);
			}
			return result;
		}

		private void CreateMandatoryChildElementHl7Error(XmlElement element, string name, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Missing mandatory element <" + name + ">", element
				));
		}

		protected virtual PeriodicIntervalTime ParseFrequency(ParseContext context, XmlElement element, Type expectedReturnType, 
			XmlToModelResult xmlToModelResult)
		{
			XmlElement numerator = (XmlElement)GetNamedChildNode(element, "numerator");
			XmlElement denominator = (XmlElement)GetNamedChildNode(element, "denominator");
			if (numerator != null && denominator != null)
			{
				Int32? repetitions = ParseNumerator(context, numerator, xmlToModelResult);
				if (SpecificationVersion.IsExactVersion(SpecificationVersion.V01R04_2_SK, context.GetVersion()))
				{
					Interval<PhysicalQuantity> quantityInterval = ParseDenominatorSk(context, denominator, xmlToModelResult);
					return PeriodicIntervalTimeSk.CreateFrequencySk(repetitions, quantityInterval == null ? null : quantityInterval.Low, quantityInterval
						 == null ? null : quantityInterval.High);
				}
				else
				{
					PhysicalQuantity quantity = ParseDenominator(context, denominator, xmlToModelResult);
					return PeriodicIntervalTime.CreateFrequency(repetitions, quantity);
				}
			}
			else
			{
				if (numerator == null)
				{
					CreateMandatoryChildElementHl7Error(element, "numerator", xmlToModelResult);
				}
				if (denominator == null)
				{
					CreateMandatoryChildElementHl7Error(element, "denominator", xmlToModelResult);
				}
				return null;
			}
		}

		private Int32? ParseNumerator(ParseContext context, XmlElement numerator, XmlToModelResult xmlToModelResult)
		{
			ElementParser parser = ParserRegistry.GetInstance().Get("INT.NONNEG");
			ParseContext subContext = ParserContextImpl.Create("INT.NONNEG", typeof(Int32?), context.GetVersion(), context.GetDateTimeZone
				(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			return (Int32?)parser.Parse(subContext, Arrays.AsList((XmlNode)numerator), xmlToModelResult).BareValue;
		}

		private PhysicalQuantity ParseDenominator(ParseContext context, XmlElement numerator, XmlToModelResult xmlToModelResult)
		{
			ElementParser parser = ParserRegistry.GetInstance().Get("PQ.TIME");
			ParseContext subContext = ParserContextImpl.Create("PQ.TIME", typeof(PhysicalQuantity), context.GetVersion(), context.GetDateTimeZone
				(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			return (PhysicalQuantity)parser.Parse(subContext, Arrays.AsList((XmlNode)numerator), xmlToModelResult).BareValue;
		}

		private Interval<PhysicalQuantity> ParseDenominatorSk(ParseContext context, XmlElement numerator, XmlToModelResult xmlToModelResult
			)
		{
			// TM - Unsure if SK is allowed to send in any kind of PQ, or only specific ones. Picked PQ.BASIC to cover most scenarios. 
			ElementParser parser = ParserRegistry.GetInstance().Get("IVL<PQ.BASIC>");
			ParseContext subContext = ParserContextImpl.Create("IVL<PQ.BASIC>", typeof(PhysicalQuantity), context.GetVersion(), context
				.GetDateTimeZone(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			return (Interval<PhysicalQuantity>)parser.Parse(subContext, Arrays.AsList((XmlNode)numerator), xmlToModelResult).BareValue;
		}

		private void ValidateNonAllowedChildNode(XmlElement element, XmlToModelResult xmlToModelResult, string elementName)
		{
			if (GetNamedChildNode(element, elementName) != null)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Periodic Interval (PIVL<TS.DATETIME>) does not allow the <"
					 + elementName + "> element", element));
			}
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PIVLImpl();
		}
	}
}
