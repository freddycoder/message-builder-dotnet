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
 * Last modified: $LastChangedDate: 2011-05-17 11:48:36 -0400 (Tue, 17 May 2011) $
 * Revision:      $LastChangedRevision: 2666 $
 */

namespace Ca.Infoway.Messagebuilder.Transport.Mohawk
{
	/// <summary>An interface for a transport layer to make use of a transport mechanism, such as HttpClient.</summary>
	/// <remarks>An interface for a transport layer to make use of a transport mechanism, such as HttpClient.</remarks>
	/// <author>
	/// <a href="http://www.intelliware.ca/">Intelliware Development</a>
	/// sharpen.ignore - transport - TBD!
	/// </author>
	public interface Client
	{
		/// <summary>Obtains the http state of the underlying client.</summary>
		/// <remarks>Obtains the http state of the underlying client.</remarks>
		/// <returns>the http state of the underlying client</returns>
		//HttpState GetState();

		/// <summary>Obtains the current http parameters.</summary>
		/// <remarks>Obtains the current http parameters.</remarks>
		/// <returns>http parameters</returns>
		//HttpClientParams GetParams();

		/// <summary>Fires the given post method.</summary>
		/// <remarks>Fires the given post method.</remarks>
		/// <param name="method">the type of method to execute</param>
		/// <returns>the http status code</returns>
		/// <exception cref="System.IO.IOException">if there were any problems during the execution of the method</exception>
		int ExecuteMethod(PostMethod method);
	}

   

   
}
