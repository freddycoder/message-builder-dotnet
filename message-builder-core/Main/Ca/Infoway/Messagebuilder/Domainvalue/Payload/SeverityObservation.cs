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


using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum SeverityObservation.</summary>
	/// <remarks>
	/// The Enum SeverityObservation. An indication of the seriousness of a patient's medical
	/// condition or issues. Conditions for which severity levels are assigned include: disease state,
	/// allergies, intolerance and contraindications involving combinations of drugs and other conditions.
	/// </remarks>
	[System.Serializable]
	public class SeverityObservation : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.SeverityObservation
	{
		static SeverityObservation()
		{
		}

		private const long serialVersionUID = -5776943781743759764L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation HIGH = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation
			("HIGH", "H");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation MODERATE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation
			("MODERATE", "M");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation LOW = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation
			("LOW", "L");

		private readonly string codeValue;

		private SeverityObservation(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_SEVERITY_OBSERVATION.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystemName
		{
			get
			{
				return null;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}
	}
}
