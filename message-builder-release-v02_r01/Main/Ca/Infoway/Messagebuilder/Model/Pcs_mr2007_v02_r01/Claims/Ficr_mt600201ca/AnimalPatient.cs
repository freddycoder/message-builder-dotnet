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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Animal Patient</summary>
     * 
     * <p>Used when invoice is for animal patient.</p> <p>Animal 
     * Patient</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT600201CA.CoveredPartyAsPatientAnimal"})]
    public class AnimalPatient : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Claims.Ficr_mt600201ca.ICoveredPartyAsPatientChoice {

        private ST name;

        public AnimalPatient() {
            this.name = new STImpl();
        }
        /**
         * <summary>Business Name: Name of the animal</summary>
         * 
         * <remarks>Relationship: 
         * FICR_MT600201CA.CoveredPartyAsPatientAnimal.name 
         * Conformance/Cardinality: POPULATED (1) <p>Name of animal</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public String Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

    }

}