using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>This is shared by all subclasses of EntityName.</summary>
	/// <remarks>This is shared by all subclasses of EntityName.</remarks>
	public abstract class AbstractEntityNamePropertyFormatter<V> : AbstractNullFlavorPropertyFormatter<V> where V : EntityName
	{
		internal override string FormatNonNullValue(FormatContext context, V value, int indentLevel)
		{
			StringBuilder buffer = new StringBuilder();
			if (value != null)
			{
				buffer.Append(CreateElement(context, GetUseAttributeMap(value), indentLevel, false, false));
				foreach (EntityNamePart namePart in value.Parts)
				{
					AppendNamePart(buffer, namePart);
				}
				buffer.Append(CreateElementClosure(context, 0, true));
			}
			return buffer.ToString();
		}

		private void AppendNamePart(StringBuilder buffer, EntityNamePart namePart)
		{
			string openTag = string.Empty;
			string closeTag = string.Empty;
			if (namePart.Type != null)
			{
				openTag = "<" + namePart.Type.Value + AddQualifier(namePart) + ">";
				closeTag = "</" + namePart.Type.Value + ">";
			}
			buffer.Append(openTag);
			buffer.Append(XmlStringEscape.Escape(namePart.Value));
			buffer.Append(closeTag);
		}

		private string AddQualifier(EntityNamePart namePart)
		{
			return StringUtils.IsNotBlank(namePart.Qualifier) ? " qualifier=\"" + namePart.Qualifier + "\"" : string.Empty;
		}

		protected virtual IDictionary<string, string> GetUseAttributeMap(V value)
		{
			string uses = string.Empty;
			foreach (EntityNameUse entityNameUse in value.Uses)
			{
				uses += uses.Length == 0 ? string.Empty : " ";
				uses += entityNameUse.CodeValue;
			}
			IDictionary<string, string> result = new Dictionary<string, string>();
			if (uses.Length > 0)
			{
				result["use"] = uses;
			}
			return result;
		}
	}
}
