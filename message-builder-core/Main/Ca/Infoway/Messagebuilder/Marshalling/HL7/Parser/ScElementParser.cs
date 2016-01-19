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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>
	/// SC - Coded String (CS was already taken for coded simple)
	/// Parses an SC element into a CodedString.
	/// </summary>
	/// <remarks>
	/// SC - Coded String (CS was already taken for coded simple)
	/// Parses an SC element into a CodedString. The element looks like this:
	/// Assistant to the Regional Manager
	/// Regional Manager
	/// HL7 defines other optional attributes such as code system version and description.
	/// Currently this class does nothing with codeSystem.
	/// This class is a mix of StElementParser and CvElementParser.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-SC
	/// </remarks>
	[DataTypeHandler("SC")]
	internal class ScElementParser : AbstractSingleElementParser<CodedString<Code>>
	{
		private CodeLookupUtils codeLookupUtils = new CodeLookupUtils();

		private CodedStringValidationUtils codedStringValidationUtils = new CodedStringValidationUtils();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override CodedString<Code> ParseNonNullNode(ParseContext context, XmlNode node, BareANY result, Type expectedReturnType
			, XmlToModelResult xmlToModelResult)
		{
			string value = null;
			int childNodeCount = node.ChildNodes.Count;
			if (childNodeCount == 0)
			{
				// this is an empty node, return empty string (null should have a null flavor attribute)
				value = AbstractSingleElementParser<CodedString<Code>>.EMPTY_STRING;
			}
			else
			{
				if (childNodeCount == 1)
				{
					XmlNode childNode = node.FirstChild;
					if (childNode.NodeType != System.Xml.XmlNodeType.Text)
					{
						xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Expected SC node to have a text node", (XmlElement
							)node));
					}
					value = childNode.Value;
				}
				else
				{
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, "Expected SC node to have at most one child", (XmlElement
						)node));
				}
			}
			string code = GetAttributeValue(node, "code");
			string codeSystem = GetAttributeValue(node, "codeSystem");
			Code lookedUpCode = null;
			if (StringUtils.IsNotBlank(code) && StringUtils.IsNotBlank(codeSystem))
			{
				lookedUpCode = this.codeLookupUtils.GetCorrespondingCode(code, codeSystem, expectedReturnType, (XmlElement)node, context.
					Type, xmlToModelResult);
			}
			string displayName = GetAttributeValue(node, "displayName");
			string codeSystemName = GetAttributeValue(node, "codeSystemName");
			string codeSystemVersion = GetAttributeValue(node, "codeSystemVersion");
			// TM - this cast may not work properly within .NET
			CodedString<Code> codedString = new CodedString<Code>(value, lookedUpCode, displayName, codeSystemName, codeSystemVersion
				);
			bool codeProvided = StringUtils.IsNotBlank(code);
			bool codeSystemProvided = StringUtils.IsNotBlank(codeSystem);
			this.codedStringValidationUtils.ValidateCodedString(codedString, codeProvided, codeSystemProvided, (XmlElement)node, null
				, xmlToModelResult);
			return codedString;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new SCImpl<Code>();
		}
	}
}
