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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Prpm_mt303010ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Act Definition or Event Name</summary>
     * 
     * <p>Acts are the pivot of the RIM; all domain information and 
     * processes are represented primarily in Acts. Any profession 
     * or business, including healthcare, is primarily constituted 
     * of intentional and occasionally non-intentional actions, 
     * performed and recorded by responsible actors. An 
     * Act-instance is a record of such an action.</p> <p>A record 
     * of something that is being done, has been done, can be done, 
     * or is intended or requested to be done. Acts connect to 
     * Entities in their Roles through Participations and connect 
     * to other Acts through ActRelationships. Participations are 
     * the authors, performers and other responsible parties as 
     * well as subjects and beneficiaries (which includes tools and 
     * material used in the performance of the act, which are also 
     * subjects). The moodCode distinguishes between Acts that are 
     * meant as factual records, vs. records of intended or ordered 
     * services, and the other modalities in which act can 
     * appear.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PRPM_MT303010CA.ActDefinitionOrEvent"})]
    public class ActDefinitionOrEventName : MessagePartBean {

        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Merged.Location_1> location;
        private IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Prpm_mt303010ca.SequelTo> sequel;

        public ActDefinitionOrEventName() {
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.location = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Merged.Location_1>();
            this.sequel = new List<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Prpm_mt303010ca.SequelTo>();
        }
        /**
         * <summary>Business Name: Act Definition or Event Name 
         * Effective Time</summary>
         * 
         * <remarks>Relationship: 
         * PRPM_MT303010CA.ActDefinitionOrEvent.effectiveTime 
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
         * <summary>Relationship: 
         * PRPM_MT303010CA.ActDefinitionOrEvent.location</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-25)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Merged.Location_1> Location {
            get { return this.location; }
        }

        /**
         * <summary>Relationship: 
         * PRPM_MT303010CA.ActDefinitionOrEvent.sequel</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-25)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequel"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Pr.Prpm_mt303010ca.SequelTo> Sequel {
            get { return this.sequel; }
        }

    }

}