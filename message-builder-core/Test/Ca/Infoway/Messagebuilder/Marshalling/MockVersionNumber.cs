using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	public class MockVersionNumber : VersionNumber
	{
		public static readonly VersionNumber MOCK_NEWFOUNDLAND = new Ca.Infoway.Messagebuilder.Marshalling.MockVersionNumber("MOCK_NEWFOUNDLAND"
			, Hl7BaseVersion.MR2007);

		public static readonly VersionNumber MOCK_MR2009 = new Ca.Infoway.Messagebuilder.Marshalling.MockVersionNumber("MOCK_MR2009"
			, Hl7BaseVersion.MR2009);

		private readonly string literal;

		private readonly Hl7BaseVersion baseVersion;

		private MockVersionNumber(string literal, Hl7BaseVersion baseVersion)
		{
			this.literal = literal;
			this.baseVersion = baseVersion;
		}

		public virtual string VersionLiteral
		{
			get
			{
				return this.literal;
			}
		}

		public virtual Hl7BaseVersion GetBaseVersion()
		{
			return this.baseVersion;
		}

		public virtual Hl7BaseVersion GetBaseVersion(Typed datatype)
		{
			return GetBaseVersion();
		}
	}
}
