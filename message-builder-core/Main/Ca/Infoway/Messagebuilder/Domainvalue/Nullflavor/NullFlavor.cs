using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor
{
	/// <summary>The Enum NullFlavor.</summary>
	/// <remarks>The Enum NullFlavor. Indicates why a value is not present</remarks>
	[System.Serializable]
	public class NullFlavor : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.NullFlavor
	{
		static NullFlavor()
		{
		}

		private const long serialVersionUID = 7363875379566291402L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor NO_INFORMATION = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("NO_INFORMATION", "NI");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor OTHER = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("OTHER", "OTH");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor NEGATIVE_INFINITY = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("NEGATIVE_INFINITY", "NINF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor POSITIVE_INFINITY = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("POSITIVE_INFINITY", "PINF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor UNKNOWN = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("UNKNOWN", "UNK");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor ASKED_BUT_UNKNOWN = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("ASKED_BUT_UNKNOWN", "ASKU");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor TEMPORARILY_UNAVAILABLE = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("TEMPORARILY_UNAVAILABLE", "NAV");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor SUFFICIENT_QUANTITY = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("SUFFICIENT_QUANTITY", "QS");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor NOT_ASKED = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("NOT_ASKED", "NASK");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor TRACE = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("TRACE", "TRC");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor MASKED = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("MASKED", "MSK");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor NOT_APPLICABLE = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("NOT_APPLICABLE", "NA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor UN_ENCODED = new Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor
			("UN_ENCODED", "UNC");

		private readonly string codeValue;

		private NullFlavor(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
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
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_NULL_FLAVOR.Root;
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
	}
}
