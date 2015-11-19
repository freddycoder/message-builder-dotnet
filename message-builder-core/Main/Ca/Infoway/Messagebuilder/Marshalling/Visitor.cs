using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal interface Visitor
	{
		void VisitRootStart(PartBridge tealBean, Interaction interaction);

		void VisitRootEnd(PartBridge tealBean, Interaction interaction);

		void VisitAttribute(AttributeBridge tealBean, Relationship relationship, ConstrainedDatatype constraints, VersionNumber version
			, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone);

		void VisitAssociationStart(PartBridge tealBean, Relationship relationship);

		void VisitAssociationEnd(PartBridge tealBean, Relationship relationship);

		void LogError(Hl7Error error);

		string GetCurrentPropertyPath();
	}
}
