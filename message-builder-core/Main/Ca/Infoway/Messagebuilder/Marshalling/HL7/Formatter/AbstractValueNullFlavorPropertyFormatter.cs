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
		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, V t, BareANY bareAny)
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
