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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

using System;
using System.Globalization;

namespace Ca.Infoway.Messagebuilder
{
    public static class DateUtils
    {
        public const long MILLIS_PER_SECOND = 1000;
        public const long MILLIS_PER_MINUTE = MILLIS_PER_SECOND * 60;
        public const long MILLIS_PER_HOUR =  MILLIS_PER_MINUTE * 60;
        public const long MILLIS_PER_DAY = MILLIS_PER_HOUR * 24;

        public static PlatformDate ParseDate(String value, String[] formats)
        {
            return new PlatformDate(DateTime.ParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.None));
        }
    }
}
