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
namespace Ca.Infoway.Messagebuilder.Model.Sk_cerx_v01_r04_2.Pharmacy.Porx_mt980040ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Administration Precondition</summary>
     * 
     * <p>This sets the conditions for which a specific 
     * administration of the drug may be undertaken. Example: if 
     * headache persists for 2hrs or more 'take 2 tabs.</p> 
     * <p>Indicates that prescription is a 'PRN' (as needed) 
     * prescription and that doses to be consumed cannot be 
     * accurately calculated. This has important compliance 
     * implications.</p> <p>To flag a prescription as PRN without 
     * specifying a condition, include the association but specify 
     * a null flavor for the Dosage Condition.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT980040CA.ActEventCriterion"})]
    public class AdministrationPrecondition : MessagePartBean {

        private ST text;

        public AdministrationPrecondition() {
            this.text = new STImpl();
        }
        /**
         * <summary>Business Name: A:Dosage Condition</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT980040CA.ActEventCriterion.text 
         * Conformance/Cardinality: MANDATORY (1) <p>A free-form 
         * textual description of condition that must be met before the 
         * product may be administered to/by the 
         * patient.</p><p>Example: When pressure exceeds 150/90 - Take 
         * 2 tabs</p> <p>A free-form textual description of condition 
         * that must be met before the product may be administered 
         * to/by the patient.</p><p>Example: When pressure exceeds 
         * 150/90 - Take 2 tabs</p> <p>RepeatPattern.prn (true when 
         * present)</p><p>ZDP.13.6 (true when 
         * present)</p><p>ZDP.13.7</p> <p>RepeatPattern.prn (true when 
         * present)</p><p>ZDP.13.6 (true when 
         * present)</p><p>ZDP.13.7</p> <p>RepeatPattern.prn (true when 
         * present)</p><p>ZDP.13.6 (true when 
         * present)</p><p>ZDP.13.7</p> <p>Allows un-coded 
         * specifications of conditions in which the medication should 
         * be taken.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"text"})]
        public String Text {
            get { return this.text.Value; }
            set { this.text.Value = value; }
        }

    }

}