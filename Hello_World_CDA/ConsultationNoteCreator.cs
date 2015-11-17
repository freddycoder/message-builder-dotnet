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
﻿using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.J5goodies;
using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Consultationnote;
using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Domainvalue;
using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Merged;
using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Chiefcomplaintandreasonforvisitsection;
using Ca.Infoway.Messagebuilder.Resolver;
using Platform.Xml.Sax;

namespace Hello_World_CDA {

    public class ConsultationNoteCreator {
	    /*
	     * Note that many of these methods could be placed in a central location for reuse (if a group of Authors was always the same, they could be cached, etc.)
	     */
		
	    public ConsultationNoteDocument CreateConsultationNote() {

		    // Community Health and Hospitals: Consultation Note
		    // templateId 2.16.840.1.113883.10.20.22.1.4

		    ConsultationNoteDocument consultationNote = new ConsultationNoteDocument();
		    consultationNote.TypeId = new Identifier("2.16.840.1.113883.1.3", "POCD_HD000040");
		    consultationNote.TemplateId.Add(new Identifier("2.16.840.1.113883.10.20.22.1.4"));
		    consultationNote.Id = new Identifier("2.16.840.1.113883.19.5.99999.1", "TT988");
		    consultationNote.Code = GetLoincCode();
		    consultationNote.Title = "Community Health and Hospitals: Consultation Note";
		    consultationNote.EffectiveTime = new MbDate(DateUtil.GetDate(2012, 8, 16));
		    consultationNote.ConfidentialityCode = GetConfidentialityCode();
		    consultationNote.LanguageCode = GetLanguageCode();
		    consultationNote.RecordTarget.Add(CreateRecordTarget());
		    consultationNote.Author.Add(CreateAuthor());
		    consultationNote.Custodian = CreateCustodian();
		    consultationNote.InFulfillmentOf.Add(CreateInFulfillmentOf());
		    consultationNote.ComponentOf = CreateComponentOf();
		    consultationNote.Component = CreateComponent();
		
		    return consultationNote;
	    }

	    // used to add more information to the document object after initially creating it
	    public void AddHistoryOfPresentIllness(ConsultationNote consultationNote) {
		    Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Historyofpresentillnesssection.Section historyOfPresentIllnessSection = 
                new Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Historyofpresentillnesssection.Section();
		    historyOfPresentIllnessSection.Title = "HISTORY OF PRESENT ILLNESS";
		    historyOfPresentIllnessSection.Text = CreateIllnessHistoryText();
		
		    HistoryOfPresentIllnessSectionComponent3 historyOfPresentIllness = new HistoryOfPresentIllnessSectionComponent3();
		    historyOfPresentIllness.Section = historyOfPresentIllnessSection;
		
		    consultationNote.Component.Component2ChoiceAsStructuredBody.Component.Add(historyOfPresentIllness);
	    }

	    private EncapsulatedData CreateIllnessHistoryText() {
		    EncapsulatedData text = new EncapsulatedData();
		
		    try {
			    text.AddContent("<paragraph>This patient was only recently discharged for a recurrent GI" +
					    "bleed as described below.</paragraph>");
			    text.AddContent("<paragraph>He presented to the ER today c/o a dark stool yesterday but a" +
					    "normal brown stool today. On exam he was hypotensive in the 80?s" +
					    "resolved after .... .... .... </paragraph>");
			    text.AddContent("<paragraph>Lab at discharge: Glucose 112, BUN 16, creatinine 1.1," +
					    "electrolytes normal. H. pylori antibody pending. Admission hematocrit" +
					    "16%, discharge hematocrit 29%. WBC 7300, platelet count 256,000." +
					    "Urinalysis normal. Urine culture: No growth. INR 1.1, PTT" +
					    "40.</paragraph>");
			    text.AddContent("<paragraph>He was transfused with 6 units of packed red blood cells with" +
					    ".... .... ....</paragraph>");
			    text.AddContent("<paragraph>GI evaluation 12 September: Colonoscopy showed single red clot in" +
					    ".... .... ....</paragraph>");
		    } catch (SAXException e) {
			    Console.WriteLine("Unexpected exception adding content to ED: " + e);
		    }
		    return text;
	    }

