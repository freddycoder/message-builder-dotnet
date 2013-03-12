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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Common.Coct_mt090310ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: EHR Repository</summary>
     * 
     * <p>Provides context about the record and its management.</p> 
     * <p>Identification of the EHR infostructure responsible for 
     * the storage and management of the record</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT090310CA.AssignedDevice"})]
    public class EHRRepository : MessagePartBean {

        private ST assignedRepositoryLocationName;
        private TEL assignedRepositoryLocationTelecom;
        private ST representedRepositoryJurisdictionName;

        public EHRRepository() {
            this.assignedRepositoryLocationName = new STImpl();
            this.assignedRepositoryLocationTelecom = new TELImpl();
            this.representedRepositoryJurisdictionName = new STImpl();
        }
        /**
         * <summary>Business Name: Repository Name</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT090310CA.RepositoryLocation.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides a 
         * human-readable name for the repository and is therefore 
         * mandatory</p> <p>The name of the repository which is 
         * responsible for maintaining the record. E.g. &quot;Ontario 
         * Health Respository #3&quot;</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedRepositoryLocation/name"})]
        public String AssignedRepositoryLocationName {
            get { return this.assignedRepositoryLocationName.Value; }
            set { this.assignedRepositoryLocationName.Value = value; }
        }

        /**
         * <summary>Business Name: Repository URL</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT090310CA.RepositoryLocation.telecom 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows direct 
         * access to the repository and is therefore mandatory.</p> 
         * <p>Identification of the electronic address for reaching the 
         * repository where the event is stored.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedRepositoryLocation/telecom"})]
        public TelecommunicationAddress AssignedRepositoryLocationTelecom {
            get { return this.assignedRepositoryLocationTelecom.Value; }
            set { this.assignedRepositoryLocationTelecom.Value = value; }
        }

        /**
         * <summary>Business Name: Repository Jurisdiction Name</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT090310CA.RepositoryJurisdiction.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Establishes 
         * business context for determining custodianship, and is 
         * therefore mandatory.</p> <p>The name of the jurisdiction 
         * that is responsible for the EHR infostructure that contains 
         * and manages the record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedRepositoryJurisdiction/name"})]
        public String RepresentedRepositoryJurisdictionName {
            get { return this.representedRepositoryJurisdictionName.Value; }
            set { this.representedRepositoryJurisdictionName.Value = value; }
        }

    }

}