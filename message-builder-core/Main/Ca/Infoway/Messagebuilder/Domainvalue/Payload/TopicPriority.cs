using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum TopicPriority.</summary>
	/// <remarks>The Enum TopicPriority.</remarks>
	[System.Serializable]
	public class TopicPriority : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.TopicPriority, Describable
	{
		static TopicPriority()
		{
		}

		private const long serialVersionUID = 4476190535780761850L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority NL_MANDATORY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority
			("NL_MANDATORY", "NL_MAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority GROUP_MANDATORY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority
			("GROUP_MANDATORY", "GROUP_MAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority OPTIONAL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority
			("OPTIONAL", "OPTIONAL");

		private readonly string codeValue;

		private TopicPriority(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.TOPIC_PRIORITY.Root;
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
