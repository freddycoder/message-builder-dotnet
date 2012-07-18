using System.Text;
using Ca.Infoway.Messagebuilder;
using ILOG.J2CsMapping.Util;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	public class Hl7DataTypeName
	{
		private readonly string name;

		private Hl7DataTypeName(string name)
		{
			this.name = name;
		}

		public static Ca.Infoway.Messagebuilder.Marshalling.HL7.Hl7DataTypeName Create(string name)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Hl7DataTypeName(name);
		}

		public virtual Ca.Infoway.Messagebuilder.Marshalling.HL7.Hl7DataTypeName GetUnqualifiedVersion()
		{
			if (IsQualified())
			{
				return Create(Unqualify());
			}
			else
			{
				return this;
			}
		}

		private string Unqualify()
		{
			StringBuilder builder = new StringBuilder();
			for (StringTokenizer tokenizer = new StringTokenizer(this.name, "<,>", true); tokenizer.HasMoreTokens(); )
			{
				string token = tokenizer.NextToken();
				if ("<,>".IndexOf(token) >= 0)
				{
					builder.Append(token);
				}
				else
				{
					if (IsQualified(token))
					{
						builder.Append(StringUtils.SubstringBefore(token, "."));
					}
					else
					{
						builder.Append(token);
					}
				}
			}
			return builder.ToString();
		}

		private bool IsQualified(string token)
		{
			return token.Contains(".");
		}

		public override string ToString()
		{
			return this.name;
		}

		public virtual bool IsQualified()
		{
			return this.name.Contains(".");
		}

		public static string Unqualify(string name)
		{
			return Create(name).GetUnqualifiedVersion().ToString();
		}

		public static string GetTypeWithoutParameters(string name)
		{
			return StringUtils.IsNotBlank(name) && name.Contains("<") ? StringUtils.SubstringBefore(name, "<") : name;
		}

		public static string GetParameterizedType(string type)
		{
			return StringUtils.SubstringBeforeLast(StringUtils.SubstringAfter(type, "<"), ">");
		}
	}
}
