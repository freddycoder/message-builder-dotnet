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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.AssignedEntity1","POME_MT010040CA.AssignedEntity2","POME_MT010040CA.AssignedEntity3","POME_MT010040CA.AssignedEntity4","PORR_MT050016CA.AssignedEntity","PORX_MT980010CA.AssignedEntity","PORX_MT980020CA.AssignedEntity","PORX_MT980030CA.AssignedEntity"})]
    public class AssignedEntity : MessagePartBean {

        private ST assignedOrganizationName;

        public AssignedEntity() {
            this.assignedOrganizationName = new STImpl();
        }
        /**
         * <summary>Un-merged Business Name: KnowledgebaseVendorName</summary>
         * 
         * <remarks>Relationship: PORX_MT980020CA.Organization.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows a 
         * knowledgebase vendor to be referenced by name.</p><p>The 
         * attribute is mandatory because it is the only information 
         * collected about a knowledgebase vendor.</p> <p>The name of a 
         * clinical knowledgebase vendor organization.</p> Un-merged 
         * Business Name: MedicationDocumentAuthorName Relationship: 
         * PORR_MT050016CA.Organization4.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Helps the receiver evaluate the supplied 
         * information.</p> <p>The name of the organization responsible 
         * for creating the medication document.</p> Un-merged Business 
         * Name: RecommendingAuthorityName Relationship: 
         * POME_MT010040CA.Organization4.name Conformance/Cardinality: 
         * MANDATORY (1) <p>The source of a recommendation may 
         * influence prescriber's willingness to use the recommended 
         * dose and is therefore mandatory</p> <p>Indicates the name of 
         * the organization or agency that created the dosage 
         * recommendation</p> Un-merged Business Name: 
         * FormularyOwnerName Relationship: 
         * POME_MT010040CA.Organization3.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Helps identify the circumstances in which 
         * the formulary applies.</p> <p>The name of the organization 
         * or facility responsible for the formulary.</p> Un-merged 
         * Business Name: KnowledgebaseVendorName Relationship: 
         * PORX_MT980010CA.Organization.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows a knowledgebase vendor to be 
         * referenced by name.</p><p>The attribute is mandatory because 
         * it is the only information collected about a knowledgebase 
         * vendor.</p> <p>The name of a clinical knowledgebase vendor 
         * organization.</p> Un-merged Business Name: 
         * MonitoringOrganizationName Relationship: 
         * POME_MT010040CA.Organization2.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Helps identify the program and understand 
         * its context. May also indicate who to send reports to.</p> 
         * <p>The name of the organization responsible for the 
         * monitoring program</p> Un-merged Business Name: 
         * MonographAuthorName Relationship: 
         * POME_MT010040CA.Organization1.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Helps the receiver evaluate the supplied 
         * information.</p> <p>The name of the organization responsible 
         * for creating the monograph</p> Un-merged Business Name: 
         * KnowledgebaseVendorName Relationship: 
         * PORX_MT980030CA.Organization.name Conformance/Cardinality: 
         * MANDATORY (1) <p>Allows a knowledgebase vendor to be 
         * referenced by name.</p><p>The attribute is mandatory because 
         * it is the only information collected about a knowledgebase 
         * vendor.</p> <p>The name of a clinical knowledgebase vendor 
         * organization.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedOrganization/name","representedOrganization/name"})]
        [Hl7MapByPartType(Name="assignedOrganization", Type="POME_MT010040CA.Organization1")]
        [Hl7MapByPartType(Name="assignedOrganization", Type="POME_MT010040CA.Organization2")]
        [Hl7MapByPartType(Name="assignedOrganization", Type="POME_MT010040CA.Organization3")]
        [Hl7MapByPartType(Name="assignedOrganization", Type="POME_MT010040CA.Organization4")]
        [Hl7MapByPartType(Name="assignedOrganization", Type="PORX_MT980010CA.Organization")]
        [Hl7MapByPartType(Name="assignedOrganization", Type="PORX_MT980020CA.Organization")]
        [Hl7MapByPartType(Name="assignedOrganization", Type="PORX_MT980030CA.Organization")]
        [Hl7MapByPartType(Name="representedOrganization", Type="PORR_MT050016CA.Organization4")]
        public String AssignedOrganizationName {
            get { return this.assignedOrganizationName.Value; }
            set { this.assignedOrganizationName.Value = value; }
        }

    }

}