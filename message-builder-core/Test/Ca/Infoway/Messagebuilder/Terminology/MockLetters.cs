using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Terminology
{
	[System.Serializable]
	public class MockLetters : EnumPattern, MockCharacters
	{
		static MockLetters()
		{
		}

		private const long serialVersionUID = 6400732969093598844L;

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters A = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("A");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters B = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("B");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters C = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("C");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters D = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("D");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters E = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("E");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters LMNO = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("LMNO");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockLetters OTHER = new Ca.Infoway.Messagebuilder.Terminology.MockLetters
			("OTHER");

		private MockLetters(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return "a.b.c.e.f.g.h";
			}
		}

		public virtual string CodeValue
		{
			get
			{
				return this != OTHER ? Name : null;
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
