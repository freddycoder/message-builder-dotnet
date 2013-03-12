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
 * Last modified: $LastChangedDate: 2011-08-25 16:27:38 -0400 (Thu, 25 Aug 2011) $
 * Revision:      $LastChangedRevision: 2941 $
 */

using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Platform
{
	public class CodeUtil
	{
		public static Code ConvertToCode(string codeAsString, String codeSystem)
		{
			Code result = null;
			if (StringUtils.IsNotBlank(codeAsString))
			{
				result = new TrivialCodeResolver().Lookup<Code>(typeof(Code), codeAsString, codeSystem);
			}
			return result;
		}
	}
}

