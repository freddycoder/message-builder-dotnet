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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Common.Coct_mt080100ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Domainvalue;
    using System;


    /**
     * <summary>Business Name: Specimen Observation</summary>
     * 
     * <p>It is sometimes relevant to know certain specimen 
     * characteristics when evaluating a result regarding a 
     * specimen.</p> <p>One or more observation acts which describe 
     * aspects of a specimen (color, adequacy, etc.)</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT080100CA.SpecimenObservationEvent"})]
    public class SpecimenObservation : MessagePartBean {

        private CV code;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private ANY<object> value;

        public SpecimenObservation() {
            this.code = new CVImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.value = new ANYImpl<object>();
        }
        /**
         * <summary>Business Name: Specimen Observation Type</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.SpecimenObservationEvent.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Type of 
         * observation.</p> <p>Describes the specific observation being 
         * performed/documented.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public SpecimenObservationCode Code {
            get { return (SpecimenObservationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Specimen Observation Date/Time</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.SpecimenObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date/time 
         * when the observation took place. The date and time of the 
         * specimen observation can be relevant in the result.</p> 
         * <p>When this observation took place (or over what time 
         * interval; for collection).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Specimen Observation Value</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.SpecimenObservationEvent.value 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public object Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}