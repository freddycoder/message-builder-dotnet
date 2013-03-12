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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// Formats some nullable object into element:
	/// &lt;element-name value="value" /&gt;
	/// If an object is null, value is replaced by a nullFlavor.
	/// </summary>
	/// <remarks>
	/// Formats some nullable object into element:
	/// &lt;element-name value="value" /&gt;
	/// If an object is null, value is replaced by a nullFlavor. So the element would look
	/// like this:
	/// &lt;element-name nullFlavor="something" /&gt;
	/// This class uses the "no information" null flavor for nulls it gets.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CS
	/// </remarks>
	public abstract class AbstractValueNullFlavorPropertyFormatter<V> : AbstractAttributePropertyFormatter<V>
	{
		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, V t, BareANY bareAny)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (t != null)
			{
				result["value"] = GetValue(t, context, bareAny);
				AddOtherAttributesIfNecessary(t, result, context, bareAny);
			}
			else
			{
				NullFlavor providedNullFlavor = bareAny.NullFlavor;
				result[AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME] = providedNullFlavor == null ? AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION
					 : providedNullFlavor.CodeValue;
			}
			return result;
		}

		protected abstract string GetValue(V v, FormatContext context, BareANY bareAny);

		protected virtual void AddOtherAttributesIfNecessary(V v, IDictionary<string, string> attributes, FormatContext context, 
			BareANY bareAny)
		{
		}
		// no-op in superclass
	}
}
