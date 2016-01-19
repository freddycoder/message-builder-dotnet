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


using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A basic implementation of a CredentialsProvider.</summary>
	/// <remarks>A basic implementation of a CredentialsProvider. Holds credentials, and nothing more.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public class TrivialCredentialsProvider : CredentialsProvider
	{
		private readonly Credentials credentials;

		/// <summary>Constructs a TrivialCredentialsProvider based on the provided Credentials.</summary>
		/// <remarks>Constructs a TrivialCredentialsProvider based on the provided Credentials.</remarks>
		/// <param name="credentials">the credentials to provide</param>
		public TrivialCredentialsProvider(Credentials credentials)
		{
			this.credentials = credentials;
		}

		/// <summary>Obtain the credentials.</summary>
		/// <remarks>Obtain the credentials.</remarks>
		/// <returns>the current credentials</returns>
		public virtual Credentials GetCredentials()
		{
			return this.credentials;
		}
	}
}
