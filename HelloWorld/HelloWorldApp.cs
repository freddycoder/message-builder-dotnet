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
﻿using System;
using System.IO;
using System.Text;
using System.Xml;

using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Datatype.Lang.Util;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using Ca.Infoway.Messagebuilder.Transport;
using Ca.Infoway.Messagebuilder.Transport.Rest;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Domainvalue.Basic;
using Ca.Infoway.Messagebuilder.Domainvalue.Transport;
using Ca.Infoway.Messagebuilder.Domainvalue.Payload;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Merged;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Merged;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Mcci_mt002100ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt240002ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt050207ca;
using Ca.Infoway.Messagebuilder.Transport.Mohawk;

namespace Hello_World
{
    public enum ServiceType { SIMULATED, SOAP, REST, UNKNOWN };

    abstract class HelloWorldApp
    {
        // Two abstract methods to be implemented by subclass.
        protected abstract IInteraction CreateRequestInteraction();
        protected abstract void ProcessResponseInteraction(IInteraction message);

        protected bool isSimulatedMode = false;
        protected string responseExampleResourceFileName = null;

        public static VersionNumber MBSpecificationVersion = SpecificationVersion.R02_04_02;
        
        public void Run(string[] args)
        {
            string username = "";
            string passwd = "";
            string serviceType = "";

		    if (args.Length == 1) {
			    isSimulatedMode = true;
			    serviceType = "simulated";
		    } else if (args.Length == 4) {
			    username = args[1];
			    passwd = args[2];
			    serviceType = args[3];
		    } else {
			    Console.WriteLine("Please use no argument for simulated mode. Or enter userid and " +
							    "password and serviceType as arguments for REST or SOAP mode.");
                Console.WriteLine("Exited");
                Environment.Exit(0);
		    }

            // Relaxes code vocabulary code checks.
            DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();
                
            IInteraction msg = this.CreateRequestInteraction();
            CredentialsProvider credentials = this.CreateCredentialsProvider(username, passwd);

            string xmlResponse = this.SubmitRequest(msg, credentials, this.ServiceTypeFor(serviceType));

		    Console.WriteLine("\n\nHere's the response (XML):\n");
		    Console.WriteLine(xmlResponse);

            IInteraction interaction = this.ConvertXMLToMessageObject(xmlResponse);
		
		    this.ProcessResponseInteraction(interaction);
            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadLine();
        }

        private ServiceType ServiceTypeFor(string value) {
    	    if (value.StartsWith("simulated")) {
    		    Console.WriteLine("INFO: Simulated transport is used.");
    		    return ServiceType.SIMULATED;
    	    }else if (value.StartsWith("soap")) {
    		    Console.WriteLine("INFO: SOAP transport is used.");
    		    return ServiceType.SOAP;
    	    }
    	    else if (value.StartsWith("rest")) {
                Console.WriteLine("INFO: REST transport is used.");
    		    return ServiceType.REST;
    	    }
    	    else return ServiceType.UNKNOWN;
        }

        protected string SubmitRequest(IInteraction msg, 
			CredentialsProvider credentials,
			ServiceType serviceType) 
        {
		    string xmlRequest = this.ConvertMessageObjectToXML(msg);
            
            xmlRequest = Beautify(xmlRequest);
            
		    Console.WriteLine("\nRequest Message (in XML):\n");
		    Console.WriteLine(xmlRequest);

            // Use Message Builder validator to validate the message
            MessageValidator.Validate(xmlRequest, MBSpecificationVersion);

            string xmlResponse = "<null/>";
		    switch(serviceType) 
            {
		        case ServiceType.SIMULATED:
                    if (responseExampleResourceFileName != null)
                    {
                        Console.WriteLine("Deserializing example XML response from resource bundle: {0}\n", responseExampleResourceFileName);
			            xmlResponse = HelloWorldApp.ReadResourceFile(responseExampleResourceFileName);
				        return xmlResponse;
			        }else {
				        Console.WriteLine("No example XML response is specified");
                        Environment.Exit(1);
			        }
                    break;
		        case ServiceType.SOAP:
                    xmlResponse = this.SubmitSoapServiceRequest(xmlRequest, credentials);
			        break;
		        case ServiceType.REST:
			        xmlResponse = this.SubmitRestServiceRequest(xmlRequest, credentials);
			        break;
		        default:
			        Console.WriteLine("No service type specified in command-line");
                    Environment.Exit(1);
                    break;
		    }

            return xmlResponse;
		}

