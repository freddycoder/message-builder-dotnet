using System;
using System.Collections.Generic;
using System.Text;
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

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullDataType(FormatContext context, BareANY bareAny, int indentLevel)
		{
			V value = ExtractBareValue(bareAny);
			ValidateContext(context);
			StringBuilder builder = new StringBuilder();
			if (IsInvalidValue(context, value))
			{
				builder.Append(CreateWarning(indentLevel, CreateWarningText(context, value)));
			}
			builder.Append(CreateElement(context, GetAttributeNameValuePairs(context, value, bareAny), indentLevel, true, true));
			return builder.ToString();
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override string FormatNonNullValue(FormatContext context, V value, int indentLevel)
		{
			throw new NotSupportedException("Different formatNonNullValue handler used for AbstractAttributePropertyFormatter");
		}

		protected virtual string CreateWarningText(FormatContext context, V value)
		{
			return "Value " + value + " is not valid";
		}

		internal virtual bool IsInvalidValue(FormatContext context, V value)
		{
			return false;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal virtual IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, V value, BareANY bareAny)
		{
			return GetAttributeNameValuePairs(context, value);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal virtual IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, V value)
		{
			throw new InvalidOperationException("getAttributeNameValuePairs(FormatContext,T) is not implemented");
		}
	}
}
