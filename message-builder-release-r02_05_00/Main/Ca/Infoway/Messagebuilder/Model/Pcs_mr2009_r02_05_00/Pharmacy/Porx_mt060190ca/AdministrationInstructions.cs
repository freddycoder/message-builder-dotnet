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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt060190ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060190CA.AdministrationInstructions"})]
    public class AdministrationInstructions : MessagePartBean {

        private CD code;
        private ST text;

        public AdministrationInstructions() {
            this.code = new CDImpl();
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: Medication type</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.AdministrationInstructions.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Important in 
         * providing the context of the rendered dosage 
         * instruction.</p><p>For this reason the attribute is 
         * Mandatory.</p> <p>Differentiates the type of medication e.g. 
         * drug, vaccine</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public SubstanceAdministrationType Code {
            get { return (SubstanceAdministrationType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Rendered Dosage Instruction</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060190CA.AdministrationInstructions.text 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * prescriber to verify the structured dosage 
         * instruction.</p><p>Attribute is marked as 
         * &quot;mandatory&quot; as the rendition of the dosage 
         * instruction must always be made available to the 
         * prescriber.</p> <p>A textual rendition of structured (or 
         * non-structure) original dosage instruction specified by the 
         * prescriber.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

    }

}