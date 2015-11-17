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
	public class MockLetters : EnumPattern, MockCharacters
	{
		static MockLetters()
		{
		}

		private const long serialVersionUID = 6400732969093598844L;

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockLetters A = new Ca.Infoway.Messagebuilder.Resolver.MockLetters
			("A");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockLetters B = new Ca.Infoway.Messagebuilder.Resolver.MockLetters
			("B");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockLetters C = new Ca.Infoway.Messagebuilder.Resolver.MockLetters
			("C");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockLetters D = new Ca.Infoway.Messagebuilder.Resolver.MockLetters
			("D");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockLetters E = new Ca.Infoway.Messagebuilder.Resolver.MockLetters
			("E");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockLetters LMNO = new Ca.Infoway.Messagebuilder.Resolver.MockLetters
			("LMNO");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockLetters OTHER = new Ca.Infoway.Messagebuilder.Resolver.MockLetters
			("OTHER");

		private MockLetters(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return "a.b.c.e.f.g.h";
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
				return this != OTHER ? Name : null;
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
