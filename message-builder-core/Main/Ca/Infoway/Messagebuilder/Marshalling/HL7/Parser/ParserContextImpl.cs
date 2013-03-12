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
using Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser;
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser
{
	internal class ParserContextImpl : ParseContext
	{
		private readonly System.Type expectedReturnType;

		private readonly string type;

		private readonly VersionNumber version;

		private readonly Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance;

		private readonly CodingStrength strength;

		private readonly Int32? length;

		private readonly TimeZone dateTimeZone;

		private readonly TimeZone dateTimeTimeZone;

		private ParserContextImpl(string type, System.Type returnType, VersionNumber version, TimeZone dateTimeZone, TimeZone dateTimeTimeZone
			, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance, CodingStrength strength, Int32? length)
		{
			this.type = type;
			this.expectedReturnType = returnType;
			this.version = version;
			this.dateTimeZone = dateTimeZone;
			this.dateTimeTimeZone = dateTimeTimeZone;
			this.conformance = conformance;
			this.strength = strength;
			this.length = length;
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

		public virtual TimeZone GetDateTimeZone()
		{
			return this.dateTimeZone;
		}

		public virtual TimeZone GetDateTimeTimeZone()
		{
			return this.dateTimeTimeZone;
		}

		public virtual Ca.Infoway.Messagebuilder.Xml.ConformanceLevel GetConformance()
		{
			return this.conformance;
		}

		internal static ParseContext Create(string type, System.Type returnType, VersionNumber version, TimeZone dateTimeZone, TimeZone
			 dateTimeTimeZone, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserContextImpl(type, returnType, version, dateTimeZone, dateTimeTimeZone
				, conformance, null, null);
		}

		public virtual CodingStrength GetCodingStrength()
		{
			return this.strength;
		}

		public virtual Int32? GetLength()
		{
			return this.length;
		}

		public static ParseContext Create(string type, System.Type returnType, VersionNumber version, TimeZone dateTimeZone, TimeZone
			 dateTimeTimeZone, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel conformance, CodingStrength strength, Int32? length)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserContextImpl(type, returnType, version, dateTimeZone, dateTimeTimeZone
				, conformance, strength, length);
		}

		public static ParseContext Create(string newType, ParseContext oldContext)
		{
			return Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserContextImpl.Create(newType, oldContext.GetConformance(), oldContext
				);
		}

		public static ParseContext Create(string newType, Ca.Infoway.Messagebuilder.Xml.ConformanceLevel newConformance, ParseContext
			 oldContext)
		{
			return new Ca.Infoway.Messagebuilder.Marshalling.HL7.Parser.ParserContextImpl(newType, oldContext.GetExpectedReturnType()
				, oldContext.GetVersion(), oldContext.GetDateTimeZone(), oldContext.GetDateTimeTimeZone(), newConformance, oldContext.GetCodingStrength
				(), oldContext.GetLength());
		}
	}
}
