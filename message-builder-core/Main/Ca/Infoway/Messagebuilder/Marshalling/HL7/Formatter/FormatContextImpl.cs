using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	internal class FormatContextImpl : FormatContext
	{
		private readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel;

		private readonly string elementName;

		private readonly string type;

		private readonly bool isSpecializationType;

		private readonly bool isPassOnSpecializationType;

		private readonly VersionNumber version;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		internal FormatContextImpl(string elementName, string type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel
			) : this(elementName, type, conformanceLevel, false, null, null, null, true)
		{
		}

		internal FormatContextImpl(string elementName, string type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel
			, bool isSpecializationType, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone) : this(elementName
			, type, conformanceLevel, isSpecializationType, version, dateTimeZone, dateTimeTimeZone, true)
		{
		}

		internal FormatContextImpl(string elementName, string type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel
			, bool isSpecializationType, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone, bool isPassOnSpecializationType
			)
		{
			this.elementName = elementName;
			this.type = type;
			this.conformanceLevel = conformanceLevel;
			this.isSpecializationType = isSpecializationType;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.isPassOnSpecializationType = isPassOnSpecializationType;
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformanceLevel()
		{
			return this.conformanceLevel;
		}

		public virtual string GetElementName()
		{
			return this.elementName;
		}

		public virtual string Type
		{
			get
			{
				return this.type;
			}
		}

		public virtual bool IsSpecializationType()
		{
			return this.isSpecializationType;
		}

		public virtual VersionNumber GetVersion()
		{
			return this.version;
		}

		public virtual TimeZone GetDateTimeZone()
		{
			return this.dateTimeZone;
		}

		public virtual TimeZone GetDateTimeTimeZone()
		{
			return this.dateTimeTimeZone;
		}

		public virtual bool IsPassOnSpecializationType()
		{
			return this.isPassOnSpecializationType;
		}
	}
}
