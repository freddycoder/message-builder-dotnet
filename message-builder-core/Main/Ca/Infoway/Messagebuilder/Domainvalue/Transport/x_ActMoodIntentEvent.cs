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
	/// <summary>The Enum x_ActMoodIntentEvent.</summary>
	/// <remarks>The Enum x_ActMoodIntentEvent.</remarks>
	[System.Serializable]
	public class x_ActMoodIntentEvent : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.x_ActMoodIntentEvent, Describable
	{
		static x_ActMoodIntentEvent()
		{
		}

		private const long serialVersionUID = -90066419599911191L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.x_ActMoodIntentEvent EVENT = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.x_ActMoodIntentEvent
			("EVN");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.x_ActMoodIntentEvent REQUEST = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.x_ActMoodIntentEvent
			("RQO");

		private x_ActMoodIntentEvent(string codeValue) : base(codeValue)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_MOOD.Root;
			}
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeValue
		{
			get
			{
				return Name;
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
