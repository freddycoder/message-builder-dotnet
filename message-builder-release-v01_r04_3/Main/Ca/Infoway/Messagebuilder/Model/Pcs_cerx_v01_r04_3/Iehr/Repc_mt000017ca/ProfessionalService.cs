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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Repc_mt000017ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt050203ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt120600ca;
    using Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Merged;
    using System;


    /**
     * <summary>Business Name: Professional Service</summary>
     * 
     * <p>A_BillableClinicalService</p> <p>May be pertinent 
     * information with respect to a patient's drug therapy 
     * regime.</p> <p>This is the information that is recorded and 
     * maintained on a consultative service provided to a patient. 
     * This service may or may not be related to a prescribed, 
     * dispensed or administered drug.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000017CA.ProcedureEvent"})]
    public class ProfessionalService : MessagePartBean {

        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt050203ca.Patient subjectPatient;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Merged.OrderForService inFulfillmentOfActRequest;
        private Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt120600ca.Notes subjectOfAnnotation;

        public ProfessionalService() {
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new CVImpl();
        }
        /**
         * <summary>Business Name: B:Service Code</summary>
         * 
         * <remarks>Relationship: REPC_MT000017CA.ProcedureEvent.code 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>PatientConsultation.category</p> <p>D57</p> 
         * <p>ZPS.5.1</p> <p>ZPS.5.2 (experience handled as 
         * qualifier)</p> <p>Claim.436-E1 (code system)</p> 
         * <p>Claim.407-D7 (mnemonic)</p> <p>Claim.459-ER 
         * (modifier)</p> <p>Claim.418-DI (modifier)</p> 
         * <p>DUR/PPS.474-8E (modifier)</p> 
         * <p>A_BillableClinicalService</p> <p>Allows the service to be 
         * sorted and filtered. Ensures consistency for analysis and 
         * reporting purposes and is therefore mandatory</p> 
         * <p>Identifies the specific service that has been performed. 
         * This is obtained from the professional service catalog 
         * pertaining to the discipline of the health service 
         * provider.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActProfessionalServiceCode Code {
            get { return (ActProfessionalServiceCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: C:Consultation Time and Length</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000017CA.ProcedureEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>Center date cannot 
         * be null But duration can be left unspecified if not 
         * known.</p> <p>PatientConsultation.eventTime(Low)</p> 
         * <p>patientConsultation.eventDuration(Width)</p> <p>ZPS.4 
         * (center)</p> <p>ZPS.5.2(timing portion of code set)</p> 
         * <p>Claim.457-EP</p> <p>A_BillableClinicalService</p> 
         * <p>Allows the service-event to be located in a particular 
         * time. Because a time won't always be known, the attribute is 
         * only marked as &quot;populated&quot;. The duration of the 
         * consultation may also be of clinical interest.</p> <p>The 
         * date and time on which the professional service was 
         * performed, as well as the duration of the service.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: D:Professional Service Masking 
         * Indicator</summary>
         * 
         * <remarks>Relationship: 
         * REPC_MT000017CA.ProcedureEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows the 
         * patient to have discrete control over access to their 
         * medication data.</p><p>The attribute is optional because not 
         * all systems will support masking.</p> <p>Communicates the 
         * intent of the patient to restrict access to their 
         * professional service record. Provides support for additional 
         * confidentiality constraint, giving patients a level of 
         * control over their information. Valid values are: 'NORMAL' 
         * (denotes 'Not Masked'); and 'RESTRICTED' (denotes 'Masked'). 
         * The default is 'NORMAL' signifying 'Not Masked'.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Relationship: REPC_MT000017CA.Subject.patient</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/patient"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt050203ca.Patient SubjectPatient {
            get { return this.subjectPatient; }
            set { this.subjectPatient = value; }
        }

        /**
         * <summary>Relationship: 
         * REPC_MT000017CA.InFulfillmentOf.actRequest</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"inFulfillmentOf/actRequest"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Merged.OrderForService InFulfillmentOfActRequest {
            get { return this.inFulfillmentOfActRequest; }
            set { this.inFulfillmentOfActRequest = value; }
        }

        /**
         * <summary>Relationship: REPC_MT000017CA.Subject2.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt120600ca.Notes SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
            set { this.subjectOfAnnotation = value; }
        }

    }

}