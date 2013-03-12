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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// ED - Encapsulated Data (Document or Reference)
	/// Parses a ED element into an Encapsulated Data:
	/// This is some text.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// This appears to be correct, although all of the examples name the outer element as "text".
	/// </summary>
	/// <remarks>
	/// ED - Encapsulated Data (Document or Reference)
	/// Parses a ED element into an Encapsulated Data:
	/// This is some text.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ED
	/// This appears to be correct, although all of the examples name the outer element as "text".
	/// Note that there are many more variations on this datatype. HTML, XML and PDF data are
	/// all supported. However the current schemas that we work with all define the document
	/// as a String so plain text is all we support at the moment.
	/// </remarks>
	[DataTypeHandler("ED")]
	internal class EdElementParser : AbstractSingleElementParser<EncapsulatedData>
	{
		private EdValidationUtils edValidationUtils = new EdValidationUtils();

		protected override EncapsulatedData ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			ValidateMaxChildCount(context, node, StandardDataType.ED_DOC.Type.Equals(context.Type) ? 2 : 1);
			try
			{
				return Parse((XmlElement)node, context, xmlToModelResult);
			}
			catch (Exception e)
			{
				throw new XmlToModelTransformationException(e);
			}
		}

		private EncapsulatedData Parse(XmlElement element, ParseContext context, XmlToModelResult xmlToModelResult)
		{
			string specializationType = ParseSpecializationType(element);
			Compression compression = ParseCompression(element);
			x_DocumentMediaType mediaType = ParseMediaType(element);
			string language = ParseLanguage(element);
			string representation = ParseRepresentation(element);
			string reference = ParseReference(element);
			byte[] content = ParseContent(element, representation);
			Validate(specializationType, compression, mediaType, language, representation, reference, content, element, context, xmlToModelResult
				);
			if (compression != null)
			{
				return new CompressedData(mediaType, reference, content, compression, language);
			}
			else
			{
				if (mediaType != null || reference != null || content != null)
				{
					return new EncapsulatedData(mediaType, reference, language, content);
				}
				else
				{
					return null;
				}
			}
		}

		private void Validate(string specializationType, Compression compression, x_DocumentMediaType mediaType, string language, 
			string representation, string reference, byte[] content, XmlElement element, ParseContext context, XmlToModelResult xmlToModelResult
			)
		{
			Hl7BaseVersion baseVersion = context.GetVersion().GetBaseVersion();
			string type = context.Type;
			Hl7Errors errors = xmlToModelResult;
			bool hasCompression = element.HasAttribute(EdValidationUtils.ATTRIBUTE_COMPRESSION);
			this.edValidationUtils.DoValidate(specializationType, compression, hasCompression, mediaType, language, representation, reference
				, content, baseVersion, type, element, null, errors);
		}

		private byte[] ParseContent(XmlElement element, string representation)
		{
			byte[] content = null;
			string text = NodeUtil.GetTextValue(element, false);
			if (!StringUtils.IsBlank(text))
			{
				if (EdValidationUtils.REPRESENTATION_B64.EqualsIgnoreCase(representation))
				{
					content = Base64.DecodeBase64String(text);
				}
				else
				{
					content = System.Text.ASCIIEncoding.ASCII.GetBytes(text);
				}
			}
			return content;
		}

		private string ParseRepresentation(XmlElement element)
		{
			if (element.HasAttribute(EdValidationUtils.ATTRIBUTE_REPRESENTATION))
			{
				return element.GetAttribute(EdValidationUtils.ATTRIBUTE_REPRESENTATION);
			}
			return null;
		}

		private string ParseReference(XmlElement element)
		{
			if (element.HasAttribute(EdValidationUtils.ELEMENT_REFERENCE))
			{
				// this format of ED is no longer correct (for any HL7v3 version), contrary to what V01R04.3 and V02R02 data type specifications state
				return element.GetAttribute(EdValidationUtils.ELEMENT_REFERENCE);
			}
			else
			{
				// look for newer format for providing reference within a "value" attribute of a "reference" element
				XmlNodeList elements = element.GetElementsByTagName(EdValidationUtils.ELEMENT_REFERENCE);
				if (elements.Count == 1)
				{
					XmlElement reference = (XmlElement)elements.Item(0);
					if (reference.HasAttribute(EdValidationUtils.ATTRIBUTE_VALUE))
					{
						return reference.GetAttribute(EdValidationUtils.ATTRIBUTE_VALUE);
					}
				}
			}
			return null;
		}

		private string ParseSpecializationType(XmlElement element)
		{
			return GetSpecializationType(element);
		}

		private string ParseLanguage(XmlElement element)
		{
			if (element.HasAttribute(EdValidationUtils.ATTRIBUTE_LANGUAGE))
			{
				return element.GetAttribute(EdValidationUtils.ATTRIBUTE_LANGUAGE);
			}
			return null;
		}

		private Compression ParseCompression(XmlElement element)
		{
			if (element.HasAttribute(EdValidationUtils.ATTRIBUTE_COMPRESSION))
			{
				return Compression.Get(element.GetAttribute(EdValidationUtils.ATTRIBUTE_COMPRESSION));
			}
			return null;
		}

		private x_DocumentMediaType ParseMediaType(XmlElement element)
		{
			if (element.HasAttribute(EdValidationUtils.ATTRIBUTE_MEDIA_TYPE))
			{
				return Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_DocumentMediaType.Get(element.GetAttribute(EdValidationUtils.ATTRIBUTE_MEDIA_TYPE
					));
			}
			return null;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new EDImpl<EncapsulatedData>();
		}
	}
}
