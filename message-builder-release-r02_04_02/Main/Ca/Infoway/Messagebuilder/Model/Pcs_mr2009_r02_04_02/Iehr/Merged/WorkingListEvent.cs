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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;


    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT410003CA.WorkingListEvent","REPC_MT420003CA.WorkingListEvent","REPC_MT610002CA.WorkingListEvent"})]
    public class WorkingListEvent : MessagePartBean {

        private CV code;

        public WorkingListEvent() {
            this.code = new CVImpl();
        }
        /**
         * <summary>Un-merged Business Name: ObservationCategories</summary>
         * 
         * <remarks>Relationship: REPC_MT410003CA.WorkingListEvent.code 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: ServiceCategories Relationship: 
         * REPC_MT610002CA.WorkingListEvent.code 
         * Conformance/Cardinality: POPULATED (1) <p>Allows 
         * categorizing professional services for presentation. A given 
         * person may have had numerous procedures related to a 
         * particular area. By associating categories with procedures, 
         * a person viewing the EHR information can first look at a 
         * list of categories and then drill down to the specific 
         * procedures.</p><p>The presence of this field is essential to 
         * prevent users from being overwhelmed, however not all 
         * services will necessarily be categorizable. Therefore this 
         * element is marked as 'populated'.</p> <p>Categories are 
         * inferred from the terminology hierarchy and thus aren't 
         * specified as part of the 'record' message.</p> <p>Describes 
         * the categorization of the service. E.g. Psychological 
         * Counseling, Smoking Cessation, Cardiac Surgeries, etc.</p> 
         * Un-merged Business Name: ObservationCategories Relationship: 
         * REPC_MT420003CA.WorkingListEvent.code 
         * Conformance/Cardinality: POPULATED (1) <p>Allows 
         * categorizing of observations for presentation. A given 
         * person may have had numerous observations related to a 
         * particular area. By associating categories, a person viewing 
         * the EHR information can first look at a list of categories 
         * and then drill down to the specific observation.</p><p>The 
         * presence of this field is essential to prevent users from 
         * being overwhelmed, however not all observations will 
         * necessarily be categorizable. Therefore this element is 
         * marked as 'populated'.</p> <p>Describes the categorization 
         * of the observation.</p><p>E.g. signs and symptoms, history 
         * observations, etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCommonCodedClinicalObservationCategoryListCode Code {
            get { return (ActCommonCodedClinicalObservationCategoryListCode) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}