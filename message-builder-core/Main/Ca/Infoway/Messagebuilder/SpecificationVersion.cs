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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder
{
	/// <summary>An enum that lists the various supported hl7 versions.</summary>
	/// <remarks>An enum that lists the various supported hl7 versions.</remarks>
	[System.Serializable]
	public class SpecificationVersion : EnumPattern, VersionNumber
	{
		private const long serialVersionUID = 3269139690668726076L;

		/// <summary>This designation is used for a stand-alone version of the IEHR messages.</summary>
		/// <remarks>
		/// This designation is used for a stand-alone version of the IEHR messages.  It
		/// was released on 2007-05-08
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_3 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V01R04_3", "V01R04.3", Hl7BaseVersion.CERX);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_4 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V01R04_4", "V01R04.4", Hl7BaseVersion.CERX);

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

        public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_1_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
            ("V01R04_1_AB", "Alberta (PIN)", Hl7BaseVersion.CERX);

        public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V02R02_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V02R02_AB", "Alberta (V02R02)", Hl7BaseVersion.MR2007);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_03_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_03_AB", "Alberta (R02_04_03)", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_03_IMM_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_03_IMM_AB", "Alberta (Immunization)", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_03_SHR_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_03_SHR_AB", "Alberta (Shared Health Record)", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_3_ON = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V01R04_3_ON", "ON Drug", Hl7BaseVersion.CERX);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V02R04_BC = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V02R04_BC", "BC (V02R04)", Hl7BaseVersion.MR2007);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_03_NS = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_03_NS", "NS MR2009", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_3_NS = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V01R04_3_NS", "NS Drug (CeRx)", Hl7BaseVersion.CERX);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_03_NB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_03_NB", "NB Registries (R02_03)", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_3_NB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V01R04_3_NB", "NB Drug (CeRx)", Hl7BaseVersion.CERX);

        public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_03_NL = new Ca.Infoway.Messagebuilder.SpecificationVersion
            ("R02_04_03_NL", "NL CR/PR/LR (R02_04_03)", Hl7BaseVersion.MR2009);

        public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V01R04_3_NL = new Ca.Infoway.Messagebuilder.SpecificationVersion
            ("V01R04_3_NL", "NL Drug (CeRx)", Hl7BaseVersion.CERX);

        public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion CCDA_R1_1 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("CCDA_R1_1", "CDA (CCDA_R1_1)", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion CCDA_PCS_R1_1 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("CCDA_PCS_R1_1", "CDA (CCDA_PCS_R1_1)", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion PCS_CDA_R1_2 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("PCS_CDA_R1_2", "CDA (PCS_CDA_R1_2)", Hl7BaseVersion.MR2009);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion CDA_AB_SHR = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("CDA_AB_SHR", "Alberta CDA (Shared Health Record)", Hl7BaseVersion.MR2009);

		static SpecificationVersion()
		{
			// ON Drug
			// BC V02R04
			// NS releases
			// NB releases
			// CDA releases
			// AB CDA
			V01R04_3.RegisterHl7ReleaseByDatatype("II.BUS", Hl7BaseVersion.MR2009);
			V01R04_3.RegisterHl7ReleaseByDatatype("II.VER", Hl7BaseVersion.MR2009);
			V01R04_3.RegisterHl7ReleaseByDatatype("II.BUS_AND_VER", Hl7BaseVersion.MR2009);
			V01R04_3_ON.RegisterHl7ReleaseByDatatype("II.BUS", Hl7BaseVersion.MR2009);
			V01R04_3_ON.RegisterHl7ReleaseByDatatype("II.VER", Hl7BaseVersion.MR2009);
			V01R04_3_ON.RegisterHl7ReleaseByDatatype("II.BUS_AND_VER", Hl7BaseVersion.MR2009);
			V01R04_2_SK.RegisterHl7ReleaseByDatatype("II.BUS", Hl7BaseVersion.MR2009);
			V01R04_2_SK.RegisterHl7ReleaseByDatatype("II.VER", Hl7BaseVersion.MR2009);
			V01R04_2_SK.RegisterHl7ReleaseByDatatype("II.BUS_AND_VER", Hl7BaseVersion.MR2009);
            // MBR-368: a temporary work-around for producing AB PIN compliant date time renderings
            V01R04_1_AB.RegisterHl7ReleaseByDatatype("TS.FULLDATETIME", Hl7BaseVersion.MR2009);
        }

        private readonly string description;

		private readonly Hl7BaseVersion baseVersion;

		private readonly IDictionary<string, Hl7BaseVersion> hl7ReleaseByDatatypeMap = new Dictionary<string, Hl7BaseVersion>();

		private SpecificationVersion(string name, string description, Hl7BaseVersion baseVersion) : base(name)
		{
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

		/// <summary>Check registry to see if the provided datatype should be treated as specified by a specific HL7v3 release.</summary>
		/// <remarks>
		/// Check registry to see if the provided datatype should be treated as specified by a specific HL7v3 release. If not,
		/// use the defined base version.
		/// The great majority of implementations should never need to register specific datatypes against HL7v3 releases.
		/// </remarks>
		/// <param name="datatype">An object representing a datatype. Usually, but not restricted to, an instance of StandardDataType.
		/// 	</param>
		/// <returns>the HL7 release that the given datatype conforms to</returns>
		public virtual Hl7BaseVersion GetBaseVersion(Typed datatype)
		{
			if (datatype != null && this.hl7ReleaseByDatatypeMap.ContainsKey(datatype.Type))
			{
				return this.hl7ReleaseByDatatypeMap.SafeGet(datatype.Type);
			}
			return GetBaseVersion();
		}

		/// <summary>Clear the registry.</summary>
		/// <remarks>Clear the registry.</remarks>
		public virtual void ClearHl7ReleaseByDatatypeRegistry()
		{
			this.hl7ReleaseByDatatypeMap.Clear();
		}

		/// <summary>Register a specific datatype against a particular HL7v3 release (for validation and processing).</summary>
		/// <remarks>Register a specific datatype against a particular HL7v3 release (for validation and processing).</remarks>
		/// <param name="datatype"></param>
		/// <param name="hl7BaseVersion"></param>
		public virtual void RegisterHl7ReleaseByDatatype(string datatype, Hl7BaseVersion hl7BaseVersion)
		{
			this.hl7ReleaseByDatatypeMap[datatype] = hl7BaseVersion;
		}

		/// <summary>Checks if the supplied VersionNumber is based on a particular HL7v3 release.</summary>
		/// <remarks>
		/// Checks if the supplied VersionNumber is based on a particular HL7v3 release.
		/// This now takes in the specific datatype for which this check is being performed. If the datatype
		/// registry contains this datatype then its registered version is returned, otherwise the base version
		/// is returned.
		/// </remarks>
		/// <param name="version"></param>
		/// <param name="versionToCheck"></param>
		/// <returns>whether the version supplied is a match for the given HL7v3 release</returns>
		public static bool IsVersion(Typed datatype, VersionNumber version, Hl7BaseVersion versionToCheck)
		{
			if (versionToCheck == null || version == null)
			{
				return false;
			}
			return version.GetBaseVersion(datatype) == versionToCheck;
		}

		/// <summary>Checks that a provided version is a match for a known version.</summary>
		/// <remarks>
		/// Checks that a provided version is a match for a known version. Usually done for jurisdiction-specific datatype processing.
		/// This check does _not_ compare the contents of the datatype registry.
		/// </remarks>
		/// <param name="version1"></param>
		/// <param name="version2"></param>
		/// <returns>whether the versions match</returns>
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
