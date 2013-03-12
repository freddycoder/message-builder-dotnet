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
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT010110CA.SupplementalFillInformation","PORX_MT060040CA.SupplementalFillInformation"})]
    public class SupplementalFillInformation : MessagePartBean {

        private CS classCode;
        private CS moodCode;
        private INT repeatNumber;
        private INT quantity;

        public SupplementalFillInformation() {
            this.classCode = new CSImpl();
            this.moodCode = new CSImpl();
            this.repeatNumber = new INTImpl();
            this.quantity = new INTImpl();
        }
        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010110CA.SupplementalFillInformation.classCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.SupplementalFillInformation.classCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"classCode"})]
        public ActClass ClassCode {
            get { return (ActClass) this.classCode.Value; }
            set { this.classCode.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT010110CA.SupplementalFillInformation.moodCode 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * PORX_MT060040CA.SupplementalFillInformation.moodCode 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"moodCode"})]
        public ActMood MoodCode {
            get { return (ActMood) this.moodCode.Value; }
            set { this.moodCode.Value = value; }
        }

        /**
         * <summary>Business Name: NumberOfFills</summary>
         * 
         * <remarks>Un-merged Business Name: NumberOfFills 
         * Relationship: 
         * PORX_MT010110CA.SupplementalFillInformation.repeatNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A prescription 
         * can authorize multiple fills.</p> <p>Allows the prescriber 
         * to specify the number of fills authorized by this 
         * prescription.</p> Un-merged Business Name: NumberOfFills 
         * Relationship: 
         * PORX_MT060040CA.SupplementalFillInformation.repeatNumber 
         * Conformance/Cardinality: REQUIRED (0-1) <p>A prescription 
         * can authorize multiple fills.</p> <p>Allows the prescriber 
         * to specify the number of fills authorized by this 
         * prescription.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"repeatNumber"})]
        public int? RepeatNumber {
            get { return this.repeatNumber.Value; }
            set { this.repeatNumber.Value = value; }
        }

        /**
         * <summary>Business Name: FillQuantity</summary>
         * 
         * <remarks>Un-merged Business Name: FillQuantity Relationship: 
         * PORX_MT010110CA.SupplementalFillInformation.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The prescription 
         * is usually authorized for a specific quantity for each 
         * fill.</p> <p>Specifies the quantity for each fill.</p> 
         * Un-merged Business Name: FillQuantity Relationship: 
         * PORX_MT060040CA.SupplementalFillInformation.quantity 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The prescription 
         * is usually authorized for a specific quantity for each 
         * fill.</p> <p>Specifies the quantity for each fill.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"quantity"})]
        public int? Quantity {
            get { return this.quantity.Value; }
            set { this.quantity.Value = value; }
        }

    }

}