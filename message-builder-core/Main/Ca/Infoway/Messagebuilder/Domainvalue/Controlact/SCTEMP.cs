using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum SCTEMP.</summary>
	/// <remarks>The Enum SCTEMP. Created manually.</remarks>
	[System.Serializable]
	public class SCTEMP : EnumPattern, Code, Describable
	{
		static SCTEMP()
		{
		}

		private const long serialVersionUID = 584607967819653758L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.SCTEMP SRTKEY = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.SCTEMP
			("SRTKEY");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.SCTEMP VFPAPER = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.SCTEMP
			("VFPAPER");

		private SCTEMP(string name) : base(name)
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
