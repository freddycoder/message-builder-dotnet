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
 * Last modified: $LastChangedDate: 2014-01-30 15:25:26 -0500 (Thu, 30 Jan 2014) $
 * Revision:      $LastChangedRevision: 8372 $
 */
using Ca.Infoway.Messagebuilder.Xml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>A tool that can locate message parts.</summary>
	/// <remarks>A tool that can locate message parts.</remarks>
	/// <author>Intelliware Development</author>
	public interface MessagePartResolver
	{
		/// <summary>Find a message part by name.</summary>
		/// <remarks>Find a message part by name.</remarks>
		/// <param name="type">- the name of message type to retrieve.</param>
		/// <returns>- the message part</returns>
		MessagePart GetMessagePart(string type);

		/// <summary>Find the root type of a package location.</summary>
		/// <remarks>Find the root type of a package location.</remarks>
		/// <param name="packageLocationName">- the name of the package location.</param>
		/// <returns>- the root type of the package location.</returns>
		string GetPackageLocationRootType(string packageLocationName);
	}
}
