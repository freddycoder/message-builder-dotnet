using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActSpecimenTransportationCode.</summary>
	/// <remarks>The Enum ActSpecimenTransportationCode.</remarks>
	[System.Serializable]
	public class ActSpecimenTransportationCode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActSpecimenTransportationCode
		, Describable
	{
		static ActSpecimenTransportationCode()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActSpecimenTransportationCode SREC = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActSpecimenTransportationCode
			("SREC");

		private ActSpecimenTransportationCode(string name) : base(name)
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
