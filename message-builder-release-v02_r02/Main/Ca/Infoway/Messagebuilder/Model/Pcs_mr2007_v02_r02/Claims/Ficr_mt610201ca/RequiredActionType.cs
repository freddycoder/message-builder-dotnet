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
 * Last modified: $LastChangedDate: 2011-05-04 16:47:15 -0300 (Wed, 04 May 2011) $
 * Revision:      $LastChangedRevision: 2623 $
 */
/* This class was auto-generated by the message builder generator tools. */
namespace Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Claims.Ficr_mt610201ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Pcs_mr2007_v02_r02.Domainvalue;


    [Hl7PartTypeMappingAttribute(new string[] {"FICR_MT610201CA.AdjudicationResultRequiredAct"})]
    public class RequiredActionType : MessagePartBean {

        private CV code;

        public RequiredActionType() {
            this.code = new CVImpl();
        }
        /**
         * <summary>Relationship: 
         * FICR_MT610201CA.AdjudicationResultRequiredAct.code</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1) <p>Required 
         * Action Type -e.g. print on EOB, allow override. Only specify 
         * a URL to instruct the Rx s/w vendor to pick up the form from 
         * the adjudicator's web site.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"code"})]
        public ActAdjudicationResultActionCode Code {
            get { return (ActAdjudicationResultActionCode) this.code.Value; }
            set { this.code.Value = value; }
        }

    }

}