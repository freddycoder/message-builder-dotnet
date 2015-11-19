using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	internal class MockCodeImpl : Code
	{
		private readonly string codeValue;

		private readonly string codeSystem;

		public MockCodeImpl(string codeValue, string codeSystem)
		{
			this.codeValue = codeValue;
			this.codeSystem = codeSystem;
		}

		public virtual string CodeSystem
		{
			get
			{
				return this.codeSystem;
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
				return this.codeValue;
			}
		}
	}
}
