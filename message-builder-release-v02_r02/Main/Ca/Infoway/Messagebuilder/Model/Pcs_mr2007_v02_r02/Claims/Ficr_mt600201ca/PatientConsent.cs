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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt600201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Patient consent</summary>
     * 
     * <p>Information about the patient's consent.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT600201CA.Subject"})]
    public class PatientConsent : MessagePartBean {

        private ST signatureText;
        private BL patientConsentValue;

        public PatientConsent() {
            this.signatureText = new STImpl();
            this.patientConsentValue = new BLImpl(false);
        }
        /**
         * <summary>Business Name: Patient Keyword</summary>
         * 
         * <remarks>Relationship: FICR_MT600201CA.Subject.signatureText 
         * Conformance/Cardinality: MANDATORY (1) <p>The keyword used 
         * by the Patient to indicate signature or consent.</p> 
         * <p>Patient Keyword</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"signatureText"})]
        public String SignatureText {
            get { return this.signatureText.Value; }
            set { this.signatureText.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT600201CA.Subject.patientConsent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientConsent"})]
        public bool? PatientConsentValue {
            get { return this.patientConsentValue.Value; }
            set { this.patientConsentValue.Value = value; }
        }

    }

}