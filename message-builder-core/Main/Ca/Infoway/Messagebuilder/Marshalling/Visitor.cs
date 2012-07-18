using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal interface Visitor
	{
		void VisitRootStart(PartBridge tealBean, Interaction interaction);

		void VisitRootEnd(PartBridge tealBean, Interaction interaction);

		void VisitAttribute(AttributeBridge tealBean, Relationship relationship, VersionNumber version, TimeZone dateTimeZone, TimeZone
			 dateTimeTimeZone);

		void VisitAssociationStart(PartBridge tealBean, Relationship relationship);

		void VisitAssociationEnd(PartBridge tealBean, Relationship relationship);
	}
}
