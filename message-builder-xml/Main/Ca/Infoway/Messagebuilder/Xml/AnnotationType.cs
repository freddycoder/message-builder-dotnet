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


using System.Collections.Generic;
using Ca.Infoway.Messagebuilder;
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
		private const long serialVersionUID = 3066114109382422542L;

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType CONSTRAINT = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("CONSTRAINT", "CONSTRAINT", "constraint", "formalConstraint");

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

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType DESCRIPTION = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("DESCRIPTION", "DESCRIPTION", "description");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType DEFINITION = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("DEFINITION", "DEFINITION", "definition");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType USAGE_CONSTRAINT = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("USAGE_CONSTRAINT", "USAGE CONSTRAINT", "usageConstraint");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType REQUIREMENTS = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("REQUIREMENTS", "REQUIREMENTS", "requirements");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType STABILITY_REMARKS = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("STABILITY_REMARKS", "STABILITY REMARKS", "stabilityRemarks");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType WALKTHROUGH = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("WALKTHROUGH", "WALKTHROUGH", "walkthrough");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType APPENDIX = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("APPENDIX", "APPENDIX", "appendix");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType BALLOT_COMMENT = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("BALLOT_COMMENT", "BALLOT COMMENT", "ballotComment");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType CHANGE_REQUEST = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("CHANGE_REQUEST", "CHANGE REQUEST", "changeRequest");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType STATIC_EXAMPLE = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("STATIC_EXAMPLE", "STATIC EXAMPLE", "staticExample");

		public static readonly Ca.Infoway.Messagebuilder.Xml.AnnotationType DEPRECATION_INFO = new Ca.Infoway.Messagebuilder.Xml.AnnotationType
			("DEPRECATION_INFO", "DEPRECATION INFO", "deprecationInfo");

		private static readonly IList<Ca.Infoway.Messagebuilder.Xml.AnnotationType> _typesAllowingMultipleCardinality = new List<
			Ca.Infoway.Messagebuilder.Xml.AnnotationType>();

		static AnnotationType()
		{
			//	public static final AnnotationType DESCRIPTION = new AnnotationType("DESCRIPTION", "DESCRIPTION / DEFINITION", "description", "definition");
			//TODO: GN: need to figure out if these have corresponding mappings on mif1s
			//For C# Translation, there should only be 1 static block in this class
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.USAGE_NOTES);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.DESIGN_COMMENTS);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.OTHER_NOTES);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.MAPPING);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.CONSTRAINT);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.OPEN_ISSUE);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.USAGE_CONSTRAINT);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.APPENDIX);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.STATIC_EXAMPLE);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.BALLOT_COMMENT);
			_typesAllowingMultipleCardinality.Add(Ca.Infoway.Messagebuilder.Xml.AnnotationType.CHANGE_REQUEST);
		}

		public static readonly IList<Ca.Infoway.Messagebuilder.Xml.AnnotationType> typesAllowingMultipleCardinality = Ca.Infoway.Messagebuilder.CollUtils.CreateUnmodifiableList
			(_typesAllowingMultipleCardinality);

		private readonly string[] mifElementNames;

		private string displayName;

		private AnnotationType(string name, string displayName, params string[] mif) : base(name)
		{
			this.displayName = displayName;
			this.mifElementNames = mif;
		}

		public virtual string[] MifElementNames
		{
			get
			{
				return mifElementNames;
			}
		}

		public virtual string Description
		{
			get
			{
				return displayName;
			}
		}

		public virtual void SetDisplayName(string displayName)
		{
			this.displayName = displayName;
		}
	}
}
