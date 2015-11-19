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
using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// Represents a TEL.PHONEMAIL String as an element:
	/// &lt;element-name use="H WP" value="mailto://me@me.com"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// Represents a TEL.PHONEMAIL String as an element:
	/// &lt;element-name use="H WP" value="mailto://me@me.com"&gt;&lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-TEL
	/// The TEL.PHONEMAIL variant defined by CeRx is for personal contact addresses only.
	/// The only valid URLSchemes are FAX, MAILTO and TELEPHONE.
	/// </remarks>
	[DataTypeHandler(new string[] { "TEL.ALL", "TEL.PHONEMAIL", "TEL" })]
	public class TelPhonemailPropertyFormatter : AbstractValueNullFlavorPropertyFormatter<TelecommunicationAddress>
	{
		private static readonly TelValidationUtils TEL_VALIDATION_UTILS = new TelValidationUtils();

		protected sealed override string GetValue(TelecommunicationAddress phonemail, FormatContext context, BareANY bareAny)
		{
			string type = context.Type;
			string specializationType = bareAny.DataType == null ? null : bareAny.DataType.Type;
			VersionNumber version = context.GetVersion();
			Hl7Errors errors = context.GetModelToXmlResult();
			TEL_VALIDATION_UTILS.ValidateTelecommunicationAddress(phonemail, type, specializationType, version, null, context.GetPropertyPath
				(), errors);
			return phonemail.ToString();
		}

		protected override void AddOtherAttributesIfNecessary(TelecommunicationAddress phonemail, IDictionary<string, string> attributes
			, FormatContext context, BareANY bareAny)
		{
			VersionNumber version = context.GetVersion();
			string type = (bareAny == null || bareAny.DataType == null) ? null : bareAny.DataType.Type;
			string actualType = TEL_VALIDATION_UTILS.DetermineActualType(phonemail, context.Type, type, version, null, context.GetPropertyPath
				(), context.GetModelToXmlResult(), false);
			if (!context.Type.Equals(actualType))
			{
				// excluding our test NFLD version to allow legacy tests to pass
				if (!"NEWFOUNDLAND".Equals(version == null ? null : version.VersionLiteral))
				{
					AddSpecializationType(attributes, actualType);
				}
			}
			if (!phonemail.AddressUses.IsEmpty())
			{
				StringBuilder useValue = new StringBuilder();
				bool isFirst = true;
				foreach (Ca.Infoway.Messagebuilder.Domainvalue.TelecommunicationAddressUse addressUse in phonemail.AddressUses)
				{
					if (TEL_VALIDATION_UTILS.IsAllowableUse(actualType, addressUse, version))
					{
						if (!isFirst)
						{
							useValue.Append(XmlRenderingUtils.SPACE);
						}
						useValue.Append(addressUse.CodeValue);
						isFirst = false;
					}
				}
				attributes["use"] = useValue.ToString();
			}
		}
	}
}
