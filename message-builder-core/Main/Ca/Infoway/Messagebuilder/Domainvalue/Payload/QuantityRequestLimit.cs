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
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum QuantityRequestLimit.</summary>
	/// <remarks>The Enum QuantityRequestLimit.</remarks>
	[System.Serializable]
	public class QuantityRequestLimit : EnumPattern, QueryRequestLimit
	{
		static QuantityRequestLimit()
		{
		}

		private const long serialVersionUID = 669843685953278565L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.QuantityRequestLimit RECORDS = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.QuantityRequestLimit
			("RECORDS", "RD");

		private readonly string codeValue;

		private QuantityRequestLimit(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return "2.16.840.1.113883.5.1112";
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
