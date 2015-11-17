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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Resolver;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	[System.Serializable]
	public class MockStarTrek : EnumPattern, MockCharacters
	{
		static MockStarTrek()
		{
		}

		private const long serialVersionUID = -5314443670242023450L;

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockStarTrek KIRK = new Ca.Infoway.Messagebuilder.Resolver.MockStarTrek
			("KIRK");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockStarTrek SPOCK = new Ca.Infoway.Messagebuilder.Resolver.MockStarTrek
			("SPOCK");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockStarTrek MCCOY = new Ca.Infoway.Messagebuilder.Resolver.MockStarTrek
			("MCCOY");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockStarTrek PICARD = new Ca.Infoway.Messagebuilder.Resolver.MockStarTrek
			("PICARD");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockStarTrek DATA = new Ca.Infoway.Messagebuilder.Resolver.MockStarTrek
			("DATA");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockStarTrek OTHER = new Ca.Infoway.Messagebuilder.Resolver.MockStarTrek
			("OTHER");

		private MockStarTrek(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return "to.boldly.go";
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
				return this != OTHER ? ToString() : null;
			}
		}

		public virtual NullFlavor GetNullFlavor()
		{
			return this != OTHER ? null : Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER;
		}

		public virtual bool HasNullFlavor()
		{
			return this == OTHER;
		}
	}
}
