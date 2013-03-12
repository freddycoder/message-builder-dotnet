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
 * Last modified: $LastChangedDate: 2011-09-20 16:51:13 -0400 (Tue, 20 Sep 2011) $
 * Revision:      $LastChangedRevision: 2998 $
 */

namespace Ca.Infoway.Messagebuilder.Datatype.Lang.Util
{
	/// <summary>This class wraps a standard Date and provides for a datePattern to be supplied.</summary>
	/// <remarks>
	/// This class wraps a standard Date and provides for a datePattern to be supplied.
	/// The supplied date pattern will be used when formatting the date object as xml,
	/// and allows for dates to format the same way going out as coming in or to have a
	/// specified format as desired when writing a response.
	/// </remarks>
	/// <author><a href="http://www.intelliware.ca/">Intelliware Development</a></author>
	[System.Serializable]
	public class DateWithPattern : Ca.Infoway.Messagebuilder.PlatformDate
	{
		private const long serialVersionUID = 8208330288380914940L;

		private readonly string datePattern;

		/// <summary>Instantiates a new date.</summary>
		/// <remarks>Instantiates a new date.</remarks>
		/// <param name=" Date">the   date</param>
		/// <param name="datePattern">the date pattern</param>
		public DateWithPattern(Ca.Infoway.Messagebuilder.PlatformDate  objDate, string datePattern) : base(objDate.Time)
		{
			this.datePattern = datePattern;
		}

		/// <summary>Gets the date pattern.</summary>
		/// <remarks>Gets the date pattern.</remarks>
		/// <returns>the date pattern</returns>
		public virtual string DatePattern
		{
			get
			{
				return datePattern;
			}
		}
	}
}
