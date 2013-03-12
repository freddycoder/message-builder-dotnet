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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT400001CA.HealthDocumentAttachment","FICR_MT490102CA.HealthDocumentAttachment","FICR_MT490103CA.HealthDocumentAttachment"})]
    public class HealthDocumentAttachment_1 : MessagePartBean {

        private II id;
        private CV code;
        private ED<EncapsulatedData> text;

        public HealthDocumentAttachment_1() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.text = new EDImpl<EncapsulatedData>();
        }
        /**
         * <summary>Business Name: AttachmentIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: AttachmentIdentifier 
         * Relationship: FICR_MT490103CA.HealthDocumentAttachment.id 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AttachmentIdentifier Relationship: 
         * FICR_MT490102CA.HealthDocumentAttachment.id 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AttachmentIdentifier Relationship: 
         * FICR_MT400001CA.HealthDocumentAttachment.id 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: AttachmentType</summary>
         * 
         * <remarks>Un-merged Business Name: AttachmentType 
         * Relationship: FICR_MT490103CA.HealthDocumentAttachment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Constrains the 
         * type of attachment (document, XRAY, bit map image, etc.) 
         * included to support a healthcare claim. Vocabulary bound to 
         * this domain should be a specification for the type of 
         * document (i.e. WCB First Report of Accident - Form 8).</p> 
         * Un-merged Business Name: AttachmentType Relationship: 
         * FICR_MT490102CA.HealthDocumentAttachment.code 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AttachmentType Relationship: 
         * FICR_MT400001CA.HealthDocumentAttachment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Constrains the 
         * type of attachment (document, XRAY, bit map image, etc.) 
         * included to support a healthcare claim. Vocabulary bound to 
         * this domain should be a specification for the type of 
         * document (i.e. WCB First Report of Accident - Form 8).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActClaimAttachmentCode Code {
            get { return (ActClaimAttachmentCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: AttachmentContent</summary>
         * 
         * <remarks>Un-merged Business Name: AttachmentContent 
         * Relationship: FICR_MT490103CA.HealthDocumentAttachment.text 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AttachmentContent Relationship: 
         * FICR_MT490102CA.HealthDocumentAttachment.text 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AttachmentContent Relationship: 
         * FICR_MT400001CA.HealthDocumentAttachment.text 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public EncapsulatedData Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

    }

}