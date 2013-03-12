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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Lab.Polb_mt004200ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Report Section Observation</summary>
     * 
     * <p>Any report sections reported at the header or report 
     * level (not specific to a specimen or diagnosis).</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"POLB_MT004200CA.ReportLevelObservationEvent"})]
    public class ReportSectionObservation : MessagePartBean {

        private II id;
        private CD code;
        private ST text;
        private TS effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private ANY<object> value;

        public ReportSectionObservation() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.text = new STImpl();
            this.effectiveTime = new TSImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.value = new ANYImpl<object>();
        }
        /**
         * <summary>Business Name: Section Identifier</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.ReportLevelObservationEvent.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Unique identifier 
         * for a section of the report at the ObservationReport 
         * level.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Report Section Observation Type</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.ReportLevelObservationEvent.code 
         * Conformance/Cardinality: POPULATED (1) <p>Specifies the type 
         * of report section.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public SectionHeadingObservationCode Code {
            get { return (SectionHeadingObservationCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Note Type</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.ReportLevelObservationEvent.text 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Type of comment 
         * or note.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

        /**
         * <summary>Business Name: Report Section Observation Date/Time</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.ReportLevelObservationEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The date/time 
         * this report section was &quot;reported&quot;.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public PlatformDate EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: Result Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.ReportLevelObservationEvent.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: Report Section Observation Value</summary>
         * 
         * <remarks>Relationship: 
         * POLB_MT004200CA.ReportLevelObservationEvent.value 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The report 
         * section values - usually this is text-based. If a coded 
         * value applies, values must be selected from the 
         * SectionHeadingObservationValue Concept Domain.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public object Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

    }

}