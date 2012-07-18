using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic
{
	/// <summary>The Enum Iso3166Alpha2Country.</summary>
	/// <remarks>The Enum Iso3166Alpha2Country.</remarks>
	[System.Serializable]
	public class Iso3166Alpha2Country : EnumPattern, Country
	{
		static Iso3166Alpha2Country()
		{
		}

		private const long serialVersionUID = -7361050354534966120L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.Iso3166Alpha2Country CANADA = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.Iso3166Alpha2Country
			("CANADA", "CA");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Basic.Iso3166Alpha2Country UNITED_STATES = new Ca.Infoway.Messagebuilder.Domainvalue.Basic.Iso3166Alpha2Country
			("UNITED_STATES", "US");

		private readonly string codeValue;

		private Iso3166Alpha2Country(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.ISO_3166_1_ALPHA_2.Root;
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
