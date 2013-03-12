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
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt306011ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: ActDefinitionOrEventName</summary>
     * 
     * <remarks>PRPM_MT309000CA.ActDefinitionOrEvent: Act 
     * Definition or Event Name <p>A record of something that is 
     * being done, has been done, can be done, or is intended or 
     * requested to be done. Acts connect to Entities in their 
     * Roles through Participations and connect to other Acts 
     * through ActRelationships. Participations are the authors, 
     * performers and other responsible parties as well as subjects 
     * and beneficiaries (which includes tools and material used in 
     * the performance of the act, which are also subjects). The 
     * moodCode distinguishes between Acts that are meant as 
     * factual records, vs. records of intended or ordered 
     * services, and the other modalities in which act can 
     * appear.</p> <p>Acts are the pivot of the RIM; all domain 
     * information and processes are represented primarily in Acts. 
     * Any profession or business, including healthcare, is 
     * primarily constituted of intentional and occasionally 
     * non-intentional actions, performed and recorded by 
     * responsible actors. An Act-instance is a record of such an 
     * action.</p> PRPM_MT306011CA.ActDefinitionOrEvent: Act 
     * Definition or Event Name <p>A record of something that is 
     * being done, has been done, can be done, or is intended or 
     * requested to be done. Acts connect to Entities in their 
     * Roles through Participations and connect to other Acts 
     * through ActRelationships. Participations are the authors, 
     * performers and other responsible parties as well as subjects 
     * and beneficiaries (which includes tools and material used in 
     * the performance of the act, which are also subjects). The 
     * moodCode distinguishes between Acts that are meant as 
     * factual records, vs. records of intended or ordered 
     * services, and the other modalities in which act can 
     * appear.</p> <p>Acts are the pivot of the RIM; all domain 
     * information and processes are represented primarily in Acts. 
     * Any profession or business, including healthcare, is 
     * primarily constituted of intentional and occasionally 
     * non-intentional actions, performed and recorded by 
     * responsible actors. An Act-instance is a record of such an 
     * action.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT306011CA.ActDefinitionOrEvent","PRPM_MT309000CA.ActDefinitionOrEvent"})]
    public class ActDefinitionOrEventName_2 : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.Location_2> location;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt306011ca.SequelTo> sequel;

        public ActDefinitionOrEventName_2() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.location = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.Location_2>();
            this.sequel = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt306011ca.SequelTo>();
        }
        /**
         * <summary>Business Name: 
         * ActDefinitionOrEventNameEffectiveTime</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ActDefinitionOrEventNameEffectiveTime Relationship: 
         * PRPM_MT306011CA.ActDefinitionOrEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Effective Time 
         * with regard to the act involved</p> <p>Required attribute 
         * indicating effective time of this act</p> Un-merged Business 
         * Name: ActDefinitionOrEventNameEffectiveTime Relationship: 
         * PRPM_MT309000CA.ActDefinitionOrEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Effective Time 
         * with regard to the act involved</p> <p>Required attribute 
         * indicating effective time of this act</p></remarks>
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
         * PRPM_MT306011CA.ActDefinitionOrEvent.location 
         * Conformance/Cardinality: REQUIRED (0-25) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PRPM_MT309000CA.ActDefinitionOrEvent.location 
         * Conformance/Cardinality: OPTIONAL (0-25)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Merged.Location_2> Location {
            get { return this.location; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT306011CA.ActDefinitionOrEvent.sequel 
         * Conformance/Cardinality: REQUIRED (0-25)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequel"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pr.Prpm_mt306011ca.SequelTo> Sequel {
            get { return this.sequel; }
        }

    }

}