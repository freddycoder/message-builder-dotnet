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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>At the moment, this code set only supports one reason, used for the eReferrals ping.</summary>
	/// <remarks>
	/// At the moment, this code set only supports one reason, used for the eReferrals ping.
	/// Identifies why this specific query, modification request, or modification occurred.
	/// </remarks>
	[System.Serializable]
	public class ActReason : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActReason, Describable
	{
		static ActReason()
		{
		}

		private const long serialVersionUID = -4688667149166033487L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ActReason SYSTEM_TEST = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ActReason
			("SYSTEM_TEST", "SYSTEST");

		private readonly string codeValue;

		private ActReason(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.REFERRALS_ACT_REASON.Root;
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
