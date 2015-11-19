using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Datatype.Lang.Util
{
	[System.Serializable]
	public class IntegrityCheckAlgorithm : EnumPattern
	{
		private const long serialVersionUID = 1L;

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.IntegrityCheckAlgorithm SHA_1 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.IntegrityCheckAlgorithm
			("SHA_1");

		public static readonly Ca.Infoway.Messagebuilder.Datatype.Lang.Util.IntegrityCheckAlgorithm SHA_256 = new Ca.Infoway.Messagebuilder.Datatype.Lang.Util.IntegrityCheckAlgorithm
			("SHA_256");

		private IntegrityCheckAlgorithm(string name) : base(name)
		{
		}
	}
}
