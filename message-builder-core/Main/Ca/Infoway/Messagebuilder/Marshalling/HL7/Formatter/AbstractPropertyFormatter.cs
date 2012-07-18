using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public abstract class AbstractPropertyFormatter : PropertyFormatter
	{
		internal static readonly IDictionary<string, string> EMPTY_ATTRIBUTE_MAP = new Dictionary<string, string>();

		internal static readonly string NULL_FLAVOR_ATTRIBUTE_NAME = "nullFlavor";

		internal static readonly string NULL_FLAVOR_NO_INFORMATION = "NI";

		internal static readonly IDictionary<string, string> NULL_FLAVOR_ATTRIBUTES = new Dictionary<string, string>();

		static AbstractPropertyFormatter()
		{
			NULL_FLAVOR_ATTRIBUTES[NULL_FLAVOR_ATTRIBUTE_NAME] = NULL_FLAVOR_NO_INFORMATION;
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		public virtual string Format(FormatContext formatContext, BareANY dataType)
		{
			return Format(formatContext, dataType, 0);
		}

		/// <exception cref="Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter.ModelToXmlTransformationException"></exception>
		public abstract string Format(FormatContext formatContext, BareANY dataType, int indentLevel);

		protected virtual string CreateElement(FormatContext context, IDictionary<string, string> attributes, int indentLevel, bool
			 close, bool lineBreak)
		{
			if (!IsNullFlavor(attributes))
			{
				if (attributes == null)
				{
					attributes = new Dictionary<string, string>();
				}
				IDictionary<string, string> extraAttributes = CreateSpecializationTypeAttibutesIfNecessary(context);
				// bug 13884 - csharp throws exception if put duplicate key in map; this was occurring when using putAll() instead of below code
				foreach (string key in extraAttributes.Keys)
				{
					attributes.Remove(key);
					attributes[key] = extraAttributes.SafeGet(key);
				}
			}
			return CreateElement(context.GetElementName(), attributes, indentLevel, close, lineBreak);
		}

		protected virtual string CreateElement(string name, IDictionary<string, string> attributes, int indentLevel, bool close, 
			bool lineBreak)
		{
			return XmlRenderingUtils.CreateStartElement(name, attributes, indentLevel, close, lineBreak);
		}

		protected virtual string CreateElementClosure(FormatContext context, int indentLevel, bool lineBreak)
		{
			return XmlRenderingUtils.CreateEndElement(context.GetElementName(), indentLevel, lineBreak);
		}

		protected virtual void ValidateContext(FormatContext context)
		{
		}

		protected virtual IDictionary<string, string> CreateSpecializationTypeAttibutesIfNecessary(FormatContext context)
		{
			IDictionary<string, string> attributes = new Dictionary<string, string>();
			if (context.IsSpecializationType())
			{
				StandardDataType type = StandardDataType.GetByTypeName(context.Type);
				attributes["xsi:type"] = Xmlify(type.TypeName.UnspecializedName);
				attributes["specializationType"] = Xmlify(type.Type);
			}
			return attributes;
		}

		protected virtual bool IsNullFlavor(IDictionary<string, string> attributes)
		{
			return attributes != null && attributes.ContainsKey(NULL_FLAVOR_ATTRIBUTE_NAME);
		}

		public virtual string Xmlify(string type)
		{
			string typeForXml = System.Text.RegularExpressions.Regex.Replace(type, "\\>", string.Empty);
			typeForXml = System.Text.RegularExpressions.Regex.Replace(typeForXml, "\\<", "_");
			return typeForXml;
		}
	}
}
