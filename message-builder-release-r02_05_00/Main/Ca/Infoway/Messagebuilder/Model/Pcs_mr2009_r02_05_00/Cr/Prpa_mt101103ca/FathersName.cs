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
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_05_00.Cr.Prpa_mt101103ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    [Hl7PartTypeMappingAttribute(new string[] {"PRPA_MT101103CA.FathersName"})]
    public class FathersName : MessagePartBean {

        private PN value;
        private ST semanticsText;

        public FathersName() {
            this.value = new PNImpl();
            this.semanticsText = new STImpl();
        }
        /**
         * <summary>Business Name: Father's Name</summary>
         * 
         * <remarks>Relationship: PRPA_MT101103CA.FathersName.value 
         * Conformance/Cardinality: MANDATORY (1) <p>It is included as 
         * a parameter item in order to further constrain the possible 
         * number of responses and increase the match probability to a 
         * single record.</p> <p>This parameter does not map to a 
         * single RIM attribute, instead, in RIM terms Father's name is 
         * the person name part of &quot;family&quot; for the person 
         * who is the player in a PersonalRelationship of type of 
         * &quot;father&quot; to the focal person.</p> <p>This query 
         * parameter item is the name of the focal person's father.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"value"})]
        public PersonName Value {
            get { return this.value.Value; }
            set { this.value.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PRPA_MT101103CA.FathersName.semanticsText</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"semanticsText"})]
        public String SemanticsText {
            get { return this.semanticsText.Value; }
            set { this.semanticsText.Value = value; }
        }

    }

}