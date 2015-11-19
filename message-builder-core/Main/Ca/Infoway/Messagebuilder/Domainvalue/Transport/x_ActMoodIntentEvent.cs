using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum x_ActMoodIntentEvent.</summary>
	/// <remarks>The Enum x_ActMoodIntentEvent.</remarks>
	[System.Serializable]
	public class x_ActMoodIntentEvent : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.x_ActMoodIntentEvent, Describable
	{
		static x_ActMoodIntentEvent()
		{
		}

		private const long serialVersionUID = -90066419599911191L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.x_ActMoodIntentEvent EVENT = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.x_ActMoodIntentEvent
			("EVN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.x_ActMoodIntentEvent REQUEST = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.x_ActMoodIntentEvent
			("RQO");

		private x_ActMoodIntentEvent(string codeValue) : base(codeValue)
		{
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
