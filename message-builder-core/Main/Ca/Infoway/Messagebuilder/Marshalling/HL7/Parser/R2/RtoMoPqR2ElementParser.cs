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


using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// RTO - Ratio (physical quantity, physical quantity)
	/// Parses into a Ratio of physical quantities.
	/// </summary>
	/// <remarks>
	/// RTO - Ratio (physical quantity, physical quantity)
	/// Parses into a Ratio of physical quantities. The elements looks like this:
	/// 
	/// 
	/// 
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-RTO
	/// </remarks>
	[DataTypeHandler("RTO<MO,PQ>")]
	internal class RtoMoPqR2ElementParser : AbstractRtoR2ElementParser<Money, PhysicalQuantity>
	{
		internal PqR2ElementParser pqParser = new PqR2ElementParser();

		internal MoR2ElementParser moParser = new MoR2ElementParser();

		protected override Money GetNumeratorValue(XmlElement element, string type, ParseContext context, XmlToModelResult xmlToModelResult
			)
		{
			// inner types (numerator and denominator) are guaranteed to be of type MO.x and PQ.x due to the DataTypeHandler annotation; no need to validate this is a MO or PQ
			// create new (mandatory) context
			ParseContext innerContext = ParseContextImpl.Create(type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality
				.Create("1"), context);
			// this loses any null flavor info; however, since both numerator and denominator are mandatory this is not a problem
			return (Money)moParser.Parse(innerContext, (XmlNode)element, xmlToModelResult).BareValue;
		}

		protected override PhysicalQuantity GetDenominatorValue(XmlElement element, string type, ParseContext context, XmlToModelResult
			 xmlToModelResult)
		{
			// inner types (numerator and denominator) are guaranteed to be of type MO.x and PQ.x due to the DataTypeHandler annotation; no need to validate this is a MO or PQ
			// create new (mandatory) context
			ParseContext innerContext = ParseContextImpl.Create(type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY, Cardinality
				.Create("1"), context);
			// this loses any null flavor info; however, since both numerator and denominator are mandatory this is not a problem
			return (PhysicalQuantity)pqParser.Parse(innerContext, (XmlNode)element, xmlToModelResult).BareValue;
		}
	}
}
