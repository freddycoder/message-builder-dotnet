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
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder
{
	/// <summary>An enum that lists the various supported hl7 versions.</summary>
	/// <remarks>An enum that lists the various supported hl7 versions.</remarks>
	[System.Serializable]
	public class SpecificationVersion : EnumPattern, VersionNumber
	{
		static SpecificationVersion()
		{
		}

		private const long serialVersionUID = 3269139690668726076L;

		/// <summary>This designation is used for a stand-alone version of the IEHR messages.</summary>
		/// <remarks>
		/// This designation is used for a stand-alone version of the IEHR messages.  It
		/// was released on 2007-05-08
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_3 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V01R04_3", "V01R04.3", Hl7BaseVersion.CERX);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V02R01 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V02R01", "V02R01", Hl7BaseVersion.MR2007_V02R01);

		/// <summary>
		/// This designation is used for the major release of CeRx, CR, PR and other
		/// messages.
		/// </summary>
		/// <remarks>
		/// This designation is used for the major release of CeRx, CR, PR and other
		/// messages.  It appears to have been officially released on 2007-12-07.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V02R02 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V02R02", "V02R02", Hl7BaseVersion.MR2007);

		/// <summary>
		/// R02.04.00 is the designation given to Maintenance Release 2009 (MR 2009),
		/// officially released on 2009-03-16.
		/// </summary>
		/// <remarks>
		/// R02.04.00 is the designation given to Maintenance Release 2009 (MR 2009),
		/// officially released on 2009-03-16.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_02 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_02", "R02.04.02", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_03 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_03", "R02.04.03", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_05 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_05", "R02.05", Hl7BaseVersion.MR2009);

		/// <summary>
		/// Saskatchewan (V01R04.2)
		/// Base version should technically be V01R04_2 (which isn't a MB HL7v3 release), but the value
		/// is really only used to determine the main release (CeRx, in this case) so we should be ok to use V01R04_3.
		/// </summary>
		/// <remarks>
		/// Saskatchewan (V01R04.2)
		/// Base version should technically be V01R04_2 (which isn't a MB HL7v3 release), but the value
		/// is really only used to determine the main release (CeRx, in this case) so we should be ok to use V01R04_3.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_2_SK = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V01R04_2_SK", "Saskatchewan (V01R04.2)", Hl7BaseVersion.CERX);

		/// <summary>Alberta</summary>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V02R02_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V02R02_AB", "Alberta (V02R02)", Hl7BaseVersion.MR2007);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_03_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_03_AB", "Alberta (R02_04_03)", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_05_00_PA_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_05_00_PA_AB", "Alberta (R02_05_00 Pre-Adopted)", Hl7BaseVersion.MR2009);

		private readonly string description;

		private readonly Hl7BaseVersion baseVersion;

		private SpecificationVersion(string name, string description, Hl7BaseVersion baseVersion) : base(name)
		{
			// currently unused
			// TBD if this is still considered as based on MR2009
			this.description = description;
			this.baseVersion = baseVersion;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string VersionLiteral
		{
			get
			{
				return Name;
			}
		}

		/// <summary>Gets the description.</summary>
		/// <remarks>Gets the description.</remarks>
		/// <returns>the description</returns>
		public virtual string Description
		{
			get
			{
				return this.description;
			}
		}

		/// <summary>Gets the base version of HL7v3 applicable to this version.</summary>
		/// <remarks>Gets the base version of HL7v3 applicable to this version.</remarks>
		/// <returns>the base version</returns>
		public virtual Hl7BaseVersion GetBaseVersion()
		{
			return this.baseVersion;
		}

		/// <summary>Checks if the supplied VersionNumber is based on a particular HL7v3 release</summary>
		/// <param name="version"></param>
		/// <param name="versionToCheck"></param>
		/// <returns></returns>
		public static bool IsVersion(VersionNumber version, Hl7BaseVersion versionToCheck)
		{
			if (versionToCheck == null || version == null)
			{
				return false;
			}
			return version.GetBaseVersion() == versionToCheck;
		}

		public static bool IsExactVersion(VersionNumber version1, VersionNumber version2)
		{
			if (version1 == null || version1.VersionLiteral == null || version2 == null || version2.VersionLiteral == null)
			{
				return false;
			}
			return version1.VersionLiteral.Equals(version2.VersionLiteral) && version1.GetBaseVersion() == version2.GetBaseVersion();
		}
	}
}
