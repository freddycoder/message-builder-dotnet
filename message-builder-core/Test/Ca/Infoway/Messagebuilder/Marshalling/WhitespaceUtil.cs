using System.Text;
using Ca.Infoway.Messagebuilder;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public abstract class WhitespaceUtil
	{
		public static string NormalizeWhitespace(string xml)
		{
			StringBuilder builder = new StringBuilder();
			bool text = true;
			for (StringTokenizer tokenizer = new StringTokenizer(xml, "<>", true); tokenizer.HasMoreTokens(); )
			{
				string token = tokenizer.NextToken();
				if ("<".Equals(token))
				{
					text = false;
					builder.Append(token);
				}
				else
				{
					if (">".Equals(token))
					{
						text = true;
						builder.Append(token);
					}
					else
					{
						if (!text || StringUtils.IsNotBlank(token))
						{
							builder.Append(token);
						}
					}
				}
			}
			return builder.ToString().Trim();
		}
	}
}
