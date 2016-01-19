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
	/// <summary>The Enum ActClass.</summary>
	/// <remarks>The Enum ActClass.</remarks>
	[System.Serializable]
	public class ActClass : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActClass, Describable
	{
		static ActClass()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass ACT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("ACT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass ALRT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("ALRT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass BATTERY = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("BATTERY");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass CACT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("CACT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass CLUSTER = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("CLUSTER");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass CONC = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("CONC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass COND = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("COND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass CONS = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("CONS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass COV = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("COV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass DOC = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("DOC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass DOCBODY = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("DOCBODY");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass ENC = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("ENC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass INFRM = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("INFRM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass INVE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("INVE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass LIST = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("LIST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass MPROT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("MPROT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass OBS = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("OBS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass PROC = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("PROC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass SBADM = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("SBADM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass SPLY = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("SPLY");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass STORE = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("STORE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass SUBST = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("SUBST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass VERIF = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActClass
			("VERIF");

		private ActClass(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_CLASS.Root;
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
