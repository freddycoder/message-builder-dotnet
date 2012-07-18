using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal class TrivialContext : ParseContext
	{
		private readonly string type;

		public TrivialContext(string type)
		{
			this.type = type;
		}

		public virtual CodingStrength GetCodingStrength()
		{
			return null;
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformance()
		{
			return null;
		}

		public virtual System.Type GetExpectedReturnType()
		{
			return null;
		}

		public virtual Int32? GetLength()
		{
			return null;
		}

		public virtual VersionNumber GetVersion()
		{
			return null;
		}

		public virtual TimeZone GetDateTimeZone()
		{
			return null;
		}

		public virtual TimeZone GetDateTimeTimeZone()
		{
			return null;
		}

		public virtual string Type
		{
			get
			{
				return this.type;
			}
		}
	}
}
