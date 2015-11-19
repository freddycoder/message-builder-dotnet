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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Lab.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt080100ca;
    using System;


    /**
     * <summary>POLB_MT004100CA.Specimen1: Culture Specimen</summary>
     * 
     * <p>Associates the specimens as received with the culture 
     * observation (before processing). Specimen processing and 
     * subsequent reporting is communicated using the Isolate 
     * Specimen participation.</p> POLB_MT004200CA.Specimen: Report 
     * Section Specimen <p>At least 1 specimen must be specified on 
     * a Result.</p> <p>Associates the specimens as received with a 
     * diagnosis report section. This includes specimens subsequent 
     * to processing. Specimens originally received (and not 
     * processed) are communicated using the Report Specimen 
     * participation.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT002000CA.Specimen","POLB_MT004000CA.Specimen","POLB_MT004100CA.Specimen1","POLB_MT004200CA.Specimen"})]
    public class ReportSectionSpecimen : MessagePartBean {

        private Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt080100ca.SpecimenRole specimen;
        private INT sequenceNumber;

        public ReportSectionSpecimen() {
            this.sequenceNumber = new INTImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: POLB_MT004100CA.Specimen1.specimen 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POLB_MT002000CA.Specimen.specimen Conformance/Cardinality: 
         * REQUIRED (1) Un-merged Business Name: (no business name 
         * specified) Relationship: POLB_MT004200CA.Specimen.specimen 
         * Conformance/Cardinality: REQUIRED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * POLB_MT004000CA.Specimen.specimen Conformance/Cardinality: 
         * REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"specimen"})]
        public Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Common.Coct_mt080100ca.SpecimenRole Specimen {
            get { return this.specimen; }
            set { this.specimen = value; }
        }

        /**
         * <summary>Business Name: SpecimenSequenceNumber</summary>
         * 
         * <remarks>Un-merged Business Name: SpecimenSequenceNumber 
         * Relationship: POLB_MT002000CA.Specimen.sequenceNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Order in which 
         * the specimen is to appear in the message.</p> Un-merged 
         * Business Name: SpecimenSequenceNumber Relationship: 
         * POLB_MT004200CA.Specimen.sequenceNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Order in which 
         * the specimen is to appear in the message.</p> Un-merged 
         * Business Name: SpecimenSequenceNumber Relationship: 
         * POLB_MT004000CA.Specimen.sequenceNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Specifies the 
         * order in which the specimen is to appear in the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sequenceNumber"})]
        public int? SequenceNumber {
            get { return this.sequenceNumber.Value; }
            set { this.sequenceNumber.Value = value; }
        }

    }

}