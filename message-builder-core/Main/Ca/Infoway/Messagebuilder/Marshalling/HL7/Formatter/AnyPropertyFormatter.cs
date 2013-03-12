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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// ANY, ANY.LAB, ANY.CA.IZ, ANY.PATH
	/// Each value sent over the wire must correspond to one of the
	/// following non-abstract data type flavor specifications defined below:
	/// ANY:       all types allowed
	/// ANY.LAB:   CD.LAB, ST, PQ.LAB, IVL, INT.NONNEG, INT.POS, TS.FULLDATETIME, URG
	/// ANY.CA.IZ: ST, PN.BASIC, INT.POS, BL
	/// ANY.PATH:  ST, PQ, ED.DOCORREF or CD.LAB
	/// </summary>
	[DataTypeHandler(new string[] { "ANY", "ANY.LAB", "ANY.CA.IZ", "ANY.PATH" })]
	public class AnyPropertyFormatter : AbstractPropertyFormatter
	{
		public override string Format(FormatContext formatContext, BareANY hl7Value, int indentLevel)
		{
			string specializationType = hl7Value.DataType.Type;
			PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(specializationType);
			string parentType = formatContext.Type;
			if (formatter == null || !AnyHelper.IsValidTypeForAny(parentType, specializationType))
			{
				string errorText = "Cannot support properties of type " + specializationType + " for " + parentType + ". Please specify a specializationType applicable for "
					 + parentType + " in the appropriate message bean.";
				throw new ModelToXmlTransformationException(errorText);
			}
			else
			{
				return formatter.Format(new FormatContextImpl(formatContext.GetModelToXmlResult(), formatContext.GetPropertyPath(), formatContext
					.GetElementName(), specializationType, formatContext.GetDomainType(), formatContext.GetConformanceLevel(), true, formatContext
					.GetVersion(), formatContext.GetDateTimeZone(), formatContext.GetDateTimeTimeZone(), true, null), hl7Value, indentLevel);
			}
		}
	}
}
