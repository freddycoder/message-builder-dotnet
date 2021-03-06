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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Iehr.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"REPC_MT410001CA.ActDefinition","REPC_MT410003CA.ActDefinition","REPC_MT420001CA.ActDefinition","REPC_MT420003CA.ActDefinition","REPC_MT610001CA.ActDefinition","REPC_MT610002CA.ActDefinition"})]
    public class ActDefinition : MessagePartBean {

        private II id;

        public ActDefinition() {
            this.id = new IIImpl();
        }
        /**
         * <summary>Business Name: ProtocolIds</summary>
         * 
         * <remarks>Un-merged Business Name: ProtocolIds Relationship: 
         * REPC_MT610001CA.ActDefinition.id Conformance/Cardinality: 
         * MANDATORY (1) <p> <i>Allows linking together a series of 
         * observations, procedures, drug administrations and other 
         * clinical actions as part of a particular protocol. Useful in 
         * clinical studies and may also provide context around why the 
         * action was performed. The element also allows providers to 
         * filter searches to only expose data related to a particular 
         * protocol.</i> </p><p> <i>This element is optional because 
         * the use of and need to reference protocols will not apply to 
         * all healthcare providers. PoS applications should choose 
         * whether to support the element based on the perceived needs 
         * of their client base.</i> </p> <p> <i>Indicates that the 
         * action described by the Professional Service record was 
         * performed as part of a particular protocol.</i> </p> 
         * Un-merged Business Name: ProtocolIds Relationship: 
         * REPC_MT410003CA.ActDefinition.id Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: ProtocolIds 
         * Relationship: REPC_MT420001CA.ActDefinition.id 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Allows linking 
         * together a series of observations, procedures, drug 
         * administrations and other clinical actions as part of a 
         * particular protocol. Useful in clinical studies and may also 
         * provide context around why the action was performed. The 
         * element also allows providers to filter searches to only 
         * expose data related to a particular protocol.</i> </p><p> 
         * <i>This element is optional because the use of and need to 
         * reference protocols will not apply to all healthcare 
         * providers. PoS applications should choose whether to support 
         * the element based on the perceived needs of their client 
         * base.</i> </p> <p> <i>Indicates that the action described by 
         * the Coded Observation record was performed as part of a 
         * particular protocol.</i> </p> Un-merged Business Name: 
         * ProtocolIds Relationship: REPC_MT420003CA.ActDefinition.id 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Allows linking 
         * together a series of observations, procedures, drug 
         * administrations and other clinical actions as part of a 
         * particular protocol. Useful in clinical studies and may also 
         * provide context around why the action was performed. The 
         * element also allows providers to filter searches to only 
         * expose data related to a particular protocol.</i> </p><p> 
         * <i>This element is optional because the use of and need to 
         * reference protocols will not apply to all healthcare 
         * providers. PoS applications should choose whether to support 
         * the element based on the perceived needs of their client 
         * base.</i> </p> <p> <i>Indicates that the action described by 
         * the Coded Observation record was performed as part of a 
         * particular protocol.</i> </p> Un-merged Business Name: 
         * ProtocolIds Relationship: REPC_MT410001CA.ActDefinition.id 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Allows linking 
         * together a series of observations, procedures, drug 
         * administrations and other clinical actions as part of a 
         * particular protocol. Useful in clinical studies and may also 
         * provide context around why the action was performed. The 
         * element also allows providers to filter searches to only 
         * expose data related to a particular protocol.</i> </p><p> 
         * <i>This element is optional because the use of and need to 
         * reference protocols will not apply to all healthcare 
         * providers. PoS applications should choose whether to support 
         * the element based on the perceived needs of their client 
         * base.</i> </p> <p> <i>Indicates that the action described by 
         * the Measured Observation record was performed as part of a 
         * particular protocol.</i> </p> Un-merged Business Name: 
         * ProtocolIds Relationship: REPC_MT610002CA.ActDefinition.id 
         * Conformance/Cardinality: MANDATORY (1) <p> <i>Allows linking 
         * together a series of observations, procedures, drug 
         * administrations and other clinical actions as part of a 
         * particular protocol. Useful in clinical studies and may also 
         * provide context around why the action was performed. The 
         * element also allows providers to filter searches to only 
         * expose data related to a particular protocol.</i> </p><p> 
         * <i>This element is optional because the use of and need to 
         * reference protocols will not apply to all healthcare 
         * providers. PoS applications should choose whether to support 
         * the element based on the perceived needs of their client 
         * base.</i> </p> <p> <i>Indicates that the action described by 
         * the Professional Service record was performed as part of a 
         * particular protocol.</i> </p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

    }

}