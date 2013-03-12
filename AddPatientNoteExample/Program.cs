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

namespace AddPatientNoteExample
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
                        CreateAddPatientNote());

                Console.WriteLine("Here's the request:");
                Console.WriteLine(xmlRequest.GetXmlMessage());

                String xmlResponse = new RestTransportLayer(URL).SendRequestAndGetResponse(
                        new _CredentialsProvider_35(args[0], args[1]),
                        SimpleRequestMessage.Create(xmlRequest.GetXmlMessage()));

                Console.WriteLine("Here's the response:");
                Console.WriteLine(xmlResponse);
            }
        }


        private static AddPatientNoteRequest CreateAddPatientNote()
        {
            AddPatientNoteRequest messageBean = new AddPatientNoteRequest();

            TriggerEvent_1<Comment> controlActEvent = new TriggerEvent_1<Comment>();
            messageBean.ControlActEvent = controlActEvent;

            controlActEvent.Code = HL7TriggerEventCode.FIND_CANDIDATES_QUERY;

            populateMessageAttributesStandardValues(messageBean);
            populateRecordControlActStandardValues(controlActEvent);

            // payload
			controlActEvent.Subject = new RefersTo_1<Comment>();
			controlActEvent.Subject.Act = CreateComment();

            return messageBean;
        }

        private static void populateMessageAttributesStandardValues(AddPatientNoteRequest message)
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
		
		private static Comment CreateComment() {
			Comment noteBean = new Comment();
			noteBean.Code =
					CodeResolverRegistry.Lookup<ActPatientAnnotationCode>("MED", CodeSystem.VOCABULARY_ACT_CODE.Root);
			noteBean.Text = "note text";
            noteBean.ConfidentialityCode.Add(Ca.Infoway.Messagebuilder.Domainvalue.Payload.Confidentiality.NORMAL);
			return noteBean;
		}
		
        private static void populateRecordControlActStandardValues(TriggerEvent_1<Comment> controlActEvent)
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
        }
    }

}
