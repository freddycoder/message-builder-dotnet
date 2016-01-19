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

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>Potential update modes.</summary>
	/// <remarks>
	/// Potential update modes.
	/// This enum models the various Update Mode Kinds in the HL7 standards materials.
	/// </remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class UpdateModeType : EnumPattern
	{
		static UpdateModeType()
		{
		}

		private const long serialVersionUID = 3066114109382422542L;

		/// <summary>The add update mode.</summary>
		/// <remarks>The add update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType ADD = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("ADD", "A");

		/// <summary>The remoe update mode.</summary>
		/// <remarks>The remoe update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType REMOVE = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("REMOVE", "D");

		/// <summary>The replace update mode.</summary>
		/// <remarks>The replace update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType REPLACE = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("REPLACE", "R");

		/// <summary>The add or update update mode.</summary>
		/// <remarks>The add or update update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType ADD_OR_UPDATE = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("ADD_OR_UPDATE", "N");

		/// <summary>The no change update mode.</summary>
		/// <remarks>The no change update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType NO_CHANGE = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("NO_CHANGE", "N");

		/// <summary>The unknown update mode.</summary>
		/// <remarks>The unknown update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType UNKNOWN = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("UNKNOWN", "U");

		private readonly string codeValue;

		private UpdateModeType(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary>Gets the code for the update mode.</summary>
		/// <remarks>Gets the code for the update mode.</remarks>
		/// <returns>the codeValue</returns>
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}
	}
}
