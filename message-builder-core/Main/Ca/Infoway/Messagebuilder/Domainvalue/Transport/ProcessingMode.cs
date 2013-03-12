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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Domainvalue.Util;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum ProcessingMode.</summary>
	/// <remarks>The Enum ProcessingMode.</remarks>
	[System.Serializable]
	public class ProcessingMode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ProcessingMode, Describable
	{
		static ProcessingMode()
		{
		}

		private const long serialVersionUID = -4741683761461235584L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode ARCHIVE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode
			("ARCHIVE", "A");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode CURRENT_PROCESSING = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode
			("CURRENT_PROCESSING", "T");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode INITIAL_LOAD = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode
			("INITIAL_LOAD", "I");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode RESTORE_FROM_ARCHIVE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode
			("RESTORE_FROM_ARCHIVE", "R");

		private readonly string codeValue;

		private ProcessingMode(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_PROCESSING_MODE.Root;
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
