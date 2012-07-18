using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Util.Text;

namespace Ca.Infoway.Messagebuilder.Xml.Util
{
	/// <summary>
	/// A utility to format a valid XML comment, used for displaying
	/// XML warnings.
	/// </summary>
	/// <remarks>
	/// A utility to format a valid XML comment, used for displaying
	/// XML warnings.
	/// </remarks>
	/// <author>Intelliware Development</author>
	public class XmlWarningRenderer
	{
		public virtual string CreateWarning(int indentLevel, string text)
		{
			return Indenter.Indent("<!-- WARNING: " + XmlStringEscape.Escape(text) + " -->" + SystemUtils.LINE_SEPARATOR, indentLevel
				);
		}
	}
}
