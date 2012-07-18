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
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PeriodicIntervalTime ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			return ParseNonNullNode(context, (XmlElement)node, expectedReturnType, xmlToModelResult);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual PeriodicIntervalTime ParseNonNullNode(ParseContext context, XmlElement element, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			ValidateNonAllowedChildNode(element, xmlToModelResult, "period");
			ValidateNonAllowedChildNode(element, xmlToModelResult, "phase");
			XmlElement frequency = (XmlElement)GetNamedChildNode(element, "frequency");
			if (frequency != null)
			{
				return ParseFrequency(context, frequency, expectedReturnType, xmlToModelResult);
			}
			else
			{
				CreateMandatoryChildElementHl7Error(element, "frequency", xmlToModelResult);
				return null;
			}
		}

		private void CreateMandatoryChildElementHl7Error(XmlElement element, string name, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Missing mandatory element <" + name + ">", element
				));
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected virtual PeriodicIntervalTime ParseFrequency(ParseContext context, XmlElement element, Type expectedReturnType, 
			XmlToModelResult xmlToModelResult)
		{
			XmlElement numerator = (XmlElement)GetNamedChildNode(element, "numerator");
			XmlElement denominator = (XmlElement)GetNamedChildNode(element, "denominator");
			if (numerator != null && denominator != null)
			{
				Int32? repetitions = ParseNumerator(context, numerator, xmlToModelResult);
				if (SpecificationVersion.IsVersion(SpecificationVersion.V01R04_2_SK, context.GetVersion()))
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

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Int32? ParseNumerator(ParseContext context, XmlElement numerator, XmlToModelResult xmlToModelResult)
		{
			ElementParser parser = ParserRegistry.GetInstance().Get("INT.NONNEG");
			ParseContext subContext = ParserContextImpl.Create("INT.NONNEG", typeof(Int32?), context.GetVersion(), context.GetDateTimeZone
				(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			return (Int32?)parser.Parse(subContext, Arrays.AsList((XmlNode)numerator), xmlToModelResult).BareValue;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private PhysicalQuantity ParseDenominator(ParseContext context, XmlElement numerator, XmlToModelResult xmlToModelResult)
		{
			ElementParser parser = ParserRegistry.GetInstance().Get("PQ.TIME");
			ParseContext subContext = ParserContextImpl.Create("PQ.TIME", typeof(PhysicalQuantity), context.GetVersion(), context.GetDateTimeZone
				(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
			return (PhysicalQuantity)parser.Parse(subContext, Arrays.AsList((XmlNode)numerator), xmlToModelResult).BareValue;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Interval<PhysicalQuantity> ParseDenominatorSk(ParseContext context, XmlElement numerator, XmlToModelResult xmlToModelResult
			)
		{
			ElementParser parser = ParserRegistry.GetInstance().Get("IVL<PQ>");
			ParseContext subContext = ParserContextImpl.Create("IVL<PQ>", typeof(PhysicalQuantity), context.GetVersion(), context.GetDateTimeZone
				(), context.GetDateTimeTimeZone(), Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY);
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
