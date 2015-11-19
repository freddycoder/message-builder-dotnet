using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum AcknowledgementDetailType.</summary>
	/// <remarks>
	/// The Enum AcknowledgementDetailType. A code distinguishing between errors,
	/// warnings and information messages related to the transmission of the message
	/// </remarks>
	[System.Serializable]
	public class AcknowledgementDetailType : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.AcknowledgementDetailType
	{
		static AcknowledgementDetailType()
		{
		}

		private const long serialVersionUID = -5837485473668582469L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType ERROR = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType
			("ERROR", "E");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType INFORMATION = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType
			("INFORMATION", "I");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType WARNING = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType
			("WARNING", "W");

		private readonly string codeValue;

		private AcknowledgementDetailType(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACKNOWLEDGEMENT_DETAIL_TYPE.Root;
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
	}
}
