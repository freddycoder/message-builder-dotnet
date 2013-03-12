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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
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
	public class AnyElementParser : AbstractSingleElementParser<object>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ANYImpl<object>();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override object ParseNonNullNode(ParseContext context, XmlNode node, BareANY hl7Result, Type returnType, XmlToModelResult
			 xmlToModelResult)
		{
			object result = null;
			string parentType = context == null ? null : context.Type;
			string specializationType = ObtainSpecializationType(parentType, node, xmlToModelResult);
			if (StringUtils.IsNotBlank(specializationType))
			{
				ElementParser elementParser = ParserRegistry.GetInstance().Get(specializationType);
				if (elementParser == null || !IsValidTypeForAny(parentType, specializationType))
				{
					xmlToModelResult.AddHl7Error(Hl7Error.CreateInvalidTypeError(specializationType, parentType, (XmlElement)node));
				}
				else
				{
					BareANY parsedValue = elementParser.Parse(ParserContextImpl.Create(specializationType, GetReturnType(context), context.GetVersion
						(), context.GetDateTimeZone(), context.GetDateTimeTimeZone(), context.GetConformance()), Arrays.AsList(node), xmlToModelResult
						);
					result = parsedValue.BareValue;
					// Yes, this is a side effect of calling this method. If we don't do this then the actual type of the ANY.LAB (i.e. PQ.LAB) is lost.
					hl7Result.DataType = parsedValue.DataType;
				}
			}
			else
			{
				xmlToModelResult.AddHl7Error(Hl7Error.CreateMissingMandatoryAttributeError(AbstractElementParser.SPECIALIZATION_TYPE, (XmlElement
					)node));
			}
			return result;
		}

		private bool IsValidTypeForAny(string parentType, string specializationType)
		{
			if (StringUtils.IsBlank(specializationType))
			{
				return false;
			}
			bool valid = AnyHelper.IsValidTypeForAny(parentType, specializationType);
			if (!valid)
			{
				// unqualify only the inner types
				string innerUnqualified = Hl7DataTypeName.UnqualifyInnerTypes(specializationType);
				valid = AnyHelper.IsValidTypeForAny(parentType, innerUnqualified);
			}
			if (!valid)
			{
				// unqualify both outer and inner types)
				string bothUnqualified = Hl7DataTypeName.Unqualify(specializationType);
				valid = AnyHelper.IsValidTypeForAny(parentType, bothUnqualified);
			}
			return valid;
		}

		/// <summary>The specialization type attribute is used to check against valid ANY types.</summary>
		/// <remarks>
		/// The specialization type attribute is used to check against valid ANY types. This has a bit of "magic"
		/// involved, as the CHI specializationType notation (eg. URG_PQ) just happens to match up to our
		/// StandardDataType enum names.
		/// </remarks>
		/// <param name="parentType"></param>
		/// <param name="node"></param>
		/// <param name="xmlToModelResult"></param>
		/// <returns>the converted specializationType</returns>
		private string ObtainSpecializationType(string parentType, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			string rawSpecializationType = GetSpecializationType(node);
			if (StringUtils.IsBlank(rawSpecializationType))
			{
				// some cases don't need specialization type. Treat xsi:type as specializationType (internally)
				// e.g. URG_PQ, ST
				string xsiType = GetXsiType(node);
				if (xsiType != null)
				{
					string innerSpecializationType = null;
					XmlNodeList childNodes = node.ChildNodes;
					for (int i = 0; i < childNodes.Count; i++)
					{
						XmlNode child = childNodes.Item(0);
						innerSpecializationType = GetSpecializationType(child);
						if (StringUtils.IsNotBlank(innerSpecializationType))
						{
							break;
						}
					}
					if (innerSpecializationType != null)
					{
						// the "true" specialization type, in this case, is found by combining the xsi type with the inner specialization type
						int xsiTypeIndex = xsiType.IndexOf("_");
						xsiType = (xsiTypeIndex >= 0 ? Ca.Infoway.Messagebuilder.StringUtils.Substring(xsiType, 0, xsiTypeIndex) : xsiType);
						rawSpecializationType = xsiType + "_" + innerSpecializationType;
					}
					else
					{
						rawSpecializationType = xsiType;
					}
				}
			}
			if (rawSpecializationType != null && rawSpecializationType.Contains("_") && rawSpecializationType.IndexOf('_') == rawSpecializationType
				.LastIndexOf('_'))
			{
				rawSpecializationType = rawSpecializationType.Replace("_", "<") + ">";
			}
			return rawSpecializationType;
		}
	}
}
