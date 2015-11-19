using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum ProcessingMode.</summary>
	/// <remarks>The Enum ProcessingMode.</remarks>
	[System.Serializable]
	public class ProcessingMode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ProcessingMode, Describable
	{
		static ProcessingMode()
		{
		}

		private const long serialVersionUID = -4741683761461235584L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode ARCHIVE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode
			("ARCHIVE", "A");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode CURRENT_PROCESSING = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode
			("CURRENT_PROCESSING", "T");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode INITIAL_LOAD = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode
			("INITIAL_LOAD", "I");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode RESTORE_FROM_ARCHIVE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode
			("RESTORE_FROM_ARCHIVE", "R");

		private readonly string codeValue;

		private ProcessingMode(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_PROCESSING_MODE.Root;
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
				return this.codeValue;
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
