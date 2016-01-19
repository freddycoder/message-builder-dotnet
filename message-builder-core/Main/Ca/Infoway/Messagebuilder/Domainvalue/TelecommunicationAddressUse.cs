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


using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// A communication address at a home, attempted contacts for
	/// business purposes might intrude privacy and chances are one
	/// will contact family or other household members instead of
	/// the person one wishes to call.
	/// </summary>
	/// <remarks>
	/// A communication address at a home, attempted contacts for
	/// business purposes might intrude privacy and chances are one
	/// will contact family or other household members instead of
	/// the person one wishes to call. Typically used with urgent
	/// cases, or if no other contacts are available.
	/// </remarks>
	public interface TelecommunicationAddressUse : Code
	{
	}
}
