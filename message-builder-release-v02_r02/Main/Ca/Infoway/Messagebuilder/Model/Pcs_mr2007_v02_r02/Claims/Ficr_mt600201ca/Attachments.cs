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
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Attachments</summary>
     * 
     * <p>If this relationship is required, it may only be 
     * specified for the Root Invoice Element Group and is not 
     * permitted for all other Invoice Element Groups.</p><p>Look 
     * into what HL7 is currently doing, as well as timing. Each 
     * SIG to revisit based on HL7's work. Want the ability to send 
     * attachments with the invoice as well as sending it upon 
     * request. Need to ensure that the vocab in the info codes for 
     * inv adj response supports the needed attachments.</p> <p>Use 
     * of attachments must be pre-approved by the NeCST Pharmacy 
     * SIG.</p><p>RxS1: Not permitted, as attachments are not 
     * included in this scenario.</p> <p>Could be used to attach a 
     * Limited Use Form or a Consent Form.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT600201CA.InvoiceElementGroupAttachment"})]
    public class Attachments : MessagePartBean {

        private CS typeCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt600201ca.HealthDocumentAttachment healthDocumentAttachment;

        public Attachments() {
            this.typeCode = new CSImpl();
        }
        /**
         * <summary>Relationship: 
         * FICR_MT600201CA.InvoiceElementGroupAttachment.typeCode</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeCode"})]
        public ActRelationshipType TypeCode {
            get { return (ActRelationshipType) this.typeCode.Value; }
            set { this.typeCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * FICR_MT600201CA.InvoiceElementGroupAttachment.healthDocumentAttachment</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"healthDocumentAttachment"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt600201ca.HealthDocumentAttachment HealthDocumentAttachment {
            get { return this.healthDocumentAttachment; }
            set { this.healthDocumentAttachment = value; }
        }

    }

}