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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca;
    using System;


    /**
     * <summary>PORX_MT060340CA.ControlActEvent: Status Changes</summary>
     * 
     * <p>This records the history of changes that have been made 
     * to the prescription, including why the changes were made, 
     * who made them and when.</p> <p>Provides an audit trail of a 
     * patient's therapy adjustments. Status changes may affect 
     * evaluations of compliance.</p> 
     * PORX_MT060160CA.ControlActEvent: Status Changes <p>This 
     * records the history of changes that have been made to the 
     * prescription, including why the changes were made, who made 
     * them and when.</p> <p>Provides an audit trail of a patient's 
     * therapy adjustments. Status changes may affect evaluations 
     * of compliance.</p> PORX_MT060210CA.ControlActEvent: Other 
     * Medication Status Changes <p>This records the history of 
     * changes that have been made to the other medication record, 
     * including why the changes were made, who made them and 
     * when.</p> <p>Provides an audit trail of a patient's use of 
     * other medications.</p> PORX_MT060040CA.ControlActEvent: 
     * Status Changes <p>This records the history of changes that 
     * have been made to the prescription, including why the 
     * changes were made, who made them and when.</p> <p>Provides 
     * an audit trail of a patient's therapy adjustments. Status 
     * changes may affect evaluations of compliance.</p> 
     * PORX_MT060090CA.ControlActEvent: Dispense Status Changes 
     * <p>This records the history of changes that have been made 
     * to the prescription dispense, including why the changes were 
     * made, who made them and when.</p> <p>Provides an audit trail 
     * of a patient's therapy adjustments. Status changes may 
     * affect evaluations of compliance.</p> 
     * PORX_MT060010CA.ControlActEvent: Dispense Status Changes 
     * <p>This records the history of changes that have been made 
     * to the prescription dispense, including why the changes were 
     * made, who made them and when.</p> <p>Provides an audit trail 
     * of a patient's therapy adjustments. Status changes may 
     * affect evaluations of compliance.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060010CA.ControlActEvent","PORX_MT060040CA.ControlActEvent","PORX_MT060090CA.ControlActEvent","PORX_MT060160CA.ControlActEvent","PORX_MT060210CA.ControlActEvent","PORX_MT060340CA.ControlActEvent"})]
    public class StatusChanges : MessagePartBean {

        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider responsiblePartyAssignedPerson;
        private Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.ManagedBy author;

        public StatusChanges() {
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.reasonCode = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: ChangeType</summary>
         * 
         * <remarks>Relationship: PORX_MT060340CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies what 
         * kind of change occurred. Examples include Suspended, 
         * Superseded, Released, Aborted (stopped), etc.</p> 
         * <p>Distinguishes discontinueStatus, holdStatus, 
         * reactivateStatus and releaseStatus</p> <p>This attribute is 
         * mandatory to ensure that change types are 
         * distinguishable.</p> Un-merged Business Name: ChangeType 
         * Relationship: PORX_MT060160CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies what 
         * kind of change occurred. Examples include Suspended, 
         * Superseded, Released, Aborted (stopped), etc.</p> 
         * <p>Distinguishes discontinueStatus, holdStatus, 
         * reactivateStatus and releaseStatus</p> <p>This attribute is 
         * mandatory to ensure that change types are 
         * distinguishable.</p> Un-merged Business Name: ChangeType 
         * Relationship: PORX_MT060040CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies what 
         * kind of change occurred. Examples include Suspended, 
         * Superseded, Released, Aborted (stopped), etc.</p> 
         * <p>Distinguishes discontinueStatus, holdStatus, 
         * reactivateStatus and releaseStatus</p> <p>This attribute is 
         * mandatory to ensure that change types are 
         * distinguishable.</p> Un-merged Business Name: 
         * OtherMedicationStatusChangeType Relationship: 
         * PORX_MT060210CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies what 
         * kind of change occurred. Examples include Completed, 
         * Aborted, etc.</p> <p>This attribute is mandatory to ensure 
         * that change types are distinguishable</p> Un-merged Business 
         * Name: DispenseStatusChangeType Relationship: 
         * PORX_MT060010CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies what 
         * kind of change occurred. Examples include Suspended, 
         * Aborted, etc.</p> <p>This attribute is mandatory to ensure 
         * that change types are distinguishable.</p> Un-merged 
         * Business Name: DispenseStatusChangeType Relationship: 
         * PORX_MT060090CA.ControlActEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifies what 
         * kind of change occurred. Examples include Suspended, 
         * Aborted, etc.</p> <p>This attribute is mandatory to ensure 
         * that change types are distinguishable.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public HL7TriggerEventCode Code {
            get { return (HL7TriggerEventCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ChangeEffectivePeriod</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>The date on which 
         * the various status changes of a prescription become valid 
         * and applicable. In the case of a suspend, may also indicate 
         * the scheduled time at which the status change will end.</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> <p>Allows applications to sort and 
         * filter by time.</p><p>The effective date can be defaulted to 
         * change date, and thus is mandatory.</p> <p>Allows 
         * applications to sort and filter by time.</p><p>The effective 
         * date can be defaulted to change date, and thus is 
         * mandatory.</p> Un-merged Business Name: 
         * ChangeEffectivePeriod Relationship: 
         * PORX_MT060160CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>The date on which 
         * the various status changes of a prescription become valid 
         * and applicable. In the case of a suspend, may also indicate 
         * the scheduled time at which the status change will end.</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> <p>Allows applications to sort and 
         * filter by time.</p><p>The effective date can be defaulted to 
         * change date, and thus is mandatory.</p> <p>Allows 
         * applications to sort and filter by time.</p><p>The effective 
         * date can be defaulted to change date, and thus is 
         * mandatory.</p> Un-merged Business Name: 
         * ChangeEffectivePeriod Relationship: 
         * PORX_MT060040CA.ControlActEvent.effectiveTime 
         * Conformance/Cardinality: MANDATORY (1) <p>The date on which 
         * the various status changes of a prescription become valid 
         * and applicable. In the case of a suspend, may also indicate 
         * the scheduled time at which the status change will end.</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescription.cancelTime</p><p>Prescription.holdReleaseDate</p><p>Prescription.holdStartDate</p><p>Prescription.modificationTime</p><p>Prescription.stopDate</p><p>Prescription.reactivateDate</p><p>ZPB3.14(when 
         * code is discontinued)</p> 
         * <p>PrescriptionStatus.initialEndDate</p><p>PrescriptionStatus.actualEndDate</p><p>Prescript
         * ... [rest of documentation truncated due to excessive length]
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ChangeReason</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes the 
         * reason the status of the prescription was changed.</p> 
         * <p>PrescriptionStatus.reason(mnemonic)</p><p>PrescriptionStatus.adhocReason(originalText)</p> 
         * <p>PrescriptionStatus.reason(mnemonic)</p><p>PrescriptionStatus.adhocReason(originalText)</p> 
         * <p>Ensures consistent terminology in capturing and 
         * interpreting reasons for change. Allows CWE because not all 
         * reasons will correspond to a pre-defined code.</p> Un-merged 
         * Business Name: ChangeReason Relationship: 
         * PORX_MT060160CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes the 
         * reason the status of the prescription was changed.</p> 
         * <p>PrescriptionStatus.reason(mnemonic)</p><p>PrescriptionStatus.adhocReason(originalText)</p> 
         * <p>PrescriptionStatus.reason(mnemonic)</p><p>PrescriptionStatus.adhocReason(originalText)</p> 
         * <p>Ensures consistent terminology in capturing and 
         * interpreting reasons for change. Allows CWE because not all 
         * reasons will correspond to a pre-defined code.</p> Un-merged 
         * Business Name: ChangeReason Relationship: 
         * PORX_MT060040CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes the 
         * reason the status of the prescription was changed.</p> 
         * <p>PrescriptionStatus.reason(mnemonic)</p><p>PrescriptionStatus.adhocReason(originalText)</p> 
         * <p>PrescriptionStatus.reason(mnemonic)</p><p>PrescriptionStatus.adhocReason(originalText)</p> 
         * <p>Ensures consistent terminology in capturing and 
         * interpreting reasons for change. Allows CWE because not all 
         * reasons will correspond to a pre-defined code.</p> Un-merged 
         * Business Name: OtherMedicationStatusChangeReason 
         * Relationship: PORX_MT060210CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes the 
         * reason the status of the other medication was changed.</p> 
         * <p>Ensures consistent terminology in capturing and 
         * interpreting reasons for change. Allows CWE because not all 
         * reasons will correspond to a pre-defined code.</p> Un-merged 
         * Business Name: DispenseStatusChangeReason Relationship: 
         * PORX_MT060010CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes the 
         * reason the status of the prescription dispense was 
         * changed.</p> <p>Ensures consistent terminology in capturing 
         * and interpreting reasons for change. Allows CWE because not 
         * all reasons will correspond to a pre-defined code.</p> 
         * Un-merged Business Name: DispenseStatusChangeReason 
         * Relationship: PORX_MT060090CA.ControlActEvent.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Denotes the 
         * reason the status of the prescription dispense was 
         * changed.</p> <p>Ensures consistent terminology in capturing 
         * and interpreting reasons for change. Allows CWE because not 
         * all reasons will correspond to a pre-defined code.</p></remarks>
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
         * PORX_MT060340CA.ResponsibleParty3.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.ResponsibleParty6.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.ResponsibleParty4.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060210CA.ResponsibleParty2.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060010CA.ResponsibleParty2.assignedPerson 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060090CA.ResponsibleParty4.assignedPerson 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Common.Coct_mt090107ca.Provider ResponsiblePartyAssignedPerson {
            get { return this.responsiblePartyAssignedPerson; }
            set { this.responsiblePartyAssignedPerson = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060340CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1) <p>&nbsp;Identity of 
         * the health service provider or</p> <div>application 
         * responsible for the change in the</div> <div>prescription 
         * status.</div> Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * PORX_MT060160CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1) <div>Identity of the 
         * health service provider or</div> <div>application 
         * responsible for the change in the</div> <p>prescription 
         * status.&nbsp;</p> Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * PORX_MT060210CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1) <div>Identity of the 
         * health service provider or the</div> <div>application 
         * responsible for the change in the other</div> <p>medication 
         * status.&nbsp;</p> Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * PORX_MT060010CA.ControlActEvent.author 
         * Conformance/Cardinality: POPULATED (1) <div>Identity of the 
         * health service provider or the</div> <div>application 
         * responsible for the change in the</div> <p>prescription 
         * dispense status.&nbsp;</p> Un-merged Business Name: (no 
         * business name specified) Relationship: 
         * PORX_MT060090CA.ControlActEvent.author 
         * Conformance/Cardinality: MANDATORY (1) <div>Identity of the 
         * health service provider or the</div> <div>application 
         * responsible for the change in the</div> <p>prescription 
         * dispense status.&nbsp;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Merged.ManagedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

    }

}