using System;
using System.Xml;
using System.Reflection;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Interaction;
using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Merged;
using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Rcmr_mt000002ab;
using Ca.Infoway.Messagebuilder.Model.Cda_ab_shr.Caabtranscribedreports;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Quqi_mt020000ab;
using Ca.Infoway.Messagebuilder.Model.Ab_r02_04_03_shr.Common.Rcmr_mt000004ab;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Terminology.Proxy;
using Ca.Infoway.Messagebuilder.Platform;
using Platform.Xml.Sax;
using Ca.Infoway.Messagebuilder.Domainvalue.Transport;
using System.Runtime.InteropServices;

namespace Hello_World
{
    class Application
    {
        public void Run()
        {
            this.Setup();
            Console.WriteLine("Start:");

            //Build test request message
            IInteraction request = this.CreateRequest();

            string xmlRequest = this.ConvertMessageObjectToXML(request, SpecificationVersion.R02_04_03_SHR_AB);
            Console.WriteLine("XML request:");
            Console.WriteLine(xmlRequest);

            //Submit Request and recieve response
            string xmlResponse = this.SubmitRequest(xmlRequest);

            //Process Response 
            IInteraction response = this.ConvertXMLToMessageObject(xmlResponse, SpecificationVersion.R02_04_03_SHR_AB);

            //Reconvert response to xml and print to screen (before decoding)
            string xmlResponse2 = this.ConvertMessageObjectToXML(response, SpecificationVersion.R02_04_03_SHR_AB);
            Console.WriteLine("XML response:");
            Console.WriteLine(xmlResponse2);

            //Process response - decode cda portion of response and print to screen
            this.processResponse(response);

            Console.WriteLine("Done!");
        }

        private void Setup()
        {
            //Standard configuration with HL7v3 code resolution
            DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();

            //Separate configuration for CDA code resolution
            GenericCodeResolverRegistry cdaCodeResolverRegistry = new GenericCodeResolverRegistryImpl();

            Assembly cdaAssembly = Assembly.Load("message-builder-release-cda-ab-shr");

            cdaCodeResolverRegistry.Register(new CdaCodeResolver(
                new TypedCodeFactory(),
                ResourceLoader.GetResource(cdaAssembly, "/voc.xml"),
                ResourceLoader.GetResource(cdaAssembly, "/vocabNameMap.xml"),
                CdaCodeResolver.MODE_LENIENT
            ));

            CodeResolverRegistry.RegisterCodeResolverRegistryForVersion(SpecificationVersion.CDA_AB_SHR, cdaCodeResolverRegistry);
        }

        public void processResponse(IInteraction queryResponse)
        {
            DocumentDetailQueryResponse response = (DocumentDetailQueryResponse)queryResponse;

            var realmCodes = response.GetRealmCode();
            foreach (Realm realm in realmCodes)
            {
                Console.WriteLine("Realm Code: " + realm.CodeValue);
            }

            if (response.ControlActEvent.Subject != null)
            {
                foreach (RefersTo<DocumentInformation> refersTo in response.ControlActEvent.Subject) {
                    DocumentInformation documentInformation = refersTo.Act;
                    if (documentInformation != null)
                    {
                        Console.WriteLine("Document title: " + documentInformation.Title);
                        Console.WriteLine("Document text follws. ");
                        byte[] data = Convert.FromBase64String(documentInformation.Text.Content);
                        string decodedString = System.Text.Encoding.Default.GetString(data);
                        Console.WriteLine(decodedString);

                        CAABTranscribedReportsDocument encapsulatedDocument = (CAABTranscribedReportsDocument)this.ProcessDocumentXml(decodedString, SpecificationVersion.CDA_AB_SHR);
//                        Console.WriteLine(this.ConvertMessageObjectToXML(encapsulatedDocument, SpecificationVersion.CDA_AB_SHR));
                        if (encapsulatedDocument != null)
                        {
                            Console.WriteLine("Title from document: " + encapsulatedDocument.Title);

                            foreach(Author author in encapsulatedDocument.Author)
                            {
                                PersonName authorName = author.AssignedAuthor.AssignedPersonName;
                                Console.WriteLine("Document author: " + authorName.GivenName + " " + authorName.FamilyName);
                            }

                            Console.WriteLine(encapsulatedDocument.Component.NonXMLBodyText.Content);
                        }
                    }
                }
            }
        }

