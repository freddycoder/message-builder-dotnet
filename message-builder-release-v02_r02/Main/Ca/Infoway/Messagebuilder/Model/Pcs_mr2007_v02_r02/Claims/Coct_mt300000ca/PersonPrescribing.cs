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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Coct_mt300000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Person Prescribing</summary>
     * 
     * <p>Person Prescribing</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT300000CA.PrescriberPerson"})]
    public class PersonPrescribing : MessagePartBean {

        private PN name;
        private LIST<TEL, TelecommunicationAddress> telecom;

        public PersonPrescribing() {
            this.name = new PNImpl();
            this.telecom = new LISTImpl<TEL, TelecommunicationAddress>(typeof(TELImpl));
        }
        /**
         * <summary>Business Name: Prescriber Name</summary>
         * 
         * <remarks>Relationship: COCT_MT300000CA.PrescriberPerson.name 
         * Conformance/Cardinality: POPULATED (1) <p>Name of person 
         * prescribing</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public PersonName Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

        /**
         * <summary>Business Name: Prescriber Telephone Number</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT300000CA.PrescriberPerson.telecom 
         * Conformance/Cardinality: REQUIRED (0-3) <p>used for Coverage 
         * Extension to contact prescriber</p> <p>Telephone no. of the 
         * prescriber</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"telecom"})]
        public IList<TelecommunicationAddress> Telecom {
            get { return this.telecom.RawList(); }
        }

    }

}