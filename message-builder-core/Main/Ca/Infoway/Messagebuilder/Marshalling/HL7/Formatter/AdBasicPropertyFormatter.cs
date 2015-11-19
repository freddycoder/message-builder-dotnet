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
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Iterator;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// AD.BASIC - Address (Basic)
	/// Represents an Address object as an element:
	/// &lt;element-name use="PHYS"&gt;	&lt;!-- "PHYS" is visit, "PST" is postal, "TMP" is temporary, "H" is home, "WP" is workplace.
	/// </summary>
	/// <remarks>
	/// AD.BASIC - Address (Basic)
	/// Represents an Address object as an element:
	/// &lt;element-name use="PHYS"&gt;	&lt;!-- "PHYS" is visit, "PST" is postal, "TMP" is temporary, "H" is home, "WP" is workplace. --&gt;
	/// 1709 Bloor St W.&lt;delimiter/&gt;
	/// Suite 200&lt;delimiter/&gt;
	/// &lt;city&gt;Toronto&lt;/city&gt;
	/// &lt;state code="ON&gt;Ontario&lt;/state&gt;
	/// &lt;postalCode&gt;A1A 1A1&lt;/postalCode&gt;&lt;delimiter/&gt;
	/// &lt;country code="CA"&gt;Canada&lt;/country&gt;
	/// &lt;/element-name&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-AD
	/// CeRx limits the length of each part to 60 characters. This limit is not enforced by
	/// this class.
	/// It is also quite apparent that the use of the delimiters in the address indicates a
	/// certain level of dementia.
	/// </remarks>
	[DataTypeHandler("AD.BASIC")]
	internal class AdBasicPropertyFormatter : AbstractAdPropertyFormatter
	{
		protected sealed override string FormatNonNullValue(FormatContext context, PostalAddress postalAddress, int indentLevel)
		{
			Hl7BaseVersion baseVersion = context.GetVersion().GetBaseVersion();
			string dataType = context.Type;
			AbstractAdPropertyFormatter.AD_VALIDATION_UTILS.ValidatePostalAddress(postalAddress, dataType, context.GetVersion(), null
				, context.GetPropertyPath(), context.GetModelToXmlResult());
			PostalAddress basicAddress = new PostalAddress();
			StringBuilder builder = new StringBuilder();
			// remove any non-basic address parts
			foreach (PostalAddressPart part in EmptyIterable<object>.NullSafeIterable(postalAddress.Parts))
			{
				if (part.Type == PostalAddressPartType.CITY || part.Type == PostalAddressPartType.STATE || part.Type == PostalAddressPartType
					.COUNTRY || part.Type == PostalAddressPartType.POSTAL_CODE || part.Type == PostalAddressPartType.DELIMITER)
				{
					Flush(builder, basicAddress);
					basicAddress.AddPostalAddressPart(part);
				}
				else
				{
					if (StringUtils.IsNotBlank(part.Value))
					{
						if (builder.Length > 0)
						{
							builder.Append(" ");
						}
						builder.Append(part.Value);
					}
				}
			}
			Flush(builder, basicAddress);
			foreach (Ca.Infoway.Messagebuilder.Domainvalue.PostalAddressUse use in postalAddress.Uses)
			{
				if (AbstractAdPropertyFormatter.AD_VALIDATION_UTILS.IsAllowableUse(dataType, use, baseVersion))
				{
					basicAddress.AddUse(use);
				}
			}
			return base.FormatNonNullValue(context, basicAddress, indentLevel);
		}

		private void Flush(StringBuilder builder, PostalAddress basicAddress)
		{
			if (builder.Length > 0)
			{
				basicAddress.AddPostalAddressPart(new PostalAddressPart(builder.ToString()));
				builder.Length = 0;
			}
		}
	}
}
