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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt090108ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Healthcare Worker</summary>
     * 
     * <p>Critical to tracking responsibility and performing 
     * follow-up. The CMET supports both licensed providers as well 
     * as non-licensed providers such as technicians, 
     * receptionists, etc.</p> <p>All attributes other than the 
     * various identifiers are expected to be retrieved from the 
     * provider registry.</p> <p>The person organization assigned 
     * to carry out the associated (linked by a participation) 
     * action and/or the organization under whose authority they 
     * are acting.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT090108CA.AssignedEntity"})]
    public class HealthcareWorker : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt911107ca.IActingPerson, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt911108ca.IActingPerson {

        private LIST<II, Identifier> id;
        private CV code;
        private LIST<TEL, TelecommunicationAddress> telecom;
        private PN assignedPersonName;
        private II assignedPersonAsHealthCareProviderId;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged.ResponsibleOrganization representedOrganization;

        public HealthcareWorker() {
            this.id = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.code = new CVImpl();
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
            this.assignedPersonName = new PNImpl();
            this.assignedPersonAsHealthCareProviderId = new IIImpl();
        }
        /**
         * <summary>Business Name: A:Healthcare Worker Identifier</summary>
         * 
         * <remarks>Relationship: COCT_MT090108CA.AssignedEntity.id 
         * Conformance/Cardinality: MANDATORY (*) <p>Allows unique 
         * identification of the person which can be critical for 
         * authentication, permissions, drill-down and traceability and 
         * is therefore mandatory.</p> <p>Unique identifier the person 
         * involved in the action.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public IList<Identifier> Id {
            get { return this.id.RawList(); }
        }

        /**
         * <summary>Business Name: B: Healthcare Worker Type</summary>
         * 
         * <remarks>Relationship: COCT_MT090108CA.AssignedEntity.code 
         * Conformance/Cardinality: REQUIRED (1) <p>Provides context 
         * around the actions of the participant and is therefore 
         * mandatory.</p> <p>Indicates the &quot;kind&quot; of 
         * healthcare participant, such as &quot;physician&quot;, 
         * &quot;dentist&quot;, &quot;lab technician&quot;, 
         * &quot;receptionist&quot;, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public AssignedRoleType Code {
            get { return (AssignedRoleType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: E: Healthcare Worker Phone and 
         * Emails</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT090108CA.AssignedEntity.telecom 
         * Conformance/Cardinality: REQUIRED (0-5) <p>This is the most 
         * commonly used piece of contact information and is returned 
         * here to avoid unnecessary queries of the provider 
         * registry.</p> <p>Indicates phone and/or e-mail addresses at 
         * which the healthcare worker can be reached.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

        /**
         * <summary>Business Name: C: Healthcare Worker Name</summary>
         * 
         * <remarks>Relationship: COCT_MT090108CA.Person.name 
         * Conformance/Cardinality: REQUIRED (1) <p>This is a 
         * human-readable name and is thus essential for both display 
         * and validation of the person. As a result, the attribute is 
         * mandatory.</p> <p>The name of the participating person.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPerson/name"})]
        public PersonName AssignedPersonName {
            get { return this.assignedPersonName.Value; }
            set { this.assignedPersonName.Value = value; }
        }

        /**
         * <summary>Business Name: D: License Number</summary>
         * 
         * <remarks>Relationship: COCT_MT090108CA.HealthCareProvider.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows lookup on 
         * college website, confirmation of identity, etc. Regulations 
         * occasionally require license numbers to be specified as part 
         * of clinical records.</p> <p>If the identifier used in the 
         * root of the CMET is the same as the license number, the 
         * license number should be sent in both places.</p><p>Detailed 
         * information about the status and effective period of 
         * licenses must be retrieved from the provider registry.</p> 
         * <p>The license number issued to the provider and relevant to 
         * the current action.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedPerson/asHealthCareProvider/id"})]
        public Identifier AssignedPersonAsHealthCareProviderId {
            get { return this.assignedPersonAsHealthCareProviderId.Value; }
            set { this.assignedPersonAsHealthCareProviderId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT090108CA.AssignedEntity.representedOrganization</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"representedOrganization"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged.ResponsibleOrganization RepresentedOrganization {
            get { return this.representedOrganization; }
            set { this.representedOrganization = value; }
        }

    }

}