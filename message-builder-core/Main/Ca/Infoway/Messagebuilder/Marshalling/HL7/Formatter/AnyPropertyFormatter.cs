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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Marshalling.Polymorphism;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// ANY, ANY.LAB, ANY.CA.IZ, ANY.PATH; added for BC: ANY.X1, ANY.X2
	/// Each value sent over the wire must correspond to one of the
	/// following non-abstract data type flavor specifications defined below:
	/// ANY:       all types allowed
	/// ANY.LAB:   CD.LAB, ST, PQ.LAB, IVL, INT.NONNEG, INT.POS, TS.FULLDATETIME, URG
	/// ANY.CA.IZ: ST, PN.BASIC, INT.POS, BL
	/// ANY.PATH:  ST, PQ, ED.DOCORREF or CD.LAB
	/// ANY.X1:    ST, CV, PQ.LAB, IVL, URG
	/// ANY.X2:    ST, CV, ED.DOCORREF
	/// </summary>
	[DataTypeHandler(new string[] { "ANY", "ANY.LAB", "ANY.CA.IZ", "ANY.PATH", "ANY.x1", "ANY.x2" })]
	public class AnyPropertyFormatter : AbstractNullFlavorPropertyFormatter<object>
	{
		private readonly PolymorphismHandler polymorphismHandler = new PolymorphismHandler();

		public override string Format(FormatContext formatContext, BareANY hl7Value, int indentLevel)
		{
			if (hl7Value == null)
			{
				return string.Empty;
			}
			string specializationType = hl7Value.DataType.Type;
			StandardDataType specializationTypeAsEnum = StandardDataType.GetByTypeName(specializationType);
			if (specializationTypeAsEnum != null && StandardDataType.ANY.Equals(specializationTypeAsEnum.RootDataType))
			{
				// specializationType has been determined to be an ANY variant; this (most likely) means specializationType has not been specified, so don't do any special processing  
				return base.Format(formatContext, hl7Value, indentLevel);
			}
			else
			{
				string mappedSpecializationType = this.polymorphismHandler.MapCdaR1Type(hl7Value.DataType, formatContext.IsCda());
				PropertyFormatter formatter = FormatterRegistry.GetInstance().Get(mappedSpecializationType);
				string parentType = formatContext.Type;
				if (formatter == null || !AnyHelper.IsValidTypeForAny(parentType, specializationType))
				{
					string errorText = "Cannot support properties of type " + specializationType + " for " + parentType + ". Please specify a specializationType applicable for "
						 + parentType + " in the appropriate message bean.";
					throw new ModelToXmlTransformationException(errorText);
				}
				else
				{
					// pass processing off to the formatter applicable for the given specializationType
					StandardDataType type = hl7Value.DataType;
					return formatter.Format(new Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.FormatContextImpl(formatContext.GetModelToXmlResult
						(), formatContext.GetPropertyPath(), formatContext.GetElementName(), mappedSpecializationType, type.Coded ? "Code" : formatContext
						.GetDomainType(), formatContext.GetConformanceLevel(), formatContext.GetCardinality(), true, formatContext.GetVersion(), 
						formatContext.GetDateTimeZone(), formatContext.GetDateTimeTimeZone(), null, formatContext.GetConstraints(), formatContext
						.IsCda()), hl7Value, indentLevel);
				}
			}
		}

		// yes, pass constraints down
		protected override string FormatNonNullValue(FormatContext formatContext, object t, int indentLevel)
		{
			// getting to this point means: 
			//    1) specializationType was not specified
			//    2) the value being processed is neither null nor a NullFlavor
			// effectively, we have no idea what to do with the data at this point
			string errorText = "Specalization type not set for property of type " + formatContext.Type + ". Specialization type is required in order to render non-null data.";
			throw new ModelToXmlTransformationException(errorText);
		}
	}
}
