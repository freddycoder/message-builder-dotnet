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
 * Last modified: $LastChangedDate: 2011-05-04 15:47:15 -0400 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Replaces</summary>
     * 
     * <remarks>MFMI_MT700716CA.ReplacementOf: replaces 
     * <p>Associates a new registration which is intended to 
     * replace a registration received prior to this message.</p> 
     * <p>Supports this message &quot;replacing&quot; a prior 
     * registration with a current regsitration (merges).</p> 
     * MFMI_MT700726CA.ReplacementOf: replaces <p>Associates a new 
     * registration which is intended to replace a registration 
     * received prior to this message.</p> <p>Supports this message 
     * &quot;replacing&quot; a prior registration with a current 
     * regsitration (merges).</p> MFMI_MT700746CA.ReplacementOf: 
     * replaces <p>Associates a new registration which is intended 
     * to replace a registration received prior to this 
     * message.</p> <p>Supports this message &quot;replacing&quot; 
     * a prior registration with a current regsitration 
     * (merges).</p> MFMI_MT700711CA.ReplacementOf: replaces 
     * <p>Associates a new registration which is intended to 
     * replace a registration received prior to this message.</p> 
     * <p>Supports this message &quot;replacing&quot; a prior 
     * registration with a current regsitration (merges).</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MFMI_MT700711CA.ReplacementOf","MFMI_MT700716CA.ReplacementOf","MFMI_MT700726CA.ReplacementOf","MFMI_MT700746CA.ReplacementOf"})]
    public class Replaces : MessagePartBean {

        private BL contextConductionInd;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged.PriorRegistrationEvent priorRegistration;

        public Replaces() {
            this.contextConductionInd = new BLImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MFMI_MT700716CA.ReplacementOf.contextConductionInd 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MFMI_MT700726CA.ReplacementOf.contextConductionInd 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MFMI_MT700746CA.ReplacementOf.contextConductionInd 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MFMI_MT700711CA.ReplacementOf.contextConductionInd 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"contextConductionInd"})]
        public bool? ContextConductionInd {
            get { return this.contextConductionInd.Value; }
            set { this.contextConductionInd.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * MFMI_MT700716CA.ReplacementOf.priorRegistration 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MFMI_MT700726CA.ReplacementOf.priorRegistration 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MFMI_MT700746CA.ReplacementOf.priorRegistration 
         * Conformance/Cardinality: POPULATED (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MFMI_MT700711CA.ReplacementOf.priorRegistration 
         * Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"priorRegistration"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Common.Merged.PriorRegistrationEvent PriorRegistration {
            get { return this.priorRegistration; }
            set { this.priorRegistration = value; }
        }

    }

}