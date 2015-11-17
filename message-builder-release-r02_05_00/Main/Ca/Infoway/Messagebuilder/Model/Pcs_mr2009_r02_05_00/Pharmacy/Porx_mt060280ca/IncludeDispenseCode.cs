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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Pharmacy.Porx_mt060280ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060280CA.IncludeDispenseCode"})]
    public class IncludeDispenseCode : MessagePartBean {

        private CV value;

        public IncludeDispenseCode() {
            this.value = new CVImpl();
        }
        /**
         * <summary>Business Name: Include Dispense Code</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT060280CA.IncludeDispenseCode.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>To have the 
         * ability for the user to query for the details of a single 
         * prescription without requesting all of the dispense 
         * information, due to concerns about overwhelming the user 
         * with too much information and concerns about 
         * performance.</p> <p>HL7 Approved codes &amp; descriptions: 
         * ALLDISP all dispenses Return all dispenses of the 
         * prescription to date. LASTDISP last dispense Return most 
         * recent dispense of the prescription. NODISP no dispense 
         * Return no dispense of the prescription.</p> <p>Support the 
         * return of no dispenses, the latest dispense or all 
         * dispenses.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public QueryParameterValue Value {
            get { return (QueryParameterValue) this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}