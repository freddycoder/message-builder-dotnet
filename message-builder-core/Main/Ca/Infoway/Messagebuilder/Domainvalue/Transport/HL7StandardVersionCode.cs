using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum HL7StandardVersionCode.</summary>
	/// <remarks>
	/// The Enum HL7StandardVersionCode. Indicates the version of the HL7 messaging standard being referenced.
	/// This is the domain of HL7 version codes for the Version 3 standards. Values are to be determined by HL7
	/// and added with each new version of the HL7 Standard.
	/// </remarks>
	[System.Serializable]
	public class HL7StandardVersionCode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.HL7StandardVersionCode, Describable
	{
		static HL7StandardVersionCode()
		{
		}

		private const long serialVersionUID = -2697379971765691638L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode V3_2005_05 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode
			("V3_2005_05", "V3-2005-05");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode V3_2006_05 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode
			("V3_2006_05", "V3-2006-05");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode V3_2007_05 = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode
			("V3_2007_05", "V3-2007-05");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode V3_2007N = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode
			("V3_2007N", "V3-2007N");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode V3_2008N = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7StandardVersionCode
			("V3_2008N", "V3-2008N");

		private readonly string codeValue;

		private HL7StandardVersionCode(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_HL7_STANDARD_VERSION_CODE.Root;
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
				return this.codeValue;
			}
		}
	}
}
