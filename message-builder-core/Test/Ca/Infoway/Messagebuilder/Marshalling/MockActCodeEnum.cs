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
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	[System.Serializable]
	public class MockActCodeEnum : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActCode
	{
		static MockActCodeEnum()
		{
		}

		private const long serialVersionUID = 5768896600339903436L;

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum SEV = new Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum
			("SEV");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum IMMUNIZ = new Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum
			("IMMUNIZ");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum ADVERSE_REACTION = new Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum
			("ADVERSE_REACTION");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum PORX_TE010210UV = new Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum
			("PORX_TE010210UV");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum DRUG = new Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum
			("DRUG");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum INF = new Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum
			("INF");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum PORX_TE060300UV = new Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum
			("PORX_TE060300UV");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum G = new Ca.Infoway.Messagebuilder.Marshalling.MockActCodeEnum
			("G");

		private MockActCodeEnum(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_CODE.Root;
			}
		}

		public virtual string CodeSystemName
		{
			get
			{
				return null;
			}
		}

		public virtual string CodeValue
		{
			get
			{
				return Name;
			}
		}
	}
}
