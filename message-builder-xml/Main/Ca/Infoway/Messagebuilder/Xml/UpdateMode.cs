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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
using System.Collections.Generic;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Xml;
using Platform.SimpleXml;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>Update mode on an attribute or an association.</summary>
	/// <remarks>
	/// Update mode on an attribute or an association.
	/// Describes how a relationship should be updated.
	/// </remarks>
	/// <author>Intelliware Development</author>
	[RootAttribute]
	public class UpdateMode
	{
		[ElementListAttribute(Entry = "allowdUpdateMode", Inline = true, Required = false)]
		private IList<string> updateModesAllowed;

		[XmlAttributeAttribute(Required = false)]
		private string updateModeDefault;

		/// <summary>Gets the update mode that should be assumed if no updateMode is specified.</summary>
		/// <remarks>Gets the update mode that should be assumed if no updateMode is specified.</remarks>
		/// <returns>updateModeDefault</returns>
		/// <summary>Sets the update mode that should be assumed if no updateMode is specified.</summary>
		/// <remarks>Sets the update mode that should be assumed if no updateMode is specified.</remarks>
		/// <value></value>
		public virtual UpdateModeType UpdateModeDefault
		{
			get
			{
				return EnumPattern.ValueOf<UpdateModeType>(updateModeDefault);
			}
			set
			{
				UpdateModeType updateModeDefault = value;
				this.updateModeDefault = updateModeDefault.Name;
			}
		}

		/// <summary>Gets the list of update modes that may be used for this element.</summary>
		/// <remarks>Gets the list of update modes that may be used for this element.</remarks>
		/// <returns>updateModesAllowed</returns>
		/// <summary>Set the list of update modes that may be used for this element.</summary>
		/// <remarks>Set the list of update modes that may be used for this element.</remarks>
		/// <value></value>
		public virtual IList<UpdateModeType> UpdateModesAllowed
		{
			get
			{
				IList<UpdateModeType> result = new List<UpdateModeType>();
				if (updateModesAllowed != null)
				{
					foreach (string updateModeType in updateModesAllowed)
					{
						result.Add(EnumPattern.ValueOf<UpdateModeType>(updateModeType));
					}
				}
				return result;
			}
			set
			{
				IList<UpdateModeType> updateModes = value;
				if (updateModes == null)
				{
					this.updateModesAllowed = null;
				}
				else
				{
					IList<string> result = new List<string>();
					if (updateModes != null)
					{
						foreach (UpdateModeType updateModeType in updateModes)
						{
							result.Add(updateModeType.Name);
						}
					}
					this.updateModesAllowed = result;
				}
			}
		}
	}
}
