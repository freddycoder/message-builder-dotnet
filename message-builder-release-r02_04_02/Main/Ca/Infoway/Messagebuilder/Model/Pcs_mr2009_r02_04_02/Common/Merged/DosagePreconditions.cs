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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: DosagePreconditions</summary>
     * 
     * <remarks>COCT_MT260030CA.ObservationEventCriterion: Dosage 
     * Preconditions <p>Allows recommended dosage instructions to 
     * be bound to a particular characteristic of the patient.</p> 
     * <p>A condition that must be true for the patient in order 
     * for the specified recommended dosage range to apply.</p> 
     * COCT_MT260010CA.ObservationEventCriterion: Dosage 
     * Preconditions <p>Allows recommended dosage instructions to 
     * be bound to a particular characteristic of the patient.</p> 
     * <p>A condition that must be true for the patient in order 
     * for the specified recommended dosage range to apply.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT260010CA.ObservationEventCriterion","COCT_MT260020CA.ObservationEventCriterion","COCT_MT260030CA.ObservationEventCriterion"})]
    public class DosagePreconditions : MessagePartBean {

        private CV code;
        private URG<PQ, PhysicalQuantity> value;

        public DosagePreconditions() {
            this.code = new CVImpl();
            this.value = new URGImpl<PQ, PhysicalQuantity>();
        }
        /**
         * <summary>Business Name: DosagePreconditionType</summary>
         * 
         * <remarks>Un-merged Business Name: DosagePreconditionType 
         * Relationship: COCT_MT260030CA.ObservationEventCriterion.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * specification of multiple preconditions for a dosage 
         * specification, such as Age Range, Weight Range, etc. This is 
         * mandatory because the precondition range cannot be evaluated 
         * without knowing the precondition type.</p> <p>Indicates the 
         * type of characteristic against which the patient is 
         * evaluated. This includes age, weight, height, etc.</p> 
         * Un-merged Business Name: DosagePreconditionType 
         * Relationship: COCT_MT260010CA.ObservationEventCriterion.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the 
         * specification of multiple preconditions for a dosage 
         * specification, such as Age Range, Weight Range, etc. This is 
         * mandatory because the precondition range cannot be evaluated 
         * without knowing the precondition type.</p> <p>Indicates the 
         * type of characteristic against which the patient is 
         * evaluated. This includes age, weight, height, etc.</p> 
         * Un-merged Business Name: DosagePreconditionType 
         * Relationship: COCT_MT260020CA.ObservationEventCriterion.code 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationDosageDefinitionPreconditionType Code {
            get { return (ObservationDosageDefinitionPreconditionType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: DosagePreconditionValue</summary>
         * 
         * <remarks>Un-merged Business Name: DosagePreconditionValue 
         * Relationship: 
         * COCT_MT260030CA.ObservationEventCriterion.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Minimum Age</p> 
         * <p>Maximum Age</p> <p>Allows direct comparison of the 
         * patient's characteristics with the minimum and maximum 
         * values specified.</p><p>The element is mandatory because 
         * there's no point in identifying that the dosage range is 
         * based on criteria unless the specific criterion used is 
         * expressed.</p> <p>If not specified, it means that the range 
         * is based on a criteria (e.g. weight), but the specific range 
         * on which the criteria is based is not known.</p> <p>A 
         * specific value or range of values of the Dosage Precondition 
         * Type, for which the recommended dosage applies.</p><p>This 
         * includes min-max age range, min-max weights, etc.</p><p>This 
         * is a mandatory attribute as the specific range of values 
         * must be known.</p> Un-merged Business Name: 
         * DosagePreconditionValue Relationship: 
         * COCT_MT260010CA.ObservationEventCriterion.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Minimum Age</p> 
         * <p>Maximum Age</p> <p>Allows direct comparison of the 
         * patient's characteristics with the minimum and maximum 
         * values specified.</p><p>The element is mandatory because 
         * there's no point in identifying that the dosage range is 
         * based on criteria unless the specific criterion used is 
         * expressed.</p> <p>If not specified, it means that the range 
         * is based on a criteria (e.g. weight), but the specific range 
         * on which the criteria is based is not known.</p> <p>A 
         * specific value or range of values of the Dosage Precondition 
         * Type, for which the recommended dosage applies.</p><p>This 
         * includes min-max age range, min-max weights, etc.</p><p>This 
         * is a mandatory attribute as the values of the measurements 
         * must be known.</p> Un-merged Business Name: 
         * DosagePreconditionValue Relationship: 
         * COCT_MT260020CA.ObservationEventCriterion.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public UncertainRange<PhysicalQuantity> Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}