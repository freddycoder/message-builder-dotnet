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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Terminology
{
	[System.Serializable]
	public class MockLetters : EnumPattern, MockCharacters
	{
		static MockLetters()
		{
		}

		private const long serialVersionUID = 6400732969093598844L;

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters A = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("A");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters B = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("B");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters C = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("C");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters D = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("D");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters E = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("E");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters LMNO = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("LMNO");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters OTHER = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
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
