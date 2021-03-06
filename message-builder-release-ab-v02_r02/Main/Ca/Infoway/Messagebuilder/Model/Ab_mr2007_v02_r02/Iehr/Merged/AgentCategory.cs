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
namespace Ca.Infoway.Messagebuilder.Model.Ab_mr2007_v02_r02.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: AgentCategory</summary>
     * 
     * <remarks>REPC_MT000006CA.MaterialKind: Agent Category 
     * <p>Category of material or agent to which the patient was 
     * exposed.</p> <p>Allows exposed materials or agents to be 
     * collectively referenced.</p> REPC_MT000005CA.MaterialKind: 
     * Agent Category <p>Category of material or agent to which the 
     * patient was exposed.</p> <p>Allows exposed materials or 
     * agents to be collectively referenced.</p> 
     * REPC_MT000009CA.MaterialKind: Agent Category <p>Category of 
     * material or agent to which the patient was exposed.</p> 
     * <p>Allows exposed materials or agents to be collectively 
     * referenced.</p> REPC_MT000013CA.MaterialKind: Agent Category 
     * <p>Category of material or agent to which the patient was 
     * exposed.</p> <p>Allows exposed materials or agents to be 
     * collectively referenced.</p> REPC_MT000001CA.MaterialKind: 
     * Agent Category <p>Category of material or agent to which the 
     * patient was exposed.</p> <p>Allows exposed materials or 
     * agents to be collectively referenced.</p> 
     * REPC_MT000012CA.MaterialKind: Agent Category <p>Category of 
     * material or agent to which the patient was exposed.</p> 
     * <p>Allows exposed materials or agents to be collectively 
     * referenced.</p> REPC_MT000002CA.MaterialKind: Agent Category 
     * <p>Category of material or agent to which the patient was 
     * exposed.</p> <p>Allows exposed materials or agents to be 
     * collectively referenced.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT000001CA.MaterialKind","REPC_MT000002CA.MaterialKind","REPC_MT000005CA.MaterialKind","REPC_MT000006CA.MaterialKind","REPC_MT000009CA.MaterialKind","REPC_MT000012CA.MaterialKind","REPC_MT000013CA.MaterialKind"})]
    public class AgentCategory : MessagePartBean {

        private CV code;
        private ST name;

        public AgentCategory() {
            this.code = new CVImpl();
            this.name = new STImpl();
        }
        /**
         * <summary>Business Name: ExposedMaterialType</summary>
         * 
         * <remarks>Un-merged Business Name: ExposedMaterialType 
         * Relationship: REPC_MT000006CA.MaterialKind.code 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates the type 
         * of agent that the patient was exposed to which caused the 
         * adverse reaction. This includes Drug, Food, Latex, Dust, 
         * etc.</p> <p>Allows different kinds of reaction agents to be 
         * distinguished. Coding strength is set to CWE because the 
         * exposure agent type may not always be codified. The 
         * attribute is populated because there is little point in 
         * communicating about the exposure to an agent if it is not 
         * known what the agent is, however it may not always be 
         * coded.</p> Un-merged Business Name: ExposedMaterialType 
         * Relationship: REPC_MT000005CA.MaterialKind.code 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates the type 
         * of agent that the patient was exposed to which caused the 
         * adverse reaction. This includes Drug, Food, Latex, Dust, 
         * etc.</p> <p>Allows different kinds of reaction agents to be 
         * distinguished. Coding strength is set to CWE because the 
         * exposure agent type may not always be codified. The 
         * attribute is populated because there is little point in 
         * communicating about the exposure to an agent if it is not 
         * known what the agent is, however it may not always be 
         * coded.</p> Un-merged Business Name: ExposedMaterialType 
         * Relationship: REPC_MT000009CA.MaterialKind.code 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates the type 
         * of agent that the patient was exposed to which caused the 
         * adverse reaction. This includes Drug, Food, Latex, Dust, 
         * etc.</p> <p>Allows different kinds of reaction agents to be 
         * distinguished. Coding strength is set to CWE because the 
         * exposure agent type may not always be codified. The 
         * attribute is populated because there is little point in 
         * communicating about the exposure to an agent if it is not 
         * known what the agent is, however it may not always be 
         * coded.</p> Un-merged Business Name: ExposedMaterialType 
         * Relationship: REPC_MT000001CA.MaterialKind.code 
         * Conformance/Cardinality: POPULATED (1) <p>Indicates the type 
         * of agent that the patient was exposed to which caused the 
         * adverse reaction. This includes Drug, Food, Latex, Dust, 
         * etc.</p> <p>Allows different kinds of reaction agents to be 
         * distinguished. Coding strength is set to CWE because the 
         * exposure agent type may not always be codified. The 
         * attribute is populated because there is little point in 
         * communicating about the exposure to an agent if it is not 
         * known what the agent is, however it may not always be coded. 
         * Also, the code may sometimes be masked, in which case a 
         * &quot;null flavor&quot; must be specified.</p> Un-merged 
         * Business Name: ExposedMaterialType Relationship: 
         * REPC_MT000013CA.MaterialKind.code Conformance/Cardinality: 
         * POPULATED (1) <p>Indicates the type of agent that the 
         * patient was exposed to which caused the adverse reaction. 
         * This includes Drug, Food, Latex, Dust, etc.</p> <p>Allows 
         * different kinds of reaction agents to be distinguished. 
         * Coding strength is set to CWE because the exposure agent 
         * type may not always be codified. The attribute is populated 
         * because there is little point in communicating about the 
         * exposure to an agent if it is not known what the agent is, 
         * however it may not always be coded.</p> Un-merged Business 
         * Name: ExposedMaterialType Relationship: 
         * REPC_MT000012CA.MaterialKind.code Conformance/Cardinality: 
         * POPULATED (1) <p>Indicates the type of agent that the 
         * patient was exposed to which caused the adverse reaction. 
         * This includes Drug, Food, Latex, Dust, etc.</p> <p>Allows 
         * different kinds of reaction agents to be distinguished. 
         * Coding strength is set to CWE because the exposure agent 
         * type may not always be codified. The attribute is populated 
         * because there is little point in communicating about the 
         * exposure to an agent if it is not known what the agent is, 
         * however it may not always be coded.</p> Un-merged Business 
         * Name: ExposedMaterialType Relationship: 
         * REPC_MT000002CA.MaterialKind.code Conformance/Cardinality: 
         * POPULATED (1) <p>Indicates the type of agent that the 
         * patient was exposed to which caused the adverse reaction. 
         * This includes Drug, Food, Latex, Dust, etc.</p> <p>Allows 
         * different kinds of reaction agents to be distinguished. 
         * Coding strength is set to CWE because the exposure agent 
         * type may not always be codified. The attribute is populated 
         * because there is little point in communicating about the 
         * exposure to an agent if it is not known what the agent is, 
         * however it may not always be coded. Also, the code may 
         * sometimes be masked, in which case a &quot;null flavor&quot; 
         * must be specified.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ExposureAgentEntityType Code {
            get { return (ExposureAgentEntityType) this.code.Value; }
            set { this.code.Value = value; }
        }

        /**
         * <summary>Business Name: ExposedMaterialName</summary>
         * 
         * <remarks>Un-merged Business Name: ExposedMaterialName 
         * Relationship: REPC_MT000006CA.MaterialKind.name 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Indicates the 
         * name of the agent identified by MaterialKind.code</p> 
         * <p>Provides a human-readable name in circumstances where the 
         * agent is captured as code.</p> Un-merged Business Name: 
         * ExposedMaterialName Relationship: 
         * REPC_MT000012CA.MaterialKind.name Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Indicates the name of the agent identified 
         * by MaterialKind.code.</p> <p>Proivdes a human-readable name 
         * in circumstances where the agent is captured as a code.</p> 
         * Un-merged Business Name: ExposedMaterialName Relationship: 
         * REPC_MT000002CA.MaterialKind.name Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Indicates the name of the agent identified 
         * by MaterialKind.code</p> <p>Provides a human-readable name 
         * in circumstances where the agent is captured as a code.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public String Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

    }

}