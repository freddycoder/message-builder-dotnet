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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-05-27 08:43:37 -0400 (Wed, 27 May 2015) $
 * Revision:      $LastChangedRevision: 9535 $
 */

using System;
using System.Globalization;
namespace Ca.Infoway.Messagebuilder.Lang
{
	public class NumberUtil
	{
		public static Boolean IsNumber(String numberAsString) {
			try {
				if (StringUtils.IsBlank(numberAsString)) 
				{
					return false;
				} 
				else 
				{
                    //Handle hex to be consistent with Java
                    if (IsHexNumber(numberAsString)) {
                        int.Parse(numberAsString.Substring(2), NumberStyles.HexNumber);
                        return true;
                    } else {
					    Decimal.Parse(FilterLastCharacter(numberAsString));
					    return true;
                    }
				}
			} catch (FormatException e) {
				return false;
			}
		}

        //For compatbility with commons math on the Java side
        private static string FilterLastCharacter(string numberAsString) {
            char lastCharacter = numberAsString[numberAsString.Length - 1];
            if (lastCharacter == 'l' || lastCharacter == 'L' || lastCharacter == 'f' || lastCharacter == 'F' || lastCharacter == 'd' || lastCharacter == 'D') {
                return numberAsString.Substring(0, numberAsString.Length - 1);
            }
            return numberAsString;
        }

        private static bool IsHexNumber(String numberAsString) {
            return !StringUtils.IsBlank(numberAsString) && numberAsString.ToLower().StartsWith("0x");
        }

		public static Boolean IsInteger(String numberAsString) {
			try {
				int.Parse(numberAsString);
				return true;
			} catch (FormatException e) {
				return false;
			}
		}

		public static int? ParseAsInteger(String numberAsString) {
            if (IsHexNumber(numberAsString)) {
                return int.Parse(numberAsString.Substring(2), NumberStyles.HexNumber);
            }
			return (int) Decimal.Parse(numberAsString);
		}
	}
}

