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
	/// <summary>The Enum IssueFilterCode.</summary>
	/// <remarks>
	/// The Enum IssueFilterCode. Indicates how result sets should be
	/// filtered based on whether they have associated unmanaged or persistent issues.
	/// </remarks>
	[System.Serializable]
	public class IssueFilterCode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.IssueFilterCode, Describable
	{
		static IssueFilterCode()
		{
		}

		private const long serialVersionUID = -4833350276910420958L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.IssueFilterCode ALL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.IssueFilterCode
			("ALL", "A");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.IssueFilterCode WITH_ISSUES = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.IssueFilterCode
			("WITH_ISSUES", "I");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.IssueFilterCode WITH_UNMANAGED_ISSUES = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.IssueFilterCode
			("WITH_UNMANAGED_ISSUES", "U");

		private readonly string codeValue;

		private IssueFilterCode(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_QUERY_PARAMETER_VALUE.Root;
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
