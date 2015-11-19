using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>At the moment, this code set only supports one reason, used for the eReferrals ping.</summary>
	/// <remarks>
	/// At the moment, this code set only supports one reason, used for the eReferrals ping.
	/// Identifies why this specific query, modification request, or modification occurred.
	/// </remarks>
	[System.Serializable]
	public class ActReason : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActReason, Describable
	{
		static ActReason()
		{
		}

		private const long serialVersionUID = -4688667149166033487L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ActReason SYSTEM_TEST = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ActReason
			("SYSTEM_TEST", "SYSTEST");

		private readonly string codeValue;

		private ActReason(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.REFERRALS_ACT_REASON.Root;
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
