using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum TriggerEventId.</summary>
	/// <remarks>The Enum TriggerEventId. Created manually.</remarks>
	[System.Serializable]
	public class TriggerEventId : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActCode, Describable
	{
		static TriggerEventId()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.TriggerEventId PORX_TE010340CA = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.TriggerEventId
			("PORX_TE010340CA");

		private TriggerEventId(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_CODE.Root;
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
