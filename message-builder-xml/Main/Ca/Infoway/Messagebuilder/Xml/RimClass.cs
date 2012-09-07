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

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ACT = new Ca.Infoway.Messagebuilder.Xml.RimClass("ACT", "Act"
			);

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ACT_RELATIONSHIP = new Ca.Infoway.Messagebuilder.Xml.RimClass
			("ACT_RELATIONSHIP", "ActRelationship");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ENTITY = new Ca.Infoway.Messagebuilder.Xml.RimClass("ENTITY"
			, "Entity");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass OTHER_CLASS = new Ca.Infoway.Messagebuilder.Xml.RimClass("OTHER_CLASS"
			, "OtherClass");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass PARTICIPATION = new Ca.Infoway.Messagebuilder.Xml.RimClass(
			"PARTICIPATION", "Participation");

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ROLE = new Ca.Infoway.Messagebuilder.Xml.RimClass("ROLE", "Role"
			);

		public static readonly Ca.Infoway.Messagebuilder.Xml.RimClass ROLE_LINK = new Ca.Infoway.Messagebuilder.Xml.RimClass("ROLE_LINK"
			, "RoleLink");

		private readonly string code;

		private RimClass(string name, string code) : base(name)
		{
			this.code = code;
		}

		public virtual string GetDescription()
		{
			return WordUtils.CapitalizeFully(Name);
		}

		public virtual string GetCode()
		{
			return this.code;
		}
	}
}
