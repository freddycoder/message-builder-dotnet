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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Pome_mt010040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Merged;
    using System;


    /**
     * <summary>Business Name: Monitoring Programs</summary>
     * 
     * <p>Allows association of additional business requirements 
     * with a particular drug</p> <p>A system of additional 
     * business rules, documentation or reporting associated with a 
     * particular drug or group of drugs. These are typically 
     * instituted to detect potential abuse, or to monitor 
     * prescribing and/or dispensing patterns of a sensitive class 
     * of medications. Examples include triplicate programs, 
     * antibiotic monitoring programs, etc.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010040CA.MonitoringProgram"})]
    public class MonitoringPrograms : MessagePartBean {

        private CV code;
        private ST title;
        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Merged.AssignedEntity3 custodianAssignedEntity;

        public MonitoringPrograms() {
            this.code = new CVImpl();
            this.title = new STImpl();
        }
        /**
         * <summary>Business Name: Program Type</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010040CA.MonitoringProgram.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Used for 
         * classifying and sorting monitoring programs.</p><p>This is 
         * mandatory because, different program types have different 
         * business rules.</p> <p>A coded value denoting a specific 
         * kind of monitoring program. For example, &quot;Drugs of 
         * potential abuse&quot;, &quot;Antibiotics&quot;, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActMonitoringProtocolCode Code {
            get { return (ActMonitoringProtocolCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Program Name</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010040CA.MonitoringProgram.title 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Provides a 
         * provider-recognizable label for the program.</p> <p>A 
         * user-friendly label assigned to the monitoring program.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"title"})]
        public String Title {
            get { return this.title.Value; }
            set { this.title.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POME_MT010040CA.Custodian.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"custodian/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pharmacy.Merged.AssignedEntity3 CustodianAssignedEntity {
            get { return this.custodianAssignedEntity; }
            set { this.custodianAssignedEntity = value; }
        }

    }

}