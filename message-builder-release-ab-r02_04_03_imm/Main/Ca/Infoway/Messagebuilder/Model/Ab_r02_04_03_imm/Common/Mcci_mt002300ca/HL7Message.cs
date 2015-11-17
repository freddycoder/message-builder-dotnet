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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Mcci_mt002300ca {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Datatype.Lang;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged;
    using System;
    using System.Collections.Generic;


    /**
     * <summary>Business Name: HL7 Message</summary>
     * 
     * <p>Conveys information about the interaction and how it is 
     * to be processed</p> <p>The root class of all messages.</p>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCCI_MT002300CA.Message"})]
    public class HL7Message<CAE> : MessagePartBean {

        private II id;
        private TS creationTime;
        private ST securityText;
        private CS responseModeCode;
        private II interactionId;
        private LIST<II, Identifier> profileId;
        private CS processingCode;
        private CS acceptAckCode;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.Receiver receiver;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.ToBeRespondedToBy respondTo;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.Sender sender;
        private IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.RoutingInstructionLines> attentionLine;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Mcci_mt002300ca.Acknowledgement acknowledgement;
        private CAE controlActEvent;

        public HL7Message() {
            this.id = new IIImpl();
            this.creationTime = new TSImpl();
            this.securityText = new STImpl();
            this.responseModeCode = new CSImpl();
            this.interactionId = new IIImpl();
            this.profileId = new LISTImpl<II, Identifier>(typeof(IIImpl));
            this.processingCode = new CSImpl();
            this.acceptAckCode = new CSImpl();
            this.attentionLine = new List<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.RoutingInstructionLines>();
        }
        /**
         * <summary>Business Name: A:Message Identifier</summary>
         * 
         * <remarks>Relationship: MCCI_MT002300CA.Message.id 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>soap:Header\wsa:MessageID</p> <p>Allows detection of 
         * duplicate messages, and allows tying acknowledgments to the 
         * message they are acknowledging. The attribute is therefore 
         * mandatory.</p> <p>A unique identifier for the message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"id"})]
        public Identifier Id {
            get { return this.id.Value; }
            set { this.id.Value = value; }
        }

        /**
         * <summary>Business Name: G:Message Timestamp</summary>
         * 
         * <remarks>Relationship: MCCI_MT002300CA.Message.creationTime 
         * Conformance/Cardinality: MANDATORY (1) <p>Allows 
         * identification of how current the information in a message 
         * is. Also provides a baseline for identifying the time-zone 
         * of other times within the message. As a result, the 
         * attribute is mandatory.</p> <p>Indicates the time this 
         * particular message instance was constructed.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"creationTime"})]
        public PlatformDate CreationTime {
            get { return this.creationTime.Value; }
            set { this.creationTime.Value = value; }
        }

        /**
         * <summary>Business Name: H:Security Token</summary>
         * 
         * <remarks>Relationship: MCCI_MT002300CA.Message.securityText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Allows 
         * jurisdictions and applications to communicate authentication 
         * and session information. The attribute is optional because 
         * not all jurisdictions will require this capability.</p> <p>A 
         * locally-defined field used to maintain a session, identify a 
         * user, and/or perform some other function related to 
         * authenticating the message source.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"securityText"})]
        public String SecurityText {
            get { return this.securityText.Value; }
            set { this.securityText.Value = value; }
        }

        /**
         * <summary>Business Name: DA: Response Type</summary>
         * 
         * <remarks>Relationship: 
         * MCCI_MT002300CA.Message.responseModeCode 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>soap:Header\wsa:Action (after the second underscore, if 
         * any, 'D' otherwise)</p> <p>Essential to determining receiver 
         * behavior and therefore mandatory.</p> <p>Identifies whether 
         * the response is desired immediately (as a direct 
         * acknowledgement), on a deferred basis (as a subsequent 
         * independent interaction) or via queue using polling.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"responseModeCode"})]
        public ResponseMode ResponseModeCode {
            get { return (ResponseMode) this.responseModeCode.Value; }
            set { this.responseModeCode.Value = value; }
        }

        /**
         * <summary>Business Name: B:Interaction Type</summary>
         * 
         * <remarks>Relationship: MCCI_MT002300CA.Message.interactionId 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>soap:Header\wsa:Action (after 'urn:hl7-org:v3:' and 
         * before the second underscore, if any)</p> <p>Identifies what 
         * the receiving application should do, and how the message 
         * should be validated. The attribute is therefore 
         * mandatory.</p> <p>Indicates the interaction conveyed by this 
         * message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"interactionId"})]
        public Identifier InteractionId {
            get { return this.interactionId.Value; }
            set { this.interactionId.Value = value; }
        }

        /**
         * <summary>Business Name: F:Conformance Profile Identifiers</summary>
         * 
         * <remarks>Relationship: MCCI_MT002300CA.Message.profileId 
         * Conformance/Cardinality: MANDATORY (1-10) <p>Indicates any 
         * additional validation that may be appropriate. Also 
         * influences what extensions can be processed.</p> 
         * <p>Identifies the conformance profile(s) this message 
         * complies with.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"profileId"})]
        public IList<Identifier> ProfileId {
            get { return this.profileId.RawList(); }
        }

        /**
         * <summary>Business Name: DB:Processing Code</summary>
         * 
         * <remarks>Relationship: 
         * MCCI_MT002300CA.Message.processingCode 
         * Conformance/Cardinality: MANDATORY (1) 
         * <p>soap:Header\wsa:To\(portion between second-last '\' and 
         * third-last '\')</p> <p>Indicates how the message should be 
         * handled and is therefore mandatory.</p> <p>Indicates whether 
         * this message is intended to be processed as production, test 
         * or debug message.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"processingCode"})]
        public ProcessingID ProcessingCode {
            get { return (ProcessingID) this.processingCode.Value; }
            set { this.processingCode.Value = value; }
        }

        /**
         * <summary>Business Name: E:Desired Acknowledgment Type</summary>
         * 
         * <remarks>Relationship: MCCI_MT002300CA.Message.acceptAckCode 
         * Conformance/Cardinality: MANDATORY (1) <p>Provides support 
         * for immediate, deferred and polling mode and distinguishes 
         * which mode is desired. The attribute is therefore 
         * mandatory.</p> <p>When using SOAP, this attribute MUST be 
         * set to NE (Never). (Accept acknowledgements are handled via 
         * the transport protocol, not HL7.)</p> <p>Indicates how the 
         * message is expected to be acknowledged.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"acceptAckCode"})]
        public AcknowledgementCondition AcceptAckCode {
            get { return (AcknowledgementCondition) this.acceptAckCode.Value; }
            set { this.acceptAckCode.Value = value; }
        }

        /**
         * <summary>Relationship: MCCI_MT002300CA.Message.receiver</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"receiver"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.Receiver Receiver {
            get { return this.receiver; }
            set { this.receiver = value; }
        }

        /**
         * <summary>Relationship: MCCI_MT002300CA.Message.respondTo</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"respondTo"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.ToBeRespondedToBy RespondTo {
            get { return this.respondTo; }
            set { this.respondTo = value; }
        }

        /**
         * <summary>Relationship: MCCI_MT002300CA.Message.sender</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"sender"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.Sender Sender {
            get { return this.sender; }
            set { this.sender = value; }
        }

        /**
         * <summary>Relationship: MCCI_MT002300CA.Message.attentionLine</summary>
         * 
         * <remarks>Conformance/Cardinality: OPTIONAL (0-5)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"attentionLine"})]
        public IList<Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Merged.RoutingInstructionLines> AttentionLine {
            get { return this.attentionLine; }
        }

        /**
         * <summary>Relationship: 
         * MCCI_MT002300CA.Message.acknowledgement</summary>
         * 
         * <remarks>Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"acknowledgement"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_imm.Common.Mcci_mt002300ca.Acknowledgement Acknowledgement {
            get { return this.acknowledgement; }
            set { this.acknowledgement = value; }
        }

        /**
         * <summary>Relationship: 
         * MCCI_MT002300CA.Message.controlActEvent</summary>
         * 
         * <remarks>Conformance/Cardinality: REQUIRED (0-1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"controlActEvent"})]
        public CAE ControlActEvent {
            get { return this.controlActEvent; }
            set { this.controlActEvent = value; }
        }

    }

}