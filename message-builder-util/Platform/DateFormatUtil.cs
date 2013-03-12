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

namespace Ca.Infoway.Messagebuilder.Platform
{
	public class DateFormatUtil
	{
		public static PlatformDate Parse(String dateString, String pattern, TimeZone timeZone) {
			// FIXME - use timeZone
            return DateUtils.ParseDate(AddColonToTimeZone(dateString), new[] { MakePatternDotNetCompatible(pattern) });
		}

		public static bool IsMatchingPattern(String dateString, String pattern) {
		    try { 
				DateUtils.ParseDate(AddColonToTimeZone(dateString), new[] { MakePatternDotNetCompatible(pattern) }); 
			} 
			catch (Exception e) {
				return false;
			}
			return true;
		}
		
		public static String Format(PlatformDate date, String datePattern) {
			return Format(date, datePattern, TimeZone.CurrentTimeZone);
		}
		
		public static String Format(PlatformDate date, String datePattern, TimeZone timeZone) {
			// FIXME - use timeZone
			if (date==null) {
				return "";
			} else {
				DateTime dateTime = date;
				return RemoveColonFromTimeZone(dateTime.ToString(MakePatternDotNetCompatible(datePattern)));
			}
		}

		private static string RemoveColonFromTimeZone(string dateString) {
			return StringUtils.Replace(dateString, ":", "");
		}

		private static string AddColonToTimeZone(string dateString) {
			if (dateString.Length == 23) {
				return dateString.Substring(0, dateString.Length-4) + 
					   dateString.Substring(dateString.Length-4, 2) +
					   ":" +
					   dateString.Substring(dateString.Length-2);
			} else {
				return dateString;
			}
		}
		
		private static string MakePatternDotNetCompatible(string datePattern) {
			return StringUtils.Replace(StringUtils.Replace(datePattern, "ZZZZZ", "zzz"), "SSS", "fff");
		}
	}
}

