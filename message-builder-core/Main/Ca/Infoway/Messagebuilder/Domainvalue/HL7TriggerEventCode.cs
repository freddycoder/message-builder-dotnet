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
namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>The trigger event referenced by the Control Act instance.</summary>
	/// <remarks>
	/// The trigger event referenced by the Control Act instance.
	/// Identifies the trigger event that occurred. Values are drawn
	/// from the available trigger events used in the release of HL7
	/// identified by the versionCode.
	/// </remarks>
	public interface HL7TriggerEventCode : Ca.Infoway.Messagebuilder.Domainvalue.ActCode
	{
	}
}
