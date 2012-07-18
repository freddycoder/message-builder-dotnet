using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum RoleCode.</summary>
	/// <remarks>The Enum RoleCode. Created manually.</remarks>
	[System.Serializable]
	public class RoleCode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.RoleCode, Describable
	{
		static RoleCode()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.RoleCode P = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.RoleCode
			("P");

		private RoleCode(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ROLE_CODE.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return Name;
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
