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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Domainvalue;


    /**
     * <summary>Business Name: ComponentObservations</summary>
     * 
     * <remarks>REPC_MT420003CA.SubObservationEvent: Component 
     * Observations <p>Not all observations can be expressed as a 
     * single code or code and value.</p> <p>Captures components of 
     * a more complex observation, such as apgar or blood 
     * pressure.</p> REPC_MT420001CA.SubObservationEvent: Component 
     * Observations <p>Not all observations can be expressed as a 
     * single code or code and value.</p> <p>Captures components of 
     * a more complex observation, such as apgar or blood 
     * pressure.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT420001CA.SubObservationEvent","REPC_MT420003CA.SubObservationEvent"})]
    public class ComponentObservations_2 : MessagePartBean {

        private CD code;
        private CD value;

        public ComponentObservations_2() {
            this.code = new CDImpl();
            this.value = new CDImpl();
        }
        /**
         * <summary>Business Name: ComponentObservationType</summary>
         * 
         * <remarks>Un-merged Business Name: ComponentObservationType 
         * Relationship: REPC_MT420001CA.SubObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes 
         * between multiple types of sub-observations that together 
         * make a single Observation.</p><p>Code is mandatory to ensure 
         * that sub-observations are distinguishable.</p><p> <i>This 
         * element makes use of the CD datatype to allow for use of the 
         * SNOMED code system that in some circumstances requires the 
         * use of post-coordination. Post-coordination is only 
         * supported by the CD datatype.</i> </p><p> <i>The element 
         * uses CWE to allow for the capture of Component Observation 
         * Type concepts not presently supported by the approved code 
         * system(s). In this case, the human-to-human benefit of 
         * capturing additional non-coded values outweighs the 
         * penalties of capturing some information that will not be 
         * amenable to searching or categorizing.</i> </p> <p>EPHS: 
         * need fixed value for 
         * &quot;COMPLICATIONS&quot;</p><p>EPHS:need fixed value for 
         * IMMUNIZATION VACCINE; VALID IMMUNIZATION DOSES 
         * RECEIVED;IMMUNIZATION DOSES NEEDED;ADDITIONAL 
         * COMPLICATION;CAUSE OF DEATH;OTHER COMPLICATION; RISK FACTOR 
         * CATEGORY;RISK FACTOR FREQUENCY; RISK FACTOR 
         * COMMENT;</p><p>EPHS: need fixed value for OUTBREAK 
         * COMPLICATION AGGREGATE COUNT; OUTBREAK SIGN AND SYMPTOM 
         * UNIDENTIFIED AGGREGATE COUNT</p> <p>Identifies the type of 
         * sub-observation being made.</p><p>APGAR skin color score, 
         * etc.</p> Un-merged Business Name: ComponentObservationType 
         * Relationship: REPC_MT420003CA.SubObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Distinguishes 
         * between multiple types of sub-observations that together 
         * make a single Observation.</p><p>Code is mandatory to ensure 
         * that sub-observations are distinguishable.</p><p> <i>This 
         * element makes use of the CD datatype to allow for use of the 
         * SNOMED code system that in some circumstances requires the 
         * use of post-coordination. Post-coordination is only 
         * supported by the CD datatype.</i> </p><p> <i>The element 
         * uses CWE to allow for the capture of Component Observation 
         * Type concepts not presently supported by the approved code 
         * system(s). In this case, the human-to-human benefit of 
         * capturing additional non-coded values outweighs the 
         * penalties of capturing some information that will not be 
         * amenable to searching or categorizing.</i> </p> <p>EPHS: 
         * need fixed value for 
         * &quot;COMPLICATIONS&quot;</p><p>EPHS:need fixed value for 
         * IMMUNIZATION VACCINE; VALID IMMUNIZATION DOSES 
         * RECEIVED;IMMUNIZATION DOSES NEEDED;ADDITIONAL 
         * COMPLICATION;CAUSE OF DEATH;OTHER COMPLICATION; RISK FACTOR 
         * CATEGORY;RISK FACTOR FREQUENCY; RISK FACTOR 
         * COMMENT;</p><p>EPHS: need fixed value for OUTBREAK 
         * COMPLICATION AGGREGATE COUNT; OUTBREAK SIGN AND SYMPTOM 
         * UNIDENTIFIED AGGREGATE COUNT</p> <p>Identifies the type of 
         * sub-observation being made.</p><p>APGAR skin color score, 
         * etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public CommonCodedClinicalObservationComponentType Code {
            get { return (CommonCodedClinicalObservationComponentType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ComponentObservationValue</summary>
         * 
         * <remarks>Un-merged Business Name: ComponentObservationValue 
         * Relationship: REPC_MT420001CA.SubObservationEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Depending on 
         * CommonCodedClinicalObservationSubType, one of 
         * CommonClinicalObservationResultValue or 
         * CommonClinicalObservationAssertionValue must implemented in 
         * place of CommonClinicalObservationSubValue</p> <p>PHS 
         * 07-feb-02. Some appropriate vocab concept is needed for 
         * observation.code, to pair with EPHS mappings.</p> <p>Conveys 
         * the clinical information resulting from the sub-observation 
         * in a standardized representation.</p><p>There's no point 
         * sending a sub-observation if no value is known. Therefore, 
         * the attribute is mandatory.</p> <p>EPHS: datatype needs to 
         * be constrained at runtime to CV, PQ or ST depending upon 
         * type of observation being reported. EPHS: vocab domains 
         * needed for CAUSE OF DEATH;VACCINE</p> <p>Indicates what was 
         * actually observed when the sub-observation was 
         * made.</p><p>E.g. score for skin color in an APGAR</p> 
         * Un-merged Business Name: ComponentObservationValue 
         * Relationship: REPC_MT420003CA.SubObservationEvent.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Depending on 
         * CommonCodedClinicalObservationSubType, one of 
         * CommonClinicalObservationResultValue or 
         * CommonClinicalObservationAssertionValue must be implemented 
         * in place of CommonClinicalObservationSubValue</p> <p>PHS 
         * 07-feb-02. Some appropriate vocab concept is needed for 
         * observation.code, to pair with EPHS mappings.</p> <p>Conveys 
         * the clinical information resulting from the sub-observation 
         * in a standardized representation.</p><p>There's no point 
         * sending a sub-observation if no value is known. Therefore, 
         * the attribute is mandatory.</p> <p>EPHS: datatype needs to 
         * be constrained at runtime to CV, PQ or ST depending upon 
         * type of observation being reported. EPHS: vocab domains 
         * needed for CAUSE OF DEATH;VACCINE</p> <p>Indicates what was 
         * actually observed when the sub-observation was 
         * made.</p><p>E.g. score for skin color in an APGAR</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public CommonCodedClinicalObservationComponentValue Value {
            get { return (CommonCodedClinicalObservationComponentValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}