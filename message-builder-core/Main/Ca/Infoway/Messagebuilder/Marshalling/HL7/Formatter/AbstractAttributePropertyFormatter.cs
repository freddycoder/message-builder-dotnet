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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// Represents an object as a single-level element with only attributes, comme ca:
	/// &lt;element-name attribute1="value1" /&gt;
	/// Concrete subclasses handle the formatting of attributes.
	/// </summary>
	/// <remarks>
	/// Represents an object as a single-level element with only attributes, comme ca:
	/// &lt;element-name attribute1="value1" /&gt;
	/// Concrete subclasses handle the formatting of attributes.
	/// </remarks>
	public abstract class AbstractAttributePropertyFormatter<V> : AbstractNullFlavorPropertyFormatter<V>
	{
		protected static readonly string EMPTY_STRING = string.Empty;

		internal override string FormatNonNullDataType(FormatContext context, BareANY bareAny, int indentLevel)
		{
			V value = ExtractBareValue(bareAny);
			return CreateElement(context, GetAttributeNameValuePairs(context, value, bareAny), indentLevel, true, true);
		}

		internal override string FormatNonNullValue(FormatContext context, V value, int indentLevel)
		{
			throw new NotSupportedException("Different formatNonNullValue handler used for AbstractAttributePropertyFormatter");
		}

		internal abstract IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, V value, BareANY bareAny);
	}
}
