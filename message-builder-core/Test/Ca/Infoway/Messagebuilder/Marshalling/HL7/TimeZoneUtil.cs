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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
﻿using System;
using System.Collections.Generic;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7 {
    public class TimeZoneUtil {

        private static readonly IDictionary<string, TimeZoneInfo> JAVA_TO_DOT_NET_TIMEZONE_MAPPING = new Dictionary<string, TimeZoneInfo>();

        //Add to this as necessary depending on usage by JUnit tests on the Java side
        static TimeZoneUtil() {
            JAVA_TO_DOT_NET_TIMEZONE_MAPPING.Add("America/New_York", TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            JAVA_TO_DOT_NET_TIMEZONE_MAPPING.Add("America/Toronto", TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            JAVA_TO_DOT_NET_TIMEZONE_MAPPING.Add("Canada/Ontario", TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            JAVA_TO_DOT_NET_TIMEZONE_MAPPING.Add("Canada/Saskatchewan", TimeZoneInfo.FindSystemTimeZoneById("Canada Central Standard Time"));
            JAVA_TO_DOT_NET_TIMEZONE_MAPPING.Add("GMT-3", TimeZoneInfo.CreateCustomTimeZone("GMT-3", new TimeSpan(-3, 0, 0), "GMT-3", "GMT-3"));
            JAVA_TO_DOT_NET_TIMEZONE_MAPPING.Add("GMT-5", TimeZoneInfo.CreateCustomTimeZone("GMT-5", new TimeSpan(-5, 0, 0), "GMT-5", "GMT-5"));
            JAVA_TO_DOT_NET_TIMEZONE_MAPPING.Add("GMT-6", TimeZoneInfo.CreateCustomTimeZone("GMT-6", new TimeSpan(-6, 0, 0), "GMT-6", "GMT-6"));
            JAVA_TO_DOT_NET_TIMEZONE_MAPPING.Add("GMT-7", TimeZoneInfo.CreateCustomTimeZone("GMT-7", new TimeSpan(-7, 0, 0), "GMT-7", "GMT-7"));
        }

        public static TimeZoneInfo GetTimeZone(string timeZoneId) {
            if (!JAVA_TO_DOT_NET_TIMEZONE_MAPPING.ContainsKey(timeZoneId)) {
                throw new ArgumentException("Missing time zone mapping for " + timeZoneId);
            }
            return JAVA_TO_DOT_NET_TIMEZONE_MAPPING[timeZoneId];
        }

        public static int GetUTCOffset(string timeZoneId, PlatformDate date) {
            DateTimeOffset original = new DateTimeOffset(date);
            DateTimeOffset converted = TimeZoneInfo.ConvertTime(original, GetTimeZone(timeZoneId));
            return (int)converted.Offset.TotalMilliseconds;
        }
    }
}