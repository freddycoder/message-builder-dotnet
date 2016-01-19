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
	/// <summary>The Enum TopicPriority.</summary>
	/// <remarks>The Enum TopicPriority.</remarks>
	[System.Serializable]
	public class TopicPriority : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.TopicPriority, Describable
	{
		static TopicPriority()
		{
		}

		private const long serialVersionUID = 4476190535780761850L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority NL_MANDATORY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority
			("NL_MANDATORY", "NL_MAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority GROUP_MANDATORY = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority
			("GROUP_MANDATORY", "GROUP_MAND");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority OPTIONAL = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.TopicPriority
			("OPTIONAL", "OPTIONAL");

		private readonly string codeValue;

		private TopicPriority(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.TOPIC_PRIORITY.Root;
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
