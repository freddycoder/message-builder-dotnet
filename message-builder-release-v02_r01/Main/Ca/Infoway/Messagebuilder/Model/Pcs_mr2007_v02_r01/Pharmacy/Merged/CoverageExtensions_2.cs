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
 * Last modified: $LastChangedDate: 2013-03-08 11:06:36 -0500 (Fri, 08 Mar 2013) $
 * Revision:      $LastChangedRevision: 6699 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged;


    /**
     * <summary>Business Name: CoverageExtensions</summary>
     * 
     * <remarks>PORX_MT060160CA.Coverage: Coverage Extensions 
     * <p>Allows conveying special coverage information between 
     * providers.</p> <p>An authorization issued by a payor to 
     * cover a drug not previously covered by a patient's drug 
     * plan.</p> PORX_MT060340CA.Coverage: Coverage Extensions 
     * <p>Allows conveying special coverage information between 
     * providers.</p> <p>An authorization issued by a payor to 
     * cover a drug not previously covered by a patient's drug 
     * plan.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060160CA.Coverage","PORX_MT060340CA.Coverage"})]
    public class CoverageExtensions_2 : MessagePartBean {

        private CS moodCode;
        private II id;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.CarrierRole authorCarrierRole;

        public CoverageExtensions_2() {
            this.moodCode = new CSImpl();
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: ExtensionGrantedIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: ExtensionGrantedIndicator 
         * Relationship: PORX_MT060160CA.Coverage.moodCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates to the 
         * pharmacy whether they need to check the status of coverage 
         * prior to dispensing. Mandatory due to HL7 rules.</p> <p>If 
         * set to 'EVN', then coverage has been requested. Otherwise it 
         * has merely been requested.</p> Un-merged Business Name: 
         * ExtensionGrantedIndicator Relationship: 
         * PORX_MT060340CA.Coverage.moodCode Conformance/Cardinality: 
         * MANDATORY (1) <p>Indicates to the pharmacy whether they need 
         * to check the status of coverage prior to dispensing. The 
         * element is mandatory to satisfy HL7 rules.</p> <p>If set to 
         * 'EVN', then coverage has been granted. Otherwise it has 
         * merely been requested.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"moodCode"})]
        public x_ActMoodOrderEvent MoodCode {
            get { return (x_ActMoodOrderEvent) this.moodCode.Value; }
            set { this.moodCode.Value = value; }
        }

        /**
         * <summary>Business Name: CoverageExtensionId</summary>
         * 
         * <remarks>Un-merged Business Name: CoverageExtensionId 
         * Relationship: PORX_MT060160CA.Coverage.id 
         * Conformance/Cardinality: POPULATED (1) <p>Allows for 
         * referencing of a specific coverage extension.</p><p>This 
         * identifier may be needed on claims against the 
         * coverage.</p><p>At times when the ID will not be available 
         * (such as when the request has just been submitted), the 
         * attribute is 'populated'.</p> <p>Unique identification for a 
         * specific coverage extension.</p> Un-merged Business Name: 
         * CoverageExtensionId Relationship: 
         * PORX_MT060340CA.Coverage.id Conformance/Cardinality: 
         * POPULATED (1) <p>Allows for referencing of a specific 
         * coverage extension.</p><p>This identifier may be needed on 
         * claims against the coverage.</p><p>At times the ID will not 
         * be available (such as when the request has just been 
         * submitted), the attribute is 'populated'.</p> <p>Unique 
         * identification for a specific coverage extension.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PORX_MT060160CA.Author2.carrierRole 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.Author2.carrierRole Conformance/Cardinality: 
         * MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author/carrierRole"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Merged.CarrierRole AuthorCarrierRole {
            get { return this.authorCarrierRole; }
            set { this.authorCarrierRole = value; }
        }

    }

}