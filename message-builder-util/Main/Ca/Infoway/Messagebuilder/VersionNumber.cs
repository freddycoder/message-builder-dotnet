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
 * Last modified: $LastChangedDate: 2014-01-30 15:25:26 -0500 (Thu, 30 Jan 2014) $
 * Revision:      $LastChangedRevision: 8372 $
 */
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder
{
	/// <summary>An interface usable by any class that provides a version number/id.</summary>
	/// <remarks>An interface usable by any class that provides a version number/id.</remarks>
	public interface VersionNumber
	{
		/// <summary>Gets the version literal.</summary>
		/// <remarks>Gets the version literal. Null should not be returned.</remarks>
		/// <returns>the version literal</returns>
		string VersionLiteral
		{
			get;
		}

		/// <summary>The HL7v3 release that this version is based on.</summary>
		/// <remarks>The HL7v3 release that this version is based on. If at all possible, null should not be returned.</remarks>
		/// <returns>the base version</returns>
		Hl7BaseVersion GetBaseVersion();

		/// <summary>This method should only return getBaseVersion() in the great majority of cases.</summary>
		/// <remarks>This method should only return getBaseVersion() in the great majority of cases.</remarks>
		/// <param name="datatype">An object representing a datatype. Usually, but not restricted to, an instance of StandardDataType.
		/// 	</param>
		/// <returns>the HL7 release that the given datatype conforms to</returns>
		Hl7BaseVersion GetBaseVersion(Typed datatype);
	}
}
