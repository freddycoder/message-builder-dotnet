using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum QuantityRequestLimit.</summary>
	/// <remarks>The Enum QuantityRequestLimit.</remarks>
	[System.Serializable]
	public class QuantityRequestLimit : EnumPattern, QueryRequestLimit
	{
		static QuantityRequestLimit()
		{
		}

		private const long serialVersionUID = 669843685953278565L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.QuantityRequestLimit RECORDS = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.QuantityRequestLimit
			("RECORDS", "RD");

		private readonly string codeValue;

		private QuantityRequestLimit(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return "2.16.840.1.113883.5.1112";
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
	}
}
