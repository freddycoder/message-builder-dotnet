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
 * Last modified: $LastChangedDate: 2013-03-01 17:48:17 -0500 (Fri, 01 Mar 2013) $
 * Revision:      $LastChangedRevision: 6663 $
 */

using System;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Codesystem;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Domainvalue;
using Ca.Infoway.Messagebuilder.Lang;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt120600ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Terminology.Configurator;
using Ca.Infoway.Messagebuilder.Transport;
using Ca.Infoway.Messagebuilder.Transport.Rest;
using Ca.Infoway.Messagebuilder.Version;
using ActCode = Ca.Infoway.Messagebuilder.Domainvalue.ActCode;
using ActStatus = Ca.Infoway.Messagebuilder.Domainvalue.ActStatus;
using HL7TriggerEventCode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode;
using X_BasicPostalAddressUse = Ca.Infoway.Messagebuilder.Domainvalue.Basic.X_BasicPostalAddressUse;
using URLScheme = Ca.Infoway.Messagebuilder.Domainvalue.URLScheme;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Iehr.Merged;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Domainvalue;


namespace AddAllergyIntoleranceExample
{

    public class Program
    {
        private static String URL = "http://tl7.intelliware.ca/rest";

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Please enter userid and password as command-line arguments.");
            }
            else
            {
                registerResolvers();

                ModelToXmlResult xmlRequest = createTransformer().TransformToHl7AndReturnResult(
                        SpecificationVersion.R02_04_02,
                        createAddAllergyIntoleranceRequest());

                Console.WriteLine("Here's the request:");
                Console.WriteLine(xmlRequest.GetXmlMessage());

                String xmlResponse = new RestTransportLayer(URL).SendRequestAndGetResponse(
                        new _CredentialsProvider_35(args[0], args[1]),
                        SimpleRequestMessage.Create(xmlRequest.GetXmlMessage()));

                Console.WriteLine("Here's the response:");
                Console.WriteLine(xmlResponse);
            }
        }


        private static AddAllergyIntoleranceRequest createAddAllergyIntoleranceRequest()
        {
            AddAllergyIntoleranceRequest messageBean = new AddAllergyIntoleranceRequest();

            TriggerEvent_1<AllergyIntolerance> controlActEvent = new TriggerEvent_1<AllergyIntolerance>();
            messageBean.ControlActEvent = controlActEvent;

            controlActEvent.Code = HL7TriggerEventCode.ADD_ALLERGY_INTOLERANCE_REQUEST;

            populateMessageAttributesStandardValues(messageBean);
            populateRecordControlActStandardValues(controlActEvent);

            // payload
            controlActEvent.Subject = new RefersTo_1<AllergyIntolerance>();
            controlActEvent.Subject.Act = createAllergyIntoleranceBean();

            return messageBean;
        }

        private static AllergyIntolerance createAllergyIntoleranceBean()
        {

            AllergyIntolerance allergyIntoleranceBean = new AllergyIntolerance();

            allergyIntoleranceBean.StatusCode = CodeResolverRegistry.Lookup<ActStatus>("active", CodeSystem.VOCABULARY_ACT_STATUS.Root);

            allergyIntoleranceBean.Code =
                    CodeResolverRegistry.Lookup<ObservationIntoleranceType>("OINT", CodeSystem.VOCABULARY_ACT_CODE.Root);

            allergyIntoleranceBean.ConfidentialityCode.Add(
                    CodeResolverRegistry.Lookup<x_BasicConfidentialityKind>("N", CodeSystem.VOCABULARY_CONFIDENTIALITY.Root));

			AllergyIntoleranceSeverityLevel severityLevelBean = new AllergyIntoleranceSeverityLevel();
			severityLevelBean.Value =
					CodeResolverRegistry.Lookup<SeverityObservation>("H", CodeSystem.VOCABULARY_SEVERITY_OBSERVATION.Root);
			allergyIntoleranceBean.SubjectOfSeverityObservation = severityLevelBean;
			
            allergyIntoleranceBean.EffectiveTime = new PlatformDate(new DateTime(2009, 3, 22));

            allergyIntoleranceBean.NegationInd = true;

            allergyIntoleranceBean.UncertaintyCode =
                    CodeResolverRegistry.Lookup<ActUncertainty>("N", CodeSystem.VOCABULARY_ACT_UNCERTAINTY.Root);

            allergyIntoleranceBean.Value =
                    CodeResolverRegistry.Lookup<IntoleranceValue>("NDA02", CodeSystem.VOCABULARY_ENTITY_CODE.Root);

            allergyIntoleranceBean.SubjectOfSeverityObservation = severityLevelBean;

            allergyIntoleranceBean.Informant = createInformant();

            allergyIntoleranceBean.SubjectOf1 = createNote();

            allergyIntoleranceBean.SupportRecords.Add(createAllergyTestEvent());
            allergyIntoleranceBean.SupportRecords.Add(createAssessment());

            return allergyIntoleranceBean;
        }

        private static Includes createNote()
        {
            Notes annotation = new Notes();
            annotation.AuthorTime = new PlatformDate();
            annotation.Text = "some allergy/intolerance note text";
            annotation.AuthorAssignedPerson = createNoteAuthor();

			Includes includes = new Includes();
			includes.Annotation = annotation;
			
            return includes;
        }

        private static IAssignedPerson createNoteAuthor()
        {

            return createAssignedPersonBean();
        }

        private static ReportedBy createInformant()
        {
            ReportedBy informant = new ReportedBy();
            //informant.ReportedDate = new GregorianCalendar(1999, DECEMBER, 28).getTime();
            informant.Time = new PlatformDate(new DateTime(1999, 12, 28));
            informant.Party = createAssignedPersonBean();
            return informant;
        }

        private static void populateMessageAttributesStandardValues(AddAllergyIntoleranceRequest message)
        {

            message.Id = new Identifier(UUID.RandomUUID().ToString());

            message.CreationTime = new PlatformDate(new DateTime(2008, 6, 25, 14, 16, 10));
            message.ProfileId.Add(new Identifier("1.2.3.4.5", "profileIdExtension"));
            message.ProcessingCode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID.PRODUCTION;
			message.ProcessingModeCode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode.CURRENT_PROCESSING;
            message.AcceptAckCode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition.ALWAYS;
            message.Receiver = new Receiver();
            message.Receiver.DeviceId = new Identifier("2.16.124.113620.1.2.100", "222");

            message.Receiver.Telecom = new TelecommunicationAddress(CodeResolverRegistry.Lookup<URLScheme>("http"), "123.456.789.10");

            message.Sender = new Sender();
            message.Sender.DeviceId = new Identifier("2.16.124.113620.1.2.100", "111");
            message.Sender.DeviceManufacturerModelName = (new Configuration()).Version;
            message.Sender.DeviceName = (new Configuration()).Name;
            message.Sender.Telecom = new TelecommunicationAddress();
            message.Sender.Telecom.Address = "987.654.321.0";
            message.Sender.Telecom.UrlScheme = CodeResolverRegistry.Lookup<URLScheme>("http");
            message.ResponseModeCode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode.IMMEDIATE;
        }

        private static void populateRecordControlActStandardValues(TriggerEvent_1<AllergyIntolerance> controlActEvent)
        {

            controlActEvent.Id = new Identifier("2.16.840.1.113883.1.6", "8141234");
            controlActEvent.EffectiveTime = IntervalUtil.CreateInterval(new PlatformDate(0), null);
            controlActEvent.Author = createAuthorBean();
            controlActEvent.LocationServiceDeliveryLocation = createServiceDeliveryLocationBean();
            controlActEvent.ResponsiblePartyAssignedEntity = createAssignedPersonBean();
            controlActEvent.RecordTargetPatient1 = createIdentifiedPersonBean();

        }

        private static Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt240002ca.ServiceLocation createServiceDeliveryLocationBean()
        {
            Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt240002ca.ServiceLocation result = new Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt240002ca.ServiceLocation();
            result.Id = new Identifier("2.16.124.113620.1.1.11111", "1");
            result.LocationName = "Intelliware's Pharmacy";
            return result;
        }

        private static Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker createAssignedPersonBean()
        {
            Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker assignedPersonBean = new Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker();
            assignedPersonBean.Id.Add(new Identifier("12.34.56", "1"));
			assignedPersonBean.AssignedPerson = new ActingPerson();
			assignedPersonBean.AssignedPerson.AsHealthCareProviderId = new Identifier("12.34.56.78", "78");
			assignedPersonBean.Code = CodeResolverRegistry.Lookup<HealthcareProviderRoleType>("AUD", CodeSystem.VOCABULARY_ROLE_CODE.Root);
				
            return assignedPersonBean;
        }

        private static CreatedBy_1 createAuthorBean()
        {
            CreatedBy_1 authorBean = new CreatedBy_1();
            authorBean.Time = new PlatformDate(0);
            authorBean.AuthorPerson = createAssignedPersonBean();
            return authorBean;
        }

        private static Patient_1 createIdentifiedPersonBean()
        {

            Patient_1 identifiedPersonBean = new Patient_1();
            identifiedPersonBean.Id.Add(new Identifier("3.14", "159"));
            identifiedPersonBean.Addr = createPostalAddress();
            identifiedPersonBean.Telecom.Add(new TelecommunicationAddress(
                    CodeResolverRegistry.Lookup<URLScheme>("http"), "123.456.789.10"));
			identifiedPersonBean.PatientPerson = new ActingPerson();
            identifiedPersonBean.PatientPerson.Name = PersonName.CreateFirstNameLastName("Alan", "Wall");

            identifiedPersonBean.PatientPerson.AdministrativeGenderCode =
                CodeResolverRegistry.Lookup<AdministrativeGender>("F", CodeSystem.VOCABULARY_ADMINISTRATIVE_GENDER.Root);

            identifiedPersonBean.PatientPerson.BirthTime = new PlatformDate(new DateTime(1972, 2, 21));
            return identifiedPersonBean;
        }

        private static PostalAddress createPostalAddress()
        {
            return createPostalAddress("Bloor");
        }

        private static PostalAddress createPostalAddress(String streetName)
        {
            PostalAddress address1 = new PostalAddress();
            address1.AddUse(X_BasicPostalAddressUse.HOME);
            address1.AddPostalAddressPart(new PostalAddressPart(PostalAddressPartType.STREET_NAME, streetName));
            return address1;
        }

        private static AllergyTests createAllergyTestEvent()
        {

            AllergyTests allergyTestEvent = new AllergyTests();

            allergyTestEvent.Id = new Identifier("2.16.840.1.113883.1.13", "995");

            allergyTestEvent.Code =
                    CodeResolverRegistry.Lookup<ObservationAllergyTestType>("10921-5", CodeSystem.LOINC.Root);

            allergyTestEvent.Value =
                CodeResolverRegistry.Lookup<AllergyTestValue>("A3", CodeSystem.VOCABULARY_ALLERGY_TEST_VALUE.Root);


            allergyTestEvent.EffectiveTime = new PlatformDate(new DateTime(2009, 3, 10));

            return allergyTestEvent;
        }

        private static ReportedReactions createAssessment()
        {
			Exposures exposureEvent = new Exposures();
            exposureEvent.Id = new Identifier("2.16.840.1.113883.1.133", "12");
            exposureEvent.RouteCode = 
                    CodeResolverRegistry.Lookup<RouteOfAdministration>("CHEW", CodeSystem.VOCABULARY_ROUTE_OF_ADMINISTRATION.Root);
            exposureEvent.ConsumableAdministrableMaterialAdministerableMaterialKindCode =
                    CodeResolverRegistry.Lookup<ExposureAgentEntityType>("NDA05", CodeSystem.VOCABULARY_ENTITY_CODE.Root);
			
			AllergyIntoleranceSeverityLevel severityLevel = new AllergyIntoleranceSeverityLevel();
			severityLevel.Value = 
                    CodeResolverRegistry.Lookup<SeverityObservation>("H", CodeSystem.VOCABULARY_SEVERITY_OBSERVATION.Root);

			ReportedReactions subjectObservationEvent = new ReportedReactions();
			subjectObservationEvent.Id = new Identifier("2.16.840.1.113883.1.133", "15");
			subjectObservationEvent.Code =
                    CodeResolverRegistry.Lookup<ActDiagnosisCode>("371627004", CodeSystem.SNOMED.Root);
            subjectObservationEvent.NegationInd = false;
            subjectObservationEvent.Text = "description of assessment";
			subjectObservationEvent.EffectiveTime =
			        Interval<PlatformDate>.CreateLow(new PlatformDate(new DateTime(2008, 3, 17)));
			subjectObservationEvent.Value =
                    CodeResolverRegistry.Lookup<SubjectReaction>("Y45.1", CodeSystem.ICD10.Root);
			subjectObservationEvent.SubjectOfSeverityObservation = severityLevel;
		
			
			
			ReportedReactions assessmentBean = new ReportedReactions();
            assessmentBean.Code =
                    CodeResolverRegistry.Lookup<ActDiagnosisCode>("RXNASSESS", CodeSystem.VOCABULARY_ACT_CODE.Root);
			assessmentBean.StartsAfterStartOfExposureEvent = exposureEvent;
			assessmentBean.SubjectObservationEvent = subjectObservationEvent;

            return assessmentBean;
        }

        private static MessageBeanTransformerImpl createTransformer()
        {
            return new MessageBeanTransformerImpl();
        }

        private sealed class _CredentialsProvider_35 : CredentialsProvider
        {
            private readonly string _username;
            private readonly string _password;

            public _CredentialsProvider_35(string username, string password)
            {
                _username = username;
                _password = password;
            }

            public Credentials GetCredentials()
            {
                return new UsernamePasswordCredentials(_username, _password);
            }
        }



        private static void registerResolvers()
        {
            DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
            CodeResolverRegistry.RegisterResolver(typeof(ActCode),
                    new CompositeCodeResolver(
                            new EnumBasedCodeResolver(typeof(TrivialSeverityObservation)),
                            new TrivialCodeResolver()));
        }
    }

    class TrivialSeverityObservation : EnumPattern, Code
    {

        private long serialVersionUID = 6727127928910765846L;
        public static TrivialSeverityObservation SEV = new TrivialSeverityObservation("SEV");

        private TrivialSeverityObservation(String name)
            : base(name)
        {
        }

        static TrivialSeverityObservation() { }
        public string CodeValue
        {
            get { return Name; }
        }

        public string CodeSystem
        {
            get { return Ca.Infoway.Messagebuilder.Codesystem.CodeSystem.VOCABULARY_ACT_CODE.Root; }
        }
    }

}
