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
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using System;
using Ca.Infoway.Messagebuilder.Marshalling.HL7;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Xml.Service;
using System.Xml;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Ca.Infoway.Messagebuilder.Model.Pcs_mr2009_r02_04_02.Interaction;
using System.Reflection;

namespace Hello_World {
    /**
     * <p>
     * Example Message Validation. Uses the MB validation API to validate the files
     * in the command-line arguments
     * </p>
     * <p>
     * The pan-Canadian specifications supported used are base R02.04.02 release.
     * 
     * </p>
     */
    class MessageValidator {

	    public void Run(string[] args) {
            // Relaxes code vocabulary code checks.
            DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();

            // a bit of a hack here - we need to force the MR2009 assembly to load into memory
            Assembly.Load("message-builder-release-r02_04_02");

            MessageValidator.Validate(HelloWorldApp.ReadResourceFile("Resources.PRPA_EX101104CA_validation.xml"), HelloWorldApp.MBSpecificationVersion);

            Console.WriteLine("\nDone validation. Press any key to exit.");
            Console.ReadLine();
        }

	    public static void Validate(string xmlString, VersionNumber versionNumber) {
		    try {
			    Console.WriteLine("\nValidation Errors: ");
			    XmlDocument document = new DocumentFactory().CreateFromString(xmlString);

                MessageValidatorImpl validator = CreateNewValidator();
                MessageValidatorResult result = validator.Validate(document, versionNumber);

			    Console.WriteLine("There are {0} errors\n", result.GetHl7Errors().Count);
                foreach (Hl7Error hl7Err in result.GetHl7Errors())
                {
                    Console.WriteLine("Error ({0}): {1} at XPath: {2}\n", hl7Err.GetHl7ErrorCode(), hl7Err.GetMessage(), hl7Err.GetPath());
			    }
		    } catch (Exception e) {
			    // XML parsing error
                Console.WriteLine(e.StackTrace);
            }
	    }

	    private static MessageValidatorImpl CreateNewValidator() {
		    return new MessageValidatorImpl();
	    }

    }
}