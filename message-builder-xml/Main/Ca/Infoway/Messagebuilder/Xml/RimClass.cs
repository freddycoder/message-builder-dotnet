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
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[System.Serializable]
	public class RimClass : EnumPattern
	{
		static RimClass()
		{
		}

		private const long serialVersionUID = -8779975480440476740L;

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ACT = new Ca.Infoway.Messagebuilder.Xml.RimClass("ACT", "Act"
			);

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ACT_RELATIONSHIP = new Ca.Infoway.Messagebuilder.Xml.RimClass
			("ACT_RELATIONSHIP", "ActRelationship");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ENTITY = new Ca.Infoway.Messagebuilder.Xml.RimClass("ENTITY"
			, "Entity");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass OTHER_CLASS = new Ca.Infoway.Messagebuilder.Xml.RimClass("OTHER_CLASS"
			, "OtherClass");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass PARTICIPATION = new Ca.Infoway.Messagebuilder.Xml.RimClass(
			"PARTICIPATION", "Participation");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ROLE = new Ca.Infoway.Messagebuilder.Xml.RimClass("ROLE", "Role"
			);

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ROLE_LINK = new Ca.Infoway.Messagebuilder.Xml.RimClass("ROLE_LINK"
			, "RoleLink");

		private readonly string code;

		private RimClass(string name, string code) : base(name)
		{
			this.code = code;
		}

		public virtual string Description
		{
			get
			{
				return WordUtils.CapitalizeFully(Name);
			}
		}

		public virtual string Code
		{
			get
			{
				return this.code;
			}
		}
	}
}
