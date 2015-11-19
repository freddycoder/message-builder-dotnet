using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Resolver;

namespace Ca.Infoway.Messagebuilder.Resolver
{
	[System.Serializable]
	public class MockEnum : EnumPattern, MockCharacters
	{
		static MockEnum()
		{
		}

		private const long serialVersionUID = -8250727697675835177L;

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockEnum FRED = new Ca.Infoway.Messagebuilder.Resolver.MockEnum
			("FRED");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockEnum BARNEY = new Ca.Infoway.Messagebuilder.Resolver.MockEnum
			("BARNEY");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockEnum WILMA = new Ca.Infoway.Messagebuilder.Resolver.MockEnum
			("WILMA");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockEnum BETTY = new Ca.Infoway.Messagebuilder.Resolver.MockEnum
			("BETTY");

		public static readonly Ca.Infoway.Messagebuilder.Resolver.MockEnum BAM_BAM = new Ca.Infoway.Messagebuilder.Resolver.MockEnum
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

		public virtual string CodeSystemName
		{
			get
			{
				return null;
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
