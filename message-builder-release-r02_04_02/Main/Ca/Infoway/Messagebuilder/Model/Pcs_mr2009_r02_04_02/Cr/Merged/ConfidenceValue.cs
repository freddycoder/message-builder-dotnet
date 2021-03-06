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
 * Author:        $LastChangedBy: jmis $
 * Last modified: $LastChangedDate: 2015-09-15 11:09:53 -0400 (Tue, 15 Sep 2015) $
 * Revision:      $LastChangedRevision: 9796 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: ConfidenceValue</summary>
     * 
     * <remarks>PRPA_MT101106CA.ObservationEvent: Confidence Value 
     * <p>Supports the business requirement to provide a confidence 
     * value associated with the identifiedEntity returned in the 
     * responsedistinguishes these different representations.</p> 
     * <p>Each returned IdentifiedPerson can have an associated 
     * ObservationEvent reporting the confidence value (degree of 
     * certainty) and the name of the matching algorithm that 
     * resulted in that record's inclusion in the result set.</p> 
     * PRPA_MT101102CA.ObservationEvent: Confidence Value 
     * <p>Supports the business requirement to provide a confidence 
     * value associated with the identifiedEntity returned in the 
     * response distinguishes these different representations.</p> 
     * <p>Each returned IdentifiedPerson can have an associated 
     * ObservationEvent reporting the confidence value (degree of 
     * certainty) and the name of the matching algorithm that 
     * resulted in that record's inclusion in the result set.</p> 
     * PRPA_MT101104CA.ObservationEvent: Confidence Value 
     * <p>Supports the business requirement to provide a confidence 
     * value associated with the identifiedEntity returned in the 
     * responsedistinguishes these different representations.</p> 
     * <p>Each returned IdentifiedPerson can have an associated 
     * ObservationEvent reporting the confidence value (degree of 
     * certainty) and the name of the matching algorithm that 
     * resulted in that record's inclusion in the result set.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101102CA.ObservationEvent","PRPA_MT101104CA.ObservationEvent","PRPA_MT101106CA.ObservationEvent"})]
    public class ConfidenceValue : MessagePartBean {

        private CV code;
        private REAL value;

        public ConfidenceValue() {
            this.code = new CVImpl();
            this.value = new REALImpl();
        }
        /**
         * <summary>Business Name: ProbabilityMatchCode</summary>
         * 
         * <remarks>Un-merged Business Name: ProbabilityMatchCode 
         * Relationship: PRPA_MT101106CA.ObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports confident identification of intended 
         * client</p> <p>Supports the business requirement to identify 
         * type of confidence matching used i.e. the code would be the 
         * name for the algorithm for the confidence value</p> 
         * Un-merged Business Name: ProbabilityMatchCode Relationship: 
         * PRPA_MT101102CA.ObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports confident identification of intended 
         * client</p> <p>Supports the business requirement to identify 
         * type of confidence matching used i.e. the code would be the 
         * name for the algorithm for the confidence value</p> 
         * Un-merged Business Name: ProbabilityMatchCode Relationship: 
         * PRPA_MT101104CA.ObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Mandatory 
         * attribute supports confident identification of intended 
         * client</p> <p>Supports the business requirement to identify 
         * type of confidence matching used i.e. the code would be the 
         * name for the algorithm for the confidence value</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationQueryMatchType Code {
            get { return (ObservationQueryMatchType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ConfidenceValue</summary>
         * 
         * <remarks>Un-merged Business Name: ConfidenceValue 
         * Relationship: PRPA_MT101106CA.ObservationEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute to provide information about success of query</p> 
         * <p>A real number value indicating the confidence of the 
         * query with regard to finding the intended target client i.e. 
         * the value would be the computed confidence value.</p> 
         * Un-merged Business Name: ConfidenceValue Relationship: 
         * PRPA_MT101102CA.ObservationEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute to provide information about success of query</p> 
         * <p>A real number value indicating the confidence of the 
         * query with regard to finding the intended target client i.e. 
         * the value would be the computed confidence value.</p> 
         * Un-merged Business Name: ConfidenceValue Relationship: 
         * PRPA_MT101104CA.ObservationEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute to provide information about success of query</p> 
         * <p>A real number value indicating the confidence of the 
         * query with regard to finding the intended target client i.e. 
         * the value would be the computed confidence value.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public BigDecimal Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}