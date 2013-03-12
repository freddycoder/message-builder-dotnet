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
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// CV - Coded Value
	/// Parses an CV element into a CV enum field.
	/// </summary>
	/// <remarks>
	/// CV - Coded Value
	/// Parses an CV element into a CV enum field. The element looks like this:
	/// 
	/// According to CeRx: code has a limit of 20 characters. This limit is not
	/// currently enforced by this class.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CV
	/// CeRx states that attribute codeSystem is mandatory if code is specified. However,
	/// none of the sample messages do this and the HL7 definition of the message domains
	/// do not specify what the codeSystem is for different domains.
	/// There's also an originalText attribute that must be included if code is specified.
	/// Again, the HL7 domain definitions are of little help with that.
	/// Finally: there are two types of attributes that that use this datatype.
	/// CNE (coded no extensibility): code attribute is mandatory.
	/// CWE (coded with extensibility): code attribute is required (that is, must be supported
	/// but not mandatory. originalText may be specified if code is not entered.
	/// Currently this class does nothing with codeSystem or originalText. Therefore it is
	/// identical to the CS class.
	/// </remarks>
	[DataTypeHandler(new string[] { "CV", "CD", "CE", "CS" })]
	public class CvElementParser : AbstractCodeTypeElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new CVImpl();
		}

		protected override Code ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			throw new NotSupportedException("Nothing should be calling this method.");
		}

		protected override Code ParseNonNullCodeNode(ParseContext context, string codeAttributeName, XmlNode node, BareANY result
			, Type expectedReturnType, XmlToModelResult xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			PerformStandardValidations(context, element, xmlToModelResult);
			Type codeType = GetReturnTypeAsCodeType(expectedReturnType);
			Code code = GetCorrespondingCode(context, element, codeType, xmlToModelResult, codeAttributeName);
			PopulateOriginalText(result, context, (XmlElement)node, GetReturnType(context), xmlToModelResult);
			AddTranslations(context, element, (CD)result, expectedReturnType, xmlToModelResult);
			AddDisplayName(element, (CD)result);
			// this is not the usual way of doing things; this is to make validation easier
			((BareANYImpl)result).BareValue = code;
			return code;
		}

		private void PerformStandardValidations(ParseContext context, XmlElement element, XmlToModelResult result)
		{
			if (StandardDataType.CS.Type.Equals(context.Type))
			{
				ValidateUnallowedAttributes(context.Type, element, result, AbstractCodeTypeElementParser.CODE_SYSTEM_ATTRIBUTE_NAME);
			}
			ValidateUnallowedAttributes(context.Type, element, result, "codeSystemName");
			ValidateUnallowedAttributes(context.Type, element, result, "codeSystemVersion");
			ValidateUnallowedChildNode(context.Type, element, result, "qualifier");
		}

		private bool IsInterface(Type codeType)
		{
			return codeType.IsInterface;
		}

		private Code GetCorrespondingCode(ParseContext context, XmlElement element, Type codeType, XmlToModelResult xmlToModelResult
			, string codeAttributeName)
		{
			string code = GetAttributeValue(element, codeAttributeName);
			string codeSystem = GetAttributeValue(element, AbstractCodeTypeElementParser.CODE_SYSTEM_ATTRIBUTE_NAME);
			if (StandardDataType.CS.Type.Equals(context.Type))
			{
				if (codeSystem != null)
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "CS should not include the 'codeSystem' property. ("
						 + XmlDescriber.DescribeSingleElement(element) + ")", element));
				}
			}
			else
			{
				if (StringUtils.IsNotBlank(code) && StringUtils.IsBlank(codeSystem))
				{
					xmlToModelResult.AddHl7Error(CreateMissingCodeSystemError(element, codeType, code));
				}
			}
			Code result = GetCode(codeType, code, codeSystem);
			// if a code is specified and there is no matching enum value for it,
			// something is seriously wrong
			if (StringUtils.IsNotBlank(code) && result == null)
			{
				xmlToModelResult.AddHl7Error(CreateInvalidCodeError(element, codeType, code));
			}
			// the following code will preserve the codeSystem even if the actual code can not be found
			if (result == null && !StringUtils.IsEmpty(codeSystem) && IsInterface(codeType))
			{
				result = FullCodeWrapper.Wrap(codeType, null, codeSystem);
			}
			return result;
		}

		private Code GetCode(Type expectedReturnType, string codeValue, string codeSystem)
		{
			Type returnType = GetReturnTypeAsCodeType(expectedReturnType);
			CodeResolver resolver = CodeResolverRegistry.GetResolver(returnType);
			return resolver.Lookup<Code>(returnType, codeValue, codeSystem);
		}

		private void AddDisplayName(XmlElement element, CD result)
		{
			string displayName = GetAttributeValue(element, "displayName");
			result.DisplayName = displayName;
		}

		private void AddTranslations(ParseContext context, XmlElement element, CD result, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			XmlNodeList translations = element.GetElementsByTagName("translation");
			for (int i = 0,  length = translations.Count; i < length; i++)
			{
				XmlElement translationElement = (XmlElement)translations.Item(i);
				// only want direct child node translations
				if (translationElement.ParentNode.Equals(element))
				{
					CD parsedTranslation = (CD)DoParse(context, translationElement, xmlToModelResult, true, AbstractCodeTypeElementParser.STANDARD_CODE_ATTRIBUTE_NAME
						);
					if (parsedTranslation != null)
					{
						result.Translations.Add(parsedTranslation);
					}
				}
			}
		}
	}
}
