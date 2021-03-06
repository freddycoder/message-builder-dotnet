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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Pharmacy.Porx_mt040020ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Other Medication</summary>
     * 
     * <p>routeCode must not be used when code is SNOMED and is 
     * mandatory otherwise</p> <p>While SNOMED codes may 
     * pre-coordinate the drug code, the drug must not be modified. 
     * However route information for a drug may be updated.</p> 
     * <p>The medication record being updated.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"PORX_MT040020CA.OtherMedication"})]
    public class OtherMedication : MessagePartBean {

        private II id;
        private CD code;
        private CS statusCode;
        private IVL<TS, Interval<PlatformDate>> effectiveTime;
        private SET<CV, Code> confidentialityCode;
        private CV routeCode;

        public OtherMedication() {
            this.id = new IIImpl();
            this.code = new CDImpl();
            this.statusCode = new CSImpl();
            this.effectiveTime = new IVLImpl<TS, Interval<PlatformDate>>();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
            this.routeCode = new CVImpl();
        }
        /**
         * <summary>Business Name: A:Other Medication Id</summary>
         * 
         * <remarks>Relationship: PORX_MT040020CA.OtherMedication.id 
         * Conformance/Cardinality: MANDATORY (1) <p>Identifier of the 
         * Other Medication record that needs to be updated.</p> 
         * <p>Uniquely identifies the record to be updated and is 
         * therefore mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: Other Medication Type</summary>
         * 
         * <remarks>Relationship: PORX_MT040020CA.OtherMedication.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Must be 'DRUG' 
         * unless using SNOMED</p> <p>Indicates that the record is a 
         * drug administration rather than an immunization or other 
         * type of administration. For SNOMED, may also include route, 
         * drug and other information.</p> <p>Needed to convey the 
         * meaning of this class and is therefore mandatory.</p><p>The 
         * element allows 'CD' to provide support for SNOMED.</p> 
         * <p>Needed to convey the meaning of this class and is 
         * therefore mandatory.</p><p>The element allows 'CD' to 
         * provide support for SNOMED.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActCode Code {
            get { return (ActCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: B:Medication Status</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040020CA.OtherMedication.statusCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Indicates whether 
         * the medication is still considered active.</p><p>Valid 
         * status can only be 'ACTIVE' or 'COMPLETED'.</p> <p>Indicates 
         * whether the medication is still considered 
         * active.</p><p>Valid status can only be 'ACTIVE' or 
         * 'COMPLETED'.</p> <p>Indicates the new state of the 
         * medication and is therefore mandatory.</p><p>Note ------ The 
         * provider might know that the patient is not taking the 
         * medication but not necessarily when the patient stopped it. 
         * Thus the status of the medication could be set to 
         * 'COMPLETED' by the provider without necessarily setting an 
         * End Date on the medication record.</p> <p>Indicates the new 
         * state of the medication and is therefore 
         * mandatory.</p><p>Note ------ The provider might know that 
         * the patient is not taking the medication but not necessarily 
         * when the patient stopped it. Thus the status of the 
         * medication could be set to 'COMPLETED' by the provider 
         * without necessarily setting an End Date on the medication 
         * record.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"statusCode"})]
        public ActStatus StatusCode {
            get { return (ActStatus) this.statusCode.Value; }
            set { this.statusCode.Value = value; }
        }

        /**
         * <summary>Business Name: C:Drug Active Period</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040020CA.OtherMedication.effectiveTime 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The new period in 
         * which the active medication is deemed to be active.</p> 
         * <p>Allows the drug active period information to be 
         * changed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"effectiveTime"})]
        public Interval<PlatformDate> EffectiveTime {
            get { return this.effectiveTime.Value; }
            set { this.effectiveTime.Value = value; }
        }

        /**
         * <summary>Business Name: E:Other Medication Masking 
         * Indicators</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040020CA.OtherMedication.confidentialityCode 
         * Conformance/Cardinality: REQUIRED (0-2) <p>Taboo allows the 
         * provider to request restricted access to patient or their 
         * care giver.</p><p>Constraint: Can&#226;&#128;&#153;t have 
         * both normal and one of the other codes simultaneously.</p> 
         * <p>Taboo allows the provider to request restricted access to 
         * patient or their care giver.</p><p>Constraint: 
         * Can&#226;&#128;&#153;t have both normal and one of the other 
         * codes simultaneously.</p> <p>Taboo allows the provider to 
         * request restricted access to patient or their care 
         * giver.</p><p>Constraint: Can&#226;&#128;&#153;t have both 
         * normal and one of the other codes simultaneously.</p> 
         * <p>Taboo allows the provider to request restricted access to 
         * patient or their care giver.</p><p>Constraint: 
         * Can&#226;&#128;&#153;t have both normal and one of the other 
         * codes simultaneously.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_NormalRestrictedTabooConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_NormalRestrictedTabooConfidentialityKind>(); }
        }

        /**
         * <summary>Business Name: D:Route</summary>
         * 
         * <remarks>Relationship: 
         * PORX_MT040020CA.OtherMedication.routeCode 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>This is the means 
         * by which the patient is taking the other medication.</p> 
         * <p>Ensures consistency in description of routes. Provides 
         * potential for cross-checking dosage form and route. Because 
         * this information is pre-coordinated into 'code' for SNOMED, 
         * it is marked as optional.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"routeCode"})]
        public RouteOfAdministration RouteCode {
            get { return (RouteOfAdministration) this.routeCode.Value; }
            set { this.routeCode.Value = value; }
        }

    }

}