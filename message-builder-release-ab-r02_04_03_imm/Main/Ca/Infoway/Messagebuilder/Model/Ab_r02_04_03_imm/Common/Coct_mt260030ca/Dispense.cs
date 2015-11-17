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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt260030ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Dispense</summary>
     * 
     * <p>Used when the issue pertains to the supply of the drug 
     * rather than the drug itself. E.g. Duplicate pharmacy, refill 
     * too soon, etc.</p> <p>Indicates a particular dispense event 
     * that resulted in the issue.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT260030CA.SupplyEvent"})]
    public class Dispense : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt260030ca.ICausalActs {

        private II id;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt260030ca.Dispensed product;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.DispensedAt location;

        public Dispense() {
            this.id = new IIImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
        }
        /**
         * <summary>Business Name: A:Prescription Dispense Number</summary>
         * 
         * <remarks>Relationship: COCT_MT260030CA.SupplyEvent.id 
         * Conformance/Cardinality: REQUIRED (1) <p>Allows provider to 
         * drill down and retrieve additional information about the 
         * dispense event for consideration in their issue management 
         * decision.</p> <p>Unique identifier of the dispensed event 
         * that triggered the issue.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: B:Dispense Status</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT260030CA.SupplyEvent.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Important in 
         * understanding what medication the patient actually has on 
         * hand, thus the attribute is mandatory. May also influence 
         * the ability of a different pharmacy to dispense the 
         * medication.</p> <p>Indicates the status of the dispense 
         * record created on the EHR/DIS. If 'Active' it means that the 
         * dispense has been processed but not yet given to the 
         * patient. If 'Complete', it indicates that the medication has 
         * been delivered to the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: B:Dispensed Date</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT260030CA.SupplyEvent.effectiveTime 
         * Conformance/Cardinality: REQUIRED (1) <p>ZDU.4.5</p> 
         * <p>Allows evaluation of 'refill too soon' and similar 
         * issues.</p><p>Attribute is marked as &quot;populated&quot; 
         * as a dispense record may not exist without processing 
         * date.</p> <p>Applications should specify a null flavor of 
         * &quot;Not Applicable&quot; for dispenses that have not yet 
         * been picked up.</p> <p>The date and time on which the 
         * product was issued to the patient.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: C:Dispense Masking Indicator</summary>
         * 
         * <remarks>Relationship: 
         * COCT_MT260030CA.SupplyEvent.confidentialityCode 
         * Conformance/Cardinality: OPTIONAL (0-2) <p>Conveys the 
         * patient's wishes relating to the sensitivity of the drug 
         * information.</p><p>The attribute is optional because not all 
         * systems will support masking.</p> <p>An indication of 
         * sensitivity surrounding the related drug, and thus defines 
         * the required sensitivity for the detected issue.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_BasicConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_BasicConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: COCT_MT260030CA.SupplyEvent.product</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"product"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Coct_mt260030ca.Dispensed Product {
            get { return this.product; }
            set { this.product = value; }
        }

        /**
         * <summary>Relationship: COCT_MT260030CA.SupplyEvent.location</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"location"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.DispensedAt Location {
            get { return this.location; }
            set { this.location = value; }
        }

    }

}