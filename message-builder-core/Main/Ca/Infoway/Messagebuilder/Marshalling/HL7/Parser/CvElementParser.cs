using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

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
	/// </remarks>
	[DataTypeHandler(new string[] { "CV", "CD", "CE", "CS" })]
	public class CvElementParser : AbstractCodeTypeElementParser
	{
		private CodeLookupUtils codeLookupUtils = new CodeLookupUtils();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			if ("CD".Equals(typeName))
			{
				return new CDImpl();
			}
			else
			{
				if ("CE".Equals(typeName))
				{
					return new CEImpl();
				}
				else
				{
					if ("CS".Equals(typeName))
					{
						return new CSImpl();
					}
				}
			}
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
			string code = GetAttributeValue(element, codeAttributeName);
			string codeSystem = GetAttributeValue(element, AbstractCodeTypeElementParser.CODE_SYSTEM_ATTRIBUTE_NAME);
			Code actualCode = this.codeLookupUtils.GetCorrespondingCode(code, codeSystem, expectedReturnType, element, context.Type, 
				xmlToModelResult);
			PopulateOriginalText(result, context, (XmlElement)node, xmlToModelResult);
			AddTranslations(context, element, (CD)result, xmlToModelResult);
			AddDisplayName(element, (CD)result);
			// this is not the usual way of doing things; this is to make validation easier
			((BareANYImpl)result).BareValue = actualCode;
			return actualCode;
		}

		private void PerformStandardValidations(ParseContext context, XmlElement element, XmlToModelResult result)
		{
			StandardDataType type = StandardDataType.GetByTypeName(context);
			if (type == StandardDataType.CS)
			{
				ValidateUnallowedAttributes(type, element, result, AbstractCodeTypeElementParser.CODE_SYSTEM_ATTRIBUTE_NAME);
			}
			ValidateUnallowedAttributes(type, element, result, "codeSystemName");
			ValidateUnallowedAttributes(type, element, result, "codeSystemVersion");
			ValidateUnallowedChildNode(context.Type, element, result, "qualifier");
		}

		private void AddDisplayName(XmlElement element, CD result)
		{
			string displayName = GetAttributeValue(element, "displayName");
			result.DisplayName = displayName;
		}

		private void AddTranslations(ParseContext context, XmlElement element, CD result, XmlToModelResult xmlToModelResult)
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
