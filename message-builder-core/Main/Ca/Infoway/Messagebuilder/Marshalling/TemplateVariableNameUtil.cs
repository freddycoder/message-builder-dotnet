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
