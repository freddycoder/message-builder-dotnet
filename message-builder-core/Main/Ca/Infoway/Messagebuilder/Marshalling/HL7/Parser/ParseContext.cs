using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public interface ParseContext : Typed
	{
		Type GetExpectedReturnType();

		VersionNumber GetVersion();

		TimeZone GetDateTimeZone();

		TimeZone GetDateTimeTimeZone();

		Int32? GetLength();

		CodingStrength GetCodingStrength();

		Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformance();
	}
}
