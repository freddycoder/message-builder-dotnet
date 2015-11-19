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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Formatter
{
	public class FormatContextImpl : FormatContext
	{
		private readonly ModelToXmlResult result;

		private readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel;

		private readonly string elementName;

		private readonly string type;

		private readonly bool isSpecializationType;

		private readonly VersionNumber version;

		private readonly TimeZoneInfo dateTimeZone;

		private readonly TimeZoneInfo dateTimeTimeZone;

		private readonly string propertyPath;

		private readonly CodingStrength codingStrength;

		private readonly Cardinality cardinality;

		private readonly string domainType;

		private readonly ConstrainedDatatype constraints;

		private readonly bool isCda;

		public FormatContextImpl(string newType, FormatContext context) : this(newType, false, context.GetConformanceLevel(), context
			.GetCardinality(), context.GetElementName(), context)
		{
		}

		public FormatContextImpl(string newType, bool isSpecializationType, FormatContext context) : this(newType, isSpecializationType
			, context.GetConformanceLevel(), context.GetCardinality(), context.GetElementName(), context)
		{
		}

		public FormatContextImpl(string newType, string newElementName, FormatContext context) : this(newType, false, context.GetConformanceLevel
			(), context.GetCardinality(), newElementName, context)
		{
		}

		public FormatContextImpl(string newType, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel newConformanceLevel, Cardinality 
			newCardinality, string elementName, FormatContext context) : this(newType, false, newConformanceLevel, newCardinality, elementName
			, context)
		{
		}

		public FormatContextImpl(string newType, bool isSpecializationType, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel newConformanceLevel
			, Cardinality newCardinality, string elementName, FormatContext context) : this(context.GetModelToXmlResult(), context.GetPropertyPath
			(), elementName, newType, context.GetDomainType(), newConformanceLevel, newCardinality, isSpecializationType, context.GetVersion
			(), context.GetDateTimeZone(), context.GetDateTimeTimeZone(), context.GetCodingStrength(), null, context.IsCda())
		{
		}

		public FormatContextImpl(ModelToXmlResult result, string propertyPath, string elementName, string type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			 conformanceLevel, Cardinality cardinality, bool isCda) : this(result, propertyPath, elementName, type, null, conformanceLevel
			, cardinality, false, null, null, null, null, null, isCda)
		{
		}

		public FormatContextImpl(ModelToXmlResult result, string propertyPath, string elementName, string type, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			 conformanceLevel, Cardinality cardinality, bool isSpecializationType, VersionNumber version, TimeZoneInfo dateTimeZone, 
			TimeZoneInfo dateTimeTimeZone, CodingStrength codingStrength, bool isCda) : this(result, propertyPath, elementName, type
			, null, conformanceLevel, cardinality, isSpecializationType, version, dateTimeZone, dateTimeTimeZone, codingStrength, null
			, isCda)
		{
		}

		public FormatContextImpl(ModelToXmlResult result, string propertyPath, string elementName, string type, string domainType
			, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformanceLevel, Cardinality cardinality, bool isSpecializationType, VersionNumber
			 version, TimeZoneInfo dateTimeZone, TimeZoneInfo dateTimeTimeZone, CodingStrength codingStrength, ConstrainedDatatype constraints
			, bool isCda)
		{
			// TM - CDA - modified this case to set isSpecializationType to false (must specifically specify this value if it is required)
			// TM - CDA - modified this case to set isSpecializationType to false (must specifically specify this value if it is required)
			// TM - CDA - modified this case to set isSpecializationType to false (must specifically specify this value if it is required)
			// constraints not automatically passed on
			// tests only
			// tests only
			this.result = result;
			this.propertyPath = propertyPath;
			this.elementName = elementName;
			this.type = type;
			this.domainType = domainType;
			this.conformanceLevel = conformanceLevel;
			this.cardinality = cardinality;
			this.isSpecializationType = isSpecializationType;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.codingStrength = codingStrength;
			this.constraints = constraints;
			this.isCda = isCda;
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

		public virtual Cardinality GetCardinality()
		{
			return this.cardinality;
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

		public virtual TimeZoneInfo GetDateTimeZone()
		{
			return this.dateTimeZone;
		}

		public virtual TimeZoneInfo GetDateTimeTimeZone()
		{
			return this.dateTimeTimeZone;
		}

		public virtual CodingStrength GetCodingStrength()
		{
			return this.codingStrength;
		}

		public virtual string GetDomainType()
		{
			return this.domainType;
		}

		public virtual bool IsFixed()
		{
			// assumes that this version of FormatContext is only ever used for non-fixed relationships (might change later)
			return false;
		}

		public virtual ConstrainedDatatype GetConstraints()
		{
			return this.constraints;
		}

		public virtual bool IsCda()
		{
			return this.isCda;
		}
	}
}
