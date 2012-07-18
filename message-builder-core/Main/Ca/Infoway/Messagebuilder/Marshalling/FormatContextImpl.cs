using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class FormatContextImpl : FormatContext
	{
		private readonly Relationship relationship;

		private readonly VersionNumber version;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		private FormatContextImpl(Relationship relationship, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			)
		{
			this.relationship = relationship;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
		}

		public static FormatContext Create(Relationship relationship, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.FormatContextImpl(relationship, version, dateTimeZone, dateTimeTimeZone);
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformanceLevel()
		{
			return this.relationship.Conformance;
		}

		public virtual string GetElementName()
		{
			return this.relationship.Name;
		}

		public virtual string Type
		{
			get
			{
				return this.relationship.Type;
			}
		}

		public virtual bool IsSpecializationType()
		{
			return false;
		}

		public virtual bool IsPassOnSpecializationType()
		{
			return true;
		}

		public virtual VersionNumber GetVersion()
		{
			return this.version;
		}

		public virtual TimeZone GetDateTimeZone()
		{
			return dateTimeZone;
		}

		public virtual TimeZone GetDateTimeTimeZone()
		{
			return dateTimeTimeZone;
		}
	}
}
