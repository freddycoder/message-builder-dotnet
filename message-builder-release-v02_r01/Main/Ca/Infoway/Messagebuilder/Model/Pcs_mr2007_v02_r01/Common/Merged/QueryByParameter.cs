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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"MFMI_MT700746CA.QueryByParameter","MFMI_MT700751CA.QueryByParameter","QUQI_MT020000CA.QueryByParameter","QUQI_MT020002CA.QueryByParameter","QUQI_MT120006CA.QueryByParameter","QUQI_MT120008CA.QueryByParameter"})]
    public class QueryByParameter<PL> : MessagePartBean {

        private II queryId;
        private CS responseModalityCode;
        private INT initialQuantity;
        private CV initialQuantityCode;
        private PL parameterList;
        private INT sortControlSequenceNumber;
        private ST sortControlElementName;
        private CS sortControlDirectionCode;

        public QueryByParameter() {
            this.queryId = new IIImpl();
            this.responseModalityCode = new CSImpl();
            this.initialQuantity = new INTImpl();
            this.initialQuantityCode = new CVImpl();
            this.sortControlSequenceNumber = new INTImpl();
            this.sortControlElementName = new STImpl();
            this.sortControlDirectionCode = new CSImpl();
        }
        /**
         * <summary>Business Name: QueryIdentifier</summary>
         * 
         * <remarks>Un-merged Business Name: QueryIdentifier 
         * Relationship: QUQI_MT020000CA.QueryByParameter.queryId 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to allow 
         * continuation of queries and linking of query requests and 
         * responses and therefore mandatory.</p> <p>Unique number for 
         * this particular query.</p> Un-merged Business Name: 
         * QueryIdentifier Relationship: 
         * MFMI_MT700751CA.QueryByParameter.queryId 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to allow 
         * continuation of queries and linking of query requests and 
         * responses and therefore mandatory.</p> <p>Unique number for 
         * this particular query.</p> Un-merged Business Name: 
         * QueryIdentifier Relationship: 
         * MFMI_MT700746CA.QueryByParameter.queryId 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to allow 
         * continuation of queries and linking of query requests and 
         * responses and therefore mandatory.</p> <p>Unique number for 
         * this particular query.</p> Un-merged Business Name: 
         * QueryIdentifier Relationship: 
         * QUQI_MT020002CA.QueryByParameter.queryId 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to allow 
         * continuation of queries and linking of query requests and 
         * responses and therefore mandatory.</p> <p>Unique number for 
         * this particular query.</p> Un-merged Business Name: 
         * QueryIdentifier Relationship: 
         * QUQI_MT120008CA.QueryByParameter.queryId 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to allow 
         * continuation of queries and linking of query requests and 
         * responses and therefore mandatory.</p> <p>Unique number for 
         * this particular query.</p> Un-merged Business Name: 
         * QueryIdentifier Relationship: 
         * QUQI_MT120006CA.QueryByParameter.queryId 
         * Conformance/Cardinality: MANDATORY (1) <p>Needed to allow 
         * continuation of queries and linking of query requests and 
         * responses and therefore mandatory.</p> <p>Unique number for 
         * this particular query.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"queryId"})]
        public Identifier QueryId {
            get { return this.queryId.Value; }
            set { this.queryId.Value = value; }
        }

        /**
         * <summary>Business Name: ExpeditedQueryIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: ExpeditedQueryIndicator 
         * Relationship: 
         * QUQI_MT020000CA.QueryByParameter.responseModalityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Intended to cover 
         * situations in which the HIAL issues a query with an ID to 
         * obtain a very limited amount of information, or issues a 
         * query with basic provider information to obtain IDs and othe 
         * information, such as licence status</p> <p>This allows the 
         * sender to indicate to the receiver that this query should 
         * follow an expedited processing flow.</p> Un-merged Business 
         * Name: ExpeditedQueryIndicator Relationship: 
         * MFMI_MT700751CA.QueryByParameter.responseModalityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Intended to cover 
         * situations in which the HIAL issues a query with an ID to 
         * obtain a very limited amount of information, or issues a 
         * query with basic provider information to obtain IDs and othe 
         * information, such as licence status</p> <p>This allows the 
         * sender to indicate to the receiver that this query should 
         * follow an expedited processing flow.</p> Un-merged Business 
         * Name: ExpeditedQueryIndicator Relationship: 
         * MFMI_MT700746CA.QueryByParameter.responseModalityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>&gt;Intended to 
         * cover situations in which the HIAL issues a query with an ID 
         * to obtain a very limited amount of information, or issues a 
         * query with basic provider information to obtain IDs and othe 
         * information, such as licence status</p> <p>This allows the 
         * sender to indicate to the receiver that this query should 
         * follow an expedited processing flow.</p> Un-merged Business 
         * Name: ExpeditedQueryIndicator Relationship: 
         * QUQI_MT020002CA.QueryByParameter.responseModalityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Intended to cover 
         * situations in which the HIAL issues a query with an ID to 
         * obtain a very limited amount of information, or issues a 
         * query with basic provider information to obtain IDs and othe 
         * information, such as licence status</p> <p>This allows the 
         * sender to indicate to the receiver that this query should 
         * follow an expedited processing flow.</p> Un-merged Business 
         * Name: ExpeditedQueryIndicator Relationship: 
         * QUQI_MT120008CA.QueryByParameter.responseModalityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>&gt;Intended to 
         * cover situations in which the HIAL issues a query with an ID 
         * to obtain a very limited amount of information, or issues a 
         * query with basic provider information to obtain IDs and othe 
         * information, such as licence status</p> <p>This allows the 
         * sender to indicate to the receiver that this query should 
         * follow an expedited processing flow.</p> Un-merged Business 
         * Name: ExpeditedQueryIndicator Relationship: 
         * QUQI_MT120006CA.QueryByParameter.responseModalityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>&gt;Intended to 
         * cover situations in which the HIAL issues a query with an ID 
         * to obtain a very limited amount of information, or issues a 
         * query with basic provider information to obtain IDs and othe 
         * information, such as licence status</p> <p>This allows the 
         * sender to indicate to the receiver that this query should 
         * follow an expedited processing flow.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responseModalityCode"})]
        public ResponseModality ResponseModalityCode {
            get { return (ResponseModality) this.responseModalityCode.Value; }
            set { this.responseModalityCode.Value = value; }
        }

        /**
         * <summary>Business Name: QueryLimit</summary>
         * 
         * <remarks>Un-merged Business Name: QueryLimit Relationship: 
         * QUQI_MT020000CA.QueryByParameter.initialQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>There may be a 
         * very large number of matching rows. To manage communication 
         * bandwidth, a limited set may initially be returned with 
         * further data retrieved by using query continuations.</p> 
         * <p>If not specified, the default behavior is to return all 
         * repetitions. However the recipient of a query may always 
         * choose to limit the quantity returned to be less than the 
         * number requested. Regardless of the number specified here, 
         * the number of rows returned will never exceed the number of 
         * matching rows based on the query parameters.</p> <p>The 
         * number of response item repetitions that should be included 
         * in the initial response.</p> Un-merged Business Name: 
         * QueryLimit Relationship: 
         * MFMI_MT700751CA.QueryByParameter.initialQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>There may be a 
         * very large number of matching rows. To manage communication 
         * bandwidth, a limited set may initially be returned with 
         * further data retrieved by using query continuations.</p> 
         * <p>If not specified, the default behavior is to return all 
         * repetitions. However the recipient of a query may always 
         * choose to limit the quantity returned to be less than the 
         * number requested. Regardless of the number specified here, 
         * the number of rows returned will never exceed the number of 
         * matching rows based on the query parameters.</p> <p>The 
         * number of response item repetitions that should be included 
         * in the initial response.</p> Un-merged Business Name: 
         * QueryLimit Relationship: 
         * MFMI_MT700746CA.QueryByParameter.initialQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>There may be a 
         * very large number of matching rows. To manage communication 
         * bandwidth, a limited set may initially be returned with 
         * further data retrieved by using query continuations.</p> 
         * <p>The number of response item repetitions that should be 
         * included in the initial response.</p> Un-merged Business 
         * Name: QueryLimit Relationship: 
         * QUQI_MT020002CA.QueryByParameter.initialQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>There may be a 
         * very large number of matching rows. To manage communication 
         * bandwidth, a limited set may initially be returned with 
         * further data retrieved by using query continuations.</p> 
         * <p>If not specified, the default behavior is to return all 
         * repetitions. However the recipient of a query may always 
         * choose to limit the quantity returned to be less than the 
         * number requested. Regardless of the number specified here, 
         * the number of rows returned will never exceed the number of 
         * matching rows based on the query parameters.</p> <p>The 
         * number of response item repetitions that should be included 
         * in the initial response.</p> Un-merged Business Name: 
         * QueryLimit Relationship: 
         * QUQI_MT120008CA.QueryByParameter.initialQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>There may be a 
         * very large number of matching rows. To manage communication 
         * bandwidth, a limited set may initially be returned with 
         * further data retrieved by using query continuations.</p> 
         * <p>If not specified, the default behavior is to return all 
         * repetitions. However the recipient of a query may always 
         * choose to limit the quantity returned to be less than the 
         * number requested. Regardless of the number specified here, 
         * the number of rows returned will never exceed the number of 
         * matching rows based on the query parameters.</p> <p>The 
         * number of response item repetitions that should be included 
         * in the initial response.</p> Un-merged Business Name: 
         * QueryLimit Relationship: 
         * QUQI_MT120006CA.QueryByParameter.initialQuantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>There may be a 
         * very large number of matching rows. To manage communication 
         * bandwidth, a limited set may initially be returned with 
         * further data retrieved by using query continuations.</p> 
         * <p>If not specified, the default behavior is to return all 
         * repetitions. However the recipient of a query may always 
         * choose to limit the quantity returned to be less than the 
         * number requested. Regardless of the number specified here, 
         * the number of rows returned will never exceed the number of 
         * matching rows based on the query parameters.</p> <p>The 
         * number of response item repetitions that should be included 
         * in the initial response.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"initialQuantity"})]
        public int? InitialQuantity {
            get { return this.initialQuantity.Value; }
            set { this.initialQuantity.Value = value; }
        }

        /**
         * <summary>Business Name: QueryLimitType</summary>
         * 
         * <remarks>Un-merged Business Name: QueryLimitType 
         * Relationship: 
         * QUQI_MT020000CA.QueryByParameter.initialQuantityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Needed to 
         * quantify the types of records requested to be returned in 
         * the query.</p> <p>Defines the units associated with the 
         * magnitude of the maximum size limit of a query response that 
         * can be accepted by the requesting application.</p> Un-merged 
         * Business Name: QueryLimitType Relationship: 
         * MFMI_MT700751CA.QueryByParameter.initialQuantityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Needed to 
         * quantify the types of records requested to be returned in 
         * the query.</p> <p>Defines the units associated with the 
         * magnitude of the maximum size limit of a query response that 
         * can be accepted by the requesting application.</p> Un-merged 
         * Business Name: QueryLimitType Relationship: 
         * MFMI_MT700746CA.QueryByParameter.initialQuantityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Needed to 
         * quantify the types of records requested to be returned in 
         * the query.</p> <p>Defines the units associated with the 
         * magnitude of the maximum size limit of a query response that 
         * can be accepted by the requesting application.</p> Un-merged 
         * Business Name: QueryLimitType Relationship: 
         * QUQI_MT020002CA.QueryByParameter.initialQuantityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Needed to 
         * quantify the types of records requested to be returned in 
         * the query.</p> <p>Defines the units associated with the 
         * magnitude of the maximum size limit of a query response that 
         * can be accepted by the requesting application.</p> Un-merged 
         * Business Name: QueryLimitType Relationship: 
         * QUQI_MT120008CA.QueryByParameter.initialQuantityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Needed to 
         * quantify the types of records requested to be returned in 
         * the query.</p> <p>Defines the units associated with the 
         * magnitude of the maximum size limit of a query response that 
         * can be accepted by the requesting application.</p> Un-merged 
         * Business Name: QueryLimitType Relationship: 
         * QUQI_MT120006CA.QueryByParameter.initialQuantityCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Needed to 
         * quantify the types of records requested to be returned in 
         * the query.</p> <p>Defines the units associated with the 
         * magnitude of the maximum size limit of a query response that 
         * can be accepted by the requesting application.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"initialQuantityCode"})]
        public QueryRequestLimit InitialQuantityCode {
            get { return (QueryRequestLimit) this.initialQuantityCode.Value; }
            set { this.initialQuantityCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * QUQI_MT020000CA.QueryByParameter.parameterList 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MFMI_MT700751CA.QueryByParameter.parameterList 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MFMI_MT700746CA.QueryByParameter.parameterList 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * QUQI_MT020002CA.QueryByParameter.parameterList 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * QUQI_MT120008CA.QueryByParameter.parameterList 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * QUQI_MT120006CA.QueryByParameter.parameterList 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"parameterList"})]
        public PL ParameterList {
            get { return this.parameterList; }
            set { this.parameterList = value; }
        }

        /**
         * <summary>Business Name: SequenceNumber</summary>
         * 
         * <remarks>Un-merged Business Name: SequenceNumber 
         * Relationship: MFMI_MT700751CA.SortControl.sequenceNumber 
         * Conformance/Cardinality: MANDATORY (1) <p>This number 
         * determines which sort element is using primarily, secondary, 
         * etc. and is therefore mandatory.</p> <p>When more than one 
         * sort control is specified, this is the order of this sort 
         * element amongst the others.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sortControl/sequenceNumber"})]
        public int? SortControlSequenceNumber {
            get { return this.sortControlSequenceNumber.Value; }
            set { this.sortControlSequenceNumber.Value = value; }
        }

        /**
         * <summary>Business Name: SortElementName</summary>
         * 
         * <remarks>Un-merged Business Name: SortElementName 
         * Relationship: MFMI_MT700751CA.SortControl.elementName 
         * Conformance/Cardinality: MANDATORY (1) <p>The name of the 
         * element is mandatory.</p> <p>Name of the element to 
         * sort.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sortControl/elementName"})]
        public String SortControlElementName {
            get { return this.sortControlElementName.Value; }
            set { this.sortControlElementName.Value = value; }
        }

        /**
         * <summary>Business Name: SortControlDirection</summary>
         * 
         * <remarks>Un-merged Business Name: SortControlDirection 
         * Relationship: MFMI_MT700751CA.SortControl.directionCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>This element is 
         * required.</p> <p>Sets the ascending or descending nature of 
         * the sort request.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sortControl/directionCode"})]
        public Sequencing SortControlDirectionCode {
            get { return (Sequencing) this.sortControlDirectionCode.Value; }
            set { this.sortControlDirectionCode.Value = value; }
        }

    }

}