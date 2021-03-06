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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Si.Comt_mt400001ca {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: Maskable Record</summary>
     * 
     * <p>A particular record or type of record for which masking 
     * is supported.</p> <p>The root construct for masking and 
     * unmasking specific record or type of record.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COMT_MT400001CA.MaskableActType"})]
    public class MaskableRecord : MessagePartBean {

        private II id;
        private CV code;
        private SET<CV, Code> confidentialityCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Si.Comt_mt400001ca.Role directTargetRole;
        private Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Si.Comt_mt400001ca.Diagnosis reasonDiagnosis;

        public MaskableRecord() {
            this.id = new IIImpl();
            this.code = new CVImpl();
            this.confidentialityCode = new SETImpl<CV, Code>(typeof(CVImpl));
        }
        /**
         * <summary>Business Name: C:Record Identifier</summary>
         * 
         * <remarks>Relationship: COMT_MT400001CA.MaskableActType.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>The identifier of 
         * the prescription, dispense, allergy, lab test result or 
         * other record for which the masking status is being 
         * changed.</p> <p>Allows unique reference to a particular 
         * record to be masked or unmasked.</p> <p>In many systems, 
         * masking a 'child' may result in automatic masking of the 
         * parent. For example, masking a dispense record may cause the 
         * prescription to become masked as well.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: B:Record Type</summary>
         * 
         * <remarks>Relationship: COMT_MT400001CA.MaskableActType.code 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates a 
         * detailed type of record to be masked. E.g. All lab tests of 
         * a given type.</p> <p>Allows automatic masking of a 
         * particular type of record rather than requiring each 
         * occurrence to be masked individually.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActInformationCategoryCode Code {
            get { return (ActInformationCategoryCode) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: A:Masked Indicator</summary>
         * 
         * <remarks>Relationship: 
         * COMT_MT400001CA.MaskableActType.confidentialityCode 
         * Conformance/Cardinality: MANDATORY (1-2) <p>Indicates the 
         * new value for the masking status of the item.</p> <p>Forces 
         * the sender of the message to assert what the new value 
         * should be, rather than performing a 'toggle' and potentially 
         * ending up in the wrong state. Therefore, the attribute is 
         * mandatory.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"confidentialityCode"})]
        public ICollection<x_NormalRestrictedTabooConfidentialityKind> ConfidentialityCode {
            get { return this.confidentialityCode.RawSet<x_NormalRestrictedTabooConfidentialityKind>(); }
        }

        /**
         * <summary>Relationship: COMT_MT400001CA.DirectTarget.role</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"directTarget/role"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Si.Comt_mt400001ca.Role DirectTargetRole {
            get { return this.directTargetRole; }
            set { this.directTargetRole = value; }
        }

        /**
         * <summary>Relationship: COMT_MT400001CA.Reason.diagnosis</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"reason/diagnosis"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Si.Comt_mt400001ca.Diagnosis ReasonDiagnosis {
            get { return this.reasonDiagnosis; }
            set { this.reasonDiagnosis = value; }
        }

    }

}