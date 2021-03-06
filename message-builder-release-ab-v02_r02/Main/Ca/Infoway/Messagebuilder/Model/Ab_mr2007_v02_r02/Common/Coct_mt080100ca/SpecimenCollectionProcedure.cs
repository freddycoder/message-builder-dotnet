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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Coct_mt080100ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090102ca;
    using Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Specimen Collection Procedure</summary>
     * 
     * <p>This is the procedure act which describes the 
     * process/procedure used to collect the associated 
     * specimen.</p> <p>For certain laboratory tests, the specimen 
     * collection procedure information is relevant in determining 
     * the result value.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT080100CA.SpecimenCollectionProcedureEvent"})]
    public class SpecimenCollectionProcedure : MessagePartBean {

        private ST text;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090102ca.AssignedPerson performerAssignedEntity;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes> subjectOfAnnotation;

        public SpecimenCollectionProcedure() {
            this.text = new STImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.subjectOfAnnotation = new List<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes>();
        }
        /**
         * <summary>Business Name: G:Specimen Collection Text</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.SpecimenCollectionProcedureEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Used to describe 
         * any additional information regarding the specimen collection 
         * procedure or the collected material, e.g. left ear; where 
         * &quot;ear&quot; is atomically represented by the Natural 
         * entity code but the &quot;left&quot; is not able, at this 
         * time, to also be communicated within the Natural entity. 
         * This attribute is not used for notes or comments regarding 
         * the specimen collection process. Notes and annotations are 
         * documented using the Annotation CMET.</p> <p>The text 
         * attribute documents any additional information regarding 
         * this specimen collection procedure event that is not able to 
         * be communicated using the other attribution of this act e.g. 
         * for granularity of coding reasons.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: E:Specimen Collection Date/Time</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT080100CA.SpecimenCollectionProcedureEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date/time the 
         * specimen was collected. This can be a date/time interval 
         * (start - stop).</p><p>The time may not always be known, but 
         * a date should always be entered.</p> <p>The date/time the 
         * specimen was collected. This can be a date/time interval 
         * (start - stop).</p><p>The time may not always be known, but 
         * a date should always be entered.</p> <p>The specimen 
         * collection date/time is relevant to the testing and 
         * resulting outcome of that specimen for some laboratory 
         * tests.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * COCT_MT080100CA.Performer2.assignedEntity</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"performer/assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt090102ca.AssignedPerson PerformerAssignedEntity {
            get { return this.performerAssignedEntity; }
            set { this.performerAssignedEntity = value; }
        }

        /**
         * <summary>Relationship: COCT_MT080100CA.Subject2.annotation</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"subjectOf/annotation"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Sessionmgmt.Coct_mt120600ca.Notes> SubjectOfAnnotation {
            get { return this.subjectOfAnnotation; }
        }

    }

}