        private string SubmitRestServiceRequest(string xmlRequest, CredentialsProvider credentials) 
        {
            /* NOTE: 
             * This code is intended to be used for reference only and it 
             * may not return any response or meaningful response during 
             * the execution of the program.  Appropriate code change needs 
             * to be made to work with your specific REST based service provider.
             */

            string serviceURL = "http://tl7.intelliware.ca/rest";

		    string xmlResponse = new RestTransportLayer(serviceURL).SendRequestAndGetResponse(
				    credentials, SimpleRequestMessage.Create(xmlRequest));

		    return xmlResponse;
	    }

        private string SubmitSoapServiceRequest(string xmlRequest, CredentialsProvider credentials)
        {
            /* NOTE: 
             * This code is intended to be used for reference only and it 
             * may not return any response or meaningful response during 
             * the execution of the program.  Appropriate code change needs 
             * to be made to work with your specific SOAP based service provider.
             */

            MohawkTransportLayer transportLayer = new MohawkTransportLayer();

            RequestMessage requestMessage = null;
            try
            {
                requestMessage = SimpleRequestMessage.Create(new DocumentFactory().CreateFromString(xmlRequest));
            }
            catch (TransportLayerException e)
            {
                Console.WriteLine(e.StackTrace);
            }
            String xmlResponse = transportLayer.SendRequestAndGetResponse(credentials, requestMessage);
            return xmlResponse;
        }

        protected MessageBeanTransformerImpl CreateTransformer()
        {
            // PERMISSIVE is the default setting for the transformer; this allows processing to continue even if errors are detected

            // this creates a transformer using the local timezone and PERMISSIVE
            // return new MessageBeanTransformerImpl();

            // this creates a transformer using the local timezone and explicitly sets PERMISSIVE
            // return new MessageBeanTransformerImpl(RenderMode.PERMISSIVE);

            // specify a time zone when using the transformer 
            // (not absolutely necessary, if not set, local timezone is used)
            // Note: a time zone can also be specified for each individual transform, overriding any provided in the constructor
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return new MessageBeanTransformerImpl(timeZone, timeZone);
        }

        protected string ConvertMessageObjectToXML(IInteraction msg)
        {
            ModelToXmlResult xmlQuery = this.CreateTransformer().TransformToHl7AndReturnResult(
                     MBSpecificationVersion, msg);
            return xmlQuery.GetXmlMessage();
        }

        protected IInteraction ConvertXMLToMessageObject(String xml)
        {

            IInteraction msg = null;

            MessageBeanTransformerImpl transformer = this.CreateTransformer();
            try
            {
                XmlToModelResult result = transformer.TransformFromHl7(MBSpecificationVersion, new DocumentFactory().CreateFromString(xml));
                msg = (IInteraction)result.GetMessageObject();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception in HelloWorldApp.Deserialize() method");
                throw new Exception(ex.ToString());
            }
            return msg;
        }

