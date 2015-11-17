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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: Manufacturer</summary>
     * 
     * <remarks>COCT_MT220210CA.Manufacturer: Manufacturer 
     * <p>Useful in distinguishing and grouping drug products</p> 
     * <p>Identity of the organization that manufactured the drug 
     * product.</p> POIZ_MT061150AB.Manufacturer: Manufacturer 
     * <p>Useful in distinguishing and grouping drug products</p> 
     * <p>Identity of the organization that manufactured the drug 
     * product.</p> POIZ_MT060150AB.Manufacturer: Manufacturer 
     * <p>Useful in distinguishing and grouping drug products</p> 
     * <p>Identity of the organization that manufactured the drug 
     * product.</p> COCT_MT220110CA.Manufacturer: Manufacturer 
     * <p>Useful in distinguishing and grouping drug products</p> 
     * <p>Identity of the organization that manufactured the drug 
     * product.</p> POIZ_MT030060AB.Manufacturer: Manufacturer 
     * <p>Useful in distinguishing and grouping drug products</p> 
     * <p>Identity of the organization that manufactured the drug 
     * product.</p> POIZ_MT030050AB.Manufacturer: Manufacturer 
     * <p>Useful in distinguishing and grouping drug products</p> 
     * <p>Identity of the organization that manufactured the drug 
     * product.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"COCT_MT220110CA.Manufacturer","COCT_MT220210CA.Manufacturer","POIZ_MT030050AB.Manufacturer","POIZ_MT030060AB.Manufacturer","POIZ_MT060150AB.Manufacturer","POIZ_MT061150AB.Manufacturer"})]
    public class Manufacturer : MessagePartBean {

        private II id;
        private ST name;

        public Manufacturer() {
            this.id = new IIImpl();
            this.name = new STImpl();
        }
        /**
         * <summary>Un-merged Business Name: ManufacturerId</summary>
         * 
         * <remarks>Relationship: COCT_MT220210CA.Manufacturer.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows sending of 
         * identifiers in place of manufacturer name. May be used in 
         * drug search where specific manufacturer is a criterion.</p> 
         * <p>An identifier denoting a specific drug manufacturer.</p> 
         * Un-merged Business Name: ManufacturerID Relationship: 
         * POIZ_MT061150AB.Manufacturer.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows sending of identifiers in place of 
         * manufacturer name. May be used in drug search where specific 
         * manufacturer is a criterion.</p> <p>An identifier denoting a 
         * specific drug manufacturer.</p> Un-merged Business Name: 
         * ManufacturerId Relationship: COCT_MT220110CA.Manufacturer.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows sending of 
         * identifiers in place of manufacturer name. May be used in 
         * drug search where specific manufacturer is a criterion.</p> 
         * <p>An identifier denoting a specific drug manufacturer.</p> 
         * Un-merged Business Name: ManufacturerID Relationship: 
         * POIZ_MT060150AB.Manufacturer.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows sending of identifiers in place of 
         * manufacturer name. May be used in drug search where specific 
         * manufacturer is a criterion.</p> <p>An identifier denoting a 
         * specific drug manufacturer.</p> Un-merged Business Name: 
         * ManufacturerID Relationship: POIZ_MT030060AB.Manufacturer.id 
         * Conformance/Cardinality: REQUIRED (0-1) <p>Allows sending of 
         * identifiers in place of manufacturer name. May be used in 
         * drug search where specific manufacturer is a criterion.</p> 
         * <p>An identifier denoting a specific drug manufacturer.</p> 
         * Un-merged Business Name: ManufacturerID Relationship: 
         * POIZ_MT030050AB.Manufacturer.id Conformance/Cardinality: 
         * REQUIRED (0-1) <p>Allows sending of identifiers in place of 
         * manufacturer name. May be used in drug search where specific 
         * manufacturer is a criterion.</p> <p>An identifier denoting a 
         * specific drug manufacturer.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: ManufacturerName</summary>
         * 
         * <remarks>Un-merged Business Name: ManufacturerName 
         * Relationship: COCT_MT220210CA.Manufacturer.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Used in 
         * reporting.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because there will always be a name 
         * for an organization.</p> <p>The name of the drug 
         * manufacturer.</p> Un-merged Business Name: ManufacturerName 
         * Relationship: POIZ_MT061150AB.Manufacturer.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Used in 
         * reporting.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because there will always be a name 
         * for an organization.</p> <p>The name of the drug 
         * manufacturer.</p> Un-merged Business Name: ManufacturerName 
         * Relationship: COCT_MT220110CA.Manufacturer.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Used for 
         * reporting.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because there will always be a name 
         * for an organization.</p> <p>The name of the drug 
         * manufacturer.</p> Un-merged Business Name: ManufacturerName 
         * Relationship: POIZ_MT060150AB.Manufacturer.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Used in 
         * reporting.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because there will always be a name 
         * for an organization.</p> <p>The name of the drug 
         * manufacturer.</p> Un-merged Business Name: ManufacturerName 
         * Relationship: POIZ_MT030060AB.Manufacturer.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Used in 
         * reporting.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because there will always be a name 
         * for an organization.</p> <p>The name of the drug 
         * manufacturer.</p> Un-merged Business Name: ManufacturerName 
         * Relationship: POIZ_MT030050AB.Manufacturer.name 
         * Conformance/Cardinality: MANDATORY (1) <p>Used in 
         * reporting.</p><p>The attribute is marked as 
         * &quot;mandatory&quot; because there will always be a name 
         * for an organization.</p> <p>The name of the drug 
         * manufacturer.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"name"})]
        public String Name {
            get { return this.name.Value; }
            set { this.name.Value = value; }
        }

    }

}