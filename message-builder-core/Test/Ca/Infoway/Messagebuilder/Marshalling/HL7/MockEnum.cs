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
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	[System.Serializable]
	public class MockEnum : EnumPattern, MockCharacters
	{
		static MockEnum()
		{
		}

		private const long serialVersionUID = 2054176307399510076L;

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum FRED = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("FRED");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum BARNEY = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("BARNEY");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum WILMA = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("WILMA");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum BETTY = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("BETTY");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum BAM_BAM = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("BAM_BAM");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum CERX_MAX = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("12345678901234567890");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum CERX_MAX_PLUS_1 = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("123456789012345678901");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum MR2009_MAX = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
			);

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum MR2009_MAX_PLUS_1 = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901"
			);

		private MockEnum(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return "1.2.3.4.5";
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

		public virtual string CodeValue
		{
			get
			{
				return ToString();
			}
		}
	}
}