	    private Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Consultationnote.Component2 CreateComponent() {
		    StructuredBody body = new StructuredBody();
		    body.Component.Add(CreateReasonForVisit());
		    body.Component.Add(CreateGeneralStatus());
		
		    Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Consultationnote.Component2 component = new Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Consultationnote.Component2();
		    component.Component2Choice = body;
		    return component;
	    }

	    private GeneralStatusSectionComponent3 CreateGeneralStatus() {
		    Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Generalstatussection.Section section = new Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Generalstatussection.Section();
		    section.Title = "GENERAL STATUS";
		
		    try {
			    EncapsulatedData text = new EncapsulatedData("<paragraph>Alert and in good spirits, no acute distress. </paragraph>");
			    section.Text = text;
		    } catch (SAXException e) {
			    Console.WriteLine("Unexpected exception adding content to ED: " + e);
		    }
		
		    GeneralStatusSectionComponent3 generalStatus = new GeneralStatusSectionComponent3();
		    generalStatus.Section = section;
		    return generalStatus;
	    }

	    private ChiefComplaintAndReasonForVisitSectionComponent3 CreateReasonForVisit() {
		    Section section = new Section();
		    section.Title = "REASON FOR VISIT/CHIEF COMPLAINT";
		
		    try {
			    EncapsulatedData text = new EncapsulatedData("<paragraph>Dark stools.</paragraph>");
			    section.Text = text;
		    } catch (SAXException e) {
			    Console.WriteLine("Unexpected exception adding content to ED: " + e);
		    }
		

		    ChiefComplaintAndReasonForVisitSectionComponent3 reasonForVisit = new ChiefComplaintAndReasonForVisitSectionComponent3();
		    reasonForVisit.Section = section;
		
		    return reasonForVisit;
	    }

	    private Component1_2 CreateComponentOf() {
		    // setting low only - currently (2015/01/28) the Schematron validation will report an error if high is provided (outside of MB's control)
		    Interval<PlatformDate> interval = IntervalUtil.CreateInterval(DateUtil.GetDate(2009, 01, 27), null);
		    DateInterval dateInterval = new DateInterval(interval);
		
		    EncompassingEncounter_2 encompassingEncounter = new EncompassingEncounter_2();
		    encompassingEncounter.Id = new Identifier("2.16.840.1.113883.19", "9937012");
		    encompassingEncounter.EffectiveTime = dateInterval;		
		
		    Component1_2 componentOf = new Component1_2();
		    componentOf.EncompassingEncounter = encompassingEncounter;
		    return componentOf;
	    }

	    private InFulfillmentOf CreateInFulfillmentOf() {
		    Order order = new Order();
		    order.Id.Add(new Identifier("2.16.840.1.113883.19", "12345-67890"));
		
 		    InFulfillmentOf inFulfillmentOf = new InFulfillmentOf();
		    inFulfillmentOf.Order = order;
		
		    return inFulfillmentOf;
	    }

	    private Custodian CreateCustodian() {
		    EntityNamePart namePart = new EntityNamePart("Community Health and Hospitals");
		
		    OrganizationName name = new OrganizationName();
		    name.AddNamePart(namePart);
		
		    CustodianOrganization organization = new CustodianOrganization();
		    organization.Id.Add(new Identifier("2.16.840.1.113883.4.6", "99999999"));
		    organization.Name = name;
		    organization.Telecom = CreateTelecom("555-555-1002", Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.WORKPLACE);
		    organization.Addr = CreateAddress("1002 Healthcare Drive", "Portland", "OR", "99123", "US");
		
		    AssignedCustodian assignedCustodian = new AssignedCustodian();
		    assignedCustodian.RepresentedCustodianOrganization = organization;
		
		    Custodian custodian = new Custodian();
		    custodian.AssignedCustodian = assignedCustodian;
		
		    return custodian;
	    }

	    private Author_2 CreateAuthor() {
		    AssignedAuthor assignedAuthor = new AssignedAuthor();
		    assignedAuthor.Id.Add(new Identifier("2.16.840.1.113883.4.6", "99999999"));
		    assignedAuthor.Addr.Add(CreateAddress("1002 Healthcare Drive", "Portland", "OR", "99123", "US"));
		    assignedAuthor.Telecom.Add(CreateTelecom("555-555-1002", Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.WORKPLACE));
		
		    Author_2 author = new Author_2();
		    author.Time = CreateDate(2005, 02, 29);
		    author.AssignedAuthor = assignedAuthor;
		
		    return author;
	    }

