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
using Ca.Infoway.Messagebuilder.Model.Ccda_r1_1.Consultationnote;
using Ca.Infoway.Messagebuilder.Resolver.Configurator;

namespace Hello_World_CDA {

    public class ConsultationNoteHelloWorldApp : HelloWorldAppBase {

        private string documentXml = "Resources.ConsultationNote.xml";

        public void Run(string[] args) {
            ConsultationNoteHelloWorldApp app = new ConsultationNoteHelloWorldApp();

            app.CreateDocumentBeanAndConvertToXml();

            app.ObtainDocumentXmlAndConvertToBean();
        }

        public void CreateDocumentBeanAndConvertToXml() {

            // this method creates a ConsultationNote object and populates various fields (attempting to match some but not all values in the sample CDA ConsultationNote xml)

            // Relaxes code vocabulary code checks and sets up some basic code resolvers
            DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();

            ConsultationNoteCreator consultationNoteCreator = new ConsultationNoteCreator();
            ConsultationNoteDocument consultationNote = consultationNoteCreator.CreateConsultationNote();

            string xml = ProcessDocumentObject(consultationNote);

            // note the errors reported about missing the "History of Present Illness Section" - so let's add that section now
            consultationNoteCreator.AddHistoryOfPresentIllness(consultationNote);

            Console.WriteLine("\n\nModifying objects to clear out some errors. Re-converting to xml");
            xml = ProcessDocumentObject(consultationNote);

            // xml can now be used as necessary (embedded in message, sent using a transport mechanism, etc)
        }

        public void ObtainDocumentXmlAndConvertToBean() {

            Console.WriteLine("\n\nNow taking a large sample document (as xml) and converting to objects.\n");

            // this method takes a full sample ConsultationNote document and converts it into objects, walking the object model and printing out various fields

            // Relaxes code vocabulary code checks and sets up some basic code resolvers.
            // This only needs to be done once (which occurred in createDocumentBeanAndConvertToXml()), but including it here for completeness.
            DefaultCodeResolutionConfigurator.ConfigureCodeResolversWithTrivialDefault();

            String xml = ReadResourceFile(this.documentXml);

            ConsultationNote consultationNote = (ConsultationNote)ProcessDocumentXml(xml);

            ConsultationNoteAccessor consultationNoteAccessor = new ConsultationNoteAccessor();
            consultationNoteAccessor.ProcessConsultationNote(consultationNote);

        }

    }
}