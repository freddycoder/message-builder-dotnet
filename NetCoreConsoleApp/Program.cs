using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Cr.Prpa_mt101103ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Mfmi_mt700751ca;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Interaction;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using System;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_03.Common.Merged;
using Ca.Infoway.Messagebuilder.Datatype.Lang;
using Ca.Infoway.Messagebuilder.Domainvalue.Payload;
using Ca.Infoway.Messagebuilder.Resolver;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Codesystem;

namespace NetCoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // the HL7v3 version to target
            SpecificationVersion version = SpecificationVersion.R02_04_03;

            // set up MB default code handling (not likely sufficient for a production environment!)
            // - see the Code Resolvers in User Guide for more details
            DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();

            // create the interaction
            FindCandidatesQuery findCandidatesRequest = new FindCandidatesQuery();

            // create the controlAct and set it on the interaction 
            TriggerEvent<ParameterList> controlAct = new TriggerEvent<ParameterList>();
            findCandidatesRequest.ControlActEvent = controlAct;

            // create an "intermediary" bean and set it on the controlAct 
            QueryByParameter<ParameterList> queryByParameter = new QueryByParameter<ParameterList>();
            controlAct.QueryByParameter = queryByParameter;

            // create the payload bean and set it on the "intermediary" bean 
            ParameterList parameterList = new ParameterList();
            queryByParameter.ParameterList = parameterList;

            // setting values on the payload
            PersonName name = PersonName.CreateFirstNameLastName("Jane", "Smith");
            parameterList.PersonNameValue.Add(name);
            parameterList.AdministrativeGenderValue = AdministrativeGender.FEMALE;

            // alternative way to create a code object via direct lookup
            Ca.Infoway.Messagebuilder.Domainvalue.AdministrativeGender codeLookup =
                CodeResolverRegistry.Lookup<AdministrativeGender>("F", CodeSystem.VOCABULARY_ADMINISTRATIVE_GENDER.Root);

            parameterList.AdministrativeGenderValue = codeLookup;

            // The transformer object which can convert objects <-> xml.
            // Note that it is set to permissive mode in order to allow errors to occur without throwing an exception; this
            // may be a desired setting even in production. 
            MessageBeanTransformerImpl messageTransformer = new MessageBeanTransformerImpl(RenderMode.PERMISSIVE);

            // transform the message object into its xml representation (also performs validation)
            ModelToXmlResult result = messageTransformer.TransformToHl7AndReturnResult(version, findCandidatesRequest);

            // the message produced (notice the errors listed within the xml message)
            Console.WriteLine(result.GetXmlMessage());

            // iterating through the errors detected by the MB validation component 
            foreach (Hl7Error hl7Error in result.GetHl7Errors())
            {
                Console.WriteLine(hl7Error);
            }
        }
    }
}
