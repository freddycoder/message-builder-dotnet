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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
using Ca.Infoway.Messagebuilder.Transport;

namespace Ca.Infoway.Messagebuilder.Transport
{
	/// <summary>A simple credentials implementation.</summary>
	/// <remarks>A simple credentials implementation. Stores username and password.</remarks>
	/// <author>
	/// Intelliware Development
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public class UsernamePasswordCredentials : Credentials
	{
		private readonly string username;

		private readonly string password;

		/// <summary>Constructs a usernamePassword credential with the given username and password.</summary>
		/// <remarks>Constructs a usernamePassword credential with the given username and password.</remarks>
		/// <param name="username">the username/login id for the credentials</param>
		/// <param name="password">the plaintext password for the credentials</param>
		public UsernamePasswordCredentials(string username, string password)
		{
			this.username = username;
			this.password = password;
		}

		/// <summary>Obtains the username.</summary>
		/// <remarks>Obtains the username.</remarks>
		/// <returns>the username</returns>
		public virtual string GetUsername()
		{
			return this.username;
		}

		/// <summary>Obtains the password.</summary>
		/// <remarks>Obtains the password.</remarks>
		/// <returns>the plaintext password</returns>
		public virtual string GetPassword()
		{
			return this.password;
		}
	}
}
