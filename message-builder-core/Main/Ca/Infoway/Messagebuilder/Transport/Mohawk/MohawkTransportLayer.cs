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
 * Author:        $LastChangedBy: gng $
 * Last modified: $LastChangedDate: 2015-11-19 18:20:12 -0500 (Fri, 30 Jan 2015) $
 * Revision:      $LastChangedRevision: 9755 $
 */


using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Ca.Infoway.Messagebuilder.Platform;
using log4net;

namespace Ca.Infoway.Messagebuilder.Transport.Mohawk
{

    /// <summary>Implementation of a transport layer for sending messages to Mohawk HIAL via SOAP.</summary>
    /// <remarks>
    /// Implementation of a transport layer for sending messages to Mohawk HIAL via SOAP.
    /// SOAP is one of two common interfaces for HL7 messages.
    /// Makes use of Apache Commons HttpClient for communication.
    /// </remarks>
    /// <author>
    /// <a href="http://www.intelliware.ca/">Intelliware Development</a>
    /// sharpen.ignore - transport - TBD!
    /// </author>
    public class MohawkTransportLayer : TransportLayer
    {
        internal class StandardHttpClient : Client
        {
            public virtual int ExecuteMethod(PostMethod method)
            {
                var request = (HttpWebRequest)WebRequest.Create(method.Uri);

                request.Method = "POST";
                request.ContentType = method.MimeType;
                request.ContentLength = method.Content.Length;

                var requestStream = request.GetRequestStream();

                requestStream.Write(method.Content, 0, method.Content.Length);
                requestStream.Flush();
                requestStream.Close();

                try
                {
                    method.Response = (HttpWebResponse)request.GetResponse();

                }
                catch (WebException ex)
                {
                    //.NET throws if the server answers with a 500 status code
                    if (ex.Response != null)
                    {
                        method.Response = (HttpWebResponse)ex.Response;
                    }
                    else
                    {
                        throw;
                    }
                }

                return (int)method.Response.StatusCode;
            }
        }

        private readonly Client client;
        private readonly string url;
        private readonly ILog log = LogManager.GetLogger(typeof(MohawkTransportLayer));

        /// <summary>Constructs a Mohawk transport layer using a well-known url.</summary>
        /// <remarks>Constructs a Mohawk transport layer using a well-known url. Makes use of the default tranport mechanism (HttpClient)
        /// </remarks>
        public MohawkTransportLayer()
            : this("http://142.222.45.132:8080/soap/hl7/v3/ca/v2.04.2/Service.svc")
        {
        }

        /// <summary>Constructs a Mohawk transport layer for the given url.</summary>
        /// <remarks>Constructs a Mohawk transport layer for the given url. Makes use of the default tranport mechanism (HttpClient)
        /// </remarks>
        /// <param name="url">the target url to send messages to</param>
        public MohawkTransportLayer(string url)
            : this(new MohawkTransportLayer.StandardHttpClient(), url)
        {
        }

        /// <summary>Constructs a Mohawk transport layer for the given url.</summary>
        /// <remarks>Constructs a Mohawk transport layer for the given url. Makes use of provided client instead of the default HttpClient.
        /// </remarks>
        /// <param name="client">the transport client to use</param>
        /// <param name="url">the target url to send messages to</param>
        public MohawkTransportLayer(Client client, string url)
        {
            this.client = client;
            this.url = url;
        }

        /// <summary>Sends a request message synchronously and returns a response message as a string.</summary>
        /// <remarks>Sends a request message synchronously and returns a response message as a string.</remarks>
        /// <param name="credentialsProvider">object to obtain Credentials from</param>
        /// <param name="requestMessage">the message to be sent</param>
        /// <returns>the response message as a string</returns>
        /// <exception cref="Ca.Infoway.Messagebuilder.Transport.TransportLayerException">if any problems occurred</exception>
        public virtual string SendRequestAndGetResponse(CredentialsProvider credentialsProvider, RequestMessage requestMessage)
        {
            try
            {
                return PostMessage(requestMessage);
            }
            catch (IOException e)
            {
                throw new TransportLayerException(e);
            }
        }

        private string PostMessage(RequestMessage requestMessage)
        {
            return PostMethod(CreatePostMethod(requestMessage));
        }

        private string PostMethod(PostMethod method)
        {
            int statusCode = client.ExecuteMethod(method);

            if (IsOk(statusCode))
            {
                return UnwrapFromSoap(method);
            }

            log.Warn("Status code " + statusCode);

            throw new HttpTransportLayerException(statusCode);
        }

        private static string UnwrapFromSoap(PostMethod method)
        {
            var sr = new StreamReader(method.Response.GetResponseStream(), Encoding.Default);

            return new Hl7MessageExtractor().GetHl7Message(sr.BaseStream);
        }

        internal virtual PostMethod CreatePostMethod(RequestMessage requestMessage)
        {
            var name = requestMessage.GetInteractionId();

            var service = ServiceDefinition.GetService(name);

            if (service == null)
            {
                throw new TransportLayerException("Cannot find a Mohawk service for type " + name);
            }

            var method = new PostMethod(Concatenate(url, service.GetPath()));

            byte[] soapEnvelope = WrapInSoapEnvelope(requestMessage.GetMessageAsDocument(), service);

            method.MimeType = "application/soap+xml";
            method.Content = soapEnvelope;


            return method;
        }

        internal virtual byte[] WrapInSoapEnvelope(XmlDocument document, ServiceDefinition service)
        {
            return Encoding.Default.GetBytes(CreateSoapAction(service, document));

        }

        private string CreateSoapAction(ServiceDefinition service, XmlDocument document)
        {
            const string xmlVersionString = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            const string soapEnvelopeBeginString = "<env:Envelope xmlns:env=\"http://www.w3.org/2003/05/soap-envelope\" >";

            const string soapBodyBeginString = "<env:Body>";
            const string soapBodyEndString = "</env:Body>";

            const string soapHeaderBeginString = "<env:Header xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">";
            const string soapHeaderEndString = "</env:Header>";

            const string soapEnvelopeEndString = "</env:Envelope>";


            var actionXmlString = String.Format("<wsa:Action>{0}</wsa:Action>", service.GetAction());
            var fromXmlString = "<wsa:From><wsa:Address>http://anonymous</wsa:Address></wsa:From>";
            var messageXmlString = string.Format("<wsa:MessageID>{0}</wsa:MessageID>", new UUID());
            var toXmlString = string.Format("<wsa:To>{0}</wsa:To>", "http://bt-app.biztalk.marc-hi.ca:8080/soap/hl7/v3/ca/v2.04.2/service.svc");

            var sb = new StringBuilder();

            sb.Append(xmlVersionString);
            sb.Append(soapEnvelopeBeginString);

            sb.Append(soapHeaderBeginString);
            sb.Append(actionXmlString);
            sb.Append(fromXmlString);
            sb.Append(messageXmlString);
            sb.Append(toXmlString);
            sb.Append(soapHeaderEndString);

            sb.Append(soapBodyBeginString);
            sb.Append(document.OuterXml);
            sb.Append(soapBodyEndString);

            sb.Append(soapEnvelopeEndString);

            return sb.ToString();

        }

        private static string Concatenate(string url, string path)
        {
            if (url.EndsWith("/") && path.StartsWith("/"))
            {
                return url + path.Substring(1);
            }

            if (url.EndsWith("/") || path.StartsWith("/"))
            {
                return url + path;
            }

            return url + "/" + path;
        }

        private static bool IsOk(int statusCode)
        {
            return statusCode == 200;// HttpStatus.SC_OK;
        }
    }



}
