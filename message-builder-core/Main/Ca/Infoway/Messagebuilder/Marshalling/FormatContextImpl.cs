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

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class FormatContextImpl : FormatContext
	{
		private readonly ModelToXmlResult result;

		private readonly Relationship relationship;

		private readonly VersionNumber version;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		private readonly string propertyPath;

		private readonly CodingStrength codingStrength;

		private FormatContextImpl(ModelToXmlResult result, string propertyPath, Relationship relationship, VersionNumber version, 
			TimeZone dateTimeZone, TimeZone dateTimeTimeZone, CodingStrength codingStrength)
		{
			this.result = result;
			this.propertyPath = propertyPath;
			this.relationship = relationship;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.codingStrength = codingStrength;
		}

		public static FormatContext Create(ModelToXmlResult result, string propertyPath, Relationship relationship, VersionNumber
			 version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone, CodingStrength codingStrength)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.FormatContextImpl(result, propertyPath, relationship, version, dateTimeZone
				, dateTimeTimeZone, codingStrength);
		}

		public virtual ModelToXmlResult GetModelToXmlResult()
		{
			return result;
		}

		public virtual string GetPropertyPath()
		{
			return this.propertyPath;
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

		public virtual CodingStrength GetCodingStrength()
		{
			return this.codingStrength;
		}

		public virtual string GetDomainType()
		{
			return this.relationship.DomainType;
		}
	}
}
