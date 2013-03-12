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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
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
