using System.Text;

namespace Ca.Infoway.Messagebuilder.Lang
{
	public class XmlStringEscape
	{
		public static string Escape(string str)
		{
			StringBuilder builder = new StringBuilder();
			int len = str == null ? 0 : str.Length;
			for (int i = 0; i < len; i++)
			{
				char c = str[i];
				string entityName = EntityName(c);
				if (entityName == null)
				{
					if (c > unchecked((int)(0x7F)))
					{
						builder.Append("&#");
						int ascii = c;
						builder.Append(ascii);
						builder.Append(';');
					}
					else
					{
						builder.Append(c);
					}
				}
				else
				{
					builder.Append('&');
					builder.Append(entityName);
					builder.Append(';');
				}
			}
			return builder.ToString();
		}

		private static string EntityName(char c)
		{
			switch (c)
			{
				case '\'':
				{
					return "apos";
				}

				case '&':
				{
					return "amp";
				}

				case '<':
				{
					return "lt";
				}

				case '>':
				{
					return "gt";
				}

				case '"':
				{
					return "quot";
				}

				default:
				{
					break;
				}
			}
			//			return null; // moved outside of switch for c# translation
			return null;
		}
	}
}
