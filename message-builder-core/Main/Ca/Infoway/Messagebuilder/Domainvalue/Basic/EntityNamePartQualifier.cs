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

namespace Ca.Infoway.Messagebuilder.Domainvalue.Basic {
    using System;
    using Ca.Infoway.Messagebuilder.Codesystem;
    using Ca.Infoway.Messagebuilder.Domainvalue.Util;
    using Ca.Infoway.Messagebuilder.Lang;

    /// <summary>
    /// EntityNamePartQualifier
    /// From http://www.hl7.org/v3ballot/html/infrastructure/itsxml/datatypes-its-xml.htm#domain-EntityNameUse
    /// </summary>
    [Serializable]
    public class EntityNamePartQualifier : EnumPattern, Ca.Infoway.Messagebuilder.Domainvalue.EntityNamePartQualifier, Describable {

        public static readonly EntityNamePartQualifier ACADEMIC = new EntityNamePartQualifier("ACADEMIC", "AC");
        public static readonly EntityNamePartQualifier ADOPTED = new EntityNamePartQualifier("ADOPTED", "AD");
        public static readonly EntityNamePartQualifier BIRTH = new EntityNamePartQualifier("BIRTH", "BR");
        public static readonly EntityNamePartQualifier CALLME = new EntityNamePartQualifier("CALLME", "CL");
        public static readonly EntityNamePartQualifier INITIAL = new EntityNamePartQualifier("INITIAL", "IN");
        public static readonly EntityNamePartQualifier NOBILITY = new EntityNamePartQualifier("NOBILITY", "NB");
        public static readonly EntityNamePartQualifier PROFESSIONAL = new EntityNamePartQualifier("PROFESSIONAL", "PR");
        public static readonly EntityNamePartQualifier SPOUSE = new EntityNamePartQualifier("SPOUSE", "SP");
        public static readonly EntityNamePartQualifier TITLE = new EntityNamePartQualifier("TITLE", "TITLE");
        public static readonly EntityNamePartQualifier VOORVOEGSEL = new EntityNamePartQualifier("VOORVOEGSEL", "VV");
        public static readonly EntityNamePartQualifier LEGALSTATUS = new EntityNamePartQualifier("LEGALSTATUS", "LS");

        private readonly String codeValue;

        /// <summary>
        /// The code value.
        /// </summary>
        public String CodeValue {
            get { return this.codeValue; }
        }

        public virtual String CodeSystem {
            get {
                return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ENTITY_NAME_QUALIFIER.Root;
            }
        }

        public virtual String CodeSystemName {
            get { return null; }
        }

        /// <summary>
        /// Returns the description.
        /// </summary>
        public virtual String Description {
            get {
                return DescribableUtil.GetDefaultDescription(this);
            }
        }

        private EntityNamePartQualifier(String name, String codeValue) :
            base(name) {
                this.codeValue = codeValue;
        }
    }
}