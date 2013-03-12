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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>An enum that represents the vocabulary Source.</summary>
	/// <remarks>An enum that represents the vocabulary Source.</remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class DomainSource : EnumPattern
	{
		static DomainSource()
		{
		}

		private const long serialVersionUID = 3259949645508081979L;

		/// <summary>A vocabulary source that represents the value set.</summary>
		/// <remarks>A vocabulary source that represents the value set.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.DomainSource VALUE_SET = new Ca.Infoway.Messagebuilder.Xml.DomainSource
			("VALUE_SET", "valueSet");

		/// <summary>A vocabulary source that represents the code system.</summary>
		/// <remarks>A vocabulary source that represents the code system.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.DomainSource CODE_SYSTEM = new Ca.Infoway.Messagebuilder.Xml.DomainSource
			("CODE_SYSTEM", "codeSystem");

		/// <summary>A vocabulary source that represents the concept domain (domain name).</summary>
		/// <remarks>A vocabulary source that represents the concept domain (domain name).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.DomainSource CONCEPT_DOMAIN = new Ca.Infoway.Messagebuilder.Xml.DomainSource
			("CONCEPT_DOMAIN", "domain");

		private readonly string code;

		private DomainSource(string name, string description) : base(name)
		{
			this.code = description;
		}

		/// <summary>Gets the code of the vocabulary source.</summary>
		/// <remarks>Gets the code of the vocabulary source.</remarks>
		/// <returns>the code.</returns>
		public virtual string GetCode()
		{
			return this.code;
		}
	}
}
