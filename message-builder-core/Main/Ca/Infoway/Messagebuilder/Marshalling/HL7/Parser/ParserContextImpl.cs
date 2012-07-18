using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal class ParserContextImpl : ParseContext
	{
		private readonly System.Type expectedReturnType;

		private readonly string type;

		private readonly VersionNumber version;

		private readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance;

		private readonly CodingStrength strength;

		private readonly Int32? length;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		private ParserContextImpl(string type, System.Type returnType, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance, CodingStrength strength, Int32? length)
		{
			this.type = type;
			this.expectedReturnType = returnType;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.conformance = conformance;
			this.strength = strength;
			this.length = length;
		}

		public virtual string Type
		{
			get
			{
				return this.type;
			}
		}

		public virtual System.Type GetExpectedReturnType()
		{
			return this.expectedReturnType;
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

		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformance()
		{
			return this.conformance;
		}

		internal static ParseContext Create(string type, System.Type returnType, VersionNumber version, TimeZone dateTimeZone, TimeZone
			 dateTimeTimeZone, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserContextImpl(type, returnType, version, dateTimeZone, dateTimeTimeZone
				, conformance, null, null);
		}

		public virtual CodingStrength GetCodingStrength()
		{
			return this.strength;
		}

		public virtual Int32? GetLength()
		{
			return this.length;
		}

		public static ParseContext Create(string type, System.Type returnType, VersionNumber version, TimeZone dateTimeZone, TimeZone
			 dateTimeTimeZone, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance, CodingStrength strength, Int32? length)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserContextImpl(type, returnType, version, dateTimeZone, dateTimeTimeZone
				, conformance, strength, length);
		}
	}
}
