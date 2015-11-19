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
namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>An interface describing types that have documentation.</summary>
	/// <remarks>
	/// An interface describing types that have documentation.  MIFs often contain
	/// additional documentation that describe the purpose or meaning of types.
	/// </remarks>
	/// <author>Intelliware Development</author>
	public interface Documentable
	{
		/// <summary>Get the documentation.</summary>
		/// <remarks>Get the documentation.</remarks>
		/// <returns>the documentation.</returns>
		/// <summary>Set the documentation.</summary>
		/// <remarks>Set the documentation.</remarks>
		/// <value>- the new documentation value</value>
		Ca.Infoway.Messagebuilder.Xml.Documentation Documentation
		{
			get;
			set;
		}
	}
}
