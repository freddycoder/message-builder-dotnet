using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActConsentInformationAccessReason.</summary>
	/// <remarks>The Enum ActConsentInformationAccessReason.</remarks>
	[System.Serializable]
	public class ActConsentInformationAccessReason : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActConsentInformationAccessReason
		, Describable
	{
		static ActConsentInformationAccessReason()
		{
		}

		private const long serialVersionUID = -3966382346162978317L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActConsentInformationAccessReason EMERGENCY = new 
			Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActConsentInformationAccessReason("EMERGENCY", "EMERG");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActConsentInformationAccessReason PROFESSIONAL_JUDGEMENT
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActConsentInformationAccessReason("PROFESSIONAL_JUDGEMENT", "PROFJ"
			);

		private readonly string codeValue;

		private ActConsentInformationAccessReason(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_REASON.Root;
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
