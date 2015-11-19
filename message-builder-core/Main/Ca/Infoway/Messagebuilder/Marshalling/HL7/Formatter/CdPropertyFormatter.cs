using System.Collections.Generic;
using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	/// <summary>
	/// CS - Coded Simple
	/// Formats a enum into a CS element.
	/// </summary>
	/// <remarks>
	/// CS - Coded Simple
	/// Formats a enum into a CS element. The element looks like this:
	/// &lt;element-name code="RECENT"/&gt;
	/// According to CeRx: code has a limit of 20 characters. This limit is not
	/// currently enforced by this class.
	/// HL7 implies that variations on this type may use a different name than "code" for
	/// the attribute. The use in the controlActProcess is given as an example.
	/// http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#dtimpl-CS
	/// </remarks>
	[DataTypeHandler(new string[] { "CD", "CE" })]
	internal class CdPropertyFormatter : AbstractCodePropertyFormatter
	{
		protected override IDictionary<string, string> GetAttributeNameValuePairs(FormatContext context, Code code, BareANY bareAny
			)
		{
			IDictionary<string, string> result = base.GetAttributeNameValuePairs(context, code, bareAny);
			if (code != null)
			{
				if (StringUtils.IsNotBlank(code.CodeSystem))
				{
					result["codeSystem"] = code.CodeSystem;
				}
				ANYMetaData anyCd = (ANYMetaData)bareAny;
				if (StringUtils.IsNotBlank(anyCd.DisplayName))
				{
					result["displayName"] = anyCd.DisplayName;
				}
			}
			return result;
		}

		protected override bool HasChildContent(CD cd, FormatContext context)
		{
			return HasTranslations(cd) || base.HasChildContent(cd, context);
		}

		private bool HasTranslations(CD cd)
		{
			return !cd.Translations.IsEmpty();
		}

		protected override void CreateChildContent(CD cd, StringBuilder result)
		{
			base.CreateChildContent(cd, result);
			if (HasTranslations(cd))
			{
				foreach (CD translation in cd.Translations)
				{
					IDictionary<string, string> attributes = new Dictionary<string, string>();
					attributes["code"] = translation.Value.CodeValue;
					attributes["codeSystem"] = translation.Value.CodeSystem;
					result.Append(CreateElement("translation", attributes, 0, true, false));
				}
			}
		}
	}
}
