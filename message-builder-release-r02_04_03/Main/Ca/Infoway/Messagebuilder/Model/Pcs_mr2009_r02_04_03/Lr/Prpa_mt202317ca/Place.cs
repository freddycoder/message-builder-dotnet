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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lr.Prpa_mt202317ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT202317CA.Place"})]
    public class Place : MessagePartBean {

        private CV code;
        private BL mobileInd;

        public Place() {
            this.code = new CVImpl();
            this.mobileInd = new BLImpl();
        }
        /**
         * <summary>Business Name: E:Location Place Type</summary>
         * 
         * <remarks>Relationship: PRPA_MT202317CA.Place.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Used for 
         * searching, as well as for understanding what is meant by a 
         * particular location and is therefore mandatory.</p> 
         * <p>Distinguishes different levels of location granularity. 
         * E.g. Campus, building, floor, ward, room, bed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ServiceDeliveryLocationPlaceType Code {
            get { return (ServiceDeliveryLocationPlaceType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: F:Location Mobile Indicator</summary>
         * 
         * <remarks>Relationship: PRPA_MT202317CA.Place.mobileInd 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows flagging 
         * that the location does not have a fixed physical 
         * location.</p><p>This element must always be known and is 
         * therefore mandatory.</p> <p>An indication of whether a place 
         * has the capability to move from one location to another. 
         * Example: air and ground ambulances, mobile clinics.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"mobileInd"})]
        public bool? MobileInd {
            get { return this.mobileInd.Value; }
            set { this.mobileInd.Value = value; }
        }

    }

}