using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>
	/// Codes representing the defined possible Normal states of an Role, as defined by the Role
	/// class state machine.
	/// </summary>
	/// <remarks>
	/// Codes representing the defined possible Normal states of an Role, as defined by the Role
	/// class state machine.
	/// Differentiates whether the role is active, suspended or terminated
	/// </remarks>
	/// <author>BC Holmes</author>
	[System.Serializable]
	public class RoleStatusNormal : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.RoleStatusNormal, Describable
	{
		static RoleStatusNormal()
		{
		}

		private const long serialVersionUID = -8503517204278317948L;

		/// <summary>The state representing the fact that the Entity is currently active in the Role.</summary>
		/// <remarks>The state representing the fact that the Entity is currently active in the Role.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatusNormal ACTIVE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatusNormal
			("ACTIVE");

		/// <summary>The state that represents a suspension of the Entity playing the Role.</summary>
		/// <remarks>
		/// The state that represents a suspension of the Entity playing the Role.
		/// This state is arrived at from the "active" state.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatusNormal SUSPENDED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatusNormal
			("SUSPENDED");

		/// <summary>The state representing the successful termination of the Role.</summary>
		/// <remarks>The state representing the successful termination of the Role.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatusNormal TERMINATED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.RoleStatusNormal
			("TERMINATED");

		private RoleStatusNormal(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ROLE_STATUS.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				// another unusual case where the code value is in lower case
				return Name.ToLower();
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
