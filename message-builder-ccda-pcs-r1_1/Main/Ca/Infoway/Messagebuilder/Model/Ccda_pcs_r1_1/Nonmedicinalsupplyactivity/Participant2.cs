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
namespace Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Nonmedicinalsupplyactivity {
    using Ca.Infoway.Messagebuilder;
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Productinstance;
    using System.Collections.Generic;


    [Hl7PartTypeMappingAttribute(new string[] {"NonMedicinalSupplyActivity.Participant2"})]
    public class Participant2 : MessagePartBean, Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Nonmedicinalsupplyactivity.IParticipant2Choice {

        private LIST<CS, Code> realmCode;
        private II typeId;
        private LIST<II, Identifier> templateId;
        private IVLTSCDAR1 time;
        private CE awarenessCode;
        private Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Productinstance.ParticipantRole participantRole;

        public Participant2() {
            this.realmCode = new LISTImpl<CS, Code>(typeof(CSImpl));
            this.typeId = new IIImpl();
            this.templateId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.time = new IVLTSCDAR1Impl();
            this.awarenessCode = new CEImpl();
        }
        /**
         * <summary>Relationship: 
         * NonMedicinalSupplyActivity.Participant2.realmCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"realmCode"})]
        public IList<Code> RealmCode {
            get { return this.realmCode.RawList<Code>(); }
        }

        /**
         * <summary>Relationship: 
         * NonMedicinalSupplyActivity.Participant2.typeId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"typeId"})]
        public Identifier TypeId {
            get { return this.typeId.Value; }
            set { this.typeId.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * NonMedicinalSupplyActivity.Participant2.templateId</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-*)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"templateId"})]
        public IList<Identifier> TemplateId {
            get { return this.templateId.RawList(); }
        }

        /**
         * <summary>Relationship: 
         * NonMedicinalSupplyActivity.Participant2.time</summary>
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
         * NonMedicinalSupplyActivity.Participant2.awarenessCode</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"awarenessCode"})]
        public Code AwarenessCode {
            get { return (Code) this.awarenessCode.Value; }
            set { this.awarenessCode.Value = value; }
        }

        /**
         * <summary>Relationship: 
         * NonMedicinalSupplyActivity.Participant2.participantRole</summary>
         * 
         * <remarks>Conformance/Cardinality: POPULATED (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"participantRole"})]
        public Ca.Infoway.Messagebuilder.Model.Ccda_pcs_r1_1.Productinstance.ParticipantRole ParticipantRole {
            get { return this.participantRole; }
            set { this.participantRole = value; }
        }

    }

}