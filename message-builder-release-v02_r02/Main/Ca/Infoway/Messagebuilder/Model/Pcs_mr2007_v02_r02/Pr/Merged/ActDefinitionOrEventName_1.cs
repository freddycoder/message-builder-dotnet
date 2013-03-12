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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: ActDefinitionOrEventName</summary>
     * 
     * <remarks>PRPM_MT303010CA.ActDefinitionOrEvent: Act 
     * Definition or Event Name <p>Acts are the pivot of the RIM; 
     * all domain information and processes are represented 
     * primarily in Acts. Any profession or business, including 
     * healthcare, is primarily constituted of intentional and 
     * occasionally non-intentional actions, performed and recorded 
     * by responsible actors. An Act-instance is a record of such 
     * an action.</p> <p>A record of something that is being done, 
     * has been done, can be done, or is intended or requested to 
     * be done. Acts connect to Entities in their Roles through 
     * Participations and connect to other Acts through 
     * ActRelationships. Participations are the authors, performers 
     * and other responsible parties as well as subjects and 
     * beneficiaries (which includes tools and material used in the 
     * performance of the act, which are also subjects). The 
     * moodCode distinguishes between Acts that are meant as 
     * factual records, vs. records of intended or ordered 
     * services, and the other modalities in which act can 
     * appear.</p> PRPM_MT301010CA.ActDefinitionOrEvent: Act 
     * Definition or Event Name <p>Acts are the pivot of the RIM; 
     * all domain information and processes are represented 
     * primarily in Acts. Any profession or business, including 
     * healthcare, is primarily constituted of intentional and 
     * occasionally non-intentional actions, performed and recorded 
     * by responsible actors. An Act-instance is a record of such 
     * an action.</p> <p>A record of something that is being done, 
     * has been done, can be done, or is intended or requested to 
     * be done. Acts connect to Entities in their Roles through 
     * Participations and connect to other Acts through 
     * ActRelationships. Participations are the authors, performers 
     * and other responsible parties as well as subjects and 
     * beneficiaries (which includes tools and material used in the 
     * performance of the act, which are also subjects). The 
     * moodCode distinguishes between Acts that are meant as 
     * factual records, vs. records of intended or ordered 
     * services, and the other modalities in which act can 
     * appear.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT301010CA.ActDefinitionOrEvent","PRPM_MT303010CA.ActDefinitionOrEvent"})]
    public class ActDefinitionOrEventName_1 : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.Location_1> location;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.SequelTo> sequel;

        public ActDefinitionOrEventName_1() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.location = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.Location_1>();
            this.sequel = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.SequelTo>();
        }
        /**
         * <summary>Business Name: 
         * ActDefinitionOrEventNameEffectiveTime</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ActDefinitionOrEventNameEffectiveTime Relationship: 
         * PRPM_MT303010CA.ActDefinitionOrEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute indicating effective time of this act</p> 
         * <p>Effective Time with regard to the act involved</p> 
         * Un-merged Business Name: 
         * ActDefinitionOrEventNameEffectiveTime Relationship: 
         * PRPM_MT301010CA.ActDefinitionOrEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Required 
         * attribute indicating effective time of this act</p> 
         * <p>Effective Time with regard to the act involved</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT303010CA.ActDefinitionOrEvent.location 
         * Conformance/Cardinality: REQUIRED (0-25) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT301010CA.ActDefinitionOrEvent.location 
         * Conformance/Cardinality: REQUIRED (0-25)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.Location_1> Location {
            get { return this.location; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT303010CA.ActDefinitionOrEvent.sequel 
         * Conformance/Cardinality: REQUIRED (0-25) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT301010CA.ActDefinitionOrEvent.sequel 
         * Conformance/Cardinality: REQUIRED (0-25)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequel"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Pr.Merged.SequelTo> Sequel {
            get { return this.sequel; }
        }

    }

}