using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>Potential update modes.</summary>
	/// <remarks>
	/// Potential update modes.
	/// This enum models the various Update Mode Kinds in the HL7 standards materials.
	/// </remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class UpdateModeType : EnumPattern
	{
		static UpdateModeType()
		{
		}

		private const long serialVersionUID = 3066114109382422542L;

		/// <summary>The add update mode.</summary>
		/// <remarks>The add update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType ADD = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("ADD", "A");

		/// <summary>The remoe update mode.</summary>
		/// <remarks>The remoe update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType REMOVE = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("REMOVE", "D");

		/// <summary>The replace update mode.</summary>
		/// <remarks>The replace update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType REPLACE = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("REPLACE", "R");

		/// <summary>The add or update update mode.</summary>
		/// <remarks>The add or update update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType ADD_OR_UPDATE = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("ADD_OR_UPDATE", "N");

		/// <summary>The no change update mode.</summary>
		/// <remarks>The no change update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType NO_CHANGE = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("NO_CHANGE", "N");

		/// <summary>The unknown update mode.</summary>
		/// <remarks>The unknown update mode.</remarks>
		public static readonly Ca.Infoway.Messagebuilder.Xml.UpdateModeType UNKNOWN = new Ca.Infoway.Messagebuilder.Xml.UpdateModeType
			("UNKNOWN", "U");

		private readonly string codeValue;

		private UpdateModeType(string name, string codeValue) : base(name)
		{
			this.codeValue = codeValue;
		}

		/// <summary>Gets the code for the update mode.</summary>
		/// <remarks>Gets the code for the update mode.</remarks>
		/// <returns>the codeValue</returns>
		public virtual string GetCodeValue()
		{
			return this.codeValue;
		}
	}
}
