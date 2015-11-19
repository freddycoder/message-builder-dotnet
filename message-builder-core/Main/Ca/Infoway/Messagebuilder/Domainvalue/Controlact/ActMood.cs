using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActMood.</summary>
	/// <remarks>The Enum ActMood.</remarks>
	[System.Serializable]
	public class ActMood : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActMood, Describable
	{
		static ActMood()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood DEF = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("DEF");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood EVN = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("EVN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood EVN_CRT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("EVN.CRT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood EVNINT_CRT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("EVNINT.CRT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood INT = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("INT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood PERM = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("PERM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood RQO = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActMood
			("RQO");

		private ActMood(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_MOOD.Root;
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

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return Name;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string Description
		{
			get
			{
				return DescribableUtil.GetDefaultDescription(this);
			}
		}
	}
}
