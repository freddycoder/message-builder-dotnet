using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum AdministrativeGender.</summary>
	/// <remarks>The Enum AdministrativeGender. The gender of a person used for adminstrative purposes (as opposed to clinical gender).
	/// 	</remarks>
	[System.Serializable]
	public class AdministrativeGender : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.AdministrativeGender, Describable
	{
		static AdministrativeGender()
		{
		}

		private const long serialVersionUID = 1376436588630112644L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender FEMALE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender
			("FEMALE", "F");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender MALE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender
			("MALE", "M");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender UNDIFFERENTIATED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender
			("UNDIFFERENTIATED", "UN");

		private readonly string codeValue;

		private AdministrativeGender(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ADMINISTRATIVE_GENDER.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystemName
		{
			get
			{
				return null;
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
