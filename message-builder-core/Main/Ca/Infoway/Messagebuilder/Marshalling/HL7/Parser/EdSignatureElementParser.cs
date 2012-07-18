using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// ED.SIGNATURE - Encapsulated Data (Signature)
	/// Parses a ED.SIGNATURE element into a String:
	/// 
	/// signatureString
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// This appears to be correct, although all of the examples name the outer element as "text".
	/// </summary>
	/// <remarks>
	/// ED.SIGNATURE - Encapsulated Data (Signature)
	/// Parses a ED.SIGNATURE element into a String:
	/// 
	/// signatureString
	/// 
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// This appears to be correct, although all of the examples name the outer element as "text".
	/// CeRx notes that this is an evolving standard.
	/// </remarks>
	[DataTypeHandler("ED.SIGNATURE")]
	internal class EdSignatureElementParser : AbstractSingleElementParser<string>
	{
		private readonly StElementParser stElementParser = new StElementParser();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override string ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			string result = null;
			XmlNode signatureNode = GetNamedChildNode(node, "signature");
			if (signatureNode == null || signatureNode.NodeType != System.Xml.XmlNodeType.Element)
			{
				xmlToModelResult.AddHl7Error(CreateHl7Error((XmlElement)node));
			}
			else
			{
				result = (string)this.stElementParser.Parse(context, signatureNode, xmlToModelResult).BareValue;
			}
			return result;
		}

		private Hl7Error CreateHl7Error(XmlElement element)
		{
			return new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Expected ED.SIGNATURE node to have a child element named signature", element
				);
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new EDImpl<string>();
		}
	}
}
