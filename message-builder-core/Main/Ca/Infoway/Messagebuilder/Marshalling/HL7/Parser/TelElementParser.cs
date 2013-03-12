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
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Impl;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Util.Xml;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	/// <summary>Parses an TEL element into a String.</summary>
	/// <remarks>
	/// Parses an TEL element into a String. The element looks like this:
	/// 
	/// If a value is null, value is replaced by a null flavor. So the element would look
	/// like this:
	/// 
	/// The value attribute is a bit of a pain, since it contains two pieces of information,
	/// the URLScheme and the actual address.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TEL
	/// </remarks>
	[DataTypeHandler(new string[] { "TEL.URI", "TEL.PHONEMAIL", "TEL.ALL", "TEL" })]
	internal class TelElementParser : AbstractSingleElementParser<TelecommunicationAddress>
	{
		private static readonly TelValidationUtils TEL_VALIDATION_UTILS = new TelValidationUtils();

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.XmlToModelTransformationException"></exception>
		protected override TelecommunicationAddress ParseNonNullNode(ParseContext context, XmlNode node, BareANY parseResult, Type
			 expectedReturnType, XmlToModelResult xmlToModelResult)
		{
			ValidateNoChildren(context, node);
			string specializationType = GetSpecializationType(node);
			TelecommunicationAddress telecomAddress = ParseTelecommunicationAddress(node, xmlToModelResult);
			string type = context.Type;
			TEL_VALIDATION_UTILS.ValidateTelecommunicationAddress(telecomAddress, type, specializationType, context.GetVersion(), (XmlElement
				)node, null, xmlToModelResult);
			return telecomAddress;
		}

		private TelecommunicationAddress ParseTelecommunicationAddress(XmlNode node, XmlToModelResult xmlToModelResult)
		{
			string value = GetAttributeValue(node, "value");
			// remove the // that appear after the colon if necessary
			// e.g. file://monkey
			value = value == null ? null : System.Text.RegularExpressions.Regex.Replace(value, "://", ":");
			// anything before the FIRST colon is the URL scheme. Anything after it is the address.
			int colonIndex = value == null ? -1 : value.IndexOf(':');
			string address = null;
			Ca.Infoway.Messagebuilder.Domainvalue.URLScheme urlScheme = null;
			if (colonIndex == -1)
			{
				address = value;
			}
			else
			{
				address = Ca.Infoway.Messagebuilder.StringUtils.Substring(value, colonIndex + 1);
				string urlSchemeString = Ca.Infoway.Messagebuilder.StringUtils.Substring(value, 0, colonIndex);
				urlScheme = CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.URLScheme>(urlSchemeString);
				if (urlScheme == null)
				{
					string message = "Unrecognized URL scheme '" + urlSchemeString + "' in element " + XmlDescriber.DescribePath(node);
					xmlToModelResult.AddHl7Error(new Hl7Error(Hl7ErrorCode.DATA_TYPE_ERROR, message, (XmlElement)node));
				}
			}
			TelecommunicationAddress result = new TelecommunicationAddress();
			result.Address = address;
			result.UrlScheme = urlScheme;
			// handle address uses
			string addressUses = GetAttributeValue(node, "use");
			if (addressUses != null)
			{
				StringTokenizer tokenizer = new StringTokenizer(addressUses);
				while (tokenizer.HasMoreElements())
				{
					result.AddAddressUse(CodeResolverRegistry.Lookup<Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse>(tokenizer
						.NextToken()));
				}
			}
			return result;
		}

		protected override BareANY DoCreateDataTypeInstance(string typeName)
		{
			return new TELImpl();
		}
	}
}
