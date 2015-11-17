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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Antigens</summary>
     * 
     * <remarks>POIZ_MT030050AB.Antigens: Antigens <p>Important for 
     * expressing antigen validity and counts.</p> <p>A list of 
     * antigens that may or be present in a vaccine administered to 
     * a patient.</p> POIZ_MT060150AB.Antigens: Antigens 
     * <p>Important for expressing antigen validity and counts.</p> 
     * <p>A list of antigens that may or be present in a vaccine 
     * administered to a patient.</p> POIZ_MT030060AB.Antigens: 
     * Antigens <p>Important for expressing antigen validity and 
     * counts.</p> <p>A list of antigens that may or be present in 
     * a vaccine administered to a patient.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POIZ_MT030050AB.Antigens","POIZ_MT030060AB.Antigens","POIZ_MT060150AB.Antigens"})]
    public class Antigens : MessagePartBean {

        private CV code;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Merged.HealthChart asHealthChart;

        public Antigens() {
            this.code = new CVImpl();
        }
        /**
         * <summary>Business Name: AntigenCode</summary>
         * 
         * <remarks>Un-merged Business Name: AntigenCode Relationship: 
         * POIZ_MT030050AB.Antigens.code Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows un-ambiguous identification of the 
         * ingredients of a drug for performing various alert 
         * checking.</p><p>Also allows for the identification of 
         * antigens as specific class of ingredients in vaccines.</p> 
         * <p>The unique code used to identify the antigen.</p> 
         * Un-merged Business Name: AntigenCode Relationship: 
         * POIZ_MT030060AB.Antigens.code Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows un-ambiguous identification of the 
         * ingredients of a drug for performing various alert 
         * checking.</p><p>Also allows for the identification of 
         * antigens as specific class of ingredients in vaccines.</p> 
         * <p>The unique code used to identify the antigen.</p> 
         * Un-merged Business Name: AntigenCode Relationship: 
         * POIZ_MT060150AB.Antigens.code Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows un-ambiguous identification of the 
         * ingredients of a drug for performing various alert 
         * checking.</p><p>Also allows for the identification of 
         * antigens as specific class of ingredients in vaccines.</p> 
         * <p>The unique code used to identify the antigen.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ClinicalDrug Code {
            get { return (ClinicalDrug) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * POIZ_MT030050AB.Antigens.asHealthChart 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT030060AB.Antigens.asHealthChart 
         * Conformance/Cardinality: REQUIRED (0-1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POIZ_MT060150AB.Antigens.asHealthChart 
         * Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"asHealthChart"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Immunization.Merged.HealthChart AsHealthChart {
            get { return this.asHealthChart; }
            set { this.asHealthChart = value; }
        }

    }

}