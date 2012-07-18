/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2012-01-18 21:43:51 -0500 (Wed, 18 Jan 2012) $
 * Revision:      $LastChangedRevision: 4345 $
 */


using System;

namespace Ca.Infoway.Messagebuilder.Platform
{

	public class NumberFormatter
	{
		public String Format(BigDecimal b, int maxLength, int maxNumberOfDecimals, bool padFractions) {
			String basePattern = "0." + StringUtils.Repeat(padFractions ? "0" : "#", maxNumberOfDecimals);
			String text = String.Format("{0:" + basePattern + "}", (decimal) b);
			
			if (text.Length <= maxLength && text.Contains(".")) {
				return text;
			} else if (text.Contains(".")) {
				return text.Substring(text.Length - maxLength);
			} else if (text.Length > (maxLength - maxNumberOfDecimals - 1)) {
				return text.Substring(text.Length - (maxLength - maxNumberOfDecimals - 1));
			} else {
				return text;
			}
		}
	}
}
			                            