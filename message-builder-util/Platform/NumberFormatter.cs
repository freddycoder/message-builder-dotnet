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
 * Last modified: $LastChangedDate: 2013-03-05 08:26:42 -0500 (Tue, 05 Mar 2013) $
 * Revision:      $LastChangedRevision: 6671 $
 */


using System;

namespace Ca.Infoway.Messagebuilder.Platform
{

	public class NumberFormatter
	{
		public String Format(BigDecimal b, int maxLength, int maxNumberOfIntegers, int maxNumberOfDecimals, bool padFractions) {
			String basePattern = "0." + StringUtils.Repeat(padFractions ? "0" : "#", maxNumberOfDecimals);
			String text = String.Format("{0:" + basePattern + "}", (decimal) b);

            // the above takes care of the decimals having too many digits; now to handle digits to left of decimal.
            // this code preserves a negative sign to match what the java code does (this is possibly not ideal)
            int decimalLocation = text.IndexOf(".");
            if (decimalLocation > maxNumberOfIntegers) {
                return (b.CompareTo(BigDecimal.ZERO) < 0 ? "-" : "") + text.Substring(decimalLocation - maxNumberOfIntegers);
            } else if (decimalLocation == -1 && text.Length > maxNumberOfIntegers) {
                return (b.CompareTo(BigDecimal.ZERO) < 0 ? "-" : "") + text.Substring(text.Length - maxNumberOfIntegers);
            } else {
                return text;
            }

		}
	}
}
			                            