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
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A class that models the cardinality of a particular HL7 relationship.</summary>
	/// <remarks>A class that models the cardinality of a particular HL7 relationship.</remarks>
	/// <author>Intelliware Development</author>
	public class Cardinality
	{
		private readonly Int32? min;

		private readonly Int32? max;

		/// <summary>Get the maximum value.</summary>
		/// <remarks>Get the maximum value.</remarks>
		/// <returns>the maximum value.</returns>
		public virtual Int32? Max
		{
			get
			{
				return this.max;
			}
		}

		/// <summary>Get the minimum value.</summary>
		/// <remarks>Get the minimum value.</remarks>
		/// <returns>the minimum value.</returns>
		public virtual Int32? Min
		{
			get
			{
				return this.min;
			}
		}

		/// <summary>A flag that indicates that the cardinality is at least one.</summary>
		/// <remarks>A flag that indicates that the cardinality is at least one.</remarks>
		/// <returns>true if the minimum cardinality is at least one; false otherwise.</returns>
		public virtual bool Mandatory
		{
			get
			{
				return this.min >= 1;
			}
		}

		/// <summary>Standard constructor.</summary>
		/// <remarks>Standard constructor.</remarks>
		/// <param name="min">- the minimum value.</param>
		/// <param name="max">- the maximum value.</param>
		public Cardinality(Int32? min, Int32? max)
		{
			this.min = min;
			this.max = max;
		}

		/// <summary>A convenience method to see if the cardinality of "1" or "0-1".</summary>
		/// <remarks>A convenience method to see if the cardinality of "1" or "0-1".</remarks>
		/// <returns>true if the maximum cardinality is 1; false otherwise.</returns>
		public virtual bool Single
		{
			get
			{
				return 1 == this.max;
			}
		}

		/// <summary>A convenience method to see if the cardinality of "0".</summary>
		/// <remarks>A convenience method to see if the cardinality of "0".</remarks>
		/// <returns>true if the maximum cardinality is 0; false otherwise.</returns>
		public virtual bool IsForbidden()
		{
			return 0 == this.max;
		}

		/// <summary>
		/// A convenience method to see if the maximum cardinality is greater than
		/// one.
		/// </summary>
		/// <remarks>
		/// A convenience method to see if the maximum cardinality is greater than
		/// one.
		/// </remarks>
		/// <returns>true if the cardinality is not single; false otherwise.</returns>
		public virtual bool Multiple
		{
			get
			{
				return !Single;
			}
		}

		public virtual bool Unbounded
		{
			get
			{
				return int.MaxValue == this.max;
			}
		}

		/// <summary>Determine if this cardinality is equal to another object.</summary>
		/// <remarks>Determine if this cardinality is equal to another object.</remarks>
		/// <param name="obj">- the other object</param>
		/// <returns>true if the two objects describe the same cardinality; false otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			else
			{
				if (obj.GetType() != GetType())
				{
					return false;
				}
				else
				{
					Ca.Infoway.Messagebuilder.Xml.Cardinality that = (Ca.Infoway.Messagebuilder.Xml.Cardinality)obj;
					return new EqualsBuilder().Append(this.min, that.min).Append(this.max, that.max).IsEquals();
				}
			}
		}

		/// <summary>Provide a string representation of the cardinality.</summary>
		/// <remarks>
		/// Provide a string representation of the cardinality.  (e.g. "0-*", indicating
		/// unbounded cardinality.
		/// </remarks>
		/// <returns>the string representation of the cardinality.</returns>
		public override string ToString()
		{
			if (1.Equals(this.min) && int.MaxValue.Equals(this.max))
			{
				return "*";
			}
			else
			{
				if (0.Equals(this.min) && int.MaxValue.Equals(this.max))
				{
					return "0-*";
				}
				else
				{
					if (int.MaxValue.Equals(this.max))
					{
						return string.Empty + this.min + "-*";
					}
					else
					{
						if (ObjectUtils.Equals(this.min, this.max))
						{
							return string.Empty + this.min;
						}
						else
						{
							return string.Empty + this.min + "-" + this.max;
						}
					}
				}
			}
		}

		/// <summary>Parse a cardinality string (such as "*" or "0-50") into a cardinality object.</summary>
		/// <remarks>Parse a cardinality string (such as "*" or "0-50") into a cardinality object.</remarks>
		/// <param name="string">- the string representation.</param>
		/// <returns>- the cardinality</returns>
		public static Ca.Infoway.Messagebuilder.Xml.Cardinality Create(string @string)
		{
			if (StringUtils.IsBlank(@string))
			{
				return null;
			}
			else
			{
				if ("*".Equals(@string))
				{
					return new Ca.Infoway.Messagebuilder.Xml.Cardinality(1, int.MaxValue);
				}
				else
				{
					if (@string.Contains("-"))
					{
						int min = int.Parse(StringUtils.SubstringBefore(@string, "-"));
						string maxAsString = StringUtils.SubstringAfter(@string, "-");
						int max = ("*".Equals(maxAsString)) ? int.MaxValue : int.Parse(maxAsString);
						return new Ca.Infoway.Messagebuilder.Xml.Cardinality(min, max);
					}
					else
					{
						if (@string.Contains(".."))
						{
							int min = int.Parse(StringUtils.SubstringBefore(@string, ".."));
							string maxAsString = StringUtils.SubstringAfter(@string, "..");
							int max = ("*".Equals(maxAsString)) ? int.MaxValue : int.Parse(maxAsString);
							return new Ca.Infoway.Messagebuilder.Xml.Cardinality(min, max);
						}
						else
						{
							int value = int.Parse(@string);
							return new Ca.Infoway.Messagebuilder.Xml.Cardinality(value, value);
						}
					}
				}
			}
		}

		/// <summary>
		/// A convenience method to indicate whether a specified value is contained within
		/// the cardinality range.
		/// </summary>
		/// <remarks>
		/// A convenience method to indicate whether a specified value is contained within
		/// the cardinality range.
		/// </remarks>
		/// <param name="value">- the value being specified.</param>
		/// <returns>- true if the cardinality range contains the value; false otherwise.</returns>
		public virtual bool Contains(int value)
		{
			return (this.min == null || this.min <= value) && (this.max == null || this.max >= value);
		}
	}
}
