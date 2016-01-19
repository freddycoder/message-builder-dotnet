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


using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang.Util
{
	[System.Serializable]
	public class CalendarCycle : EnumPattern
	{
		static CalendarCycle()
		{
		}

		private const long serialVersionUID = 2463751994500229084L;

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle YEAR = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("YEAR", "Y");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle YEAR_2 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("YEAR_2", "CY");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle MONTH_OF_THE_YEAR = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("MONTH_OF_THE_YEAR", "M");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle MONTH_OF_THE_YEAR_2 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("MONTH_OF_THE_YEAR_2", "MY");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle MONTH_CONTINUOUS = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("MONTH_CONTINUOUS", "CM");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle WEEK_CONTINUOUS = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("WEEK_CONTINUOUS", "W");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle WEEK_CONTINUOUS_2 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("WEEK_CONTINUOUS_2", "CW");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle WEEK_OF_THE_YEAR = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("WEEK_OF_THE_YEAR", "WY");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle DAY_OF_THE_MONTH = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("DAY_OF_THE_MONTH", "D");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle DAY_OF_THE_MONTH_2 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("DAY_OF_THE_MONTH_2", "DM");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle DAY_CONTINUOUS = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("DAY_CONTINUOUS", "CD");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle DAY_OF_THE_YEAR = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("DAY_OF_THE_YEAR", "DY");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle DAY_OF_THE_WEEK = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("DAY_OF_THE_WEEK", "J");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle DAY_OF_THE_WEEK_2 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("DAY_OF_THE_WEEK_2", "DW");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle HOUR_OF_THE_DAY = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("HOUR_OF_THE_DAY", "H");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle HOUR_OF_THE_DAY_2 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("HOUR_OF_THE_DAY_2", "HD");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle HOUR_CONTINUOUS = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("HOUR_CONTINUOUS", "CH");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle MINUTE_OF_THE_HOUR = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("MINUTE_OF_THE_HOUR", "N");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle MINUTE_OF_THE_HOUR_2 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("MINUTE_OF_THE_HOUR_2", "NH");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle MINUTE_CONTINUOUS = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("MINUTE_CONTINUOUS", "CN");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle SECOND_OF_THE_MINUTE = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("SECOND_OF_THE_MINUTE", "S");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle SECOND_OF_THE_MINUTE_2 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("SECOND_OF_THE_MINUTE_2", "SN");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle SECOND_CONTINUOUS = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.CalendarCycle
			("SECOND_CONTINUOUS", "CS");

		private readonly string calendarCycleCode;

		private CalendarCycle(string name, string calendarCycleCode) : base(name)
		{
			this.calendarCycleCode = calendarCycleCode;
		}

		public virtual string CalendarCycleCode
		{
			get
			{
				return this.calendarCycleCode;
			}
		}
	}
}
