using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum x_ActMoodOrderEvent.</summary>
	/// <remarks>The Enum x_ActMoodOrderEvent.</remarks>
	[System.Serializable]
	public class x_ActMoodOrderEvent : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.x_ActMoodOrderEvent
	{
		static x_ActMoodOrderEvent()
		{
		}

		private const long serialVersionUID = 7047002739820769921L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.x_ActMoodOrderEvent EVENT = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.x_ActMoodOrderEvent
			("EVENT", "EVN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.x_ActMoodOrderEvent REQUEST = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.x_ActMoodOrderEvent
			("REQUEST", "RQO");

		private readonly string codeValue;

		private x_ActMoodOrderEvent(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_MOOD.Root;
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
	}
}
