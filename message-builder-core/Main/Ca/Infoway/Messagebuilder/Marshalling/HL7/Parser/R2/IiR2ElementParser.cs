using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Constraints;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// II - Installer Identifier
	/// Parses an II element into a II object.
	/// </summary>
	/// <remarks>
	/// II - Installer Identifier
	/// Parses an II element into a II object. The element looks like this:
	/// 
	/// CeRx standards claim that both attributes are required, although extension
	/// is sometimes unused.
	/// The HL7 standard defines the assigningAuthorityName attribute, but that
	/// has been left out of the CeRx implementation.
	/// According to CeRx: Root has a limit of 100 characters, extension of 20
	/// characters. These limits are not currently enforced by this class.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-II
	/// </remarks>
	[DataTypeHandler("II")]
	internal class IiR2ElementParser : AbstractSingleElementParser<Identifier>
	{
		private static readonly IiValidationUtils iiValidationUtils = new IiValidationUtils();

		private readonly IiConstraintsHandler constraintsHandler = new IiConstraintsHandler();

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new IIImpl();
		}

		protected override Identifier ParseNonNullNode(ParseContext context, XmlNode node, BareANY bareAny, Type returnType, XmlToModelResult
			 result)
		{
			XmlElement element = (XmlElement)node;
			string root = GetMandatoryAttributeValue(element, "root", result);
			string extension = GetAttributeValue(element, "extension");
			string assigningAuthorityName = GetAttributeValue(element, "assigningAuthorityName");
			string displayable = GetAttributeValue(element, "displayable");
			ValidateII(result, element, root, extension, assigningAuthorityName, displayable);
			Identifier identifier = new Identifier(root, extension);
			identifier.AssigningAuthorityName = assigningAuthorityName;
			identifier.Displayable = displayable;
			HandleConstraints(context, result, element, identifier);
			return identifier;
		}

		private void HandleConstraints(ParseContext context, Hl7Errors errors, XmlElement element, Identifier identifier)
		{
			ErrorLogger logger = new _ErrorLogger_97(errors, element);
			this.constraintsHandler.HandleConstraints(context.GetConstraints(), identifier, logger, IsSingleCardinality(context.GetCardinality
				()));
		}

		private sealed class _ErrorLogger_97 : ErrorLogger
		{
			public _ErrorLogger_97(Hl7Errors errors, XmlElement element)
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

		private bool IsSingleCardinality(Cardinality cardinality)
		{
			return cardinality == null ? true : cardinality.Single;
		}

		private void ValidateII(XmlToModelResult xmlToModelResult, XmlElement element, string root, string extension, string assigningAuthorityName
			, string displayable)
		{
			ValidateRootAsOidOrUuidOrRuid(xmlToModelResult, element, root);
		}

		private void ValidateRootAsOidOrUuidOrRuid(XmlToModelResult xmlToModelResult, XmlElement element, string root)
		{
			// if root has not been provided don't bother further validating
			if (StringUtils.IsNotBlank(root))
			{
				if (!(iiValidationUtils.IsOid(root, true) || iiValidationUtils.IsUuid(root) || iiValidationUtils.IsRuid(root)))
				{
					RecordError(iiValidationUtils.GetRootMustBeUuidRuidOidErrorMessage(root), element, xmlToModelResult);
				}
			}
		}

		private void RecordError(string message, XmlElement element, XmlToModelResult xmlToModelResult)
		{
			xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message + " (" + XmlDescriber.DescribeSingleElement
				(element) + ")", element));
		}
	}
}
