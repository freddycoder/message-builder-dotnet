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
namespace Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged {
    using Ca.Infoway.Messagebuilder.Annotation;
    using Ca.Infoway.Messagebuilder.Datatype;
    using Ca.Infoway.Messagebuilder.Datatype.Impl;
    using Ca.Infoway.Messagebuilder.Domainvalue;
    using Ca.Infoway.Messagebuilder.Model;
    using System;


    /**
     * <summary>Business Name: CreatedBy</summary>
     * 
     * <remarks>MCAI_MT700211CA.Author: a:*created by <p>If 
     * AuthorizationToken is specified and communicates author, the 
     * bare AuthorRole class must be specified, otherwise the 
     * R_ActingPerson CMET must be specified.</p> <p>Critical for 
     * auditing and for validating permissions and therefore 
     * mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p> QUQI_MT020002CA.Author: a:*created 
     * by <p>If AuthorizationToken is specified and communicates 
     * author, the bare AuthorRole class must be specified, 
     * otherwise the R_ActingPerson CMET must be specified.</p> 
     * <p>Critical for auditing and for validating permissions and 
     * therefore mandatory.</p> <p>Indicates the person responsible 
     * for the event that caused this message.</p> 
     * MCAI_MT700212CA.Author: a:*created by <p>If 
     * AuthorizationToken is specified and communicates author, the 
     * bare AuthorRole class must be specified, otherwise the 
     * R_ActingPerson CMET must be specified.</p> <p>Critical for 
     * auditing and for validating permissions and therefore 
     * mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p> MCAI_MT700220CA.Author: a:*created 
     * by <p>If AuthorizationToken is specified and communicates 
     * author, the bare AuthorRole class must be specified, 
     * otherwise the R_ActingPerson CMET must be specified.</p> 
     * <p>Critical for auditing and for validating permissions and 
     * therefore mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p> QUQI_MT020000CA.Author: a:*created 
     * by <p>If AuthorizationToken is specified and communicates 
     * author, the bare AuthorRole class must be specified, 
     * otherwise the R_ActingPerson CMET must be specified.</p> 
     * <p>Critical for auditing and for validating permissions and 
     * therefore mandatory.</p> <p>Indicates the person responsible 
     * for the event that caused this message.</p> 
     * MCAI_MT700232CA.Author: a:*created by <p>If 
     * AuthorizationToken is specified and communicates author, the 
     * bare AuthorRole class must be specified, otherwise the 
     * R_ActingPerson CMET must be specified.</p> <p>Critical for 
     * auditing and for validating permissions and therefore 
     * mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p> MCAI_MT700230CA.Author: a:*created 
     * by <p>If AuthorizationToken is specified and communicates 
     * author, the bare AuthorRole class must be specified, 
     * otherwise the R_ActingPerson CMET must be specified.</p> 
     * <p>Critical for auditing and for validating permissions and 
     * therefore mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p> MCAI_MT700210CA.Author: a:*created 
     * by <p>If AuthorizationToken is specified and communicates 
     * author, the bare AuthorRole class must be specified, 
     * otherwise the R_ActingPerson CMET must be specified.</p> 
     * <p>Critical for auditing and for validating permissions and 
     * therefore mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p> MCAI_MT700231CA.Author: a:*created 
     * by <p>If AuthorizationToken is specified and communicates 
     * author, the bare AuthorRole class must be specified, 
     * otherwise the R_ActingPerson CMET must be specified.</p> 
     * <p>Critical for auditing and for validating permissions and 
     * therefore mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p> MCAI_MT700222CA.Author: a:*created 
     * by <p>If AuthorizationToken is specified and communicates 
     * author, the bare AuthorRole class must be specified, 
     * otherwise the R_ActingPerson CMET must be specified.</p> 
     * <p>Critical for auditing and for validating permissions and 
     * therefore mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p> MCAI_MT700221CA.Author: a:*created 
     * by <p>If AuthorizationToken is specified and communicates 
     * author, the bare AuthorRole class must be specified, 
     * otherwise the R_ActingPerson CMET must be specified.</p> 
     * <p>Critical for auditing and for validating permissions and 
     * therefore mandatory.</p> <p>Choice of Patient CMET is as 
     * follows:</p><p>1. 'identified' when supporting Patient 
     * Session Tokens.</p><p>2. 'informational' when passing 
     * through non Client- Registry patient for PHS or similar 
     * processing.</p><p>3. 'identified-confirmable' otherwise.</p> 
     * <p>Indicates the person responsible for the event that 
     * caused this message.</p></remarks>
     */
    [Hl7PartTypeMappingAttribute(new string[] {"MCAI_MT700210CA.Author","MCAI_MT700211CA.Author","MCAI_MT700212CA.Author","MCAI_MT700220CA.Author","MCAI_MT700221CA.Author","MCAI_MT700222CA.Author","MCAI_MT700230CA.Author","MCAI_MT700231CA.Author","MCAI_MT700232CA.Author","QUQI_MT020000CA.Author","QUQI_MT020002CA.Author"})]
    public class CreatedBy_1 : MessagePartBean {