	    private RecordTarget CreateRecordTarget() {
		    RecordTarget recordTargetBean = new RecordTarget();
		    recordTargetBean.PatientRole = CreatePatientRole();
		    return recordTargetBean;
	    }

	    private PatientRole CreatePatientRole() {
		    PatientRole patientRole = new PatientRole();
		    patientRole.Id.Add(new Identifier("2.16.840.1.113883.19.5.99999.2", "998991"));
		    patientRole.Addr.Add(CreateAddress("1357 Amber Drive", "Beaverton", "OR", "97867", "US"));
		    patientRole.Telecom.Add(CreateTelecom("(816)276-6909", Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse.PRIMARY_HOME));
		    patientRole.Patient = CreatePatient();
		    return patientRole;
	    }

	    private Patient CreatePatient() {
		    Patient patient = new Patient();
		    patient.Name.Add(CreateName());
		    patient.AdministrativeGenderCode = new CodedTypeR2<AdministrativeGender>(Ca.Infoway.Messagebuilder.Domainvalue.Payload.AdministrativeGender.FEMALE);
		    patient.BirthTime = CreateDate(2005, 4, 1);
		    return patient;
	    }

	    private MbDate CreateDate(int year, int month, int day) {
		    return new MbDate(new DateWithPattern(DateUtil.GetDate(year, month, day), "yyyyMMdd"));
	    }

	    private PersonName CreateName() {
		    PersonName name = new PersonName();
		    name.Parts.Add(new EntityNamePart("Isabella", PersonNamePartType.GIVEN));
		    name.Parts.Add(new EntityNamePart("Isa", PersonNamePartType.GIVEN));
		    name.Parts.Add(new EntityNamePart("Jones", PersonNamePartType.FAMILY));
		    name.Uses.Add(Ca.Infoway.Messagebuilder.Domainvalue.Basic.EntityNameUse.LEGAL);
		    return name;
	    }

	    private TelecommunicationAddress CreateTelecom(string number, Ca.Infoway.Messagebuilder.Domainvalue.Basic.TelecommunicationAddressUse use) {
		    return new TelecommunicationAddress(Ca.Infoway.Messagebuilder.Domainvalue.Basic.URLScheme.TEL, number, use);
	    }

	    private PostalAddress CreateAddress(string streetAddress, string city, string state, string postalCode, string country) {
		    PostalAddress address = new PostalAddress();
		    address.Uses.Add(Ca.Infoway.Messagebuilder.Domainvalue.Basic.PostalAddressUse.PRIMARY_HOME);
		    address.Parts.Add(new PostalAddressPart(PostalAddressPartType.STREET_ADDRESS_LINE, streetAddress));
		    address.Parts.Add(new PostalAddressPart(PostalAddressPartType.CITY, city));
		    address.Parts.Add(new PostalAddressPart(PostalAddressPartType.STATE, state));
		    address.Parts.Add(new PostalAddressPart(PostalAddressPartType.POSTAL_CODE, postalCode));
		    address.Parts.Add(new PostalAddressPart(PostalAddressPartType.COUNTRY, country));
		    return address;
	    }

	    private CodedTypeR2<Language> GetLanguageCode() {
		    Language code = CodeResolverRegistry.Lookup<Language>(typeof(Language), "en-US");
		    return new CodedTypeR2<Language>(code);
	    }

	    private CodedTypeR2<BasicConfidentialityKind> GetConfidentialityCode() {
		    BasicConfidentialityKind code = CodeResolverRegistry.Lookup<BasicConfidentialityKind>(typeof(BasicConfidentialityKind), "11488-4", "2.16.840.1.113883.6.1");
		    return new CodedTypeR2<BasicConfidentialityKind>(code);
	    }

	    private CodedTypeR2<ConsultDocumentType> GetLoincCode() {
            ConsultDocumentType code = CodeResolverRegistry.Lookup<ConsultDocumentType>(typeof(ConsultDocumentType), "11488-4", "2.16.840.1.113883.6.1");
		
		    CodedTypeR2<ConsultDocumentType> loincCode = new CodedTypeR2<ConsultDocumentType>();
		    loincCode.Code = code;
		    loincCode.CodeSystemName = "LOINC";
		    loincCode.DisplayName = "ConsultationNote";
		
		    return loincCode;
        }
    }

}
