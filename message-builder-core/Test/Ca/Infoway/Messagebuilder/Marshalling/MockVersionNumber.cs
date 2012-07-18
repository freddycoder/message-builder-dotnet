using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class MockVersionNumber : VersionNumber
	{
		public static readonly VersionNumber MOCK_NEWFOUNDLAND = new Ca.Infoway.Messagebuilder.Marshalling.MockVersionNumber("MOCK_NEWFOUNDLAND"
			);

		public static readonly VersionNumber MOCK_MR2009 = new Ca.Infoway.Messagebuilder.Marshalling.MockVersionNumber("MOCK_MR2009"
			);

		private readonly string literal;

		private MockVersionNumber(string literal)
		{
			this.literal = literal;
		}

		public virtual string VersionLiteral
		{
			get
			{
				return this.literal;
			}
		}

		public virtual VersionNumber GetBaseVersion()
		{
			return this;
		}
	}
}
