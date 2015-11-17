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
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;
using Ca.Infoway.Messagebuilder.Xml.Validator;
using Ca.Infoway.Messagebuilder.Util.Xml;

namespace Hello_World_CDA {

    /// <summary>
    /// Example Message Validation. Uses the MB validation API to validate the files in the command-line arguments
    /// 
    /// The pan-Canadian specifications supported used are base R02.04.02 release.
    /// </summary>
    class ProcedureNoteMessageValidator {

        // Note: A ProcedureNote document that did not validate "cleanly" was intentionally chosen to illustrate the MB Validator.

        // A quick explanation as to what the reported errors/warnings might mean (a full investigation is required to know the exact nature of each problem):


        // 1) both of these errors are noting that the templates specified performer to have a cardinality of "1", but the message provided 2 

        //	ERROR: Association "performer" has a cardinality of "1", but 2 occurrences were found (<serviceEvent classCode="PCPR">)  at XPath: /ClinicalDocument/documentationOf/serviceEvent
        //	ERROR: Unexpected cardinality on : performer on ProcedureNote.ServiceEvent at XPath: /ClinicalDocument/documentationOf/serviceEvent/performer[1]


        // 2) a discrepancy between a fixed code in the templates and the actual code in the message

        //	ERROR: Invalid attribute value: expected "PPRF" but was "PRF" (<performer typeCode="PRF">) at XPath: /ClinicalDocument/documentationOf/serviceEvent/performer[1]/@typeCode


        // 3) These two errors appear contradictory, but the second is a side-effect of the first error. The first one indicates the code provided could not be found in the ActClass code 
        //    resolver. This led to the value not being passed on, and then the fixed code validation logged an error that the value was missing.

        //	ERROR: The code, "completed", in element <statusCode> is not a valid value for domain type "ActClass" at XPath: /ClinicalDocument/authorization/consent/statusCode
        //	ERROR: Fixed-value attribute 'statusCode' must have value 'completed' at XPath: /ClinicalDocument/authorization/consent/statusCode


        // 4) These are Schematron validation errors.

        //	ERROR: 	If a width is not present, the serviceEvent/effectiveTime SHALL include effectiveTime/high at XPath: null
        //	ERROR: 	When only the date and the length of the procedure are known a width element SHALL be present and the serviceEvent/effectiveTime/high SHALL not be present at XPath: null

        public void Run(string[] args) {
            Console.WriteLine("Validating a ProcedureNote document:\n");
            Validate();
        }
            
        private void Validate() {
            // Relaxes code vocabulary checks.
            DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();

            // a bit of a hack here - we need to force the assembly to load into memory
            Assembly.Load("message-builder-ccda-r1_1");

            ClinicalDocumentValidator validator = CreateNewValidator();

            CdaValidatorResult result = validator.Validate(CreateDocument("Resources.ProcedureNote.xml"), HelloWorldAppBase.MBSpecificationVersion);
            Console.WriteLine("There are " + CountErrorsAndWarnings(result.GetErrors()) + " errors and/or warnings\n");
            IEnumerator<TransformError> enumerator = result.GetErrors().GetEnumerator();
            while (enumerator.MoveNext()) {
                TransformError cdaError = enumerator.Current;
                if (cdaError.GetErrorLevel() != ErrorLevel.INFO) {
                    Console.WriteLine(cdaError.GetErrorLevel() + ": " + cdaError.GetMessage() + " at XPath: " + cdaError.GetPath());
                }
            }
        }

        private int CountErrorsAndWarnings(IList<TransformError> list) {
            int count = 0;
            foreach(TransformError transformError in list) {
                if (transformError.GetErrorLevel() != ErrorLevel.INFO) {
                    count++;
                }
            }
            return count;
        }

        private XmlDocument CreateDocument(string resourceName) {
            // For our example, we'll use the resource XML document that are in the assembly.
            return new DocumentFactory().CreateFromString(HelloWorldAppBase.ReadResourceFile(resourceName));
        }

        private ClinicalDocumentValidator CreateNewValidator() {
            return new ClinicalDocumentValidator();
        }
    }

}