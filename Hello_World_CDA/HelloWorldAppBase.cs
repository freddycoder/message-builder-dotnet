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
using System.IO;
using System.Text;
using System.Xml;
using Ca.Infoway.Messagebuilder;
using Ca.Infoway.Messagebuilder.Error;
using Ca.Infoway.Messagebuilder.Model;
using Ca.Infoway.Messagebuilder.Marshalling;
using Ca.Infoway.Messagebuilder.Util.Xml;
using Platform.Xml.Sax;

namespace Hello_World_CDA {

    public abstract class HelloWorldAppBase {

        public static readonly VersionNumber MBSpecificationVersion = SpecificationVersion.CCDA_R1_1;

        protected string ProcessDocumentObject(IClinicalDocument clinicalDocument) {

            // the transformer would ideally be cached
            CdaModelToXmlResult result = CreateTransformer().TransformToDocument(MBSpecificationVersion, clinicalDocument);

            Console.WriteLine("\nDocument (converted to XML):\n");

            // IMPORTANT NOTE: it is the application's responsibility to add a valid xml header to the xml output
            //                 (this feature is under consideration for a future version of MB)

            string documentXml = result.GetXmlDocument();
            Console.WriteLine(documentXml);

            ReportErrorsAndWarnings(result, true, true);

            return documentXml;
        }

        protected IClinicalDocument ProcessDocumentXml(string documentXml) {

            IClinicalDocument document = null;

            // the transformer would ideally be cached
            ClinicalDocumentTransformer transformer = CreateTransformer();

            // this is a W3C DOM Document (not to be confused with a CDA Document)
            XmlDocument xmlAsDoc = CreateW3CDocument(documentXml);

            XmlToCdaModelResult result = transformer.TransformFromDocument(MBSpecificationVersion, xmlAsDoc);

            document = (IClinicalDocument)result.GetClinicalDocumentObject();

            ReportErrorsAndWarnings(result, false, false);

            return document;
        }

        private void ReportErrorsAndWarnings(TransformErrors errors, bool toXml, bool includeInfo) {
            string message = (toXml ? "Document object to XML" : "Document XML to object");
            if (errors.IsValid()) {
                Console.WriteLine("\n\nNo errors or warnings to report from converting " + message + ".\n");
            } else {
                Console.WriteLine("\n\nErrors/warnings from converting " + message + ":\n");
            }
            // printing everything (to include INFO messages as well)
            foreach (TransformError transformError in errors.GetErrors()) {
                if (includeInfo || transformError.GetErrorLevel() != ErrorLevel.INFO) {
                    Console.WriteLine(transformError);
                }
            }
        }

        protected ClinicalDocumentTransformer CreateTransformer() {
            // PERMISSIVE is the default setting for the transformer; this allows processing to continue even if errors are detected

            // this creates a transformer using the local timezone and PERMISSIVE
            // return new MessageBeanTransformerImpl();

            // this creates a transformer using the local timezone and explicitly sets PERMISSIVE
            // return new MessageBeanTransformerImpl(RenderMode.PERMISSIVE);

            // specify a time zone when using the transformer 
            // (not absolutely necessary, if not set, local timezone is used)
            // Note: a time zone can also be specified for each individual transform, overriding any provided in the constructor
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            return new ClinicalDocumentTransformer(timeZone, timeZone);
        }

        private XmlDocument CreateW3CDocument(String xml) {

            // there are many ways to end up with a W3C XML Document; this one shows creating one from a String

            XmlDocument result = null;
            try {
                result = new DocumentFactory().CreateFromString(xml);
            } catch (SAXException e) {
                Console.Write("SAXException in HelloWorldApp.CreateXmlDocument() method");
                Console.WriteLine(e.StackTrace);
            }
            return result;
        }

        public static string ReadResourceFile(string resourceName) {
            string contents = null;
            Stream stream = GetEmbeddedFile("Hello_World_CDA", resourceName);
            contents = ConvertStreamToString(stream);
            return contents;
        }


        private static Stream GetEmbeddedFile(string assemblyName, string fileName) {
            try {
                System.Reflection.Assembly a = System.Reflection.Assembly.Load(assemblyName);
                Stream str = a.GetManifestResourceStream(assemblyName + "." + fileName);

                if (str == null)
                    throw new Exception("Could not locate embedded resource '" + fileName + "' in assembly '" + assemblyName + "'");
                return str;
            } catch (Exception e) {
                throw new Exception(assemblyName + ": " + e.Message);
            }
        }

        private static String ConvertStreamToString(Stream memStream) {
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
    }

}