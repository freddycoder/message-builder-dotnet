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
			("V01R04_3", "V01R04.3");

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V02R01 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V02R01", "V02R01");

		/// <summary>
		/// This designation is used for the major release of CeRx, CR, PR and other
		/// messages.
		/// </summary>
		/// <remarks>
		/// This designation is used for the major release of CeRx, CR, PR and other
		/// messages.  It appears to have been officially released on 2007-12-07.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V02R02 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V02R02", "V02R02");

		/// <summary>
		/// R02.04.00 is the designation given to Maintenance Release 2009 (MR 2009),
		/// officially released on 2009-03-16.
		/// </summary>
		/// <remarks>
		/// R02.04.00 is the designation given to Maintenance Release 2009 (MR 2009),
		/// officially released on 2009-03-16.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_02 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_02", "R02.04.02");

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion R02_04_03 = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("R02_04_03", "R02.04.03");

		/// <summary>Newfoundland and Labrador (mixed V01R04.3 / V02R02).</summary>
		/// <remarks>Newfoundland and Labrador (mixed V01R04.3 / V02R02).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion NEWFOUNDLAND = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("NEWFOUNDLAND", "Newfoundland and Labrador (mixed V01R04.3 / V02R02)");

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
			("V01R04_2_SK", "Saskatchewan (V01R04.2)", Ca.Infoway.Messagebuilder.SpecificationVersion.V01R04_3);

		/// <summary>Alberta (V02R02).</summary>
		/// <remarks>Alberta (V02R02).</remarks>
		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion V02R02_AB = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("V02R02_AB", "Alberta (V02R02)", Ca.Infoway.Messagebuilder.SpecificationVersion.V02R02);

		public static readonly Ca.Infoway.Messagebuilder.SpecificationVersion NA = new Ca.Infoway.Messagebuilder.SpecificationVersion
			("NA", string.Empty, null, true);

		private readonly string description;

		private readonly bool unknown;

		private readonly VersionNumber baseVersion;

		private SpecificationVersion(string name, string description) : this(name, description, null)
		{
		}

		private SpecificationVersion(string name, string description, VersionNumber baseVersion) : this(name, description, baseVersion
			, false)
		{
		}

		private SpecificationVersion(string name, string description, VersionNumber baseVersion, bool unknown) : base(name)
		{
			this.description = description;
			this.baseVersion = baseVersion;
			this.unknown = unknown;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string VersionLiteral
		{
			get
			{
				return Name;
			}
		}

		/// <summary>Checks if is unknown.</summary>
		/// <remarks>Checks if is unknown.</remarks>
		/// <returns>true, if is unknown</returns>
		public virtual bool Unknown
		{
			get
			{
				return this.unknown;
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

		/// <summary>Gets the base version, if applicable.</summary>
		/// <remarks>
		/// Gets the base version, if applicable. Since all versions in this
		/// enum are base versions, this method just returns itself.
		/// </remarks>
		/// <returns>the description</returns>
		public virtual VersionNumber GetBaseVersion()
		{
			return this.baseVersion == null ? this : this.baseVersion;
		}

		public static bool IsVersion(VersionNumber desiredVersion, VersionNumber versionToCheck)
		{
			string actualVersion = (versionToCheck == null ? null : versionToCheck.VersionLiteral);
			string baseVersion = (versionToCheck == null ? null : (versionToCheck.GetBaseVersion() == null ? null : versionToCheck.GetBaseVersion
				().VersionLiteral));
			string desiredVersionLiteral = (desiredVersion == null ? null : desiredVersion.VersionLiteral);
			return StringUtils.Equals(actualVersion, desiredVersionLiteral) || StringUtils.Equals(baseVersion, desiredVersionLiteral);
		}
	}
}
