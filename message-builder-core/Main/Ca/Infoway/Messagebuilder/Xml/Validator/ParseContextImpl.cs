using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml.Validator
{
	internal class ParseContextImpl : ParseContext
	{
		private readonly Relationship relationship;

		private readonly VersionNumber version;

		private ParseContextImpl(Relationship relationship, VersionNumber version)
		{
			this.relationship = relationship;
			this.version = version;
		}

		public static ParseContext Create(Relationship relationship, VersionNumber version)
		{
			return new Ca.Infoway.Messagebuilder.Xml.Validator.ParseContextImpl(relationship, version);
		}

		public virtual System.Type GetExpectedReturnType()
		{
			return DomainTypeHelper.GetReturnType(this.relationship, this.version);
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
			return null;
		}

		public virtual TimeZone GetDateTimeTimeZone()
		{
			return null;
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
