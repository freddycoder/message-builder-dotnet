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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Repc_mt500006ab {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    /**
     * <summary>Business Name: Query Definition</summary>
     * 
     * <p>Allows the user and/or the point-of-service application 
     * to constrain what EHR information they wish to retrieve.</p> 
     * <p>Identifies the various parameters that act as filters on 
     * the records to be retrieved.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT500006AB.ParameterList"})]
    public class QueryDefinition : MessagePartBean {

        private II recordIdValue;
        private II repositoryIDValue;

        public QueryDefinition() {
            this.recordIdValue = new IIImpl();
            this.repositoryIDValue = new IIImpl();
        }
        /**
         * <summary>Business Name: Record Ids</summary>
         * 
         * <remarks>Relationship: REPC_MT500006AB.RecordId.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Specifically 
         * identifies the record to be returned.</p><p>Because the 
         * primary purpose of the query is to retrieve identified 
         * records, the element is mandatory.</p><p>Multiple 
         * repetitions are allowed to support multiple detail records 
         * as part of one query for efficiency reasons.</p> <p>A 
         * globally unique identifier assigned by the EHR to the record 
         * (or records) to be retrieved.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"recordId/value"})]
        public Identifier RecordIdValue {
            get { return this.recordIdValue.Value; }
            set { this.recordIdValue.Value = value; }
        }

        /**
         * <summary>Business Name: Repository Identifier</summary>
         * 
         * <remarks>Relationship: REPC_MT500006AB.RepositoryID.value 
         * Conformance/Cardinality: MANDATORY (1) <p>A unique 
         * identifier for the EHR repository.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"repositoryID/value"})]
        public Identifier RepositoryIDValue {
            get { return this.repositoryIDValue.Value; }
            set { this.repositoryIDValue.Value = value; }
        }

    }

}