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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System;


    /**
     * <summary>POLB_MT004200CA.ReportableTestIndicator: Reportable 
     * Health Indicator</summary>
     * 
     * <p>This must not be linked at ObservationReport level.</p> 
     * <p>Indicates whether or not this result is reportable to 
     * another party such as an agency, study, or other 
     * authority.</p> POLB_MT004000CA.ReportableTestIndicator: 
     * Reportable Observation <p>Report test and test results to 
     * Public Health and or other entities</p> 
     * POLB_MT004100CA.ReportableTestIndicator: Reportable Health 
     * Indicator <p>Indicates whether or not this result is 
     * reportable to another agency, study, or authority.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004000CA.ReportableTestIndicator","POLB_MT004100CA.ReportableTestIndicator","POLB_MT004200CA.ReportableTestIndicator"})]
    public class ReportableHealthIndicator : MessagePartBean {

        private CD code;
        private BL value;

        public ReportableHealthIndicator() {
            this.code = new CDImpl();
            this.value = new BLImpl();
        }
        /**
         * <summary>Business Name: ObservationTypeReportableIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: 
         * ObservationTypeReportableIndicator Relationship: 
         * POLB_MT004200CA.ReportableTestIndicator.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Specifies this 
         * observation as indicating whether the associated result is 
         * reportable to an agency, ministry, study, etc.</p> Un-merged 
         * Business Name: ObservationTypeReportableIndicator 
         * Relationship: POLB_MT004000CA.ReportableTestIndicator.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Describes this 
         * observation as an indicator as to whether or not this result 
         * is to be reported to public health.</p> Un-merged Business 
         * Name: ObservationTypeReportableIndicator Relationship: 
         * POLB_MT004100CA.ReportableTestIndicator.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Specifies this 
         * observation as a reportable test indicator</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ReportableToCode Code {
            get { return (ReportableToCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ReportableIndicator</summary>
         * 
         * <remarks>Un-merged Business Name: ReportableIndicator 
         * Relationship: POLB_MT004200CA.ReportableTestIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>This boolean value 
         * set whether this result is reportable. True=reportable, 
         * false=not reportable.</p> Un-merged Business Name: 
         * ReportableIndicator Relationship: 
         * POLB_MT004000CA.ReportableTestIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Report test and 
         * test results to another entity.</p> Un-merged Business Name: 
         * ReportableIndicator Relationship: 
         * POLB_MT004100CA.ReportableTestIndicator.value 
         * Conformance/Cardinality: MANDATORY (1) <p>This boolean value 
         * set whether this result is reportable to another agency, 
         * study, panel, authority, etc. True=reportable, false=not 
         * reportable.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public bool? Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}