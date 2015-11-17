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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Prpa_mt101106ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Identified Person</summary>
     * 
     * <p>Provides the message entry point required to add a person 
     * to the Client Registry</p> <p>The IdentifiedEntity class is 
     * the entry point to the R-MIM and contains one or more 
     * identifiers (for example an &quot;internal&quot; id used 
     * only by computer systems and an &quot;external&quot; id for 
     * display to users) for the Person in the Client Registry. The 
     * statusCode is set to &quot;active&quot;. The beginning of 
     * the effectiveTime is when the record was added to the 
     * registry.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101106CA.IdentifiedEntity"})]
    public class IdentifiedPerson : MessagePartBean {

        private SET<II, Identifier> id;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private CV confidentialityCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged.OtherIDsNonHealthcareIdentifiers> identifiedPersonAsOtherIDs;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged.ConfidenceValue subjectOfObservationEvent;

        public IdentifiedPerson() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new CVImpl();
            this.identifiedPersonAsOtherIDs = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged.OtherIDsNonHealthcareIdentifiers>();
        }
        /**
         * <summary>Business Name: Client Healthcare Identification 
         * Number</summary>
         * 
         * <remarks>Relationship: PRPA_MT101106CA.IdentifiedEntity.id 
         * Conformance/Cardinality: REQUIRED (1-40) <p>Mandatory 
         * attribute supports unique identification of the client.</p> 
         * <p>At least 1 client identifier must be present in the 
         * message</p> <p>This identification attribute supports 
         * capture of a healthcare identifier specific to the client. 
         * This identifier may be assigned jurisdictionally or by care 
         * facility.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Client Status Code</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101106CA.IdentifiedEntity.statusCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the identification of the client</p> <p>Indicates 
         * the status of the Client role (e.g. Active)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public RoleStatus StatusCode {
            get { return (RoleStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Client Effective Time</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101106CA.IdentifiedEntity.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute supports the identification of the client</p> 
         * <p>An interval of time specifying the period during which 
         * this record in a client registry is in effect, if such time 
         * limit is applicable and known</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Client Masked Information</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101106CA.IdentifiedEntity.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the business requirement to provide restricted 
         * access where required</p> <p>Data in the EHR may at some 
         * point (and in some jurisdictions) be accessed directly by 
         * patients. Some health information may be deemed 
         * inappropriate for direct access by patients and requires 
         * interpretation by a clinician (e.g. prescription of 
         * placebos, analysis of certain psychiatric conditions, etc) 
         * Even where direct access by patient is not provided, there 
         * may need to be guidance to other providers viewing the 
         * record where care should be used in disclosing information 
         * to the patient. Non-clinical data (e.g. demographics) may 
         * need to be flagged as not for disclosure to patient and or 
         * next of kin. There may be professional policy and or 
         * legislative guidelines about when/if records may be flagged 
         * as not for direct disclosure.</p> <p>A code that controls 
         * the disclosure of information about this patient 
         * encounter.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public x_VeryBasicConfidentialityKind ConfidentialityCode {
            get { return (x_VeryBasicConfidentialityKind) this.confidentialityCode.Value; }
            set { this.confidentialityCode.Value = value; }
        }

        /**
         * <summary>Relationship: PRPA_MT101106CA.Person.asOtherIDs</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-100)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/asOtherIDs"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged.OtherIDsNonHealthcareIdentifiers> IdentifiedPersonAsOtherIDs {
            get { return this.identifiedPersonAsOtherIDs; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101106CA.Subject.observationEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/observationEvent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged.ConfidenceValue SubjectOfObservationEvent {
            get { return this.subjectOfObservationEvent; }
            set { this.subjectOfObservationEvent = value; }
        }

    }

}