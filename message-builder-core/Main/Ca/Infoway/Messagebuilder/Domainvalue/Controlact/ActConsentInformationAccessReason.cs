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
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActConsentInformationAccessReason.</summary>
	/// <remarks>The Enum ActConsentInformationAccessReason.</remarks>
	[System.Serializable]
	public class ActConsentInformationAccessReason : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActConsentInformationAccessReason
		, Describable
	{
		static ActConsentInformationAccessReason()
		{
		}

		private const long serialVersionUID = -3966382346162978317L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActConsentInformationAccessReason EMERGENCY = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActConsentInformationAccessReason("EMERGENCY", "EMERG");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActConsentInformationAccessReason PROFESSIONAL_JUDGEMENT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActConsentInformationAccessReason("PROFESSIONAL_JUDGEMENT", "PROFJ"
			);

		private readonly string codeValue;

		private ActConsentInformationAccessReason(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_REASON.Root;
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

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string Description
		{
			get
			{
				return DescribableUtil.GetDefaultDescription(this);
			}
		}
	}
}
