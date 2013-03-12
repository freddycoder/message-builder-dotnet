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
	/// <summary>The Enum ActMood.</summary>
	/// <remarks>The Enum ActMood.</remarks>
	[System.Serializable]
	public class ActMood : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActCode, Describable
	{
		static ActMood()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood DEF = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("DEF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood EVN = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("EVN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood EVN_CRT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("EVN.CRT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood EVNINT_CRT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("EVNINT.CRT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood INT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("INT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood PERM = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("PERM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood RQO = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("RQO");

		private ActMood(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_MOOD.Root;
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
