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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ca.Infoway.Messagebuilder
{
    public class PlatformDate
    {
        private static long joffset = 621355968000000000; // Java 1/100 nanoseconds origin offset

        private DateTime dt;

        public PlatformDate()
        {
            dt = DateTime.Now;
        }

        public PlatformDate(long millis)
        {
            Time = millis;
        }

        public PlatformDate(DateTime dt)
        {
            this.dt = dt;
        }

        public bool After(PlatformDate that)
        {
            return dt > that.dt;
        }

        public bool Before(PlatformDate that)
        {
            return dt < that.dt;
        }

        public override bool Equals(Object that)
        {
            return dt == ((PlatformDate) that).dt;
        }

		public override int GetHashCode() 
		{
			return dt.GetHashCode();
		}
			
        public int CompareTo(PlatformDate that)
        {
            return dt.CompareTo(that.dt);
        }

		public override string ToString() {
			return this.dt.ToString();
		}
		
        public int DayOfMonth
        {
            get { return dt.Day; }
        }

        public int DayOfWeek
        {
            get { return (int) dt.DayOfWeek; }
        }

        public int Hours
        {
            get { return dt.Hour; }
        }

        public int Minutes
        {
            get { return dt.Minute; }
        }

        public int Month
        {
            get { return dt.Month - 1; }
        }

        public int Seconds
        {
            get { return dt.Second; }
        }

        public long Time
        {
            get { return (dt.Ticks - joffset) / 10000; } // 100 nanoseconds to milliseconds
            set { dt = new DateTime((value * 10000) + joffset); } // Milliseconds to 100 nanoseconds
        }

        public int Year
        {
            get { return dt.Year - 1900; }
        }

        public static implicit operator DateTime(PlatformDate that)
        {
            return that.dt;
        }
		
    }
}
