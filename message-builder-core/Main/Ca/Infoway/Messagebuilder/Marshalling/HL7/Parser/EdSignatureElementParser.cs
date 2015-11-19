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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using System.Xml;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Error;
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

		// Note that the behaviour for this datatype has not been fully defined by CHI. It is likely that the code below will need to be adjusted at some point.
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override string ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			StandardDataType type = StandardDataType.GetByTypeName(context);
			ValidateUnallowedAttributes(type, (XmlElement)node, xmlToModelResult, "compression");
			ValidateUnallowedAttributes(type, (XmlElement)node, xmlToModelResult, "language");
			ValidateUnallowedAttributes(type, (XmlElement)node, xmlToModelResult, "reference");
			ValidateUnallowedAttributes(type, (XmlElement)node, xmlToModelResult, "integrityCheck");
			ValidateUnallowedAttributes(type, (XmlElement)node, xmlToModelResult, "thumbnail");
			ValidateMaxChildCount(context, node, 1);
			if (!Ca.Infoway.Messagebuilder.Domainvalue.Basic.MediaType.XML_TEXT.CodeValue.Equals(GetAttributeValue(node, "mediaType")
				))
			{
				xmlToModelResult.AddHl7Error(CreateHl7Error("Attribute mediaType must be included with a value of \"text/xml\" for ED.SIGNATURE"
					, (XmlElement)node));
			}
			string result = null;
			XmlNode signatureNode = GetNamedChildNode(node, "signature");
			if (signatureNode == null || signatureNode.NodeType != System.Xml.XmlNodeType.Element)
			{
				xmlToModelResult.AddHl7Error(CreateHl7Error("Expected ED.SIGNATURE node to have a child element named signature", (XmlElement
					)node));
			}
			else
			{
				result = (string)this.stElementParser.Parse(context, signatureNode, xmlToModelResult).BareValue;
			}
			return result;
		}

		private Hl7Error CreateHl7Error(string errorMessage, XmlElement element)
		{
			return new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, errorMessage, element);
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new EDImpl<string>();
		}
	}
}
