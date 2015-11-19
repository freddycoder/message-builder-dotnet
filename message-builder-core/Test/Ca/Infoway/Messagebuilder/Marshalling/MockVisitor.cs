using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class MockVisitor : Visitor
	{
		private bool rootStarted;

		private bool rootEnded;

		private bool attributeVisited;

		public virtual bool IsRootStarted()
		{
			return rootStarted;
		}

		public virtual void SetRootStarted(bool rootStarted)
		{
			this.rootStarted = rootStarted;
		}

		public virtual void VisitAssociationEnd(PartBridge tealBean, Relationship relationship)
		{
		}

		public virtual void VisitAssociationStart(PartBridge tealBean, Relationship relationship)
		{
		}

		public virtual void VisitAttribute(AttributeBridge tealBean, Relationship relationship, ConstrainedDatatype constraints, 
			VersionNumber version, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone)
		{
			this.attributeVisited = true;
		}

		public virtual void VisitRootEnd(PartBridge tealBean, Interaction interaction)
		{
			this.rootEnded = true;
		}

		public virtual void VisitRootStart(PartBridge tealBean, Interaction interaction)
		{
			this.rootStarted = true;
		}

		public virtual bool IsRootEnded()
		{
			return this.rootEnded;
		}

		public virtual bool IsAttributeVisited()
		{
			return this.attributeVisited;
		}

		public virtual void LogError(Hl7Error error)
		{
		}

		// do nothing
		public virtual string GetCurrentPropertyPath()
		{
			return string.Empty;
		}
	}
}
