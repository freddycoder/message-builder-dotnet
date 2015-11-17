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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Claims.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using System.Collections.Generic;


    /**
     * <summary>FICR_MT600201CA.HealthDocumentAttachment: (no 
     * business name)</summary>
     * 
     * <p>Used to attach documents, image, etc.</p><p>required to 
     * support a health claim.</p><p>Value is not mandatory to 
     * allow for case where just a reference to an existing 
     * attachment is required.</p> 
     * FICR_MT500201CA.HealthDocumentAttachment: (no business name) 
     * <p>Used to attach documents, image, etc.</p><p>required to 
     * support a health claim.</p><p>Value is not mandatory to 
     * allow for case where just a reference to an existing 
     * attachment is required.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT500201CA.HealthDocumentAttachment","FICR_MT600201CA.HealthDocumentAttachment"})]
    public class HealthDocumentAttachment_2 : MessagePartBean {

        private SET<II, Identifier> id;
        private CV code;
        private ED<EncapsulatedData> value;

        public HealthDocumentAttachment_2() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.value = new EDImpl<EncapsulatedData>();
        }
        /**
         * <summary>Business Name: AttachmentIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: AttachmentIdentifier 
         * Relationship: FICR_MT600201CA.HealthDocumentAttachment.id 
         * Conformance/Cardinality: MANDATORY (1-5) Un-merged Business 
         * Name: AttachmentIdentifier Relationship: 
         * FICR_MT500201CA.HealthDocumentAttachment.id 
         * Conformance/Cardinality: MANDATORY (1-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: AttachmentType</summary>
         * 
         * <remarks>Un-merged Business Name: AttachmentType 
         * Relationship: FICR_MT600201CA.HealthDocumentAttachment.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Constrains the 
         * type of attachment (document, XRAY, bit map image, etc.) 
         * included to support a healthcare claim. Vocabulary bound to 
         * this domain should be a specification for the type of 
         * document (i.e. WCB First Report of Accident - Form 8).</p> 
         * Un-merged Business Name: AttachmentType Relationship: 
         * FICR_MT500201CA.HealthDocumentAttachment.code 
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
         * Relationship: FICR_MT600201CA.HealthDocumentAttachment.value 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: AttachmentContent Relationship: 
         * FICR_MT500201CA.HealthDocumentAttachment.value 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public EncapsulatedData Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}