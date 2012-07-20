using Ca.Infoway.Messagebuilder.Lang;

namespace Ca.Infoway.Messagebuilder.Xml
{
	/// <summary>Annotation Type.</summary>
	/// <remarks>
	/// Annotation Type.
	/// This enum models the various annotation types in the HL7 standards materials.
	/// VB: The following constraints are taken from section 6.2.4.1 "Constrained Item Properties", page 39 of the
	/// SMCT User Guide.
	/// https://www.i-proving.ca/download/Projects/e-Health/CHI/SMCT/SMCT+User+Guide+v0.3+%28MASTER%29.pdf
	/// </remarks>
	/// <author>Intelliware Development</author>
	[System.Serializable]
	public class AnnotationType : EnumPattern
	{
		static AnnotationType()
		{
		}

		private const long serialVersionUID = 3066114109382422542L;

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType CONSTRAINT = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("CONSTRAINT", "CONSTRAINT", "constraint", "formalConstraint");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType DESCRIPTION = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("DESCRIPTION", "DESCRIPTION / DEFINITION", "description", "definition");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType DESIGN_COMMENTS = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("DESIGN_COMMENTS", "DESIGN COMMENTS", "designComments");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType MAPPING = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("MAPPING", "MAPPING", "mapping");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType OPEN_ISSUE = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("OPEN_ISSUE", "OPEN ISSUE", "openIssues", "openIssue");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType OTHER_NOTES = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("OTHER_NOTES", "OTHER NOTES", "otherAnnotation");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType RATIONALE = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("RATIONALE", "RATIONALE", "rationale");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType USAGE_NOTES = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("USAGE_NOTES", "USAGE NOTES", "usageNotes");

		private readonly string[] mifElementNames;

		private string displayName;

		private AnnotationType(string name, string displayName, params string[] mif) : base(name)
		{
			this.displayName = displayName;
			this.mifElementNames = mif;
		}

		public virtual string[] GetMifElementNames()
		{
			return mifElementNames;
		}

		public virtual string GetDisplayName()
		{
			return displayName;
		}

		public virtual void SetDisplayName(string displayName)
		{
			this.displayName = displayName;
		}
	}
}
