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
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca;
    using System;


    /**
     * <summary>PORX_MT060210CA.Author: *b:recorded by</summary>
     * 
     * <p>Indicates the identity of the provider who recorded the 
     * other medication information.</p> <p>Allows other providers 
     * to enquire about the authenticity of the content of the 
     * other medication record and is therefore mandatory.</p> 
     * REPC_MT000009CA.Author: *f:authored by <p>Identifies the 
     * provider who reported the allergy or intolerance.</p> 
     * <p>Identifies responsibility for accuracy and relevance of 
     * the information. This association reflects primary 
     * responsibility, and is therefore mandatory.</p> 
     * PORX_MT060060CA.Author: *refused by <p>Indicates who refused 
     * to fulfill the prescription</p> <p>Allows follow-up and 
     * traceability of the refusal and is therefore mandatory</p> 
     * PORX_MT060190CA.Author3: *refused by <p>Indicates who 
     * refused to fulfill the prescription</p> <p>Allows follow-up 
     * and traceability of the refusal and is therefore 
     * mandatory</p> PORX_MT060190CA.Author: *recorded by 
     * <p>Indicates the provider who recorded the &quot;other 
     * active medication&quot;.</p> <p>Useful for follow-up and 
     * audit purposes, and therefore mandatory.</p> 
     * PORX_MT060040CA.Author: *refused by <p>Indicates who refused 
     * to fulfill the prescription</p> <p>Allows follow-up and 
     * traceability of the refusal.</p><p>Association is mandatory 
     * as the provider refusing the fill must be known.</p> 
     * <p>Allows follow-up and traceability of the 
     * refusal.</p><p>Association is mandatory as the provider 
     * refusing the fill must be known.</p> PORX_MT020070CA.Author: 
     * bc:prescribed by <p>The person who prescribed the 
     * medication.</p> <p>Used to create an 'inferred' prescription 
     * if an electronic prescription does not already exist in the 
     * EHR.</p> REPC_MT000005CA.Author: *f:authored by 
     * <p>Identifies the provider who reported the allergy or 
     * intolerance.</p> <p>Identifies responsibility for accuracy 
     * and relevance of the information. This association reflects 
     * primary responsibility, and is therefore mandatory.</p> 
     * PORX_MT030040CA.Author: *refused by <p>Indicates who refused 
     * to fulfill the prescription</p> <p>Allows follow-up and 
     * traceability of the refusal and is therefore mandatory.</p> 
     * REPC_MT000006CA.Author: *f:authored by <p>Identifies the 
     * provider who reported the reaction.</p> <p>Identifies 
     * responsibility for accuracy and relevance of the 
     * information. This association reflects primary 
     * responsibility, and is therefore mandatory.</p> 
     * PORX_MT020060CA.Author: bc:prescribed by <p>The person who 
     * prescribed the device.</p> <p>Used to create an 'inferred' 
     * prescription if an electronic prescription does not already 
     * exist in the EHR.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020060CA.Author","PORX_MT020070CA.Author","PORX_MT030040CA.Author","PORX_MT060040CA.Author","PORX_MT060060CA.Author","PORX_MT060190CA.Author","PORX_MT060190CA.Author3","PORX_MT060210CA.Author","REPC_MT000005CA.Author","REPC_MT000006CA.Author","REPC_MT000009CA.Author"})]
    public class RefusedBy : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker assignedEntity;
        private TS time;

        public RefusedBy() {
            this.time = new TSImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060210CA.Author.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000009CA.Author.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060060CA.Author.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT020070CA.Author.assignedEntity 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.Author.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Author.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060190CA.Author3.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000005CA.Author.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT030040CA.Author.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT000006CA.Author.assignedEntity 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT020060CA.Author.assignedEntity 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt090108ca.HealthcareWorker AssignedEntity {
            get { return this.assignedEntity; }
            set { this.assignedEntity = value; }
        }

        /**
         * <summary>Un-merged Business Name: CreateTimestamp</summary>
         * 
         * <remarks>Relationship: REPC_MT000009CA.Author.time 
         * Conformance/Cardinality: POPULATED (1) <p>The date and time 
         * on which the allergy/intolerance record was created.</p> 
         * <p>Identifies timing of allergy/intolerance for sorting and 
         * for audit purposes. Attribute is populated because the 
         * source of the data may not be through the 'record common 
         * observation' interaction.</p> Un-merged Business Name: 
         * PrescriptionOrderDate Relationship: 
         * PORX_MT020070CA.Author.time Conformance/Cardinality: 
         * POPULATED (1) <p>The date at which the drug was prescribed. 
         * This may differ from the date on which the prescription 
         * becomes effective. E.g. A prescription created today may not 
         * be valid to be dispensed or administered for two weeks.</p> 
         * <p>Indicates when the action was performed, and may 
         * influence expiry dates for the order.</p><p>The attribute is 
         * populated because the creation date of the prescription 
         * shall always be known or absent for a reason.</p> 
         * <p>Indicates when the action was performed, and may 
         * influence expiry dates for the order.</p><p>The attribute is 
         * populated because the creation date of the prescription 
         * shall always be known or absent for a reason.</p> Un-merged 
         * Business Name: CreateTimestamp Relationship: 
         * REPC_MT000005CA.Author.time Conformance/Cardinality: 
         * POPULATED (1) <p>The date and time on which the 
         * allergy/intolerance record was created.</p> <p>Identifies 
         * timing of allergy/intolerance for sorting and for audit 
         * purposes. Attribute is populated because the source of the 
         * data may not be through the 'record allergy/intolerance' 
         * interaction.</p> Un-merged Business Name: CreateTimestamp 
         * Relationship: REPC_MT000006CA.Author.time 
         * Conformance/Cardinality: POPULATED (1) <p>The date and time 
         * on which the adverse reaction record was created.</p> 
         * <p>Identifies timing of adverse reaction for sorting and for 
         * audit purposes. Attribute is populated because the source of 
         * the data may not be through the 'record common observation' 
         * interaction.</p> Un-merged Business Name: 
         * PrescriptionOrderDate Relationship: 
         * PORX_MT020060CA.Author.time Conformance/Cardinality: 
         * POPULATED (1) <p>The calendar date on which the device was 
         * prescribed. This may differ from the date on which the 
         * prescription becomes effective. E.g. A prescription created 
         * today may not be valid to be dispensed or used for two 
         * weeks.</p> <p>Indicates when the action was performed, and 
         * may influence expiry dates for the order.</p><p>The 
         * attribute is populated because the creation date of the 
         * prescription shall always be known or absent for a 
         * reason.</p> <p>Indicates when the action was performed, and 
         * may influence expiry dates for the order.</p><p>The 
         * attribute is populated because the creation date of the 
         * prescription shall always be known or absent for a 
         * reason.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public PlatformDate Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

    }

}