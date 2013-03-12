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
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Terminology
{
	[System.Serializable]
	public class MockEnum : EnumPattern, MockCharacters
	{
		static MockEnum()
		{
		}

		private const long serialVersionUID = -8250727697675835177L;

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum FRED = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("FRED");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum BARNEY = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("BARNEY");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum WILMA = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("WILMA");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum BETTY = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("BETTY");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum BAM_BAM = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("BAM_BAM");

		private MockEnum(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return string.Empty;
			}
		}

		public virtual string CodeValue
		{
			get
			{
				return ToString();
			}
		}
	}
}
