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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Datatype;

namespace Ca.Infoway.Messagebuilder.Datatype
{
	/// <summary>HL7 datatype SET.</summary>
	/// <remarks>
	/// HL7 datatype SET. Backed by a java Set.
	/// Used when multiple repetitions are allowed, order is irrelevant and duplicates are prohibited.
	/// </remarks>
	/// <author>Intelliware Development</author>
	/// <TBD></TBD>
	/// <TBD></TBD>
	public interface SET<T, V> : COLLECTION<T> where T : ANY<V>
	{
		/// <summary>Returns the underlying Java Set containing values in the underlying Java datatype.</summary>
		/// <remarks>Returns the underlying Java Set containing values in the underlying Java datatype.</remarks>
		/// <returns>the underlying Java Set containing values in the underlying Java datatype</returns>
		ICollection<V> RawSet();

		ICollection<U> RawSet<U>() where U : V;
	}
}
