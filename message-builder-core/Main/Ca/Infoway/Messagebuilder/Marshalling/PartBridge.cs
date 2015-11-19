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
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Marshalling;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	/// <summary>A part bridge maps between a Message Part and the object that represents it.</summary>
	/// <remarks>
	/// A part bridge maps between a Message Part and the object that represents it.
	/// In the most simple case, one part maps to one class, but in some cases (such
	/// as with inlining) the part really maps to a subset of properties on the class in
	/// which it was inlined.
	/// </remarks>
	/// <author>Intelliware Development</author>
	internal interface PartBridge
	{
		string GetTypeName();

		IList<BaseRelationshipBridge> GetRelationshipBridges();

		bool IsEmpty();

		bool IsNullPart();

		/// <summary>
		/// Indicates whether or not the part has been "collapsed" or "inlined" into
		/// another part type.
		/// </summary>
		/// <remarks>
		/// Indicates whether or not the part has been "collapsed" or "inlined" into
		/// another part type.
		/// </remarks>
		/// <returns>
		/// true if the part maps to a number of bean properties in a message bean,
		/// rather than a bean, itself.  Otherwise, it returns false.
		/// </returns>
		bool IsCollapsed();

		string GetPropertyName();

		/// <summary>Indicates whether or not the part has a null flavor.</summary>
		/// <remarks>Indicates whether or not the part has a null flavor.</remarks>
		/// <returns>whether the part has a null flavor set on it</returns>
		bool HasNullFlavor();

		/// <summary>Returns the part's null flavor, if it has one, or null.</summary>
		/// <remarks>Returns the part's null flavor, if it has one, or null.</remarks>
		/// <returns>the null flavor</returns>
		NullFlavor GetNullFlavor();
	}
}
