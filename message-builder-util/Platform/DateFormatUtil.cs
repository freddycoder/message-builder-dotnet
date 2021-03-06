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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System;
using System.Collections.Generic;

namespace Ca.Infoway.Messagebuilder.Platform
{
	public class DateFormatUtil
	{
        public static PlatformDate Parse(String dateString, String pattern, TimeZoneInfo timeZone)
        {
            return DateUtils.ParseDate(AddColonToTimeZone(dateString), new[] { MakePatternDotNetCompatible(pattern) }, timeZone);
		}

		public static bool IsMatchingPattern(String dateString, String pattern) {

            if (dateString.Length != pattern.Length) {
                return false;
            }

		    try {
                string addColon = AddColonToTimeZone(dateString);
                string[] makeCompatible = new[] { MakePatternDotNetCompatible(pattern) };
                DateUtils.ParseDate(addColon, makeCompatible);
            } 
			catch (Exception e) {
				return false;
			}
			return true;
		}
		
		public static String Format(PlatformDate date, String datePattern) {
			return Format(date, datePattern, TimeZoneInfo.Local);
		}
		
		public static String Format(PlatformDate date, String datePattern, TimeZoneInfo timeZone) {
			if (date==null) {
				return "";
			} else {
				DateTime dateTime = date;
                if (timeZone != null) {
                    dateTime = TimeZoneInfo.ConvertTime(dateTime, timeZone);
                }
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
            string result = datePattern;
            if (datePattern.IndexOf("ZZZZZ") >= 0) {
                result = StringUtils.Replace(datePattern, "ZZZZZ", "zzz");
            } else {
                result = StringUtils.Replace(datePattern, "Z", "zzz");
            }
            result = StringUtils.Replace(result, "SSS", "fff");
			return result;
		}
	}
}

