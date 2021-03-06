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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca;
    using System;


    /**
     * <summary>REPC_MT230002CA.Author: *a: authored by</summary>
     * 
     * <p> <i>Used to identify responsibility for accuracy and 
     * relevance of the information. This association reflects 
     * primary responsibility, and is therefore mandatory.</i> 
     * </p><p> <i>The author is generally the person to contact 
     * with requests for additional information. In some cases, 
     * this information may also be used for filtering or 
     * sorting.</i> </p> <p> <i>This identifies the provider who is 
     * responsible for the decision to capture the Clinical 
     * Observation Document in the patient's EHR. Note that while 
     * the author is frequently the data-enterer, this will not 
     * always be the case, for example where transcribers are 
     * involved.</i> </p> REPC_MT220001CA.Author3: *a: requested by 
     * <p> <i>By requesting the action, the provider takes a level 
     * of responsibility for it. The attribute may also be used to 
     * search or filter records. Requesting providers generally 
     * have authorization to view masked information as well.</i> 
     * </p> <p> <i>This identifies the provider who requested the 
     * Discharge-Care Summary to be performed. The request may have 
     * been verbal, electronic, as part of a referral or by other 
     * means. This element does not need to be captured in 
     * &quot;record&quot; and &quot;amend&quot; messages where a 
     * request id is captured, as the requesting provider can be 
     * looked up by retrieving the request.</i> </p> 
     * REPC_MT230002CA.Author2: *a: requested by <p> <i>By 
     * requesting the action, the provider takes a level of 
     * responsibility for it. The attribute may also be used to 
     * search or filter records. Requesting providers generally 
     * have authorization to view masked information as well.</i> 
     * </p> <p> <i>This identifies the provider who requested the 
     * Clinical Observation Document to be performed. The request 
     * may have been verbal, electronic, as part of a referral or 
     * by other means. This element does not need to be captured in 
     * &quot;record&quot; and &quot;amend&quot; messages where a 
     * request id is captured, as the requesting provider can be 
     * looked up by retrieving the request.</i> </p> 
     * REPC_MT500001CA.Author2: *requested by <p> <i>By requesting 
     * the action, the provider takes a level of responsibility for 
     * it. The attribute may also be used to search or filter 
     * records. Requesting providers generally have authorization 
     * to view masked information as well.</i> </p> <p> <i>This 
     * identifies the provider who requested the Care Composition 
     * to be performed. The request may have been verbal, 
     * electronic, as part of a referral or by other means. This 
     * element does not need to be captured in &quot;record&quot; 
     * and &quot;amend&quot; messages where a request id is 
     * captured, as the requesting provider can be looked up by 
     * retrieving the request.</i> </p> REPC_MT220002CA.Author3: 
     * *a: requested by <p> <i>By requesting the action, the 
     * provider takes a level of responsibility for it. The 
     * attribute may also be used to search or filter records. 
     * Requesting providers generally have authorization to view 
     * masked information as well.</i> </p> <p> <i>This identifies 
     * the provider who requested the Discharge-Care Summary to be 
     * performed. The request may have been verbal, electronic, as 
     * part of a referral or by other means. This element does not 
     * need to be captured in &quot;record&quot; and 
     * &quot;amend&quot; messages where a request id is captured, 
     * as the requesting provider can be looked up by retrieving 
     * the request.</i> </p> REPC_MT500002CA.Author2: *requested by 
     * <p> <i>By requesting the action, the provider takes a level 
     * of responsibility for it. The attribute may also be used to 
     * search or filter records. Requesting providers generally 
     * have authorization to view masked information as well.</i> 
     * </p> <p> <i>This identifies the provider who requested the 
     * Care Composition to be performed. The request may have been 
     * verbal, electronic, as part of a referral or by other means. 
     * This element does not need to be captured in 
     * &quot;record&quot; and &quot;amend&quot; messages where a 
     * request id is captured, as the requesting provider can be 
     * looked up by retrieving the request.</i> </p> 
     * REPC_MT230003CA.Author2: *a: requested by <p> <i>By 
     * requesting the action, the provider takes a level of 
     * responsibility for it. The attribute may also be used to 
     * search or filter records. Requesting providers generally 
     * have authorization to view masked information as well.</i> 
     * </p> <p> <i>This identifies the provider who requested the 
     * Clinical Observation Document to be performed. The request 
     * may have been verbal, electronic, as part of a referral or 
     * by other means. This element does not need to be captured in 
     * &quot;record&quot; and &quot;amend&quot; messages where a 
     * request id is captured, as the requesting provider can be 
     * looked up by retrieving the request.</i> </p> 
     * REPC_MT500003CA.Author2: *requested by <p> <i>By requesting 
     * the action, the provider takes a level of responsibility for 
     * it. The attribute may also be used to search or filter 
     * records. Requesting providers generally have authorization 
     * to view masked information as well.</i> </p> <p> <i>This 
     * identifies the provider who requested the Care Composition 
     * to be performed. The request may have been verbal, 
     * electronic, as part of a referral or by other means. This 
     * element does not need to be captured in &quot;record&quot; 
     * and &quot;amend&quot; messages where a request id is 
     * captured, as the requesting provider can be looked up by 
     * retrieving the request.</i> </p> REPC_MT220002CA.Author: *a: 
     * authored by <p> <i>Used to identify responsibility for 
     * accuracy and relevance of the information. This association 
     * reflects primary responsibility, and is therefore 
     * mandatory.</i> </p><p> <i>The author is generally the person 
     * to contact with requests for additional information. In some 
     * cases, this information may also be used for filtering or 
     * sorting.</i> </p> <p> <i>This identifies the provider who is 
     * responsible for the decision to capture the Discharge-Care 
     * Summary in the patient's EHR. Note that while the author is 
     * frequently the data-enterer, this will not always be the 
     * case, for example where transcribers are involved.</i> </p> 
     * REPC_MT210003CA.Author: *a: authored by <p> <i>Used to 
     * identify responsibility for accuracy and relevance of the 
     * information. This association reflects primary 
     * responsibility, and is therefore mandatory.</i> </p><p> 
     * <i>The author is generally the person to contact with 
     * requests for additional information. In some cases, this 
     * information may also be used for filtering or sorting.</i> 
     * </p> <p> <i>This identifies the provider who is responsible 
     * for the decision to capture the Referral in the patient's 
     * EHR. Note that while the author is frequently the 
     * data-enterer, this will not always be the case, for example 
     * where transcribers are involved.</i> </p> 
     * REPC_MT230003CA.Author: *a: authored by <p> <i>Used to 
     * identify responsibility for accuracy and relevance of the 
     * information. This association reflects primary 
     * responsibility, and is therefore mandatory.</i> </p><p> 
     * <i>The author is generally the person to contact with 
     * requests for additional information. In some cases, this 
     * information may also be used for filtering or sorting.</i> 
     * </p> <p> <i>This identifies the provider who is responsible 
     * for the decision to capture the Clinical Observation 
     * Document in the patient's EHR. Note that while the author is 
     * frequently the data-enterer, this will not always be the 
     * case, for example where transcribers are involved.</i> </p> 
     * REPC_MT210002CA.Author: *a: authored by <p> <i>Used to 
     * identify responsibility for accuracy and relevance of the 
     * information. This association reflects primary 
     * responsibility, and is therefore mandatory.</i> </p><p> 
     * <i>The author is generally the person to contact with 
     * requests for additional information. In some cases, this 
     * information may also be used for filtering or sorting.</i> 
     * </p> <p> <i>This identifies the provider who is responsible 
     * for the decision to capture the Referral in the patient's 
     * EHR. Note that while the author is frequently the 
     * data-enterer, this will not always be the case, for example 
     * where transcribers are involved.</i> </p> 
     * REPC_MT500004CA.Author: *amended by <p> <i>The most recent 
     * Amending Provider has significant responsibility for the 
     * &quot;current appearance&quot; of the record and can have 
     * considerable influence on how other providers will interpret 
     * the validity and significance of the record. The element is 
     * mandatory because it should always be known by the EHR.</i> 
     * </p> <p> <i>This identifies the provider who most recently 
     * amended the Care Composition.</i> </p> 
     * REPC_MT420001CA.Author2: *i:requested by <p> <i>By 
     * requesting the action, the provider takes a level of 
     * responsibili
     * ... [rest of documentation truncated due to excessive length]
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT210001CA.Author","REPC_MT210002CA.Author","REPC_MT210003CA.Author","REPC_MT220001CA.Author","REPC_MT220001CA.Author3","REPC_MT220002CA.Author","REPC_MT220002CA.Author3","REPC_MT220003CA.Author","REPC_MT220003CA.Author3","REPC_MT230001CA.Author2","REPC_MT230002CA.Author","REPC_MT230002CA.Author2","REPC_MT230003CA.Author","REPC_MT230003CA.Author2","REPC_MT410001CA.Author","REPC_MT410003CA.Author2","REPC_MT410003CA.Author3","REPC_MT420001CA.Author2","REPC_MT420003CA.Author2","REPC_MT500001CA.Author2","REPC_MT500002CA.Author2","REPC_MT500003CA.Author","REPC_MT500003CA.Author2","REPC_MT500004CA.Author","REPC_MT500004CA.Author2","REPC_MT610001CA.Author","REPC_MT610002CA.Author"})]
    public class RequestedBy : MessagePartBean {

        private TS time;
        private CV signatureCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson actingPerson;

        public RequestedBy() {
            this.time = new TSImpl();
            this.signatureCode = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: AuthoredDatetime</summary>
         * 
         * <remarks>Relationship: REPC_MT220002CA.Author.time 
         * Conformance/Cardinality: REQUIRED (1) <p> <i>Used to allow 
         * for historical sequencing of records in the EHR, which 
         * facilitates auditing, sorting etc. This attribute is 
         * populated because it won't always be known in the 
         * circumstance where the data is being entered by a person 
         * other than the original &quot;creator&quot; of the 
         * record.</i> </p> <p> <i>Indicates the time the decision to 
         * record when the Discharge-Care Summary was made. This will 
         * usually be simultaneous with the time the record is 
         * submitted to the EHR, but in some circumstances may be 
         * before.</i> </p> Un-merged Business Name: AuthoredDatetime 
         * Relationship: REPC_MT230002CA.Author.time 
         * Conformance/Cardinality: REQUIRED (1) <p> <i>Used to allow 
         * for historical sequencing of records in the EHR, which 
         * facilitates auditing, sorting etc. This attribute is 
         * populated because it won't always be known in the 
         * circumstance where the data is being entered by a person 
         * other than the original &quot;creator&quot; of the 
         * record.</i> </p> <p> <i>Indicates the time the decision to 
         * record when the Clinical Observation Document was made. This 
         * will usually be simultaneous with the time the record is 
         * submitted to the EHR, but in some circumstances may be 
         * before.</i> </p> Un-merged Business Name: AmendDatetime 
         * Relationship: REPC_MT500003CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>It can be used 
         * by PoS applications to sort or filter records. Also provides 
         * information on how recently the record has changed.</i> 
         * </p><p> <i>Because the element should always be known by the 
         * EHR, it is mandatory.</i> </p> <p> <i>This indicates the 
         * last time a change was made to the Care Composition.</i> 
         * </p> Un-merged Business Name: AuthoredDatetime Relationship: 
         * REPC_MT210003CA.Author.time Conformance/Cardinality: 
         * REQUIRED (1) <p> <i>Used to allow for historical sequencing 
         * of records in the EHR, which facilitates auditing, sorting 
         * etc. This attribute is populated because it won't always be 
         * known in the circumstance where the data is being entered by 
         * a person other than the original &quot;creator&quot; of the 
         * record.</i> </p> <p> <i>Indicates the time the decision to 
         * record when the Referral was made. This will usually be 
         * simultaneous with the time the record is submitted to the 
         * EHR, but in some circumstances may be before.</i> </p> 
         * Un-merged Business Name: AuthoredDatetime Relationship: 
         * REPC_MT210002CA.Author.time Conformance/Cardinality: 
         * REQUIRED (1) <p> <i>Used to allow for historical sequencing 
         * of records in the EHR, which facilitates auditing, sorting 
         * etc. This attribute is populated because it won't always be 
         * known in the circumstance where the data is being entered by 
         * a person other than the original &quot;creator&quot; of the 
         * record.</i> </p> <p> <i>Indicates the time the decision to 
         * record when the Referral was made. This will usually be 
         * simultaneous with the time the record is submitted to the 
         * EHR, but in some circumstances may be before.</i> </p> 
         * Un-merged Business Name: AuthoredDatetime Relationship: 
         * REPC_MT230003CA.Author.time Conformance/Cardinality: 
         * REQUIRED (1) <p> <i>Used to allow for historical sequencing 
         * of records in the EHR, which facilitates auditing, sorting 
         * etc. This attribute is populated because it won't always be 
         * known in the circumstance where the data is being entered by 
         * a person other than the original &quot;creator&quot; of the 
         * record.</i> </p> <p> <i>Indicates the time the decision to 
         * record when the Clinical Observation Document was made. This 
         * will usually be simultaneous with the time the record is 
         * submitted to the EHR, but in some circumstances may be 
         * before.</i> </p> Un-merged Business Name: AmendDatetime 
         * Relationship: REPC_MT500004CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>It can be used 
         * by PoS applications to sort or filter records. Also provides 
         * information on how recently the record has changed.</i> 
         * </p><p> <i>Because the element should always be known by the 
         * EHR, it is mandatory.</i> </p> <p> <i>This indicates the 
         * last time a change was made to the Care Composition.</i> 
         * </p> Un-merged Business Name: AuthoredDatetime Relationship: 
         * REPC_MT220001CA.Author.time Conformance/Cardinality: 
         * REQUIRED (1) Un-merged Business Name: AuthoredDatetime 
         * Relationship: REPC_MT410003CA.Author3.time 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: AuthoredDatetime Relationship: 
         * REPC_MT220003CA.Author.time Conformance/Cardinality: 
         * REQUIRED (1) <p> <i>Used to allow for historical sequencing 
         * of records in the EHR, which facilitates auditing, sorting 
         * etc. This attribute is populated because it won't always be 
         * known in the circumstance where the data is being entered by 
         * a person other than the original &quot;creator&quot; of the 
         * record.</i> </p> <p> <i>Indicates the time the decision to 
         * record when the Discharge-Care Summary was made. This will 
         * usually be simultaneous with the time the record is 
         * submitted to the EHR, but in some circumstances may be 
         * before.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public PlatformDate Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

        /**
         * <summary>Business Name: AttestedIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: AttestedIndicator 
         * Relationship: REPC_MT220002CA.Author.signatureCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important for 
         * assessing the level of 'officialness' of a document. Because 
         * it must always be known whether a document has been attested 
         * or not, the attribute is mandatory.</p> <p>An indication 
         * that the provider attests to the authenticity of the 
         * document that he/she has authored.</p> Un-merged Business 
         * Name: AttestedIndicator Relationship: 
         * REPC_MT230002CA.Author.signatureCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important for 
         * assessing the level of 'officialness' of a document. Because 
         * it must always be known whether a document has been attested 
         * or not, the attribute is mandatory.</p> <p>An indication 
         * that the provider attests to the authenticity of the 
         * document that he/she has authored.</p> Un-merged Business 
         * Name: AttestedIndicator Relationship: 
         * REPC_MT210003CA.Author.signatureCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important for 
         * assessing the level of 'officialness' of a document. Because 
         * it must always be known whether a document has been attested 
         * or not, the attribute is mandatory.</p> <p>An indication 
         * that the provider attests to the authenticity of the 
         * document that he/she has authored.</p> Un-merged Business 
         * Name: AttestedIndicator Relationship: 
         * REPC_MT210002CA.Author.signatureCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important for 
         * assessing the level of 'officialness' of a document. Because 
         * it must always be known whether a document has been attested 
         * or not, the attribute is mandatory.</p> <p>An indication 
         * that the provider attests to the authenticity of the 
         * document that he/she has authored.</p> Un-merged Business 
         * Name: AttestedIndicator Relationship: 
         * REPC_MT230003CA.Author.signatureCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important for 
         * assessing the level of 'officialness' of a document. Because 
         * it must always be known whether a document has been attested 
         * or not, the attribute is mandatory.</p> <p>An indication 
         * that the provider attests to the authenticity of the 
         * document that he/she has authored.</p> Un-merged Business 
         * Name: AttestedIndicator Relationship: 
         * REPC_MT220001CA.Author.signatureCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AttestedIndicator Relationship: 
         * REPC_MT210001CA.Author.signatureCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: AttestedIndicator Relationship: 
         * REPC_MT220003CA.Author.signatureCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important for 
         * assessing the level of 'officialness' of a document. Because 
         * it must always be known whether a document has been attested 
         * or not, the attribute is mandatory.</p> <p>An indication 
         * that the provider attests to the authenticity of the 
         * document that he/she has authored.</p></remarks>
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
         * <remarks>Relationship: REPC_MT220001CA.Author3.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230002CA.Author.actingPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * REPC_MT230002CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500001CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT220002CA.Author3.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500002CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230003CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500003CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT210001CA.Author.actingPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT220002CA.Author.actingPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT410001CA.Author.actingPerson Conformance/Cardinality: 
         * REQUIRED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT210003CA.Author.actingPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230003CA.Author.actingPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT210002CA.Author.actingPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500004CA.Author.actingPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * REPC_MT420001CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT230001CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT220003CA.Author3.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500004CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT610001CA.Author.actingPerson Conformance/Cardinality: 
         * REQUIRED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT500003CA.Author.actingPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT220001CA.Author.actingPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: REPC_MT220003CA.Author.actingPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT410003CA.Author3.actingPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT410003CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT610002CA.Author.actingPerson Conformance/Cardinality: 
         * REQUIRED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: 
         * REPC_MT420003CA.Author2.actingPerson 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"actingPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt911108ca.IActingPerson ActingPerson {
            get { return this.actingPerson; }
            set { this.actingPerson = value; }
        }

    }

}