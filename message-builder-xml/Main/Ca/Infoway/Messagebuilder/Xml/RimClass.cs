using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Xml
{
	[System.Serializable]
	public class RimClass : EnumPattern
	{
		static RimClass()
		{
		}

		private const long serialVersionUID = -8779975480440476740L;

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ACT = new Ca.Infoway.Messagebuilder.Xml.RimClass("ACT");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ACT_RELATIONSHIP = new Ca.Infoway.Messagebuilder.Xml.RimClass
			("ACT_RELATIONSHIP");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ENTITY = new Ca.Infoway.Messagebuilder.Xml.RimClass("ENTITY"
			);

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass PARTICIPATION = new Ca.Infoway.Messagebuilder.Xml.RimClass(
			"PARTICIPATION");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ROLE = new Ca.Infoway.Messagebuilder.Xml.RimClass("ROLE");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ROLE_LINK = new Ca.Infoway.Messagebuilder.Xml.RimClass("ROLE_LINK"
			);

		private RimClass(string name) : base(name)
		{
		}

		public virtual string GetDescription()
		{
			return WordUtils.CapitalizeFully(Name);
		}

		public virtual string GetCode()
		{
			return Name;
		}
	}
}
