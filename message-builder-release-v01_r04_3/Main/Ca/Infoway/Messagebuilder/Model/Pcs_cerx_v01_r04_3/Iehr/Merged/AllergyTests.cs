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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: AllergyTests</summary>
     * 
     * <remarks>REPC_MT000005CA.AllergyTestEvent: Allergy Tests 
     * <p>Value is mandatory if not using SNOMED</p> <p>Provides 
     * evidence for recording the allergy/intolerance.</p> 
     * <p>Indicates the specific allergy test that supports the 
     * recording of the allergy/intolerance.</p> 
     * REPC_MT000001CA.AllergyTestEvent: Allergy Tests <p>Value is 
     * required if not using SNOMED</p> <p>At least one of Id or 
     * Value must be specified.</p> <p>Provides evidence for 
     * recording the allergy/intolerance.</p> <p>Indicates the 
     * specific allergy test that supports the recording of the 
     * allergy/intolerance.</p> REPC_MT000013CA.AllergyTestEvent: 
     * Allergy Tests <p>If code is SNOMED, value is not permitted, 
     * otherwise it is mandatory.</p> <p>Provides evidence for 
     * recording the allergy/intolerance.</p> <p>Indicates the 
     * specific allergy test that supports the recording of the 
     * allergy/intolerance.</p> REPC_MT000009CA.AllergyTestEvent: 
     * Allergy Tests <p>Value must not be present when using 
     * SNOMED, mandatory otherwise</p> <p>Provides evidence for 
     * recording the allergy/intolerance.</p> <p>Indicates the 
     * specific allergy test that supports the recording of the 
     * allergy/intolerance.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000001CA.AllergyTestEvent","REPC_MT000005CA.AllergyTestEvent","REPC_MT000009CA.AllergyTestEvent","REPC_MT000013CA.AllergyTestEvent"})]
    public class AllergyTests : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Pcs_cerx_v01_r04_3.Iehr.Merged.IRecords {

        private II id;
        private CD code;
        private TS effectiveTime;
        private CV value;

        public AllergyTests() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.effectiveTime = new TSImpl();
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: AllergyTestRecordId</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyTestRecordId 
         * Relationship: REPC_MT000005CA.AllergyTestEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows an 
         * allergy/intolerance test record to be directly 
         * referenced.</p> <p>An identifier for a specific instance of 
         * an allergy/intolerance test.</p> Un-merged Business Name: 
         * AllergyTestRecordId Relationship: 
         * REPC_MT000001CA.AllergyTestEvent.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows an allergy/intolerance test record 
         * to be directly referenced.</p> <p>An identifier for a 
         * specific instance of an allergy/intolerance test.</p> 
         * Un-merged Business Name: AllergyTestRecordId Relationship: 
         * REPC_MT000013CA.AllergyTestEvent.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows an allergy/intolerance test record 
         * to be directly referenced.</p> <p>An identifier for a 
         * specific instance of an allergy/intolerance test.</p> 
         * Un-merged Business Name: AllergyTestRecordId Relationship: 
         * REPC_MT000009CA.AllergyTestEvent.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows an allergy/intolerance test record 
         * to be directly referenced.</p> <p>An identifier for a 
         * specific instance of an allergy/intolerance test.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyTestType</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyTestType 
         * Relationship: REPC_MT000005CA.AllergyTestEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows different 
         * kinds of allergy/intolerance tests to be distinguishable and 
         * is therefore mandatory. It uses the CD type to support 
         * SNOMED post-coordination.</p> <p>A coded value denoting the 
         * type of allergy test conducted.</p> Un-merged Business Name: 
         * AllergyTestType Relationship: 
         * REPC_MT000001CA.AllergyTestEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows different 
         * kinds of allergy/intolerance tests to be distinguishable and 
         * is therefore mandatory. It uses the CD type to support 
         * SNOMED post-coordination.</p> <p>A coded value denoting the 
         * type of allergy test conducted.</p> Un-merged Business Name: 
         * AllergyTestType Relationship: 
         * REPC_MT000013CA.AllergyTestEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows different 
         * kinds of allergy/intolerance tests to be distinguishable and 
         * is therefore mandatory. It uses the CD type to support 
         * SNOMED post-coordination.</p> <p>A coded value denoting the 
         * type of allergy test conducted.</p> Un-merged Business Name: 
         * AllergyTestType Relationship: 
         * REPC_MT000009CA.AllergyTestEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows different 
         * kinds of allergy/intolerance tests to be distinguishable and 
         * is therefore mandatory. It uses the CD type to support 
         * SNOMED post-coordination.</p> <p>A coded value denoting the 
         * type of allergy test conducted.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationAllergyTestType Code {
            get { return (ObservationAllergyTestType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyTestDate</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyTestDate 
         * Relationship: REPC_MT000005CA.AllergyTestEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the currency of the test.</p> <p>The date on 
         * which the allergy test was performed.</p> Un-merged Business 
         * Name: AllergyTestDate Relationship: 
         * REPC_MT000001CA.AllergyTestEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the currency of the test.</p> <p>The date on 
         * which the allergy test was performed.</p> Un-merged Business 
         * Name: AllergyTestDate Relationship: 
         * REPC_MT000013CA.AllergyTestEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the currency of the test.</p> <p>The date on 
         * which the allergy test was performed.</p> Un-merged Business 
         * Name: AllergyTestDate Relationship: 
         * REPC_MT000009CA.AllergyTestEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows providers 
         * to evaluate the currency of the test.</p> <p>The date on 
         * which the allergy test was performed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: AllergyTestResult</summary>
         * 
         * <remarks>Un-merged Business Name: AllergyTestResult 
         * Relationship: REPC_MT000005CA.AllergyTestEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows other 
         * providers to evaluate the test. There is no point in 
         * associating an allergy test with unknown results with an 
         * allergy or intolerance however the element is optional 
         * because this information may be post-coordinated in the 
         * 'code' attribute using SNOMED.</p> <p>A code indicating 
         * result of the allergy test.</p> Un-merged Business Name: 
         * AllergyTestResult Relationship: 
         * REPC_MT000001CA.AllergyTestEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows other 
         * providers to evaluate the test. There is no point in 
         * associating an allergy test with unknown results with an 
         * allergy or intolerance however the element is optional 
         * because this information may be post-coordinated in the 
         * 'code' attribute using SNOMED.</p> <p>A code indicating 
         * result of the allergy test.</p> Un-merged Business Name: 
         * AllergyTestResult Relationship: 
         * REPC_MT000013CA.AllergyTestEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows other 
         * providers to evaluate the test. There is no point in 
         * associating an allergy test with unknown results with an 
         * allergy or intolerance however the element is optional 
         * because this information may be post-coordinated in the 
         * 'code' attribute using SNOMED.</p> <p>A code indicating 
         * result of the allergy test.</p> Un-merged Business Name: 
         * AllergyTestResult Relationship: 
         * REPC_MT000009CA.AllergyTestEvent.value 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows other 
         * providers to evaluate the test. There is no point in 
         * associating an allergy test with unknown results with an 
         * allergy or intolerance however the element is optional 
         * because this information may be post-coordinated in the 
         * 'code' attribute using SNOMED.</p> <p>A code indicating 
         * result of the allergy test.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public AllergyTestValue Value {
            get { return (AllergyTestValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}