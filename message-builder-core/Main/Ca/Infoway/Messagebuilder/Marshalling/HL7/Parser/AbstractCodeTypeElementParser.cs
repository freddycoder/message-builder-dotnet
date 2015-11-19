using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public abstract class AbstractCodeTypeElementParser : AbstractSingleElementParser<Code>
	{
		protected static readonly string STANDARD_CODE_ATTRIBUTE_NAME = "code";

		protected static readonly string CODE_SYSTEM_ATTRIBUTE_NAME = "codeSystem";

		private static readonly CdValidationUtils CD_VALIDATION_UTILS = new CdValidationUtils();

		private CodedTypesConstraintsHandler constraintsHandler = new CodedTypesConstraintsHandler();

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
				CD_VALIDATION_UTILS.ValidateCodedType(codeAsCd, codeAsString, IsCWE(context), IsCNE(context), isTranslation, false, context
					.Type, context.GetVersion(), (XmlElement)node, null, xmlToModelResult);
				HandleConstraints(codeAsCd.Value, context.GetConstraints(), (XmlElement)node, xmlToModelResult);
			}
			return cd;
		}

		private void HandleConstraints(Code code, ConstrainedDatatype constraints, XmlElement element, Hl7Errors errors)
		{
			// only code/codeSystem passed to constraints handler for now (only qualifier and codeSystem are currently checked for constraints)
			CodedTypeR2<Code> codedType = new CodedTypeR2<Code>(code);
			ErrorLogger logger = new _ErrorLogger_79(errors, element);
			this.constraintsHandler.HandleConstraints(constraints, codedType, logger);
		}

		private sealed class _ErrorLogger_79 : ErrorLogger
		{
			public _ErrorLogger_79(Hl7Errors errors, XmlElement element)
			{
				this.errors = errors;
				this.element = element;
			}

			public void LogError(Hl7ErrorCode errorCode, ErrorLevel errorLevel, string errorMessage)
			{
				errors.AddHl7Error(new Hl7Error(errorCode, errorLevel, errorMessage, element));
			}

			private readonly Hl7Errors errors;

			private readonly XmlElement element;
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

		protected virtual void PopulateOriginalText(BareANY dataType, ParseContext context, XmlElement element, XmlToModelResult 
			xmlToModelResult)
		{
			if (HasOriginalText(element))
			{
				((CD)dataType).OriginalText = GetOriginalText(element);
			}
		}

		protected abstract Code ParseNonNullCodeNode(ParseContext context, string codeAttributeName, XmlNode node, BareANY result
			, Type expectedReturnType, XmlToModelResult xmlToModelResult);
	}
}
