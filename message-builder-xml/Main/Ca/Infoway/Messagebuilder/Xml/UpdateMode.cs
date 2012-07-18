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
					if (updateModesAllowed != null)
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
