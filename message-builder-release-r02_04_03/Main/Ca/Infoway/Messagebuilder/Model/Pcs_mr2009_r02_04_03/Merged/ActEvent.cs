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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: ReferencedRecord</summary>
     * 
     * <remarks>COMT_MT001104CA.ActEvent: Referenced Record <p>As a 
     * request, refers to the event to be acted upon or which has 
     * been acted upon.</p><p>As a response, may be used to 
     * indicate the identifier assigned to a created object.</p> 
     * <p>References an existing event record by identifier.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_MT001104CA.ActEvent","REPC_MT230001CA.ActEvent","REPC_MT230002CA.ActEvent","REPC_MT230003CA.ActEvent","REPC_MT500001CA.ActEvent","REPC_MT500002CA.ActEvent","REPC_MT500004CA.ActEvent"})]
    public class ActEvent : MessagePartBean {

        private II id;

        public ActEvent() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Un-merged Business Name: ContainedServiceEventIds</summary>
         * 
         * <remarks>Relationship: REPC_MT500001CA.ActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>One of the primary 
         * purposes of a care composition is to 'group' information. 
         * This attribute is the representation of that grouping.</p> 
         * <p>References any existing health service event records that 
         * should be associated with this care composition when it is 
         * created</p> Un-merged Business Name: RecordIdentifier 
         * Relationship: COMT_MT001104CA.ActEvent.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows the event 
         * record to be uniquely referenced and is therefore 
         * mandatory.</p> <p>The identifier assigned by the central 
         * system (EHR) to the Event record being referred 
         * to.</p><p>For the retract interaction, the identfier of the 
         * control act requested to be nullified.</p> Un-merged 
         * Business Name: ReportedOnServiceLink Relationship: 
         * REPC_MT230002CA.ActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a direct link for drill-down to 
         * the discrete record of the procedure or observation being 
         * reported on.</p> <p>A unique identifier assigned to the 
         * discrete record associated with the procedure or observation 
         * being reported upon.</p> Un-merged Business Name: 
         * ReportedOnServiceLink Relationship: 
         * REPC_MT230003CA.ActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a direct link for drill-down to 
         * the discrete record of the procedure or observation being 
         * reported on.</p> <p>A unique identifier assigned to the 
         * discrete record associated with the procedure or observation 
         * being reported upon.</p> Un-merged Business Name: 
         * ContainedServiceEventIds Relationship: 
         * REPC_MT500004CA.ActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>One of the primary purposes of a care 
         * composition is to 'group' information. This attribute is the 
         * representation of that grouping.</p> <p>References existing 
         * health service event records that are associated this care 
         * composition</p> Un-merged Business Name: 
         * ReportedOnServiceLink Relationship: 
         * REPC_MT230001CA.ActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>Provides a direct link for drill-down to 
         * the discrete record of the procedure or observation being 
         * reported on.</p> <p>A unique identifier assigned to the 
         * discrete record associated with the procedure or observation 
         * being reported upon.</p> Un-merged Business Name: 
         * ContainedServiceEventIds Relationship: 
         * REPC_MT500002CA.ActEvent.id Conformance/Cardinality: 
         * MANDATORY (1) <p>One of the primary purposes of a care 
         * composition is to 'group' information. This attribute is the 
         * representation of that grouping.</p> <p>References health 
         * service event records to be added to or removed from the 
         * care composition.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}