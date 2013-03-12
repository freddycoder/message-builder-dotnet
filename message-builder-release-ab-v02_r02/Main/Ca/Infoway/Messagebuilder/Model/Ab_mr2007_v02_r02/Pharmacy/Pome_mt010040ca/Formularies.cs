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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Pome_mt010040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged;
    using System;


    /**
     * <summary>Business Name: Formularies</summary>
     * 
     * <p>At least One of Id or Title must be specified</p> <p>List 
     * of drugs available from (or carried by) a particular 
     * organization. For example, University Hospital formulary, 
     * East Side Long Term Care formulary, Alberta Blue Cross 
     * formulary</p> <p>Used to ascertain/ensure what drugs can be 
     * prescribed/dispensed within a specific jurisdiction or which 
     * will be covered by a patient's insurance.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.PotentialSupply"})]
    public class Formularies : MessagePartBean {

        private II id;
        private ST title;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.AssignedEntity3 performerAssignedEntity;

        public Formularies() {
            this.id = new IIImpl();
            this.title = new STImpl();
        }
        /**
         * <summary>Business Name: Formulary Id</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.PotentialSupply.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A unique 
         * identifier for a specific formulary.</p> <p>Allows the 
         * formulary to be unambiguously referenced</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Formulary Name</summary>
         * 
         * <remarks>Relationship: POME_MT010040CA.PotentialSupply.title 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The name by which 
         * the formulary is commonly known.</p> <p>Gives a 
         * provider-recognizable label for the formulary.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"title"})]
        public String Title {
            get { return this.title.Value; }
            set { this.title.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POME_MT010040CA.Performer.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Merged.AssignedEntity3 PerformerAssignedEntity {
            get { return this.performerAssignedEntity; }
            set { this.performerAssignedEntity = value; }
        }

    }

}