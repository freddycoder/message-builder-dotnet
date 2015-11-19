using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>
	/// The codes identify the conditions under which accept acknowledgements are
	/// required to be returned in response to this message.
	/// </summary>
	/// <remarks>
	/// The codes identify the conditions under which accept acknowledgements are
	/// required to be returned in response to this message. Note that accept acknowledgement
	/// address two different issues at the same time: reliable transport as well as syntactical correct
	/// </remarks>
	/// <author>administrator</author>
	[System.Serializable]
	public class AcknowledgementCondition : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.AcknowledgementCondition, Describable
	{
		static AcknowledgementCondition()
		{
		}

		private const long serialVersionUID = 7605543876867112424L;

		/// <summary>Always send an acknowledgement.</summary>
		/// <remarks>Always send an acknowledgement.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition ALWAYS = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition
			("ALWAYS", "AL");

		/// <summary>Send an acknowledgement for error/reject conditions only.</summary>
		/// <remarks>Send an acknowledgement for error/reject conditions only.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition ERRORS_ONLY = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition
			("ERRORS_ONLY", "ER");

		/// <summary>Never send an acknowledgement.</summary>
		/// <remarks>Never send an acknowledgement.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition NEVER = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition
			("NEVER", "NE");

		private readonly string codeValue;

		private AcknowledgementCondition(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACKNOWLEDGEMENT_CONDITION.Root;
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
