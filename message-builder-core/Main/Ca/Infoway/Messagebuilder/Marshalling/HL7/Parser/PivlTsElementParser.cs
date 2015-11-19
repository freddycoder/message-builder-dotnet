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
