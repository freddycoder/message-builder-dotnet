using System;
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

		TimeZone GetDateTimeZone();

		TimeZone GetDateTimeTimeZone();

		string Type
		{
			get;
		}

		XmlToModelResult GetResult();

		Hl7PartSource CreatePartSource(Relationship relationship, XmlElement currentElement);

		Relationship GetRelationship(string name);

		Interaction GetInteraction();
	}
}
