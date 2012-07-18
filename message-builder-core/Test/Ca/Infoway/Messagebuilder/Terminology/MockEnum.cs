using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Terminology;

namespace Ca.Infoway.Messagebuilder.Terminology
{
	[System.Serializable]
	public class MockEnum : EnumPattern, MockCharacters
	{
		static MockEnum()
		{
		}

		private const long serialVersionUID = -8250727697675835177L;

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum FRED = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("FRED");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum BARNEY = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("BARNEY");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum WILMA = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("WILMA");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum BETTY = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("BETTY");

		public static readonly Ca.Infoway.Messagebuilder.Terminology.MockEnum BAM_BAM = new Ca.Infoway.Messagebuilder.Terminology.MockEnum
			("BAM_BAM");

		private MockEnum(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return string.Empty;
			}
		}

		public virtual string CodeValue
		{
			get
			{
				return ToString();
			}
		}
	}
}
