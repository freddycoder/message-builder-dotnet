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

		protected override string FormatNonNullDataType(FormatContext context, BareANY bareAny, int indentLevel)
		{
			V value = ExtractBareValue(bareAny);
			return CreateElement(context, GetAttributeNameValuePairs(context, value, bareAny), indentLevel, true, true);
		}

		protected override string FormatNonNullValue(FormatContext context, V value, int indentLevel)
		{
			throw new NotSupportedException("Different formatNonNullValue handler used for AbstractAttributePropertyFormatter");
		}

		protected abstract IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, V value, BareANY bareAny
			);
	}
}
