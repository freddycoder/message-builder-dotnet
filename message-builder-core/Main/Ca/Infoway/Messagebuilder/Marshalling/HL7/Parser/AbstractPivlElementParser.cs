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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */
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
		// TM - VALIDATION - this approach to PIVL is not used by the current set of pan-Canadian standards (CeRx, MR2007, MR2009)
		//                 - leaving this code as-is, with no validation updates; the code could be removed, but it may be useful in a future standard
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
