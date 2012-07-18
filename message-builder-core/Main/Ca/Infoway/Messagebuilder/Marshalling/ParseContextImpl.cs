using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class ParseContextImpl : ParseContext
	{
		private readonly Relationship relationship;

		private readonly VersionNumber version;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		private ParseContextImpl(Relationship relationship, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			)
		{
			this.relationship = relationship;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
		}

		public static ParseContext Create(Relationship relationship, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.ParseContextImpl(relationship, version, dateTimeZone, dateTimeTimeZone);
		}

		public virtual System.Type GetExpectedReturnType()
		{
			return DomainTypeHelper.GetReturnType(this.relationship);
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

		public virtual TimeZone GetDateTimeZone()
		{
			return this.dateTimeZone;
		}

		public virtual TimeZone GetDateTimeTimeZone()
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
	}
}
