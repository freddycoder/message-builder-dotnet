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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Xml.Util;
using ILOG.J2CsMapping.Text;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.R2
{
	/// <summary>
	/// ST - String
	/// Parses an ST element into a String.
	/// </summary>
	/// <remarks>
	/// ST - String
	/// Parses an ST element into a String. The element looks like this:
	/// This is some text
	/// Returns the value of the text node, or null if there is no node.
	/// HL7 defines other attributes, but notes that they are optional since
	/// the values are self-evident (representation="TXT" mediaType="text/plain").
	/// The CeRx documentation makes no mention of these attributes.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-ST
	/// </remarks>
	[DataTypeHandler("ST")]
	internal class StR2ElementParser : AbstractSingleElementParser<string>
	{
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override string ParseNonNullNode(ParseContext context, XmlNode node, BareANY dataType, Type returnType, XmlToModelResult
			 xmlToModelResult)
		{
			XmlElement element = (XmlElement)node;
			// could have language (if so, must be nonblank); don't know if language only restricted to certain types
			// must have text (NF would have been processed elsewhere)
			// TM: incoming xml should have mediaType=\"text/plain\" and representation=\"TXT\", but not currently validating this
			if (HasLanguageAttribute(element) && GetLanguage(element) == null)
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("For ST, the language attribute, if provided, can not be blank."
					, XmlDescriber.DescribeSingleElement(element)), element));
			}
			string result = null;
			int childNodeCount = node.ChildNodes.Count;
			if (childNodeCount == 0)
			{
				if (ConformanceLevelUtil.IsMandatory(context.GetConformance(), context.GetCardinality()))
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("The string value should not be empty ({0})"
						, XmlDescriber.DescribeSingleElement(element)), element));
				}
				// this is an empty node, return empty string (null should have a null flavor attribute)
				result = AbstractSingleElementParser<string>.EMPTY_STRING;
			}
			else
			{
				if (childNodeCount == 1)
				{
					XmlNode childNode = node.FirstChild;
					if (childNode.NodeType != System.Xml.XmlNodeType.Text && childNode.NodeType != System.Xml.XmlNodeType.CDATA)
					{
						// RM18422 - decided to allow for CDATA section within ST datatypes (other datatypes - AD, ON, PN, SC, TN - still restrict to TEXT only)
						throw new XmlToModelTransformationException("Expected ST node to have a text node");
					}
					if (childNode.NodeType == System.Xml.XmlNodeType.CDATA)
					{
						((ST)dataType).IsCdata = true;
					}
					result = childNode.Value;
				}
				else
				{
					throw new XmlToModelTransformationException("Expected ST node to have at most one child");
				}
			}
			if (context.GetLength() != null && result.Length > context.GetLength())
			{
				xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, System.String.Format("The specified string (\"{0}\") exceeds the maximum length of {1}.  The string has been truncated."
					, Truncate(result, 50), context.GetLength()), element));
				result = StringUtils.Left(result, context.GetLength());
			}
			if (HasLanguageAttribute(element))
			{
				string language = GetLanguage(node);
				// this cast is safe - it will always be an STImpl due to the doCreateDataTypeInstance() method
				((STImpl)dataType).Language = language;
			}
			return result;
		}

		private string GetLanguage(XmlNode node)
		{
			string language = ((XmlElement)node).GetAttribute("language");
			return StringUtils.TrimToNull(language);
		}

		private string Truncate(string text, Int32? length)
		{
			if (StringUtils.IsBlank(text))
			{
				return string.Empty;
			}
			else
			{
				if (text.Length > length)
				{
					return StringUtils.Substring(text, 0, length - 3) + "...";
				}
				else
				{
					return text;
				}
			}
		}

		private bool HasLanguageAttribute(XmlElement element)
		{
			return element.HasAttribute("language");
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new STImpl();
		}
	}
}
