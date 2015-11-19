using System;
using System.Collections.Generic;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Xml;
using Ca.Infoway.Messagebuilder.Xml.Service;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal interface Hl7Source
	{
		MessageDefinitionService GetService();

		string GetMessagePartName();

		XmlElement GetCurrentElement();

		VersionNumber GetVersion();

		TimeZoneInfo GetDateTimeZone();

		TimeZoneInfo GetDateTimeTimeZone();

		string Type
		{
			get;
		}

		XmlToModelResult GetResult();

		Hl7PartSource CreatePartSource(Relationship relationship, XmlElement currentElement);

		Hl7PartSource CreatePartSourceForSpecificType(Relationship relationship, XmlElement currentElement, string type);

		Relationship GetRelationship(string name);

		IList<Relationship> GetAllRelationships();

		Interaction GetInteraction();

		bool IsR2();

		bool IsCda();
	}
}
