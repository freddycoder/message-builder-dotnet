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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
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
