using System;
using Ca.Infoway.Messagebuilder;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public interface FormatContext
	{
		string GetElementName();

		string Type
		{
			get;
		}

		bool IsSpecializationType();

		bool IsPassOnSpecializationType();

		Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformanceLevel();

		VersionNumber GetVersion();

		TimeZone GetDateTimeZone();

		TimeZone GetDateTimeTimeZone();
	}
}
