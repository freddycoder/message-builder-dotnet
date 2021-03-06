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

namespace Ca.Infoway.Messagebuilder.Domainvalue.Payload
{
	/// <summary>The Enum QueryResponse.</summary>
	/// <remarks>The Enum QueryResponse. Values in this domain allow a query response system to return a precise response status.
	/// 	</remarks>
	[System.Serializable]
	public class QueryResponse : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.QueryResponse
	{
		static QueryResponse()
		{
		}

		private const long serialVersionUID = -6211467438802392184L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.QueryResponse APPLICATION_ERROR = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.QueryResponse
			("APPLICATION_ERROR", "AE", true);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.QueryResponse NO_DATA_FOUND = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.QueryResponse
			("NO_DATA_FOUND", "NF", false);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.QueryResponse DATA_FOUND = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.QueryResponse
			("DATA_FOUND", "OK", false);

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Payload.QueryResponse QUERY_PARAMETER_ERROR = new Ca.Infoway.Messagebuilder.Domainvalue.Payload.QueryResponse
			("QUERY_PARAMETER_ERROR", "QE", true);

		private readonly string codeValue;

		private readonly bool error;

		private QueryResponse(string name, string codeValue, bool error) : base(name)
		{
			this.codeValue = codeValue;
			this.error = error;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_QUERY_RESPONSE.Root;
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

		/// <summary>Checks if is error.</summary>
		/// <remarks>Checks if is error.</remarks>
		/// <returns>true, if is error</returns>
		public virtual bool IsError()
		{
			return this.error;
		}
	}
}
