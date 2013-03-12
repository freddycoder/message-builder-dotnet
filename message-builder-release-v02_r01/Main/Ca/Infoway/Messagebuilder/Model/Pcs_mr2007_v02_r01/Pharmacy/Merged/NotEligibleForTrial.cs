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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r01.Pharmacy.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: NotEligibleForTrial</summary>
     * 
     * <remarks>PORX_MT060340CA.Component2: G:not eligible for 
     * Trial? <p>Serves as reminder for dispenser to consider 
     * option of part-filling. In some jurisdictions, the 
     * prescription must be so designated by the prescriber for the 
     * dispenser to do trial dispensing.</p> <p>Indicates that a 
     * prescription is part of a Trial Program.</p> 
     * PORX_MT060160CA.Component2: G:Not eligible for Trial? 
     * <p>Serves as reminder for dispenser to consider option of 
     * part-filling. In some jurisdictions, the prescription must 
     * be so designated by the prescriber for the dispenser to do 
     * trial dispensing.</p><p>The element is mandatory because 
     * eligibility must be either true or false.</p> <p>Indicates 
     * that a prescription is part of a Trial Program.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT060160CA.Component2","PORX_MT060340CA.Component2"})]
    public class NotEligibleForTrial : MessagePartBean {

        private BL negationInd;

        public NotEligibleForTrial() {
            this.negationInd = new BLImpl();
        }
        /**
         * <summary>Business Name: NotEligibleForTrial</summary>
         * 
         * <remarks>Un-merged Business Name: NotEligibleForTrial 
         * Relationship: PORX_MT060340CA.Component2.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>May affect 
         * dispensers' discretion to dispense anything other than 
         * prescribed fill quantity.</p><p>Expressed as 
         * 'Non-Eligibility' rather than 'Eligibility' due to 
         * restrictions in HL7 modeling.</p><p>The attribute is 
         * mandatory because it must be known whether trials are 
         * allowed or not.</p> <p>An indication that a prescription is 
         * or is not eligible for trial dispensing from a clinical (not 
         * financial) perspective. False = Eligible, True = Not 
         * Eligible.</p> Un-merged Business Name: NotEligibleForTrial 
         * Relationship: PORX_MT060160CA.Component2.negationInd 
         * Conformance/Cardinality: MANDATORY (1) <p>May affect 
         * dispensers' discretion to dispense anything other than 
         * prescribed fill quantity.</p><p>Expressed as 
         * 'Non-Eligibility' rather than 'Eligibility' due to 
         * restrictions in HL7 modeling.</p><p>The attribute is 
         * mandatory as it must be known whether it is true or 
         * false.</p> <p>An indication that a prescription is or is not 
         * eligible for trial dispensing from a clinical (not 
         * financial) perspective. False = Eligible, True = Not 
         * Eligible.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"negationInd"})]
        public bool? NegationInd {
            get { return this.negationInd.Value; }
            set { this.negationInd.Value = value; }
        }

    }

}