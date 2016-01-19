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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	public class ParseContextImpl : ParseContext
	{
		private readonly System.Type expectedReturnType;

		private readonly string type;

		private readonly VersionNumber version;

		private readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance;

		private readonly CodingStrength strength;

		private readonly Int32? length;

		private readonly TimeZoneInfo dateTimeZone;

		private readonly TimeZoneInfo dateTimeTimeZone;

		private readonly Cardinality cardinality;

		private readonly ConstrainedDatatype constraints;

		private readonly bool isCda;

		private readonly bool isFixedValue;

		private ParseContextImpl(string type, System.Type returnType, VersionNumber version, TimeZoneInfo dateTimeZone, TimeZoneInfo
			 dateTimeTimeZone, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance, Cardinality cardinality, CodingStrength strength
			, Int32? length, ConstrainedDatatype constraints, bool isCda, bool isFixedValue)
		{
			this.type = type;
			this.expectedReturnType = returnType;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.conformance = conformance;
			this.cardinality = cardinality;
			this.strength = strength;
			this.length = length;
			this.constraints = constraints;
			this.isCda = isCda;
			this.isFixedValue = isFixedValue;
		}

		public virtual string Type
		{
			get
			{
				return this.type;
			}
		}

		public virtual System.Type GetExpectedReturnType()
		{
			return this.expectedReturnType;
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

		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformance()
		{
			return this.conformance;
		}

		public virtual Cardinality GetCardinality()
		{
			return this.cardinality;
		}

		public virtual CodingStrength GetCodingStrength()
		{
			return this.strength;
		}

		public virtual Int32? GetLength()
		{
			return this.length;
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
			return isFixedValue;
		}

		// tests only
		public static ParseContext Create(string type, System.Type returnType, VersionNumber version, TimeZoneInfo dateTimeZone, 
			TimeZoneInfo dateTimeTimeZone, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance, Cardinality cardinality, ConstrainedDatatype
			 constraints, bool isCda)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParseContextImpl(type, returnType, version, dateTimeZone, dateTimeTimeZone
				, conformance, cardinality, null, null, constraints, isCda, false);
		}

		// tests only
		public static ParseContext Create(string type, System.Type returnType, VersionNumber version, TimeZoneInfo dateTimeZone, 
			TimeZoneInfo dateTimeTimeZone, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance, Cardinality cardinality, CodingStrength
			 strength, Int32? length, ConstrainedDatatype constraints, bool isCda)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParseContextImpl(type, returnType, version, dateTimeZone, dateTimeTimeZone
				, conformance, cardinality, strength, length, constraints, isCda, false);
		}

		public static ParseContext Create(string newType, ParseContext oldContext)
		{
			return Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParseContextImpl.Create(newType, oldContext.GetConformance(), oldContext
				.GetCardinality(), oldContext);
		}

		public static ParseContext CreateWithConstraints(string newType, ParseContext oldContext)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParseContextImpl(newType, oldContext.GetExpectedReturnType(), 
				oldContext.GetVersion(), oldContext.GetDateTimeZone(), oldContext.GetDateTimeTimeZone(), oldContext.GetConformance(), oldContext
				.GetCardinality(), oldContext.GetCodingStrength(), oldContext.GetLength(), oldContext.GetConstraints(), oldContext.IsCda
				(), oldContext.IsFixedValue());
		}

		public static ParseContext CreateWithConstraints(string newType, System.Type newReturnType, ParseContext oldContext)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParseContextImpl(newType, newReturnType, oldContext.GetVersion
				(), oldContext.GetDateTimeZone(), oldContext.GetDateTimeTimeZone(), oldContext.GetConformance(), oldContext.GetCardinality
				(), oldContext.GetCodingStrength(), oldContext.GetLength(), oldContext.GetConstraints(), oldContext.IsCda(), oldContext.
				IsFixedValue());
		}

		public static ParseContext Create(string newType, System.Type newReturnType, ParseContext oldContext)
		{
			// not passing constraints down unless constraints are explicitly provided
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParseContextImpl(newType, newReturnType, oldContext.GetVersion
				(), oldContext.GetDateTimeZone(), oldContext.GetDateTimeTimeZone(), oldContext.GetConformance(), oldContext.GetCardinality
				(), oldContext.GetCodingStrength(), oldContext.GetLength(), null, oldContext.IsCda(), oldContext.IsFixedValue());
		}

		public static ParseContext Create(string newType, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel newConformance, Cardinality
			 newCardinality, ParseContext oldContext)
		{
			// not passing constraints down unless constraints are explicitly provided
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParseContextImpl(newType, oldContext.GetExpectedReturnType(), 
				oldContext.GetVersion(), oldContext.GetDateTimeZone(), oldContext.GetDateTimeTimeZone(), newConformance, newCardinality, 
				oldContext.GetCodingStrength(), oldContext.GetLength(), null, oldContext.IsCda(), oldContext.IsFixedValue());
		}

		public static ParseContext Create(string newType, System.Type newReturnType, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel
			 newConformance, Cardinality newCardinality, ParseContext oldContext)
		{
			// not passing constraints down unless constraints are explicitly provided
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParseContextImpl(newType, newReturnType, oldContext.GetVersion
				(), oldContext.GetDateTimeZone(), oldContext.GetDateTimeTimeZone(), newConformance, newCardinality, oldContext.GetCodingStrength
				(), oldContext.GetLength(), null, oldContext.IsCda(), oldContext.IsFixedValue());
		}
	}
}
