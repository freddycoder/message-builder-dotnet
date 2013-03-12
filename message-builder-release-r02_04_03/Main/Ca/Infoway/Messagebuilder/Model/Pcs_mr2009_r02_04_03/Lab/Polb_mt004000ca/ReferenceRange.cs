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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt004000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Reference Range</summary>
     * 
     * <p>Reference ranges are generally presented as a pair of 
     * values (Lo - Hi) of the same datatype as the observation to 
     * which they apply (carried as an IVL). In some cases there 
     * may only be a Lo or a Hi rather than a pair of values.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004000CA.InterpretationRange"})]
    public class ReferenceRange : MessagePartBean {

        private ANY<object> value;
        private CV interpretationCode;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt004000ca.ReferenceRangeCriteria> preconditionObservationEventCriterion;

        public ReferenceRange() {
            this.value = new ANYImpl<object>();
            this.interpretationCode = new CVImpl();
            this.preconditionObservationEventCriterion = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt004000ca.ReferenceRangeCriteria>();
        }
        /**
         * <summary>Business Name: Reference Range Value</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004000CA.InterpretationRange.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Reference ranges 
         * are generally presented as a pair of values (Lo - Hi) of the 
         * same datatype as the observation to which they apply 
         * (carried as an IVL). In some cases there may only be a 
         * single value (not a range or interval). If a coded value 
         * applies, the value must be selected from the 
         * LaboratoryResultCodeValue Concept Domain.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public object Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Business Name: Reference Range Interpretation Type</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004000CA.InterpretationRange.interpretationCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Describes the 
         * type of range e.g. normal, high, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"interpretationCode"})]
        public ObservationInterpretation InterpretationCode {
            get { return (ObservationInterpretation) this.interpretationCode.Value; }
            set { this.interpretationCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * POLB_MT004000CA.Precondition.observationEventCriterion</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"precondition/observationEventCriterion"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Lab.Polb_mt004000ca.ReferenceRangeCriteria> PreconditionObservationEventCriterion {
            get { return this.preconditionObservationEventCriterion; }
        }

    }

}