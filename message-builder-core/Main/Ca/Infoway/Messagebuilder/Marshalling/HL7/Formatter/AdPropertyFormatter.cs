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
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// AD - Address
	/// Represents an Address object as an element:
	/// &lt;addr use='WP'&gt;
	/// &lt;houseNumber&gt;1050&lt;/houseNumber&gt;
	/// &lt;direction&gt;W&lt;/direction&gt;
	/// &lt;streetName&gt;Wishard Blvd&lt;/streetName&gt;,
	/// &lt;additionalLocator&gt;RG 5th floor&lt;/additionalLocator&gt;,
	/// &lt;city&gt;Indianapolis&lt;/city&gt;, &lt;state&gt;IN&lt;/state&gt;
	/// &lt;postalCode&gt;46240&lt;/postalCode&gt;
	/// &lt;/addr&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// AD - Address
	/// Represents an Address object as an element:
	/// &lt;addr use='WP'&gt;
	/// &lt;houseNumber&gt;1050&lt;/houseNumber&gt;
	/// &lt;direction&gt;W&lt;/direction&gt;
	/// &lt;streetName&gt;Wishard Blvd&lt;/streetName&gt;,
	/// &lt;additionalLocator&gt;RG 5th floor&lt;/additionalLocator&gt;,
	/// &lt;city&gt;Indianapolis&lt;/city&gt;, &lt;state&gt;IN&lt;/state&gt;
	/// &lt;postalCode&gt;46240&lt;/postalCode&gt;
	/// &lt;/addr&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-AD
	/// </remarks>
	[DataTypeHandler("AD")]
	internal class AdPropertyFormatter : AbstractAdPropertyFormatter
	{
		protected sealed override string FormatNonNullValue(FormatContext context, PostalAddress postalAddress, int indentLevel)
		{
			AbstractAdPropertyFormatter.AD_VALIDATION_UTILS.ValidatePostalAddress(postalAddress, context.Type, context.GetVersion(), 
				null, context.GetPropertyPath(), context.GetModelToXmlResult());
			return base.FormatNonNullValue(context, postalAddress, indentLevel);
		}
	}
}
