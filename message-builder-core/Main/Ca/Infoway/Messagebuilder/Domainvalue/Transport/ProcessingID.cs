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

namespace Ca.Infoway.Messagebuilder.Domainvalue.Transport
{
	/// <summary>
	/// Codes used to specify whether a message is part of a production, training,
	/// or debugging system.
	/// </summary>
	/// <remarks>
	/// Codes used to specify whether a message is part of a production, training,
	/// or debugging system.
	/// </remarks>
	[System.Serializable]
	public class ProcessingID : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ProcessingID, Describable
	{
		static ProcessingID()
		{
		}

		private const long serialVersionUID = -4810533940602682646L;

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID DEBUGGING = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID
			("DEBUGGING", "D");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID PRODUCTION = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID
			("PRODUCTION", "P");

		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID TRAINING = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID
			("TRAINING", "T");

		private readonly string codeValue;

		private ProcessingID(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return string.Empty;
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
