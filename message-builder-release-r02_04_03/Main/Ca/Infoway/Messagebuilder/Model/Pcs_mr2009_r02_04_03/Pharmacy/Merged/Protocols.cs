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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Domainvalue;


    /**
     * <summary>Business Name: Protocols</summary>
     * 
     * <remarks>PORX_MT060340CA.SubstanceAdministrationDefinition: 
     * Protocols <p>Allows linking to specific guidelines or 
     * protocols. Also used to provide additional detail needed 
     * when requesting a 'special access' drug from Health 
     * Canada.</p> <p>Documentation of why a prescriber has chosen 
     * to prescribe the drug in the manner they have.</p> 
     * PORX_MT060160CA.SubstanceAdministrationDefinition: Protocols 
     * <p>Allows linking to specific guidelines or protocols. Also 
     * used to provide additional detail needed when requesting a 
     * 'special access' drug from Health Canada.</p> 
     * <p>Documentation of why a prescriber has chosen to prescribe 
     * the drug in the manner they have.</p> 
     * PORX_MT010120CA.SubstanceAdministrationDefinition: Protocols 
     * <p>May be important in Quality Assurance monitoring - are 
     * the best, most recent protocols being followed.</p> <p>May 
     * define a specific protocol that is being followed in 
     * treating the patient.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010120CA.SubstanceAdministrationDefinition","PORX_MT060160CA.SubstanceAdministrationDefinition","PORX_MT060340CA.SubstanceAdministrationDefinition"})]
    public class Protocols : MessagePartBean {

        private II id;
        private CV code;

        public Protocols() {
            this.id = new IIImpl();
            this.code = new CVImpl();
        }
        /**
         * <summary>Business Name: ProtocolIdentifiers</summary>
         * 
         * <remarks>Un-merged Business Name: ProtocolIdentifiers 
         * Relationship: 
         * PORX_MT060340CA.SubstanceAdministrationDefinition.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Enables the 
         * communication of a reference to a protocol, study or 
         * guideline id, specific to the jurisdiction;</p><p>Allows 
         * providers to reference a protocol/guideline for prescribing 
         * to specific situations. This could also be used for 
         * justification for prescribing a medication from a particular 
         * formulary. E.g., 'Limited' Use' medications in Ontario 
         * require physicians to use a code indicating that a patient 
         * is eligible for this particular medication.</p> <p>A unique 
         * identifier for a specific protocol or guideline which the 
         * prescription has been written in accordance with.</p> 
         * Un-merged Business Name: ProtocolIdentifiers Relationship: 
         * PORX_MT060160CA.SubstanceAdministrationDefinition.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Enables the 
         * communication of a reference to a protocol, study or 
         * guideline id, specific to the jurisdiction;</p><p>Allows 
         * providers to reference a protocol/guideline for prescribing 
         * to specific situations. This could also be used for 
         * justification for prescribing a medication from a particular 
         * formulary. E.g., 'Limited Use' medications in Ontario 
         * require physicians to use a code indicating that a patient 
         * is eligible for this particular medication.</p> <p>A unique 
         * identifier for a specific protocol or guideline which the 
         * prescription has been written in accordance with.</p> 
         * Un-merged Business Name: ProtocolIdentifiers Relationship: 
         * PORX_MT010120CA.SubstanceAdministrationDefinition.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Enables the 
         * communication of a reference to a protocol, study or 
         * guideline id, specific to the jurisdiction;</p><p>Allows 
         * providers to reference a protocol/guideline for prescribing 
         * to specific situations. This could also be used for 
         * justification for prescribing a medication from a particular 
         * formulary. E.g., 'Limited Use' medications in Ontario 
         * require physicians to use a code indicating that a patient 
         * is eligible for this particular medication;</p><p>This 
         * attribute is mandatory as the id clearly identifies the 
         * protocol, study or guideline being referenced</p> <p>A 
         * unique identifier for a specific protocol or guideline which 
         * the prescription has been written in accordance with.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: PrescriptionType</summary>
         * 
         * <remarks>Un-merged Business Name: PrescriptionType 
         * Relationship: 
         * PORX_MT060340CA.SubstanceAdministrationDefinition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Important in 
         * confirming that the correct protocol is being 
         * followed.</p><p>Therefore is Mandatory</p> <p>Relevant in 
         * understanding the protocol.</p> Un-merged Business Name: 
         * PrescriptionType Relationship: 
         * PORX_MT060160CA.SubstanceAdministrationDefinition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Important in 
         * confirming that the correct protocol is being 
         * followed.</p><p>Therefore is Mandatory</p> <p>Relevant in 
         * understanding the protocol.</p> Un-merged Business Name: 
         * PrescriptionType Relationship: 
         * PORX_MT010120CA.SubstanceAdministrationDefinition.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Important in 
         * confirming that the correct protocol is being 
         * followed.</p><p>Therefore is Mandatory</p> <p>Relevant in 
         * understanding the protocol.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public SubstanceAdministrationType Code {
            get { return (SubstanceAdministrationType) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}