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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class AbstractCodeTypeElementParser : AbstractSingleElementParser<Code>
	{
		protected static readonly string STANDARD_CODE_ATTRIBUTE_NAME = "code";

		protected static readonly string CODE_SYSTEM_ATTRIBUTE_NAME = "codeSystem";

		private static readonly CdValidationUtils CD_VALIDATION_UTILS = new CdValidationUtils();

		public override BareANY Parse(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			bool isTranslation = false;
			return DoParse(context, node, xmlToModelResult, isTranslation, STANDARD_CODE_ATTRIBUTE_NAME);
		}

		public virtual BareANY DoParse(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult, bool isTranslation, 
			string codeAttributeName)
		{
			BareANY cd = DoCreateDataTypeInstance(context.Type);
			PopulateNullFlavor(cd, context, node, xmlToModelResult);
			PopulateValue(cd, context, node, xmlToModelResult, codeAttributeName);
			if (!isTranslation)
			{
				CD codeAsCd = (CD)cd;
				string codeAsString = GetAttributeValue(node, codeAttributeName);
				CD_VALIDATION_UTILS.ValidateCodedType(codeAsCd, codeAsString, IsCWE(context), IsCNE(context), isTranslation, context.Type
					, context.GetVersion().GetBaseVersion(), (XmlElement)node, null, xmlToModelResult);
			}
			return cd;
		}

		private bool IsCNE(ParseContext context)
		{
			return context.GetCodingStrength() == CodingStrength.CNE;
		}

		private bool IsCWE(ParseContext context)
		{
			return context.GetCodingStrength() == CodingStrength.CWE;
		}

		private void PopulateNullFlavor(BareANY dataType, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			if (HasValidNullFlavorAttribute(context, node, xmlToModelResult))
			{
				NullFlavor nullFlavor = ParseNullNode(context, node, xmlToModelResult);
				dataType.NullFlavor = nullFlavor;
			}
		}

		private void PopulateValue(BareANY dataType, ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult, string
			 codeAttributeName)
		{
			Code value = ParseNonNullCodeNode(context, codeAttributeName, node, dataType, GetReturnType(context), xmlToModelResult);
			((BareANYImpl)dataType).BareValue = value;
		}

		protected virtual void PopulateOriginalText(BareANY dataType, ParseContext context, XmlElement element, Type returnType, 
			XmlToModelResult xmlToModelResult)
		{
			if (HasOriginalText(element))
			{
				((CD)dataType).OriginalText = GetOriginalText(element);
			}
		}

		private string GetOriginalText(XmlElement element)
		{
			XmlNodeList children = element.ChildNodes;
			string result = null;
			int length = children == null ? 0 : children.Count;
			for (int i = 0; i < length; i++)
			{
				XmlNode node = children.Item(i);
				if (node.NodeType != System.Xml.XmlNodeType.Element)
				{
				}
				else
				{
					if ("originalText".Equals(NodeUtil.GetLocalOrTagName(node)))
					{
						result = NodeUtil.GetTextValue(node);
					}
				}
			}
			return result;
		}

		protected bool HasOriginalText(XmlElement element)
		{
			return StringUtils.IsNotBlank(GetOriginalText(element));
		}

		protected virtual Hl7Error CreateInvalidCodeError(XmlNode node, Type type, string code)
		{
			string message = "The code, \"" + code + "\", in element <" + NodeUtil.GetLocalOrTagName(node) + "> is not a valid value for domain type \""
				 + ClassUtils.GetShortClassName(type) + "\"";
			return new Hl7Error(Hl7ErrorCode.VALUE_NOT_IN_CODE_SYSTEM, message, (XmlElement)node);
		}

		protected virtual Hl7Error CreateMissingCodeSystemError(XmlNode node, Type type, string code)
		{
			return new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "CodeSystem is mandatory when providing a code value", (XmlElement)node
				);
		}

		protected virtual Type GetReturnTypeAsCodeType(Type type)
		{
			if (type is Type)
			{
				return (Type)type;
			}
			else
			{
				if (Generics.IsCollectionParameterizedType(type))
				{
					// this case should only happen if the original property was inlined
					return (Type)Generics.GetParameterType(type);
				}
				else
				{
					throw new ArgumentException("Can't determine the domain type of " + type);
				}
			}
		}

		protected abstract Code ParseNonNullCodeNode(ParseContext context, string codeAttributeName, XmlNode node, BareANY result
			, Type expectedReturnType, XmlToModelResult xmlToModelResult);
	}
}
