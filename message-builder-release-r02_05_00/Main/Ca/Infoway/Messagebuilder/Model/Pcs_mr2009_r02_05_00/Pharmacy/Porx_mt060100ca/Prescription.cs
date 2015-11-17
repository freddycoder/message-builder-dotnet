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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt060100ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Prescription</summary>
     * 
     * <p>Provides a drill-down link from the prescription to its 
     * corresponding order.</p> <p>Indicates the order being 
     * dispensed</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060100CA.SubstanceAdministrationRequest"})]
    public class Prescription : MessagePartBean {

        private SET<II, Identifier> id;
        private CV code;
        private CS statusCode;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.SupervisedBy responsibleParty;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.PrescribedBy author;

        public Prescription() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.statusCode = new CSImpl();
        }
        /**
         * <summary>Business Name: A:Prescription Identifier</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060100CA.SubstanceAdministrationRequest.id 
         * Conformance/Cardinality: MANDATORY (1-2) <p>Links the 
         * dispense to the prescription it fulfilled.</p> <p>The 
         * Prescription Order Number is a globally unique number 
         * assigned to a prescription by the EHR/DIS irrespective of 
         * the source of the order</p><p>It is created by the EHR/DIS 
         * once the prescription has passed all edits and 
         * validation.</p><p>As the 'id' is the link to the 
         * prescription, it is Mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

        /**
         * <summary>Business Name: Prescription Type</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060100CA.SubstanceAdministrationRequest.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Important in 
         * understanding the context of the prescription being 
         * fulfilled. Therefore is Mandatory.</p> <p>Differentiates the 
         * type of medication e.g. drug, vaccine</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public SubstanceAdministrationType Code {
            get { return (SubstanceAdministrationType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Prescription Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060100CA.SubstanceAdministrationRequest.statusCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Needed in some 
         * jurisdictions</p> <p>Provides the status of the prescription 
         * without requiring additional queries</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060100CA.SubstanceAdministrationRequest.responsibleParty</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responsibleParty"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.SupervisedBy ResponsibleParty {
            get { return this.responsibleParty; }
            set { this.responsibleParty = value; }
        }

        /**
         * <summary>Relationship: 
         * PORX_MT060100CA.SubstanceAdministrationRequest.author</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"author"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Merged.PrescribedBy Author {
            get { return this.author; }
            set { this.author = value; }
        }

    }

}