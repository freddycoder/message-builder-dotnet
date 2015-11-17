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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Coct_mt050201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Patient</summary>
     * 
     * <p>Used when patienty identity confirmation is handled as a 
     * distinct business process rather than as part of each 
     * transaction. Allows transactions to be linked to a specific 
     * patient.</p> <p>A person who is receiving or may receive 
     * healthcare services and has had their identity previously 
     * confirmed</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT050201CA.Patient"})]
    public class Patient : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged.IPatient {

        private SET<II, Identifier> id;

        public Patient() {
            this.id = new SETImpl<II, Identifier>(typeof(IIImpl));
        }
        /**
         * <summary>Business Name: A:Patient Identifier</summary>
         * 
         * <remarks>Relationship: COCT_MT050201CA.Patient.id 
         * Conformance/Cardinality: MANDATORY (1-3) <p>C39 
         * (Extension)</p> <p>PTT.050.01 (Extension)</p> <p>PTT.050.02 
         * (Root)</p> <p>A.1</p> <p>PID.2</p> <p>Patient.332-CY 
         * (Extension)</p> <p>Patient.331-CX (Root)</p> 
         * <p>Claim.330-CW</p> <p>Health Card Number</p> <p>PID.2</p> 
         * <p>PID.4</p> <p>ZDU.2</p> <p>ZKW.3</p> <p>Jurisdiction 
         * (Root)</p> <p>Person.PHN (Extension)</p> <p>Allows a patient 
         * to be referred to unambiguously. Because this is the 
         * principal mechanism for identifying patients to electronic 
         * systems, the attribute is mandatory. The cardinality of 
         * patient identifiers is up to 3 based on the use case to 
         * support communication of a local and jurisdictional 
         * identifier along with the national identifier.</p> <p>Unique 
         * identifier issued as part of the patient identity 
         * verification process.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public ICollection<Identifier> Id {
            get { return this.id.RawSet(); }
        }

    }

}