/**
 * Copyright 2012 Canada Health Infoway, Inc.
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
 * Last modified: $LastChangedDate: 2012-01-18 20:51:51 -0500 (Wed, 18 Jan 2012) $
 * Revision:      $LastChangedRevision: 3829 $
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
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Mfmi_mt700751ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Cr.Prpa_mt101103ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
using Ca.Infoway.Messagebuilder.Platform;
using Ca.Infoway.Messagebuilder.Terminology;
using Ca.Infoway.Messagebuilder.Terminology.Configurator;
using Ca.Infoway.Messagebuilder.Transport;
using Ca.Infoway.Messagebuilder.Transport.Rest;
using Ca.Infoway.Messagebuilder.Version;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
using ActCode = Ca.Infoway.Messagebuilder.Domainvalue.ActCode;
using ActStatus = Ca.Infoway.Messagebuilder.Domainvalue.ActStatus;
using HL7TriggerEventCode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.HL7TriggerEventCode;
using PostalAddressUse = Ca.Infoway.Messagebuilder.Datatype.Lang.PostalAddressUse;
using URLScheme = Ca.Infoway.Messagebuilder.Domainvalue.URLScheme;

namespace FindCandidatesQueryExample
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
                        CreateFindCandidatesQuery());

                Console.WriteLine("Here's the request:");
                Console.WriteLine(xmlRequest.GetXmlMessage());

                String xmlResponse = new RestTransportLayer(URL).SendRequestAndGetResponse(
                        new _CredentialsProvider_35(args[0], args[1]),
                        SimpleRequestMessage.Create(xmlRequest.GetXmlMessage()));

                Console.WriteLine("Here's the response:");
                Console.WriteLine(xmlResponse);
            }
        }


        private static FindCandidatesQuery CreateFindCandidatesQuery()
        {
            FindCandidatesQuery messageBean = new FindCandidatesQuery();

            TriggerEvent<ParameterList> controlActEvent = new TriggerEvent<ParameterList>();
            messageBean.ControlActEvent = controlActEvent;

            controlActEvent.EventType = HL7TriggerEventCode.FIND_CANDIDATES_QUERY;

            populateMessageAttributesStandardValues(messageBean);
            populateRecordControlActStandardValues(controlActEvent);

            // payload
            controlActEvent.QueryByParameter = new Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.QueryByParameter<ParameterList>();
			controlActEvent.QueryByParameter.QueryIdentifier = new Identifier("12.34.5", "11222211");
			controlActEvent.QueryByParameter.ParameterList = new ParameterList();
			controlActEvent.QueryByParameter.ParameterList.ClientName.Add(PersonName.CreateFirstNameLastName("J", "Smith"));

            return messageBean;
        }

        private static void populateMessageAttributesStandardValues(FindCandidatesQuery message)
        {

            message.MessageIdentifier = new Identifier(UUID.RandomUUID().ToString());

            message.MessageTimestamp = new PlatformDate(new DateTime(2008, 6, 25, 14, 16, 10));
            message.ConformanceProfileIdentifiers.Add(new Identifier("1.2.3.4.5", "profileIdExtension"));
            message.ProcessingCode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingID.PRODUCTION;
			message.ProcessingMode = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ProcessingMode.CURRENT_PROCESSING;
            message.DesiredAcknowledgmentType = Ca.Infoway.Messagebuilder.Domainvalue.Transport.AcknowledgementCondition.ALWAYS;
            message.Receiver = new Receiver();
            message.Receiver.ReceiverApplicationIdentifier = new Identifier("2.16.124.113620.1.2.100", "222");

            message.Receiver.ReceiverNetworkAddress = new TelecommunicationAddress(CodeResolverRegistry.Lookup<URLScheme>("http"), "123.456.789.10");

            message.Sender = new Sender();
            message.Sender.SendingApplicationIdentifier = new Identifier("2.16.124.113620.1.2.100", "111");
            message.Sender.SendingSoftwareVersionNumber = (new Configuration()).Version;
            message.Sender.SendingApplicationName = (new Configuration()).Name;
            message.Sender.SendingNetworkAddress = new TelecommunicationAddress();
            message.Sender.SendingNetworkAddress.Address = "987.654.321.0";
            message.Sender.SendingNetworkAddress.UrlScheme = CodeResolverRegistry.Lookup<URLScheme>("http");
            message.ResponseType = Ca.Infoway.Messagebuilder.Domainvalue.Transport.ResponseMode.IMMEDIATE;
        }

        private static void populateRecordControlActStandardValues(TriggerEvent<ParameterList> controlActEvent)
        {

            controlActEvent.EventIdentifier = new Identifier("2.16.840.1.113883.1.6", "8141234");
            controlActEvent.EventEffectivePeriod = IntervalUtil.CreateInterval(new PlatformDate(0), null);
            controlActEvent.Author = createAuthorBean();
            controlActEvent.DataEntryLocationServiceDeliveryLocation = createServiceDeliveryLocationBean();
            controlActEvent.ResponsiblePartyAssignedEntity = createAssignedPersonBean();
        }

        private static ServiceDeliveryLocation createServiceDeliveryLocationBean()
        {
            ServiceDeliveryLocation result = new ServiceDeliveryLocation();
            result.Id = new Identifier("2.16.124.113620.1.1.11111", "1");
            result.LocationName = "Intelliware's Pharmacy";
            return result;
        }

        private static Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker createAssignedPersonBean()
        {
            Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker assignedPersonBean = new Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged.HealthcareWorker();
            assignedPersonBean.HealthcareWorkerIdentifier.Add(new Identifier("12.34.56", "1"));
			assignedPersonBean.AssignedPerson = new ActingPerson();
			assignedPersonBean.AssignedPerson.LicenseNumber = new Identifier("12.34.56.78", "78");
			assignedPersonBean.HealthcareWorkerType = CodeResolverRegistry.Lookup<HealthcareProviderRoleType>("AUD", CodeSystem.VOCABULARY_ROLE_CODE.Root);
				
            return assignedPersonBean;
        }

        private static CreatedBy_2 createAuthorBean()
        {
            CreatedBy_2 authorBean = new CreatedBy_2();
            authorBean.TimeOfCreation = new PlatformDate(0);
            authorBean.AuthorPerson = createAssignedPersonBean();
            return authorBean;
        }

        private static Patient_1 createIdentifiedPersonBean()
        {

            Patient_1 identifiedPersonBean = new Patient_1();
            identifiedPersonBean.PatientIdentifier.Add(new Identifier("3.14", "159"));
            identifiedPersonBean.PatientAddress = createPostalAddress();
            identifiedPersonBean.PatientContactPhoneAndEMails.Add(new TelecommunicationAddress(
                    CodeResolverRegistry.Lookup<URLScheme>("http"), "123.456.789.10"));
			identifiedPersonBean.PatientPerson = new ActingPerson();
            identifiedPersonBean.PatientPerson.Name = PersonNameUtil.CreateFirstNameLastName("Alan", "Wall");

            identifiedPersonBean.PatientPerson.PatientGender =
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
            address1.AddUse(PostalAddressUse.HOME);
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
