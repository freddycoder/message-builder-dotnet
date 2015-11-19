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
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Collections.Generics;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>ANY (R2)</summary>
	[DataTypeHandler("ANY")]
	public class AnyR2ElementParser : AbstractSingleElementParser<object>
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new ANYImpl<object>();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		public override BareANY Parse(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			// if we have any specialization type (even with a NF), delegate control to a subparser
			// otherwise, let the ANY parser handle this
			string parentType = context == null ? null : context.Type;
			string actualType = ObtainActualType(parentType, node, xmlToModelResult);
			bool newTypeSpecified = StringUtils.IsNotBlank(actualType);
			if (newTypeSpecified)
			{
				BareANY result = CreateDataTypeInstance(context != null ? GetType(context) : null);
				object value = DelegateToConcreteParser(context, node, result, xmlToModelResult);
				((BareANYImpl)result).BareValue = value;
				return result;
			}
			return base.Parse(context, node, xmlToModelResult);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override object ParseNonNullNode(ParseContext context, XmlNode node, BareANY hl7Result, Type returnType, XmlToModelResult
			 xmlToModelResult)
		{
			return DelegateToConcreteParser(context, node, hl7Result, xmlToModelResult);
		}

		private object DelegateToConcreteParser(ParseContext context, XmlNode node, BareANY hl7Result, XmlToModelResult xmlToModelResult
			)
		{
			object result = null;
			string parentType = context == null ? null : context.Type;
			string actualType = ObtainActualType(parentType, node, xmlToModelResult);
			if (StringUtils.IsNotBlank(actualType))
			{
				ElementParser elementParser = ParserR2Registry.GetInstance().Get(actualType);
				if (elementParser == null || !IsValidTypeForAny(parentType, actualType))
				{
					xmlToModelResult.AddHl7Error(Hl7Error.CreateInvalidTypeError(actualType, parentType, (XmlElement)node));
				}
				else
				{
					BareANY parsedValue = elementParser.Parse(ParseContextImpl.CreateWithConstraints(actualType, DetermineReturnType(actualType
						, GetReturnType(context)), context), Arrays.AsList(node), xmlToModelResult);
					result = parsedValue.BareValue;
					// Yes, this is a side effect of calling this method. If we don't do this then the actual type of the ANY could be lost
					hl7Result.DataType = parsedValue.DataType;
					hl7Result.NullFlavor = parsedValue.NullFlavor;
					// preserve all metadata (yes, also not a great side effect); this will have to be adjusted whenever new metadata is added to a data type (extremely infrequently)
					if (hl7Result is ANYMetaData && parsedValue is ANYMetaData)
					{
						ANYMetaData anyMetaDataResult = (ANYMetaData)hl7Result;
						ANYMetaData anyMetaDataParsed = (ANYMetaData)parsedValue;
						anyMetaDataResult.Language = anyMetaDataParsed.Language;
						anyMetaDataResult.DisplayName = anyMetaDataParsed.DisplayName;
						anyMetaDataResult.OriginalText = anyMetaDataParsed.OriginalText;
						anyMetaDataResult.Translations.AddAll(anyMetaDataParsed.Translations);
						anyMetaDataResult.IsCdata = anyMetaDataParsed.IsCdata;
						anyMetaDataResult.Operator = anyMetaDataParsed.Operator;
						anyMetaDataResult.Unsorted = anyMetaDataParsed.Unsorted;
					}
				}
			}
			else
			{
				xmlToModelResult.AddHl7Error(Hl7Error.CreateMissingMandatoryAttributeError("xsi:type", (XmlElement)node));
			}
			return result;
		}

		private Type DetermineReturnType(string actualType, Type returnType)
		{
			StandardDataType actualTypeTypeAsType = StandardDataType.GetByTypeName(actualType);
			if (actualTypeTypeAsType != null && actualTypeTypeAsType.Coded)
			{
				// TM: could expand this to try to obtain the actual domain type using the code and code system (possibly more trouble than its worth)
				//     (this type of "lookup domain type by code system" is not currently supported; would need to watch out for multiple domains using same code system)
				//     Also: MB doesn't track code systems, though it does have an enum of some of the more common ones
				return typeof(ANY<object>);
			}
			return returnType;
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

		/// <summary>The xsi:type attribute is used to check against valid ANY types.</summary>
		/// <remarks>
		/// The xsi:type attribute is used to check against valid ANY types. This has a bit of "magic"
		/// involved, as the CHI specializationType notation (eg. URG_PQ) just happens to match up to our
		/// StandardDataType enum names.
		/// </remarks>
		/// <param name="parentType"></param>
		/// <param name="node"></param>
		/// <param name="xmlToModelResult"></param>
		/// <returns>the actual type</returns>
		private string ObtainActualType(string parentType, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			string actualType = null;
			string xsiType = GetXsiType(node);
			if (xsiType != null)
			{
				string innerType = null;
				XmlNodeList childNodes = node.ChildNodes;
				foreach (XmlNode child in new XmlNodeListIterable(childNodes))
				{
					innerType = GetXsiType(child);
					if (StringUtils.IsNotBlank(innerType))
					{
						break;
					}
				}
				if (StringUtils.IsNotBlank(innerType))
				{
					// the "true" type, in this case, is found by combining the outer xsi:type with the inner xsi:type
					int xsiTypeIndex = xsiType.IndexOf("_");
					xsiType = (xsiTypeIndex >= 0 ? Ca.Infoway.Messagebuilder.StringUtils.Substring(xsiType, 0, xsiTypeIndex) : xsiType);
					actualType = xsiType + "_" + innerType;
				}
				else
				{
					actualType = xsiType;
				}
				if (StringUtils.IsNotBlank(actualType))
				{
					actualType = ConvertSpecializationType(actualType);
				}
			}
			return actualType;
		}
	}
}
