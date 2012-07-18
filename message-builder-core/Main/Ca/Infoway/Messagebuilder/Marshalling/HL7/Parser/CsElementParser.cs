using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// CS - Coded Simple
	/// Parses an CS element into a CS enum field.
	/// </summary>
	/// <remarks>
	/// CS - Coded Simple
	/// Parses an CS element into a CS enum field. The element looks like this:
	/// 
	/// According to CeRx: code has a limit of 20 characters. This limit is not
	/// currently enforced by this class.
	/// CeRx has nothing to say about whether code is mandatory or not.
	/// HL7 implies that variations on this type may use a different name than "code"
	/// for the attribute. The use in the controlActProcess is given as an example.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CS
	/// </remarks>
	[DataTypeHandler("CS")]
	public class CsElementParser : AbstractCodeTypeElementParser
	{
		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new CSImpl();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override Code ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			ValidateUnallowedAttributes(context.Type, element, xmlToModelResult, "codeSystem");
			ValidateUnallowedAttributes(context.Type, element, xmlToModelResult, "codeSystemName");
			ValidateUnallowedAttributes(context.Type, element, xmlToModelResult, "codeSystemVersion");
			ValidateUnallowedAttributes(context.Type, element, xmlToModelResult, "displayName");
			ValidateUnallowedChildNode(context.Type, element, xmlToModelResult, "originalText");
			ValidateUnallowedChildNode(context.Type, element, xmlToModelResult, "translation");
			ValidateUnallowedChildNode(context.Type, element, xmlToModelResult, "qualifier");
			Type returnType = GetReturnTypeAsCodeType(expectedReturnType);
			Code result = (Code)ParseCodedSimpleValue(GetAttributeValue(element, "code"), returnType, element, xmlToModelResult, null
				);
			return result;
		}

		public virtual Code ParseCodedSimpleValue(string code, Type returnType, XmlElement @base, XmlToModelResult xmlToModelResult
			, XmlAttribute attr)
		{
			if (StringUtils.IsBlank(code))
			{
				xmlToModelResult.AddHl7Error(Hl7Error.CreateEmptyCodeValueError(@base, attr));
				return null;
			}
			else
			{
				Code result = CodeResolverRegistry.Lookup(returnType, code);
				if (result == null)
				{
					xmlToModelResult.AddHl7Error(CreateHl7Error(@base, returnType, code));
				}
				return result;
			}
		}
	}
}
