using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Terminology
{
	[System.Serializable]
	public class MockStarTrek : EnumPattern, MockCharacters
	{
		static MockStarTrek()
		{
		}

		private const long serialVersionUID = -5314443670242023450L;

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockStarTrek KIRK = new Ca.Infoway.Messagebuilder.Terminology.MockStarTrek
			("KIRK");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockStarTrek SPOCK = new Ca.Infoway.Messagebuilder.Terminology.MockStarTrek
			("SPOCK");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockStarTrek MCCOY = new Ca.Infoway.Messagebuilder.Terminology.MockStarTrek
			("MCCOY");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockStarTrek PICARD = new Ca.Infoway.Messagebuilder.Terminology.MockStarTrek
			("PICARD");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockStarTrek DATA = new Ca.Infoway.Messagebuilder.Terminology.MockStarTrek
			("DATA");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockStarTrek OTHER = new Ca.Infoway.Messagebuilder.Terminology.MockStarTrek
			("OTHER");

		private MockStarTrek(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return "to.boldly.go";
			}
		}

		public virtual string CodeValue
		{
			get
			{
				return this != OTHER ? ToString() : null;
			}
		}

		public virtual NullFlavor GetNullFlavor()
		{
			return this != OTHER ? null : Ca.Infoway.Messagebuilder.Domainvalue.Nullflavor.NullFlavor.OTHER;
		}

		public virtual bool HasNullFlavor()
		{
			return this == OTHER;
		}
	}
}
