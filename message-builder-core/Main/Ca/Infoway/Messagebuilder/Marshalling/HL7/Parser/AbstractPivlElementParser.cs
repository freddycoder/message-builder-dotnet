using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// PIVL - Periodic Interval of Time
	/// An interval of time that recurs periodically.
	/// </summary>
	/// <remarks>
	/// PIVL - Periodic Interval of Time
	/// An interval of time that recurs periodically. Periodic intervals have two
	/// properties, phase and period. The phase specifies the "interval prototype"
	/// that is repeated every period.
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PIVL
	/// </remarks>
	public abstract class AbstractPivlElementParser : AbstractSingleElementParser<PeriodicIntervalTime>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PeriodicIntervalTime ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			try
			{
				XmlElement period = (XmlElement)GetNamedChildNode(node, "period");
				XmlElement phase = (XmlElement)GetNamedChildNode(node, "phase");
				if (period != null && phase != null)
				{
					return PeriodicIntervalTime.CreatePeriodPhase(CreatePeriodType(context, period, xmlToModelResult), CreatePhaseType(context
						, phase, xmlToModelResult));
				}
				else
				{
					if (period != null)
					{
						return PeriodicIntervalTime.CreatePeriod(CreatePeriodType(context, period, xmlToModelResult));
					}
					else
					{
						if (phase != null)
						{
							return PeriodicIntervalTime.CreatePhase(CreatePhaseType(context, phase, xmlToModelResult));
						}
						else
						{
							return null;
						}
					}
				}
			}
			catch (ParseException e)
			{
				throw new XmlToModelTransformationException(e.ToString());
			}
		}

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract DateDiff CreatePeriodType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult);

		/// <exception cref="ILOG.J2CsMapping.Util.ParseException"></exception>
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected abstract Interval<PlatformDate> CreatePhaseType(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult
			);
	}
}
