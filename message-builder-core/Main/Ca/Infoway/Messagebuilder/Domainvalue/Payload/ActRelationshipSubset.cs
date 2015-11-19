using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum ActRelationshipSubset.</summary>
	/// <remarks>The Enum ActRelationshipSubset.</remarks>
	[System.Serializable]
	public class ActRelationshipSubset : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActRelationshipSubset, Describable
	{
		static ActRelationshipSubset()
		{
		}

		private const long serialVersionUID = -617461458714176662L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset EXPECTED_FUTURE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("EXPECTED_FUTURE", "FUTURE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset EXPECTED_LAST = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("EXPECTED_LAST", "LAST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset EXPECTED_NEXT = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("EXPECTED_NEXT", "NEXT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset FIRST_KNOWN = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("FIRST_KNOWN", "FIRST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset FUTURE_SUMMARY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("FUTURE_SUMMARY", "FUTSUM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset MAXIMUM = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("MAXIMUM", "MAX");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset MINIMUM = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("MINIMUM", "MIN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset MOST_RECENT = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("MOST_RECENT", "RECENT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset PREVIOUS = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("PREVIOUS", "PAST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset PREVIOUS_SUMMARY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("PREVIOUS_SUMMARY", "PREVSUM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset SUMMARY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("SUMMARY", "SUM");

		private readonly string codeValue;

		private ActRelationshipSubset(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_RELATIONSHIP_SUBSET.Root;
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
