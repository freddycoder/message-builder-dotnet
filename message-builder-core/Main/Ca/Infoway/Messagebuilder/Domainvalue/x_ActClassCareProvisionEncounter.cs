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
using Ca.Infoway.Messagebuilder.Domainvalue;

namespace Ca.Infoway.Messagebuilder.Domainvalue
{
	/// <summary>
	/// An interaction between a patient and healthcare
	/// participant(s) for the purpose of providing patient
	/// service(s) or assessing the health status of a patient.
	/// </summary>
	/// <remarks>
	/// An interaction between a patient and healthcare
	/// participant(s) for the purpose of providing patient
	/// service(s) or assessing the health status of a patient. For
	/// example, outpatient visit to multiple departments, home
	/// health support (including physical therapy), inpatient
	/// hospital stay, emergency room visit, field visit (e.g.
	/// traffic accident), office visit, occupational therapy,
	/// telephone call.
	/// </remarks>
	public interface x_ActClassCareProvisionEncounter : ActClass
	{
	}
}
