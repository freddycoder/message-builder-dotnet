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
	/// The non-laboratory, non-diagnostic imaging coded
	/// observation if no value is also required to convey the full
	/// meaning of the observation.
	/// </summary>
	/// <remarks>
	/// The non-laboratory, non-diagnostic imaging coded
	/// observation if no value is also required to convey the full
	/// meaning of the observation. When the Coded Observation Type
	/// represents only the observable, this represents the coded
	/// (non-numeric) result of that non-laboratory, non-diagnositic
	/// imaging coded observation. Examples of the former include
	/// "Decreased breath sounds", of the latter include an APGAR
	/// result, a functional assessment, etc. The value must not
	/// require a specific unit of measure.
	/// </remarks>
	public interface NonLabDICodedObservationValue : ObservationValue
	{
	}
}
