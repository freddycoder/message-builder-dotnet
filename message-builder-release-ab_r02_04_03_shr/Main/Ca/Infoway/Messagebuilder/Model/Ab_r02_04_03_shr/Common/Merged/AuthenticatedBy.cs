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

/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: AuthenticatedBy</summary>
     * 
     * <remarks>RCMR_MT000220AB.Authenticator: authenticated by 
     * <p>Provides information about the person that authenticated 
     * the clinical document - i.e. the person that validated that 
     * the information contained within the clinical document is 
     * correct.</p> RCMR_MT000210AB.Authenticator: authenticated by 
     * <p>Provides information about the person that authenticated 
     * the clinical document - i.e. the person that validated that 
     * the information contained within the clinical document is 
     * correct.</p> RCMR_MT000002AB.Authenticator: authenticated by 
     * <p>Provides information about the person that authenticated 
     * the clinical document - i.e. the person that validated that 
     * the information contained within the clinical document is 
     * correct.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"RCMR_MT000002AB.Authenticator","RCMR_MT000210AB.Authenticator","RCMR_MT000220AB.Authenticator"})]
    public class AuthenticatedBy : MessagePartBean {

        private TS time;
        private CV signatureCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.AssignedPerson assignedPerson;

        public AuthenticatedBy() {
            this.time = new TSImpl();
            this.signatureCode = new CVImpl();
        }
        /**
         * <summary>Business Name: AuthenticationDate</summary>
         * 
         * <remarks>Un-merged Business Name: AuthenticationDate 
         * Relationship: RCMR_MT000220AB.Authenticator.time 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date that the 
         * clinical document was authenticated.</p> Un-merged Business 
         * Name: AuthenticationDate Relationship: 
         * RCMR_MT000210AB.Authenticator.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>The date that the clinical document was 
         * authenticated.</p> Un-merged Business Name: 
         * AuthenticationDate Relationship: 
         * RCMR_MT000002AB.Authenticator.time Conformance/Cardinality: 
         * REQUIRED (0-1) <p>The date that the clinical document was 
         * authenticated.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public PlatformDate Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

        /**
         * <summary>Business Name: AuthenticatorSignature</summary>
         * 
         * <remarks>Un-merged Business Name: AuthenticatorSignature 
         * Relationship: RCMR_MT000220AB.Authenticator.signatureCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Included to 
         * maintain conformance with HL7 UV model. Sent as a nullFlavor 
         * of 'NA' (Not Applicable) as this is not currently captured 
         * in Netcare report repositories.</p> <p>A code specifying 
         * whether and how the authenticator has attested his 
         * authentication through a signature and or whether such a 
         * signature is needed.</p> Un-merged Business Name: 
         * AuthenticatorSignature Relationship: 
         * RCMR_MT000210AB.Authenticator.signatureCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Included to 
         * maintain conformance with HL7 UV model. Sent as a nullFlavor 
         * of 'NA' (Not Applicable) as this is not currently captured 
         * in Netcare report repositories.</p> <p>A code specifying 
         * whether and how the authenticator has attested his 
         * authentication through a signature and or whether such a 
         * signature is needed.</p> Un-merged Business Name: 
         * AuthenticatorSignature Relationship: 
         * RCMR_MT000002AB.Authenticator.signatureCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Included to 
         * maintain conformance with HL7 UV model. Sent as a nullFlavor 
         * of 'NA' (Not Applicable) as this is not currently captured 
         * in Netcare report repositories.</p> <p>A code specifying 
         * whether and how the authenticator has attested his 
         * authentication through a signature and or whether such a 
         * signature is needed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"signatureCode"})]
        public ParticipationSignature SignatureCode {
            get { return (ParticipationSignature) this.signatureCode.Value; }
            set { this.signatureCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * RCMR_MT000220AB.Authenticator.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * RCMR_MT000210AB.Authenticator.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * RCMR_MT000002AB.Authenticator.assignedPerson 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged.AssignedPerson AssignedPerson {
            get { return this.assignedPerson; }
            set { this.assignedPerson = value; }
        }

    }

}