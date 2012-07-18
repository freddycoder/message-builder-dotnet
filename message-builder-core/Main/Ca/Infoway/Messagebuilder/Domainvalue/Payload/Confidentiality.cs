using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum Confidentiality.</summary>
	/// <remarks>
	/// The Enum Confidentiality.
	/// A limited set of confidentiality codes, limited to 'normal' and 'restricted'
	/// </remarks>
	[System.Serializable]
	public class Confidentiality : EnumPattern, x_VeryBasicConfidentialityKind, x_BasicConfidentialityKind, x_NormalRestrictedTabooConfidentialityKind
		, Describable
	{
		static Confidentiality()
		{
		}

		private const long serialVersionUID = 7559834755963615602L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.Confidentiality NORMAL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.Confidentiality
			("NORMAL", "N");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.Confidentiality RESTRICTED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.Confidentiality
			("RESTRICTED", "R");

		private readonly string codeValue;

		private Confidentiality(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_CONFIDENTIALITY.Root;
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
