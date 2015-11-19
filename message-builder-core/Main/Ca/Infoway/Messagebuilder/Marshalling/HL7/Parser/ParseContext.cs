using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public interface ParseContext : Typed
	{
		Type GetExpectedReturnType();

		VersionNumber GetVersion();

		TimeZoneInfo GetDateTimeZone();

		TimeZoneInfo GetDateTimeTimeZone();

		Int32? GetLength();

		CodingStrength GetCodingStrength();

		Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformance();

		Cardinality GetCardinality();

		ConstrainedDatatype GetConstraints();

		bool IsCda();

		bool IsFixedValue();
	}
}
