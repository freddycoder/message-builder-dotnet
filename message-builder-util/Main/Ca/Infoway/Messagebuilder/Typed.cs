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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
namespace Ca.Infoway.Messagebuilder
{
	/// <summary>An interface that defines HL7 concepts that have types.</summary>
	/// <author>Intelliware Development</author>
	public interface Typed
	{
		/// <summary>Return the HL7 type -- either an HL7 data type or a complex message type.</summary>
		/// <remarks>Return the HL7 type -- either an HL7 data type or a complex message type.</remarks>
		/// <returns>- the HL7 type</returns>
		string Type
		{
			get;
		}
	}
}
