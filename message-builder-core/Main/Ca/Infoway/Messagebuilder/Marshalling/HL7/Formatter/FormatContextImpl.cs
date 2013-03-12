/**
 * Copyright 2013 Canada Health Infoway, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 * Author:        $LastChangedBy: tmcgrady $
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	internal class FormatContextImpl : FormatContext
	{
		private readonly ModelToXmlResult result;

		private readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel;

		private readonly string elementName;

		private readonly string type;

		private readonly bool isSpecializationType;

		private readonly bool isPassOnSpecializationType;

		private readonly VersionNumber version;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		private readonly string propertyPath;

		private CodingStrength codingStrength;

		private readonly string domainType;

		internal FormatContextImpl(ModelToXmlResult result, string propertyPath, string elementName, string type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			 conformanceLevel) : this(result, propertyPath, elementName, type, null, conformanceLevel, false, null, null, null, true
			, null)
		{
		}

		internal FormatContextImpl(ModelToXmlResult result, string propertyPath, string elementName, string type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			 conformanceLevel, bool isSpecializationType, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone, CodingStrength
			 codingStrength) : this(result, propertyPath, elementName, type, null, conformanceLevel, isSpecializationType, version, 
			dateTimeZone, dateTimeTimeZone, true, codingStrength)
		{
		}

		internal FormatContextImpl(ModelToXmlResult result, string propertyPath, string elementName, string type, string domainType
			, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, bool isSpecializationType, VersionNumber version, TimeZone
			 dateTimeZone, TimeZone dateTimeTimeZone, bool isPassOnSpecializationType, CodingStrength codingStrength)
		{
			this.result = result;
			this.propertyPath = propertyPath;
			this.elementName = elementName;
			this.type = type;
			this.domainType = domainType;
			this.conformanceLevel = conformanceLevel;
			this.isSpecializationType = isSpecializationType;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.isPassOnSpecializationType = isPassOnSpecializationType;
			this.codingStrength = codingStrength;
		}

		internal FormatContextImpl(string newType, FormatContext context) : this(newType, context.IsSpecializationType(), context
			.GetConformanceLevel(), context.GetElementName(), context)
		{
		}

		internal FormatContextImpl(string newType, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel newConformanceLevel, string elementName
			, FormatContext context) : this(newType, context.IsSpecializationType(), newConformanceLevel, elementName, context)
		{
		}

		internal FormatContextImpl(string newType, bool isSpecializationType, FormatContext context) : this(newType, isSpecializationType
			, context.GetConformanceLevel(), context.GetElementName(), context)
		{
		}

		internal FormatContextImpl(string newType, bool isSpecializationType, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel newConformanceLevel
			, string elementName, FormatContext context) : this(context.GetModelToXmlResult(), context.GetPropertyPath(), elementName
			, newType, context.GetDomainType(), newConformanceLevel, isSpecializationType, context.GetVersion(), context.GetDateTimeZone
			(), context.GetDateTimeTimeZone(), context.IsPassOnSpecializationType(), context.GetCodingStrength())
		{
		}

		public virtual ModelToXmlResult GetModelToXmlResult()
		{
			return this.result;
		}

		public virtual string GetPropertyPath()
		{
			return this.propertyPath;
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

		public virtual CodingStrength GetCodingStrength()
		{
			return this.codingStrength;
		}

		public virtual string GetDomainType()
		{
			return this.domainType;
		}
	}
}
