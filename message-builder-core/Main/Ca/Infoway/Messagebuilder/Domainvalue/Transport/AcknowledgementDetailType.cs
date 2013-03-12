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
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>The Enum AcknowledgementDetailType.</summary>
	/// <remarks>
	/// The Enum AcknowledgementDetailType. A code distinguishing between errors,
	/// warnings and information messages related to the transmission of the message
	/// </remarks>
	[System.Serializable]
	public class AcknowledgementDetailType : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.AcknowledgementDetailType
	{
		static AcknowledgementDetailType()
		{
		}

		private const long serialVersionUID = -5837485473668582469L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType ERROR = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType
			("ERROR", "E");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType INFORMATION = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType
			("INFORMATION", "I");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType WARNING = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementDetailType
			("WARNING", "W");

		private readonly string codeValue;

		private AcknowledgementDetailType(string name, string codeValue) : base(name)
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
		public virtual string CodeValue
		{
			get
			{
				return this.codeValue;
			}
		}
	}
}
