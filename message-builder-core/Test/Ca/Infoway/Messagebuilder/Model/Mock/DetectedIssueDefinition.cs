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
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Annotation;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Model.Mock;

namespace Ca.Infoway.Messagebuilder.Model.Mock
{
	[System.Serializable]
	[Hl7PartTypeMappingAttribute(new string[] { "PORX_MT980030CA.DetectedIssueDefinition" })]
	public class DetectedIssueDefinition
	{
		private const long serialVersionUID = 1829563352068802464L;

		private Identifier issueMonographId;

		private string issueDescription;

		private AuthorBean author;

		private Interval<PlatformDate> doseDuration;

		private UncertainRange<PhysicalQuantity> dosageRange;

		private ObservationDosageDefinitionPreconditionType dosagePreconditionType;

		private UncertainRange<PhysicalQuantity> dosagePreconditionValue;

		[Hl7XmlMappingAttribute(new string[] { "id" })]
		public virtual Identifier GetIssueMonographId()
		{
			return issueMonographId;
		}

		public virtual void SetIssueMonographId(Identifier issueMonographId)
		{
			this.issueMonographId = issueMonographId;
		}

		[Hl7XmlMappingAttribute(new string[] { "text" })]
		public virtual string GetIssueDescription()
		{
			return issueDescription;
		}

		public virtual void SetIssueDescription(string issueDescription)
		{
			this.issueDescription = issueDescription;
		}

		[Hl7XmlMappingAttribute(new string[] { "author" })]
		public virtual AuthorBean GetAuthor()
		{
			return author;
		}

		public virtual void SetAuthor(AuthorBean author)
		{
			this.author = author;
		}

		[Hl7XmlMappingAttribute(new string[] { "component/substanceAdministrationEventCriterion/effectiveTime" })]
		public virtual Interval<PlatformDate> GetDoseDuration()
		{
			return doseDuration;
		}

		public virtual void SetDoseDuration(Interval<PlatformDate> doseDuration)
		{
			this.doseDuration = doseDuration;
		}

		[Hl7XmlMappingAttribute(new string[] { "component/substanceAdministrationEventCriterion/doseQuantity" })]
		public virtual UncertainRange<PhysicalQuantity> GetDosageRange()
		{
			return dosageRange;
		}

		public virtual void SetDosageRange(UncertainRange<PhysicalQuantity> dosageRange)
		{
			this.dosageRange = dosageRange;
		}

		[Hl7XmlMappingAttribute(new string[] { "component/substanceAdministrationEventCriterion/component/observationEventCriterion/code"
			 })]
		public virtual ObservationDosageDefinitionPreconditionType GetDosagePreconditionType()
		{
			return dosagePreconditionType;
		}

		public virtual void SetDosagePreconditionType(ObservationDosageDefinitionPreconditionType dosagePreconditionType)
		{
			this.dosagePreconditionType = dosagePreconditionType;
		}

		[Hl7XmlMappingAttribute(new string[] { "component/substanceAdministrationEventCriterion/component/observationEventCriterion/value"
			 })]
		public virtual UncertainRange<PhysicalQuantity> GetDosagePreconditionValue()
		{
			return dosagePreconditionValue;
		}

		public virtual void SetDosagePreconditionValue(UncertainRange<PhysicalQuantity> dosagePreconditionValue)
		{
			this.dosagePreconditionValue = dosagePreconditionValue;
		}
	}
}
