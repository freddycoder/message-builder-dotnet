using System.Text;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.J5goodies;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class TemplateVariableNameUtil
	{
		public static string Transform(string templateParameterName)
		{
			string[] words = StringUtils.Split(CamelCaseUtil.ConvertToWords(templateParameterName));
			if (words.Length == 1 && words[0].Length <= 3)
			{
				return words[0].ToUpper();
			}
			else
			{
				StringBuilder builder = new StringBuilder();
				foreach (string word in words)
				{
					builder.Append(Ca.Infoway.Messagebuilder.StringUtils.Substring(word, 0, 1).ToUpper());
				}
				return builder.ToString();
			}
		}
	}
}
