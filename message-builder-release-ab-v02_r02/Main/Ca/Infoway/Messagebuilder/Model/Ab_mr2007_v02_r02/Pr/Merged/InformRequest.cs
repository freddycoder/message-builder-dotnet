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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged;


    /**
     * <summary>Business Name: InformRequest</summary>
     * 
     * <remarks>PRPM_MT301010CA.InformRequest: Inform Request <p>A 
     * record of something that is being done, has been done, can 
     * be done, or is intended or requested to be done.</p> <p>Acts 
     * are the pivot of the RIM; all domain information and 
     * processes are represented primarily in Acts. Any profession 
     * or business, including healthcare, is primarily constituted 
     * of intentional and occasionally non-intentional actions, 
     * performed and recorded by responsible actors. An 
     * Act-instance is a record of such an action.</p> <p>(Provider 
     * Topic) use case - Document Routing Preference where code = 
     * doc type e.g. ECG XRAY DI - Diagnostic Image Lab Test Result 
     * Other Transcript</p> PRPM_MT303010CA.InformRequest: Inform 
     * Request <p>A record of something that is being done, has 
     * been done, can be done, or is intended or requested to be 
     * done.</p> <p>Acts are the pivot of the RIM; all domain 
     * information and processes are represented primarily in Acts. 
     * Any profession or business, including healthcare, is 
     * primarily constituted of intentional and occasionally 
     * non-intentional actions, performed and recorded by 
     * responsible actors. An Act-instance is a record of such an 
     * action.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.InformRequest","PRPM_MT303010CA.InformRequest"})]
    public class InformRequest : MessagePartBean {

        private CV code;
        private CV subjectModeCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.DispenseShipToLocation subjectServiceDeliveryLocation;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.IChoice indirectTargetChoice;

        public InformRequest() {
            this.code = new CVImpl();
            this.subjectModeCode = new CVImpl();
        }
        /**
         * <summary>Business Name: InformRequestCode</summary>
         * 
         * <remarks>Un-merged Business Name: InformRequestCode 
         * Relationship: PRPM_MT301010CA.InformRequest.code 
         * Conformance/Cardinality: POPULATED (1) <p>A code specifying 
         * the particular kind of Act that the Act-instance represents 
         * within its class. Ex. Document Type</p> <p>Populated</p> 
         * Un-merged Business Name: InformRequestCode Relationship: 
         * PRPM_MT303010CA.InformRequest.code Conformance/Cardinality: 
         * POPULATED (1) <p>A code specifying the particular kind of 
         * Act that the Act-instance represents within its class. Ex. 
         * Document Type</p> <p>Populated attribute supports the 
         * business requirement to provide coded information about the 
         * Act being described</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.Subject.modeCode 
         * Conformance/Cardinality: POPULATED (1) <p>Populated</p> 
         * Un-merged Business Name: (no business name specified) 
         * Relationship: PRPM_MT303010CA.Subject.modeCode 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/modeCode"})]
        public ParticipationMode SubjectModeCode {
            get { return (ParticipationMode) this.subjectModeCode.Value; }
            set { this.subjectModeCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT301010CA.Subject.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT303010CA.Subject.serviceDeliveryLocation 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subject/serviceDeliveryLocation"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.DispenseShipToLocation SubjectServiceDeliveryLocation {
            get { return this.subjectServiceDeliveryLocation; }
            set { this.subjectServiceDeliveryLocation = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: PRPM_MT301010CA.IndirectTarget.choice 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT303010CA.IndirectTarget.choice 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"indirectTarget/choice"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Merged.IChoice IndirectTargetChoice {
            get { return this.indirectTargetChoice; }
            set { this.indirectTargetChoice = value; }
        }

    }

}