        protected CredentialsProvider CreateCredentialsProvider(string userid, string password)
        {
            return new _CredentialsProvider_35(userid, password);
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

        protected void SetTransportWrapperValues<CAE>(HL7Message<CAE> message) 
        {
            // Fill in transport wrapper portion

            Identifier ii = new Identifier(System.Guid.NewGuid().ToString());
            message.Id = ii;

            DateTime now = DateTime.Now;
            DateTime dateTime = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 12);
            
            message.CreationTime = new Ca.Infoway.Messagebuilder.PlatformDate(dateTime);

            message.ProcessingModeCode = ProcessingMode.CURRENT_PROCESSING;

            Identifier profileId = new Identifier("2.16.840.1.113883.2.20.2", "R02.04.02");
            Identifier abProfileId = new Identifier("2.16.840.1.113883.3.19.3.163.8", "AB-EHR");
            message.ProfileId.Add(profileId);
            message.ProfileId.Add(abProfileId);

            message.ProcessingCode = ProcessingID.PRODUCTION;
            message.AcceptAckCode = AcknowledgementCondition.ALWAYS;
            message.ResponseModeCode = ResponseMode.IMMEDIATE;

            // Set Receiver (system that this query is addressed to)
            Receiver receiver = new Receiver();
            message.Receiver = receiver;
            receiver.DeviceId = new Identifier("2.16.840.1.113883.3.19.3.163.8", "EHR");
            receiver.Telecom = new TelecommunicationAddress(URLScheme.HTTP, "www.ehr.ca/ehr");
            receiver.DeviceAgentAgentOrganizationId = null;

            // Set Sender
            message.Sender = new Sender();
            message.Sender.DeviceId = new Identifier("2.16.840.1.113883.3.19.3.163.8", "DR-BLACK-EMR");
            message.Sender.DeviceManufacturerModelName= "5.0";
            message.Sender.DeviceSoftwareName = "Infoway EMR";
            TelecommunicationAddress tel = new TelecommunicationAddress();
            tel.Address = "www.infoway-inforoute.ca/emr";
            tel.UrlScheme = URLScheme.HTTP;
            message.Sender.Telecom = tel;
            message.Sender.DeviceAgentAgentOrganizationId = null;
        }

        protected Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt240012ca.ServiceLocation CreateServiceLocation()
        {
            Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt240012ca.ServiceLocation location = new Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt240012ca.ServiceLocation();
            location.Id = new Identifier("2.16.840.1.113883.19.3.163.9", "DR-BLACK-CLINIC");
            location.LocationName = "Dr. Black Family Physician Offices";
            return location;
        }

        protected ServiceLocation CreateServiceLocation2() {
            ServiceLocation location = new ServiceLocation();
            location.Id = new Identifier(
                    "2.16.840.1.113883.19.3.163.9", "DR-BLACK-CLINIC");

            location.LocationName = "Dr. Black Family Physician Offices";
            return location;
        }

        protected CreatedBy_2 CreateAuthor_2()
        {
            CreatedBy_2 author = new CreatedBy_2();
            author.Time = new PlatformDate();

            Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt090102ca.HealthcareWorker authorPerson =
                new Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt090102ca.HealthcareWorker();
           
            Identifier healthcareProviderId = new Identifier("2.16.840.1.113883.3.19.3.163.1.2", "200202888");

            PersonName pn = PersonName.CreateFirstNameLastName("Samantha", "Black");
            EntityNamePart prefix = new EntityNamePart("Dr.", PersonNamePartType.PREFIX);
            pn.Uses.Add(EntityNameUse.LEGAL);
            pn.AddNamePart(prefix);

            authorPerson.Id.Add(new Identifier("2.16.840.1.113883.3.19.3.163.77.1", "samantha.black"));
            authorPerson.AssignedPerson = new ActingPerson();
            authorPerson.AssignedPerson.Name = pn;
            authorPerson.AssignedPerson.AsHealthCareProviderId = healthcareProviderId;            
            
            author.AuthorPerson = authorPerson;

            return author;
        }

        protected CreatedBy_1 CreateAuthor_1()
        {
            CreatedBy_1 author = new CreatedBy_1();
            author.Time = new PlatformDate();

            Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt090102ca.HealthcareWorker authorPerson =
                new Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Common.Coct_mt090102ca.HealthcareWorker();

            Identifier healthcareProviderId = new Identifier(
                    "2.16.840.1.113883.3.19.3.163.1.2", "200202888");

            PersonName pn = PersonName.CreateFirstNameLastName("Samantha", "Black");
            EntityNamePart prefix = new EntityNamePart("Dr.",
                    PersonNamePartType.PREFIX);
            pn.Uses.Add(EntityNameUse.LEGAL);
            pn.AddNamePart(prefix);

            Identifier id = new Identifier("2.16.840.1.113883.3.19.3.163.77.1",
            "samantha.black");

            authorPerson.AssignedPerson = new ActingPerson();
            authorPerson.AssignedPerson.AsHealthCareProviderId = healthcareProviderId;
            authorPerson.AssignedPerson.Name = pn;

            authorPerson.Id.Add(id);
            author.AuthorPerson = authorPerson;

            return author;
        }

