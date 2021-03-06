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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_4.Common.Coct_mt050202ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Patient</summary>
     * 
     * <p>Information used to identify the patient and to support 
     * clinical decisions. This information applies to the person 
     * in the context of the associated action only, and should be 
     * stored separately. I.e. the address/phone/email only apply 
     * to the current prescription/dispense/lab order etc.</p> <p>A 
     * person who is receiving or may receive healthcare services 
     * and has personal attributes (e.g. name, birth date). .</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT050202CA.Patient"})]
    public class Patient : MessagePartBean {

        private II id;
        private PN patientPersonName;
        private CV patientPersonAdministrativeGenderCode;
        private TS patientPersonBirthTime;

        public Patient() {
            this.id = new IIImpl();
            this.patientPersonName = new PNImpl();
            this.patientPersonAdministrativeGenderCode = new CVImpl();
            this.patientPersonBirthTime = new TSImpl();
        }
        /**
         * <summary>Business Name: A:Patient ID</summary>
         * 
         * <remarks>Relationship: COCT_MT050202CA.Patient.id 
         * Conformance/Cardinality: MANDATORY (1) <p>C39 
         * (Extension)</p> <p>PTT.050.01 (Extension)</p> <p>PTT.050.02 
         * (Root)</p> <p>A.1</p> <p>PID.2</p> <p>Patient.332-CY 
         * (Extension)</p> <p>Patient.331-CX (Root)</p> 
         * <p>Claim.330-CW</p> <p>Health Card Number</p> <p>PID.2</p> 
         * <p>PID.4</p> <p>ZDU.2</p> <p>ZKW.3</p> <p>Jurisdiction 
         * (Root)</p> <p>Person.PHN (Extension)</p> <p>Allows a patient 
         * to be referred to unambiguously. Because this is the 
         * principal mechanism for identifying humans, the attribute is 
         * mandatory. If an identifier is not known, it should be 
         * looked up using the 'client registry' capabilities of the 
         * EHR application.</p> <p>Unique identifier assigned to a 
         * person by Federal, Provincial and Territorial jurisdiction 
         * for the purposes of uniquely identifying the person within 
         * the EHR.</p><p>The EHR will define which identifier to use 
         * within a jurisdiction.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: B:Patient Name</summary>
         * 
         * <remarks>Relationship: COCT_MT050202CA.Person.name 
         * Conformance/Cardinality: MANDATORY (1) <p>ZPA.1 
         * (partType=Given)</p> <p>ZPA.2 (partType=Family)</p> <p>ZPA.3 
         * (partType=Given - all repetitions except first)</p> <p>C37 
         * (partType=Given)</p> <p>C38 (partType=Family)</p> 
         * <p>PTT.030-01 (partType=Family)</p> <p>PTT.030-02 
         * (partType=Given - 1st occurrence)</p> <p>PTT.030-03 
         * (partType=Given - subsequen occurrences)</p> <p>PTT.030-04 
         * (partType=Suffix)</p> <p>PTT.030-05 (partType=Prefix)</p> 
         * <p>patient Initials</p> <p>PID.5</p> <p>Patient.310-CA 
         * (partType=Given)</p> <p>Patient.311-CB (partType=Family)</p> 
         * <p>Recipient Name First (partType=Given)</p> <p>Recipient 
         * Name Last (partType=Family)</p> <p>PID.5</p> <p>PID.9 (any 
         * name other than first repetition is an alias)</p> 
         * <p>ZDU.3</p> <p>ZKW.2</p> <p>Person.givenName</p> 
         * <p>Person.lastName</p> <p>Person.middleName</p> 
         * <p>Person.namePrefix</p> <p>Person.nameSuffix</p> <p>Used, 
         * with other patient identity attributes, to confirm patient 
         * identity, as well as when addressing the patient. Element is 
         * mandatory because the patient's name is necessary for 
         * positive identification of the patient in the jurisdictional 
         * client registry.</p> <p>The name by which the patient is 
         * known and which apply to a particular clinical action that 
         * has been reported or recorded.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientPerson/name"})]
        public PersonName PatientPersonName {
            get { return this.patientPersonName.Value; }
            set { this.patientPersonName.Value = value; }
        }

        /**
         * <summary>Business Name: F:Patient Gender</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT050202CA.Person.administrativeGenderCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to confirm 
         * patient identity. May affect dosing or therapy 
         * appropriateness.</p><p>Element is mandatory because the 
         * patient's gender is necessary for positive identification of 
         * the patient in the jurisdictional client registry.</p> 
         * <p>Indicates the gender (sex) of the patient. Complex 
         * genetic genders are handled as observations if they are 
         * considered relevant.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientPerson/administrativeGenderCode"})]
        public AdministrativeGender PatientPersonAdministrativeGenderCode {
            get { return (AdministrativeGender) this.patientPersonAdministrativeGenderCode.Value; }
            set { this.patientPersonAdministrativeGenderCode.Value = value; }
        }

        /**
         * <summary>Business Name: E:Patient Birth Date</summary>
         * 
         * <remarks>Relationship: COCT_MT050202CA.Person.birthTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Used to confirm 
         * patient identity.</p><p>May also influence dosage and 
         * therapy appropriateness.</p><p>Element is mandatory because 
         * the patient's birth date is necessary for positive 
         * identification of the patient in the jurisdictional client 
         * registry.</p> <p>Indicates the date on which the patient was 
         * born.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"patientPerson/birthTime"})]
        public PlatformDate PatientPersonBirthTime {
            get { return this.patientPersonBirthTime.Value; }
            set { this.patientPersonBirthTime.Value = value; }
        }

    }

}