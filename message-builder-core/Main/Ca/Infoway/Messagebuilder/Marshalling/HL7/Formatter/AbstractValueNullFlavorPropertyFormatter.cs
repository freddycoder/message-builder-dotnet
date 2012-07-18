using System.Collections.Generic;
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
		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		internal override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, V t)
		{
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (t != null)
			{
				result["value"] = GetValue(t, context);
				AddOtherAttributesIfNecessary(t, result);
			}
			else
			{
				result[AbstractPropertyFormatter.NULL_FLAVOR_ATTRIBUTE_NAME] = AbstractPropertyFormatter.NULL_FLAVOR_NO_INFORMATION;
			}
			return result;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected abstract string GetValue(V v, FormatContext context);

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		protected virtual void AddOtherAttributesIfNecessary(V v, IDictionary<string, string> attributes)
		{
		}
		// no-op in superclass
	}
}
