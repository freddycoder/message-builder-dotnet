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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Substitution</summary>
     * 
     * <remarks>PORX_MT060160CA.SubstitutionMade: Substitution 
     * <p>May explain why prescribed and dispensed medications 
     * differ.</p> <p>An indication of what kind of substitution 
     * made, if any.</p> PORX_MT060090CA.SubstitutionMade: 
     * Substitution <p>May explain why prescribed and dispensed 
     * medications differ.</p> <p>An indication of what kind of 
     * substitution made, if any.</p> 
     * PORX_MT060340CA.SubstitutionMade: Substitution <p>May 
     * explain why prescribed and dispensed medications differ.</p> 
     * <p>An indication of what kind of substitution made, if 
     * any.</p> PORX_MT020070CA.SubstitutionMade: Substitution 
     * <p>May explain why prescribed and dispensed medications may 
     * differ.</p> <p>An indication of what kind of substitution 
     * was made, if any.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT020070CA.SubstitutionMade","PORX_MT060090CA.SubstitutionMade","PORX_MT060160CA.SubstitutionMade","PORX_MT060340CA.SubstitutionMade"})]
    public class Substitution : MessagePartBean {

        private CV code;
        private CV reasonCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged.Agent responsiblePartyAgent;

        public Substitution() {
            this.code = new CVImpl();
            this.reasonCode = new CVImpl();
        }
        /**
         * <summary>Business Name: SubstitutionCode</summary>
         * 
         * <remarks>Un-merged Business Name: SubstitutionCode 
         * Relationship: PORX_MT060090CA.SubstitutionMade.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that 
         * substitution was done (or not). This attribute is mandatory 
         * because it is essential to understanding the 
         * substitution.</p> <p>A code signifying whether a different 
         * drug was dispensed from what was prescribed.</p> Un-merged 
         * Business Name: SubstitutionCode Relationship: 
         * PORX_MT060160CA.SubstitutionMade.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that 
         * substitution was done (or not). This attribute is mandatory 
         * because it is essential to understanding the 
         * substitution.</p> <p>A code signifying whether a different 
         * drug was dispensed from what was prescribed.</p> Un-merged 
         * Business Name: SubstitutionCode Relationship: 
         * PORX_MT060340CA.SubstitutionMade.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that 
         * substitution was done (or not). This attribute is mandatory 
         * because it is essential to understanding the 
         * substitution.</p> <p>A code signifying whether a different 
         * drug was dispensed from what was prescribed.</p> Un-merged 
         * Business Name: SubstitutionCode Relationship: 
         * PORX_MT020070CA.SubstitutionMade.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates that 
         * substitution was done (or not). This attribute is mandatory 
         * because it is essential to understanding the 
         * substitution.</p> <p>A code signifying whether a different 
         * drug was dispensed from what was prescribed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActSubstanceAdminSubstitutionCode Code {
            get { return (ActSubstanceAdminSubstitutionCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: ProductSelectionReasonCode</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060090CA.SubstitutionMade.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Standardized 
         * reasons for substitution performed (or not performed). 
         * Useful in analysis of dispensing patterns.</p> <p>Indicates 
         * the reason for the substitution of (or failure to 
         * substitute) the medication from what was prescribed.</p> 
         * Un-merged Business Name: ProductSelectionCode Relationship: 
         * PORX_MT060160CA.SubstitutionMade.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Standardized 
         * reasons for substitution performed (or not performed). 
         * Useful in analysis of dispensing patterns.</p> <p>Indicates 
         * the reason for the substitution of (or failure to 
         * substitute) the medication from what was prescribed.</p> 
         * Un-merged Business Name: ProductSelectionCode Relationship: 
         * PORX_MT060340CA.SubstitutionMade.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Standardized 
         * reasons for substitution performed (or not performed). 
         * Useful in analysis of dispensing patterns.</p> <p>Indicates 
         * the reason for the substitution of (or failure to 
         * substitute) the medication from what was prescribed.</p> 
         * Un-merged Business Name: ProductSelectionReasonCode 
         * Relationship: PORX_MT020070CA.SubstitutionMade.reasonCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Standardized 
         * reasons for substitution performed (or not performed). 
         * Useful in analysis of dispensing patterns.</p> <p>Indicates 
         * the reason for the substitution of (or lack of substitution) 
         * from what was prescribed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reasonCode"})]
        public SubstanceAdminSubstitutionReason ReasonCode {
            get { return (SubstanceAdminSubstitutionReason) this.reasonCode.Value; }
            set { this.reasonCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060090CA.ResponsibleParty.agent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060160CA.ResponsibleParty.agent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060340CA.ResponsibleParty.agent 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT020070CA.ResponsibleParty.agent 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty/agent"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Merged.Agent ResponsiblePartyAgent {
            get { return this.responsiblePartyAgent; }
            set { this.responsiblePartyAgent = value; }
        }

    }

}