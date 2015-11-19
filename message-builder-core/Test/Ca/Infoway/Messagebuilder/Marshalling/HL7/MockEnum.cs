using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7
{
	[System.Serializable]
	public class MockEnum : EnumPattern, MockCharacters
	{
		static MockEnum()
		{
		}

		private const long serialVersionUID = 2054176307399510076L;

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum FRED = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("FRED");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum BARNEY = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("BARNEY");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum WILMA = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("WILMA");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum BETTY = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("BETTY");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum BAM_BAM = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("BAM_BAM");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum CERX_MAX = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("12345678901234567890");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum CERX_MAX_PLUS_1 = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("123456789012345678901");

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum MR2009_MAX = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
			);

		public static readonly Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum MR2009_MAX_PLUS_1 = new Ca.Infoway.Messagebuilder.Marshalling.HL7.MockEnum
			("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901"
			);

		private MockEnum(string name) : base(name)
		{
		}

		public virtual string CodeSystem
		{
			get
			{
				return "1.2.3.4.5";
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

		public virtual string CodeValue
		{
			get
			{
				return ToString();
			}
		}
	}
}
