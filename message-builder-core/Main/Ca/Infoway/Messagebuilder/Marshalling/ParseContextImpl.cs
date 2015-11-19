using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class ParseContextImpl : ParseContext
	{
		private readonly Relationship relationship;

		private readonly VersionNumber version;

		private readonly TimeZoneInfo dateTimeZone;

		private readonly TimeZoneInfo dateTimeTimeZone;

		private readonly ConstrainedDatatype constraints;

		private readonly CodeTypeHandler codeTypeHandler;

		private readonly bool isCda;

		public ParseContextImpl(Relationship relationship, ConstrainedDatatype constraints, VersionNumber version, TimeZoneInfo dateTimeZone
			, TimeZoneInfo dateTimeTimeZone, CodeTypeHandler codeTypeHandler, bool isCda)
		{
			this.relationship = relationship;
			this.constraints = constraints;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.codeTypeHandler = codeTypeHandler;
			this.isCda = isCda;
		}

		public virtual System.Type GetExpectedReturnType()
		{
			return DomainTypeHelper.GetReturnType(this.relationship, this.version, this.codeTypeHandler);
		}

		public virtual string Type
		{
			get
			{
				return this.relationship.Type;
			}
		}

		public virtual VersionNumber GetVersion()
		{
			return this.version;
		}

		public virtual TimeZoneInfo GetDateTimeZone()
		{
			return this.dateTimeZone;
		}

		public virtual TimeZoneInfo GetDateTimeTimeZone()
		{
			return this.dateTimeTimeZone;
		}

		public virtual Int32? GetLength()
		{
			return this.relationship.Length;
		}

		public virtual CodingStrength GetCodingStrength()
		{
			return this.relationship.CodingStrength;
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformance()
		{
			return this.relationship.Conformance;
		}

		public virtual Cardinality GetCardinality()
		{
			return this.relationship.Cardinality;
		}

		public virtual ConstrainedDatatype GetConstraints()
		{
			return this.constraints;
		}

		public virtual bool IsCda()
		{
			return isCda;
		}

		public virtual bool IsFixedValue()
		{
			return relationship.HasFixedValue();
		}
	}
}
