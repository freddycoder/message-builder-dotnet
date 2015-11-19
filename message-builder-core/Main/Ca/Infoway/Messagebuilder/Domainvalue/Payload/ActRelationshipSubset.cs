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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum ActRelationshipSubset.</summary>
	/// <remarks>The Enum ActRelationshipSubset.</remarks>
	[System.Serializable]
	public class ActRelationshipSubset : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActRelationshipSubset, Describable
	{
		static ActRelationshipSubset()
		{
		}

		private const long serialVersionUID = -617461458714176662L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset EXPECTED_FUTURE = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("EXPECTED_FUTURE", "FUTURE");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset EXPECTED_LAST = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("EXPECTED_LAST", "LAST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset EXPECTED_NEXT = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("EXPECTED_NEXT", "NEXT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset FIRST_KNOWN = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("FIRST_KNOWN", "FIRST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset FUTURE_SUMMARY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("FUTURE_SUMMARY", "FUTSUM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset MAXIMUM = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("MAXIMUM", "MAX");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset MINIMUM = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("MINIMUM", "MIN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset MOST_RECENT = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("MOST_RECENT", "RECENT");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset PREVIOUS = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("PREVIOUS", "PAST");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset PREVIOUS_SUMMARY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("PREVIOUS_SUMMARY", "PREVSUM");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset SUMMARY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.ActRelationshipSubset
			("SUMMARY", "SUM");

		private readonly string codeValue;

		private ActRelationshipSubset(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_RELATIONSHIP_SUBSET.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystemName
		{
			get
			{
				return null;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string Description
		{
			get
			{
				return DescribableUtil.GetDefaultDescription(this);
			}
		}
	}
}
