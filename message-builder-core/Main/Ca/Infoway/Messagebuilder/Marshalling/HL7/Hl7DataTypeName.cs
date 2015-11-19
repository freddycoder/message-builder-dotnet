/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System.Collections.Generic;
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

		public virtual Ca.Infoway.Messagebuilder.Marshalling.HL7.Hl7DataTypeName GetUnqualifiedInnerTypesVersion()
		{
			if (IsQualified())
			{
				return Create(UnqualifyInnerTypes());
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

		private string UnqualifyInnerTypes()
		{
			StringBuilder builder = new StringBuilder();
			bool first = true;
			for (StringTokenizer tokenizer = new StringTokenizer(this.name, "<,>", true); tokenizer.HasMoreTokens(); )
			{
				string token = tokenizer.NextToken();
				if ("<,>".IndexOf(token) >= 0)
				{
					builder.Append(token);
				}
				else
				{
					if (IsQualified(token) && !first)
					{
						builder.Append(StringUtils.SubstringBefore(token, "."));
					}
					else
					{
						builder.Append(token);
					}
				}
				first = false;
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

		public virtual IList<Ca.Infoway.Messagebuilder.Marshalling.HL7.Hl7DataTypeName> GetInnerTypes()
		{
			IList<Ca.Infoway.Messagebuilder.Marshalling.HL7.Hl7DataTypeName> innerTypes = new List<Ca.Infoway.Messagebuilder.Marshalling.HL7.Hl7DataTypeName
				>();
			bool first = true;
			for (StringTokenizer tokenizer = new StringTokenizer(this.name, "<,>", true); tokenizer.HasMoreTokens(); )
			{
				string token = tokenizer.NextToken();
				if (first || "<,>".IndexOf(token) >= 0)
				{
				}
				else
				{
					// skip;
					innerTypes.Add(Ca.Infoway.Messagebuilder.Marshalling.HL7.Hl7DataTypeName.Create(token));
				}
				first = false;
			}
			return innerTypes;
		}

		public static string Unqualify(string name)
		{
			return Create(name).GetUnqualifiedVersion().ToString();
		}

		public static string UnqualifyInnerTypes(string name)
		{
			return Create(name).GetUnqualifiedInnerTypesVersion().ToString();
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