        // Record Target Set up
        protected Patient CreateRecordTarget()
        {
            // Set the Patient we're querying against
            Patient patient = new Patient();

            // Set patient identifier(s)d
            patient.Id.Add(new Identifier("2.16.840.1.113883.3.19.3.163.1", "9880897949"));

            // Set Patient Name
            patient.PatientPerson = new ActingPerson();
            patient.PatientPerson.Name = PersonName.CreateFirstNameLastName("Cyril", "Lambert");
            EntityNamePart prefix = new EntityNamePart("Mr.", PersonNamePartType.PREFIX);
            patient.PatientPerson.Name.Uses.Add(EntityNameUse.LEGAL);
            patient.PatientPerson.Name.AddNamePart(prefix);

            // Now set the patient's birthdate
            patient.PatientPerson.BirthTime = new PlatformDate(new DateTime(1949, 11, 05)); // client birth date

            // Set Gender
            patient.PatientPerson.AdministrativeGenderCode = AdministrativeGender.MALE;

            // Set the address for this patient
            PostalAddress addr = new PostalAddress();

            addr.Uses.Add(X_BasicPostalAddressUse.HOME);
            addr.Uses.Add(X_BasicPostalAddressUse.PHYSICAL);
            addr.Uses.Add(X_BasicPostalAddressUse.POSTAL);

            PostalAddressPart part = new PostalAddressPart();
            part.Type = null;
            part.Value = "1234 Main Street";
            addr.AddPostalAddressPart(part);

            part = new PostalAddressPart();
            part.Type = PostalAddressPartType.CITY;
            part.Value = "Calgary";
            addr.AddPostalAddressPart(part);

            part = new PostalAddressPart();
            part.Type = PostalAddressPartType.STATE;
            part.Value = "Alberta";
            addr.AddPostalAddressPart(part);

            part = new PostalAddressPart();
            part.Type = PostalAddressPartType.COUNTRY;
            part.Value = "Canada";
            addr.AddPostalAddressPart(part);
         
            patient.Addr = addr;

            return patient;
        }
        


        public static string ReadResourceFile(string resourceName) 
        {
            string contents = null;
            Stream stream = GetEmbeddedFile("Hello_World", resourceName);
            contents = ConvertStreamToString(stream);
            return contents;
        }


        private static Stream GetEmbeddedFile(string assemblyName, string fileName)
        {
            try
            {
                System.Reflection.Assembly a = System.Reflection.Assembly.Load(assemblyName);
                Stream str = a.GetManifestResourceStream(assemblyName + "." + fileName);

                if (str == null)
                    throw new Exception("Could not locate embedded resource '" + fileName + "' in assembly '" + assemblyName + "'");
                return str;
            }
            catch (Exception e)
            {
                throw new Exception(assemblyName + ": " + e.Message);
            }
        }

        private static String ConvertStreamToString(Stream memStream) 
        {
		    /*
		     * To convert the InputStream to String we use the BufferedReader.readLine()
		     * method. We iterate until the BufferedReader return null which means
		     * there's no more data to read. Each line will appended to a StringBuilder
		     * and returned as String.
		     */
		    if (memStream != null) {
			    StringBuilder sb = new StringBuilder();
			    String line;

				StreamReader reader = new StreamReader(memStream);

				while ((line = reader.ReadLine()) != null) {
					sb.Append(line).Append("\n");
				}

			    return sb.ToString();
		    } else {       
			    return null;
		    }
	    }

        static public string Beautify(string text)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(text);

            return Beautify(document);
        }

        static public string Beautify(XmlDocument document)
        {

            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "  ";
            settings.NewLineChars = "\r\n";
            settings.NewLineHandling = NewLineHandling.Replace;
            XmlWriter writer = XmlWriter.Create(sb, settings);
            document.Save(writer);
            writer.Close();
            return sb.ToString();
        }

    }
}
