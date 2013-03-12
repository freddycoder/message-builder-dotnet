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
 * Last modified: $LastChangedDate: 2013-03-01 17:48:17 -0500 (Fri, 01 Mar 2013) $
 * Revision:      $LastChangedRevision: 6663 $
 */

using System;
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
					Decimal.Parse(numberAsString);
					return true;
				}
			} catch (FormatException e) {
				return false;
			}
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
			return (int) Decimal.Parse(numberAsString);
		}
	}
}

