using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum RoleClass.</summary>
	/// <remarks>The Enum RoleClass.</remarks>
	[System.Serializable]
	public class RoleClass : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.RoleClass, Describable
	{
		static RoleClass()
		{
		}

		private const long serialVersionUID = -4129204171430176848L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleClass ROLE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleClass
			("ROLE", "ROL");

		private readonly string codeValue;

		private RoleClass(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ROLE_CLASS.Root;
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