        public string SubmitRequest(string requestMsg)
        {
            string xmlResponse = ResourceUtil.ReadResourceFile("Resources.RCMR_IN000032AB.xml");
            return xmlResponse;
        }

        public IInteraction CreateRequest()
        {
            DocumentDetailQuery interaction = new DocumentDetailQuery();
            interaction.ControlActEvent = new TriggerEvent<QueryDefinition>();

            interaction.AddRealmCode(Realm.ALBERTA);
            interaction.Id = new Identifier(UUID.RandomUUID().ToString());
            return interaction;
        }


        public string ConvertMessageObjectToXML(IInteraction msg, VersionNumber version)
        {
            ModelToXmlResult xmlQuery = this.CreateTransformer().TransformToHl7(version, msg);
            return xmlQuery.GetXmlMessage();
        }

        public IInteraction ConvertXMLToMessageObject(String xml, VersionNumber version)
        {

            IInteraction msg = null;

            MessageBeanTransformerImpl transformer = this.CreateTransformer();
            try
            {
                XmlToModelResult result = transformer.TransformFromHl7(version, new DocumentFactory().CreateFromString(xml));
                msg = (IInteraction)result.GetMessageObject();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception in HelloWorldApp.Deserialize() method");
                throw new Exception(ex.ToString());
            }
            return msg;
        }

        protected MessageBeanTransformerImpl CreateTransformer()
        {
            TimeZoneInfo timeZone;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
            }
            else
            {
                throw new PlatformNotSupportedException();
            }

            return new MessageBeanTransformerImpl(timeZone, timeZone);
        }

        protected IClinicalDocument ProcessDocumentXml(string documentXml, VersionNumber version)
        {

            IClinicalDocument document = null;

            // the transformer would ideally be cached
            ClinicalDocumentTransformer transformer = CreateCDATransformer();

            // this is a W3C DOM Document (not to be confused with a CDA Document)
            XmlDocument xmlAsDoc = CreateW3CDocument(documentXml);

            XmlToCdaModelResult result = transformer.TransformFromDocument(version, xmlAsDoc);

            document = (IClinicalDocument)result.GetClinicalDocumentObject();

            return document;
        }

        protected ClinicalDocumentTransformer CreateCDATransformer()
        {
            // PERMISSIVE is the default setting for the transformer; this allows processing to continue even if errors are detected

            // this creates a transformer using the local timezone and PERMISSIVE
            // return new MessageBeanTransformerImpl();

            // this creates a transformer using the local timezone and explicitly sets PERMISSIVE
            // return new MessageBeanTransformerImpl(RenderMode.PERMISSIVE);

            // specify a time zone when using the transformer 
            // (not absolutely necessary, if not set, local timezone is used)
            // Note: a time zone can also be specified for each individual transform, overriding any provided in the constructor
            TimeZoneInfo timeZone;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                timeZone = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
            }
            else
            {
                throw new PlatformNotSupportedException();
            }

            return new ClinicalDocumentTransformer(timeZone, timeZone);
        }

        private XmlDocument CreateW3CDocument(String xml)
        {

            // there are many ways to end up with a W3C XML Document; this one shows creating one from a String

            XmlDocument result = null;
            try
            {
                result = new DocumentFactory().CreateFromString(xml);
            }
            catch (SAXException e)
            {
                Console.Write("SAXException in HelloWorldApp.CreateXmlDocument() method");
                Console.WriteLine(e.StackTrace);
            }
            return result;
        }
    }
}
