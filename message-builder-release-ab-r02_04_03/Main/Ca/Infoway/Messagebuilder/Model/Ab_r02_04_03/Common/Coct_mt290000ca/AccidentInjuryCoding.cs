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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Coct_mt290000ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Domainvalue;


    /**
     * <summary>Business Name: Accident Injury coding</summary>
     * 
     * <p>Accident Information</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT290000CA.AccidentInjuryCoding"})]
    public class AccidentInjuryCoding : MessagePartBean {

        private CV code;
        private CV value;
        private CV targetSiteCode;

        public AccidentInjuryCoding() {
            this.code = new CVImpl();
            this.value = new CVImpl();
            this.targetSiteCode = new CVImpl();
        }
        /**
         * <summary>Business Name: Observation Injury type</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT290000CA.AccidentInjuryCoding.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Injury Type</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ObservationInjuryType Code {
            get { return (ObservationInjuryType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: Injury code</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT290000CA.AccidentInjuryCoding.value 
         * Conformance/Cardinality: MANDATORY (1) <p>Nature of 
         * Injury</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public InjuryObservationValue Value {
            get { return (InjuryObservationValue) this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Business Name: Act Injury Site</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT290000CA.AccidentInjuryCoding.targetSiteCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Body Part + 
         * modifier = Side of Body</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"targetSiteCode"})]
        public InjuryActSite TargetSiteCode {
            get { return (InjuryActSite) this.targetSiteCode.Value; }
            set { this.targetSiteCode.Value = value; }
        }

    }

}