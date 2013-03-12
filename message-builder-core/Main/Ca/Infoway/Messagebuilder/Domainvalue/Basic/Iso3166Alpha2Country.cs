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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic
{
	/// <summary>The Enum Iso3166Alpha2Country.</summary>
	/// <remarks>The Enum Iso3166Alpha2Country.</remarks>
	[System.Serializable]
    public class Iso3166Alpha2Country : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.Country, Describable
	{
		static Iso3166Alpha2Country()
		{
		}

		private const long serialVersionUID = -7361050354534966120L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.Iso3166Alpha2Country CANADA = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.Iso3166Alpha2Country
			("CANADA", "CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.Iso3166Alpha2Country UNITED_STATES = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.Iso3166Alpha2Country
			("UNITED_STATES", "US");

		private readonly string codeValue;

		private Iso3166Alpha2Country(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.ISO_3166_1_ALPHA_2.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
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
