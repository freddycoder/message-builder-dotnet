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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Pome_mt010090ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: has characteristic</summary>
     * 
     * <p>Used to hold characteristic type and value pair as one 
     * set of query parameter item.</p> <p>Filters medications by 
     * their appearance.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POME_MT010090CA.DrugCharacteristics"})]
    public class HasCharacteristic : MessagePartBean {

        private ST drugCharacteristicValue;
        private CV drugCharacteristicTypeValue;

        public HasCharacteristic() {
            this.drugCharacteristicValue = new STImpl();
            this.drugCharacteristicTypeValue = new CVImpl();
        }
        /**
         * <summary>Business Name: G:Drug Characteristic</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010090CA.DrugCharacteristic.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides the 
         * 'value' part of the name-value pair describing the 
         * characteristic of drug product to be retrieved. 
         * Example:</p><p>type: color</p><p>value: blue</p><p>type: 
         * shape</p><p>value: rectangular</p><p>The attribute is 
         * mandatory because there's no point searching for a 
         * characteristic without specifying a value.</p> 
         * <p>Information pertaining to a specific instance of drug 
         * characteristic (color - red, shape - triangular, markings 
         * etc).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugCharacteristic/value"})]
        public String DrugCharacteristicValue {
            get { return this.drugCharacteristicValue.Value; }
            set { this.drugCharacteristicValue.Value = value; }
        }

        /**
         * <summary>Business Name: H:Drug Characteristic Type Code</summary>
         * 
         * <remarks>Relationship: 
         * POME_MT010090CA.DrugCharacteristicType.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows retrieval 
         * based on specific characteristic of a drug. The attribute is 
         * mandatory because there's no point searching for a 
         * characteristic without identifying what kind of 
         * characteristic is being searched by.</p> <p>A coded value 
         * denoting the type of physical characteristic of a drug. 
         * Characteristics include: Color, Shape, Markings, Size, 
         * etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"drugCharacteristicType/value"})]
        public MedicationObservationType DrugCharacteristicTypeValue {
            get { return (MedicationObservationType) this.drugCharacteristicTypeValue.Value; }
            set { this.drugCharacteristicTypeValue.Value = value; }
        }

    }

}