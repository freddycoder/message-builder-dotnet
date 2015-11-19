using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang.Util
{
	[System.Serializable]
	public class EdRepresentation : EnumPattern
	{
		private const long serialVersionUID = 1L;

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.EdRepresentation B64 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.EdRepresentation
			("B64");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.EdRepresentation TXT = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.EdRepresentation
			("TXT");

		private EdRepresentation(string name) : base(name)
		{
		}
	}
}
