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


namespace Ca.Infoway.Messagebuilder
{
	/// <summary>The Interface Code.</summary>
	/// <remarks>The Interface Code. Implemented by all classes that supply a code mnemonic and a related code system.</remarks>
	public interface Code
	{
		/// <summary>Gets the code value.</summary>
		/// <remarks>Gets the code value.</remarks>
		/// <returns>the code value</returns>
		string CodeValue
		{
			get;
		}

		/// <summary>Gets the code system.</summary>
		/// <remarks>Gets the code system.</remarks>
		/// <returns>the code system</returns>
		string CodeSystem
		{
			get;
		}

		/// <summary>Gets the code system name.</summary>
		/// <remarks>Gets the code system name.</remarks>
		/// <returns>the code system name</returns>
		string CodeSystemName
		{
			get;
		}
	}
}
