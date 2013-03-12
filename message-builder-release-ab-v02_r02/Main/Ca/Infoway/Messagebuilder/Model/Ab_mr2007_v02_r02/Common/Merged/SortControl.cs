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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: SortControl</summary>
     * 
     * <remarks>MFMI_MT700751CA.SortControl: Sort Control <p>Holds 
     * specification of sort order for instance matches to a 
     * query.</p> <p>Optional for systems which can receive query 
     * requests and sort the results before returning to the query 
     * requestor.</p> MFMI_MT700746CA.SortControl: Sort Control 
     * <p>Holds specification of sort order for instance matches to 
     * a query.</p> <p>Optional for systems which can receive query 
     * requests and sort the results before returning to the query 
     * requestor.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MFMI_MT700746CA.SortControl","MFMI_MT700751CA.SortControl"})]
    public class SortControl : MessagePartBean {

        private INT sequenceNumber;
        private ST elementName;
        private CS directionCode;

        public SortControl() {
            this.sequenceNumber = new INTImpl();
            this.elementName = new STImpl();
            this.directionCode = new CSImpl();
        }
        /**
         * <summary>Business Name: SequenceNumber</summary>
         * 
         * <remarks>Un-merged Business Name: SequenceNumber 
         * Relationship: MFMI_MT700751CA.SortControl.sequenceNumber 
         * Conformance/Cardinality: MANDATORY (1) <p>When more than one 
         * sort control is specified, this is the order of this sort 
         * element amongst the others.</p> <p>This number determines 
         * which sort element is using primarily, secondary, etc. and 
         * is therefore mandatory.</p> Un-merged Business Name: 
         * SequenceNumber Relationship: 
         * MFMI_MT700746CA.SortControl.sequenceNumber 
         * Conformance/Cardinality: MANDATORY (1) <p>When more than one 
         * sort control is specified, this is the order of this sort 
         * element amongst the others.</p> <p>This number determines 
         * which sort element is using primarily, secondary, etc. and 
         * is therefore mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequenceNumber"})]
        public int? SequenceNumber {
            get { return this.sequenceNumber.Value; }
            set { this.sequenceNumber.Value = value; }
        }

        /**
         * <summary>Business Name: SortElementName</summary>
         * 
         * <remarks>Un-merged Business Name: SortElementName 
         * Relationship: MFMI_MT700751CA.SortControl.elementName 
         * Conformance/Cardinality: MANDATORY (1) <p>Name of the 
         * element to sort.</p> <p>The name of the element is 
         * mandatory.</p> Un-merged Business Name: SortElementName 
         * Relationship: MFMI_MT700746CA.SortControl.elementName 
         * Conformance/Cardinality: MANDATORY (1) <p>Name of the 
         * element to sort.</p> <p>The name of the element is 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"elementName"})]
        public String ElementName {
            get { return this.elementName.Value; }
            set { this.elementName.Value = value; }
        }

        /**
         * <summary>Business Name: SortControlDirection</summary>
         * 
         * <remarks>Un-merged Business Name: SortControlDirection 
         * Relationship: MFMI_MT700751CA.SortControl.directionCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Sets the 
         * ascending or descending nature of the sort request.</p> 
         * <p>This element is required.</p> Un-merged Business Name: 
         * SortControlDirection Relationship: 
         * MFMI_MT700746CA.SortControl.directionCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Sets the 
         * ascending or descending nature of the sort request.</p> 
         * <p>This element is required.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directionCode"})]
        public Sequencing DirectionCode {
            get { return (Sequencing) this.directionCode.Value; }
            set { this.directionCode.Value = value; }
        }

    }

}