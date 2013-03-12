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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Ra.Comt_mt400001ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"COMT_MT400001CA.Role"})]
    public class Role : MessagePartBean {

        private CV playingEntityKindCode;

        public Role() {
            this.playingEntityKindCode = new CVImpl();
        }
        /**
         * <summary>Business Name: Maskable Material</summary>
         * 
         * <remarks>Relationship: COMT_MT400001CA.EntityKind.code 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows masking a 
         * drug, avoiding the requirement to mask each prescription and 
         * dispense individually.</p> <p>Usually specified at the 
         * generic or therapeutic-equivalent level to ensure related 
         * medications are also covered.</p> <p>Indicates the materia 
         * (e.g drug) whose associated records should be masked.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"playingEntityKind/code"})]
        public MaskableMaterialEntityType PlayingEntityKindCode {
            get { return (MaskableMaterialEntityType) this.playingEntityKindCode.Value; }
            set { this.playingEntityKindCode.Value = value; }
        }

    }

}