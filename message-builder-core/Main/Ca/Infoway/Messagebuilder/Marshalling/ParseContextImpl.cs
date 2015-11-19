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
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling
{
	internal class ParseContextImpl : ParseContext
	{
		private readonly Relationship relationship;

		private readonly VersionNumber version;

		private readonly TimeZoneInfo dateTimeZone;

		private readonly TimeZoneInfo dateTimeTimeZone;

		private readonly ConstrainedDatatype constraints;

		private readonly CodeTypeHandler codeTypeHandler;

		private readonly bool isCda;

		public ParseContextImpl(Relationship relationship, ConstrainedDatatype constraints, VersionNumber version, TimeZoneInfo dateTimeZone
			, TimeZoneInfo dateTimeTimeZone, CodeTypeHandler codeTypeHandler, bool isCda)
		{
			this.relationship = relationship;
			this.constraints = constraints;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.codeTypeHandler = codeTypeHandler;
			this.isCda = isCda;
		}

		public virtual System.Type GetExpectedReturnType()
		{
			return DomainTypeHelper.GetReturnType(this.relationship, this.version, this.codeTypeHandler);
		}

		public virtual string Type
		{
			get
			{
				return this.relationship.Type;
			}
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

		public virtual Int32? GetLength()
		{
			return this.relationship.Length;
		}

		public virtual CodingStrength GetCodingStrength()
		{
			return this.relationship.CodingStrength;
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformance()
		{
			return this.relationship.Conformance;
		}

		public virtual Cardinality GetCardinality()
		{
			return this.relationship.Cardinality;
		}

		public virtual ConstrainedDatatype GetConstraints()
		{
			return this.constraints;
		}

		public virtual bool IsCda()
		{
			return isCda;
		}

		public virtual bool IsFixedValue()
		{
			return relationship.HasFixedValue();
		}
	}
}
