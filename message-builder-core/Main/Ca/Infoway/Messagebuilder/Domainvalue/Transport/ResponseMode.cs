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
	/// <summary>
	/// Specifies the mode, immediate versus deferred or queued, by which a receiver
	/// should communicate its receiver responsibilities.
	/// </summary>
	/// <remarks>
	/// Specifies the mode, immediate versus deferred or queued, by which a receiver
	/// should communicate its receiver responsibilities.
	/// </remarks>
	[System.Serializable]
	public class ResponseMode : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.ResponseMode, Describable
	{
		static ResponseMode()
		{
		}

		private const long serialVersionUID = -3314261517693748622L;

		/// <summary>The receiver may respond in a non-immediate manner.</summary>
		/// <remarks>
		/// The receiver may respond in a non-immediate manner. Note: this will be
		/// the default value.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode DEFERRED = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode
			("D");

		/// <summary>
		/// The receiver is required to assume that the sender is blocking and
		/// behave appropriately by sending an immediate response.
		/// </summary>
		/// <remarks>
		/// The receiver is required to assume that the sender is blocking and
		/// behave appropriately by sending an immediate response.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode IMMEDIATE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode
			("I");

		/// <summary>
		/// The receiver shall keep any application responses in a queue until
		/// such time as the queue is polled.
		/// </summary>
		/// <remarks>
		/// The receiver shall keep any application responses in a queue until
		/// such time as the queue is polled.
		/// </remarks>
		public static readonly Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode QUEUE = new Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode
			("Q");

		private ResponseMode(string codeValue) : base(codeValue)
		{
		}

		/// <summary><inheritDoc></inheritDoc></summary>
		public virtual string CodeSystem
		{
			get
			{
				return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_RESPONSE_MODE.Root;
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
