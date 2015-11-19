using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum SeverityObservation.</summary>
	/// <remarks>
	/// The Enum SeverityObservation. An indication of the seriousness of a patient's medical
	/// condition or issues. Conditions for which severity levels are assigned include: disease state,
	/// allergies, intolerance and contraindications involving combinations of drugs and other conditions.
	/// </remarks>
	[System.Serializable]
	public class SeverityObservation : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.SeverityObservation
	{
		static SeverityObservation()
		{
		}

		private const long serialVersionUID = -5776943781743759764L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation HIGH = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation
			("HIGH", "H");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation MODERATE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation
			("MODERATE", "M");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation LOW = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.SeverityObservation
			("LOW", "L");

		private readonly string codeValue;

		private SeverityObservation(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_SEVERITY_OBSERVATION.Root;
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
