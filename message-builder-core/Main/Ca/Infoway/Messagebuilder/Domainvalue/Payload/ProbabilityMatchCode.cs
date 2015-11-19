using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum ProbabilityMatchCode.</summary>
	/// <remarks>
	/// The Enum ProbabilityMatchCode. An observation related to a query response.
	/// Example: The degree of match or match weight returned by a matching algorithm in a response to a query.
	/// </remarks>
	[System.Serializable]
	public class ProbabilityMatchCode : EnumPattern, ObservationQueryMatchType, Describable
	{
		static ProbabilityMatchCode()
		{
		}

		private const long serialVersionUID = -4412180444594616563L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ProbabilityMatchCode PATTERN_MATCH = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ProbabilityMatchCode
			("PATTERN_MATCH", "PTNM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ProbabilityMatchCode PHONETIC_MATCH = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ProbabilityMatchCode
			("PHONETIC_MATCH", "PHCM");

		private readonly string codeValue;

		private ProbabilityMatchCode(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.SC_TEMP.Root;
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
