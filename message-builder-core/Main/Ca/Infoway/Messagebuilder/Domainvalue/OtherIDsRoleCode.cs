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
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>Identifies the type of identifier being supplied (e.g.</summary>
	/// <remarks>
	/// Identifies the type of identifier being supplied (e.g. driver's license number).
	/// This domain type was used (but not really defined) in some client registry
	/// messages.  It was later renamed to OtherIdentifierRoleType.
	/// </remarks>
	/// <author>BC Holmes</author>
	/// <seealso cref="OtherIdentifierRoleType">OtherIdentifierRoleType</seealso>
	public interface OtherIDsRoleCode : Code
	{
	}
}
