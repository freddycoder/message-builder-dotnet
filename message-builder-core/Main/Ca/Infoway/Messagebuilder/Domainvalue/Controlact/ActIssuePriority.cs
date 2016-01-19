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


using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Controlact
{
	/// <summary>The Enum ActIssuePriority.</summary>
	/// <remarks>The Enum ActIssuePriority. Indicates the relative importance or priority of a detected issue</remarks>
	[System.Serializable]
	public class ActIssuePriority : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ActIssuePriority
	{
		static ActIssuePriority()
		{
		}

		private const long serialVersionUID = 5357530778447095336L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority ERROR = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority
			("ERROR", "E");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority INFORMATION = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority
			("INFORMATION", "I");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority WARNING = new Ca.Infoway.Messagebuilder.Domainvalue.Controlact.ActIssuePriority
			("WARNING", "W");

		private readonly string codeValue;

		private ActIssuePriority(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACKNOWLEDGEMENT_DETAIL_TYPE.Root;
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
	}
}
