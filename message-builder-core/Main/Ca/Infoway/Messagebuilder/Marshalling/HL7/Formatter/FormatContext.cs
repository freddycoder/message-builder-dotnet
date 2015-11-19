using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public interface FormatContext : Typed
	{
		ModelToXmlResult GetModelToXmlResult();

		string GetPropertyPath();

		string GetElementName();

		string Type
		{
			get;
		}

		string GetDomainType();

		bool IsFixed();

		CodingStrength GetCodingStrength();

		bool IsSpecializationType();

		Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformanceLevel();

		Cardinality GetCardinality();

		VersionNumber GetVersion();

		TimeZoneInfo GetDateTimeZone();

		TimeZoneInfo GetDateTimeTimeZone();

		ConstrainedDatatype GetConstraints();

		bool IsCda();
	}
}
