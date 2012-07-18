using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActSubstanceAdministrationImmunizationCode.</summary>
	/// <remarks>The Enum ActSubstanceAdministrationImmunizationCode.</remarks>
	[System.Serializable]
	public class ActSubstanceAdministrationImmunizationCode : EnumPattern, ActSubstanceAdministrationCode, Describable
	{
		static ActSubstanceAdministrationImmunizationCode()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActSubstanceAdministrationImmunizationCode IMMUNIZ
			 = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActSubstanceAdministrationImmunizationCode("IMMUNIZ");

		private ActSubstanceAdministrationImmunizationCode(string name) : base(name)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_CODE.Root;
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
