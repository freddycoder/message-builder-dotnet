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
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActCode.</summary>
	/// <remarks>The Enum ActCode. A code specifying the particular kind of Act that the Act-instance represents within its class.
	/// 	</remarks>
	[System.Serializable]
	public class ActCode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActCode, Describable
	{
		static ActCode()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode ADVERSE_REACTION = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("ADVERSE_REACTION");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode ASSERTION = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("ASSERTION");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode CHRON = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("CHRON");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode CONFIDENCE_VALUE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("ConfidenceValue");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode DRUG = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("DRUG");

        public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode DX = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
            ("DX");

        public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode FS = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("FS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode G = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("G");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode IMMUNIZ = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("IMMUNIZ");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode INF = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("INF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode INFA = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("INFA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode OBSANTC = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("OBSANTC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode OBSANTV = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("OBSANTV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode PORX_TE010210UV = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("PORX_TE010210UV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode REP_HALF_LIFE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("REP_HALF_LIFE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode SEV = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("SEV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode STORE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("STORE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode TF = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("TF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode FALSE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("FALSE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode VFPAPER = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActCode
			("VFPAPER");

		private ActCode(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_CODE.Root;
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
				return Name;
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
