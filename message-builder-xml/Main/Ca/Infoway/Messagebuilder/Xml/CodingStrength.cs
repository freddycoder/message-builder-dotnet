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
	/// <summary>An enum that represents the coding strenth.</summary>
	/// <remarks>An enum that represents the coding strenth.</remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class CodingStrength : EnumPattern
	{
		static CodingStrength()
		{
		}

		private const long serialVersionUID = 3259949645508081979L;

		/// <summary>A coding strength that represents a coded, non-extensible code (CNE).</summary>
		/// <remarks>A coding strength that represents a coded, non-extensible code (CNE).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.CodingStrength CNE = new Ca.Infoway.Messagebuilder.Xml.CodingStrength
			("CNE", "coded, non-extensible");

		/// <summary>A coding strength that represents a coded with extensibility code (CWE).</summary>
		/// <remarks>A coding strength that represents a coded with extensibility code (CWE).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.CodingStrength CWE = new Ca.Infoway.Messagebuilder.Xml.CodingStrength
			("CWE", "coded with extensibility");

		private readonly string description;

		private CodingStrength(string name, string description) : base(name)
		{
			this.description = description;
		}

		/// <summary>Gets a user-readable description of the coding strength.</summary>
		/// <remarks>Gets a user-readable description of the coding strength.</remarks>
		/// <returns>the description.</returns>
		public virtual string Description
		{
			get
			{
				return this.description;
			}
		}
	}
}
