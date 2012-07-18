using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActIssuePriority.</summary>
	/// <remarks>The Enum ActIssuePriority. Indicates the relative importance or priority of a detected issue</remarks>
	[System.Serializable]
	public class ActIssuePriority : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActIssuePriority
	{
		static ActIssuePriority()
		{
		}

		private const long serialVersionUID = 5357530778447095336L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority ERROR = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority
			("ERROR", "E");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority INFORMATION = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority
			("INFORMATION", "I");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority WARNING = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority
			("WARNING", "W");

		private readonly string codeValue;

		private ActIssuePriority(string name, string codeValue) : base(name)
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
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}
	}
}
