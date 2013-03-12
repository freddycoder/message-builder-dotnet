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

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// PQ - Physical Quantity
	/// Parses a PQ element into a PhysicalQuantity.
	/// </summary>
	/// <remarks>
	/// PQ - Physical Quantity
	/// Parses a PQ element into a PhysicalQuantity. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-PQ
	/// CeRx specifies that the quantity is formatted as 99999999.99 with no leading or
	/// trailing zeros. This class ignores that particular restriction.  (for MR2007 and MR2009, for most cases this becomes 11.2)
	/// </remarks>
	[DataTypeHandler("PQ")]
	internal class PqElementParser : AbstractSingleElementParser<PhysicalQuantity>
	{
		private PqValidationUtils pqValidationUtils = new PqValidationUtils();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override PhysicalQuantity ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			BigDecimal value = this.pqValidationUtils.ValidateValue(element.GetAttribute("value"), context.GetVersion(), context.Type
				, element, null, xmlToModelResult);
			Ca.Infoway.Messagebuilder.Domainvalue.UnitsOfMeasureCaseSensitive unit = this.pqValidationUtils.ValidateUnits(context.Type
				, element.GetAttribute("unit"), element, null, xmlToModelResult);
			// TODO: TM - PQ.LAB in MR2009 allows for an originalText attribute. Since no current pan-Canadian standard uses PQ.LAB, this requirement has not been implemented.
			return (value != null) ? new PhysicalQuantity(value, unit) : null;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new PQImpl();
		}
	}
}
