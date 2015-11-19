using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum SubscriptionStatus.</summary>
	/// <remarks>The Enum SubscriptionStatus.</remarks>
	[System.Serializable]
	public class SubscriptionStatus : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.SubscriptionStatus, Describable
	{
		static SubscriptionStatus()
		{
		}

		private const long serialVersionUID = -8472481397627274517L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.SubscriptionStatus SUBSCRIBED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.SubscriptionStatus
			("SUBSCRIBED", "1");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.SubscriptionStatus UNSUBSCRIBED = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.SubscriptionStatus
			("UNSUBSCRIBED", "2");

		private readonly string codeValue;

		private SubscriptionStatus(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.SUBSCRIPTION_STATUS.Root;
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