        private TS time;
        private CV modeCode;
        private ED<String> signatureText;
        private Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged.IAuthorPerson_1 authorPerson;

        public CreatedBy_1() {
            this.time = new TSImpl();
            this.modeCode = new CVImpl();
            this.signatureText = new EDImpl<String>();
        }
        /**
         * <summary>Business Name: TimeOfCreation</summary>
         * 
         * <remarks>Un-merged Business Name: TimeOfCreation 
         * Relationship: MCAI_MT700211CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The time a change 
         * is made is a critical piece of audit information and is 
         * therefore mandatory.</p> <p>The time the person responsible 
         * for the event made the decision for it to occur. This may be 
         * different than the time the change became effective. (E.g. 
         * If a provider decides today to put a prescription on hold 
         * starting next Tuesday, the time of creation would be today 
         * and the change effective period would be next 
         * Tuesday.)</p><p>This date can be back-dated.</p> Un-merged 
         * Business Name: TimeOfCreation Relationship: 
         * QUQI_MT020002CA.Author.time Conformance/Cardinality: 
         * MANDATORY (1) <p>The time a change is made is a critical 
         * piece of audit information and is therefore mandatory.</p> 
         * <p>The time the person responsible for the event made the 
         * decision for it to occur. This may be different than the 
         * time the change became effective. (E.g. If a provider 
         * decides today to put a prescription on hold starting next 
         * Tuesday, the time of creation would be today and the change 
         * effective period would be next Tuesday.)</p><p>This date can 
         * be back-dated.</p> Un-merged Business Name: TimeOfCreation 
         * Relationship: MCAI_MT700212CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The time a change 
         * is made is a critical piece of audit information and is 
         * therefore mandatory.</p> <p>The time the person responsible 
         * for the event made the decision for it to occur. This may be 
         * different than the time the change became effective. (E.g. 
         * If a provider decides today to put a prescription on hold 
         * starting next Tuesday, the time of creation would be today 
         * and the change effective period would be next 
         * Tuesday.)</p><p>This date can be back-dated.</p> Un-merged 
         * Business Name: TimeOfCreation Relationship: 
         * MCAI_MT700220CA.Author.time Conformance/Cardinality: 
         * MANDATORY (1) <p>The time a change is made is a critical 
         * piece of audit information and is therefore mandatory.</p> 
         * <p>The time the person responsible for the event made the 
         * decision for it to occur. This may be different than the 
         * time the change became effective. (E.g. If a provider 
         * decides today to put a prescription on hold starting next 
         * Tuesday, the time of creation would be today and the change 
         * effective period would be next Tuesday.)</p><p>This date can 
         * be back-dated.</p> Un-merged Business Name: TimeOfCreation 
         * Relationship: MCAI_MT700232CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The time a change 
         * is made is a critical piece of audit information and is 
         * therefore mandatory.</p> <p>The time the person responsible 
         * for the event made the decision for it to occur. This may be 
         * different than the time the change became effective. (E.g. 
         * If a provider decides today to put a prescription on hold 
         * starting next Tuesday, the time of creation would be today 
         * and the change effective period would be next 
         * Tuesday.)</p><p>This date can be back-dated.</p> Un-merged 
         * Business Name: TimeOfCreation Relationship: 
         * QUQI_MT020000CA.Author.time Conformance/Cardinality: 
         * MANDATORY (1) <p>The time a change is made is a critical 
         * piece of audit information and is therefore mandatory.</p> 
         * <p>The time the person responsible for the event made the 
         * decision for it to occur. This may be different than the 
         * time the change became effective. (E.g. If a provider 
         * decides today to put a prescription on hold starting next 
         * Tuesday, the time of creation would be today and the change 
         * effective period would be next Tuesday.)</p><p>This date can 
         * be back-dated.</p> Un-merged Business Name: TimeOfCreation 
         * Relationship: MCAI_MT700210CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The time a change 
         * is made is a critical piece of audit information and is 
         * therefore mandatory.</p> <p>The time the person responsible 
         * for the event made the decision for it to occur. This may be 
         * different than the time the change became effective. (E.g. 
         * If a provider decides today to put a prescription on hold 
         * starting next Tuesday, the time of creation would be today 
         * and the change effective period would be next 
         * Tuesday.)</p><p>This date can be back-dated.</p> Un-merged 
         * Business Name: TimeOfCreation Relationship: 
         * MCAI_MT700230CA.Author.time Conformance/Cardinality: 
         * MANDATORY (1) <p>The time a change is made is a critical 
         * piece of audit information and is therefore mandatory.</p> 
         * <p>The time the person responsible for the event made the 
         * decision for it to occur. This may be different than the 
         * time the change became effective. (E.g. If a provider 
         * decides today to put a prescription on hold starting next 
         * Tuesday, the time of creation would be today and the change 
         * effective period would be next Tuesday.)</p><p>This date can 
         * be back-dated.</p> Un-merged Business Name: TimeOfCreation 
         * Relationship: MCAI_MT700231CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The time a change 
         * is made is a critical piece of audit information and is 
         * therefore mandatory.</p> <p>The time the person responsible 
         * for the event made the decision for it to occur. This may be 
         * different than the time the change became effective. (E.g. 
         * If a provider decides today to put a prescription on hold 
         * starting next Tuesday, the time of creation would be today 
         * and the change effective period would be next 
         * Tuesday.)</p><p>This date can be back-dated.</p> Un-merged 
         * Business Name: TimeOfCreation Relationship: 
         * MCAI_MT700221CA.Author.time Conformance/Cardinality: 
         * MANDATORY (1) <p>The time a change is made is a critical 
         * piece of audit information and is therefore mandatory.</p> 
         * <p>The time the person responsible for the event made the 
         * decision for it to occur. This may be different than the 
         * time the change became effective. (E.g. If a provider 
         * decides today to put a prescription on hold starting next 
         * Tuesday, the time of creation would be today and the change 
         * effective period would be next Tuesday.)</p><p>This date can 
         * be back-dated.</p> Un-merged Business Name: TimeOfCreation 
         * Relationship: MCAI_MT700222CA.Author.time 
         * Conformance/Cardinality: MANDATORY (1) <p>The time a change 
         * is made is a critical piece of audit information and is 
         * therefore mandatory.</p> <p>The time the person responsible 
         * for the event made the decision for it to occur. This may be 
         * different than the time the change became effective. (E.g. 
         * If a provider decides today to put a prescription on hold 
         * starting next Tuesday, the time of creation would be today 
         * and the change effective period would be next 
         * Tuesday.)</p><p>This date can be back-dated.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"time"})]
        public PlatformDate Time {
            get { return this.time.Value; }
            set { this.time.Value = value; }
        }

        /**
         * <summary>Business Name: InformationReceivedMethod</summary>
         * 
         * <remarks>Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700211CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: QUQI_MT020002CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700212CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700220CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700232CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: QUQI_MT020000CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700210CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700230CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700231CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700221CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p> Un-merged Business Name: InformationReceivedMethod 
         * Relationship: MCAI_MT700222CA.Author.modeCode 
         * Conformance/Cardinality: REQUIRED (0-1) <p>May have 
         * ramifications for the audit trail and reliability of the 
         * information.</p> <p>Indicates how the person who recorded 
         * the event became aware of it.. E.g. Verbal, written, fax, 
         * etc.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"modeCode"})]
        public ParticipationMode ModeCode {
            get { return (ParticipationMode) this.modeCode.Value; }
            set { this.modeCode.Value = value; }
        }

        /**
         * <summary>Business Name: DigitalSignature</summary>
         * 
         * <remarks>Un-merged Business Name: DigitalSignature 
         * Relationship: MCAI_MT700211CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * QUQI_MT020002CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * MCAI_MT700212CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * MCAI_MT700220CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * MCAI_MT700232CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * QUQI_MT020000CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * MCAI_MT700210CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * MCAI_MT700230CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * MCAI_MT700231CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * MCAI_MT700221CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p> Un-merged Business 
         * Name: DigitalSignature Relationship: 
         * MCAI_MT700222CA.Author.signatureText 
         * Conformance/Cardinality: OPTIONAL (0-1) <p>Digital 
         * signatures may be needed for authentication of message 
         * content. The attribute is marked as optional because it is 
         * not yet clear whether there is a use-case for this, or where 
         * it will be used.</p> <p>Indicates the formal digital 
         * signature of the message content.</p></remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"signatureText"})]
        public String SignatureText {
            get { return this.signatureText.Value; }
            set { this.signatureText.Value = value; }
        }

        /**
         * <summary>Un-merged Business Name: (no business name 
         * specified)</summary>
         * 
         * <remarks>Relationship: MCAI_MT700211CA.Author.authorPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * QUQI_MT020002CA.Author.authorPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: MCAI_MT700212CA.Author.authorPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700220CA.Author.authorPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: MCAI_MT700232CA.Author.authorPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * QUQI_MT020000CA.Author.authorPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: MCAI_MT700210CA.Author.authorPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700230CA.Author.authorPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: MCAI_MT700231CA.Author.authorPerson 
         * Conformance/Cardinality: MANDATORY (1) Un-merged Business 
         * Name: (no business name specified) Relationship: 
         * MCAI_MT700221CA.Author.authorPerson Conformance/Cardinality: 
         * MANDATORY (1) Un-merged Business Name: (no business name 
         * specified) Relationship: MCAI_MT700222CA.Author.authorPerson 
         * Conformance/Cardinality: MANDATORY (1)</remarks>
         */
        [Hl7XmlMappingAttribute(new string[] {"authorPerson"})]
        public Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03.Common.Merged.IAuthorPerson_1 AuthorPerson {
            get { return this.authorPerson; }
            set { this.authorPerson = value; }
        }

    }

}