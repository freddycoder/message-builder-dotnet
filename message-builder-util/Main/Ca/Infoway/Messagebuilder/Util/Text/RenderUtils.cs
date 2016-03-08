using System.Text;
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Util.Text
{
	public class RenderUtils
	{
		public static string RemoveJavaEscapedCharacters(string @string)
		{
			if (StringUtils.Contains(@string, '\\'))
			{
				StringBuilder buffer = new StringBuilder();
				char[] charArray = @string.ToCharArray();
				for (int i = 0; i < charArray.Length; i++)
				{
					if (charArray[i] == '\\')
					{
						if (i < charArray.Length - 1 && charArray[i] == 'u')
						{
							i += 4;
						}
						else
						{
							// skip unicode value
							i += 3;
						}
					}
					else
					{
						//skip octal value
						buffer.Append(charArray[i]);
					}
				}
				return buffer.ToString();
			}
			return @string;
		}
	}
}
