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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
namespace Ca.Infoway.Messagebuilder.Datatype.Lang
{
	/// <summary>.NET base class.</summary>
	/// <remarks>
	/// .NET base class.
	/// Used to hold a difference value of a given type.
	/// </remarks>
	/// <author>Intelliware Development</author>
	public interface BareRatio
	{
		/// <summary>Returns the denominator.</summary>
		/// <remarks>Returns the denominator.</remarks>
		/// <returns>the denominator</returns>
		object BareDenominator
		{
			get;
		}

		/// <summary>Returns the numerator.</summary>
		/// <remarks>Returns the numerator.</remarks>
		/// <returns>the numerator</returns>
		object BareNumerator
		{
			get;
		}
	}
}
