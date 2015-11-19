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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */

/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090108ab;


    /**
     * <summary>Business Name: AuthoredBy</summary>
     * 
     * <remarks>REPC_MT500002AB.Author: authored by <p>Used to 
     * identify responsibility for accuracy and relevance of the 
     * information. This association reflects primary 
     * responsibility (which is expected to be known), and is 
     * therefore populated.</p><p>The author is generally the 
     * person to contact with requests for additional information. 
     * In some cases, this information may also be used for 
     * filtering or sorting.</p> <p>This identifies the provider 
     * who is responsible for the decision to capture the Care 
     * Composition in the patient's EHR. Note that while the author 
     * is frequently the data-enterer, this will not always be the 
     * case, for example where transcribers are involved.</p> 
     * REPC_MT500001AB.Author: authored by <p>Used to identify 
     * responsibility for accuracy and relevance of the 
     * information. This association reflects primary 
     * responsibility (which is expected to be known), and is 
     * therefore populated.</p><p>The author is generally the 
     * person to contact with requests for additional information. 
     * In some cases, this information may also be used for 
     * filtering or sorting.</p> <p>This identifies the provider 
     * who is responsible for the decision to capture the Care 
     * Composition in the patient's EHR. Note that while the author 
     * is frequently the data-enterer, this will not always be the 
     * case, for example where transcribers are involved.</p> 
     * REPC_MT500004AB.Author: authored by <p>Used to identify 
     * responsibility for accuracy and relevance of the 
     * information. This association reflects primary 
     * responsibility (which is expected to be known), and is 
     * therefore populated.</p><p>The author is generally the 
     * person to contact with requests for additional information. 
     * In some cases, this information may also be used for 
     * filtering or sorting.</p> <p>This identifies the provider 
     * who is responsible for the decision to capture the Care 
     * Composition in the patient's EHR. Note that while the author 
     * is frequently the data-enterer, this will not always be the 
     * case, for example where transcribers are involved.</p> 
     * REPC_MT500003AB.Author: authored by <p>Used to identify 
     * responsibility for accuracy and relevance of the 
     * information. This association reflects primary 
     * responsibility (which is expected to be known), and is 
     * therefore populated.</p><p>The author is generally the 
     * person to contact with requests for additional information. 
     * In some cases, this information may also be used for 
     * filtering or sorting.</p> <p>This identifies the provider 
     * who is responsible for the decision to capture the Care 
     * Composition in the patient's EHR. Note that while the author 
     * is frequently the data-enterer, this will not always be the 
     * case, for example where transcribers are involved.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT500001AB.Author","REPC_MT500002AB.Author","REPC_MT500003AB.Author","REPC_MT500004AB.Author"})]
    public class AuthoredBy_2 : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090108ab.HealthcareWorker assignedEntity;

        public AuthoredBy_2() {
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: REPC_MT500002AB.Author.assignedEntity 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500001AB.Author.assignedEntity 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500004AB.Author.assignedEntity 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * REPC_MT500003AB.Author.assignedEntity 
         * Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"assignedEntity"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Coct_mt090108ab.HealthcareWorker AssignedEntity {
            get { return this.assignedEntity; }
            set { this.assignedEntity = value; }
        }

    }

}