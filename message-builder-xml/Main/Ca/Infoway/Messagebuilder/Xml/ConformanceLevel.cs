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
	/// <summary>Conformance level.</summary>
	/// <remarks>
	/// Conformance level.
	/// This enum models the various conformance levels in the HL7 standards materials.
	/// </remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class ConformanceLevel : EnumPattern
	{
		static ConformanceLevel()
		{
		}

		private const long serialVersionUID = 3066114109382422542L;

		/// <summary>The mandatory conformance level.</summary>
		/// <remarks>
		/// The mandatory conformance level.  A mandatory data element must exist in
		/// the HL7 message and must have a non-null value.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel MANDATORY = new Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			("MANDATORY", "Mand", 0);

		/// <summary>The populated conformance level.</summary>
		/// <remarks>
		/// The populated conformance level.  A populated data element must exist in the
		/// HL7 message, but may have a null flavor associated with it.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel POPULATED = new Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			("POPULATED", "Pop", 1);

		/// <summary>The required conformance level.</summary>
		/// <remarks>
		/// The required conformance level.  This term is prone to misunderstanding, becase
		/// in terms of the data in the message, required elements are closest to optional
		/// elements.  What distinguishes the required conformance level from the optional
		/// conformance level is that a compliant system should save, persist or process any
		/// data values provided.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel REQUIRED = new Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			("REQUIRED", "Req", 2);

		/// <summary>The optional conformance level.</summary>
		/// <remarks>
		/// The optional conformance level.  An optional data element might or might not
		/// exist in the HL7 message.  Null flavors are also possible.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel OPTIONAL = new Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			("OPTIONAL", "Opt", 3);

		/// <summary>The ignored conformance level.</summary>
		/// <remarks>The ignored conformance level.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel IGNORED = new Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			("IGNORED", "Ign", 4);

		/// <summary>The not allowed conformance level.</summary>
		/// <remarks>The not allowed conformance level.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel NOT_ALLOWED = new Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			("NOT_ALLOWED", "X", 5);

		private readonly string description;

		private readonly int permissiveRank;

		private ConformanceLevel(string name, string description, int permissiveRank) : base(name)
		{
			this.description = description;
			this.permissiveRank = permissiveRank;
		}

		/// <summary>Gets a human-readable description of the conformance level.</summary>
		/// <remarks>Gets a human-readable description of the conformance level.</remarks>
		/// <returns>the description</returns>
		public virtual string Description
		{
			get
			{
				return this.description;
			}
		}

		/// <summary>
		/// A convenience method to see if one conformance level is more permissive than
		/// another conformance level.
		/// </summary>
		/// <remarks>
		/// A convenience method to see if one conformance level is more permissive than
		/// another conformance level.
		/// </remarks>
		/// <param name="conformanceLevel">- the other conformance level.</param>
		/// <returns>true if the conformance level is more permissive than the parameter value.</returns>
		public virtual bool IsMorePermissive(Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel)
		{
			return conformanceLevel == null || this.permissiveRank > conformanceLevel.permissiveRank;
		}
	}
}
