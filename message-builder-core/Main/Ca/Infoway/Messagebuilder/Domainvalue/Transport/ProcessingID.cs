using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>
	/// Codes used to specify whether a message is part of a production, training,
	/// or debugging system.
	/// </summary>
	/// <remarks>
	/// Codes used to specify whether a message is part of a production, training,
	/// or debugging system.
	/// </remarks>
	[System.Serializable]
	public class ProcessingID : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ProcessingID, Describable
	{
		static ProcessingID()
		{
		}

		private const long serialVersionUID = -4810533940602682646L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID DEBUGGING = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID
			("DEBUGGING", "D");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID PRODUCTION = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID
			("PRODUCTION", "P");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID TRAINING = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID
			("TRAINING", "T");

		private readonly string codeValue;

		private ProcessingID(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return string.Empty;
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
