using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;
using ILOG.J2CsMapping.Text;

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
	[DataTypeHandler(new string[] { "CV", "CD", "CE" })]
	internal class CvElementParser : AbstractCodeTypeElementParser
	{
		private const int MAX_TRANSLATIONS_ALLOWED = 10;

		private static readonly string CODE_SYSTEM_ATTRIBUTE_NAME = "codeSystem";

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new CVImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Code ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			PerformStandardValidations(context, element, xmlToModelResult);
			if (IsCWE(context))
			{
				if (!element.HasAttribute("code") && !HasOriginalText(element))
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Either \"code\" or \"originalText\" property must be provided ({0})."
						, XmlDescriber.DescribeSingleElement(element)), element));
				}
			}
			else
			{
				if (IsCNE(context))
				{
					if (HasOriginalText(element) && !HasValidNullFlavorAttribute(context, element, xmlToModelResult))
					{
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("\"OriginalText\" is not allowed for non-null CNE values. ({0})."
							, XmlDescriber.DescribeSingleElement(element)), element));
					}
				}
			}
			Type codeType = GetReturnTypeAsCodeType(expectedReturnType);
			Code code = GetCorrespondingCode(context, element, codeType, xmlToModelResult);
			AddTranslations(context, element, (CD)result, expectedReturnType, xmlToModelResult);
			return code;
		}

		private void PerformStandardValidations(ParseContext context, XmlElement element, XmlToModelResult result)
		{
			ValidateUnallowedAttributes(context.Type, element, result, "codeSystemName");
			ValidateUnallowedAttributes(context.Type, element, result, "codeSystemVersion");
			ValidateUnallowedAttributes(context.Type, element, result, "displayName");
			if (StandardDataType.CV.Type.Equals(context.Type))
			{
				ValidateUnallowedChildNode(context.Type, element, result, "translation");
				ValidateUnallowedChildNode(context.Type, element, result, "qualifier");
			}
			else
			{
				if (StandardDataType.CD.Type.Equals(context.Type))
				{
					ValidateUnallowedChildNode(context.Type, element, result, "qualifier");
				}
			}
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override NullFlavor ParseNullNode(ParseContext context, XmlNode node, XmlToModelResult xmlToModelResult)
		{
			NullFlavor nullFlavor = base.ParseNullNode(context, node, xmlToModelResult);
			if (!HasOriginalText((XmlElement)node) && IsOtherNullFlavor(nullFlavor) && IsCNE(context))
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("Data type \"{0}\" with coding strength of \"{1}\" "
					 + "must include <originalText> if nullFlavor is \"OTH\" ({2})", context.Type, context.GetCodingStrength(), XmlDescriber
					.DescribeSingleElement((XmlElement)node)), (XmlElement)node));
			}
			return nullFlavor;
		}

		private bool IsOtherNullFlavor(NullFlavor nullFlavor)
		{
			return Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER == nullFlavor;
		}

		private bool IsInterface(Type codeType)
		{
			return codeType.IsInterface;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		private Code GetCorrespondingCode(ParseContext context, XmlElement element, Type codeType, XmlToModelResult xmlToModelResult
			)
		{
			string code = IsMandatory(context) && IsCNE(context) ? GetMandatoryAttributeValue(element, "code", xmlToModelResult) : GetAttributeValue
				(element, "code");
			string codeSystem = (IsMandatory(context) && IsCNE(context)) || StringUtils.IsNotBlank(code) ? GetMandatoryAttributeValue
				(element, CODE_SYSTEM_ATTRIBUTE_NAME, xmlToModelResult) : GetAttributeValue(element, CODE_SYSTEM_ATTRIBUTE_NAME);
			Code result = GetCode(codeType, code, codeSystem);
			// if a code is specified and there is no matching enum value for it,
			// something is seriously wrong
			if (StringUtils.IsNotBlank(code) && result == null)
			{
				xmlToModelResult.AddHl7Error(CreateHl7Error(element, codeType, code));
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

		private bool IsCNE(ParseContext context)
		{
			return context.GetCodingStrength() == CodingStrength.CNE;
		}

		private bool IsCWE(ParseContext context)
		{
			return context.GetCodingStrength() == CodingStrength.CWE;
		}

		private bool IsMandatory(ParseContext context)
		{
			return context.GetConformance() == Ca.Infoway.Messagebuilder.Xml.ConformanceLevel.MANDATORY;
		}

		private void AddTranslations(ParseContext context, XmlElement element, CD result, Type expectedReturnType, XmlToModelResult
			 xmlToModelResult)
		{
			XmlNodeList translations = element.GetElementsByTagName("translation");
			int translationCount = 0;
			for (int i = 0,  length = translations.Count; i < length; i++)
			{
				XmlElement translationElement = (XmlElement)translations.Item(i);
				// only want direct child node translations
				if (translationElement.ParentNode.Equals(element))
				{
					translationCount++;
					ValidateTranslation(context, (XmlElement)translationElement, xmlToModelResult);
					Code translation = ExtractCodeFromTranslation(translationElement, expectedReturnType, xmlToModelResult);
					if (translation != null)
					{
						CD hl7Translation = new CVImpl();
						hl7Translation.Value = translation;
						hl7Translation.DataType = result.DataType;
						result.Translations.Add(hl7Translation);
					}
				}
			}
			if (translationCount > MAX_TRANSLATIONS_ALLOWED)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("A maximum of {0} translations are allowed for any given code."
					, MAX_TRANSLATIONS_ALLOWED), element));
			}
		}

		private Code ExtractCodeFromTranslation(XmlElement element, Type expectedReturnType, XmlToModelResult xmlToModelResult)
		{
			string code = GetMandatoryAttributeValue(element, "code", xmlToModelResult);
			string codeSystem = GetMandatoryAttributeValue(element, CODE_SYSTEM_ATTRIBUTE_NAME, xmlToModelResult);
			Type codeType = GetReturnTypeAsCodeType(expectedReturnType);
			Code translation = GetCode(codeType, code, codeSystem);
			// if a code is specified and there is no matching enum value for it, something is seriously wrong
			if (StringUtils.IsNotBlank(code) && translation == null)
			{
				xmlToModelResult.AddHl7Error(CreateHl7Error((XmlNode)element, codeType, code));
			}
			return translation;
		}

		private void ValidateTranslation(ParseContext context, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			PerformStandardValidations(context, element, xmlToModelResult);
			ValidateUnallowedAttributes(context.Type, element, xmlToModelResult, "nullFlavor");
			ValidateUnallowedChildNode(context.Type, element, xmlToModelResult, "originalText");
			ValidateUnallowedChildNode(context.Type, element, xmlToModelResult, "translation");
		}
	}
}
