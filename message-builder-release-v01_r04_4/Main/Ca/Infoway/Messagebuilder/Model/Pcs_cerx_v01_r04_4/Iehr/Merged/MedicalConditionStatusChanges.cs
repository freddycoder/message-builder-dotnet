/**
 * Copyright 2015 Canada Health Infoway, Inc.
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
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged;
    using System;


    /**
     * <summary>REPC_MT000010CA.ControlActEvent: Medical Condition 
     * Status Changes</summary>
     * 
     * <p>Provides an audit trail of a patient's medical condition 
     * changes.</p> <p>This indicates the history of changes that 
     * have been made to the medical condition record, including 
     * why the changes were made, who made them and when.</p> 
     * REPC_MT000009CA.ControlActEvent: Allergy/Intolerance Status 
     * Changes <p>Provides a record of a patient's allergy changes, 
     * providing deeper clinical understanding, particularly of 
     * past clinical decisions.</p> <p>This records the history of 
     * changes that have been made to the allergy/intolerance, 
     * including why the changes were made, who made them and 
     * when.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000009CA.ControlActEvent","REPC_MT000010CA.ControlActEvent"})]
    public class MedicalConditionStatusChanges : MessagePartBean {

        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.RefusedBy author;

        public MedicalConditionStatusChanges() {
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: 
         * MedicalConditionStatusChangeType</summary>
         * 
         * <remarks>Relationship: REPC_MT000010CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This attribute is 
         * mandatory to ensure that change types are 
         * distinguishable.</p> <p>Identifies what kind of change 
         * occurred.</p> Un-merged Business Name: 
         * AllergyIntoleranceStatusChangeType Relationship: 
         * REPC_MT000009CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>This attribute is 
         * mandatory to ensure that change types are 
         * distinguishable.</p> <p>Identifies what kind of change 
         * occurred. Allergy/Intolerance change types are Revise, 
         * Reactivate and Complete.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HL7TriggerEventCode Code {
            get { return (HL7TriggerEventCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: 
         * MedicalConditionStatusChangeEffectiveDate</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * applications to sort and filter by time.</p><p>The effective 
         * date can be defaulted to change date, and thus is 
         * mandatory.</p> <p>The date on which the changes to the 
         * medical condition become valid and applicable.</p> Un-merged 
         * Business Name: AllergyIntoleranceStatusChangeEffectiveDate 
         * Relationship: REPC_MT000009CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * applications to sort and filter by time. The date on which a 
         * change is effective should always be known and thus is 
         * mandatory.</p> <p>The date on which the various changes of 
         * an allergy/intolerance become valid and applicable.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: 
         * MedicalConditionStatusChangeReason</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Ensures 
         * consistent terminology in capturing and interpreting reasons 
         * for change. Allows CWE because not all reasons will 
         * correspond to a pre-defined code.</p> <p>Denotes the reason 
         * the medical condition record was changed.</p> Un-merged 
         * Business Name: AllergyIntoleranceStatusChangeReason 
         * Relationship: REPC_MT000009CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Ensures 
         * consistent terminology in capturing and interpreting reasons 
         * for change. Allows CWE because not all reasons will 
         * correspond to a pre-defined code.</p> <p>Denotes the reason 
         * the the allergy/intolerance was changed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public ControlActReason ReasonCode {
            get { return (ControlActReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.ResponsibleParty2.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.ResponsibleParty2.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000010CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Merged.RefusedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

    }

}