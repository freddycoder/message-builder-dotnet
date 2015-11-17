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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Cr.Prpa_mt101003ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Identified Person</summary>
     * 
     * <p>Provides the message entry point required to add a person 
     * to the Client Registry</p> <p>The IdentifiedEntity class is 
     * the entry point to the R-MIM and contains one or more 
     * identifiers (for example an &quot;internal&quot; id used 
     * only by computer systems and an &quot;external&quot; id for 
     * display to users) for the Person in the Client Registry. The 
     * statusCode is set to &quot;active&quot;. The beginning of 
     * the effectiveTime is when the record was added to the 
     * registry.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101003CA.IdentifiedEntity"})]
    public class IdentifiedPerson : MessagePartBean {

        private II id;
        private LIST<PN, PersonName> identifiedPersonName;
        private CV identifiedPersonAdministrativeGenderCode;
        private TS identifiedPersonBirthTime;

        public IdentifiedPerson() {
            this.id = new IIImpl();
            this.identifiedPersonName = new LISTImpl<PN, PersonName>(typeof(PNImpl));
            this.identifiedPersonAdministrativeGenderCode = new CVImpl();
            this.identifiedPersonBirthTime = new TSImpl();
        }
        /**
         * <summary>Business Name: Client Healthcare Identification 
         * Number</summary>
         * 
         * <remarks>Relationship: PRPA_MT101003CA.IdentifiedEntity.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports unique identification of the client.</p> 
         * <p>This identification attribute supports capture of a 
         * healthcare identifier specific to the client. This 
         * identifier may be assigned jurisdictionally or by care 
         * facility.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Client Name</summary>
         * 
         * <remarks>Relationship: PRPA_MT101003CA.Person.name 
         * Conformance/Cardinality: REQUIRED (1-20) <p>Populated 
         * attribute supports the identification of the client</p> 
         * <p>Name(s) for the Client</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/name"})]
        public IList<PersonName> IdentifiedPersonName {
            get { return this.identifiedPersonName.RawList(); }
        }

        /**
         * <summary>Business Name: Client Gender</summary>
         * 
         * <remarks>Relationship: 
         * PRPA_MT101003CA.Person.administrativeGenderCode 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the identification of the client</p> <p>Gender of 
         * the Client, this is not to be confused with Clinical Gender 
         * of a client. Administrative Gender is typically restricted 
         * to Male (M), Female (F) or Unknown (UN)</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/administrativeGenderCode"})]
        public AdministrativeGender IdentifiedPersonAdministrativeGenderCode {
            get { return (AdministrativeGender) this.identifiedPersonAdministrativeGenderCode.Value; }
            set { this.identifiedPersonAdministrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Business Name: Client Date of Birth</summary>
         * 
         * <remarks>Relationship: PRPA_MT101003CA.Person.birthTime 
         * Conformance/Cardinality: REQUIRED (1) <p>Populated attribute 
         * supports the identification of the client</p> <p>Date of 
         * birth of the Client</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"identifiedPerson/birthTime"})]
        public PlatformDate IdentifiedPersonBirthTime {
            get { return this.identifiedPersonBirthTime.Value; }
            set { this.identifiedPersonBirthTime.Value = value; }
        }

    }

}