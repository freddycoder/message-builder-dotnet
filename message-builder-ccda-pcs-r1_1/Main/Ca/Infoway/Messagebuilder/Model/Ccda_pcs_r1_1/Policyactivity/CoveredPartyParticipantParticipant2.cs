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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Policyactivity {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;


    [Hl7PartTypeMappingAttribute(new string[] {"PolicyActivity.CoveredPartyParticipantParticipant2"})]
    public class CoveredPartyParticipantParticipant2 : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Policyactivity.IParticipant2Choice {

        private II templateId;
        private IVLTSCDAR1 time;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Policyactivity.CoveredPartyParticipantParticipantRole participantRole;

        public CoveredPartyParticipantParticipant2() {
            this.templateId = new IIImpl();
            this.time = new IVLTSCDAR1Impl();
        }
        /**
         * <summary>Relationship: 
         * PolicyActivity.CoveredPartyParticipantParticipant2.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public Identifier TemplateId {
            get { return this.templateId.Value; }
            set { this.templateId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.CoveredPartyParticipantParticipant2.time</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public DateInterval Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * PolicyActivity.CoveredPartyParticipantParticipant2.participantRole</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participantRole"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Policyactivity.CoveredPartyParticipantParticipantRole ParticipantRole {
            get { return this.participantRole; }
            set { this.participantRole = value; }
        }

    }

}