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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Coct_mt080100ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Specimen Process Steps</summary>
     * 
     * <p>At this time, only the transportation specimen process 
     * steps are in scope for lab messaging.</p> <p>The specimen is 
     * subject to one or more process steps. e.g. the specimen 
     * receive date is documented using a process step object, 
     * specimen action codes are also represented and communicated 
     * using this process step object.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT080100CA.TransportationEvent"})]
    public class SpecimenProcessSteps : MessagePartBean {

        private CV code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;

        public SpecimenProcessSteps() {
            this.code = new CVImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
        }
        /**
         * <summary>Business Name: P:Transportation Type</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.TransportationEvent.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Categorizes the 
         * type of transportation act being communiated.</p> 
         * <p>Describes the type of process step being documented and 
         * communicated e.g. specimen received data, specimen action 
         * codes, transportation type.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActSpecimenTransportationCode Code {
            get { return (ActSpecimenTransportationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: R:Transportation Status</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.TransportationEvent.statusCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates (along 
         * with the mood) whether this act's action has been completed 
         * or is still being acted upon (or has yet to be acted 
         * upon).</p> <p>The state or status of this transportation 
         * process step.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: Q:Transportation Date/Time</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.TransportationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Holds the 
         * date/time the process step took place. This attribute is 
         * especially important for those process steps which document 
         * the date/time the process happened (specimen received 
         * date/time).</p> <p>The date/time the process step took place 
         * or the duration of that step (days or time in transit, start 
         * time, end time).</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

    }

}